using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic;

namespace SmallCRM.Data
{
    public static class EntityFrameworkExtensions
    {
        public static IQueryable<T> Where<T>(this IQueryable<T> source, Expression<Func<T, bool>> predicate)
        {
            source = source.Where("IsDeleted == false"); // From System.linq.Dynamic Library
            source = Queryable.Where<T>(source, predicate);
            return source;
        }
    }
}
