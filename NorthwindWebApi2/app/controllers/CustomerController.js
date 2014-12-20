(function () {
    'use strict';

    northwindApp.controller("CustomerController", CustomerController);
    northwindApp.controller("CreateCustomerController", CreateCustomerController);
    northwindApp.controller("EditCustomerController", EditCustomerController);


    CustomerController.$inject = ["$scope","$location","$routeParams","CustomerService"];
    CreateCustomerController.$inject = ["$scope","$location", "CustomerService"];
    EditCustomerController.$inject = ["$scope", "$location", "$routeParams", "CustomerService"];

    function CustomerController($scope,$location,$routeParams,customerService) {
        $scope.title = "CustomerController";

        $scope.customers = [];

        customerService.getAll().then(function (result) {
            $scope.customers = result.data;
        });

        $scope.create = function() {
            $location.path("/customer-create");
        }

        $scope.details = function(id) {
            $location.path("/customer-details/" + id);
        }

        $scope.edit = function(id) {
            $location.path("/customer-edit/" + id);
        }

        $scope.delete = function(id) {
            $location.path("/customer-delete/" + id);
        }
      
    }


    function CreateCustomerController($scope, $location, customerService) {
        $scope.title = "CreateCustomerController";

        $scope.model = {};

        $scope.create = function() {
            customerService.create($scope.model);
            $location.path("/customer");
        }

        $scope.cancel = function() {
            $location.path("/customer");
        }

    }

    function EditCustomerController($scope, $location, $routeParams, customerService) {
        $scope.model = {};

        $scope.title = "EditCustomerController";

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
    }

})();
