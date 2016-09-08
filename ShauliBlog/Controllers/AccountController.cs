using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShauliBlog.DAL;
using ShauliBlog.Models;

namespace ShauliBlog.Controllers
{
    public class AccountController : Controller
    {
        private ShauliBlogContext db = new ShauliBlogContext();

        // GET: Account/Create
        public ActionResult Login()
        {
            return View();
        }

        // POST: Account/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "ID,UserName,Password")] Manager manager)
        {
            if (ModelState.IsValid)
            {
                var users = from man in db.Managers
                            where man.UserName.Equals(manager.UserName) && man.UserName.Equals(manager.UserName)
                            select man;

                // If The User Doesn't Exist
                if (users.Count() == 0)
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                }
                else
                {
                    Session["Name"] = manager.UserName;
                    return RedirectToAction("Index" ,"Blog");
                }

            }

            return View(manager);
        }


        // GET: Account/Create
        public ActionResult Register()
        {
            return View();
        }

        // POST: Account/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "ID,UserName,Password")] Manager manager)
        {
            if (ModelState.IsValid)
            {
                db.Managers.Add(manager);
                db.SaveChanges();

                Session["Name"] = manager.UserName;
                return RedirectToAction("Index", "Blog");

            }

            return View(manager);
        }

        public ActionResult LogOff()
        {
            Session["Name"] = null;
            return RedirectToAction("Index", "Blog");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
