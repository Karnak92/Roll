using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Roll.Models
{
    public class asoc_personaje_item_filtro_create
    {
        public List<items> lista { get; set; }
        public SelectList id_personaje { get; set; }
        public SelectList categoria { get; set; }
        public SelectList clasificacion { get; set; }
        public SelectList tipo { get; set; }
        public int cantidad { get; set; }
        public bool equipado { get; set; }
        
    }
}