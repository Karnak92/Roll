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
    public class asoc_personaje_mochilaController : Controller
    {
        private RollEntities db = new RollEntities();

        // GET: asoc_personaje_mochila
        public ActionResult Index()
        {
            var asoc_personaje_mochila = db.asoc_personaje_mochila.Include(a => a.mochilas).Include(a => a.personajes);
            return View(asoc_personaje_mochila.ToList());
        }

        // GET: asoc_personaje_mochila/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            asoc_personaje_mochila asoc_personaje_mochila = db.asoc_personaje_mochila.Find(id);
            if (asoc_personaje_mochila == null)
            {
                return HttpNotFound();
            }
            return View(asoc_personaje_mochila);
        }

        // GET: asoc_personaje_mochila/Create
        public ActionResult Create()
        {
            ViewBag.id_mochila = new SelectList(db.mochilas, "id_mochila", "nombre");
            ViewBag.id_personaje = new SelectList(db.personajes, "id", "nombre");
            return View();
        }

        // POST: asoc_personaje_mochila/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_asoc,id_personaje,id_mochila,peso_ocupado")] asoc_personaje_mochila asoc_personaje_mochila)
        {
            if (ModelState.IsValid)
            {
                db.asoc_personaje_mochila.Add(asoc_personaje_mochila);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_mochila = new SelectList(db.mochilas, "id_mochila", "nombre", asoc_personaje_mochila.id_mochila);
            ViewBag.id_personaje = new SelectList(db.personajes, "id", "nombre", asoc_personaje_mochila.id_personaje);
            return View(asoc_personaje_mochila);
        }

        // GET: asoc_personaje_mochila/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            asoc_personaje_mochila asoc_personaje_mochila = db.asoc_personaje_mochila.Find(id);
            if (asoc_personaje_mochila == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_mochila = new SelectList(db.mochilas, "id_mochila", "nombre", asoc_personaje_mochila.id_mochila);
            ViewBag.id_personaje = new SelectList(db.personajes, "id", "nombre", asoc_personaje_mochila.id_personaje);
            return View(asoc_personaje_mochila);
        }

        // POST: asoc_personaje_mochila/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_asoc,id_personaje,id_mochila,peso_ocupado")] asoc_personaje_mochila asoc_personaje_mochila)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asoc_personaje_mochila).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_mochila = new SelectList(db.mochilas, "id_mochila", "nombre", asoc_personaje_mochila.id_mochila);
            ViewBag.id_personaje = new SelectList(db.personajes, "id", "nombre", asoc_personaje_mochila.id_personaje);
            return View(asoc_personaje_mochila);
        }

        // GET: asoc_personaje_mochila/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            asoc_personaje_mochila asoc_personaje_mochila = db.asoc_personaje_mochila.Find(id);
            if (asoc_personaje_mochila == null)
            {
                return HttpNotFound();
            }
            return View(asoc_personaje_mochila);
        }

        // POST: asoc_personaje_mochila/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            asoc_personaje_mochila asoc_personaje_mochila = db.asoc_personaje_mochila.Find(id);
            db.asoc_personaje_mochila.Remove(asoc_personaje_mochila);
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
