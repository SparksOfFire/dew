requirejs.config({
    baseUrl: '/scripts',
    paths: {
        "jquery": "jquery-1.10.2.min"
        //"bootstrap": "bootstrap",
        //"bootstrap-datepicker": "bootstrap-datepicker",
    },
    shim: {
        'jquery': {
            exports: ['jQuery', '$']
        },
        'bootstrap': {
            deps: ['jquery'],
            exports: "jQuery.fn.popover"
        },
        'bootstrap-datepicker': {
            deps: ['bootstrap'],
            exports: "jQuery.fn.datepicker"
        }
    }
});