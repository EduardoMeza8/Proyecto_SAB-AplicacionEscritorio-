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
    
    public partial class VENTA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VENTA()
        {
            this.BOLETA = new HashSet<BOLETA>();
            this.FACTURA = new HashSet<FACTURA>();
        }
    
        public int id_venta { get; set; }
        public double iva { get; set; }
        public int cantidad { get; set; }
        public int monto_total { get; set; }
        public string descripcion { get; set; }
        public string rut_vendedor { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BOLETA> BOLETA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FACTURA> FACTURA { get; set; }
        public virtual VENDEDOR VENDEDOR { get; set; }
    }
}
