northwindApp.service("ProductService", function ($http) {
    var baseUrl = "/api/";

    var url = baseUrl + "Product/";

    this.getAll = function () {
        return $http.get(url);
    };

    this.get = function (id) {
        return $http.get(url + id);
    };

    this.create = function (entity) {
        $http.post(url, entity);
    };

    this.update = function (entity) {
        $http.put(url + entity.productID, entity);
    };

    this.delete = function (entity) {
        $http.delete(url + entity.productID, entity);
    };
});
