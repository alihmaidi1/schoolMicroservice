using Common.OperationResult.Base;
using Microsoft.AspNetCore.Mvc;

namespace Common.OperationResult.MethodExtension;


public static class Result
{
    public static OperationResultBase<T> CreateOperationResultBase<T>(T Result,string Message,int StatusCode) 
    {

        return new OperationResultBase<T>
        {
            Result=Result,
            Message=Message,
            StatusCode=StatusCode

        };

    }
    public static JsonResult ToJsonResult<T>(this OperationResult OperationResult, int StatusCode, T? Result=default(T),string Message="") 
    {

        var OperationResultBase=CreateOperationResultBase<T>(Result,Message,StatusCode);
        return new JsonResult(OperationResultBase)
        {

            StatusCode=StatusCode
        };
        
    }

    public static async Task<JsonResult> ToJsonResultAsync<T>(this Task<OperationResult> OperationResult, int StatusCode, T? Result = null, string Message = "") where T : class
    {

        return (await OperationResult).ToJsonResult(StatusCode,Result,Message);
    }

    
}