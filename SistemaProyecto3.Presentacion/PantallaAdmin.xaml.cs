using SistemaProyecto3.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
        //Variable para validar si se abre ventana Main
        private bool valor = false;

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

            //Esconder labels
            lblRut.Visibility = Visibility.Hidden;
        }

        // Campos solo numeros
        private void SoloNumeros(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        //  Boton Crear Empresa
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            try
            {
                Empresa empresaValidaciones = new Empresa();
                if (textNombre_Empresa.Text.Length == 0 || textRut_Empresa.Text.Length == 0 ||
                    textContacto_Empresa.Text.Length == 0 || textDireccion_Empresa.Text.Length == 0)
                {
                    MessageBox.Show("Uno o más campos estan vacíos");
                }
                else if (textContacto_Empresa.Text.Length < 8)
                {
                    MessageBox.Show("El contacto debe tener 8 digitos");
                }
                else if (textRut_Empresa.Text.Length < 2)
                {
                    MessageBox.Show("Debe ingresar un rut válido");
                }
                else
                {
                    string rutSinDv = textRut_Empresa.Text.Substring(0, textRut_Empresa.Text.Length - 2);
                    string dv = textRut_Empresa.Text.Substring(textRut_Empresa.Text.Length - 1, 1);
                    string rutSinGuion = rutSinDv + dv;
                    if (textRut_Empresa.Text != String.Format("{0}-{1}", rutSinDv, dv))
                    {
                        lblRut.Visibility = Visibility.Visible;
                    }
                    else if (!empresaValidaciones.ValidarRut(textRut_Empresa.Text.ToUpper()))
                    {
                        MessageBox.Show("El rut no es válido");
                    }
                    else if (empresaValidaciones.GetEmpresa().Any(c => c.rut_empresa == textRut_Empresa.Text.ToUpper()))
                    {
                        MessageBox.Show("El rut de empresa ya existe");
                    }
                    else
                    {
                        Empresa em = new Empresa()
                        {
                            rut_empresa = textRut_Empresa.Text.ToUpper(),
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
                        else
                        {
                            throw new ArgumentException("Ha ocurrido un error inesperado");
                        }
                    }
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
                Empresa empresaValidaciones = new Empresa();
                if (empresaValidaciones.GetEmpresa().Count == 0)
                {
                    MessageBox.Show("Aún no hay empresas");
                }
                else if (textRut_Empresa.Text == "")
                {
                    MessageBox.Show("Ingrese el rut que desea eliminar");
                }
                else if (textRut_Empresa.Text.Length < 2)
                {
                    MessageBox.Show("Debe ingresar un rut válido");
                }
                else
                {
                    string rutSinDv = textRut_Empresa.Text.Substring(0, textRut_Empresa.Text.Length - 2);
                    string dv = textRut_Empresa.Text.Substring(textRut_Empresa.Text.Length - 1, 1);
                    string rutSinGuion = rutSinDv + dv;
                    if (textRut_Empresa.Text != String.Format("{0}-{1}", rutSinDv, dv))
                    {
                        lblRut.Visibility = Visibility.Visible;
                    }
                    else if (!empresaValidaciones.ValidarRut(textRut_Empresa.Text.ToUpper()))
                    {
                        MessageBox.Show("El rut no es válido");
                    }
                    else if (!empresaValidaciones.GetEmpresa().Any(c => c.rut_empresa == textRut_Empresa.Text.ToUpper()))
                    {
                        MessageBox.Show("El rut de empresa no existe");
                    }
                    else
                    {
                        Empresa em = new Empresa()
                        {
                            rut_empresa = textRut_Empresa.Text.ToUpper()
                        };
                        if (em.DeleteEmpresa())
                        {
                            MessageBox.Show("Empresa Eliminada");
                            textRut_Empresa.Text = "";
                            textNombre_Empresa.Text = "";
                            textContacto_Empresa.Text = "";
                            textDireccion_Empresa.Text = "";
                        }
                        else
                        {
                            throw new ArgumentException("Ha ocurrido un error inesperado");
                        }
                    }
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
                if (textNombre_Empresa.Text.Length == 0 || textRut_Empresa.Text.Length == 0 ||
                    textContacto_Empresa.Text.Length == 0 || textDireccion_Empresa.Text.Length == 0)
                {
                    MessageBox.Show("Uno o más campos estan vacíos");
                }
                else if (textContacto_Empresa.Text.Length < 8)
                {
                    MessageBox.Show("El contacto debe tener 8 digitos");
                }
                else if (textRut_Empresa.Text.Length < 2)
                {
                    MessageBox.Show("Debe ingresar un rut válido");
                }
                else
                {
                    Empresa empresaValidaciones = new Empresa();
                    string rutSinDv = textRut_Empresa.Text.Substring(0, textRut_Empresa.Text.Length - 2);
                    string dv = textRut_Empresa.Text.Substring(textRut_Empresa.Text.Length - 1, 1);
                    string rutSinGuion = rutSinDv + dv;
                    if (textRut_Empresa.Text != String.Format("{0}-{1}", rutSinDv, dv))
                    {
                        lblRut.Visibility = Visibility.Visible;
                    }
                    else if (!empresaValidaciones.GetEmpresa().Any(c => c.rut_empresa == textRut_Empresa.Text.ToUpper()))
                    {
                        MessageBox.Show("El rut de empresa no existe");
                    }
                    else
                    {
                        Empresa em = new Empresa()
                        {
                            rut_empresa = textRut_Empresa.Text.ToUpper(),
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
                        else
                        {
                            MessageBox.Show("Ha ocurrido un error inesperado");
                        }
                    }
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
                Empresa empresaValidaciones = new Empresa();
                if (empresaValidaciones.GetEmpresa().Count == 0)
                {
                    MessageBox.Show("Aún no hay empresas");
                }
                else if (textRut_Empresa.Text == "")
                {
                    MessageBox.Show("Ingrese rut para llenar campos");
                }
                else if (textRut_Empresa.Text.Length < 2)
                {
                    MessageBox.Show("Debe ingresar un rut válido");
                }
                else
                {
                    string rutSinDv = textRut_Empresa.Text.Substring(0, textRut_Empresa.Text.Length - 2);
                    string dv = textRut_Empresa.Text.Substring(textRut_Empresa.Text.Length - 1, 1);
                    string rutSinGuion = rutSinDv + dv;
                    if (textRut_Empresa.Text != String.Format("{0}-{1}", rutSinDv, dv))
                    {
                        lblRut.Visibility = Visibility.Visible;
                    }
                    else if (!empresaValidaciones.GetEmpresa().Any(c => c.rut_empresa == textRut_Empresa.Text.ToUpper()))
                    {
                        MessageBox.Show("El rut de empresa no existe");
                    }
                    else
                    {
                        Empresa em = new Empresa()
                        {
                            rut_empresa = textRut_Empresa.Text.ToUpper()
                        };
                        if (em.searchEmpresa())
                        {
                            textRut_Empresa.Text = em.rut_empresa;
                            textNombre_Empresa.Text = em.nombre_empresa;
                            textContacto_Empresa.Text = Convert.ToString(em.contacto);
                            textDireccion_Empresa.Text = em.direccion;
                        }

                        else
                        {
                            throw new ArgumentException("Ha ocurrido un error inesperado");
                        }
                    }
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
                Sucursal sucursalValidaciones = new Sucursal();
                if (sucursalValidaciones.GetSucursales().Count == 0)
                {
                    MessageBox.Show("Aún no hay sucursales");
                }
                else if (textID_Sucursal.Text.Length == 0)
                {
                    MessageBox.Show("Ingrese el numero de sucursal para llenar campos");
                }
                else if (!sucursalValidaciones.GetSucursales().Any(c => c.id_sucursal == int.Parse(textID_Sucursal.Text)))
                {
                    MessageBox.Show("El id ingresado no corresponde a ninguna sucursal");
                }
                else
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        // Boton Modificar Sucursal
        private void botonModificar_Sucursal_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (textID_Sucursal.Text.Length == 0 || textNombre_Sucursal.Text.Length == 0 ||
                   textCiudad_Sucursal.Text.Length == 0 || textDireccion_Sucursal.Text.Length == 0)
                {
                    MessageBox.Show("Uno o más campos estan vacíos");
                }
                else if (textID_Sucursal.Text == "0")
                {
                    MessageBox.Show("Debe ingresar un id mayor a 0");
                }
                else
                {
                    Sucursal sucursalValidaciones = new Sucursal()
                    {
                        id_sucursal = int.Parse(textID_Sucursal.Text)
                    };
                    if (!sucursalValidaciones.GetSucursales().Any(c => c.id_sucursal == int.Parse(textID_Sucursal.Text)))
                    {
                        MessageBox.Show("El id ingresado no corresponde a ninguna sucursal");
                    }
                    else
                    {
                        if (sucursalValidaciones.ReadScrsl())
                        {
                            if (sucursalValidaciones.nombre_sucursal != textNombre_Sucursal.Text)
                            {
                                if (sucursalValidaciones.GetSucursales().Any(c => c.nombre_sucursal == textNombre_Sucursal.Text))
                                {
                                    MessageBox.Show("El nombre de la sucursal ya existe");
                                }
                                else
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
                            }
                            else
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
                        }
                        else
                        {
                            throw new ArgumentException("No se ha logrado obtener los datos de la sucursal ingresada");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        // Boton Eliminar Sucursal
        private void botonEliminar_Sucursal_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Sucursal sucursalValidaciones = new Sucursal();
                if (sucursalValidaciones.GetSucursales().Count == 0)
                {
                    MessageBox.Show("Aún no hay sucursales");
                }
                else if (textID_Sucursal.Text.Length == 0)
                {
                    MessageBox.Show("Debe ingresar el id de la sucursal a eliminar");
                }
                else if (textID_Sucursal.Text == "0")
                {
                    MessageBox.Show("El id de la sucursal debe ser mayor a 0");
                }
                else if (!sucursalValidaciones.GetSucursales().Any(c => c.id_sucursal == int.Parse(textID_Sucursal.Text)))
                {
                    MessageBox.Show("El id ingresado no corresponde a ninguna sucursal");
                }
                else
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
                Sucursal sucursalValidaciones = new Sucursal();
                if (textID_Sucursal.Text.Length == 0 || textNombre_Sucursal.Text.Length == 0 || 
                    textCiudad_Sucursal.Text.Length == 0 || textDireccion_Sucursal.Text.Length == 0)
                {
                    MessageBox.Show("Uno o más campos estan vacíos");
                }
                else if (textID_Sucursal.Text == "0")
                {
                    MessageBox.Show("Debe ingresar un id mayor a 0");
                }
                else if (sucursalValidaciones.GetSucursales().Any(c => c.id_sucursal == int.Parse(textID_Sucursal.Text)))
                {
                    MessageBox.Show("El id de la sucursal ya existe");
                }
                else if (sucursalValidaciones.GetSucursales().Any(c => c.nombre_sucursal == textNombre_Sucursal.Text))
                {
                    MessageBox.Show("El nombre de la sucursal ya existe");
                }
                else
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
            //ComboBox Sucursales || Vendedor
            Sucursal suc = new Sucursal();
            ComboIDSucursal.ItemsSource = suc.GetIDSucursales();
            ComboIDSucursal.Items.Refresh();
        }

        // Boton Principal Mecanico (Abre el tabitem"Mecanico")
        private void botonPrincipal_Mecanico_Click(object sender, RoutedEventArgs e)
        {
            tab_PrincipalAdmin.SelectedIndex = 3;
            Sucursal suc = new Sucursal();
            ComboIDSucursalMecanico.ItemsSource = suc.GetIDSucursales();
            ComboIDSucursalMecanico.Items.Refresh();
        }

        // Boton Cierra la ventana Admin 
        private void botonPrincipal_Cerrar_Click(object sender, RoutedEventArgs e)
        {
            valor = true;
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }
        // Botones Principales

        // Botones Pagina Vendedor
        // Botones Vendedor
        // Boton Registrar Vendedor
        private void btn_RegistrarVendedor(object sender, RoutedEventArgs e)
        {
            try
            {
                if (RutVendedor.Text.Length == 0 || NombreVendedor.Text.Length == 0 || 
                    ApellidosVendedor.Text.Length == 0 || EdadVendedor.Text.Length == 0 ||
                    ComboSexoVendedor.SelectedIndex == 0 || SueldoVendedor.Text.Length == 0 ||
                    ComboIDSucursal.SelectedIndex == -1)
                {
                    MessageBox.Show("Uno o más campos estan vacíos");
                }
                else if (int.Parse(EdadVendedor.Text) < 18)
                {
                    MessageBox.Show("El vendedor debe ser mayor de edad");
                }
                else if (int.Parse(SueldoVendedor.Text) < 150000)
                {
                    MessageBox.Show("El sueldo no puede ser menor a $150.000");
                }
                else if (RutVendedor.Text.Length < 2)
                {
                    MessageBox.Show("Debe ingresar un rut válido");
                }
                else
                {
                    Vendedor vendedorValidaciones = new Vendedor();
                    string rutSinDv = RutVendedor.Text.Substring(0, RutVendedor.Text.Length - 2);
                    string dv = RutVendedor.Text.Substring(RutVendedor.Text.Length - 1, 1);
                    string rutSinGuion = rutSinDv + dv;
                    if (RutVendedor.Text != String.Format("{0}-{1}", rutSinDv, dv))
                    {
                        MessageBox.Show("Debe ingresar rut sin puntos y con guion\nEjemplo: 99999999-9");
                    }
                    else if (!vendedorValidaciones.ValidarRut(RutVendedor.Text.ToUpper()))
                    {
                        MessageBox.Show("El rut ingresado no es válido");
                    }
                    else if (vendedorValidaciones.GetVendedores().Any(c => c.rut_vendedor == RutVendedor.Text.ToUpper()))
                    {
                        MessageBox.Show("El rut ingresado ya esta asociado a otro vendedor");
                    }
                    else
                    {
                        Vendedor v1 = new Vendedor()
                        {
                            rut_vendedor = RutVendedor.Text.ToUpper(),
                            nombre_vendedor = NombreVendedor.Text,
                            apellidos_vendedor = ApellidosVendedor.Text,
                            edad_vendedor = int.Parse(EdadVendedor.Text),
                            sexo_vendedor = ComboSexoVendedor.Text,
                            sueldo_vendedor = int.Parse(SueldoVendedor.Text),
                            bono_vendedor = 0,
                            ventas_totales = 0,
                            id_sucursal = int.Parse(ComboIDSucursal.Text)
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
                            ComboIDSucursal.SelectedIndex = -1;
                        }
                        else
                        {
                            throw new ArgumentException("Ha ocurrido un error inesperado");
                        }
                    }
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
                Vendedor vendedorValidaciones = new Vendedor();
                if (vendedorValidaciones.GetVendedores().Count == 0)
                {
                    MessageBox.Show("Aún no hay vendedores");
                }
                else if (RutVendedor.Text.Length == 0)
                {
                    MessageBox.Show("Ingrese rut para llenar campos");
                }
                else if (RutVendedor.Text.Length < 2)
                {
                    MessageBox.Show("Debe ingresar un rut válido");
                }
                else
                {
                    string rutSinDv = RutVendedor.Text.Substring(0, RutVendedor.Text.Length - 2);
                    string dv = RutVendedor.Text.Substring(RutVendedor.Text.Length - 1, 1);
                    string rutSinGuion = rutSinDv + dv;
                    if (RutVendedor.Text != String.Format("{0}-{1}", rutSinDv, dv))
                    {
                        MessageBox.Show("Debe ingresar rut sin puntos y con guion\nEjemplo: 99999999-9");
                    }
                    else if (!vendedorValidaciones.ValidarRut(RutVendedor.Text.ToUpper()))
                    {
                        MessageBox.Show("El rut ingresado no es válido");
                    }
                    else if (!vendedorValidaciones.GetVendedores().Any(c => c.rut_vendedor == RutVendedor.Text.ToUpper()))
                    {
                        MessageBox.Show("El rut ingresado no existe");
                    }
                    else
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
                            ComboIDSucursal.Text = v1.id_sucursal.ToString();
                        }
                        else
                        {
                            throw new ArgumentException("Ha ocurrido un error inesperado");
                        }
                    }
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
                Vendedor vendedorValidaciones = new Vendedor();
                if (vendedorValidaciones.GetVendedores().Count == 0)
                {
                    MessageBox.Show("Debe existir al menos un vendedor para modificarlo");
                }
                else if (RutVendedor.Text.Length == 0)
                {
                    MessageBox.Show("Ingrese rut para modifcar vendedor");
                }
                else if (RutVendedor.Text.Length < 2)
                {
                    MessageBox.Show("Debe ingresar un rut válido");
                }
                else
                {
                    string rutSinDv = RutVendedor.Text.Substring(0, RutVendedor.Text.Length - 2);
                    string dv = RutVendedor.Text.Substring(RutVendedor.Text.Length - 1, 1);
                    string rutSinGuion = rutSinDv + dv;
                    if (RutVendedor.Text != String.Format("{0}-{1}", rutSinDv, dv))
                    {
                        MessageBox.Show("Debe ingresar rut sin puntos y con guion\nEjemplo: 99999999-9");
                    }
                    else if (!vendedorValidaciones.ValidarRut(RutVendedor.Text.ToUpper()))
                    {
                        MessageBox.Show("El rut ingresado no es válido");
                    }
                    else if (!vendedorValidaciones.GetVendedores().Any(c => c.rut_vendedor == RutVendedor.Text.ToUpper()))
                    {
                        MessageBox.Show("El rut ingresado no existe");
                    }
                    else
                    {
                        if (NombreVendedor.Text.Length == 0 || ApellidosVendedor.Text.Length == 0 ||
                            EdadVendedor.Text.Length == 0 || ComboSexoVendedor.SelectedIndex == 0 ||
                            SueldoVendedor.Text.Length == 0 || ComboIDSucursal.SelectedIndex == -1)
                        {
                            MessageBox.Show("Uno o más campos estan vacíos");
                        }
                        else if (int.Parse(EdadVendedor.Text) < 18)
                        {
                            MessageBox.Show("El vendedor debe ser mayor de edad");
                        }
                        else if (int.Parse(SueldoVendedor.Text) < 150000)
                        {
                            MessageBox.Show("El sueldo no puede ser menor a $150.000");
                        }
                        else
                        {
                            Vendedor v1 = new Vendedor()
                            {
                                rut_vendedor = RutVendedor.Text,
                                nombre_vendedor = NombreVendedor.Text,
                                apellidos_vendedor = ApellidosVendedor.Text,
                                edad_vendedor = int.Parse(EdadVendedor.Text),
                                sexo_vendedor = ComboSexoVendedor.Text,
                                sueldo_vendedor = int.Parse(SueldoVendedor.Text),
                                id_sucursal = int.Parse(ComboIDSucursal.Text)
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
                                ComboIDSucursal.SelectedIndex = -1;
                            }
                            else
                            {
                                throw new ArgumentException("Ha ocurrido un error inesperado");
                            }
                        }
                    }
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
                Vendedor vendedorValidaciones = new Vendedor();
                if (vendedorValidaciones.GetVendedores().Count == 0)
                {
                    MessageBox.Show("Debe existir al menos un vendedor para eliminarlo");
                }
                else if (RutVendedor.Text.Length == 0)
                {
                    MessageBox.Show("Ingrese rut para eliminar vendedor");
                }
                else if (RutVendedor.Text.Length < 2)
                {
                    MessageBox.Show("Debe ingresar un rut válido");
                }
                else
                {
                    string rutSinDv = RutVendedor.Text.Substring(0, RutVendedor.Text.Length - 2);
                    string dv = RutVendedor.Text.Substring(RutVendedor.Text.Length - 1, 1);
                    string rutSinGuion = rutSinDv + dv;
                    if (RutVendedor.Text != String.Format("{0}-{1}", rutSinDv, dv))
                    {
                        MessageBox.Show("Debe ingresar rut sin puntos y con guion\nEjemplo: 99999999-9");
                    }
                    else if (!vendedorValidaciones.ValidarRut(RutVendedor.Text.ToUpper()))
                    {
                        MessageBox.Show("El rut ingresado no es válido");
                    }
                    else if (!vendedorValidaciones.GetVendedores().Any(c => c.rut_vendedor == RutVendedor.Text.ToUpper()))
                    {
                        MessageBox.Show("El rut ingresado no existe");
                    }
                    else
                    {
                        Vendedor v1 = new Vendedor()
                        {
                            rut_vendedor = RutVendedor.Text
                        };
                        if (v1.DeleteVendedor())
                        {
                            MessageBox.Show("El vendedor se ha eliminado");
                            RutVendedor.Text = "";
                            NombreVendedor.Text = "";
                            ApellidosVendedor.Text = "";
                            EdadVendedor.Text = "";
                            ComboSexoVendedor.SelectedIndex = 0;
                            SueldoVendedor.Text = "";
                            ComboIDSucursal.SelectedIndex = -1;
                        }
                        else
                        {
                            throw new ArgumentException("Ha ocurrido un error inesperado");
                        }
                    }
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
            ComboIDSucursal.SelectedIndex = -1;
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
                Usuario usuarioValidaciones = new Usuario();
                if (NombreUsuario.Text.Length == 0 || ContraseñaUsuario.Password.Length == 0)
                {
                    MessageBox.Show("Uno o más campos estan vacíos");
                }
                else if (ContraseñaUsuario.Password.Length != 4)
                {
                    MessageBox.Show("La contraseña debe ser de 4 caracteres");
                }
                else if (usuarioValidaciones.GetUsuarios().Any(c => c.usuario1 == NombreUsuario.Text))
                {
                    MessageBox.Show("El nombre de usuario ya existe");
                }
                else
                {
                    Usuario u1 = new Usuario()
                    {
                        usuario1 = NombreUsuario.Text,
                        contraseña_usuario = ContraseñaUsuario.Password
                    };
                    if (ComboTipoUsuario.SelectedIndex == 0)
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
                Usuario usuarioValidaciones = new Usuario();
                if (usuarioValidaciones.GetUsuarios().Count == 0)
                {
                    MessageBox.Show("Debe existir al menos un usuario para eliminarlo");
                }
                if (NombreUsuario.Text.Length == 0)
                {
                    MessageBox.Show("Debe ingresar el nombre de usuario para eliminarlo");
                }
                else if (!usuarioValidaciones.GetUsuarios().Any(c => c.usuario1 == NombreUsuario.Text))
                {
                    MessageBox.Show("El usuario no existe");
                }
                else
                {
                    Usuario u1 = new Usuario()
                    {
                        usuario1 = NombreUsuario.Text
                    };
                    if (u1.DeleteUsuario())
                    {
                        MessageBox.Show("El usuario se ha eliminado");
                        ComboTipoUsuario.SelectedIndex = 0;
                        NombreUsuario.Text = "";
                        ContraseñaUsuario.Password = "";
                    }
                    else
                    {
                        throw new ArgumentException("Ha ocurrido un error inesperado");
                    }
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
                Usuario usuarioValidaciones = new Usuario();
                if (usuarioValidaciones.GetUsuarios().Count == 0)
                {
                    MessageBox.Show("Debe existir al menos un usuario para buscar");
                }
                if (NombreUsuario.Text.Length == 0)
                {
                    MessageBox.Show("Debe ingresar el nombre de usuario para actualizar campos");
                }
                else if (!usuarioValidaciones.GetUsuarios().Any(c => c.usuario1 == NombreUsuario.Text))
                {
                    MessageBox.Show("El usuario no existe");
                }
                else
                {
                    Usuario u1 = new Usuario()
                    {
                        usuario1 = NombreUsuario.Text
                    };
                    if (u1.ReadUsuarios())
                    {
                        if (u1.tipo_usuario == 1)
                        {
                            MessageBox.Show("Mostrando los datos del usuario administrador");
                            ComboTipoUsuario.SelectedIndex = 1;
                        }
                        else if (u1.tipo_usuario == 2)
                        {
                            MessageBox.Show("Mostrando los datos del usuario Vendedor");
                            ComboTipoUsuario.SelectedIndex = 2;
                        }
                        NombreUsuario.Text = u1.usuario1;
                        ContraseñaUsuario.Password = u1.contraseña_usuario;
                    }
                    else
                    {
                        throw new ArgumentException("Ha ocurrido un error inesperado");
                    }
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
                Usuario usuarioValidaciones = new Usuario();
                if (usuarioValidaciones.GetUsuarios().Count == 0)
                {
                    MessageBox.Show("Debe existir al menos un usuario para modificar la contraseña");
                }
                if (NombreUsuario.Text.Length == 0)
                {
                    MessageBox.Show("Debe ingresar el nombre de usuario para modificar su contraseña");
                }
                else if (!usuarioValidaciones.GetUsuarios().Any(c => c.usuario1 == NombreUsuario.Text))
                {
                    MessageBox.Show("El usuario no existe");
                }
                else if (ComboTipoUsuario.SelectedIndex == 0)
                {
                    MessageBox.Show("Debe escoger un tipo de usuario");
                }
                else
                {
                    Usuario u1 = new Usuario()
                    {
                        tipo_usuario = ComboTipoUsuario.SelectedIndex, 
                        usuario1 = NombreUsuario.Text,
                        contraseña_usuario = ContraseñaUsuario.Password
                    };
                    if (u1.UpdatePass())
                    {
                        MessageBox.Show("El usuario se ha actualizado");
                        ComboTipoUsuario.SelectedIndex = 0;
                        NombreUsuario.Text = "";
                        ContraseñaUsuario.Password = "";
                    }
                    else
                    {
                        throw new ArgumentException("Ha ocurrido un error inesperado");
                    }
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
                if (RutMecanico.Text.Length == 0 || NombreMecanico.Text.Length == 0 ||
                    ApellidoMecanico.Text.Length == 0 || SueldoMecanico.Text.Length == 0 ||
                    EdadMecanico.Text.Length == 0)
                {
                    MessageBox.Show("Uno o más campos estan vacíos");
                }
                else if (ComboSexoMecanico.SelectedIndex == 0)
                {
                    MessageBox.Show("Debe seleccionar el sexo del mecanico");
                }
                else if (int.Parse(SueldoMecanico.Text) < 150000)
                {
                    MessageBox.Show("El sueldo no puede ser menor a $150.000");
                }
                else if (int.Parse(EdadMecanico.Text) < 18)
                {
                    MessageBox.Show("El mecanico debe ser mayor de edad");
                }
                else if (ComboIDSucursalMecanico.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar la sucursal asignada al mecanico");
                }
                else
                {
                    Mecanico mecanicoValidaciones = new Mecanico();
                    string rutSinDv = RutMecanico.Text.Substring(0, RutMecanico.Text.Length - 2);
                    string dv = RutMecanico.Text.Substring(RutMecanico.Text.Length - 1, 1);
                    string rutSinGuion = rutSinDv + dv;
                    if (RutMecanico.Text != String.Format("{0}-{1}", rutSinDv, dv))
                    {
                        MessageBox.Show("Debe ingresar rut sin puntos y con guion\nEjemplo: 99999999-9");
                    }
                    else if (!mecanicoValidaciones.ValidarRut(RutMecanico.Text.ToUpper()))
                    {
                        MessageBox.Show("El rut no es válido");
                    }
                    else if (mecanicoValidaciones.GetMecanicos().Any(c => c.rut_mecanico == RutMecanico.Text.ToUpper()))
                    {
                        MessageBox.Show("Ya hay un mecanico con ese rut");
                    }
                    else
                    {
                        Mecanico m1 = new Mecanico()
                        {
                            rut_mecanico = RutMecanico.Text,
                            nombre_mecanico = NombreMecanico.Text,
                            apellido_vendedor = ApellidoMecanico.Text,
                            edad_mecanico = int.Parse(EdadMecanico.Text),
                            sexo_mecanico = ComboSexoMecanico.Text,
                            sueldo_mecanico = int.Parse(SueldoMecanico.Text),
                            id_sucursal = int.Parse(ComboIDSucursalMecanico.Text)
                        };
                        if (m1.CreateMecanico())
                        {
                            MessageBox.Show("Se ha creado el mecanico");
                            RutMecanico.Text = "";
                            NombreMecanico.Text = "";
                            ApellidoMecanico.Text = "";
                            EdadMecanico.Text = "";
                            ComboSexoMecanico.SelectedIndex = 0;
                            SueldoMecanico.Text = "";
                            ComboIDSucursalMecanico.SelectedIndex = -1;
                        }
                        else
                        {
                            throw new ArgumentException("Ha ocurrido un error inesperado");
                        }
                    }
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
                Mecanico mecanicoValidaciones = new Mecanico();
                if (mecanicoValidaciones.GetMecanicos().Count == 0)
                {
                    MessageBox.Show("Debe existir al menos un mecanico para modificar");
                }
                else if (RutMecanico.Text.Length == 0)
                {
                    MessageBox.Show("Ingrese rut para modificar mecanico");
                }
                else if (RutMecanico.Text.Length < 2)
                {
                    MessageBox.Show("Debe ingresar un rut válido");
                }
                else
                {
                    string rutSinDv = RutMecanico.Text.Substring(0, RutMecanico.Text.Length - 2);
                    string dv = RutMecanico.Text.Substring(RutMecanico.Text.Length - 1, 1);
                    string rutSinGuion = rutSinDv + dv;
                    if (RutMecanico.Text != String.Format("{0}-{1}", rutSinDv, dv))
                    {
                        MessageBox.Show("Debe ingresar rut sin puntos y con guion\nEjemplo: 99999999-9");
                    }
                    else if (!mecanicoValidaciones.ValidarRut(RutMecanico.Text.ToUpper()))
                    {
                        MessageBox.Show("El rut no es válido");
                    }
                    else if (!mecanicoValidaciones.GetMecanicos().Any(c => c.rut_mecanico == RutMecanico.Text.ToUpper()))
                    {
                        MessageBox.Show("El rut ingresado no existe");
                    }
                    else
                    {
                        if (NombreMecanico.Text.Length == 0 || ApellidoMecanico.Text.Length == 0 || 
                            SueldoMecanico.Text.Length == 0 || EdadMecanico.Text.Length == 0)
                        {
                            MessageBox.Show("Uno o más campos estan vacíos");
                        }
                        else if (ComboSexoMecanico.SelectedIndex == 0)
                        {
                            MessageBox.Show("Debe seleccionar el sexo del mecanico");
                        }
                        else if (int.Parse(SueldoMecanico.Text) < 150000)
                        {
                            MessageBox.Show("El sueldo no puede ser menor a $150.000");
                        }
                        else if (int.Parse(EdadMecanico.Text) < 18)
                        {
                            MessageBox.Show("El mecanico debe ser mayor de edad");
                        }
                        else if (ComboIDSucursalMecanico.SelectedIndex == -1)
                        {
                            MessageBox.Show("Debe seleccionar la sucursal asignada al mecanico");
                        }
                        else
                        {
                            Mecanico m1 = new Mecanico()
                            {
                                rut_mecanico = RutMecanico.Text,
                                nombre_mecanico = NombreMecanico.Text,
                                apellido_vendedor = ApellidoMecanico.Text,
                                edad_mecanico = int.Parse(EdadMecanico.Text),
                                sexo_mecanico = ComboSexoMecanico.Text,
                                sueldo_mecanico = int.Parse(SueldoMecanico.Text),
                                id_sucursal = int.Parse(ComboIDSucursalMecanico.Text)
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
                                ComboIDSucursalMecanico.SelectedIndex = -1;
                            }
                            else
                            {
                                throw new ArgumentException("Ha ocurrido un error inesperado");
                            }
                        }
                    }
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
                Mecanico mecanicoValidaciones = new Mecanico();
                if (mecanicoValidaciones.GetMecanicos().Count == 0)
                {
                    MessageBox.Show("Debe existir al menos un mecanico para eliminar");
                }
                else if (RutMecanico.Text.Length == 0)
                {
                    MessageBox.Show("Ingrese rut para eliminar mecanico");
                }
                else if (RutMecanico.Text.Length < 2)
                {
                    MessageBox.Show("Debe ingresar un rut válido");
                }
                else
                {
                    string rutSinDv = RutMecanico.Text.Substring(0, RutMecanico.Text.Length - 2);
                    string dv = RutMecanico.Text.Substring(RutMecanico.Text.Length - 1, 1);
                    string rutSinGuion = rutSinDv + dv;
                    if (RutMecanico.Text != String.Format("{0}-{1}", rutSinDv, dv))
                    {
                        MessageBox.Show("Debe ingresar rut sin puntos y con guion\nEjemplo: 99999999-9");
                    }
                    else if (!mecanicoValidaciones.ValidarRut(RutMecanico.Text.ToUpper()))
                    {
                        MessageBox.Show("El rut no es válido");
                    }
                    else if (!mecanicoValidaciones.GetMecanicos().Any(c => c.rut_mecanico == RutMecanico.Text.ToUpper()))
                    {
                        MessageBox.Show("El rut ingresado no existe");
                    }
                    else
                    {
                        Mecanico m1 = new Mecanico()
                        {
                            rut_mecanico = RutMecanico.Text
                        };
                        if (m1.DeleteMecanico())
                        {
                            MessageBox.Show("El mecanico se ha eliminado");
                            RutMecanico.Text = "";
                            NombreMecanico.Text = "";
                            ApellidoMecanico.Text = "";
                            EdadMecanico.Text = "";
                            ComboSexoMecanico.SelectedIndex = 0;
                            SueldoMecanico.Text = "";
                            ComboIDSucursalMecanico.SelectedIndex = -1;
                        }
                        else
                        {
                            throw new ArgumentException("Ha ocurrido un error inesperado");
                        }
                    }
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
                Mecanico mecanicoValidaciones = new Mecanico();
                if (mecanicoValidaciones.GetMecanicos().Count == 0)
                {
                    MessageBox.Show("Debe existir al menos un mecanico para buscar");
                }
                else if (RutMecanico.Text.Length == 0)
                {
                    MessageBox.Show("Ingrese rut para buscar mecanico");
                }
                else if (RutMecanico.Text.Length < 2)
                {
                    MessageBox.Show("Debe ingresar un rut válido");
                }
                else
                {
                    string rutSinDv = RutMecanico.Text.Substring(0, RutMecanico.Text.Length - 2);
                    string dv = RutMecanico.Text.Substring(RutMecanico.Text.Length - 1, 1);
                    string rutSinGuion = rutSinDv + dv;
                    if (RutMecanico.Text != String.Format("{0}-{1}", rutSinDv, dv))
                    {
                        MessageBox.Show("Debe ingresar rut sin puntos y con guion\nEjemplo: 99999999-9");
                    }
                    else if (!mecanicoValidaciones.ValidarRut(RutMecanico.Text.ToUpper()))
                    {
                        MessageBox.Show("El rut no es válido");
                    }
                    else if (!mecanicoValidaciones.GetMecanicos().Any(c => c.rut_mecanico == RutMecanico.Text.ToUpper()))
                    {
                        MessageBox.Show("El rut ingresado no existe");
                    }
                    else
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
                            ComboIDSucursalMecanico.Text = Convert.ToString(m1.id_sucursal);
                        }
                        else
                        {
                            throw new ArgumentException("Ha ocurrido un error inesperado");
                        }
                    }
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

        private void DetenerPrograma(object sender, EventArgs e)
        {
            if (!valor)
            {
                Environment.Exit(0);
            }
        }


        // Botones Pagina Mecanico
    }
}
