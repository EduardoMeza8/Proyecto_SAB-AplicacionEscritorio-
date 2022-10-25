using SistemaProyecto3.Dato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaProyecto3.Negocio
{
    public class Usuario
    {
        public string usuario1 { get; set; }
        public string contraseña_usuario { get; set; }
        public int tipo_usuario { get; set; }

        public Usuario() 
        {
            usuario1 = null;
            contraseña_usuario = null;
            tipo_usuario = 0;
        }
        
        // Crear Usuario Admin
        public bool CreateAdmin()
        {
            try
            {
                USUARIO userAdmin = new USUARIO()
                {
                    usuario1 = usuario1,
                    contraseña_usuario = contraseña_usuario,
                    tipo_usuario = 1
                };
                Conexion.GetDB_SAB_Entities.USUARIO.Add(userAdmin);
                Conexion.GetDB_SAB_Entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Crear Usuario Vendedor
        public bool CreateVendedor()
        {
            try
            {
                USUARIO userVendedor = new USUARIO()
                {
                    usuario1 = usuario1,
                    contraseña_usuario = contraseña_usuario,
                    tipo_usuario = 2
                };
                Conexion.GetDB_SAB_Entities.USUARIO.Add(userVendedor);
                Conexion.GetDB_SAB_Entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        // Buscar Usuario Admin
        public bool ReadAdmin()
        {
            try
            {
                USUARIO userAdmin = Conexion.GetDB_SAB_Entities.USUARIO.First(v => v.usuario1 == usuario1 && v.tipo_usuario == 1);
                usuario1 = userAdmin.usuario1;
                contraseña_usuario = userAdmin.contraseña_usuario;
                tipo_usuario = userAdmin.tipo_usuario;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        // Buscar Usuario Vendedor
        public bool ReadVendedor()
        {
            try
            {
                USUARIO userVendedor = Conexion.GetDB_SAB_Entities.USUARIO.First(v => v.usuario1 == usuario1 && v.tipo_usuario == 2);
                usuario1 = userVendedor.usuario1;
                contraseña_usuario = userVendedor.contraseña_usuario;
                tipo_usuario = userVendedor.tipo_usuario;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        // Eliminar Usuario Admin
        public bool DeleteAdmin()
        {
            try
            {
                USUARIO userAdmin = Conexion.GetDB_SAB_Entities.USUARIO.First(v => v.usuario1 == usuario1 && v.tipo_usuario == 1);
                Conexion.GetDB_SAB_Entities.USUARIO.Remove(userAdmin);
                Conexion.GetDB_SAB_Entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        // Eliminar Ususario Vendedor
        public bool DeleteVendedor()
        {
            try
            {
                USUARIO userVendedor = Conexion.GetDB_SAB_Entities.USUARIO.First(v => v.usuario1 == usuario1 && v.tipo_usuario == 2);
                Conexion.GetDB_SAB_Entities.USUARIO.Remove(userVendedor);
                Conexion.GetDB_SAB_Entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        // Update pass Admin
        public bool UpdatePassAdmin()
        {
            try
            {
                USUARIO userAdmin = Conexion.GetDB_SAB_Entities.USUARIO.First(v => v.usuario1 == usuario1 && v.tipo_usuario == 1);
                userAdmin.contraseña_usuario = contraseña_usuario;
                Conexion.GetDB_SAB_Entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        // Update pass Vendedor
        public bool UpdatePassVendedor()
        {
            try
            {
                USUARIO userVendedor = Conexion.GetDB_SAB_Entities.USUARIO.First(v => v.usuario1 == usuario1 && v.tipo_usuario == 2);
                userVendedor.contraseña_usuario = contraseña_usuario;
                Conexion.GetDB_SAB_Entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        // Lista Usuario Administrador
        public List<Usuario> GetUsuariosAdmin()
        {
            List<Usuario> ListaUsuariosAdmin = new List<Usuario>();
            foreach (USUARIO UserAdmin in Conexion.GetDB_SAB_Entities.USUARIO.ToList())
            {
                if (UserAdmin.tipo_usuario == 1)
                {
                    ListaUsuariosAdmin.Add(new Usuario()
                    {
                        usuario1 = UserAdmin.usuario1,
                        contraseña_usuario = UserAdmin.contraseña_usuario,
                        tipo_usuario = UserAdmin.tipo_usuario
                    });
                }
            }
            return ListaUsuariosAdmin;
        }
        
        // Lista Usuario Vendedor 
        public List<Usuario> GetUsuariosVendedor()
        {
            List<Usuario> ListaUsuariosVendedor = new List<Usuario>();
            foreach (USUARIO UserVendedor in Conexion.GetDB_SAB_Entities.USUARIO.ToList())
            {
                if (UserVendedor.tipo_usuario == 2)
                {
                    ListaUsuariosVendedor.Add(new Usuario()
                    {
                        usuario1 = UserVendedor.usuario1,
                        contraseña_usuario = UserVendedor.contraseña_usuario,
                        tipo_usuario = UserVendedor.tipo_usuario
                    });
                }
            }
            return ListaUsuariosVendedor;
        }
    }
}
