using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcCreditApp1.Models;

namespace MvcCreditApp1.Controllers
{
    [Authorize (Roles = "admin")]
    public class CreditsController : Controller
    {
        private CreditContext db = new CreditContext();

        // GET: Credits
        public ActionResult Index()
        {
            return View(db.Credits.ToList());
        }

        // GET: Credits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Credit credit = db.Credits.Find(id);
            if (credit == null)
            {
                return HttpNotFound();
            }
            return View(credit);
        }

        // GET: Credits/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Credits/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CreditId,Head,Period,Sum,Procent")] Credit credit)
        {
            if (ModelState.IsValid)
            {
                db.Credits.Add(credit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(credit);
        }

        // GET: Credits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Credit credit = db.Credits.Find(id);
            if (credit == null)
            {
                return HttpNotFound();
            }
            return View(credit);
        }

        // POST: Credits/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CreditId,Head,Period,Sum,Procent")] Credit credit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(credit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(credit);
        }

        // GET: Credits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Credit credit = db.Credits.Find(id);
            if (credit == null)
            {
                return HttpNotFound();
            }
            return View(credit);
        }

        // POST: Credits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Credit credit = db.Credits.Find(id);
            db.Credits.Remove(credit);
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
