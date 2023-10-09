using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Roll.Models
{
    public class impactar_danio_a_mon_model
    {
        public int id_party_mon_id { get; set; }
        public bool es_skill { get; set; }
        public int tipo_danio { get; set; }
        public int agi_pj { get; set; }
        public int vel_pj { get; set; }
        public int danio_pj_basico { get; set; }
        public int dado_prec { get; set; }
        public int danio_skill { get; set; }
        public bool es_magico { get; set; }
    }
    
    public class impactar_danio_a_pj_model
    {
        public int id_pj { get; set; }
        public bool es_skill { get; set; }
        public int tipo_danio { get; set; }
        public int tier { get; set; }
        public int vel_mon { get; set; }
        public int danio_mon_basico { get; set; }
        public int dado_prec { get; set; }
        public int danio_skill { get; set; }
        public bool es_magico { get; set; }
    }

}