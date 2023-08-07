using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Fast.Template.Basic.Dics;

/// <summary>
/// 
/// </summary>
public static class DicinfoEfCoreQueryableExtensions
{
    public static IQueryable<Dicinfo> IncludeDetails(this IQueryable<Dicinfo> queryable, bool include = true)
    {
        if (!include)
        {
            return queryable;
        }

        return queryable
                .Include(x => x.DicType)
            ;
    }
}
