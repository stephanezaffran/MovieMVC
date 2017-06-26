using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieMVC.Entitys;
using System.Security.Cryptography;
using System.Text;


namespace MovieMVC.BL
{

    public static class UISession
    {
        private static HttpContext Current
        {
            get { return HttpContext.Current; }
        }

        public static User CurrentUser
        {
            get { return Current.Session["CurrentUser"] as User; }
            set { HttpContext.Current.Session["CurrentUser"] = value; }

        }
    }
}