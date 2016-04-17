(function () {
    "use strict";

    angular.module("northwindApp").service("ShipperService", ShipperService);

    ShipperService.$inject = ["$log", "$http", "UrlBuilder"];

    function ShipperService($log, $http, urlBuilder) {
        var rest = urlBuilder.rest("Shipper");

        var svc = this;

        svc.get = function (id) {
            return $http.get(rest.get(id));
        };

        svc.post = function (entity) {
            return $http.post(rest.post(), entity);
        };

        svc.put = function (id, entity) {
            return $http.put(rest.put(id), entity);
        };

        svc.delete = function (id) {
            return $http.delete(rest.delete(id));
        };
    };
})();
