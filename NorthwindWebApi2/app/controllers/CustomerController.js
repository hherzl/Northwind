northwindApp.controller("CustomerController", ["$scope","CustomerService", function ($scope, customerService) {
    $scope.customers = [];

 customerService.getAll().then(function (result) {
        $scope.customers = result.data;
    });
}]);
