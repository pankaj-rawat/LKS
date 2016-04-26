(function()
{
    "use strict";
    var app = angular.module('common.services', ['ngResource']);
    app.constant("appSettings",
        {
            serverPath: "http://localhost:51223/"
        });
}());