(function () {
    "use strict";

    angular.module("northwindApp").service("ProductService", ProductService);

    ProductService.$inject = ["$log", "$http", "UrlBuilder"];

    function ProductService($log, $http, urlBuilder) {
        var rest = urlBuilder.rest("Product");

        var svc = this;

        svc.get = function (id, productName, supplierID, categoryID) {
            if (id) {
                return $http.get(rest.get(id));
            } else {
                return $http.get(rest.get(null, ["productName", productName, "supplierID", supplierID, "categoryID", categoryID]));
            }
        };

        svc.post = function (entity) {
            return $http.post(urlBuilder.post(), entity);
        };

        svc.put = function (id, entity) {
            return $http.put(urlBuilder.put(id), entity);
        };

        svc.delete = function (id, entity) {
            return $http.delete(urlBuilder.delete(id), entity);
        };
    };
})();
