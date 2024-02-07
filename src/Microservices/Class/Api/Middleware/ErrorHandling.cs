using ClassInfrutructure;
using Common.ExtensionMethod;

namespace Api.Middleware;

public class ErrorHandling:IMiddleware
{
    ApplicationDbContext DbContext;
    public ErrorHandling(ApplicationDbContext DbContext)
    {

        this.DbContext = DbContext;

    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {

        try
        {
            DbContext.Database.BeginTransaction();


            await next(context);

            DbContext.Database.CommitTransaction();

        }
        catch (Exception error)
        {

            DbContext.Database.RollbackTransaction();
            ActionMethods.HandlerExceptionCase(error, context);

        }
        
    }

    
}