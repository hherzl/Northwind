(function () {
    "use strict";

    northwindApp.service("CustomerService", ["$log", "$http", function ($log, $http) {
        var baseUrl = "/api/";

        var url = baseUrl + "Customer/";

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
            return $http.put(url + entity.customerID, entity);
        };

        this.delete = function (entity) {
            return $http.delete(url + entity.customerID, entity);
        };
    }]);
})();
