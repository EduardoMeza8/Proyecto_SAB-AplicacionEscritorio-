using SistemaProyecto3.Negocio;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media.Media3D;

namespace SistemaProyecto3.Presentacion
{
    /// <summary>
    /// Lógica de interacción para PantallaAdmin.xaml
    /// </summary>
    public partial class PantallaAdmin : Window
    {
        private List<Sucursal> ListSucursales;
        private List<Empresa> ListEmpresa;
        private List<Vendedor> ListVendedor;
        private List<Usuario> ListUsuariosAdmin;
        private List<Usuario> ListUsuariosVendedor;
        private List<Mecanico> ListMecanicos;

        public PantallaAdmin()
        {
            InitializeComponent();

            // Datos para iniciar el data grid en el arranque del programa

            // Data grid Empresa
            Empresa em = new Empresa();
            ListEmpresa = em.GetEmpresa();
            datagrid_ListaEmpresa.ItemsSource = ListEmpresa;
            datagrid_ListaEmpresa.Items.Refresh();
            
            // Data grid Sucursal
            Sucursal s1 = new Sucursal();
            ListSucursales = s1.GetSucursales();
            datagrid_ListaSucursal.ItemsSource = ListSucursales;
            datagrid_ListaSucursal.Items.Refresh();

            // Data Grid Mecanico
            Mecanico m1 = new Mecanico();
            ListMecanicos = m1.GetMecanicos();
            DataGridMecanicos.ItemsSource = ListMecanicos;
            DataGridMecanicos.Items.Refresh();
        }

        // Botones Empresa

        //  Boton Crear Empresa
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            try
            {
                Empresa em = new Empresa()
                {
                    rut_empresa = textRut_Empresa.Text,
                    nombre_empresa = textNombre_Empresa.Text,
                    contacto = int.Parse(textContacto_Empresa.Text),
                    direccion = textDireccion_Empresa.Text
                };
                if (em.CreateEmpresa())
                {
                    MessageBox.Show("Empresa Creada");
                    textRut_Empresa.Text = "";
                    textNombre_Empresa.Text = "";
                    textContacto_Empresa.Text = "";
                    textDireccion_Empresa.Text = "";
                }
                else if (textRut_Empresa.Text == em.rut_empresa)
                {
                    MessageBox.Show("La empresa ya existe");
                }
                else
                {
                    throw new ArgumentException("Ha ocurrido un error inesperado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        // Boton Eliminar Empresa
        private void botonEliminar_Empresa_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                Empresa em = new Empresa()
                {
                    rut_empresa = textRut_Empresa.Text
                };
                if (em.DeleteEmpresa())
                {
                    MessageBox.Show("Empresa Eliminada");
                    textRut_Empresa.Text = "";
                    textNombre_Empresa.Text = "";
                    textContacto_Empresa.Text = "";
                    textDireccion_Empresa.Text = "";
                }
                else if (textRut_Empresa.Text == " ")
                {
                    MessageBox.Show("Ingrese el rut que desea eliminar");
                }
                else 
                {
                    throw new ArgumentException("Ha ocurrido un error inesperado");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);                    
            }
        }
        
        // Boton Modificar Empresa
        private void botonModificar_Empresa_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                Empresa em = new Empresa()
                {
                    rut_empresa = textRut_Empresa.Text,
                    nombre_empresa = textNombre_Empresa.Text,
                    contacto = int.Parse(textContacto_Empresa.Text),
                    direccion = textDireccion_Empresa.Text
                };
                if (em.UpdateEmpresa())
                {
                    MessageBox.Show("Empresa Actualizada");
                    textRut_Empresa.Text = "";
                    textNombre_Empresa.Text = "";
                    textContacto_Empresa.Text = "";
                    textDireccion_Empresa.Text = "";
                }
                else if (textRut_Empresa.Text == "") 
                {
                    MessageBox.Show("Debe ingresar un rut para continuar");
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error inesperado");
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        // Boton Buscar Empresa
        private void botonBuscar_Empresa_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                Empresa em = new Empresa()
                {
                    rut_empresa = textRut_Empresa.Text
                };
                if (em.searchEmpresa()) 
                {
                    textRut_Empresa.Text = em.rut_empresa;
                    textNombre_Empresa.Text = em.nombre_empresa;
                    textContacto_Empresa.Text = Convert.ToString(em.contacto);
                    textDireccion_Empresa.Text = em.direccion;
                }
                else if (textRut_Empresa.Text == "")
                {
                    MessageBox.Show("Ingrese rut para buscar");
                }
                else
                {
                    throw new ArgumentException("Ha ocurrido un error inesperado");
                }

            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        // Boton Actualizar Tabla Empresa
        private void botonActualizarTabla_Empresa_Click(object sender, RoutedEventArgs e)
        {
            Empresa em = new Empresa();
            ListEmpresa = em.GetEmpresa();
            datagrid_ListaEmpresa.ItemsSource = ListEmpresa;
            datagrid_ListaEmpresa.Items.Refresh();
        }
        // Botones Empresa
        
        // Botones Sucursal
        // Boton Buscar Sucursal
        private void botonBuscar_Sucursal_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Sucursal s1 = new Sucursal()
                {
                    id_sucursal = int.Parse(textID_Sucursal.Text)
                };
                if (s1.ReadScrsl())
                {
                    textID_Sucursal.Text = Convert.ToString(s1.id_sucursal);
                    textCiudad_Sucursal.Text = s1.ciudad_sucursal;
                    textDireccion_Sucursal.Text = s1.direccion_sucursal;
                    textNombre_Sucursal.Text = s1.nombre_sucursal;
                }
                else
                {
                    throw new ArgumentException("Ha ocurrido un error inesperado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        // Boton Modificar Sucursal
        private void botonModificar_Sucursal_Click(object sender, RoutedEventArgs e)
        {
            {
                try
                {
                    Sucursal s1 = new Sucursal()
                    {
                        id_sucursal = int.Parse(textID_Sucursal.Text),
                        ciudad_sucursal = textCiudad_Sucursal.Text,
                        direccion_sucursal = textDireccion_Sucursal.Text,
                        nombre_sucursal = textNombre_Sucursal.Text
                    };
                    if (s1.UpdateScrsl())
                    {
                        MessageBox.Show("Sucursal Actualizada");
                        textID_Sucursal.Text = "";
                        textCiudad_Sucursal.Text = "";
                        textDireccion_Sucursal.Text = "";
                        textNombre_Sucursal.Text = "";
                    }
                    else
                    {
                        throw new ArgumentException("Ha ocurrido un error inesperado");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        
        // Boton Eliminar Sucursal
        private void botonEliminar_Sucursal_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Sucursal s1 = new Sucursal()
                {
                    id_sucursal = int.Parse(textID_Sucursal.Text)
                };
                if (s1.DeleteScrsl())
                {
                    MessageBox.Show("La sucursal se elimino");
                    textID_Sucursal.Text = "";
                    textCiudad_Sucursal.Text = "";
                    textDireccion_Sucursal.Text = "";
                    textNombre_Sucursal.Text = "";
                }
                else
                {
                    throw new ArgumentException("Ha ocurrido un error inesperado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        // Boton Registrar Sucursal
        private void botonRegistrar_Sucursal_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Sucursal s1 = new Sucursal()
                {
                    ciudad_sucursal = textCiudad_Sucursal.Text,
                    direccion_sucursal = textDireccion_Sucursal.Text,
                    nombre_sucursal = textNombre_Sucursal.Text
                };
                if (s1.CreateScrsl())
                {
                    MessageBox.Show("La sucursal se agrego exitosamente");
                    textCiudad_Sucursal.Text = "";
                    textDireccion_Sucursal.Text = "";
                    textNombre_Sucursal.Text = "";
                }
                else
                {
                    throw new ArgumentException("Ha ocurrido un error inesperado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        // Boton Actualizar Tabla Sucursal
        private void botonActualizarTabla_Sucursal_Click(object sender, RoutedEventArgs e)
        {
            Sucursal s1 = new Sucursal();
            ListSucursales = s1.GetSucursales();
            datagrid_ListaSucursal.ItemsSource = ListSucursales;
            datagrid_ListaSucursal.Items.Refresh();
        }
        // Botones Sucursal

        // Botones Principales

        // Boton Principal Empresa (Abre el tabitem"Empresa") 
        private void botonPrincipal_Empresa_Click(object sender, RoutedEventArgs e)
        {
            tab_PrincipalAdmin.SelectedIndex = 0;
        }

        // Boton Principal Sucursal (Abre el tabitem"Sucursal")
        private void botonPrincipal_Sucursal_Click(object sender, RoutedEventArgs e)
        {
            tab_PrincipalAdmin.SelectedIndex = 1;
        }

        // Boton Principal Usuarios (Abre el tabitem"Usuarios")
        private void botonPrincipal_Usuarios_Click(object sender, RoutedEventArgs e)
        {
            tab_PrincipalAdmin.SelectedIndex = 2;
        }

        // Boton Principal Mecanico (Abre el tabitem"Mecanico")
        private void botonPrincipal_Mecanico_Click(object sender, RoutedEventArgs e)
        {
            tab_PrincipalAdmin.SelectedIndex = 3;
        }

        // Boton Cierra la ventana Admin 
        private void botonPrincipal_Cerrar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            this.Close();
            mw.Show();            
        }
        // Botones Principales

        // Botones Pagina Vendedor
        // Botones Vendedor
        // Boton Registrar Vendedor
        private void btn_RegistrarVendedor(object sender, RoutedEventArgs e)
        {
            try
            {
                Vendedor v1 = new Vendedor()
                {
                    rut_vendedor = RutVendedor.Text,
                    nombre_vendedor = NombreVendedor.Text,
                    apellidos_vendedor = ApellidosVendedor.Text,
                    edad_vendedor = int.Parse(EdadVendedor.Text),
                    sexo_vendedor = ComboSexoVendedor.Text,
                    sueldo_vendedor = int.Parse(SueldoVendedor.Text),
                    bono_vendedor = 0,
                    ventas_totales = 0,
                    id_sucursal = int.Parse(ID_Sucursal.Text)
                };
                if (v1.CreateVendedor())
                {
                    MessageBox.Show("El vendedor se ha creado exitosamente");
                    RutVendedor.Text = "";
                    NombreVendedor.Text = "";
                    ApellidosVendedor.Text = "";
                    EdadVendedor.Text = "";
                    ComboSexoVendedor.SelectedIndex = 0;
                    SueldoVendedor.Text = "";
                    ID_Sucursal.Text = "";
                }
                else
                {
                    throw new ArgumentException("Ha ocurrido un error inesperado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Buscar Vendedor
        private void btn_BuscarVendedor(object sender, RoutedEventArgs e)
        {
            try
            {
                Vendedor v1 = new Vendedor()
                {
                    rut_vendedor = RutVendedor.Text
                };
                if (v1.ReadVendedor())
                {
                    RutVendedor.Text = v1.rut_vendedor;
                    NombreVendedor.Text = v1.nombre_vendedor;
                    ApellidosVendedor.Text = v1.apellidos_vendedor;
                    EdadVendedor.Text = Convert.ToString(v1.edad_vendedor);
                    ComboSexoVendedor.Text = v1.sexo_vendedor;
                    SueldoVendedor.Text = Convert.ToString(v1.sueldo_vendedor);
                    ID_Sucursal.Text = Convert.ToString(v1.id_sucursal);
                }
                else
                {
                    throw new ArgumentException("Ha ocurrido un error inesperado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Boton Modificar Vendedor
        private void btn_ModificarVendedor(object sender, RoutedEventArgs e)
        {
            try
            {
                Vendedor v1 = new Vendedor()
                {
                    rut_vendedor =  RutVendedor.Text,
                    nombre_vendedor = NombreVendedor.Text,
                    apellidos_vendedor = ApellidosVendedor.Text,
                    edad_vendedor = int.Parse(EdadVendedor.Text),
                    sexo_vendedor = ComboSexoVendedor.Text,
                    sueldo_vendedor = int.Parse(SueldoVendedor.Text),
                    id_sucursal = int.Parse(ID_Sucursal.Text)
            };
                if (v1.UpdateVendedor())
                {
                    MessageBox.Show("Los datos del vendedor se actualizaron");
                    RutVendedor.Text = "";
                    NombreVendedor.Text = "";
                    ApellidosVendedor.Text = "";
                    EdadVendedor.Text = "";
                    ComboSexoVendedor.SelectedIndex = 0;
                    SueldoVendedor.Text = "";
                    ID_Sucursal.Text = "";
                }
                else
                {
                    throw new ArgumentException("Ha ocurrido un error inesperado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Boton Eliminar Vendedor
        private void btn_EliminarVendedor(object sender, RoutedEventArgs e)
        {
            try
            {
                Vendedor v1 = new Vendedor()
                {
                    rut_vendedor = RutVendedor.Text
                };
                if (v1.DeleteVendedor())
                {
                    MessageBox.Show("¡El vendedor se ha eliminado!");
                    RutVendedor.Text = "";
                    NombreVendedor.Text = "";
                    ApellidosVendedor.Text = "";
                    EdadVendedor.Text = "";
                    ComboSexoVendedor.SelectedIndex = 0;
                    SueldoVendedor.Text = "";
                    ID_Sucursal.Text = "";
                }
                else
                {
                    throw new ArgumentException("Ha ocurrido un error inesperado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Boton Limpiar Datos Vendedor
        private void btn_LimpiarDatosVendedor(object sender, RoutedEventArgs e)
        {
            RutVendedor.Text = "";
            NombreVendedor.Text = "";
            ApellidosVendedor.Text = "";
            EdadVendedor.Text = "";
            ComboSexoVendedor.SelectedIndex = 0;
            SueldoVendedor.Text = "";
            ID_Sucursal.Text = "";
        }

        // Boton actualizar DataGrid Vendedores-Usuarios
        private void btn_ActualizarTabla3(object sender, RoutedEventArgs e)
        {
            Vendedor v1 = new Vendedor();
            Usuario u1 = new Usuario();
            if (ComboLista3.SelectedIndex == 1)
            {
                ListUsuariosAdmin = u1.GetUsuariosAdmin();
                Lista3.ItemsSource = ListUsuariosAdmin;
                Lista3.Items.Refresh();
            }
            if (ComboLista3.SelectedIndex == 2)
            {
                ListUsuariosVendedor = u1.GetUsuariosVendedor();
                Lista3.ItemsSource = ListUsuariosVendedor;
                Lista3.Items.Refresh();
            }
            if (ComboLista3.SelectedIndex == 3)
            {
                ListVendedor = v1.GetVendedores();
                Lista3.ItemsSource = ListVendedor;
                Lista3.Items.Refresh();
            }
        }
        // Botones Vendedor
        
        // Botones Usuarios
        // Boton Crear Usuario Admin o Vendedor
        private void btn_RegistrarUsuarioAoV(object sender, RoutedEventArgs e)
        {
            try
            {
                Usuario u1 = new Usuario()
                {
                    usuario1 = NombreUsuario.Text,
                    contraseña_usuario = ContraseñaUsuario.Password
                };
                if(ComboTipoUsuario.SelectedIndex == 0)
                {
                    MessageBox.Show("Debe elegir el tipo de usuario a crear");
                }
                else if (ComboTipoUsuario.SelectedIndex == 1)
                {
                    if (u1.CreateAdmin())
                    {
                        MessageBox.Show("Se ha creado el usuario administrador");
                        ComboTipoUsuario.SelectedIndex = 0;
                        NombreUsuario.Text = "";
                        ContraseñaUsuario.Password = "";
                    }
                    else
                    {
                        throw new ArgumentException("Ha ocurrido un error inesperado");
                    }
                }
                else if (ComboTipoUsuario.SelectedIndex == 2)
                {
                    if (u1.CreateVendedor()) 
                    {
                        MessageBox.Show("Se ha creado el usuario vendedor");
                        ComboTipoUsuario.SelectedIndex = 0;
                        NombreUsuario.Text = "";
                        ContraseñaUsuario.Password = "";
                    }
                    else
                    {
                        throw new ArgumentException("Ha ocurrido un error inesperado");
                    }
                }
                else
                {
                    throw new ArgumentException("Ha ocurrido un error inesperado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Boton Eliminar Usuario Admin o Vendedor
        private void btn_EliminarUsuarioAoV(object sender, RoutedEventArgs e)
        {
            try
            {
                Usuario u1 = new Usuario()
                {
                    usuario1 = NombreUsuario.Text
                };
                if (ComboTipoUsuario.SelectedIndex == 0)
                {
                    MessageBox.Show("Debe elegir el tipo de usuario a Eliminar");
                }
                else if(ComboTipoUsuario.SelectedIndex == 1)
                {
                    if (u1.DeleteAdmin())
                    {
                        MessageBox.Show("El usuario administrador se ha eliminado");
                        ComboTipoUsuario.SelectedIndex = 0;
                        NombreUsuario.Text = "";
                        ContraseñaUsuario.Password = "";
                    }
                    else
                    {
                        throw new ArgumentException("Ha ocurrido un error inesperado");
                    }
                }
                else if (ComboTipoUsuario.SelectedIndex == 2)
                {
                    if (u1.DeleteVendedor())
                    {
                        MessageBox.Show("El usuario vendedor se ha eliminado");
                        ComboTipoUsuario.SelectedIndex = 0;
                        NombreUsuario.Text = "";
                        ContraseñaUsuario.Password = "";
                    }
                    else
                    {
                        throw new ArgumentException("Ha ocurrido un error inesperado");
                    }
                }
                else
                {
                    throw new ArgumentException("Ha ocurrido un error inesperado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        // Boton Buscar Usuario Admin o Vendedor        
        private void btn_BuscarUsuarioAoV(object sender, RoutedEventArgs e)
        {
            try
            {
                Usuario u1 = new Usuario()
                {
                    usuario1 = NombreUsuario.Text
                };
                if (ComboTipoUsuario.SelectedIndex == 0)
                {
                    MessageBox.Show("Debe elegir el tipo de usuario a buscar");
                }
                else if (ComboTipoUsuario.SelectedIndex == 1)
                {
                    if(u1.ReadAdmin())
                    {
                        MessageBox.Show("Mostrando los datos del usuario administrador");
                        ListUsuariosAdmin = u1.GetUsuariosAdmin();
                        Lista3.ItemsSource = ListUsuariosAdmin;
                        Lista3.Items.Refresh();
                        NombreUsuario.Text = u1.usuario1;
                        ContraseñaUsuario.Password = u1.contraseña_usuario;
                    }
                    else
                    {
                        throw new ArgumentException("Ha ocurrido un error inesperado");
                    }
                }
                else if (ComboTipoUsuario.SelectedIndex == 2)
                {
                    if (u1.ReadVendedor())
                    {
                        MessageBox.Show("Mostrando los datos del usuario vendedor");
                        ListUsuariosVendedor = u1.GetUsuariosVendedor();
                        Lista3.ItemsSource = ListUsuariosVendedor;
                        Lista3.Items.Refresh();
                        NombreUsuario.Text = u1.usuario1;
                        ContraseñaUsuario.Password = u1.contraseña_usuario;                        
                    }
                    else
                    {
                        throw new ArgumentException("Ha ocurrido un error inesperado");
                    }
                }
                else
                {
                    throw new ArgumentException("Ha ocurrido un error inesperado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Boton Modificar Contraseña Usuario Administrador o Vendedor
        private void btn_ModificarContraseñaUsuarioAoV(object sender, RoutedEventArgs e)
        {
            try
            {
                Usuario u1 = new Usuario()
                {
                    usuario1 = NombreUsuario.Text,
                    contraseña_usuario = ContraseñaUsuario.Password
                };
                if (ComboTipoUsuario.SelectedIndex == 0)
                {
                    MessageBox.Show("Debe elegir el tipo de usuario para modificar la contraseña");
                }
                else if (ComboTipoUsuario.SelectedIndex == 1)
                {
                    if (u1.ReadAdmin())
                    {
                        MessageBox.Show("La contraseña del usuario administrador se ha actualizado");
                        NombreUsuario.Text = "";
                        ContraseñaUsuario.Password = "";
                    }
                    else
                    {
                        throw new ArgumentException("Ha ocurrido un error inesperado");
                    }
                }
                else if (ComboTipoUsuario.SelectedIndex == 2)
                {
                    if (u1.ReadVendedor())
                    {
                        MessageBox.Show("Se han actualizado los datos del usuario vendedor");
                        NombreUsuario.Text = "";
                        ContraseñaUsuario.Password = "";
                    }
                    else
                    {
                        throw new ArgumentException("Ha ocurrido un error inesperado");
                    }
                }
                else
                {
                    throw new ArgumentException("Ha ocurrido un error inesperado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // Botones Usuario        
        // Botones Pagina Vendedor
        
        // Botones Pagina Mecanico
        // Boton Registrar Mecanico
        private void btn_RegistrarMecanico(object sender, RoutedEventArgs e)
        {
            try
            {
                Mecanico m1 = new Mecanico()
                {
                    rut_mecanico = RutMecanico.Text,
                    nombre_mecanico = NombreMecanico.Text,
                    apellido_vendedor = ApellidoMecanico.Text,
                    edad_mecanico = int.Parse(EdadMecanico.Text),
                    sexo_mecanico = ComboSexoMecanico.Text,
                    sueldo_mecanico = int.Parse(SueldoMecanico.Text),
                    id_sucursal = int.Parse(IDMecanico.Text)
                };
                if(m1.CreateMecanico())
                {
                    MessageBox.Show("Se ha creado el mecanico");
                    RutMecanico.Text = "";
                    NombreMecanico.Text = "";
                    ApellidoMecanico.Text = "";
                    EdadMecanico.Text = "";
                    ComboSexoMecanico.SelectedIndex = 0;
                    SueldoMecanico.Text = "";
                    IDMecanico.Text = "";
                }
                else
                {
                    throw new ArgumentException("Ha ocurrido un error inesperado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Boton Modificar Mecanico
        private void btn_ModificarMecanico(object sender, RoutedEventArgs e)
        {
            try
            {
                Mecanico m1 = new Mecanico()
                {
                    rut_mecanico = RutMecanico.Text,
                    nombre_mecanico = NombreMecanico.Text,
                    apellido_vendedor = ApellidoMecanico.Text,
                    edad_mecanico = int.Parse(EdadMecanico.Text),
                    sexo_mecanico = ComboSexoMecanico.Text,
                    sueldo_mecanico = int.Parse(SueldoMecanico.Text),
                    id_sucursal = int.Parse(IDMecanico.Text)
                };
                if (m1.UpdateMecanico())
                {
                    MessageBox.Show("Los datos del Mecanico se han actualizado");
                    RutMecanico.Text = "";
                    NombreMecanico.Text = "";
                    ApellidoMecanico.Text = "";
                    EdadMecanico.Text = "";
                    ComboSexoMecanico.SelectedIndex = 0;
                    SueldoMecanico.Text = "";
                    IDMecanico.Text = "";
                }
                else
                {
                    throw new ArgumentException("Ha ocurrido un error inesperado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Boton Eliminar Mecanico
        private void btn_EliminarMecanico(object sender, RoutedEventArgs e)
        {
            try
            {
                Mecanico m1 = new Mecanico()
                {
                    rut_mecanico = RutMecanico.Text
                };
                if(m1.DeleteMecanico())
                {
                    MessageBox.Show("El mecanico se ha eliminado");
                    RutMecanico.Text = "";
                    NombreMecanico.Text = "";
                    ApellidoMecanico.Text = "";
                    EdadMecanico.Text = "";
                    ComboSexoMecanico.SelectedIndex = 0;
                    SueldoMecanico.Text = "";
                    IDMecanico.Text = "";
                }
                else
                {
                    throw new ArgumentException("Ha ocurrido un error inesperado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Boton Buscar Mecanico
        private void btn_BuscarMecanico(object sender, RoutedEventArgs e)
        {
            try
            {
                Mecanico m1 = new Mecanico()
                {
                    rut_mecanico = RutMecanico.Text
                };
                if (m1.ReadMecanico())
                {
                    RutMecanico.Text = m1.rut_mecanico;
                    NombreMecanico.Text = m1.nombre_mecanico;
                    ApellidoMecanico.Text = m1.apellido_vendedor;
                    EdadMecanico.Text = Convert.ToString(m1.edad_mecanico);
                    ComboSexoMecanico.Text = m1.sexo_mecanico;
                    SueldoMecanico.Text = Convert.ToString(m1.sueldo_mecanico);
                    IDMecanico.Text = Convert.ToString(m1.id_sucursal);
                }
                else
                {
                    throw new ArgumentException("Ha ocurrido un error inesperado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Boton Actualizar Lista Mecanicos
        private void btn_ActualizarTablaMecanicos(object sender, RoutedEventArgs e)
        {
            Mecanico m1 = new Mecanico();
            ListMecanicos = m1.GetMecanicos();
            DataGridMecanicos.ItemsSource = ListMecanicos;
            DataGridMecanicos.Items.Refresh();
        }
        // Botones Pagina Mecanico
    }
}
