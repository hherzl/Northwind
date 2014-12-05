northwindApp.controller("shipperCtrl", function ($scope, $http) {
    $scope.shippers = [];

    $http.get("/api/Shipper/").success(function (data) {
        $scope.shippers = data;
    });
});
