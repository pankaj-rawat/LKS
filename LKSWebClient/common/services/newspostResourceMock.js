(function () {
    "use strict";

    var app = angular.module('newspostResourceMock',
        ['ngMockE2E']);

    app.run(function ($httpBackend) {
        var newsposts = [
        {
            "id": 1,
            "heading": "header",
            "author": "author",
            "postDate": "postDate",
            "comment": "1000"
        },
        {
            "id": 2,
            "heading": "header1",
            "author": "author1",
            "postDate": "postDate1",
            "comment": "20000"
        },
        {
            "id": 3,
            "heading": "header2",
            "author": "author2",
            "postDate": "postDate2",
            "comment": "10"
        }];
        var newspostUrl = "/LKSapi/NewsPost";
        var selRegEx = new RegExp(newspostUrl+"/[0-9][0-9]*",'');
        $httpBackend.whenGET(newspostUrl).respond(newsposts);
        $httpBackend.whenGET(selRegEx).respond(function (method, url, data) {
            var newspost =[{ "id": 0 }];
            var params = url.split('/');
            var paramLength = params.length;
            var id = params[paramLength - 1];
            if (id > 0) {
                for(var i=0;i<newsposts.length;i++)
                {
                    if(newsposts[i].id==id)
                    {
                        newspost[0] = newsposts[i];
                        break;
                    }
                }
            };
            return [200, newspost, {}];
        });
    })

}());