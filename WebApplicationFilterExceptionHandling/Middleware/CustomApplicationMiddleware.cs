using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace WebApplicationFilterExceptionHandling.Middleware
{
    public class CustomApplicationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ICustomInjectedService _customInjectedService;

        public CustomApplicationMiddleware(RequestDelegate next, ICustomInjectedService customInjectedService)
        {
            _next = next;
            _customInjectedService = customInjectedService;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            _customInjectedService.DoStuff("Invoke");

            var idString = httpContext.Request.Query["id"];
            int id;
            int.TryParse(idString, out id);

            if (id == 1000)
            {
                throw new ArgumentException("Exception in filter");
            }

            if (id == 10)
            {
                httpContext.Response.Redirect("/Home/Unauthorised");
            }

            await _next(httpContext);
        }
    }
}
