using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Intento90mil;

namespace Intento90mil.Controllers
{
    [Authorize]
    public class ALMACENController : Controller
    {
        private INF244PROJECTEntities db = new INF244PROJECTEntities();

        // GET: ALMACEN
        public ActionResult Index()
        {
            return View(db.ALMACENs.ToList());
        }

        // GET: ALMACEN/Details/5
        [Authorize(Roles = "Adm")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ALMACEN aLMACEN = db.ALMACENs.Find(id);
            if (aLMACEN == null)
            {
                return HttpNotFound();
            }
            return View(aLMACEN);
        }

        // GET: ALMACEN/Create
        [Authorize(Roles = "Adm")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: ALMACEN/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_ALMACEN,DESCRIPCION,ESTADO")] ALMACEN aLMACEN)
        {
            if (ModelState.IsValid)
            {
                db.ALMACENs.Add(aLMACEN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aLMACEN);
        }

        // GET: ALMACEN/Edit/5
        [Authorize(Roles = "Adm")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ALMACEN aLMACEN = db.ALMACENs.Find(id);
            if (aLMACEN == null)
            {
                return HttpNotFound();
            }
            return View(aLMACEN);
        }

        // POST: ALMACEN/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_ALMACEN,DESCRIPCION,ESTADO")] ALMACEN aLMACEN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aLMACEN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aLMACEN);
        }

        // GET: ALMACEN/Delete/5
        [Authorize(Roles = "Adm")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ALMACEN aLMACEN = db.ALMACENs.Find(id);
            if (aLMACEN == null)
            {
                return HttpNotFound();
            }
            return View(aLMACEN);
        }

        // POST: ALMACEN/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ALMACEN aLMACEN = db.ALMACENs.Find(id);
            db.ALMACENs.Remove(aLMACEN);
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
