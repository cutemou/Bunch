using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bunch.Models;

namespace Bunch.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            DBmanager dbmanager = new DBmanager();
            List<User> users = dbmanager.GetUsers();
            ViewBag.users = users;
            return View();
        }

        public ActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateUser(User user)
        {
            DBmanager dbmanager = new DBmanager();
            try
            {
                dbmanager.NewUser(user);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return RedirectToAction("Index");
        }

        public ActionResult EditUser(int id)
        {
            DBmanager dbmanager = new DBmanager();
            User user = dbmanager.GetUserById(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult EditUser(User user)
        {
            DBmanager dbmanager = new DBmanager();
            dbmanager.UpdateUser(user);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteUser(int id)
        {
            DBmanager dbmanager = new DBmanager();
            dbmanager.DeleteUserById(id);
            return RedirectToAction("Index");
        }
    }
}