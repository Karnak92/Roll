using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Roll.Models
{
    public class asoc_personaje_skill_filtro_create
    {
        public List<get_skills_listado_resumido_Result> lista { get; set; }
        public SelectList id_personaje { get; set; }
        public SelectList skill_nivel { get; set; }
        public SelectList skill_tipo { get; set; }
        public SelectList skill_alineamiento { get; set; }
        public int usos { get; set; }

    }
}