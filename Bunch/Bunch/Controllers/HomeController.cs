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
            List<Test> tests = dbmanager.GetUsers();
            ViewBag.tests = tests;
            return View();
        }

        public ActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateUser(Test test)
        {
            DBmanager dbmanager = new DBmanager();

                dbmanager.NewUser(test);

            return RedirectToAction("Index");
        }

        public ActionResult EditUser(int id)
        {
            DBmanager dbmanager = new DBmanager();
            Test test = dbmanager.GetUserById(id);
            return View(test);
        }

        [HttpPost]
        public ActionResult EditUser(Test test)
        {
            DBmanager dbmanager = new DBmanager();
            dbmanager.UpdateUser(test);
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