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
    public class personajesController : Controller
    {
        private RollEntities db = new RollEntities();

        // GET: personajes
        public ActionResult Index()
        {
            var personajes = db.personajes.Include(p => p.atributo1).Include(p => p.clases).Include(p => p.estado1).Include(p => p.razas);
            return View(personajes.ToList());
        }

        // GET: personajes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            personajes personajes = db.personajes.Find(id);
            List<get_skills_Result> lista_skills = db.get_skills(id).ToList<get_skills_Result>();
            List<get_mascotas_Result> lista_pets = db.get_mascotas(id).ToList<get_mascotas_Result>();
            string tipo = "arma";
            List<get_items_Result> lista_armas = db.get_items(id, tipo).ToList<get_items_Result>();
            tipo = "cascos";
            List<get_items_Result> lista_cascos = db.get_items(id, tipo).ToList<get_items_Result>();
            tipo = "pecheras";
            List<get_items_Result> lista_pecheras = db.get_items(id, tipo).ToList<get_items_Result>();
            tipo = "botas";
            List<get_items_Result> lista_botas = db.get_items(id, tipo).ToList<get_items_Result>();
            tipo = "guantes";
            List<get_items_Result> lista_guantes = db.get_items(id, tipo).ToList<get_items_Result>();
            tipo = "escudos";
            List<get_items_Result> lista_escudos = db.get_items(id, tipo).ToList<get_items_Result>();
            tipo = "varios";
            List<get_items_Result> lista_varios = db.get_items(id, tipo).ToList<get_items_Result>();
            get_peso_mochila_Result peso_mochila = db.get_peso_mochila(id).FirstOrDefault();
            get_peso_total_Result peso_total = db.get_peso_total(id).FirstOrDefault();

            
            SelectList jugadores_Con_Monedero = new SelectList(db.jugadores_con_monedero(id), "id", "nombre");

            int? stats = db.get_lvl_up(id).FirstOrDefault();


            personaje_new personaje_modelo = new personaje_new();
            personaje_modelo.personaje = personajes;
            personaje_modelo.lista_skills = lista_skills;
            personaje_modelo.lista_armas = lista_armas;
            personaje_modelo.lista_cascos = lista_cascos;
            personaje_modelo.lista_pecheras = lista_pecheras;
            personaje_modelo.lista_botas = lista_botas;
            personaje_modelo.lista_guantes = lista_guantes;
            personaje_modelo.lista_escudos = lista_escudos;
            personaje_modelo.lista_varios = lista_varios;
            personaje_modelo.peso_mochila = peso_mochila;
            personaje_modelo.peso_total = peso_total;
            personaje_modelo.stats = stats;
            personaje_modelo.listado_transferencias = jugadores_Con_Monedero;
            personaje_modelo.lista_pets = lista_pets;

            if (personajes == null)
            {
                return HttpNotFound();
            }
            return View(personaje_modelo);
        }

        [HttpPost]
        public void LevelUp(level_up levelUp)
        {
            db.lvl_up(levelUp.id,levelUp.fuerza,levelUp.inteligencia,levelUp.sabiduria,levelUp.agilidad,levelUp.resistencia,levelUp.velocidad);
            db.SaveChanges();
        }
        
        [HttpPost]
        public void BuffUp(level_up levelUp)
        {
            db.buff_up(levelUp.id,levelUp.fuerza,levelUp.inteligencia,levelUp.sabiduria,levelUp.agilidad,levelUp.resistencia,levelUp.velocidad);
            db.SaveChanges();
        }
        
        [HttpPost]
        public void equip_un(id_item_asoc itemAsoc)
        {
            db.equip_un(itemAsoc.id_asoc);
            db.SaveChanges();
        }
        
        [HttpPost]
        public void equip_un_mochila(int id_pj)
        {
            db.equip_un_mochila(id_pj);
            db.SaveChanges();
        }
        
        [HttpPost]
        public void recibir_dinero(int id_pj,int oro, int plata, int cobre)
        {
            db.economia(id_pj,"gana",oro,plata,cobre);
            db.SaveChanges();
        }
        
        [HttpPost]
        public void dar_dinero(int id_pj,int oro, int plata, int cobre)
        {
            db.economia(id_pj,"pierde",oro,plata,cobre);
            db.SaveChanges();
        }
        
        [HttpPost]
        public void SkillUse(id_skill_asoc skillUp)
        {
            db.skill_up_use(skillUp.id);
            db.SaveChanges();
        }

        // GET: personajes/Create
        public ActionResult Create()
        {
            ViewBag.atributo = new SelectList(db.atributo, "id_atributo", "atributo_nombre");
            ViewBag.clase = new SelectList(db.clases, "id_clase", "clas_nombre");
            ViewBag.estado = new SelectList(db.estado, "id_estado", "est_nombre");
            ViewBag.raza = new SelectList(db.razas, "id_raza", "raza_nombre");
            return View();
        }

        // POST: personajes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,nivel,raza,clase,atributo,vida_real,energia_real,atk,mag_atk,armor,mr,oro,plata,cobre,vida_actual,energia_actual,fuerza_inicial,fuerza_real,fuerza_actual,intel_ini,intel_real,intel_actual,sab_ini,sab_real,sab_actual,agi_ini,agi_real,agi_actual,res_ini,res_real,res_actual,velocidad_ini,velocidad_real,velocidad_actual,estado,habilitado")] personajes personajes)
        {
            if (ModelState.IsValid)
            {
                db.personajes.Add(personajes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.atributo = new SelectList(db.atributo, "id_atributo", "atributo_nombre", personajes.atributo);
            ViewBag.clase = new SelectList(db.clases, "id_clase", "clas_nombre", personajes.clase);
            ViewBag.estado = new SelectList(db.estado, "id_estado", "est_nombre", personajes.estado);
            ViewBag.raza = new SelectList(db.razas, "id_raza", "raza_nombre", personajes.raza);
            return View(personajes);
        }

        // GET: personajes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            personajes personajes = db.personajes.Find(id);
            if (personajes == null)
            {
                return HttpNotFound();
            }
            ViewBag.atributo = new SelectList(db.atributo, "id_atributo", "atributo_nombre", personajes.atributo);
            ViewBag.clase = new SelectList(db.clases, "id_clase", "clas_nombre", personajes.clase);
            ViewBag.estado = new SelectList(db.estado, "id_estado", "est_nombre", personajes.estado);
            ViewBag.raza = new SelectList(db.razas, "id_raza", "raza_nombre", personajes.raza);
            return View(personajes);
        }

        // POST: personajes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,nivel,raza,clase,atributo,vida_real,energia_real,atk,mag_atk,armor,mr,oro,plata,cobre,vida_actual,energia_actual,fuerza_inicial,fuerza_real,fuerza_actual,intel_ini,intel_real,intel_actual,sab_ini,sab_real,sab_actual,agi_ini,agi_real,agi_actual,res_ini,res_real,res_actual,velocidad_ini,velocidad_real,velocidad_actual,estado,habilitado,imagen")] personajes personajes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personajes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.atributo = new SelectList(db.atributo, "id_atributo", "atributo_nombre", personajes.atributo);
            ViewBag.clase = new SelectList(db.clases, "id_clase", "clas_nombre", personajes.clase);
            ViewBag.estado = new SelectList(db.estado, "id_estado", "est_nombre", personajes.estado);
            ViewBag.raza = new SelectList(db.razas, "id_raza", "raza_nombre", personajes.raza);
            return View(personajes);
        }

        // GET: personajes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            personajes personajes = db.personajes.Find(id);
            if (personajes == null)
            {
                return HttpNotFound();
            }
            return View(personajes);
        }

        // POST: personajes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            personajes personajes = db.personajes.Find(id);
            db.personajes.Remove(personajes);
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
