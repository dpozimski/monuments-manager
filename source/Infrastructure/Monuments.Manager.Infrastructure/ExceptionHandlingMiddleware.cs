using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Monuments.Manager.Application.Exceptions;
using Monuments.Manager.Infrastructure.ViewModels;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace Monuments.Manager.Infrastructure
{
    public class ExceptionHandlingMiddleware
    {
        private readonly IOptions<MvcJsonOptions> _serializationOptions;

        public ExceptionHandlingMiddleware(IOptions<MvcJsonOptions> serializationOptions)
        {
            _serializationOptions = serializationOptions;
        }

        public async Task Invoke(HttpContext context)
        {
            var ex = context.Features.Get<IExceptionHandlerFeature>()?.Error;
            if (ex == null)
                return;

            context.Response.StatusCode = GetStatusCode(ex);

            var error = new ErrorTypeViewModel()
            {
                Message = ex.Message,
                ErrorType = GetErrorType(ex)
            };

            using (var writer = new StreamWriter(context.Response.Body))
            {
                var result = JsonConvert.SerializeObject(error, _serializationOptions.Value.SerializerSettings);
                await writer.WriteAsync(result);
                await writer.FlushAsync();
            }
        }

        private string GetErrorType(Exception ex)
        {
            switch (ex)
            {
                case MonumentsManagerAppException appEx:
                    return appEx.Type.ToString();
                default:
                    return "Unknown";
            }
        }

        private int GetStatusCode(Exception ex)
        {
            switch(ex)
            {
                case MonumentsManagerAppException authEx when authEx.Type == ExceptionType.AuthenticationFail:
                    return (int)HttpStatusCode.Forbidden;
                case MonumentsManagerAppException appEx:
                    return (int)HttpStatusCode.BadRequest;
                default:
                    return (int)HttpStatusCode.InternalServerError;

            }
        }
    }
}
