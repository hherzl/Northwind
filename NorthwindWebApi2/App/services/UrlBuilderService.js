(function () {
    "use strict";

    northwindApp.service("UrlBuilderService", [function () {
        var baseUrl = "/api";

        this.getUrl = function (value) {
            return baseUrl + "/" + value + "/";
        };
    }]);
})();
