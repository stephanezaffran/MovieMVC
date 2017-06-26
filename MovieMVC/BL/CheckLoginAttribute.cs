using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieMVC.BL;

namespace MovieMVC.BL
{
   
    public class CheckLoginAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (UISession.CurrentUser == null || UISession.CurrentUser.UserID == null)
            {
                filterContext.HttpContext.Response.Redirect("~/Home/Login");
            }
        }
    }  
}