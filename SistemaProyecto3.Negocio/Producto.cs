using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaProyecto3.Dato;

namespace SistemaProyecto3.Negocio
{
    public class Producto
    {
        public string patente_producto { get; set; }
        public int kilometraje { get; set; }
        public string año { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public int tipo { get; set; }
        public int precio { get; set; }

        public Producto()
        {
            patente_producto = null;
            kilometraje = 0;
            año = null;
            marca = null;
            modelo = null;
            tipo = 0;
            precio = 0;
        }

        public List<Producto> GetProductos()
        {
            List<Producto> ListaProductos = new List<Producto>();
            foreach (PRODUCTO producto in Conexion.GetDB_SAB_Entities.PRODUCTO.ToList())
            {
                ListaProductos.Add(new Producto()
                {
                    patente_producto = producto.patente_producto,
                    kilometraje = producto.kilometraje,
                    año = producto.año,
                    marca = producto.marca,
                    modelo = producto.modelo,
                    tipo = producto.tipo,
                    precio = producto.precio
                });
            }
            return ListaProductos;
        }

        public Array GetPatentesProducto()
        {
            int max = 0;
            int rec = 0;
            foreach (PRODUCTO producto in Conexion.GetDB_SAB_Entities.PRODUCTO.ToList())
            {
                max = max + 1;
            }
            String[] ArregloProductos = new string[max];
            foreach (PRODUCTO producto in Conexion.GetDB_SAB_Entities.PRODUCTO.ToList())
            {
                ArregloProductos[rec] = producto.patente_producto;
                rec = rec + 1;
            }
            return ArregloProductos;
        }
    }
}
