using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Roll;

namespace Roll.Controllers
{
    public class mochilasController : Controller
    {
        private RollEntities db = new RollEntities();

        // GET: mochilas
        public ActionResult Index()
        {
            return View(db.mochilas.ToList());
        }

        // GET: mochilas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mochilas mochilas = db.mochilas.Find(id);
            if (mochilas == null)
            {
                return HttpNotFound();
            }
            return View(mochilas);
        }

        // GET: mochilas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: mochilas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_mochila,nombre,multiplicador_peso,capacidad")] mochilas mochilas)
        {
            if (ModelState.IsValid)
            {
                db.mochilas.Add(mochilas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mochilas);
        }

        // GET: mochilas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mochilas mochilas = db.mochilas.Find(id);
            if (mochilas == null)
            {
                return HttpNotFound();
            }
            return View(mochilas);
        }

        // POST: mochilas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_mochila,nombre,multiplicador_peso,capacidad")] mochilas mochilas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mochilas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mochilas);
        }

        // GET: mochilas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mochilas mochilas = db.mochilas.Find(id);
            if (mochilas == null)
            {
                return HttpNotFound();
            }
            return View(mochilas);
        }

        // POST: mochilas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            mochilas mochilas = db.mochilas.Find(id);
            db.mochilas.Remove(mochilas);
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
