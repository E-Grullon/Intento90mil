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
    public class ARTICULOController : Controller
    {
        private INF244PROJECTEntities db = new INF244PROJECTEntities();

        // GET: ARTICULO
        public ActionResult Index(string Criterio = null)
        {
            var aRTICULOes = db.ARTICULOes.Include(a => a.TIPOINVENTARIO);
            return View(db.ARTICULOes.Where(p => Criterio == null ||
            p.ID_ARTICULO.ToString().StartsWith(Criterio) ||
            p.DESCRIPCION_ARTICULO.StartsWith(Criterio) ||
            p.EXISTENCIA_ARTICULO.(Criterio) ||
            p.ID_TIPOINVENTARIO.StartsWith(Criterio) ||
            p.COSTOUNITARIO.ToString().StartsWith(Criterio) ||
            p.ESTADO.StartsWith(Criterio)).ToList());




        }

        // GET: ARTICULO/Details/5
        [Authorize(Roles = "Adm, Con")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ARTICULO aRTICULO = db.ARTICULOes.Find(id);
            if (aRTICULO == null)
            {
                return HttpNotFound();
            }
            return View(aRTICULO);
        }

        // GET: ARTICULO/Create
        [Authorize(Roles = "Adm, Con")]
        public ActionResult Create()
        {
            ViewBag.ID_TIPOINVENTARIO = new SelectList(db.TIPOINVENTARIOs, "ID_TIPOINVENTARIO", "DESCRIPCION_INVENTARIO");
            return View();
        }

        // POST: ARTICULO/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_ARTICULO,DESCRIPCION_ARTICULO,EXISTENCIA_ARTICULO,ID_TIPOINVENTARIO,COSTOUNITARIO,ESTADO")] ARTICULO aRTICULO)
        {
            if (ModelState.IsValid)
            {
                db.ARTICULOes.Add(aRTICULO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_TIPOINVENTARIO = new SelectList(db.TIPOINVENTARIOs, "ID_TIPOINVENTARIO", "DESCRIPCION_INVENTARIO", aRTICULO.ID_TIPOINVENTARIO);
            return View(aRTICULO);
        }

        // GET: ARTICULO/Edit/5
        [Authorize(Roles = "Adm, Con")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ARTICULO aRTICULO = db.ARTICULOes.Find(id);
            if (aRTICULO == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_TIPOINVENTARIO = new SelectList(db.TIPOINVENTARIOs, "ID_TIPOINVENTARIO", "DESCRIPCION_INVENTARIO", aRTICULO.ID_TIPOINVENTARIO);
            return View(aRTICULO);
        }

        // POST: ARTICULO/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_ARTICULO,DESCRIPCION_ARTICULO,EXISTENCIA_ARTICULO,ID_TIPOINVENTARIO,COSTOUNITARIO,ESTADO")] ARTICULO aRTICULO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aRTICULO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_TIPOINVENTARIO = new SelectList(db.TIPOINVENTARIOs, "ID_TIPOINVENTARIO", "DESCRIPCION_INVENTARIO", aRTICULO.ID_TIPOINVENTARIO);
            return View(aRTICULO);
        }

        // GET: ARTICULO/Delete/5
        [Authorize(Roles = "Adm, Con")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ARTICULO aRTICULO = db.ARTICULOes.Find(id);
            if (aRTICULO == null)
            {
                return HttpNotFound();
            }
            return View(aRTICULO);
        }

        // POST: ARTICULO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ARTICULO aRTICULO = db.ARTICULOes.Find(id);
            db.ARTICULOes.Remove(aRTICULO);
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
