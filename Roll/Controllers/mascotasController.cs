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
    public class mascotasController : Controller
    {
        private RollEntities db = new RollEntities();

        // GET: mascotas
        public ActionResult Index()
        {
            var mascotas = db.mascotas.Include(m => m.personajes).Include(m => m.monstruos);
            return View(mascotas.ToList());
        }

        // GET: mascotas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mascotas mascotas = db.mascotas.Find(id);
            if (mascotas == null)
            {
                return HttpNotFound();
            }
            return View(mascotas);
        }

        // GET: mascotas/Create
        public ActionResult Create()
        {
            ViewBag.mascota_owner = new SelectList(db.personajes, "id", "nombre");
            ViewBag.mascota_especie = new SelectList(db.monstruos, "mon_id", "nombre");
            return View();
        }

        // POST: mascotas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "mascota_id,mascota_owner,mascota_nivel,mascota_nombre,mascota_especie,mascota_vida_inicial,mascota_mana_inicial,mascota_vida_real,mascota_mana_real,mascota_vida_actual,mascota_mana_actual,mascota_velocidad_inicial,mascota_velocidad_real,mascota_velocidad_actual,mascota_armor_inicial,mascota_armor_real,mascota_armor_actual,mascota_mr_inicial,mascota_mr_real,mascota_mr_actual,mascota_evasion_inicial,mascota_evasion_real,mascota_evasion_actual,mascota_evolucion,mascota_montura,mascota_vuela,mascota_nadar,mascota_respira_agua,mascota_capacidad_carga,mascota_peso,mascota_altura,mascota_ancho,mascota_afinidad,mascota_edad")] mascotas mascotas)
        {
            if (ModelState.IsValid)
            {
                db.mascotas.Add(mascotas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.mascota_owner = new SelectList(db.personajes, "id", "nombre", mascotas.mascota_owner);
            ViewBag.mascota_especie = new SelectList(db.monstruos, "mon_id", "nombre", mascotas.mascota_especie);
            return View(mascotas);
        }

        // GET: mascotas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mascotas mascotas = db.mascotas.Find(id);
            if (mascotas == null)
            {
                return HttpNotFound();
            }
            ViewBag.mascota_owner = new SelectList(db.personajes, "id", "nombre", mascotas.mascota_owner);
            ViewBag.mascota_especie = new SelectList(db.monstruos, "mon_id", "nombre", mascotas.mascota_especie);
            return View(mascotas);
        }

        // POST: mascotas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "mascota_id,mascota_owner,mascota_nivel,mascota_nombre,mascota_especie,mascota_vida_inicial,mascota_mana_inicial,mascota_vida_real,mascota_mana_real,mascota_vida_actual,mascota_mana_actual,mascota_velocidad_inicial,mascota_velocidad_real,mascota_velocidad_actual,mascota_armor_inicial,mascota_armor_real,mascota_armor_actual,mascota_mr_inicial,mascota_mr_real,mascota_mr_actual,mascota_evasion_inicial,mascota_evasion_real,mascota_evasion_actual,mascota_evolucion,mascota_montura,mascota_vuela,mascota_nadar,mascota_respira_agua,mascota_capacidad_carga,mascota_peso,mascota_altura,mascota_ancho,mascota_afinidad,mascota_edad")] mascotas mascotas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mascotas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.mascota_owner = new SelectList(db.personajes, "id", "nombre", mascotas.mascota_owner);
            ViewBag.mascota_especie = new SelectList(db.monstruos, "mon_id", "nombre", mascotas.mascota_especie);
            return View(mascotas);
        }

        // GET: mascotas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mascotas mascotas = db.mascotas.Find(id);
            if (mascotas == null)
            {
                return HttpNotFound();
            }
            return View(mascotas);
        }

        // POST: mascotas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            mascotas mascotas = db.mascotas.Find(id);
            db.mascotas.Remove(mascotas);
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
