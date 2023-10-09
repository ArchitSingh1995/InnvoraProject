using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.Xml;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using LogInSignupProject.Models;

namespace LogInSignupProject.Controllers
{
    public class LogController : Controller
    {
        SignLogInEntities db=new SignLogInEntities();
        // GET: Log
        public ActionResult LogIn()
        {
            return View();
        }

        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(LogInVeiwModel logInVeiwModel)
        {
            bool userExit = db.UserTb1.Any(x=>x.Email == logInVeiwModel.Email && x.Password==logInVeiwModel.Password);
            UserTb1 u = db.UserTb1.FirstOrDefault(x => x.Email == logInVeiwModel.Email && x.Password == logInVeiwModel.Password);

            if(userExit)
            {
                FormsAuthentication.SetAuthCookie(u.UserName, false);
                return RedirectToAction("Dashboard", "Tasks");
            }

            ModelState.AddModelError("", "UserName or Password is wrong");

            return View();
        }
        [HttpPost]
        public ActionResult Signup(UserTb1 userTb1)
        {
            db.UserTb1.Add(userTb1);
            db.SaveChanges();
            return RedirectToAction("LogIn");
        }
        public ActionResult Signout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("LogIn");
        }
        
    }
}