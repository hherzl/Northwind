northwindApp.controller("ShipperController", ["$scope", "$location", "$routeParams", "ShipperService", function ($scope, $location, $routeParams, shipperService) {
    $scope.shippers = [];

    shipperService.getAll().then(function (result) {
        $scope.shippers = result.data;
    });

    $scope.create = function () {
        $location.path("/shipper-create");
    };

    $scope.details = function (id) {
        $location.path("/shipper-details/" + id);
    };

    $scope.edit = function (id) {
        $location.path("/shipper-edit/" + id);
    };

    $scope.delete = function (id) {
        $location.path("/shipper-delete/" + id);
    };
}]);

northwindApp.controller("CreateShipperController", ["$scope", "$location", "ShipperService", function ($scope, $location, shipperService) {
    $scope.model = {};

    $scope.create = function () {
        shipperService.create($scope.model);

        $location.path("/shippers");
    };

    $scope.cancel = function () {
        $location.path("/shippers");
    };
}]);

northwindApp.controller("EditShipperController", ["$scope", "$location", "$routeParams", "ShipperService", function ($scope, $location, $routeParams, shipperService) {
    $scope.model = {};

    shipperService.get($routeParams.id).then(function (result) {
        $scope.model = result.data;
    });

    $scope.edit = function (id) {
        $location.path("/shipper-edit/" + id);
    };

    $scope.update = function () {
        shipperService.update($scope.model);

        $location.path("/shippers");
    };

    $scope.delete = function () {
        shipperService.delete($scope.model);

        $location.path("/shippers");
    };

    $scope.cancel = function () {
        $location.path("/shippers");
    };
}]);
