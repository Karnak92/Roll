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
    public class encuentrosController : Controller
    {
        // GET: encuentros
        private RollEntities db = new RollEntities();
        public ActionResult Index()
        {
            encuentro_modelo encuentro = new encuentro_modelo();
            encuentro.listado_filtro = db.monstruos.ToList();
            encuentro.tier = new SelectList(
                new List<SelectListItem>{
                    new SelectListItem { Selected = true, Text = "todos", Value = "0"},
                    new SelectListItem { Selected = false, Text = "1", Value = "1"},
                    new SelectListItem { Selected = false, Text = "2", Value = "2"},
                    new SelectListItem { Selected = false, Text = "3", Value = "3"},
                    new SelectListItem { Selected = false, Text = "4", Value = "4"},
                    }, "Value", "Text", 0);
            encuentro.listado_party = db.party.ToList();
            encuentro.listado_party_mon = db.party_mon.ToList();

            return View(encuentro);
        }

        // GET: encuentros/Details/5
        public ActionResult Details_mon(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            party_mon party_Mon = db.party_mon.Find(id);
            party_mon_calculadora modelo = new party_mon_calculadora();
            
            if (party_Mon == null)
            {
                return HttpNotFound();
            }
            modelo.monstruo = party_Mon;
            modelo.id_personaje = new SelectList(db.select_pj(1), "id_personaje", "nombre_personaje");
            return View(modelo);
        }
        public ActionResult Details_pj(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            get_numeros_pj_calculadora_Result modelo = db.get_numeros_pj_calculadora(id).FirstOrDefault();

            if (modelo == null)
            {
                return HttpNotFound();
            }
            
            return View(modelo);
        }

        // GET: encuentros/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public ActionResult  get_atributos_calculadora(int id_pj)
        {
            get_atributos_calculadora_Result result = db.get_atributos_calculadora(id_pj).ToList()[0];
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // POST: encuentros/Create
        [HttpPost]
        public void impactar_danio_a_mon(impactar_danio_a_mon_model danio_a_mon)
        {
            db.impactar_danio_a_mon(danio_a_mon.id_party_mon_id, danio_a_mon.es_skill, danio_a_mon.tipo_danio, danio_a_mon.agi_pj, danio_a_mon.vel_pj, danio_a_mon.danio_pj_basico, danio_a_mon.dado_prec, danio_a_mon.danio_skill, danio_a_mon.es_magico);
            db.SaveChanges();
        }
        
        [HttpPost]
        public void impactar_danio_a_pj(impactar_danio_a_pj_model danio_a_mon)
        {
            db.impactar_danio_a_pj(danio_a_mon.id_pj, danio_a_mon.es_skill, danio_a_mon.tipo_danio, danio_a_mon.tier, danio_a_mon.vel_mon, danio_a_mon.danio_mon_basico, danio_a_mon.dado_prec, danio_a_mon.danio_skill, danio_a_mon.es_magico);
            db.SaveChanges();
        }
        
        [HttpPost]
        public void agregar_a_party_mon(int id_mon)
        {
            db.agregar_a_la_party_mon(1,id_mon,1);
            db.SaveChanges();
        }
        
        [HttpPost]
        public void eliminar_de_party_mon(int id_mon)
        {
            db.eliminar_miembro_party_mon(id_mon);
            db.SaveChanges();
        }
        
        [HttpPost]
        public void descontar_mana(descontar_mana_mon_model descontar_mana_mon_model)
        {
            db.descontar_mana_mon(descontar_mana_mon_model.id_party_mon_id, descontar_mana_mon_model.mana);
            db.SaveChanges();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: encuentros/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: encuentros/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: encuentros/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: encuentros/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
