namespace Common.Entity.EntityOperation;

public static class EntityExtensionMethod
{
    
    public static   PageList<T> ToPagedList<T>(this IQueryable<T> source, int? pageNumber, int? pageSize)
    {
        if (source == null)
        {
            throw new ArgumentNullException("source");
        }
        if(pageSize is null)
        {

            return new PageList<T>(source.ToList(), source.ToList().Count);

        }
        int PaginatePageNumber =(int) ((pageNumber == null || pageNumber <= 0) ? 1 : pageNumber);
        int PaginatePageSize= (int) ((pageSize<=0) ? 10 : pageSize); 
        var items = source.Skip(((PaginatePageNumber - 1) * PaginatePageSize)).Take(PaginatePageSize).ToList();
        var count = source.Count();
        return new PageList<T>(items.ToList(), count, PaginatePageNumber, pageSize);
    }

    
    
    public static PageList<T> ToPaginateResult<T>(this IEnumerable<T> source,long count, int? pageNumber, int? pageSize)
    {

        if (source == null)
        {
            throw new ArgumentNullException("source");
        }
        if (pageSize is null && pageNumber is null)
        {

            return new PageList<T>(source.ToList(), source.ToList().Count,1,10);

        }
        int PaginatePageNumber = (int)((pageNumber == null || pageNumber <= 0) ? 1 : pageNumber);
        int PaginatePageSize = (int)((pageSize <= 0) ? 10 : pageSize);
        return new PageList<T>(source.ToList(), count, PaginatePageNumber, pageSize);


    }
    
}