using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Roll.Models
{
    public class clases_skills_sugeridas
    {
        public clases clase { get; set; }
        public List<sugerir_activas_Result> sugerencia_activas { get; set; }
        public List<sugerir_pasivas_Result> sugerencia_pasivas { get; set; }
        

    }
}