using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Roll.Models
{
    public class skill_listado
    {
        public string nombre { get; set; }
        public string tipo { get; set; }
        public string costo { get; set; }
        public string efecto { get; set; }
        public string danio { get; set; }
        public string requisito { get; set; }
        public int usos { get; set; }

    }
}