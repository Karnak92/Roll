using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Roll.Models
{
    public class skill_list_completo
    {
        public List<skill> lista { get; set; }
        public SelectList skill_nivel { get; set; }
        public SelectList skill_tipo { get; set; }
        public SelectList skill_alineamiento { get; set; }

    }
}