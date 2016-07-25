(function () {
    "use strict";

    angular.module("northwindApp").service("AdministrationService", AdministrationService);

    AdministrationService.$inject = ["$log", "$http", "UrlBuilder"];

    function AdministrationService($log, $http, urlBuilder) {
        var rest = urlBuilder.rest("Administration/Category");

        var svc = this;

        svc.get = function (id) {
            return $http.get(rest.get(id));
        };

        svc.post = function (entity) {
            return $http.post(rest.post(), entity);
        };

        svc.put = function (id, entity) {
            return $http.put(rest.put(id), entity);
        };

        svc.delete = function (id, entity) {
            return $http.delete(rest.delete(id), entity);
        };
    };
})();
