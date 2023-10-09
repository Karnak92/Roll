using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Roll.Models
{
    public class skill_list_resumido
    {
        public int id_skill { get; set; }
        public string skill_nombre { get; set; }
        public int skill_nivel { get; set; }
        public string skill_tipo { get; set; }
        public string skill_alineamiento { get; set; }

    }
}