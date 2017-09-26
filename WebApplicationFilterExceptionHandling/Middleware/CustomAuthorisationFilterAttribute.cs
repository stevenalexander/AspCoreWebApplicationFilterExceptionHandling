using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace WebApplicationFilterExceptionHandling.Middleware
{
    public class CustomAuthorisationFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var idString = context.HttpContext.Request.Query["id"];
            int id;
            int.TryParse(idString, out id);

            if (id == 1000)
            {
                throw new ArgumentException("Exception in filter");
            }

            if (id == 10)
            {
                context.Result = new RedirectToActionResult("Unauthorised", "Home", null);
            }
        }
    }
}
