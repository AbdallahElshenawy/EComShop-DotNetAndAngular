using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using EComShop.Core.Dtos;
using EComShop.API.Helper;

namespace EComShop.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IMemoryCache _memoryCache;

        public ExceptionMiddleware(RequestDelegate next, IMemoryCache memoryCache)
        {
            _next = next;
            _memoryCache = memoryCache;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                applySecurity(context);
                if (!IsRequestAllowed(context))
                {
                    context.Response.StatusCode = (int)HttpStatusCode.TooManyRequests;
                    context.Response.ContentType = "application/json";
                    var response = new ApiResponse<object>("Too many requests. Please try again later.");
                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                    return;
                }
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private bool IsRequestAllowed(HttpContext context)
        {
            var ip = context.Connection.RemoteIpAddress?.ToString();
            var cacheKey = $"Rate:{ip}";
            var now = DateTime.UtcNow;

            if (!_memoryCache.TryGetValue(cacheKey, out (DateTime Timestamp, int Count) cacheEntry))
            {
                cacheEntry = (Timestamp: now, Count: 1);
                _memoryCache.Set(cacheKey, cacheEntry, TimeSpan.FromSeconds(30));
                return true;
            }

            if (now - cacheEntry.Timestamp > TimeSpan.FromSeconds(30))
            {
                cacheEntry = (Timestamp: now, Count: 1);
                _memoryCache.Set(cacheKey, cacheEntry, TimeSpan.FromSeconds(30));
                return true;
            }

            if (cacheEntry.Count >= 5)
            {
                return false;
            }

            cacheEntry = (cacheEntry.Timestamp, cacheEntry.Count + 1);
            _memoryCache.Set(cacheKey, cacheEntry, TimeSpan.FromSeconds(30));
            return true;
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            ApiResponse<object> response;

            switch (exception)
            {
                case KeyNotFoundException:
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    response = new ApiResponse<object>("Resource not found");
                    break;
                case UnauthorizedAccessException:
                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    response = new ApiResponse<object>("Unauthorized access");
                    break;
                case ArgumentException:
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    response = new ApiResponse<object>("Invalid request");
                    break;
                default:
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    response = new ApiResponse<object>("An unexpected error occurred");
                    break;
            }

            var jsonResponse = JsonSerializer.Serialize(response);
            await context.Response.WriteAsync(jsonResponse);
        }

        private void applySecurity(HttpContext context)
        {
            context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
            context.Response.Headers.Add("X-XSS-Protection", "1; mode=block");
            context.Response.Headers.Add("X-Frame-Options", "DENY");
        }
    }
}