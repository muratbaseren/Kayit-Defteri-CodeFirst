using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TelefonDefteriCodeFirst.DataAccessLayer;
using TelefonDefteriCodeFirst.Models;

namespace TelefonDefteriCodeFirst.Controllers
{
    public class SiteUsersController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["login"] == null)
            {
                filterContext.Result = new RedirectResult("/Home/Index");
            }
        }

        private KayitTakipDBContext db = new KayitTakipDBContext();

        // GET: SysUsers
        public ActionResult Index()
        {
            return View(db.SiteUsers.ToList());
        }

        // GET: SysUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiteUser sysUser = db.SiteUsers.Find(id);
            if (sysUser == null)
            {
                return HttpNotFound();
            }
            return View(sysUser);
        }

        // GET: SysUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SysUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Surname,Email,Username,Password")] SiteUser sysUser)
        {
            if (ModelState.IsValid)
            {
                db.SiteUsers.Add(sysUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sysUser);
        }

        // GET: SysUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiteUser sysUser = db.SiteUsers.Find(id);
            if (sysUser == null)
            {
                return HttpNotFound();
            }
            return View(sysUser);
        }

        // POST: SysUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Surname,Email,Username,Password")] SiteUser sysUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sysUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sysUser);
        }

        // GET: SysUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiteUser sysUser = db.SiteUsers.Find(id);
            if (sysUser == null)
            {
                return HttpNotFound();
            }
            return View(sysUser);
        }

        // POST: SysUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SiteUser sysUser = db.SiteUsers.Find(id);
            db.SiteUsers.Remove(sysUser);
            db.SaveChanges();
            return RedirectToAction("Index");
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
