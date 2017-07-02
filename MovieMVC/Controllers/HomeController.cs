using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieMVC.BL;
using MovieMVC.Models;
using MovieMVC.Entitys;

namespace MovieMVC.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            UISession.CurrentUser = null;
            User usr = UserBL.getUserByLoginPassword(model.Login, model.Password);
            if (usr != null)
            {
                UISession.CurrentUser = usr;
                return Redirect("/Home/getUsers");
            }
            else

                return Redirect("/Home/Login");
        }
        
        [CheckLoginAttribute]
        public ActionResult getUsers()
        {
            this.ViewData["userName"] = UISession.CurrentUser.Name;
            this.ViewData["userSurname"] = UISession.CurrentUser.Surname;
            UserModel model = new UserModel();
            model.users = UserBL.getUsers();
           
            return View(model);
        }

        [CheckLoginAttribute]
        public ActionResult adduser()
        {
            this.ViewData["userName"] = UISession.CurrentUser.Name;
            this.ViewData["userSurname"] = UISession.CurrentUser.Surname;
            return View();
        }

        [CheckLoginAttribute]
        [HttpPost]        
        public ActionResult adduserpost(AddUsernModel user)
        {
            BL.UserBL.AddUser(user);


            this.ViewData["userName"] = UISession.CurrentUser.Name;
            this.ViewData["userSurname"] = UISession.CurrentUser.Surname;
            //return Redirect("/Home/getUsers");
            return Json(user, JsonRequestBehavior.AllowGet);
           
        }

        [CheckLoginAttribute]
        [HttpPost]
        public JsonResult ModifyUser(UserModelUnique user)
        {
            BL.UserBL.ModifyUser(user);
            return Json(user, JsonRequestBehavior.AllowGet);
        }
        
        [CheckLoginAttribute]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            UserModelUnique user =  UserBL.getUserbyID(id);
            return View("EditUser", user) ;
        }

        [CheckLoginAttribute]
        public ActionResult EditUser(UserModelUnique user)
        {
            return View(user);
        }

        [HttpPost]
        public ActionResult test(UserModelUnique model)
        {

            //string name = user.user.Name;
            //string surname = user.user.Surname;
            return View();
        }
        public ActionResult test2()
        {

            return View();
        }

        [HttpPost]
        public ActionResult test2(UserModelUnique model)
        {

            //string name = user.user.Name;
            //string surname = user.user.Surname;
            return View();
        }
        public ActionResult GetUsersByAPI()
        {
            return View();
        }        
    }
}

