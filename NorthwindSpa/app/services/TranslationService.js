(function () {
    "use strict";

    angular.module("northwindApp").service("TranslationService", TranslationService);

    TranslationService.$inject = ["$cookies", "$resource"];

    function TranslationService($cookies, $resource) {
        var svc = this;

        svc.language = $cookies.lang;
        svc.languageFilePath = "/app/translations/app_" + svc.language + ".json";

        svc.setResource = function (vm) {
            $resource(svc.languageFilePath).get(function (data) {
                vm.translation = data;
            });
        };
    };
})();
