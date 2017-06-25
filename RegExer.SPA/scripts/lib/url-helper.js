'use strict'

define(function () {

    return function UrlHelper() {

        this.Map = function (url, method, data) {

            let result = url;

            if (!(result[result.length - 1] == "/" || method[0] == "/")) {
                result += "/";
            }

            if (data) {
                result += method + "?";

                let key = "";
                for(key in data) {
                    result += key + "=" + encodeURI(data[key]) + "&";
                };

                result = result.slice(0, -1);
            } else {
                result += method;
            }

            return result;
        };

    }

});