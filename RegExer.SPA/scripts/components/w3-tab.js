define(['vue'], function (Vue) {
    'use strict'

    Vue.component('w3-tabs', {

        template:
`<div class="w3-container">
    <div class="w3-bar w3-black">
        <div v-for="tab in tabs" class="w3-bar-item w3-button" :class="{ 'w3-deep-purple': tab.isActive }" @click="select(tab)">
            {{ tab.title }}
        </div>
    </div>
    <slot></slot>
</div>`,

        data: function () {
            return {
                current: null,
                tabs: []
            };
        },

        methods: {

            select: function (tab) {
                this.current = tab;
            },

            registerTab: function (tab) {
                if (!this.current) {
                    this.current = tab;
                }
                this.tabs.push(tab);
            }

        }
        
    });

    Vue.component('w3-tab', {

        template:
`<div class="w3-container w3-hide" :class="{ 'w3-show': isActive }">
    <slot></slot>
</div>`,

        props: {
            title: {
                type: String,
                required: true
            }
        },

        computed: {
            isActive: function () {
                return this === this.$parent.current;
            }
        },

        created: function () {
            this.$parent.registerTab(this);
        }

    });

});