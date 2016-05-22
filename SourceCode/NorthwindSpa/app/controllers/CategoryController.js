(function (app) {
    "use strict";

    app.controller("CategoryController", CategoryController);

    CategoryController.$inject = ["$log", "$location", "$routeParams", "toaster", "ngTableParams", "$filter", "UnitOfWork"];

    function CategoryController($log, $location, $routeParams, toaster, ngTableParams, $filter, uow) {
        var vm = this;

        vm.result = {};

        uow.categoryRepository.get().then(function (result) {
            vm.result = result.data;

            if (!vm.result.didError) {
                toaster.pop("success", "Message", "Categories data was loaded successfully!");
            }

            vm.tableParams = new ngTableParams({
                page: 1,
                count: 10,
                sorting: {
                    name: "asc"
                }
            }, {
                total: vm.result.model.length,
                getData: function ($defer, params) {
                    var orderedData = params.sorting() ? $filter("orderBy")(vm.result.model, params.orderBy()) : vm.result.model;

                    $defer.resolve(orderedData.slice((params.page() - 1) * params.count(), params.page() * params.count()));
                }
            });
        });

        vm.create = function () {
            $location.path("/category-create");
        };

        vm.details = function (id) {
            $location.path("/category-details/" + id);
        };

        vm.edit = function (id) {
            $location.path("category-edit/" + id);
        };

        vm.delete = function (id) {
            $location.path("/category-delete/" + id);
        };
    };
})(angular.module("northwindApp"));
