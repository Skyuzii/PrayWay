using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using PrayWay.Application.Common.Dto;
using PrayWay.Application.Common.Exceptions;

namespace PrayWay.Api.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IWebHostEnvironment _env;
        private readonly Dictionary<Type, Func<HttpContext, Exception, Task>> _exceptionsInvokers;

        public ExceptionMiddleware(RequestDelegate next, IWebHostEnvironment env)
        {
            _next = next;
            _env = env;

            _exceptionsInvokers = new Dictionary<Type, Func<HttpContext, Exception, Task>>
            {
                {typeof(ValidationException), HandleValidationException},
                {typeof(NotFoundException), HandleNotFoundException},
                {typeof(RestException), HandleRestException},
            };
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception exception)
            {
                var exType = exception.GetType();
                if (_exceptionsInvokers.ContainsKey(exType))
                {
                    await _exceptionsInvokers[exType].Invoke(context, exception);
                }
                else
                {
                    await HandleUnrecognizedException(context, exception);
                }
            }
        }

        private async Task HandleUnrecognizedException(HttpContext context, Exception exception)
        {
            var error = BuildDefaultErrorResult(exception);

            var result = JsonConvert.SerializeObject(error);
			
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.ContentType = "application/json";
			
            await context.Response.WriteAsync(result);
        }

        private async Task HandleValidationException(HttpContext context, Exception exception)
        {
            var error = new BadResponseDto();
            var validationException = exception as ValidationException;

            if (validationException.Errors != null && validationException.Errors.Any())
            {
                error.Errors = validationException.Errors.Select(x => x.ErrorMessage).ToList();
            }
            else if (!string.IsNullOrEmpty(validationException.Message))
            {
                error.Errors = new List<string> { exception.Message };
            }
            
            var result = JsonConvert.SerializeObject(error);

            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Response.ContentType = "application/json";
			
            await context.Response.WriteAsync(result);
        }
        
        private Task HandleNotFoundException(HttpContext context, Exception exception)
        {
            context.Response.StatusCode = StatusCodes.Status404NotFound;
            return Task.CompletedTask;
        }

        private async Task HandleRestException(HttpContext context, Exception exception)
        {
            var restException = (RestException)exception;
            var error = BuildDefaultErrorResult(restException);
			
            var result = JsonConvert.SerializeObject(error);

            context.Response.StatusCode = restException.StatusCode;
            context.Response.ContentType = "application/json";
			
            await context.Response.WriteAsync(result);
        }

        private BadResponseDto BuildDefaultErrorResult(Exception exception)
        {
            var badResponse = new BadResponseDto
            {
                Errors = new List<string> {exception.Message}
            };

            if (_env.IsDevelopment())
            {
                badResponse.Errors.Add(exception.StackTrace);
            }
            
            return badResponse;
        }
    }
}