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
    public class TRANSACCIONController : Controller
    {
        private INF244PROJECTEntities db = new INF244PROJECTEntities();

        // GET: TRANSACCION
        public ActionResult Index()
        {
            var tRANSACCIONs = db.TRANSACCIONs.Include(t => t.ARTICULO);
            return View(tRANSACCIONs.ToList());
        }

        // GET: TRANSACCION/Details/5
        [Authorize(Roles = "Adm, Con")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRANSACCION tRANSACCION = db.TRANSACCIONs.Find(id);
            if (tRANSACCION == null)
            {
                return HttpNotFound();
            }
            return View(tRANSACCION);
        }

        // GET: TRANSACCION/Create
        [Authorize(Roles = "Adm, Con")]
        public ActionResult Create()
        {
            ViewBag.ID_ARTICULO = new SelectList(db.ARTICULOes, "ID_ARTICULO", "DESCRIPCION_ARTICULO");
            return View();
        }

        // POST: TRANSACCION/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_TRANSACCION,TIPO_TRANSACCION,ID_ARTICULO,FECHA_TRANSACCION,CANTIDAD_TRANSACCION,MONTO_TRANSACCION")] TRANSACCION tRANSACCION)
        {
            if (ModelState.IsValid)
            {
                db.TRANSACCIONs.Add(tRANSACCION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_ARTICULO = new SelectList(db.ARTICULOes, "ID_ARTICULO", "DESCRIPCION_ARTICULO", tRANSACCION.ID_ARTICULO);
            return View(tRANSACCION);
        }

        // GET: TRANSACCION/Edit/5
        [Authorize(Roles = "Adm, Con")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRANSACCION tRANSACCION = db.TRANSACCIONs.Find(id);
            if (tRANSACCION == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_ARTICULO = new SelectList(db.ARTICULOes, "ID_ARTICULO", "DESCRIPCION_ARTICULO", tRANSACCION.ID_ARTICULO);
            return View(tRANSACCION);
        }

        // POST: TRANSACCION/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_TRANSACCION,TIPO_TRANSACCION,ID_ARTICULO,FECHA_TRANSACCION,CANTIDAD_TRANSACCION,MONTO_TRANSACCION")] TRANSACCION tRANSACCION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tRANSACCION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_ARTICULO = new SelectList(db.ARTICULOes, "ID_ARTICULO", "DESCRIPCION_ARTICULO", tRANSACCION.ID_ARTICULO);
            return View(tRANSACCION);
        }

        // GET: TRANSACCION/Delete/5
        [Authorize(Roles = "Adm, Con")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRANSACCION tRANSACCION = db.TRANSACCIONs.Find(id);
            if (tRANSACCION == null)
            {
                return HttpNotFound();
            }
            return View(tRANSACCION);
        }

        // POST: TRANSACCION/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TRANSACCION tRANSACCION = db.TRANSACCIONs.Find(id);
            db.TRANSACCIONs.Remove(tRANSACCION);
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
