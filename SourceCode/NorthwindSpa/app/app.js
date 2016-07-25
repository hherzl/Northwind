angular.module("northwindApp", [
    "ngRoute",
    "ngResource",
    "ngCookies",
    "ngTable",
    "ui.bootstrap",
    "toaster"
]);

(function (app) {
    app.config(function ($routeProvider) {
        var base = "/app/views/";

        $routeProvider
            .when("/", {
                templateUrl: base + "home.html",
                controller: "HomeController",
                controllerAs: "vm"
            })

            .when("/supplier", {
                templateUrl: base + "supplier/index.html",
                controller: "SupplierController",
                controllerAs: "vm"
            })
            .when("/supplier-details/:id", {
                templateUrl: base + "supplier/details.html",
                controller: "EditSupplierController",
                controllerAs: "vm"
            })
            .when("/supplier-create", {
                templateUrl: base + "supplier/create.html",
                controller: "CreateSupplierController",
                controllerAs: "vm"
            })
            .when("/supplier-edit/:id", {
                templateUrl: base + "supplier/edit.html",
                controller: "EditSupplierController",
                controllerAs: "vm"
            })
            .when("/supplier-delete/:id", {
                templateUrl: base + "supplier/delete.html",
                controller: "EditSupplierController",
                controllerAs: "vm"
            })

            .when("/category", {
                templateUrl: base + "category/index.html",
                controller: "CategoryController",
                controllerAs: "vm"
            })

            .when("/product", {
                templateUrl: base + "product/index.html",
                controller: "ProductController",
                controllerAs: "vm"
            })
            .when("/product-create", {
                templateUrl: base + "product/create.html",
                controller: "CreateProductController",
                controllerAs: "vm"
            })
            .when("/product-details/:id", {
                templateUrl: base + "product/details.html",
                controller: "EditProductController",
                controllerAs: "vm"
            })
            .when("/product-edit/:id", {
                templateUrl: base + "product/edit.html",
                controller: "EditProductController",
                controllerAs: "vm"
            })
            .when("/product-delete/:id", {
                templateUrl: base + "product/delete.html",
                controller: "EditProductController",
                controllerAs: "vm"
            })

            .when("/shipper", {
                templateUrl: base + "shipper/index.html",
                controller: "ShipperController",
                controllerAs: "vm"
            })
            .when("/shipper-create", {
                templateUrl: base + "shipper/create.html",
                controller: "CreateShipperController",
                controllerAs: "vm"
            })
            .when("/shipper-details/:id", {
                templateUrl: base + "shipper/details.html",
                controller: "EditShipperController",
                controllerAs: "vm"
            })
            .when("/shipper-edit/:id", {
                templateUrl: base + "shipper/edit.html",
                controller: "EditShipperController",
                controllerAs: "vm"
            })
            .when("/shipper-delete/:id", {
                templateUrl: base + "shipper/delete.html",
                controller: "DeleteShipperController",
                controllerAs: "vm"
            })

            .when("/customer", {
                templateUrl: base + "customer/index.html",
                controller: "CustomerController",
                controllerAs: "vm"
            })
            .when("/customer-create", {
                templateUrl: base + "customer/create.html",
                controller: "CreateCustomerController",
                controllerAs: "vm"
            })
            .when("/customer-details/:id", {
                templateUrl: base + "customer/details.html",
                controller: "EditCustomerController",
                controllerAs: "vm"
            })
            .when("/customer-edit/:id", {
                templateUrl: base + "customer/edit.html",
                controller: "EditCustomerController",
                controllerAs: "vm"
            })
            .when("/customer-delete/:id", {
                templateUrl: base + "customer/delete.html",
                controller: "EditCustomerController",
                controllerAs: "vm"
            })

            .when("/order", {
                templateUrl: base + "order/index.html",
                controller: "OrderController",
                controllerAs: "vm"
            })
            .when("/order-create", {
                templateUrl: base + "order/create.html",
                controller: "CreateOrderController",
                controllerAs: "vm"
            })
            .when("/order-details/:id", {
                templateUrl: base + "order/details.html",
                controller: "OrderDetailsController",
                controllerAs: "vm"
            })

            .when("/region", {
                templateUrl: base + "region/index.html",
                controller: "RegionController",
                controllerAs: "vm"
            })

            .when("/employee", {
                templateUrl: base + "employee/index.html",
                controller: "EmployeeController",
                controllerAs: "vm"
            });
    });
})(angular.module("northwindApp"));
