namespace Common.OperationResult.Base;

public class OperationResultBase<T>:IDisposable
{
    
    
    public T Result { get; set; }

    public string Message { get; set; }
        
    public int StatusCode { get; set; }

    public Dictionary<string,List<string>> Errors { get; set; }
        
        
    protected bool disposed = false;


    //~OperationResultBase()
    //{

    //    Dispose();
    //}

    public void Dispose()
    {
            

        disposed = true;
    }

    //protected virtual void Dispose(bool disposing)
    //{

    //    if(disposed) return;


    //    disposed = true;    

    //}
    
}