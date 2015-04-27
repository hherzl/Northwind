(function () {
    "use strict";

    northwindApp.service("ProductService", ["$log", "$http", "UrlBuilderService", function ($log, $http, urlBuilder) {
        var url = urlBuilder.getUrl("Product");

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
            return $http.put(url + entity.productID, entity);
        };

        this.delete = function (entity) {
            return $http.delete(url + entity.productID, entity);
        };
    }]);
})();
