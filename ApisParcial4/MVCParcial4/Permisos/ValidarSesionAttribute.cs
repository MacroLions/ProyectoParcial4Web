using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Mvc;

namespace MVCParcial4.Permisos
{
    public class ValidarSesionAttribute : ActionFilterAttribute 
    {

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (HttpContext.Current.Session["Usuario"] == null)
            {
                filterContext.Result = new RedirectResult("~/Access");
            }
            base.OnActionExecuted(filterContext);
        }
       
            
    }
}