using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LKSapi.Models
{
    public class NewsPostModel
    {
        
        public NewsPostModel()
        {
        }
        public int Id { get; set; }
        public string Heading { get; set; }
        public string Detail { get; set; }
        public string Author { get; set; }
        public DateTime PostDate { get; set; }
        public string ImagePath { get; set; }
        public IEnumerable<NewsCommentModel> NewsComments { get; set; }
    }
}