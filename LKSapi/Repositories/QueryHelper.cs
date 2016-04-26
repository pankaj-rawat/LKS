using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;

namespace LKSapi.Repositories
{
    public static class QueryHelper
    {
        public static Expression<Func<T,string>> GetPropertyExpression<T>(string propertyName)
        {
            if(typeof(T).GetProperty(propertyName,BindingFlags.IgnoreCase |BindingFlags.Public| BindingFlags.Instance)==null)
            {
                return null;
            }
            ParameterExpression paramExp = Expression.Parameter(typeof(T),"pankaj");
            MemberExpression me = Expression.PropertyOrField(paramExp, propertyName);                
            LambdaExpression le=Expression.Lambda(me,paramExp);
            return (Expression<Func<T, string>>) le; 

        }

        public static Expression<Func<T, int>> GetPropertyExpressionInt<T>(string propertyName)
        {
            if (typeof(T).GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance) == null)
            {
                return null;
            }
            ParameterExpression paramExp = Expression.Parameter(typeof(T), "pankaj");
            MemberExpression me = Expression.PropertyOrField(paramExp, propertyName);
            LambdaExpression le = Expression.Lambda(me, paramExp);
            return (Expression<Func<T, int>>)le;

        }
    }
}