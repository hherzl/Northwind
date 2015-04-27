(function () {
    "use strict";

    northwindApp.service("CategoryService", ["$log", "$http", "UrlBuilderService", function ($log, $http, urlBuilder) {
        var url = urlBuilder.getUrl("Category");

        this.getAll = function () {
            return $http.get(url);
        };
    }]);
})();
