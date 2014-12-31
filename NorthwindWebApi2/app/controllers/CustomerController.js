northwindApp.controller("CustomerController", ["$scope", "$location", "$routeParams", "CustomerService", function ($scope,$location,$routeParams,customerService) {
    $scope.customers = [];

    customerService.getAll().then(function (result) {
        $scope.customers = result.data;
    });

    $scope.create = function() {
        $location.path("/customer-create");
    };

    $scope.details = function(id) {
        $location.path("/customer-details/" + id);
    };

    $scope.edit = function(id) {
        $location.path("/customer-edit/" + id);
    };

    $scope.delete = function(id) {
        $location.path("/customer-delete/" + id);
    };
}]);

northwindApp.controller("CreateCustomerController", ["$scope", "$location", "CustomerService", function ($scope, $location, customerService, categoryService, productService) {
    $scope.model = {};

    $scope.create = function() {
        customerService.create($scope.model);
        $location.path("/customer");
    };

    $scope.cancel = function() {
        $location.path("/customer");
    };
}]);

northwindApp.controller("EditCustomerController", ["$scope", "$location", "$routeParams", "CustomerService", function ($scope, $location, $routeParams, customerService) {
    $scope.model = {};

    customerService.get($routeParams.id).then(function (result) {
        $scope.model = result.data;
    });

    $scope.edit = function (id) {
        $location.path("/customer-edit/" + id);
    };

    $scope.update = function () {
        customerService.update($scope.model);
        $location.path("/customer");
    };

    $scope.delete = function () {
        customerService.delete($scope.model);

        $location.path("/customer");
    };

    $scope.cancel = function () {
        $location.path("/customer");
    };
}]);
