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
    
    public partial class PRODUCTO
    {
        public string patente_producto { get; set; }
        public int kilometraje { get; set; }
        public string año { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public int tipo { get; set; }
        public int precio { get; set; }
        public Nullable<int> id_boleta { get; set; }
        public Nullable<int> id_factura { get; set; }
    
        public virtual BOLETA BOLETA { get; set; }
        public virtual FACTURA FACTURA { get; set; }
    }
}
