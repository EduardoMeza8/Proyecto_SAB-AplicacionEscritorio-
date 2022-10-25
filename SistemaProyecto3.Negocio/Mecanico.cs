using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaProyecto3.Dato;

namespace SistemaProyecto3.Negocio
{
    public class Mecanico
    {
        public string rut_mecanico { get; set; }
        public string nombre_mecanico { get; set; }
        public string apellido_vendedor { get; set; }
        public int edad_mecanico { get; set; }
        public string sexo_mecanico { get; set; }
        public int sueldo_mecanico { get; set; }
        public Nullable<int> id_sucursal { get; set; }

        public Mecanico()
        {
            rut_mecanico = null;
            nombre_mecanico = null;
            apellido_vendedor = null;
            edad_mecanico = 0;
            sexo_mecanico = null;
            sueldo_mecanico = 0;
            id_sucursal = 0;
        }

        // Registrar Mecanico
        public bool CreateMecanico()
        {
            try
            {
                MECANICO mecanico = new MECANICO()
                {
                    rut_mecanico = rut_mecanico,
                    nombre_mecanico = nombre_mecanico,
                    apellido_vendedor = apellido_vendedor,
                    edad_mecanico = edad_mecanico,
                    sexo_mecanico = sexo_mecanico,
                    sueldo_mecanico = sueldo_mecanico,
                    id_sucursal = id_sucursal
                };
                Conexion.GetDB_SAB_Entities.MECANICO.Add(mecanico);
                Conexion.GetDB_SAB_Entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Buscar Mecanico
        public bool ReadMecanico()
        {
            try
            {
                MECANICO mecanico = Conexion.GetDB_SAB_Entities.MECANICO.First(v => v.rut_mecanico == rut_mecanico);
                rut_mecanico = mecanico.rut_mecanico;
                nombre_mecanico = mecanico.nombre_mecanico;
                apellido_vendedor = mecanico.apellido_vendedor;
                edad_mecanico = mecanico.edad_mecanico;
                sexo_mecanico = mecanico.sexo_mecanico;
                sueldo_mecanico = mecanico.sueldo_mecanico;
                id_sucursal = mecanico.id_sucursal;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Actualizar Mecanico
        public bool UpdateMecanico()
        {
            try
            {
                MECANICO mecanico = Conexion.GetDB_SAB_Entities.MECANICO.First(v => v.rut_mecanico == rut_mecanico);
                mecanico.rut_mecanico = rut_mecanico;
                mecanico.nombre_mecanico = nombre_mecanico;
                mecanico.apellido_vendedor = apellido_vendedor;
                mecanico.edad_mecanico = edad_mecanico;
                mecanico.sexo_mecanico = sexo_mecanico;
                mecanico.sueldo_mecanico = sueldo_mecanico;
                mecanico.id_sucursal = id_sucursal;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Eliminar Mecanico
        public bool DeleteMecanico()
        {
            try
            {
                MECANICO mecanico = Conexion.GetDB_SAB_Entities.MECANICO.First(v => v.rut_mecanico == rut_mecanico);
                Conexion.GetDB_SAB_Entities.MECANICO.Remove(mecanico);
                Conexion.GetDB_SAB_Entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Lista Mecanico => Se usa en datagrid de la pantalla mecanico
        public List<Mecanico> GetMecanicos()
        {
            List<Mecanico> ListaMecanicos = new List<Mecanico>();
            foreach (MECANICO mecanico in Conexion.GetDB_SAB_Entities.MECANICO.ToList())
            {
                ListaMecanicos.Add(new Mecanico()
                {
                    rut_mecanico = mecanico.rut_mecanico,
                    nombre_mecanico = mecanico.nombre_mecanico,
                    apellido_vendedor = mecanico.apellido_vendedor,
                    edad_mecanico = mecanico.edad_mecanico,
                    sexo_mecanico = mecanico.sexo_mecanico,
                    sueldo_mecanico = mecanico.sueldo_mecanico,
                    id_sucursal = mecanico.id_sucursal
                });
            }
            return ListaMecanicos;
        }

        // Array Ruts Mecanicos => Se usa en combo de la pantalla
        public Array GetRutMecanicos()
        {
            int max = 0;
            int rec = 0;
            foreach (MECANICO mecanico in Conexion.GetDB_SAB_Entities.MECANICO.ToList())
            {
                max = max + 1;
            }
            String[] ArregloRutMecanicos = new string[max];
            foreach (MECANICO mecanico in Conexion.GetDB_SAB_Entities.MECANICO.ToList())
            {
                ArregloRutMecanicos[rec] = mecanico.rut_mecanico;
                rec = rec + 1;
            }
            return ArregloRutMecanicos;
        }
    }
}
