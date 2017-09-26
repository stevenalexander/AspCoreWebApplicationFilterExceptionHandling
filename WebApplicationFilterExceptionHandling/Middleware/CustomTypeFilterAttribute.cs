using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationFilterExceptionHandling.Middleware
{
    /// <summary>
    /// Custom filter with DI
    /// </summary>
    public class CustomTypeFilterAttribute : TypeFilterAttribute
    {
        public CustomTypeFilterAttribute() : base(typeof(CustomTypeFilterAttributeImpl))
        {
        }

        private class CustomTypeFilterAttributeImpl : IActionFilter
        {
            private readonly ICustomInjectedService _customInjectedService;

            public CustomTypeFilterAttributeImpl(ICustomInjectedService customInjectedService)
            {
                _customInjectedService = customInjectedService;
            }

            public void OnActionExecuting(ActionExecutingContext context)
            {
                _customInjectedService.DoStuff("OnActionExecuting");

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

            public void OnActionExecuted(ActionExecutedContext context)
            {
                _customInjectedService.DoStuff("OnActionExecuted");
            }
        }
    }
}
