//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SistemaProyecto3.Dato
{
    using System;
    using System.Collections.Generic;
    
    public partial class MECANICO
    {
        public string rut_mecanico { get; set; }
        public string nombre_mecanico { get; set; }
        public string apellido_vendedor { get; set; }
        public int edad_mecanico { get; set; }
        public string sexo_mecanico { get; set; }
        public int sueldo_mecanico { get; set; }
        public Nullable<int> id_sucursal { get; set; }
    
        public virtual SUCURSAL SUCURSAL { get; set; }
    }
}