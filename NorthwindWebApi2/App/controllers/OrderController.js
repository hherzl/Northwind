(function () {
    "use strict";

    northwindApp.controller("OrderController", ["$log", "$scope", "$location", "$routeParams", "ngTableParams", "$filter", "OrderService", function ($log, $scope, $location, $routeParams, ngTableParams, $filter, orderService) {
        orderService.getAll().then(function (result) {
            $scope.result = result.data;

            $scope.tableParams = new ngTableParams({
                page: 1,
                count: 50,
                sorting: {
                    name: "asc"
                }
            }, {
                total: $scope.result.model.length,
                getData: function ($defer, params) {
                    var orderedData = params.sorting() ? $filter("orderBy")($scope.result.model, params.orderBy()) : $scope.result.model;

                    $defer.resolve(orderedData.slice((params.page() - 1) * params.count(), params.page() * params.count()));
                }
            });
        });
    }]);
})();
