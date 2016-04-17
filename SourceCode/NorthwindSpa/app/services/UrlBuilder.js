(function () {
    "use strict";

    angular.module("northwindApp").service("UrlBuilder", UrlBuilder);

    UrlBuilder.$inject = ["$log"];

    function UrlBuilder($log) {
        var svc = this;

        svc.baseUrl = "http://localhost:55690/api";

        svc.rest = function (controller) {
            return {
                get: function (id, queryString) {
                    var url = "";

                    if (queryString) {
                        var value = [];

                        for (var i = 0; i < queryString.length; i++) {
                            if (i % 2 != 0) {
                                value.push(queryString[i - 1] + "=" + (queryString[i] ? queryString[i] : ""));
                            }
                        }

                        url = [svc.baseUrl, controller, (id ? id : "")].join("/") + "?" + value.join("&");
                    } else {
                        url = [svc.baseUrl, controller, (id ? id : "")].join("/");
                    }

                    $log.log(url);

                    return url;
                },
                post: function () {
                    return [svc.baseUrl, controller].join("/");
                },
                put: function (id) {
                    return [svc.baseUrl, controller, id].join("/");
                },
                delete: function (id) {
                    return [svc.baseUrl, controller, id].join("/");
                }
            };
        };
    };
})();
