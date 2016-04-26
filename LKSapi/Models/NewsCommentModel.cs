using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LKSapi.Models
{
    public class NewsCommentModel
    {
        public int Id { get; set; }
        public int NewsPostId { get; set; }
        public string Comment { get; set; }
        public DateTime CommentDate { get; set; }
        public string VerifiedBy { get; set; }
        public bool IsVerified { get; set; }
    }
}