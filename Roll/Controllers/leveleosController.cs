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
    public class leveleosController : Controller
    {
        private RollEntities db = new RollEntities();

        // GET: leveleos
        public ActionResult Index()
        {
            var leveleo = db.leveleo.Include(l => l.personajes);
            return View(leveleo.ToList());
        }

        // GET: leveleos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            leveleo leveleo = db.leveleo.Find(id);
            if (leveleo == null)
            {
                return HttpNotFound();
            }
            return View(leveleo);
        }

        // GET: leveleos/Create
        public ActionResult Create()
        {
            ViewBag.id_personaje = new SelectList(db.personajes, "id", "nombre");
            return View();
        }

        // POST: leveleos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,id_personaje,puntos_disponibles")] leveleo leveleo)
        {
            if (ModelState.IsValid)
            {
                db.leveleo.Add(leveleo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_personaje = new SelectList(db.personajes, "id", "nombre", leveleo.id_personaje);
            return View(leveleo);
        }

        // GET: leveleos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            leveleo leveleo = db.leveleo.Find(id);
            if (leveleo == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_personaje = new SelectList(db.personajes, "id", "nombre", leveleo.id_personaje);
            return View(leveleo);
        }

        // POST: leveleos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,id_personaje,puntos_disponibles")] leveleo leveleo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(leveleo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_personaje = new SelectList(db.personajes, "id", "nombre", leveleo.id_personaje);
            return View(leveleo);
        }

        // GET: leveleos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            leveleo leveleo = db.leveleo.Find(id);
            if (leveleo == null)
            {
                return HttpNotFound();
            }
            return View(leveleo);
        }

        // POST: leveleos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            leveleo leveleo = db.leveleo.Find(id);
            db.leveleo.Remove(leveleo);
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
