using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Roll.Models
{
    public class estadisticas_del_pj_calculadora_model
    {
        public int id_pj { get; set; }
        public Nullable<int> pj_agi { get; set; }
        public Nullable<int> pj_vel { get; set; }
        public Nullable<double> danio { get; set; }
    }
}