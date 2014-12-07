northwindApp.controller("ProductCtrl", function ($scope, $http) {
    $scope.products = [];

    $http.get("/api/Product/").success(function (data) {
        $scope.products = data;
    });
});
