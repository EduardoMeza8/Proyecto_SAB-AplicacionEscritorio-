using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using SistemaProyecto3.Dato;

namespace SistemaProyecto3.Negocio
{
    public class Empresa
    {
        public string rut_empresa { get; set; }
        public string nombre_empresa { get; set; }
        public int contacto { get; set; }
        public string direccion { get; set; }

        public Empresa()
        {
            rut_empresa = null;
            nombre_empresa = null;
            contacto = 0;
            direccion = null;
        }

        public bool ValidarRut(string rut)
        {
            string dv = rut.Substring(rut.Length - 1, 1);
            char[] charCorte = { '-' };
            String[] rutTemp = rut.Split(charCorte);
            if (dv != Digito(int.Parse(rutTemp[0])))
            {
                return false;
            }
            return true;
        }

        private static string Digito(int rut)
        {
            int suma = 0;
            int multiplicador = 1;
            while (rut != 0)
            {
                multiplicador++;
                if (multiplicador == 8)
                    multiplicador = 2;
                suma += (rut % 10) * multiplicador;
                rut = rut / 10;
            }
            suma = 11 - (suma % 11);
            if (suma == 11)
            {
                return "0";
            }
            else if (suma == 10)
            {
                return "K";
            }
            else
            {
                return suma.ToString();
            }
        }

        //Funcion Crear Empresa
        public bool CreateEmpresa()
        {
            try
            {
                EMPRESA empresa = new EMPRESA()
                {
                    rut_empresa = rut_empresa,
                    nombre_empresa = nombre_empresa,
                    contacto = contacto,
                    direccion = direccion
                };
                Conexion.GetDB_SAB_Entities.EMPRESA.Add(empresa);
                Conexion.GetDB_SAB_Entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //Funcion Eliminar Enpresa     
        public bool DeleteEmpresa()
        {
            try
            {
                EMPRESA empresa = Conexion.GetDB_SAB_Entities.EMPRESA.First(v => v.rut_empresa == rut_empresa);
                Conexion.GetDB_SAB_Entities.EMPRESA.Remove(empresa);
                Conexion.GetDB_SAB_Entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                    return false;
            }
        }
        //Funcion Actualizar Empresa (actualiza los atributos de la tabla)
        public bool UpdateEmpresa() 
        {
            try 
            {
                EMPRESA empresa = Conexion.GetDB_SAB_Entities.EMPRESA.First(v => v.rut_empresa == rut_empresa);
                empresa.nombre_empresa = nombre_empresa;
                empresa.contacto = contacto;
                empresa.direccion = direccion;
                Conexion.GetDB_SAB_Entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //Funcion Buscar Empresa
        public bool searchEmpresa() 
        {
            try 
            {
                EMPRESA empresa = Conexion.GetDB_SAB_Entities.EMPRESA.First(v => v.rut_empresa == rut_empresa);
                rut_empresa = empresa.rut_empresa;
                nombre_empresa = empresa.nombre_empresa;
                contacto = empresa.contacto;
                direccion = empresa.direccion;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        // Lista de Empresas 
        public List<Empresa> GetEmpresa()
        {
            List<Empresa> ListaEmpresa = new List<Empresa>();
            foreach (EMPRESA empresa in Conexion.GetDB_SAB_Entities.EMPRESA.ToList())
            {
                ListaEmpresa.Add(new Empresa()
                {
                    rut_empresa = empresa.rut_empresa,
                    nombre_empresa = empresa.nombre_empresa,
                    contacto = empresa.contacto,
                    direccion = empresa.direccion
                });
            }
            return ListaEmpresa;
        }

        public Array GetRutEmpresa()
        {
            int max = 0;
            int rec = 0;
            foreach (EMPRESA empresa in Conexion.GetDB_SAB_Entities.EMPRESA.ToList())
            {
                max = max + 1;
            }
            String[] ArregloRutEmpresa = new string[max];
            foreach (EMPRESA empresa in Conexion.GetDB_SAB_Entities.EMPRESA.ToList())
            {
                ArregloRutEmpresa[rec] = empresa.rut_empresa;
                rec = rec + 1;
            }
            return ArregloRutEmpresa;
        }
    }
}
