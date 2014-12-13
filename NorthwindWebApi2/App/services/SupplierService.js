northwindApp.service("SupplierService", function ($http) {
    var baseUrl = "/api/";

    var url = baseUrl + "Supplier";

    this.getAll = function () {
        return $http.get(url);
    }
});
