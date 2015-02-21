(function () {
    "use strict";

    northwindApp.service("EmployeeService", ["$log", "$http", function ($log, $http) {
        var baseUrl = "/api/";

        var url = baseUrl + "Employee";

        this.getAll = function () {
            return $http.get(url);
        };
    }]);
})();
