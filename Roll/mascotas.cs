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
    
    public partial class mascotas
    {
        public int mascota_id { get; set; }
        public int mascota_owner { get; set; }
        public int mascota_nivel { get; set; }
        public string mascota_nombre { get; set; }
        public int mascota_especie { get; set; }
        public Nullable<int> mascota_vida_inicial { get; set; }
        public Nullable<int> mascota_mana_inicial { get; set; }
        public Nullable<int> mascota_vida_real { get; set; }
        public Nullable<int> mascota_mana_real { get; set; }
        public Nullable<int> mascota_vida_actual { get; set; }
        public Nullable<int> mascota_mana_actual { get; set; }
        public Nullable<int> mascota_velocidad_inicial { get; set; }
        public Nullable<int> mascota_velocidad_real { get; set; }
        public Nullable<int> mascota_velocidad_actual { get; set; }
        public Nullable<int> mascota_armor_inicial { get; set; }
        public Nullable<int> mascota_armor_real { get; set; }
        public Nullable<int> mascota_armor_actual { get; set; }
        public Nullable<int> mascota_mr_inicial { get; set; }
        public Nullable<int> mascota_mr_real { get; set; }
        public Nullable<int> mascota_mr_actual { get; set; }
        public Nullable<int> mascota_evasion_inicial { get; set; }
        public Nullable<int> mascota_evasion_real { get; set; }
        public Nullable<int> mascota_evasion_actual { get; set; }
        public Nullable<bool> mascota_evolucion { get; set; }
        public Nullable<bool> mascota_montura { get; set; }
        public Nullable<bool> mascota_vuela { get; set; }
        public Nullable<bool> mascota_nadar { get; set; }
        public Nullable<bool> mascota_respira_agua { get; set; }
        public Nullable<int> mascota_capacidad_carga { get; set; }
        public Nullable<int> mascota_peso { get; set; }
        public Nullable<int> mascota_altura { get; set; }
        public Nullable<int> mascota_ancho { get; set; }
        public Nullable<int> mascota_afinidad { get; set; }
        public Nullable<int> mascota_edad { get; set; }
    
        public virtual personajes personajes { get; set; }
        public virtual monstruos monstruos { get; set; }
    }
}
