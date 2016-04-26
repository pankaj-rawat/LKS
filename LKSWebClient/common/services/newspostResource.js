(function () {
    "use strict";
    var app = angular.module("common.services");
    app.factory("newspostResource",
        ["$resource",
            "appSettings",
        newspostResource]);

    function newspostResource($resource, appSettings) {
        return $resource(appSettings.serverPath + "/LKSapi/NewsPost/");
    }
}());