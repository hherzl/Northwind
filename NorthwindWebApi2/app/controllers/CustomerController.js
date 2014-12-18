northwindApp.controller("CustomerController", function ($scope, $http) {
    $scope.customers = [];

    $http.get("/api/Customer").success(function (data) {
        $scope.customers = data;
    });
});
