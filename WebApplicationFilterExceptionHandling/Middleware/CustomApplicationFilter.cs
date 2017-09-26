using Microsoft.AspNetCore.Builder;

namespace WebApplicationFilterExceptionHandling.Middleware
{
    public class CustomApplicationFilter
    {
        public void Configure(IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseCustomApplicationMiddleware();
        }
    }
}
