//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Roll
{
    using System;
    using System.Collections.Generic;
    
    public partial class leveleo
    {
        public int id { get; set; }
        public Nullable<int> id_personaje { get; set; }
        public Nullable<int> puntos_disponibles { get; set; }
    
        public virtual personajes personajes { get; set; }
    }
}
