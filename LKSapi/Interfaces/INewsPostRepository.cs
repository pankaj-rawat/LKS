using LKSapi.Models;
using System.Collections.Generic;

namespace LKSapi.Interfaces
{
    public interface INewsPostRepository
    {
         NewsPostModel GetNewsPost(int Id);
         IEnumerable<NewsPostModel> GetNewsPosts(int pageSize, int pageNumber, string orderBy = "Id");
         IEnumerable<NewsPostModel> GetNewsPosts();
         bool AddNewsPost(NewsPostModel newsPost);
         bool DeleteNewsPost(int Id);
         bool ModifyNewsPost(NewsPostModel newsPost);
    }
}
