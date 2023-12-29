using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;
using Common.Exceptions;
using Common.OperationResult.Base;
using Microsoft.AspNetCore.Http;

using FluentValidation;
using ValidationException = FluentValidation.ValidationException;

namespace Common.ExtensionMethod;

public static class ActionMethods
{

    public static  Action<Exception, HttpContext> HandlerExceptionCase = async (error,context) =>
    {

        var response=context.Response;
                response.ContentType= "application/json";
                var Result = new OperationResultBase<string>() { };


                switch (error)
                {


                    case ValidationException exception:
                        Result.Message = exception.Message;
                        Result.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                        response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                        Result.Errors = exception.Errors.GroupBy(e => e.PropertyName).ToDictionary(x => x.Key, x => x.Select(x => x.ErrorMessage).ToList());

                        break;

                    case UnAuthenticationException exception:
                        Result.Message = exception.Message;
                        Result.StatusCode = (int)HttpStatusCode.Unauthorized;
                        response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        break;


                    case UnAuthorizationException exception:
                        Result.Message = exception.Message;
                        Result.StatusCode = (int)HttpStatusCode.Forbidden;
                        response.StatusCode = (int)HttpStatusCode.Forbidden;
                        break;

                    case Exception exception:
                        Result.Message = exception.Message;
                        Result.StatusCode= (int)HttpStatusCode.InternalServerError;
                        response.StatusCode= (int)HttpStatusCode.InternalServerError;
                        break;
                    default :
                        Result.Message = error.Message;
                        Result.StatusCode = (int)HttpStatusCode.InternalServerError;
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;

    
                }

                
                var errors= JsonSerializer.Serialize(Result);
                await response.WriteAsync(errors);



    };


}