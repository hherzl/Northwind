(function () {
    "use strict";

    angular.module("northwindApp").controller("OrderController", OrderController);
    angular.module("northwindApp").controller("CreateOrderController", CreateOrderController);
    angular.module("northwindApp").controller("OrderDetailsController", OrderDetailsController);

    OrderController.$inject = ["$log", "$scope", "$location", "$routeParams", "ngTableParams", "$filter", "UnitOfWork"];
    CreateOrderController.$inject = ["$log", "$scope", "$location", "toaster", "UnitOfWork"];
    OrderDetailsController.$inject = ["$log", "$scope", "$location", "$routeParams", "UnitOfWork"];

    function OrderController($log, $scope, $location, $routeParams, ngTableParams, $filter, uow) {
        uow.orderRepository.get().then(function (result) {
            $scope.result = result.data;

            $scope.tableParams = new ngTableParams({
                page: 1,
                count: 50,
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
            $location.path("/order-create");
        };

        $scope.details = function (obj) {
            $location.path("/order-details/" + obj.orderID);
        };
    };

    function CreateOrderController($log, $scope, $location, toaster, uow) {
        $scope.customerResult = {};
        $scope.employeeResult = {};
        $scope.shipperResult = {};
        $scope.productResult = {};
        $scope.order = {
            orderSummaries: []
        };
        $scope.orderResult = {};

        uow.customerRepository.get().then(function (result) {
            $scope.customerResult = result.data;
        });

        uow.employeeRepository.get().then(function (result) {
            $scope.employeeResult = result.data;
        });

        uow.shipperRepository.get().then(function (result) {
            $scope.shipperResult = result.data;
        });

        uow.productRepository.get().then(function (result) {
            $scope.productResult = result.data;
        });

        $scope.order.total = function () {
            var value = 0.0;

            angular.forEach($scope.order.orderSummaries, function (item) {
                value += item.total();
            });

            return value.toFixed(2);
        };

        $scope.add = function () {
            if ($scope.product == null) {
                return;
            }

            var foundProduct = null;

            angular.forEach($scope.productResult.model, function (item) {
                if (item.productID == $scope.product) {
                    foundProduct = item;
                }
            });

            if (foundProduct != null) {
                var newItem = {
                    productID: foundProduct.productID,
                    productName: foundProduct.productName,
                    unitPrice: foundProduct.unitPrice,
                    quantity: 1
                };

                newItem.total = function () {
                    return newItem.unitPrice * newItem.quantity;
                };

                var foundDetail = null;

                angular.forEach($scope.order.orderSummaries, function (item) {
                    if (item.productID == newItem.productID) {
                        foundDetail = item;
                    }
                });

                if (foundDetail == null) {
                    $scope.order.orderSummaries.push(newItem);
                } else {
                    foundDetail.quantity += newItem.quantity;
                }

                $scope.product = null;
            }
        };

        $scope.create = function () {
            uow.orderRepository.post($scope.order).then(function (result) {
                $scope.orderResult = result.data;

                if (result.data.didError) {
                    toaster.pop("warning", "Notification", "There was an error!");
                } else {
                    $location.path("/order-details/" + $scope.orderResult.model.orderID);
                }
            });
        };
    };

    function OrderDetailsController($log, $scope, $location, $routeParams, uow) {
        $scope.result = {};

        var id = $routeParams.id;

        uow.orderRepository.get(id).then(function (result) {
            $scope.result = result.data;

            if (!$scope.result.didError) {
                $scope.result.model.total = function () {
                    var value = 0.0;

                    angular.forEach($scope.result.model.orderSummaries, function (item) {
                        value += item.total;
                    });

                    return value;
                };
            }
        });

        $scope.back = function () {
            $location.path("/order/");
        };
    };
})();
