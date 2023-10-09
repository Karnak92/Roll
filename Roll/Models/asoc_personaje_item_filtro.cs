using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Roll.Models
{
    public class asoc_personaje_item_filtro
    {
        public List<asoc_personaje_item> lista { get; set; }
        public SelectList id_personaje { get; set; }

    }
}