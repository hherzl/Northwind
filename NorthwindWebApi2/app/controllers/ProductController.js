northwindApp.controller("ProductController", ["$scope", "$location", "$routeParams", "ProductService", function ($scope, $location, $routeParams, productService) {
    $scope.result = {};

    productService.getAll().then(function (result) {
        $scope.result = result.data;
    });

    $scope.create = function() {
        $location.path("/product-create");
    };

    $scope.details = function(id) {
        $location.path("/product-details/" + id);
    };

    $scope.edit = function(id) {
        $location.path("product-edit/" + id);
    };

    $scope.delete = function(id) {
        $location.path("/product-delete/" + id);
    };
}]);

northwindApp.controller("CreateProductController", ["$scope", "$location", "SupplierService", "CategoryService", "ProductService", function ($scope, $location, supplierService, categoryService, productService) {
    $scope.result = {};

    $scope.suppliers = [];
    $scope.categories = [];

    supplierService.getAll().then(function (result) {
        $scope.suppliers = result.data;
    });

    categoryService.getAll().then(function (result) {
        $scope.categories = result.data;
    });

    $scope.create = function () {
        productService.create($scope.result.model).then(function (result) {
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
}]);

northwindApp.controller("EditProductController", ["$scope", "$location", "$routeParams", "SupplierService", "CategoryService", "ProductService", function ($scope, $location, $routeParams, supplierService, categoryService, productService) {
    $scope.result = {};

    productService.get($routeParams.id).then(function (result) {
        $scope.result = result.data;
    });

    $scope.suppliers = [];
    $scope.categories = [];

    supplierService.getAll().then(function (result) {
        $scope.suppliers = result.data;
    });

    categoryService.getAll().then(function (result) {
        $scope.categories = result.data;
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
        productService.delete($scope.model);

        $location.path("/products");
    };

    $scope.cancel = function () {
        $location.path("/product");
    };
}]);
