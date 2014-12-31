northwindApp.service("TranslationService", function ($resource) {
    this.getTranslation = function ($scope, language) {
        var languageFilePath = "/app/translations/app_" + language + ".json";

        $resource(languageFilePath).get(function (data) {
            $scope.translation = data;
        });
    };
});
