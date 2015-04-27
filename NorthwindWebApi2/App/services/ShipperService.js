(function () {
    "use strict";

    angular.module("northwindApp").service("ShipperService", ShipperService);

    ShipperService.$inject = ["$log", "$http", "UrlBuilderService"];

    function ShipperService($log, $http, urlBuilder) {
        var url = urlBuilder.getUrl("Shipper");

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
            return $http.put(url + entity.shipperID, entity);
        };

        svc.delete = function (entity) {
            return $http.delete(url + entity.shipperID, entity);
        };
    };
})();
