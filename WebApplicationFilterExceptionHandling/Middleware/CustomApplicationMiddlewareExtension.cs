using Microsoft.AspNetCore.Builder;

namespace WebApplicationFilterExceptionHandling.Middleware
{
    public static class CustomApplicationMiddlewareExtension
    {
        public static IApplicationBuilder UseCustomApplicationMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomApplicationMiddleware>();
        }
    }
}
