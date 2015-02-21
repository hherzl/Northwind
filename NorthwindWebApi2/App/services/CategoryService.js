(function () {
    "use strict";

    northwindApp.service("CategoryService", ["$log", "$http", function ($log, $http) {
        var baseUrl = "/api/";

        var url = baseUrl + "Category";

        this.getAll = function () {
            return $http.get(url);
        };
    }]);
})();
