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
    public class TIPOINVENTARIOController : Controller
    {
        private INF244PROJECTEntities db = new INF244PROJECTEntities();

        // GET: TIPOINVENTARIO
        public ActionResult Index()
        {
            return View(db.TIPOINVENTARIOs.ToList());
        }

        // GET: TIPOINVENTARIO/Details/5
        [Authorize(Roles = "Adm, Con")]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPOINVENTARIO tIPOINVENTARIO = db.TIPOINVENTARIOs.Find(id);
            if (tIPOINVENTARIO == null)
            {
                return HttpNotFound();
            }
            return View(tIPOINVENTARIO);
        }

        // GET: TIPOINVENTARIO/Create
        [Authorize(Roles = "Adm, Con")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: TIPOINVENTARIO/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_TIPOINVENTARIO,DESCRIPCION_INVENTARIO,CUENTACONTABLE,ESTADO")] TIPOINVENTARIO tIPOINVENTARIO)
        {
            if (ModelState.IsValid)
            {
                db.TIPOINVENTARIOs.Add(tIPOINVENTARIO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tIPOINVENTARIO);
        }

        // GET: TIPOINVENTARIO/Edit/5
        [Authorize(Roles = "Adm, Con")]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPOINVENTARIO tIPOINVENTARIO = db.TIPOINVENTARIOs.Find(id);
            if (tIPOINVENTARIO == null)
            {
                return HttpNotFound();
            }
            return View(tIPOINVENTARIO);
        }

        // POST: TIPOINVENTARIO/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_TIPOINVENTARIO,DESCRIPCION_INVENTARIO,CUENTACONTABLE,ESTADO")] TIPOINVENTARIO tIPOINVENTARIO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tIPOINVENTARIO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tIPOINVENTARIO);
        }

        // GET: TIPOINVENTARIO/Delete/5
        [Authorize(Roles = "Adm, Con")]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPOINVENTARIO tIPOINVENTARIO = db.TIPOINVENTARIOs.Find(id);
            if (tIPOINVENTARIO == null)
            {
                return HttpNotFound();
            }
            return View(tIPOINVENTARIO);
        }

        // POST: TIPOINVENTARIO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            TIPOINVENTARIO tIPOINVENTARIO = db.TIPOINVENTARIOs.Find(id);
            db.TIPOINVENTARIOs.Remove(tIPOINVENTARIO);
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
