(function (app) {
    "use strict";

    app.controller("ProductController", ProductController);
    app.controller("CreateProductController", CreateProductController);
    app.controller("EditProductController", EditProductController);

    ProductController.$inject = ["$log", "$location", "$routeParams", "$filter", "toaster", "ngTableParams", "UnitOfWork"];
    CreateProductController.$inject = ["$log", "$location", "UnitOfWork"];
    EditProductController.$inject = ["$log", "$location", "$routeParams", "UnitOfWork"];

    function ProductController($log, $location, $routeParams, $filter, toaster, ngTableParams, uow) {
        var vm = this;

        vm.productName = "";
        vm.supplierID = "";
        vm.categoryID = "";
        vm.result = {};

        uow.productRepository.get("", vm.productName, vm.supplierID, vm.categoryID).then(function (result) {
            vm.result = result.data;

            if (!vm.result.didError) {
                toaster.pop("success", "Message", "Products data was loaded successfully!");
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
            $location.path("/product-create");
        };

        vm.details = function (entity) {
            $location.path("/product-details/" + entity.productID);
        };

        vm.edit = function (entity) {
            $location.path("product-edit/" + entity.productID);
        };

        vm.delete = function (entity) {
            $location.path("/product-delete/" + entity.productID);
        };
    };

    function CreateProductController($log, $location, uow) {
        var vm = this;

        vm.result = {};

        vm.supplierResult = {};
        vm.categoryResult = {};

        uow.supplierRepository.get().then(function (result) {
            vm.supplierResult = result.data;
        });

        uow.categoryRepository.get().then(function (result) {
            vm.categoryResult = result.data;
        });

        vm.create = function () {
            uow.productRepository.post(vm.result.model).then(function (result) {
                if (result.data.didError) {
                    vm.result = result.data;
                } else {
                    $location.path("/product");
                }
            });
        };

        vm.cancel = function () {
            $location.path("/product");
        };
    };

    function EditProductController($log, $location, $routeParams, uow) {
        var vm = this;

        vm.result = {};

        vm.supplierResult = {};
        vm.categoryResult = {};

        uow.supplierRepository.get().then(function (result) {
            vm.supplierResult = result.data;
        });

        uow.categoryRepository.get().then(function (result) {
            vm.categoryResult = result.data;
        });

        uow.productRepository.get($routeParams.id).then(function (result) {
            vm.result = result.data;
        });

        vm.edit = function (id) {
            $location.path("/product-edit/" + id);
        };

        vm.update = function () {
            uow.productRepository.put(vm.result.model.productID, vm.result.model).then(function (result) {
                if (result.data.didError) {
                    vm.result = result.data;
                } else {
                    $location.path("/product");
                }
            });
        };

        vm.delete = function () {
            uow.productRepository.delete(vm.result.model.productID, vm.result.model);

            $location.path("/products");
        };

        vm.cancel = function () {
            $location.path("/product");
        };
    };
})(angular.module("northwindApp"));
