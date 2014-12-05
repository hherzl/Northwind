var northwindApp = angular.module("northwindApp", ["ngRoute"]);

northwindApp.config(function ($routeProvider) {
    $routeProvider

    .when("/", {
        templateUrl: "views/home.html",
        controller: "homeCtrl"
    })

    .when("/shippers", {
        templateUrl: "views/shippers.html",
        controller: "shipperCtrl"
    })

    .when("/products", {
        templateUrl: "views/products.html",
        controller: "productCtrl"
    })
});
