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
    public class itemsController : Controller
    {
        private RollEntities db = new RollEntities();

        // GET: items
        public ActionResult Index()
        {
            item_list_completo modelo = new item_list_completo();
            modelo.lista = db.items.OrderBy(o => o.item_tier).ToList();
            modelo.categoria = new SelectList(
                new List<SelectListItem>{
                    new SelectListItem { Selected = true, Text = "todos", Value = "0"},
                    new SelectListItem { Selected = false, Text = "arma", Value = "arma"},
                    new SelectListItem { Selected = false, Text = "varios", Value = "items_varios"},
                    new SelectListItem { Selected = false, Text = "mapas", Value = "mapas"},
                    new SelectListItem { Selected = false, Text = "armadura", Value = "armadura"},
                }, "Value", "Text", 0);

            modelo.clasificacion = new SelectList(
                new List<SelectListItem>{
                    new SelectListItem { Selected = true, Text = "todos", Value = "0"},
                    new SelectListItem { Selected = false, Text = "2_manos", Value = "2_manos"},
                    new SelectListItem { Selected = false, Text = "1_mano", Value = "1_mano"},
                    new SelectListItem { Selected = false, Text = "botas", Value = "botas"},
                    new SelectListItem { Selected = false, Text = "cascos", Value = "cascos"},
                    new SelectListItem { Selected = false, Text = "escudos", Value = "escudos"},
                    new SelectListItem { Selected = false, Text = "guantes", Value = "guantes"},
                    new SelectListItem { Selected = false, Text = "pecheras", Value = "pecheras"},
                    new SelectListItem { Selected = false, Text = "varios", Value = "varios"},
                }, "Value", "Text", 0);

            modelo.tipo = new SelectList(
                new List<SelectListItem>{
                    new SelectListItem { Selected = true, Text = "todos", Value = "0"},
                    new SelectListItem { Selected = false, Text = "varios", Value = "varios"},
                    new SelectListItem { Selected = false, Text = "de asta", Value = "alabardas"},
                    new SelectListItem { Selected = false, Text = "bastones", Value = "bastones"},
                    new SelectListItem { Selected = false, Text = "cuchillos", Value = "cuchillos"},
                    new SelectListItem { Selected = false, Text = "distancia", Value = "distancia"},
                    new SelectListItem { Selected = false, Text = "espadas", Value = "espadas"},
                    new SelectListItem { Selected = false, Text = "hachas", Value = "hachas"},
                    new SelectListItem { Selected = false, Text = "lanzas", Value = "lanzas"},
                    new SelectListItem { Selected = false, Text = "latigos", Value = "latigos"},
                    new SelectListItem { Selected = false, Text = "mazas", Value = "mazas"},
                    new SelectListItem { Selected = false, Text = "varas", Value = "varas"},
                }, "Value", "Text", 0);
            
            modelo.tier = new SelectList(
                new List<SelectListItem>{
                    new SelectListItem { Selected = true, Text = "todos", Value = "0"},
                    new SelectListItem { Selected = false, Text = "1", Value = "1"},
                    new SelectListItem { Selected = false, Text = "2", Value = "2"},
                    new SelectListItem { Selected = false, Text = "3", Value = "3"},
                    new SelectListItem { Selected = false, Text = "4", Value = "4"},
                    new SelectListItem { Selected = false, Text = "5", Value = "5"},
                    new SelectListItem { Selected = false, Text = "6", Value = "6"},
                    new SelectListItem { Selected = false, Text = "7", Value = "7"},
                    new SelectListItem { Selected = false, Text = "8", Value = "8"},
                    new SelectListItem { Selected = false, Text = "9", Value = "9"},
                    new SelectListItem { Selected = false, Text = "10", Value = "10"},
                    new SelectListItem { Selected = false, Text = "11", Value = "11"},
                    new SelectListItem { Selected = false, Text = "12", Value = "12"},
                    
                }, "Value", "Text", 0);

            return View(modelo);
        }

        // GET: items/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            items items = db.items.Find(id);
            if (items == null)
            {
                return HttpNotFound();
            }
            return View(items);
        }

        // GET: items/Create
        public ActionResult Create()
        {
            item_abm modelo = new item_abm();
            
            modelo.categoria = new SelectList(
                new List<SelectListItem>{
                    new SelectListItem { Selected = false, Text = "arma", Value = "arma"},
                    new SelectListItem { Selected = true, Text = "varios", Value = "items_varios"},
                    new SelectListItem { Selected = false, Text = "mapas", Value = "mapas"},
                    new SelectListItem { Selected = false, Text = "armadura", Value = "armadura"},
                }, "Value", "Text", "items_varios");

            modelo.clasificacion = new SelectList(
                new List<SelectListItem>{
                    new SelectListItem { Selected = false, Text = "2_manos", Value = "2_manos"},
                    new SelectListItem { Selected = false, Text = "1_mano", Value = "1_mano"},
                    new SelectListItem { Selected = false, Text = "botas", Value = "botas"},
                    new SelectListItem { Selected = false, Text = "cascos", Value = "cascos"},
                    new SelectListItem { Selected = false, Text = "escudos", Value = "escudos"},
                    new SelectListItem { Selected = false, Text = "guantes", Value = "guantes"},
                    new SelectListItem { Selected = false, Text = "pecheras", Value = "pecheras"},
                    new SelectListItem { Selected = true, Text = "varios", Value = "varios"},
                }, "Value", "Text", "varios");

            modelo.tipo = new SelectList(
                new List<SelectListItem>{
                    new SelectListItem { Selected = true, Text = "varios", Value = "varios"},
                    new SelectListItem { Selected = false, Text = "alabardas", Value = "alabardas"},
                    new SelectListItem { Selected = false, Text = "bastones", Value = "bastones"},
                    new SelectListItem { Selected = false, Text = "cuchillos", Value = "cuchillos"},
                    new SelectListItem { Selected = false, Text = "distancia", Value = "distancia"},
                    new SelectListItem { Selected = false, Text = "espadas", Value = "espadas"},
                    new SelectListItem { Selected = false, Text = "hachas", Value = "hachas"},
                    new SelectListItem { Selected = false, Text = "lanzas", Value = "lanzas"},
                    new SelectListItem { Selected = false, Text = "latigos", Value = "latigos"},
                    new SelectListItem { Selected = false, Text = "mazas", Value = "mazas"},
                    new SelectListItem { Selected = false, Text = "varas", Value = "varas"},
                }, "Value", "Text", "varios");
            return View(modelo);
        }

        // POST: items/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_item,item_nombre,item_categoria,item_clasificacion,item_tipo,item_tier,item_descripcion,item_bonificacion,item_atk,item_mag_atk,item_def,item_mag_def,item_imagen_nombre,peso")] items items)
        {
            if (ModelState.IsValid)
            {
                db.items.Add(items);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(items);
        }

        // GET: items/Edit/5
        public ActionResult Edit(int? id)
        {
            item_abm modelo = new item_abm();

            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            items items = db.items.Find(id);

            if (items == null)
            {
                return HttpNotFound();
            }

            modelo.categoria = new SelectList(
                new List<SelectListItem>{
                    new SelectListItem { Selected = false, Text = "arma", Value = "arma"},
                    new SelectListItem { Selected = false, Text = "varios", Value = "items_varios"},
                    new SelectListItem { Selected = false, Text = "mapas", Value = "mapas"},
                    new SelectListItem { Selected = false, Text = "armadura", Value = "armadura"},
                }, "Value", "Text", items.item_categoria);

            modelo.clasificacion = new SelectList(
                new List<SelectListItem>{
                    new SelectListItem { Selected = false, Text = "2_manos", Value = "2_manos"},
                    new SelectListItem { Selected = false, Text = "1_mano", Value = "1_mano"},
                    new SelectListItem { Selected = false, Text = "botas", Value = "botas"},
                    new SelectListItem { Selected = false, Text = "cascos", Value = "cascos"},
                    new SelectListItem { Selected = false, Text = "escudos", Value = "escudos"},
                    new SelectListItem { Selected = false, Text = "guantes", Value = "guantes"},
                    new SelectListItem { Selected = false, Text = "pecheras", Value = "pecheras"},
                    new SelectListItem { Selected = false, Text = "varios", Value = "varios"},
                }, "Value", "Text", items.item_clasificacion);

            modelo.tipo = new SelectList(
                new List<SelectListItem>{
                    new SelectListItem { Selected = false, Text = "varios", Value = "varios"},
                    new SelectListItem { Selected = false, Text = "alabardas", Value = "alabardas"},
                    new SelectListItem { Selected = false, Text = "bastones", Value = "bastones"},
                    new SelectListItem { Selected = false, Text = "cuchillos", Value = "cuchillos"},
                    new SelectListItem { Selected = false, Text = "distancia", Value = "distancia"},
                    new SelectListItem { Selected = false, Text = "espadas", Value = "espadas"},
                    new SelectListItem { Selected = false, Text = "hachas", Value = "hachas"},
                    new SelectListItem { Selected = false, Text = "lanzas", Value = "lanzas"},
                    new SelectListItem { Selected = false, Text = "latigos", Value = "latigos"},
                    new SelectListItem { Selected = false, Text = "mazas", Value = "mazas"},
                    new SelectListItem { Selected = false, Text = "varas", Value = "varas"},
                }, "Value", "Text", items.item_tipo);
            modelo.item = items;
            return View(modelo);
        }

        // POST: items/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_item,item_nombre,item_categoria,item_clasificacion,item_tipo,item_tier,item_descripcion,item_bonificacion,item_atk,item_mag_atk,item_def,item_mag_def,item_imagen_nombre,peso")] items items)
        {
            if (ModelState.IsValid)
            {
                db.Entry(items).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(items);
        }

        // GET: items/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            items items = db.items.Find(id);
            if (items == null)
            {
                return HttpNotFound();
            }
            return View(items);
        }

        // POST: items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            items items = db.items.Find(id);
            db.items.Remove(items);
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
