using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Caelum.Blog.WebApp.Filtros
{
    public class AutorizacaoFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Session.GetString("usuario") == null)
            {
                //redirect
                context.Result = new RedirectToActionResult(
                    "Login", "Usuario", new { area = "" });
            }
        }
    }
}
