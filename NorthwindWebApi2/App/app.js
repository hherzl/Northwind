var northwindApp = angular.module("northwindApp", [
    "ngRoute",
    "ngResource",
    "ngCookies",
    "ngTable",
    "ui.bootstrap",
    "toaster"
]);

northwindApp.config(function ($routeProvider) {
    $routeProvider
        .when("/", {
            templateUrl: "views/home.html",
            controller: "HomeController"
        })

        .when("/category", {
            templateUrl: "views/Category/index.html",
            controller: "CategoryController"
        })

        .when("/shipper", {
            templateUrl: "views/Shipper/index.html",
            controller: "ShipperController"
        })
        .when("/shipper-create", {
            templateUrl: "views/Shipper/create.html",
            controller: "CreateShipperController"
        })
        .when("/shipper-details/:id", {
            templateUrl: "views/Shipper/details.html",
            controller: "EditShipperController"
        })
        .when("/shipper-edit/:id", {
            templateUrl: "views/Shipper/edit.html",
            controller: "EditShipperController"
        })
        .when("/shipper-delete/:id", {
            templateUrl: "views/Shipper/delete.html",
            controller: "EditShipperController"
        })

        .when("/product", {
            templateUrl: "views/Product/index.html",
            controller: "ProductController"
        })
        .when("/product-create", {
            templateUrl: "views/Product/create.html",
            controller: "CreateProductController"
        })
        .when("/product-details/:id", {
            templateUrl: "views/Product/details.html",
            controller: "EditProductController"
        })
        .when("/product-edit/:id", {
            templateUrl: "views/Product/edit.html",
            controller: "EditProductController"
        })
        .when("/product-delete/:id", {
            templateUrl: "views/Product/delete.html",
            controller: "EditProductController"
        })

        .when("/customer", {
            templateUrl: "views/Customer/index.html",
            controller: "CustomerController"
        })
        .when("/customer-create", {
            templateUrl: "views/Customer/create.html",
            controller: "CreateCustomerController"
        })
        .when("/customer-details/:id", {
            templateUrl: "views/Customer/details.html",
            controller: "EditCustomerController"
        })
        .when("/customer-edit/:id", {
            templateUrl: "views/Customer/edit.html",
            controller: "EditCustomerController"
        })
        .when("/customer-delete/:id", {
            templateUrl: "views/Customer/delete.html",
            controller: "EditCustomerController"
        })

        .when("/order", {
            templateUrl: "views/Order/index.html",
            controller: "OrderController"
        })
        .when("/order-create", {
            templateUrl: "views/Order/create.html",
            controller: "CreateOrderController"
        })

        .when("/supplier", {
            templateUrl: "views/Supplier/index.html",
            controller: "SupplierController"
        })
        .when("/supplier-details/:id", {
            templateUrl: "views/Supplier/details.html",
            controller: "EditSupplierController"
        })
        .when("/supplier-create", {
            templateUrl: "views/Supplier/create.html",
            controller: "CreateSupplierController"
        })
        .when("/supplier-edit/:id", {
            templateUrl: "views/Supplier/edit.html",
            controller: "EditSupplierController"
        })
        .when("/supplier-delete/:id", {
            templateUrl: "views/Supplier/delete.html",
            controller: "EditSupplierController"
        });
});
