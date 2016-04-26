using System;
using System.Collections.Generic;

namespace LKS.Entities
{
    public class NewsPost
    {
        public int Id { get; set; }
        public string Heading { get; set; }
        public string Detail { get; set; }
        public string Author { get; set; }
        public DateTime PostDate { get; set; }
        public string ImagePath { get; set; }
        public ICollection<NewsComment> NewsComments { get; set; }
    }
}
