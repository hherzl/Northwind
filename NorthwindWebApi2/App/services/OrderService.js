(function () {
    "use strict";

    northwindApp.service("OrderService", ["$log", "$http", function ($log, $http) {
        var baseUrl = "/api/";

        var url = baseUrl + "Order";

        this.getAll = function () {
            return $http.get(url);
        };
    }]);
})();
