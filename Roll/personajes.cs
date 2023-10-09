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
    
    public partial class personajes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public personajes()
        {
            this.asoc_personaje_item = new HashSet<asoc_personaje_item>();
            this.asoc_personaje_skill = new HashSet<asoc_personaje_skill>();
            this.leveleo = new HashSet<leveleo>();
            this.party = new HashSet<party>();
            this.asoc_personaje_mochila = new HashSet<asoc_personaje_mochila>();
            this.mascotas = new HashSet<mascotas>();
        }
    
        public int id { get; set; }
        public string nombre { get; set; }
        public Nullable<int> nivel { get; set; }
        public Nullable<int> raza { get; set; }
        public Nullable<int> clase { get; set; }
        public Nullable<int> atributo { get; set; }
        public Nullable<int> vida_real { get; set; }
        public Nullable<int> energia_real { get; set; }
        public Nullable<int> atk { get; set; }
        public Nullable<int> mag_atk { get; set; }
        public Nullable<int> armor { get; set; }
        public Nullable<int> mr { get; set; }
        public Nullable<int> oro { get; set; }
        public Nullable<int> plata { get; set; }
        public Nullable<int> cobre { get; set; }
        public Nullable<int> vida_actual { get; set; }
        public Nullable<int> energia_actual { get; set; }
        public Nullable<int> fuerza_inicial { get; set; }
        public Nullable<int> fuerza_real { get; set; }
        public Nullable<int> fuerza_actual { get; set; }
        public Nullable<int> intel_ini { get; set; }
        public Nullable<int> intel_real { get; set; }
        public Nullable<int> intel_actual { get; set; }
        public Nullable<int> sab_ini { get; set; }
        public Nullable<int> sab_real { get; set; }
        public Nullable<int> sab_actual { get; set; }
        public Nullable<int> agi_ini { get; set; }
        public Nullable<int> agi_real { get; set; }
        public Nullable<int> agi_actual { get; set; }
        public Nullable<int> res_ini { get; set; }
        public Nullable<int> res_real { get; set; }
        public Nullable<int> res_actual { get; set; }
        public Nullable<int> velocidad_ini { get; set; }
        public Nullable<int> velocidad_real { get; set; }
        public Nullable<int> velocidad_actual { get; set; }
        public Nullable<int> estado { get; set; }
        public bool habilitado { get; set; }
        public string imagen { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<asoc_personaje_item> asoc_personaje_item { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<asoc_personaje_skill> asoc_personaje_skill { get; set; }
        public virtual atributo atributo1 { get; set; }
        public virtual clases clases { get; set; }
        public virtual estado estado1 { get; set; }
        public virtual razas razas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<leveleo> leveleo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<party> party { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<asoc_personaje_mochila> asoc_personaje_mochila { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<mascotas> mascotas { get; set; }
    }
}