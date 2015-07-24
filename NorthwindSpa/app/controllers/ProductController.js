(function () {
    "use strict";

    angular.module("northwindApp").controller("ProductController", ProductController);
    angular.module("northwindApp").controller("CreateProductController", CreateProductController);
    angular.module("northwindApp").controller("EditProductController", EditProductController);

    ProductController.$inject = ["$log", "$scope", "$location", "$routeParams", "toaster", "ngTableParams", "$filter", "UnitOfWork"];
    CreateProductController.$inject = ["$scope", "$location", "UnitOfWork"];
    EditProductController.$inject = ["$scope", "$location", "$routeParams", "UnitOfWork"];

    function ProductController($log, $scope, $location, $routeParams, toaster, ngTableParams, $filter, uow) {
        $scope.productName = " ";
        $scope.supplierID = " ";
        $scope.categoryID = " ";
        $scope.result = {};

        uow.productRepository.get("", $scope.productName, $scope.supplierID, $scope.categoryID).then(function (result) {
            $scope.result = result.data;

            if (!$scope.result.didError) {
                toaster.pop("success", "Message", "Products data was loaded successfully!");
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
            $location.path("/product-create");
        };

        $scope.details = function (entity) {
            $location.path("/product-details/" + entity.productID);
        };

        $scope.edit = function (entity) {
            $location.path("product-edit/" + entity.productID);
        };

        $scope.delete = function (entity) {
            $location.path("/product-delete/" + entity.productID);
        };
    };

    function CreateProductController($scope, $location, uow) {
        $scope.result = {};

        $scope.suppliers = [];
        $scope.categories = [];

        uow.supplierRepository.get().then(function (result) {
            $scope.suppliers = result.data;
        });

        uow.categoryRepository.get().then(function (result) {
            $scope.categories = result.data;
        });

        $scope.create = function () {
            uow.productRepository.post($scope.result.model).then(function (result) {
                if (result.data.didError) {
                    $scope.result = result.data;
                } else {
                    $location.path("/product");
                }
            });
        };

        $scope.cancel = function () {
            $location.path("/product");
        };
    };

    function EditProductController($scope, $location, $routeParams, uow) {
        $scope.result = {};

        uow.productRepository.get($routeParams.id).then(function (result) {
            $scope.result = result.data;

            $scope.supplierResult = {};
            $scope.categoryResult = {};

            uow.supplierRepository.get().then(function (result) {
                $scope.supplierResult = result.data;
            });

            uow.categoryRepository.get().then(function (result) {
                $scope.categoryResult = result.data;
            });
        });

        $scope.edit = function (id) {
            $location.path("/product-edit/" + id);
        };

        $scope.update = function () {
            productService.update($scope.result.model).then(function (result) {
                if (result.data.didError) {
                    $scope.result = result.data;
                } else {
                    $location.path("/product");
                }
            });
        };

        $scope.delete = function () {
            uow.productRepository.delete($scope.result.model.productID, $scope.result.model);

            $location.path("/products");
        };

        $scope.cancel = function () {
            $location.path("/product");
        };
    };
})();
