requirejs.config({

    baseUrl: '/scripts/lib',

    paths: {
        app: '../app',
        models: '../models',
        config: '../config',
        components: '../components'
    },

    urlArgs: "bust=" + (new Date()).getTime()

});

requirejs(['app/editor']);