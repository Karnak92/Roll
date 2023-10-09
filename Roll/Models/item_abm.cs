using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Roll.Models
{
    public class item_abm
    {
        public items item { get; set; }
        public SelectList categoria { get; set; }
        public SelectList clasificacion { get; set; }
        public SelectList tipo { get; set; }

    }
}