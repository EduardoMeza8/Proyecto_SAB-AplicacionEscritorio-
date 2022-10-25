using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaProyecto3.Dato;


namespace SistemaProyecto3.Negocio
{
    internal class Conexion
    {

        private static Proyecto_3Entities db_sab;

        public static Proyecto_3Entities GetDB_SAB_Entities
        {
            get
            {
                if (db_sab == null)
                {
                    db_sab = new Proyecto_3Entities();
                }
                return db_sab;
            }
        }

    }
}

