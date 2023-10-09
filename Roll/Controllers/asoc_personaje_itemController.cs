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
    public class asoc_personaje_itemController : Controller
    {
        private RollEntities db = new RollEntities();

        // GET: asoc_personaje_item
        public ActionResult Index()
        {
            var asoc_personaje_item = db.asoc_personaje_item.Include(a => a.items).Include(a => a.personajes);
            asoc_personaje_item_filtro modelo = new asoc_personaje_item_filtro();
            modelo.id_personaje = new SelectList(db.personajes, "id", "nombre");

            //return View(asoc_personaje_item.ToList());
            modelo.lista = asoc_personaje_item.ToList();
            return View(modelo);
        }

        // GET: asoc_personaje_item/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            asoc_personaje_item asoc_personaje_item = db.asoc_personaje_item.Find(id);
            if (asoc_personaje_item == null)
            {
                return HttpNotFound();
            }
            return View(asoc_personaje_item);
        }

        // GET: asoc_personaje_item/Create
        public ActionResult Create()
        {
            asoc_personaje_item_filtro_create modelo = new asoc_personaje_item_filtro_create();
            modelo.id_personaje = new SelectList(db.personajes, "id", "nombre");
            modelo.lista = db.items.ToList<items>();

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
                }, "Value", "Text", 0);
            
            modelo.tipo = new SelectList(
                new List<SelectListItem>{
                    new SelectListItem { Selected = true, Text = "todos", Value = "0"},
                    new SelectListItem { Selected = false, Text = "", Value = "vacio"},
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
                }, "Value", "Text", 0);

            return View(modelo);
        }

        [HttpPost]
        public void Asignar(crear_asignacion_item item_asignado)
        {
            db.crear_asignacion_item(item_asignado.id_personaje, item_asignado.id_item, item_asignado.cantidad, item_asignado.equipado);
            db.SaveChanges();
        }

        // POST: asoc_personaje_item/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_asoc,id_personaje,id_item,cantidad,equipado")] asoc_personaje_item asoc_personaje_item)
        {
            if (ModelState.IsValid)
            {
                db.asoc_personaje_item.Add(asoc_personaje_item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_item = new SelectList(db.items, "id_item", "item_nombre", asoc_personaje_item.id_item);
            ViewBag.id_personaje = new SelectList(db.personajes, "id", "nombre", asoc_personaje_item.id_personaje);
            return View(asoc_personaje_item);
        }

        // GET: asoc_personaje_item/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            asoc_personaje_item asoc_personaje_item = db.asoc_personaje_item.Find(id);
            if (asoc_personaje_item == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_item = new SelectList(db.items, "id_item", "item_nombre", asoc_personaje_item.id_item);
            ViewBag.id_personaje = new SelectList(db.personajes, "id", "nombre", asoc_personaje_item.id_personaje);
            return View(asoc_personaje_item);
        }

        // POST: asoc_personaje_item/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_asoc,id_personaje,id_item,cantidad,equipado")] asoc_personaje_item asoc_personaje_item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asoc_personaje_item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_item = new SelectList(db.items, "id_item", "item_nombre", asoc_personaje_item.id_item);
            ViewBag.id_personaje = new SelectList(db.personajes, "id", "nombre", asoc_personaje_item.id_personaje);
            return View(asoc_personaje_item);
        }

        // GET: asoc_personaje_item/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            asoc_personaje_item asoc_personaje_item = db.asoc_personaje_item.Find(id);
            if (asoc_personaje_item == null)
            {
                return HttpNotFound();
            }
            return View(asoc_personaje_item);
        }

        // POST: asoc_personaje_item/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            asoc_personaje_item asoc_personaje_item = db.asoc_personaje_item.Find(id);
            db.asoc_personaje_item.Remove(asoc_personaje_item);
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
