using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Roll.Models
{
    public class crear_asignacion_item
    {
        public int id_personaje { get; set; }
        public int id_item { get; set; }
        public int cantidad { get; set; }
        public bool equipado { get; set; }

    }
}