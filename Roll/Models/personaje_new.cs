using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Roll.Models
{
    public class personaje_new
    {
        public personajes personaje { get; set; }
        public List<get_skills_Result> lista_skills { get; set; }
        public List<get_mascotas_Result> lista_pets { get; set; }
        public List<get_items_Result> lista_armas { get; set; }
        public List<get_items_Result> lista_cascos { get; set; }
        public List<get_items_Result> lista_pecheras { get; set; }
        public List<get_items_Result> lista_botas { get; set; }
        public List<get_items_Result> lista_guantes { get; set; }
        public List<get_items_Result> lista_escudos { get; set; }
        public List<get_items_Result> lista_varios { get; set; }
        public get_peso_mochila_Result peso_mochila { get; set; }
        public get_peso_total_Result peso_total { get; set; }
        public SelectList listado_transferencias { get; set; }
        public int? stats { get; set; }

    }
}