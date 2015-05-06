(function () {
    "use strict";

    angular.module("northwindApp").service("SupplierService", SupplierService);

    SupplierService.$inject = ["$log", "$http", "UrlBuilderService"];

    function SupplierService($log, $http, urlBuilder) {
        var url = urlBuilder.getUrl("Supplier");

        var svc = this;

        svc.get = function (id) {
            return id ? $http.get(url + id) : $http.get(url);
        };

        svc.post = function (entity) {
            return $http.post(url, entity);
        };

        svc.put = function (id, entity) {
            return $http.put(url + id, entity);
        };

        svc.delete = function (id, entity) {
            return $http.delete(url + id, entity);
        };
    };
})();
