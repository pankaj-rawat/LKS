using System;

namespace LKS.Entities
{
    public class NewsComment
    {
        public int Id { get; set; }
        public int NewsPostId { get; set; }
        public string Comment { get; set; }
        public DateTime CommentDate { get; set; }
        public string VerifiedBy { get; set; }
        public bool IsVerified { get; set; }
        public NewsPost NewsPost { get; set; }
    }
}
