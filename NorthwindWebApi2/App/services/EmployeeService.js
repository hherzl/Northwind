(function () {
    "use strict";

    angular.module("northwindApp").service("EmployeeService", EmployeeService);

    EmployeeService.$inject = ["$log", "$http", "UrlBuilderService"];

    function EmployeeService($log, $http, urlBuilder) {
        var url = urlBuilder.getUrl("Employee");

        var svc = this;

        svc.get = function (id) {
            return id ? $http.get(url + id) : $http.get(url);
        };
    };
})();
