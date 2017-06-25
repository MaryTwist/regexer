define(['vue', 'url-helper', 'models/script', 'axios', 'config/api-address-config', 'components/w3-tab', 'components/w3-sidebar'], function (Vue, UrlHelper, Script, axios, api) {
    'use strict'

    new Vue({

        el: "#app",

        data: {

            helper: new UrlHelper(),

            scripts: null,
            currentScript: new Script(null, 'no-name', 'no description', '', '', new Date(), null),

            inputText: "",
            outputText: "",

            isSlidebarVisible: false,

            modals: {
                saveDialog: {
                    isActive: false
                }
            }

        },

        methods: {

            refleshList: function () {

                let self = this;

                axios.get(this.helper.Map(api.dataApiUrl, 'scripts'))
                .then(function (response) {
                    self.scripts = response.data;
                })
                .catch(function (error) {
                    alert('fail: ' + error);
                });

            },

            slidebar_show: function() {
                this.isSlidebarVisible = true;
            },

            slidebar_hide: function () {
                this.isSlidebarVisible = false;
            },

            saveDialog_show: function () {
                this.modals.saveDialog.isActive = true
            },

            saveDialog_hide: function () {
                this.modals.saveDialog.isActive = false;
            },

            saveDialog_btnSave: function () {

                this.saveDialog_hide();
            },

            btnSave: function () {

                this.saveDialog_show();
                return;

                let self = this;

                if (this.currentScript.ScriptId == null) {

                    // add object
                    axios.post(this.helper.Map(api.dataApiUrl, 'scripts'), self.currentScript.getData())
                    .then(function (response) {
                        self.currentScript.ScriptId = response.data;
                        self.scripts.push(self.currentScript);
                    })
                    .catch(function (error) {
                        alert('fail: ' + error);
                    });

                } else {

                    // update object by id
                    axios.put(
                        self.helper.Map(api.dataApiUrl, 'scripts', { id: self.currentScript.ScriptId }),
                        self.currentScript
                    )
                    .then(function (response) {
                        
                    })
                    .catch(function (error) {
                        alert('fail: ' + error);
                    });

                }

            },

            btnRun: function () {

                let self = this;

                axios.get(this.helper.Map(api.methodsApiUrl, 'DoRegex', {
                    source: encodeURIComponent(self.inputText),
                    search: encodeURIComponent(self.currentScript.SearchPattern),
                    replace: encodeURIComponent(self.currentScript.ReplacePattern)
                }))
                .then(function (response) {

                    if (response.data.success == true) {
                        self.outputText = response.data.result;
                    } else {
                        self.outputText = response.data.comment;
                    }

                })
                .catch(function (error) {
                    self.outputText = error;
                });
            },

            tabSelect: function(tabName, tabId) {
                this.tabs[tabName].forEach(t => t.isActive = false);
                this.tabs[tabName][tabId].isActive = true;
            },

            scriptOpen: function (e) {
                this.currentScript = e;
            },

            scriptDelete: function (e) {

                let self = this;

                let _id = this.scripts.findIndex((item, id, array) => {
                    if (item.ScriptId == e.ScriptId) {
                        return id;
                    }
                }, this);

                // delete object by id
                axios.delete(this.helper.Map(api.dataApiUrl, 'scripts', { id: e.ScriptId }))
                .then(function (response) {
                    self.scripts.splice(_id, 1);
                })
                .catch(function (error) {
                    alert('fail: ' + error);
                });
            }
        },

        created: function () {
            this.refleshList();
        }

    });

})