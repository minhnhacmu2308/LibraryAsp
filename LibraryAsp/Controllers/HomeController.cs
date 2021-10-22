using LibraryAsp.Dao;
using LibraryAsp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryAsp.Controllers
{
    public class HomeController : Controller
    {

        AuthenticationDao authenticationDao = new AuthenticationDao();
        public ActionResult Index()
        {
            User user = (User)Session["USER"];
            if (user == null)
            {
                return RedirectToAction("Login", "Authentication");
            }
            else
            {
                var list = authenticationDao.getInformationByUserName(user.email);
                ViewBag.list = list;
                return View();
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}