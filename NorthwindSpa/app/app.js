angular.module("northwindApp", [
    "ngRoute",
    "ngResource",
    "ngCookies",
    "ngTable",
    "ui.bootstrap",
    "toaster"
]);

(function () {
    angular.module("northwindApp").config(function ($routeProvider) {
        var base = "/app/views/";

        $routeProvider
            .when("/", {
                templateUrl: base + "home.html",
                controller: "HomeController"
            })

            .when("/supplier", {
                templateUrl: base + "supplier/index.html",
                controller: "SupplierController"
            })
            .when("/supplier-details/:id", {
                templateUrl: base + "supplier/details.html",
                controller: "EditSupplierController"
            })
            .when("/supplier-create", {
                templateUrl: base + "supplier/create.html",
                controller: "CreateSupplierController"
            })
            .when("/supplier-edit/:id", {
                templateUrl: base + "supplier/edit.html",
                controller: "EditSupplierController"
            })
            .when("/supplier-delete/:id", {
                templateUrl: base + "supplier/delete.html",
                controller: "EditSupplierController"
            })

            .when("/category", {
                templateUrl: base + "category/index.html",
                controller: "CategoryController"
            })

            .when("/product", {
                templateUrl: base + "product/index.html",
                controller: "ProductController"
            })
            .when("/product-create", {
                templateUrl: base + "product/create.html",
                controller: "CreateProductController"
            })
            .when("/product-details/:id", {
                templateUrl: base + "product/details.html",
                controller: "EditProductController"
            })
            .when("/product-edit/:id", {
                templateUrl: base + "product/edit.html",
                controller: "EditProductController"
            })
            .when("/product-delete/:id", {
                templateUrl: base + "product/delete.html",
                controller: "EditProductController"
            })

            .when("/shipper", {
                templateUrl: base + "shipper/index.html",
                controller: "ShipperController"
            })
            .when("/shipper-create", {
                templateUrl: base + "shipper/create.html",
                controller: "CreateShipperController"
            })
            .when("/shipper-details/:id", {
                templateUrl: base + "shipper/details.html",
                controller: "EditShipperController"
            })
            .when("/shipper-edit/:id", {
                templateUrl: base + "shipper/edit.html",
                controller: "EditShipperController"
            })
            .when("/shipper-delete/:id", {
                templateUrl: base + "shipper/delete.html",
                controller: "EditShipperController"
            })

            .when("/customer", {
                templateUrl: base + "customer/index.html",
                controller: "CustomerController"
            })
            .when("/customer-create", {
                templateUrl: base + "customer/create.html",
                controller: "CreateCustomerController"
            })
            .when("/customer-details/:id", {
                templateUrl: base + "customer/details.html",
                controller: "EditCustomerController"
            })
            .when("/customer-edit/:id", {
                templateUrl: base + "customer/edit.html",
                controller: "EditCustomerController"
            })
            .when("/customer-delete/:id", {
                templateUrl: base + "customer/delete.html",
                controller: "EditCustomerController"
            })

            .when("/order", {
                templateUrl: base + "order/index.html",
                controller: "OrderController"
            })
            .when("/order-create", {
                templateUrl: base + "order/create.html",
                controller: "CreateOrderController"
            })
            .when("/order-details/:id", {
                templateUrl: base + "order/details.html",
                controller: "OrderDetailsController"
            })

            .when("/region", {
                templateUrl: base + "region/index.html",
                controller: "RegionController"
            })

            .when("/employee", {
                templateUrl: base + "employee/index.html",
                controller: "EmployeeController"
            });
    });
})();
