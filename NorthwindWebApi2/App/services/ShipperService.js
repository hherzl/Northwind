(function () {
    "use strict";

    northwindApp.service("ShipperService", ["$log", "$http", function ($log, $http) {
        var baseUrl = "/api/";

        var url = baseUrl + "Shipper/";

        this.getAll = function () {
            return $http.get(url);
        };

        this.get = function (id) {
            return $http.get(url + id);
        };

        this.create = function (entity) {
            return $http.post(url, entity);
        };

        this.update = function (entity) {
            return $http.put(url + entity.shipperID, entity);
        };

        this.delete = function (entity) {
            return $http.delete(url + entity.shipperID, entity);
        };
    }]);
})();
