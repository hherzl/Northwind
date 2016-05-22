(function (app) {
    "use strict";

    app.controller("HomeController", HomeController);

    HomeController.$inject = ["$log", "$cookies", "toaster"];

    function HomeController($log, $cookies, toaster) {
        $cookies.lang = "en";
    };
})(angular.module("northwindApp"));
