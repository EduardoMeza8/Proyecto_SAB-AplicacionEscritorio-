using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaProyecto3.Dato;

namespace SistemaProyecto3.Negocio
{
    public class Venta
    {
        public int id_venta { get; set; }
        public double iva { get; set; }
        public int cantidad { get; set; }
        public int monto_total { get; set; }
        public string descripcion { get; set; }
        public string rut_vendedor { get; set; }

        public Venta()
        {
            iva = 0;
            cantidad = 0;
            monto_total = 0;
            descripcion = null;
            rut_vendedor = null;
        }

        public bool CrearVenta()
        {
            try
            {
                VENTA venta = new VENTA()
                {
                    iva = iva,
                    cantidad = cantidad,
                    monto_total = monto_total,
                    descripcion = descripcion,
                    rut_vendedor = rut_vendedor
                };
                Conexion.GetDB_SAB_Entities.VENTA.Add(venta);
                Conexion.GetDB_SAB_Entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Venta> GetVentas()
        {
            List<Venta> ListaVentas = new List<Venta>();
            foreach (VENTA venta in Conexion.GetDB_SAB_Entities.VENTA.ToList())
            {
                ListaVentas.Add(new Venta()
                {
                    id_venta = venta.id_venta,
                    iva = venta.iva,
                    cantidad = venta.cantidad,
                    monto_total = venta.monto_total,
                    descripcion = venta.descripcion,
                    rut_vendedor = venta.rut_vendedor
                });
            }
            return ListaVentas;
        }
    }
}
