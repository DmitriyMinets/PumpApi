
using PumpApi.Models;
using System.Net;

namespace PumpApi.Middlewares
{
    public class ExceptionMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch(InvalidDataException ex)
            {
                await HandleDataExceptionAsync(context, ex);
            }
            catch (Exception ex) 
            {
                await HandleExceptionAsync(context, ex);
            }


        }
        /// <summary>
        /// Обработчик ошибок невалидных данных
        /// </summary>
        /// <param name="context"></param>
        /// <param name="ex"></param>
        /// <returns></returns>
        private static async Task HandleDataExceptionAsync(HttpContext context, InvalidDataException ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            await context.Response.WriteAsync(new ErrorDetails
            {
                StatusCode = context.Response.StatusCode,
                Message = ex.Message
            }.ToString());
        }


        /// <summary>
        /// Обработчик общих ошибок
        /// </summary>
        /// <param name="context"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            await context.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
                Message = exception.Message
            }.ToString());
        }
    }
}
