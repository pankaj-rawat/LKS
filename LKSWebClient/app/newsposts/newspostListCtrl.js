(function () {
    "use strict";
     function NewsPostListCtrl(newspostResource) {
        var newsPostm = this;

        newspostResource.query(function (data) {
            newsPostm.newsposts = data;
            //newspostResource.get(function(data){
            //    newsPostm.newsposts = data;
         });
    }
    angular.module("newspostmodule").controller("NewsPostListCtrl",
        ["newspostResource",
            NewsPostListCtrl]);
}());