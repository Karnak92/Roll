using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Roll.Models
{
    public class item_listado
    {
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string bono { get; set; }
        public int cantidad { get; set; }
        public bool equipado { get; set; }

    }
}