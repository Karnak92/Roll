using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Roll.Models
{
    public class skill_abm
    {
        public skill skill { get; set; }
        public SelectList skill_nivel { get; set; }
        public SelectList skill_tipo { get; set; }
        public SelectList skill_atributo { get; set; }
        public SelectList skill_alineamiento { get; set; }

    }
}