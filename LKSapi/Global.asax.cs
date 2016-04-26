﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace LKSapi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            Database.SetInitializer(new NullDatabaseInitializer<LKS.DataModel.LKSContext>());


            AutoMapper.Mapper.CreateMap<LKS.Entities.NewsPost, LKSapi.Models.NewsPostModel>();
            AutoMapper.Mapper.CreateMap<LKS.Entities.NewsComment, LKSapi.Models.NewsCommentModel>();
        }
    }
}
