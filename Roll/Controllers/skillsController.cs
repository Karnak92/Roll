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
    public class skillsController : Controller
    {
        private RollEntities db = new RollEntities();

        // GET: skills
        public ActionResult Index()
        {
            skill_list_completo modelo = new skill_list_completo();
            modelo.lista = db.skill.ToList();
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
                    new SelectListItem { Selected = false, Text = "hielo", Value = "hielo"},
                    new SelectListItem { Selected = false, Text = "luz", Value = "luz"},
                    new SelectListItem { Selected = false, Text = "metal/lava", Value = "metal/lava"},
                    new SelectListItem { Selected = false, Text = "naturaleza", Value = "naturaleza"},
                    new SelectListItem { Selected = false, Text = "neutro", Value = "neutro"},
                    new SelectListItem { Selected = false, Text = "oscuridad", Value = "oscuridad"},
                    new SelectListItem { Selected = false, Text = "tierra", Value = "tierra"},
                    new SelectListItem { Selected = false, Text = "rayo", Value = "rayo"},
                }, "Value", "Text", 0);
            return View(modelo);
        }

        // GET: skills/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            skill skill = db.skill.Find(id);
            if (skill == null)
            {
                return HttpNotFound();
            }
            return View(skill);
        }

        // GET: skills/Create
        public ActionResult Create()
        {
            skill_abm modelo = new skill_abm();
            modelo.skill_nivel = new SelectList(
               new List<SelectListItem>{
                    new SelectListItem { Selected = true, Text = "1", Value = "1"},
                    new SelectListItem { Selected = false, Text = "2", Value = "2"},
                    new SelectListItem { Selected = false, Text = "3", Value = "3"},
                    new SelectListItem { Selected = false, Text = "4", Value = "4"},
                    new SelectListItem { Selected = false, Text = "5", Value = "5"},
               }, "Value", "Text", "1");
            modelo.skill_tipo = new SelectList(
                new List<SelectListItem>{
                    new SelectListItem { Selected = true, Text = "Pasiva", Value = "pasiva"},
                    new SelectListItem { Selected = false, Text = "Activa", Value = "activa"},
                }, "Value", "Text", "pasiva");
            modelo.skill_atributo = new SelectList(
                new List<SelectListItem>{
                    new SelectListItem { Selected = true, Text = "agua", Value = "agua"},
                    new SelectListItem { Selected = false, Text = "aire", Value = "aire"},
                    new SelectListItem { Selected = false, Text = "fuego", Value = "fuego"},
                    new SelectListItem { Selected = false, Text = "hielo", Value = "hielo"},
                    new SelectListItem { Selected = false, Text = "luz", Value = "luz"},
                    new SelectListItem { Selected = false, Text = "metal/lava", Value = "metal/lava"},
                    new SelectListItem { Selected = false, Text = "naturaleza", Value = "naturaleza"},
                    new SelectListItem { Selected = false, Text = "neutro", Value = "neutro"},
                    new SelectListItem { Selected = false, Text = "oscuridad", Value = "oscuridad"},
                    new SelectListItem { Selected = false, Text = "tierra", Value = "tierra"},
                    new SelectListItem { Selected = false, Text = "rayo", Value = "rayo"},
                }, "Value", "Text", "agua");
            return View(modelo);
        }

        // POST: skills/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_skill,skill_nombre,skill_nivel,skill_tipo,skill_atributo,skill_costo,skill_tipo_efecto,skill_danio,skill_dado_basico,skill_requisito")] skill skill)
        {
            if ((skill.skill_atributo == "agua") || (skill.skill_atributo == "aire") || (skill.skill_atributo == "fuego") || (skill.skill_atributo == "luz") || (skill.skill_atributo == "neutro") || (skill.skill_atributo == "oscuridad") || (skill.skill_atributo == "tierra"))
            {
                skill.skill_alineamiento = skill.skill_atributo;
            }
            if (skill.skill_atributo == "hielo")
            {
                skill.skill_alineamiento = "agua";
            }
            if (skill.skill_atributo == "metal/lava")
            {
                skill.skill_alineamiento = "fuego";
            }
            if (skill.skill_atributo == "naturaleza")
            {
                skill.skill_alineamiento = "tierra";
            }
            if (skill.skill_atributo == "rayo")
            {
                skill.skill_alineamiento = "aire";
            }

            if (ModelState.IsValid)
            {
                db.skill.Add(skill);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(skill);
        }

        // GET: skills/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            skill skill = db.skill.Find(id);
            if (skill == null)
            {
                return HttpNotFound();
            }

            skill_abm modelo = new skill_abm();
            modelo.skill = skill;
            modelo.skill_nivel = new SelectList(
               new List<SelectListItem>{
                    new SelectListItem { Selected = true, Text = "1", Value = "1"},
                    new SelectListItem { Selected = false, Text = "2", Value = "2"},
                    new SelectListItem { Selected = false, Text = "3", Value = "3"},
                    new SelectListItem { Selected = false, Text = "4", Value = "4"},
                    new SelectListItem { Selected = false, Text = "5", Value = "5"},
               }, "Value", "Text", skill.skill_nivel);
            modelo.skill_tipo = new SelectList(
                new List<SelectListItem>{
                    new SelectListItem { Selected = true, Text = "Pasiva", Value = "pasiva"},
                    new SelectListItem { Selected = false, Text = "Activa", Value = "activa"},
                }, "Value", "Text", skill.skill_tipo);
            modelo.skill_atributo = new SelectList(
                new List<SelectListItem>{
                    new SelectListItem { Selected = true, Text = "agua", Value = "agua"},
                    new SelectListItem { Selected = false, Text = "aire", Value = "aire"},
                    new SelectListItem { Selected = false, Text = "fuego", Value = "fuego"},
                    new SelectListItem { Selected = false, Text = "hielo", Value = "hielo"},
                    new SelectListItem { Selected = false, Text = "luz", Value = "luz"},
                    new SelectListItem { Selected = false, Text = "metal/lava", Value = "metal/lava"},
                    new SelectListItem { Selected = false, Text = "naturaleza", Value = "naturaleza"},
                    new SelectListItem { Selected = false, Text = "neutro", Value = "neutro"},
                    new SelectListItem { Selected = false, Text = "oscuridad", Value = "oscuridad"},
                    new SelectListItem { Selected = false, Text = "tierra", Value = "tierra"},
                    new SelectListItem { Selected = false, Text = "rayo", Value = "rayo"},
                }, "Value", "Text", skill.skill_atributo);
            modelo.skill_alineamiento = new SelectList(
                new List<SelectListItem>{
                    new SelectListItem { Selected = true, Text = "agua", Value = "agua"},
                    new SelectListItem { Selected = false, Text = "aire", Value = "aire"},
                    new SelectListItem { Selected = false, Text = "fuego", Value = "fuego"},
                    new SelectListItem { Selected = false, Text = "luz", Value = "luz"},
                    new SelectListItem { Selected = false, Text = "neutro", Value = "neutro"},
                    new SelectListItem { Selected = false, Text = "oscuridad", Value = "oscuridad"},
                    new SelectListItem { Selected = false, Text = "tierra", Value = "tierra"},
                }, "Value", "Text", skill.skill_alineamiento);


            return View(modelo);
        }

        // POST: skills/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_skill,skill_nombre,skill_nivel,skill_tipo,skill_atributo,skill_costo,skill_tipo_efecto,skill_danio,skill_dado_basico,skill_requisito,skill_alineamiento")] skill skill)
        {
            if (ModelState.IsValid)
            {
                db.Entry(skill).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(skill);
        }

        // GET: skills/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            skill skill = db.skill.Find(id);
            if (skill == null)
            {
                return HttpNotFound();
            }
            return View(skill);
        }

        // POST: skills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            skill skill = db.skill.Find(id);
            db.skill.Remove(skill);
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
