using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Roll;

namespace Roll.Models
{
    public class encuentro_modelo
    {
        public List<monstruos> listado_filtro { get; set; }
        public List<party> listado_party { get; set; }
        public List<party_mon> listado_party_mon { get; set; }
        public SelectList tier { get; set; }
        

    }
}