(function () {
    "use strict";

    angular.module("northwindApp").controller("OrderController", OrderController);
    angular.module("northwindApp").controller("CreateOrderController", CreateOrderController);
    angular.module("northwindApp").controller("OrderDetailsController", OrderDetailsController);

    OrderController.$inject = ["$log", "$location", "$routeParams", "ngTableParams", "$filter", "UnitOfWork"];
    CreateOrderController.$inject = ["$log", "$location", "toaster", "UnitOfWork"];
    OrderDetailsController.$inject = ["$log", "$location", "$routeParams", "UnitOfWork"];

    function OrderController($log, $location, $routeParams, ngTableParams, $filter, uow) {
        var vm = this;

        uow.orderRepository.get().then(function (result) {
            vm.result = result.data;

            vm.tableParams = new ngTableParams({
                page: 1,
                count: 50,
                sorting: {
                    name: "asc"
                }
            }, {
                total: vm.result.model.length,
                getData: function ($defer, params) {
                    var orderedData = params.sorting() ? $filter("orderBy")(vm.result.model, params.orderBy()) : vm.result.model;

                    $defer.resolve(orderedData.slice((params.page() - 1) * params.count(), params.page() * params.count()));
                }
            });
        });

        vm.create = function () {
            $location.path("/order-create");
        };

        vm.details = function (obj) {
            $location.path("/order-details/" + obj.orderID);
        };
    };

    function CreateOrderController($log, $location, toaster, uow) {
        var vm = this;

        vm.customerResult = {};
        vm.employeeResult = {};
        vm.shipperResult = {};
        vm.productResult = {};
        vm.order = {
            orderSummaries: []
        };
        vm.orderResult = {};

        uow.customerRepository.get().then(function (result) {
            vm.customerResult = result.data;
        });

        uow.employeeRepository.get().then(function (result) {
            vm.employeeResult = result.data;
        });

        uow.shipperRepository.get().then(function (result) {
            vm.shipperResult = result.data;
        });

        uow.productRepository.get().then(function (result) {
            vm.productResult = result.data;
        });

        vm.order.total = function () {
            var value = 0.0;

            angular.forEach(vm.order.orderSummaries, function (item) {
                value += item.total();
            });

            return value.toFixed(2);
        };

        vm.add = function () {
            if (vm.product == null) {
                return;
            }

            var foundProduct = null;

            angular.forEach(vm.productResult.model, function (item) {
                if (item.productID == vm.product) {
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

                angular.forEach(vm.order.orderSummaries, function (item) {
                    if (item.productID == newItem.productID) {
                        foundDetail = item;
                    }
                });

                if (foundDetail == null) {
                    vm.order.orderSummaries.push(newItem);
                } else {
                    foundDetail.quantity += newItem.quantity;
                }

                vm.product = null;
            }
        };

        vm.remove = function (index) {
            vm.order.orderSummaries.splice(index, 1);
        };

        vm.create = function () {
            uow.orderRepository.post(vm.order).then(function (result) {
                vm.orderResult = result.data;

                if (result.data.didError) {
                    toaster.pop("warning", "Notification", "There was an error!");
                } else {
                    $location.path("/order-details/" + vm.orderResult.model.orderID);
                }
            });
        };
    };

    function OrderDetailsController($log, $location, $routeParams, uow) {
        var vm = this;

        vm.result = {};

        var id = $routeParams.id;

        uow.orderRepository.get(id).then(function (result) {
            vm.result = result.data;

            if (!vm.result.didError) {
                vm.result.model.total = function () {
                    var value = 0.0;

                    angular.forEach(vm.result.model.orderSummaries, function (item) {
                        value += item.total;
                    });

                    return value;
                };
            }
        });

        vm.back = function () {
            $location.path("/order/");
        };
    };
})();
