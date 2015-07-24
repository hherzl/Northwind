(function () {
    "use strict";

    angular.module("northwindApp").controller("CategoryController", CategoryController);

    CategoryController.$inject = ["$log", "$scope", "$location", "$routeParams", "toaster", "ngTableParams", "$filter", "UnitOfWork"];

    function CategoryController($log, $scope, $location, $routeParams, toaster, ngTableParams, $filter, uow) {
        $scope.result = {};

        uow.categoryRepository.get().then(function (result) {
            $scope.result = result.data;

            if (!$scope.result.didError) {
                toaster.pop("success", "Message", "Categories data was loaded successfully!");
            }

            $scope.tableParams = new ngTableParams({
                page: 1,
                count: 10,
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

        $scope.create = function () {
            $location.path("/category-create");
        };

        $scope.details = function (id) {
            $location.path("/category-details/" + id);
        };

        $scope.edit = function (id) {
            $location.path("category-edit/" + id);
        };

        $scope.delete = function (id) {
            $location.path("/category-delete/" + id);
        };
    };
})();
