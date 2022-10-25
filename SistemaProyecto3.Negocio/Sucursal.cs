using SistemaProyecto3.Dato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaProyecto3.Negocio
{
    public class Sucursal
    {
        public int id_sucursal { get; set; }
        public string ciudad_sucursal { get; set; }
        public string direccion_sucursal { get; set; }
        public string nombre_sucursal { get; set; }

        public Sucursal()
        {
            id_sucursal = 0;
            ciudad_sucursal = null;
            direccion_sucursal = null;
            nombre_sucursal = null;
        }

        //Create Sucursal
        public bool CreateScrsl()
        {
            try
            {
                SUCURSAL sucursal = new SUCURSAL()
                {
                    ciudad_sucursal = ciudad_sucursal,
                    direccion_sucursal = direccion_sucursal,
                    nombre_sucursal = nombre_sucursal
                };
                Conexion.GetDB_SAB_Entities.SUCURSAL.Add(sucursal);
                Conexion.GetDB_SAB_Entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Buscar Sucursal
        public bool ReadScrsl()
        {
            try
            {
                SUCURSAL sucursal = Conexion.GetDB_SAB_Entities.SUCURSAL.First(v => v.id_sucursal == id_sucursal);
                ciudad_sucursal = sucursal.ciudad_sucursal;
                direccion_sucursal = sucursal.direccion_sucursal;
                nombre_sucursal = sucursal.nombre_sucursal;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Update Sucursal
        public bool UpdateScrsl()
        {
            try
            {
                SUCURSAL sucursal = Conexion.GetDB_SAB_Entities.SUCURSAL.First(v => v.id_sucursal == id_sucursal);
                sucursal.ciudad_sucursal = ciudad_sucursal;
                sucursal.direccion_sucursal = direccion_sucursal;
                sucursal.nombre_sucursal = nombre_sucursal;
                Conexion.GetDB_SAB_Entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Eliminar Sucursal
        public bool DeleteScrsl()
        {
            try
            {
                SUCURSAL sucursal = Conexion.GetDB_SAB_Entities.SUCURSAL.First(v => v.id_sucursal == id_sucursal);
                Conexion.GetDB_SAB_Entities.SUCURSAL.Remove(sucursal);
                Conexion.GetDB_SAB_Entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Lista Sucursal
        public List<Sucursal> GetSucursales()
        {
            List<Sucursal> ListaSucursales = new List<Sucursal>();
            foreach (SUCURSAL sucursal in Conexion.GetDB_SAB_Entities.SUCURSAL.ToList())
            {
                ListaSucursales.Add(new Sucursal()
                {
                    id_sucursal = sucursal.id_sucursal,
                    ciudad_sucursal = sucursal.ciudad_sucursal,
                    direccion_sucursal = sucursal.direccion_sucursal,
                    nombre_sucursal = sucursal.nombre_sucursal
                });
            }
            return ListaSucursales;
        }

        public Array GetIDSucursales()
        {
            int max = 0;
            int rec = 0;
            foreach (SUCURSAL sucursal in Conexion.GetDB_SAB_Entities.SUCURSAL.ToList())
            {
                max = max + 1;
            }
            int[] ArregloIDSucursal = new int[max];
            foreach (SUCURSAL sucursal in Conexion.GetDB_SAB_Entities.SUCURSAL.ToList())
            {
                ArregloIDSucursal[rec] = sucursal.id_sucursal;
                rec = rec + 1;
            }
            return ArregloIDSucursal;
        }
    }
}
