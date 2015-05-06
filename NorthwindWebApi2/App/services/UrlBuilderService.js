(function () {
    "use strict";

    angular.module("northwindApp").service("UrlBuilderService", UrlBuilderService);

    UrlBuilderService.$inject = [];

    function UrlBuilderService() {
        var svc = this;

        var baseUrl = "/api";

        svc.baseUrl = function () {
            return baseUrl;
        };

        svc.getUrl = function (value) {
            return baseUrl + "/" + value + "/";
        };
    };
})();
