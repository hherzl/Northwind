(function () {
    "use strict";

    angular.module("northwindApp").service("RegionService", RegionService);

    RegionService.$inject = ["$log", "$http", "UrlBuilderService"];

    function RegionService($log, $http, urlBuilder) {
        var url = urlBuilder.getUrl("Region");

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
