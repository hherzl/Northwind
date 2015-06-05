(function () {
    "use strict";

    angular.module("northwindApp").service("CategoryService", CategoryService);

    CategoryService.$inject = ["$log", "$http", "UrlBuilderService"];

    function CategoryService($log, $http, urlBuilder) {
        var url = urlBuilder.getUrl("Category");

        var svc = this;

        svc.get = function (id) {
            return $http.get(url + "/Get/" + (id ? id : ""));
        };

        svc.post = function (entity) {
            return $http.post(url + "/Post/", entity);
        };

        svc.put = function (id, entity) {
            return $http.put(url + "/Put/" + id, entity);
        };

        svc.delete = function (id, entity) {
            return $http.delete(url + "/Delete/" + id, entity);
        };
    };
})();
