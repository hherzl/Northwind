(function () {
    "use strict";

    angular.module("northwindApp").service("OrderService", OrderService);

    OrderService.$inject = ["$log", "$http", "UrlBuilderService"];

    function OrderService($log, $http, urlBuilder) {
        var url = urlBuilder.getUrl("Order");

        var svc = this;

        svc.get = function (id) {
            return id ? $http.get(url + id) : $http.get(url);
        };
    };
})();
