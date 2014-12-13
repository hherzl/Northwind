northwindApp.service("CategoryService", function ($http) {
    var baseUrl = "/api/";

    var url = baseUrl + "Category";

    this.getAll = function () {
        return $http.get(url);
    }
});
