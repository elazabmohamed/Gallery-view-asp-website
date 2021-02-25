using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _3DModels.Attributes
{
    public class CehckSession: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var MySession = HttpContext.Current.Session;

           if (MySession["Admin_Email"] == null)
            {
                filterContext.Result = new RedirectResult(string.Format("/Home/"));
            }
        }
    }
}