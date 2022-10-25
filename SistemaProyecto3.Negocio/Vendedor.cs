using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaProyecto3.Dato;

namespace SistemaProyecto3.Negocio
{
    public class Vendedor
    {
        public string rut_vendedor { get; set; }
        public string nombre_vendedor { get; set; }
        public string apellidos_vendedor { get; set; }
        public int edad_vendedor { get; set; }
        public string sexo_vendedor { get; set; }
        public int sueldo_vendedor { get; set; }
        public int bono_vendedor { get; set; }
        public int ventas_totales { get; set; }
        public Nullable<int> id_sucursal { get; set; }

        public Vendedor()
        {
            rut_vendedor = null;
            nombre_vendedor = null;
            apellidos_vendedor = null;
            edad_vendedor = 0;
            sexo_vendedor = null;
            sueldo_vendedor = 0;
            bono_vendedor = 0;
            ventas_totales = 0;
            id_sucursal = 0;
        }

        //Crear Vendedor
        public bool CreateVendedor()
        {
            try
            {
                VENDEDOR vendedor = new VENDEDOR()
                {
                    rut_vendedor = rut_vendedor,
                    nombre_vendedor = nombre_vendedor,
                    apellidos_vendedor = apellidos_vendedor,
                    edad_vendedor = edad_vendedor,
                    sexo_vendedor = sexo_vendedor,
                    sueldo_vendedor = sueldo_vendedor,
                    bono_vendedor = 0,
                    ventas_totales = 0,
                    id_sucursal = id_sucursal
                };
                Conexion.GetDB_SAB_Entities.VENDEDOR.Add(vendedor);
                Conexion.GetDB_SAB_Entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Buscar Vendedor
        public bool ReadVendedor()
        {
            try
            {
                VENDEDOR vendedor = Conexion.GetDB_SAB_Entities.VENDEDOR.First(v => v.rut_vendedor == rut_vendedor);
                rut_vendedor = vendedor.rut_vendedor;
                nombre_vendedor = vendedor.nombre_vendedor;
                apellidos_vendedor = vendedor.apellidos_vendedor;
                edad_vendedor = vendedor.edad_vendedor;
                sexo_vendedor = vendedor.sexo_vendedor;
                sueldo_vendedor = vendedor.sueldo_vendedor;
                bono_vendedor = vendedor.bono_vendedor;
                ventas_totales = vendedor.ventas_totales;
                id_sucursal = vendedor.id_sucursal;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Actualizar Vendedor
        public bool UpdateVendedor()
        {
            try
            {
                VENDEDOR vendedor = Conexion.GetDB_SAB_Entities.VENDEDOR.First(v => v.rut_vendedor == rut_vendedor);
                vendedor.nombre_vendedor = nombre_vendedor;
                vendedor.apellidos_vendedor = apellidos_vendedor;
                vendedor.edad_vendedor = edad_vendedor;
                vendedor.sexo_vendedor = sexo_vendedor;
                vendedor.sueldo_vendedor = sueldo_vendedor;
                vendedor.bono_vendedor = bono_vendedor;
                vendedor.ventas_totales = ventas_totales;
                vendedor.id_sucursal = id_sucursal;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Eliminar Vendedor
        public bool DeleteVendedor()
        {
            try
            {
                VENDEDOR vendedor = Conexion.GetDB_SAB_Entities.VENDEDOR.First(v => v.rut_vendedor == rut_vendedor);
                Conexion.GetDB_SAB_Entities.VENDEDOR.Remove(vendedor);
                Conexion.GetDB_SAB_Entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Lista Vendedor
        public List<Vendedor> GetVendedores()
        {
            List<Vendedor> ListaVendedores = new List<Vendedor>();
            foreach(VENDEDOR vendedor in Conexion.GetDB_SAB_Entities.VENDEDOR.ToList())
            {
                ListaVendedores.Add(new Vendedor()
                {
                    rut_vendedor = vendedor.rut_vendedor,
                    nombre_vendedor = vendedor.nombre_vendedor,
                    apellidos_vendedor = vendedor.apellidos_vendedor,
                    edad_vendedor = vendedor.edad_vendedor,
                    sexo_vendedor = vendedor.sexo_vendedor,
                    sueldo_vendedor = vendedor.sueldo_vendedor,
                    bono_vendedor = vendedor.bono_vendedor,
                    ventas_totales = vendedor.ventas_totales,
                    id_sucursal = vendedor.id_sucursal
            });
            }
            return ListaVendedores;
        }

        public Array GetRutVendedores()
        {
            int max = 0;
            int rec = 0;
            foreach (VENDEDOR vendedor in Conexion.GetDB_SAB_Entities.VENDEDOR.ToList())
            {
                max = max + 1;
            }
            String[] ArregloRutVendedores = new string[max];
            foreach (VENDEDOR vendedor in Conexion.GetDB_SAB_Entities.VENDEDOR.ToList())
            {
                ArregloRutVendedores[rec] = vendedor.rut_vendedor;
                rec = rec + 1;
            }
            return ArregloRutVendedores;
        }
    }
}
