using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaProyecto3.Dato;

namespace SistemaProyecto3.Negocio
{
    public class Boleta
    {
        public int id_boleta { get; set; }
        public int monto_boleta { get; set; }
        public int monto_iva_boleta { get; set; }
        public Nullable<System.DateTime> fecha_ingreso_boleta { get; set; }
        public Nullable<System.DateTime> fecha_entrega_boleta { get; set; }
        public string descripcion_boleta { get; set; }
        public string descripcion_cliente_boleta { get; set; }
        public string rut_boleta { get; set; }
        public string rut_cliente_boleta { get; set; }
        public string patente_producto_boleta { get; set; }
        public string tipo_servicio_boleta { get; set; }
        public Nullable<int> id_venta { get; set; }

        public Boleta()
        {
            id_boleta = 0;
            monto_boleta = 0;
            monto_iva_boleta = 0;
            fecha_ingreso_boleta = null;
            fecha_entrega_boleta = null;
            descripcion_boleta = null;
            descripcion_cliente_boleta = null;
            rut_boleta = null;
            rut_cliente_boleta = null;
            patente_producto_boleta = null;
            tipo_servicio_boleta = null;
            id_venta = null;
        }

        public bool CreateBoletaServicio()
        {
            try
            {
                BOLETA boleta = new BOLETA()
                {
                    monto_boleta = monto_boleta,
                    monto_iva_boleta = monto_iva_boleta,
                    fecha_ingreso_boleta = fecha_ingreso_boleta,
                    fecha_entrega_boleta = fecha_entrega_boleta,
                    descripcion_boleta = descripcion_boleta,
                    descripcion_cliente_boleta = descripcion_cliente_boleta,
                    rut_boleta = rut_boleta,
                    rut_cliente_boleta = rut_cliente_boleta,
                    patente_producto_boleta = null,
                    tipo_servicio_boleta = tipo_servicio_boleta,
                    id_venta = id_venta
                };
                VENDEDOR vendedor = Conexion.GetDB_SAB_Entities.VENDEDOR.First(v => v.rut_vendedor == rut_boleta);
                vendedor.ventas_totales = (vendedor.ventas_totales + monto_boleta);
                vendedor.bono_vendedor = Convert.ToInt16(monto_boleta * 0.05);
                Conexion.GetDB_SAB_Entities.BOLETA.Add(boleta);
                Conexion.GetDB_SAB_Entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool CreateBoletaProducto()
        {
            try
            {
                BOLETA boleta = new BOLETA()
                {
                    monto_boleta = monto_boleta,
                    monto_iva_boleta = monto_iva_boleta,
                    fecha_ingreso_boleta = fecha_ingreso_boleta,
                    fecha_entrega_boleta = fecha_entrega_boleta,
                    descripcion_boleta = descripcion_boleta,
                    descripcion_cliente_boleta = descripcion_cliente_boleta,
                    rut_boleta = rut_boleta,
                    rut_cliente_boleta = rut_cliente_boleta,
                    patente_producto_boleta = patente_producto_boleta,
                    tipo_servicio_boleta = null,
                    id_venta = id_venta
                };
                VENDEDOR vendedor = Conexion.GetDB_SAB_Entities.VENDEDOR.First(v => v.rut_vendedor == rut_boleta);
                vendedor.ventas_totales = (vendedor.ventas_totales + monto_boleta);
                vendedor.bono_vendedor = Convert.ToInt16(monto_boleta * 0.05);
                Conexion.GetDB_SAB_Entities.BOLETA.Add(boleta);
                Conexion.GetDB_SAB_Entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Boleta> GetBoletas()
        {
            List<Boleta> ListaBoletas = new List<Boleta>();
            foreach (BOLETA boleta in Conexion.GetDB_SAB_Entities.BOLETA.ToList())
            {
                ListaBoletas.Add(new Boleta()
                {
                    id_boleta = boleta.id_boleta,
                    monto_boleta = boleta.monto_boleta,
                    monto_iva_boleta = boleta.monto_iva_boleta,
                    fecha_ingreso_boleta = boleta.fecha_ingreso_boleta,
                    fecha_entrega_boleta = boleta.fecha_entrega_boleta,
                    descripcion_boleta = boleta.descripcion_boleta,
                    descripcion_cliente_boleta = boleta.descripcion_cliente_boleta,
                    rut_boleta = boleta.rut_boleta,
                    rut_cliente_boleta = boleta.rut_cliente_boleta,
                    patente_producto_boleta = boleta.patente_producto_boleta,
                    tipo_servicio_boleta = boleta.tipo_servicio_boleta,
                    id_venta = boleta.id_venta
                });
            }
            return ListaBoletas;
        }

    }    
}
