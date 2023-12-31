using System.Linq.Expressions;
using Common.EntityOperation;
using Domain.Base.Entity;
using Domain.Base.ValueObject;

namespace Repository.Base;

public static class ExtensionMethod
{
    
    public static IOrderedQueryable<T> Sort<Y,T>(this IQueryable<T> entity, string? sortType, Func<string, Expression<Func<T, object>>> switcher) where Y : StronglyTypeId where T :BaseEntityWithoutId 
    {

        if (sortType == null || sortType.Equals("")) return entity.OrderBy(x => x.DateCreated);

        List<string> strings = sortType.Split(',').ToList();
        IOrderedQueryable<T> OrderedData = null;
        foreach (string item in strings)
        {
            bool isDes = item.StartsWith("-");
            Expression<Func<T, object>> x = switcher(isDes ? item.Substring(1) : item);
            if (item.Equals(strings.First()))
            {
                OrderedData = entity.SortBy(x, isDes);
            }
            else
            {

                OrderedData = OrderedData.SortThenBy(x, isDes);
            }

        }
        return OrderedData;

    }



    
}