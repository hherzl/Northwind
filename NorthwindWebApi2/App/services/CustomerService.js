(function () {
    "use strict";

    angular.module("northwindApp").service("CustomerService", CustomerService);

    CustomerService.$inject = ["$log", "$http", "UrlBuilderService"];

    function CustomerService($log, $http, urlBuilder) {
        var url = urlBuilder.getUrl("Customer");

        var svc = this;

        svc.getAll = function () {
            return $http.get(url);
        };

        svc.get = function (id) {
            return $http.get(url + id);
        };

        svc.create = function (entity) {
            return $http.post(url, entity);
        };

        svc.update = function (entity) {
            return $http.put(url + entity.customerID, entity);
        };

        svc.delete = function (entity) {
            return $http.delete(url + entity.customerID, entity);
        };
    };
})();
