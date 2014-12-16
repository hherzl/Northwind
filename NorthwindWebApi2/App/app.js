var northwindApp = angular.module("northwindApp", ["ngRoute"]);

northwindApp.config(function ($routeProvider) {
    $routeProvider
        .when("/", {
            templateUrl: "views/home.html",
            controller: "homeCtrl"
        })
        .when("/shippers", {
            templateUrl: "views/Shippers/index.html",
            controller: "ShipperCtrl"
        })
        .when("/shipper-create", {
            templateUrl: "views/Shippers/create.html",
            controller: "CreateShipperCtrl"
        })
        .when("/shipper-details/:id", {
            templateUrl: "views/Shippers/details.html",
            controller: "EditShipperCtrl"
        })
        .when("/shipper-edit/:id", {
            templateUrl: "views/Shippers/edit.html",
            controller: "EditShipperCtrl"
        })
        .when("/shipper-delete/:id", {
            templateUrl: "views/Shippers/delete.html",
            controller: "EditShipperCtrl"
        })
        .when("/products", {
            templateUrl: "views/Products/index.html",
            controller: "ProductCtrl"
        })
           .when("/product-create", {
               templateUrl: "views/Products/create.html",
               controller: "CreateProductCtrl"
           })
        .when("/product-details/:id", {
            templateUrl: "views/Products/details.html",
            controller: "EditProductCtrl"
        })
          .when("/product-edit/:id", {
              templateUrl: "views/Products/edit.html",
              controller: "EditProductCtrl"
          })
        .when("/product-delete/:id", {
            templateUrl: "views/Products/delete.html",
            controller: "EditProductCtrl"
        })
        .when("/customers", {
            templateUrl: "views/Customers/index.html",
            controller: "CustomerCtrl"
        })
        .when("/suppliers", {
            templateUrl: "views/Suppliers/index.html",
            controller: "SupplierController"
        })
     .when("/supplier-details/:id", {
         templateUrl: "views/Suppliers/details.html",
         controller: "EditSupplierController"
     })
         .when("/supplier-create", {
             templateUrl: "views/Suppliers/create.html",
             controller: "CreateSupplierController"
         })
     .when("/supplier-edit/:id", {
         templateUrl: "views/Suppliers/edit.html",
         controller: "EditSupplierController"
     })
     .when("/supplier-delete/:id", {
         templateUrl: "views/Suppliers/delete.html",
         controller: "EditSupplierController"
     });
});
