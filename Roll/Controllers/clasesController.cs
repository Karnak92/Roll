using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Roll;
using Roll.Models;

namespace Roll.Controllers
{
    public class clasesController : Controller
    {
        private RollEntities db = new RollEntities();

        // GET: clases
        public ActionResult Index()
        {
            List<clases_skills_sugeridas> resultado = new List<clases_skills_sugeridas>();
            foreach(clases clase in db.clases.ToList())
            {
                clases_skills_sugeridas x = new clases_skills_sugeridas();
                x.sugerencia_activas = db.sugerir_activas(clase.id_clase).ToList();
                x.sugerencia_pasivas = db.sugerir_pasivas(clase.id_clase).ToList();
                x.clase = clase;

                resultado.Add(x);
            }
            return View(resultado);
        }

        // GET: clases/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clases clases = db.clases.Find(id);
            if (clases == null)
            {
                return HttpNotFound();
            }
            return View(clases);
        }

        // GET: clases/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: clases/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_clase,clas_nombre,clas_fuerza,clas_inteligencia,clas_sabiduria,clas_agilidad,clas_resistencia,clas_aspecto,clas_descripcion")] clases clases)
        {
            if (ModelState.IsValid)
            {
                db.clases.Add(clases);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clases);
        }

        // GET: clases/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clases clases = db.clases.Find(id);
            if (clases == null)
            {
                return HttpNotFound();
            }
            return View(clases);
        }

        // POST: clases/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_clase,clas_nombre,clas_fuerza,clas_inteligencia,clas_sabiduria,clas_agilidad,clas_resistencia,clas_aspecto,clas_descripcion")] clases clases)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clases).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clases);
        }

        // GET: clases/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clases clases = db.clases.Find(id);
            if (clases == null)
            {
                return HttpNotFound();
            }
            return View(clases);
        }

        // POST: clases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            clases clases = db.clases.Find(id);
            db.clases.Remove(clases);
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
