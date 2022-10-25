using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaProyecto3.Dato;

namespace SistemaProyecto3.Negocio
{
    public class Servicio
    {
        public int id_servicio { get; set; }
        public Nullable<System.DateTime> fecha_entrega { get; set; }
        public int costo_servicio { get; set; }
        public string patente_servicio { get; set; }
        public string descripcion { get; set; }

        public Servicio()
        {
            fecha_entrega = null;
            costo_servicio = 0;
            patente_servicio = patente_servicio;
            descripcion = descripcion;
        }

        public bool CrearServicio()
        {
            try
            {
                SERVICIO servicio = new SERVICIO()
                {
                    fecha_entrega = fecha_entrega,
                    costo_servicio = costo_servicio,
                    patente_servicio = patente_servicio,
                    descripcion = descripcion
                };
                Conexion.GetDB_SAB_Entities.SERVICIO.Add(servicio);
                Conexion.GetDB_SAB_Entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public List<Servicio> GetServicios()
        {
            List<Servicio> ListaServicios = new List<Servicio>();
            foreach (SERVICIO servicio in Conexion.GetDB_SAB_Entities.SERVICIO.ToList())
            {
                ListaServicios.Add(new Servicio()
                {
                    id_servicio = servicio.id_servicio,
                    fecha_entrega = servicio.fecha_entrega,
                    patente_servicio = servicio.patente_servicio,
                    descripcion = servicio.descripcion
                });
            }
            return ListaServicios;
        }
    }
}
