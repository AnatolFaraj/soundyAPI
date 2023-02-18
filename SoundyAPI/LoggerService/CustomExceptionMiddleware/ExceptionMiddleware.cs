using Core.Exceptions;
using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LoggerService.CustomExceptionMiddleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerManager _logger;

        public ExceptionMiddleware(RequestDelegate next, ILoggerManager logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (NotImplementedException niex)
            {
                _logger.LogError($"A new NotImplementedException has been thrown: {niex}");
                await HandleExceptionAsync(httpContext, niex);
            }
            catch (AccessViolationException avex)
            {
                _logger.LogError($"A new violation exception has been thrown: {avex}");
                await HandleExceptionAsync(httpContext, avex);
            }
            catch (CustomResponseException cre)
            {
                httpContext.Response.StatusCode = cre.StatusCode;
                httpContext.Response.ContentType = "application/json";
                await httpContext.Response
                    .WriteAsync(new ErrorDetailsModel() 
                    { 
                        StatusCode = cre.StatusCode, 
                        Message = cre.ErrorDescription
                    
                    }.ToString());
            }
            catch (Exception ex)
            {
                
                _logger.LogError($"Something went wrong: {ex}");
                await HandleExceptionAsync(httpContext, ex);
                
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var message = exception switch
            {
                AccessViolationException => "Access violation error from the custom middleware.",
                NotImplementedException => "Sorry, the reqired logic is to be implemented soon",
                _ => $"Internal Server Error from custom middleware. {exception.Message}"
            };

            await context.Response.WriteAsync(new ErrorDetailsModel()
            {
                StatusCode = context.Response.StatusCode,
                Message = message
            }.ToString());
        }
    }

}
