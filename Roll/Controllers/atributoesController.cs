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
    public class atributoesController : Controller
    {
        private RollEntities db = new RollEntities();

        // GET: atributoes
        public ActionResult Index()
        {
            return View(db.atributo.ToList());
        }

        // GET: atributoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            atributo atributo = db.atributo.Find(id);
            if (atributo == null)
            {
                return HttpNotFound();
            }
            return View(atributo);
        }

        // GET: atributoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: atributoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_atributo,atributo_nombre")] atributo atributo)
        {
            if (ModelState.IsValid)
            {
                db.atributo.Add(atributo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(atributo);
        }

        // GET: atributoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            atributo atributo = db.atributo.Find(id);
            if (atributo == null)
            {
                return HttpNotFound();
            }
            return View(atributo);
        }

        // POST: atributoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_atributo,atributo_nombre")] atributo atributo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(atributo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(atributo);
        }

        // GET: atributoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            atributo atributo = db.atributo.Find(id);
            if (atributo == null)
            {
                return HttpNotFound();
            }
            return View(atributo);
        }

        // POST: atributoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            atributo atributo = db.atributo.Find(id);
            db.atributo.Remove(atributo);
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
