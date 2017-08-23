﻿using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace LP.UserProfile.Api.Middlewares.ErrorHandling
{
    internal sealed class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            (HttpStatusCode code, string message) httpCodeWithMessage = exception.ToHttpStatusCode();
            var result = JsonConvert.SerializeObject(new { error = httpCodeWithMessage.message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)httpCodeWithMessage.code;

            return context.Response.WriteAsync(result);
        }
    }
}
