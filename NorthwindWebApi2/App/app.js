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
    .when("/customers", {
        templateUrl: "views/Customers/index.html",
        controller: "CustomerCtrl"
    })
});
