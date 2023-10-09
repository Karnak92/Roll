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
    public class asoc_personaje_skillController : Controller
    {
        private RollEntities db = new RollEntities();

        // GET: asoc_personaje_skill
        public ActionResult Index()
        {
            //ViewBag.id_personaje = new SelectList(db.personajes, "id", "nombre");
            var asoc_personaje_skill = db.asoc_personaje_skill.Include(a => a.personajes).Include(a => a.skill);
            //return View(asoc_personaje_skill.ToList());
            asoc_personaje_skill_filtro modelo = new asoc_personaje_skill_filtro();
            modelo.id_personaje = new SelectList(db.personajes, "id", "nombre");
            modelo.lista = asoc_personaje_skill.ToList();
            return View(modelo);
        }

        // GET: asoc_personaje_skill/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            asoc_personaje_skill asoc_personaje_skill = db.asoc_personaje_skill.Find(id);
            if (asoc_personaje_skill == null)
            {
                return HttpNotFound();
            }
            return View(asoc_personaje_skill);
        }

        // GET: asoc_personaje_skill/Create
        public ActionResult Create()
        {
            asoc_personaje_skill_filtro_create modelo = new asoc_personaje_skill_filtro_create();
            modelo.id_personaje = new SelectList(db.personajes, "id", "nombre");
            modelo.lista = db.get_skills_listado_resumido().ToList<get_skills_listado_resumido_Result>();

            modelo.skill_nivel = new SelectList(
                new List<SelectListItem>{
                    new SelectListItem { Selected = true, Text = "todos", Value = "0"},
                    new SelectListItem { Selected = false, Text = "1", Value = "1"},
                    new SelectListItem { Selected = false, Text = "2", Value = "2"},
                    new SelectListItem { Selected = false, Text = "3", Value = "3"},
                    new SelectListItem { Selected = false, Text = "4", Value = "4"},
                    new SelectListItem { Selected = false, Text = "5", Value = "5"},
                }, "Value", "Text", 0);
            modelo.skill_tipo = new SelectList(
                new List<SelectListItem>{
                    new SelectListItem { Selected = true, Text = "todos", Value = "0"},
                    new SelectListItem { Selected = false, Text = "Pasiva", Value = "pasiva"},
                    new SelectListItem { Selected = false, Text = "Activa", Value = "activa"},
                }, "Value", "Text", 0);
            modelo.skill_alineamiento = new SelectList(
                new List<SelectListItem>{
                    new SelectListItem { Selected = true, Text = "todos", Value = "0"},
                    new SelectListItem { Selected = false, Text = "agua", Value = "agua"},
                    new SelectListItem { Selected = false, Text = "aire", Value = "aire"},
                    new SelectListItem { Selected = false, Text = "fuego", Value = "fuego"},
                    new SelectListItem { Selected = false, Text = "Luz", Value = "luz"},
                    new SelectListItem { Selected = false, Text = "Neutro", Value = "neutro"},
                    new SelectListItem { Selected = false, Text = "Oscuridad", Value = "oscuridad"},
                    new SelectListItem { Selected = false, Text = "tierra", Value = "tierra"},
                }, "Value", "Text", 0);
            modelo.usos = 0;


            return View(modelo);
        }


        [HttpPost]
        public void Asignar(crear_asignacion_skill skill_asignado)
        {
            db.crear_asignacion_skill(skill_asignado.id_personaje,skill_asignado.id_skill);
            db.SaveChanges();
        }

        // POST: asoc_personaje_skill/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_asoc,id_personaje,id_skill,usos")] asoc_personaje_skill asoc_personaje_skill)
        {
            if (ModelState.IsValid)
            {
                db.asoc_personaje_skill.Add(asoc_personaje_skill);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_personaje = new SelectList(db.personajes, "id", "nombre", asoc_personaje_skill.id_personaje);
            ViewBag.id_skill = new SelectList(db.skill, "id_skill", "skill_nombre", asoc_personaje_skill.id_skill);
            return View(asoc_personaje_skill);
        }

        // GET: asoc_personaje_skill/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            asoc_personaje_skill asoc_personaje_skill = db.asoc_personaje_skill.Find(id);
            if (asoc_personaje_skill == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_personaje = new SelectList(db.personajes, "id", "nombre", asoc_personaje_skill.id_personaje);
            ViewBag.id_skill = new SelectList(db.skill, "id_skill", "skill_nombre", asoc_personaje_skill.id_skill);
            return View(asoc_personaje_skill);
        }

        // POST: asoc_personaje_skill/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_asoc,id_personaje,id_skill,usos")] asoc_personaje_skill asoc_personaje_skill)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asoc_personaje_skill).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_personaje = new SelectList(db.personajes, "id", "nombre", asoc_personaje_skill.id_personaje);
            ViewBag.id_skill = new SelectList(db.skill, "id_skill", "skill_nombre", asoc_personaje_skill.id_skill);
            return View(asoc_personaje_skill);
        }

        // GET: asoc_personaje_skill/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            asoc_personaje_skill asoc_personaje_skill = db.asoc_personaje_skill.Find(id);
            if (asoc_personaje_skill == null)
            {
                return HttpNotFound();
            }
            return View(asoc_personaje_skill);
        }

        // POST: asoc_personaje_skill/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            asoc_personaje_skill asoc_personaje_skill = db.asoc_personaje_skill.Find(id);
            db.asoc_personaje_skill.Remove(asoc_personaje_skill);
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
