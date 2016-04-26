using AutoMapper;
using LKS.DataModel;
using LKS.Entities;
using LKSapi.Interfaces;
using LKSapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace LKSapi.Repositories
{
    public class NewsPostRepository : INewsPostRepository, IDisposable
    {
        public NewsPostModel GetNewsPost(int Id)
        {
            return new NewsPostModel();
        }

        public IEnumerable<NewsPostModel> GetNewsPosts()
        {
            IEnumerable<NewsPostModel> res = null;
            using (LKSContext objContext = new LKSContext())
            {
                var newsPosts = objContext.NewsPosts.AsNoTracking();
                res = Mapper.Map<IEnumerable<NewsPostModel>>(newsPosts.ToList());
            }
            return res;
        }
        public IEnumerable<NewsPostModel> GetNewsPosts(int pageSize, int pageNumber, string orderBy = "Id")
        {
            IEnumerable<NewsPostModel> res = null;
            using (LKSContext objContext = new LKSContext())
            {
                IQueryable<NewsPost> newsPosts = objContext.NewsPosts.AsNoTracking();
                PropertyInfo piOrderBy = typeof(NewsPost).GetProperty(orderBy);

                if (piOrderBy != null)
                {
                    Type type = piOrderBy.PropertyType;
                    if (type == typeof(System.Int32))
                    {
                        Expression<Func<NewsPost, int>> orderByExp = QueryHelper.GetPropertyExpressionInt<NewsPost>(orderBy);
                        newsPosts = newsPosts.OrderBy(orderByExp);
                    }
                    else
                    {
                        Expression<Func<NewsPost, string>> orderByExp = QueryHelper.GetPropertyExpression<NewsPost>(orderBy);
                        newsPosts = newsPosts.OrderBy(orderByExp);
                    }
                }
                newsPosts = newsPosts.Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize);

                res = Mapper.Map<IEnumerable<NewsPostModel>>(newsPosts.ToList());
            }

            return res;
        }

        public bool AddNewsPost(NewsPostModel newsPost)
        {
            throw new NotImplementedException();
        }

        public bool DeleteNewsPost(int Id)
        {
            throw new NotImplementedException();
        }

        public bool ModifyNewsPost(NewsPostModel newsPost)
        {
            throw new NotImplementedException();
        }

        protected void Dispose(bool disposing)
        {

        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}