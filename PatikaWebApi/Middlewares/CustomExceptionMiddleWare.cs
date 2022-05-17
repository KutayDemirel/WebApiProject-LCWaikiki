﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using PatikaWebApi.Services;
using System;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;

namespace PatikaWebApi.Middlewares
{
    public class CustomExceptionMiddleWare
    {
        private readonly RequestDelegate _next;

        private readonly ILoggerService _loggerService;
        public CustomExceptionMiddleWare(RequestDelegate next, ILoggerService loggerService)
        {
            _next = next;
            _loggerService = loggerService;
        }

        public async Task Invoke(HttpContext context)
        {
            var watch = Stopwatch.StartNew();
            try
            {
                string message = "[Request] HTTP " + context.Request.Method + " - " + context.Request.Path;
                _loggerService.Write(message);
                await _next(context);
                watch.Stop();
                message = "[Request] HTTP " + context.Request.Method + " - " + context.Request.Path + " responded " +
                    context.Response.StatusCode.ToString() + " in " + watch.Elapsed.TotalMilliseconds + " ms";
                _loggerService.Write(message);
            }
            catch (Exception ex)
            {
                watch.Stop();
                await HandleException(context, ex, watch);
            }
        }

        private Task HandleException(HttpContext context, Exception ex, Stopwatch watch)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;


            string message = "[Error]   HTTP" + context.Request.Method + " - " + context.Response.StatusCode +
                " Error Message " + ex.Message + " in " + watch.Elapsed.TotalMilliseconds + " ms";
            _loggerService.Write(message);


            var result = JsonConvert.SerializeObject(new { Error = ex.Message }, Formatting.None);
            return context.Response.WriteAsync(result);
        }
    }


    public static class CustomExceptionMiddlewareExtension
    {
        public static IApplicationBuilder UseCustomExceptionMiddleWare(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionMiddleWare>();
        }
    }
}
