using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LKSapi.Interfaces;
using LKSapi.Models;
using Microsoft.Practices.Unity;
using System.Web.Http.Cors;
using System.Linq.Expressions;

namespace LKSapi.Controllers
{
    [EnableCorsAttribute("http://localhost:57450", "*", "*")]
    public class NewsPostController : ApiController
    {
        [Dependency]
        public INewsPostRepository NewsPostRepository { get; set; }

        [HttpGet]
        public NewsPostModel GetNewPost(int Id)
        {
            return NewsPostRepository.GetNewsPost(Id);
        }

        [HttpGet]
        public IHttpActionResult GetNewsPosts(int pageSize, int pageNumber)
        {
            return GetNewsPosts(pageSize, pageNumber, string.Empty);
        }
        [HttpGet]
        public IHttpActionResult GetNewsPosts(int pageSize, int pageNumber, string orderBy)
        {
            var newsPostList = NewsPostRepository.GetNewsPosts();
            IEnumerable<NewsPostModel> newsPosts = null;
            int recCount = 0;
            double totalPages = 0;
            if (newsPostList != null)
            {
                recCount = newsPostList.Count();
                totalPages = Math.Ceiling((double)recCount / pageSize);
                if (string.IsNullOrEmpty(orderBy))
                {
                    newsPosts = NewsPostRepository.GetNewsPosts(pageSize, pageNumber);
                }
                else
                {
                    newsPosts = NewsPostRepository.GetNewsPosts(pageSize, pageNumber, orderBy);
                }
            }

            var res = new
            {
                RecordCount = recCount,
                TotalPages = totalPages,
                NewsPostList = newsPosts.ToList()
            };
            return Ok(res);
        }

    }
}
