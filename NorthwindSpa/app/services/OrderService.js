(function () {
    "use strict";

    angular.module("northwindApp").service("OrderService", OrderService);

    OrderService.$inject = ["$log", "$http", "UrlBuilder"];

    function OrderService($log, $http, urlBuilder) {
        var rest = urlBuilder.rest("Order");

        var svc = this;

        svc.getSummaries = function (orderID, customerID, employeeID, shipperID) {
            return $http.get(rest.get(null, ["orderID", orderID, "customerID", customerID, "employeeID", employeeID, "shipperID", shipperID]));
        };

        svc.get = function (id) {
            return $http.get(rest.get(id));
        };

        svc.post = function (entity) {
            return $http.post(rest.post(), entity);
        };

        svc.put = function (id, entity) {
            return $http.put(rest.put(id), entity);
        };

        svc.delete = function (id, entity) {
            return $http.delete(rest.delete(id), entity);
        };
    };
})();
