(function () {
    "use strict";

    angular.module("northwindApp").controller("HomeController", HomeController);

    HomeController.$inject = ["$log", "$cookies", "toaster"];

    function HomeController($log, $cookies, toaster) {
        $cookies.lang = "en";

        //toaster.pop("success", "1st", "first");
        //toaster.pop("error", "2nd", "second");
        //toaster.pop("warning", "3rd", "third");
        //toaster.pop("wait", "4th", "fourth");
        //toaster.pop("note", "5th", "fifth");
    };
})();
