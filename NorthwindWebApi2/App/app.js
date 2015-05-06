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

            .when("/category", {
                templateUrl: base + "Category/index.html",
                controller: "CategoryController"
            })

            .when("/shipper", {
                templateUrl: base + "Shipper/index.html",
                controller: "ShipperController"
            })
            .when("/shipper-create", {
                templateUrl: base + "Shipper/create.html",
                controller: "CreateShipperController"
            })
            .when("/shipper-details/:id", {
                templateUrl: base + "Shipper/details.html",
                controller: "EditShipperController"
            })
            .when("/shipper-edit/:id", {
                templateUrl: base + "Shipper/edit.html",
                controller: "EditShipperController"
            })
            .when("/shipper-delete/:id", {
                templateUrl: base + "Shipper/delete.html",
                controller: "EditShipperController"
            })

            .when("/product", {
                templateUrl: base + "Product/index.html",
                controller: "ProductController"
            })
            .when("/product-create", {
                templateUrl: base + "Product/create.html",
                controller: "CreateProductController"
            })
            .when("/product-details/:id", {
                templateUrl: base + "Product/details.html",
                controller: "EditProductController"
            })
            .when("/product-edit/:id", {
                templateUrl: base + "Product/edit.html",
                controller: "EditProductController"
            })
            .when("/product-delete/:id", {
                templateUrl: base + "Product/delete.html",
                controller: "EditProductController"
            })

            .when("/customer", {
                templateUrl: base + "Customer/index.html",
                controller: "CustomerController"
            })
            .when("/customer-create", {
                templateUrl: base + "Customer/create.html",
                controller: "CreateCustomerController"
            })
            .when("/customer-details/:id", {
                templateUrl: base + "Customer/details.html",
                controller: "EditCustomerController"
            })
            .when("/customer-edit/:id", {
                templateUrl: base + "Customer/edit.html",
                controller: "EditCustomerController"
            })
            .when("/customer-delete/:id", {
                templateUrl: base + "Customer/delete.html",
                controller: "EditCustomerController"
            })

            .when("/order", {
                templateUrl: base + "Order/index.html",
                controller: "OrderController"
            })
            .when("/order-create", {
                templateUrl: base + "Order/create.html",
                controller: "CreateOrderController"
            })
            .when("/order-details/:id", {
                templateUrl: base + "Order/details.html",
                controller: "OrderDetailsController"
            })

            .when("/supplier", {
                templateUrl: base + "Supplier/index.html",
                controller: "SupplierController"
            })
            .when("/supplier-details/:id", {
                templateUrl: base + "Supplier/details.html",
                controller: "EditSupplierController"
            })
            .when("/supplier-create", {
                templateUrl: base + "Supplier/create.html",
                controller: "CreateSupplierController"
            })
            .when("/supplier-edit/:id", {
                templateUrl: base + "Supplier/edit.html",
                controller: "EditSupplierController"
            })
            .when("/supplier-delete/:id", {
                templateUrl: base + "Supplier/delete.html",
                controller: "EditSupplierController"
            });
    });
})();
