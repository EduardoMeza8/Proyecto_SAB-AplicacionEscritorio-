using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaProyecto3.Dato;

namespace SistemaProyecto3.Negocio
{
    public class Factura
    {
        public int id_factura { get; set; }
        public int monto_factura { get; set; }
        public int monto_iva_factura { get; set; }
        public Nullable<System.DateTime> fecha_ingreso_factura { get; set; }
        public Nullable<System.DateTime> fecha_entrega_factura { get; set; }
        public string descripcion_factura { get; set; }
        public string descripcion_cliente_factura { get; set; }
        public string rut_factura { get; set; }
        public string rut_cliente_factura { get; set; }
        public string rut_empresa_factura { get; set; }
        public string patente_producto_factura { get; set; }

        public Factura()
        {
            monto_factura = 0;
            monto_iva_factura = 0;
            fecha_ingreso_factura = null;
            fecha_entrega_factura = null;
            descripcion_factura = null;
            descripcion_cliente_factura = null;
            rut_factura = null;
            rut_cliente_factura = null;
            rut_empresa_factura = null;
            patente_producto_factura = null;
        }

        public bool CrearFacturaServicio()
        {
            try
            {
                FACTURA factura = new FACTURA()
                {
                    monto_factura = monto_factura,
                    monto_iva_factura = monto_iva_factura,
                    fecha_ingreso_factura = fecha_ingreso_factura,
                    fecha_entrega_factura = fecha_entrega_factura,
                    descripcion_factura = descripcion_factura,
                    descripcion_cliente_factura = descripcion_cliente_factura,
                    rut_factura = rut_factura,
                    rut_cliente_factura = rut_cliente_factura,
                    rut_empresa_factura = rut_empresa_factura
                };
                Conexion.GetDB_SAB_Entities.FACTURA.Add(factura);
                Conexion.GetDB_SAB_Entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool CrearFacturaProducto()
        {
            try
            {
                FACTURA factura = new FACTURA()
                {
                    monto_factura = monto_factura,
                    monto_iva_factura = monto_iva_factura,
                    fecha_ingreso_factura = fecha_ingreso_factura,
                    fecha_entrega_factura = fecha_entrega_factura,
                    descripcion_factura = descripcion_factura,
                    descripcion_cliente_factura = descripcion_cliente_factura,
                    rut_factura = rut_factura,
                    rut_cliente_factura = rut_cliente_factura,
                    rut_empresa_factura = rut_empresa_factura,
                    patente_producto_factura = patente_producto_factura
                };
                Conexion.GetDB_SAB_Entities.FACTURA.Add(factura);
                Conexion.GetDB_SAB_Entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Factura> GetFacturas()
        {
            List<Factura> ListaFacturas = new List<Factura>();
            foreach(FACTURA factura in Conexion.GetDB_SAB_Entities.FACTURA.ToList())
            {
                ListaFacturas.Add(new Factura()
                {
                    id_factura = factura.id_factura,
                    monto_factura = factura.monto_factura,
                    monto_iva_factura = factura.monto_iva_factura,
                    fecha_ingreso_factura = factura.fecha_ingreso_factura,
                    fecha_entrega_factura = factura.fecha_entrega_factura,
                    descripcion_factura = factura.descripcion_factura,
                    descripcion_cliente_factura = factura.descripcion_cliente_factura,
                    rut_factura = factura.rut_factura,
                    rut_cliente_factura = factura.rut_cliente_factura,
                    rut_empresa_factura = factura.rut_empresa_factura,
                    patente_producto_factura = factura.patente_producto_factura
                });
            }
            return ListaFacturas;
        }
    }
}
