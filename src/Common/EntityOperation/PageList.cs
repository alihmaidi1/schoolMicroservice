namespace Common.EntityOperation;

public class PageList<T>
{

    
    
    public PageList(List<T> items,  long count, int? pageNumber=1, int ?pageSize=null)
    {

        TotalCount = count;
        PageSize = pageSize==null?(count==0)?1:(int?)count:pageSize;
        CurrentPage = pageNumber;
        Data    = items;
        var x = (count / (double)PageSize);
        TotalPages = x==0?1:Math.Ceiling((decimal)x);
    }
    
    
    
    public int? CurrentPage { get; private set; }
    public decimal TotalPages { get; private set; }
    public int? PageSize { get; private set; }
    public long TotalCount { get; private set; }
    public bool HasPrevious => CurrentPage > 1;
    public bool HasNext => CurrentPage < TotalPages;
    public List<T> Data { get; private set; }

    
}