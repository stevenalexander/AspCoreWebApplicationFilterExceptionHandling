using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplicationFilterExceptionHandling.Middleware;

namespace WebApplicationFilterExceptionHandling.Controllers
{
    public class HomeController : Controller
    {
        [CustomAuthorisationFilter]
        public IActionResult Index(int id)
        {
            if (id == 100)
            {
                throw new ArgumentException("Exception in action");
            }

            ViewData["id"] = id;
            ViewData["description"] = "CustomAuthorisationFilter";

            return View("Index");
        }

        [CustomTypeFilter]
        public IActionResult IndexCustomTypeFilterAttribute(int id)
        {
            if (id == 100)
            {
                throw new ArgumentException("Exception in action");
            }

            ViewData["id"] = id;
            ViewData["description"] = "CustomTypeFilterAttribute";

            return View("Index");
        }

        [MiddlewareFilter(typeof(CustomApplicationFilter))]
        public IActionResult IndexCustomApplicationFilter(int id)
        {
            if (id == 100)
            {
                throw new ArgumentException("Exception in action");
            }

            ViewData["id"] = id;
            ViewData["description"] = "CustomApplicationFilter";

            return View("Index");
        }

        public IActionResult Unauthorised()
        {
            var result = View();
            result.StatusCode = (int)System.Net.HttpStatusCode.Unauthorized;

            return result;
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
