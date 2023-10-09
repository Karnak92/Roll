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
    public class razasController : Controller
    {
        private RollEntities db = new RollEntities();

        // GET: razas
        public ActionResult Index()
        {
            return View(db.razas.ToList());
        }

        // GET: razas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            razas razas = db.razas.Find(id);
            if (razas == null)
            {
                return HttpNotFound();
            }
            return View(razas);
        }

        // GET: razas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: razas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_raza,raza_nombre,raza_fuerza,raza_inteligencia,raza_sabiduria,raza_agilidad,raza_resistencia,raza_mult_vida,raza_aspecto,raza_afinidad_dioses,raza_caracteristicas,raza_atributos")] razas razas)
        {
            if (ModelState.IsValid)
            {
                db.razas.Add(razas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(razas);
        }

        // GET: razas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            razas razas = db.razas.Find(id);
            if (razas == null)
            {
                return HttpNotFound();
            }
            return View(razas);
        }

        // POST: razas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_raza,raza_nombre,raza_fuerza,raza_inteligencia,raza_sabiduria,raza_agilidad,raza_resistencia,raza_mult_vida,raza_aspecto,raza_afinidad_dioses,raza_caracteristicas,raza_atributos")] razas razas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(razas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(razas);
        }

        // GET: razas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            razas razas = db.razas.Find(id);
            if (razas == null)
            {
                return HttpNotFound();
            }
            return View(razas);
        }

        // POST: razas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            razas razas = db.razas.Find(id);
            db.razas.Remove(razas);
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
