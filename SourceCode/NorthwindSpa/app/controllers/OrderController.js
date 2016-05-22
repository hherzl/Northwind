(function (app) {
    "use strict";

    app.controller("OrderController", OrderController);
    app.controller("CreateOrderController", CreateOrderController);
    app.controller("OrderDetailsController", OrderDetailsController);

    OrderController.$inject = ["$log", "$scope", "$location", "$routeParams", "$filter", "ngTableParams", "toaster", "UnitOfWork"];
    CreateOrderController.$inject = ["$log", "$location", "toaster", "UnitOfWork"];
    OrderDetailsController.$inject = ["$log", "$location", "$routeParams", "UnitOfWork"];

    function OrderController($log, $scope, $location, $routeParams, $filter, ngTableParams, toaster, uow) {
        var vm = this;

        foo = vm;

        vm.start = undefined;
        vm.end = undefined;

        vm.open = function (obj) {
            debugger;
            obj[0].open(obj[1]);
        };

        vm.searchParams = {};

        $scope.$watch("vm.start", function (newValue, oldValue) {
            $log.log("vm.start");
            if (newValue == undefined || newValue == null) {
                vm.start = undefined;
                vm.searchParams.start = undefined;
            }
        });

        $scope.$watch("vm.end", function (newValue, oldValue) {
            $log.log("vm.end");
            if (newValue == undefined || newValue == null) {
                vm.end = undefined;
                vm.searchParams.end = undefined;
            }
        });

        uow.customerRepository.get().then(function (result) {
            vm.customerResult = result.data;
        });

        uow.employeeRepository.get().then(function (result) {
            vm.employeeResult = result.data;
        });

        uow.shipperRepository.get().then(function (result) {
            vm.shipperResult = result.data;
        });

        vm.customerID = "";
        vm.employeeID = "";
        vm.shipperID = "";
        vm.result = {
            model: []
        };

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

        uow.orderRepository.getSummaries(vm.orderID, vm.customerID, vm.employeeID, vm.shipperID).then(function (result) {
            vm.result = result.data;

            vm.tableParams.total(vm.result.model.length);
            vm.tableParams.reload();
        });

        //vm.search = function () {
        //    toaster.pop("wait", "Notification", "Searching orders...");

        //    if (vm.start) {
        //        vm.search.start = buildDateString(vm.start);
        //    }

        //    if (vm.end) {
        //        vm.search.start = buildDateString(vm.end);
        //    }

        //    uow.orderRepository.getSummaries(vm.orderID, vm.customerID, vm.employeeID, vm.shipperID).then(function (result) {
        //        vm.result = result.data;

        //        vm.tableParams.total(vm.result.model.length);
        //        vm.tableParams.reload();
        //    });
        //};

        vm.create = function () {
            $location.path("/order-create");
        };

        vm.details = function (obj) {
            $location.path("/order-details/" + obj.orderID);
        };

        vm.s = {};
        vm.e = {};

        initDatePickerScope(vm.s);
        initDatePickerScope(vm.e);
    };

    function buildDate(dateTime, time) {
        console.log("buildDate");

        if (time) {
            return new Date(dateTime.getFullYear(), dateTime.getMonth(), dateTime.getDate(), time.getHours(), time.getMinutes(), 0, 0);
        } else {
            return new Date(dateTime.getFullYear(), dateTime.getMonth(), dateTime.getDate());
        }
    };

    function buildDateString(dateTime) {
        console.log("buildDateString");

        return dateTime.getDate() + "/" + (dateTime.getMonth() + 1) + "/" + dateTime.getFullYear();
    };

    function initDatePickerScope(target) {
        console.log("initDatePickerScope");

        target.currentText = "Now";
        target.clearText = "Clear";
        target.closeText = "Close";

        target.today = function () {
            target.dt = new Date();
        };

        target.today();

        target.clear = function () {
            target.dt = null;
        };

        // Disable weekend selection
        target.disabled = function (date, mode) {
            return (mode === "day" && (date.getDay() === 0));
        };

        target.toggleMin = function () {
            target.minDate = target.minDate ? null : new Date();
        };

        target.toggleMin();

        target.open = function ($event) {
            //$event.preventDefault();
            //$event.stopPropagation();

            target.opened = true;
        };

        target.dateOptions = {
            formatYear: "yy",
            startingDay: 1
        };

        target.formats = ["dd/MM/yyyy"];
        target.format = target.formats[0];

        var tomorrow = new Date();
        tomorrow.setDate(tomorrow.getDate() + 1);

        var afterTomorrow = new Date();
        afterTomorrow.setDate(tomorrow.getDate() + 2);

        target.events = [
            {
                date: tomorrow,
                status: "full"
            },
            {
                date: afterTomorrow,
                status: "partially"
            }
        ];

        target.getDayClass = function (date, mode) {
            if (mode === "day") {
                var dayToCheck = new Date(date).setHours(0, 0, 0, 0);

                for (var i = 0; i < target.events.length; i++) {
                    var currentDay = new Date(target.events[i].date).setHours(0, 0, 0, 0);

                    if (dayToCheck === currentDay) {
                        return target.events[i].status;
                    }
                }
            }

            return "";
        };

        target.ismeridian = true;
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
})(angular.module("northwindApp"));
