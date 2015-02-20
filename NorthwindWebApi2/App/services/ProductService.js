northwindApp.service("ProductService", ["$log", "$http", function ($log, $http) {
    var baseUrl = "/api/";

    var url = baseUrl + "Product/";

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
