(function () {
    "use strict";

    angular.module("northwindApp").service("UnitOfWork", UnitOfWork);

    UnitOfWork.$inject = [
        "$log",
        "SupplierService",
        "CategoryService",
        "ProductService",
        "CustomerService",
        "EmployeeService",
        "ShipperService",
        "OrderService",
        "RegionService"
    ];

    function UnitOfWork($log, supplierSvc, categorySvc, productSvc, customerSvc, employeeSvc, shipperSvc, orderSvc, regionSvc) {
        var svc = this;

        svc.supplierRepository = supplierSvc;

        svc.categoryRepository = categorySvc;

        svc.productRepository = productSvc;

        svc.customerRepository = customerSvc;

        svc.employeeRepository = employeeSvc;

        svc.shipperRepository = shipperSvc;

        svc.orderRepository = orderSvc;

        svc.regionRepository = regionSvc;
    };
})();
