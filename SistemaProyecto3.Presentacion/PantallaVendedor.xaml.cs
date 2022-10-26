using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using SistemaProyecto3.Negocio;

namespace SistemaProyecto3.Presentacion
{
    /// <summary>
    /// Lógica de interacción para PantallaVendedor.xaml
    /// </summary>
    public partial class PantallaVendedor : Window
    {
        private List<Factura> ListFactura;
        private List<Boleta> ListBoleta;
        private List<Servicio> ListServicio;
        private List<Producto> ListProductos;
        private List<Vendedor> ListVendedor;
        private List<Mecanico> ListMecanico;
        private List<Empresa> ListEmpresa;
        private List<Venta> ListVentas;
        //Variable para validar si se abre ventana Main
        private bool valor = false;

        public PantallaVendedor()
        {
            InitializeComponent();
            // Iniciar combobox
            Vendedor vend = new Vendedor();
            ComboRutVendedor.ItemsSource = vend.GetRutVendedores();
            ComboRutVendedor.Items.Refresh();
            ComboRutVendedorBoleta.ItemsSource = vend.GetRutVendedores();
            ComboRutVendedorBoleta.Items.Refresh();

            Mecanico mec = new Mecanico();
            ComboRutMecanicos.ItemsSource = mec.GetRutMecanicos();
            ComboRutMecanicos.Items.Refresh();
            ComboRutMecanicoBoleta.ItemsSource = mec.GetRutMecanicos();
            ComboRutMecanicoBoleta.Items.Refresh();

            Sucursal suc = new Sucursal();
            ComboIDSucursal.ItemsSource = suc.GetIDSucursales();
            ComboIDSucursal.Items.Refresh();
            ComboIDSucursalBoleta.ItemsSource = suc.GetIDSucursales();
            ComboIDSucursalBoleta.Items.Refresh();

            Empresa emp = new Empresa();
            ComboRutEmpresa.ItemsSource = emp.GetRutEmpresa();
            ComboRutEmpresa.Items.Refresh();
            ComboRutEmpresaBoleta.ItemsSource = emp.GetRutEmpresa();
            ComboRutEmpresaBoleta.Items.Refresh();

            Producto prod = new Producto();
            ComboPatenteProducto.ItemsSource = prod.GetPatentesProducto();
            ComboPatenteProducto.Items.Refresh();
            ComboPatenteProductoBoleta.ItemsSource = prod.GetPatentesProducto();
            ComboPatenteProductoBoleta.Items.Refresh();
            // Termino de iniciar combobox

            //Esconder campos factura
            MontoFactura.Visibility = Visibility.Hidden;
            ComboPatenteProducto.Visibility = Visibility.Hidden;
            ServicioFactura.Visibility = Visibility.Hidden;
            FechaEntregaFactura.Visibility = Visibility.Hidden;
            FechaIngresoFactura.Visibility = Visibility.Hidden;
            ProductoFacturaTextBox.Visibility = Visibility.Hidden;
            RutClienteFactura.Visibility = Visibility.Hidden;
            NombreClienteFactura.Visibility = Visibility.Hidden;
            ApellidosClienteFactura.Visibility = Visibility.Hidden;
            ComboRutVendedor.Visibility = Visibility.Hidden;
            ComboRutMecanicos.Visibility = Visibility.Hidden;
            ComboIDSucursal.Visibility = Visibility.Hidden;
            ComboRutEmpresa.Visibility = Visibility.Hidden;
            ComboSexoClienteFactura.Visibility = Visibility.Hidden;
            EdadClienteFactura.Visibility = Visibility.Hidden;
            //Termino esconder campos factura

            //Inicio esconder campos boleta
            MontoBoleta.Visibility = Visibility.Hidden;
            ProductoTextBoxBoleta.Visibility = Visibility.Hidden;
            ComboPatenteProductoBoleta.Visibility = Visibility.Hidden;
            ServicioBoleta.Visibility = Visibility.Hidden;
            FechaEntregaBoleta.Visibility = Visibility.Hidden;
            FechaIngresoBoleta.Visibility = Visibility.Hidden;
            RutClienteBoleta.Visibility = Visibility.Hidden;
            NombreClienteBoleta.Visibility = Visibility.Hidden;
            ApellidosClienteBoleta.Visibility = Visibility.Hidden;
            ComboRutVendedorBoleta.Visibility = Visibility.Hidden;
            ComboRutMecanicoBoleta.Visibility = Visibility.Hidden;
            ComboIDSucursalBoleta.Visibility = Visibility.Hidden;
            ComboRutEmpresaBoleta.Visibility = Visibility.Hidden;
            ComboSexoClienteBoleta.Visibility = Visibility.Hidden;
            EdadClienteBoleta.Visibility = Visibility.Hidden;
            //Termino esconder campos boleta
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            tab_PantallaVendedor.SelectedIndex = 0;
        }

        private void boton_SecundarioSucursal_Click(object sender, RoutedEventArgs e)
        {
            tab_PantallaVendedor.SelectedIndex = 1;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            valor = true;
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        //DataGrid Factura
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Factura f1 = new Factura();
            Servicio serv = new Servicio();
            Producto produc = new Producto();
            Vendedor v1 = new Vendedor();
            Mecanico m1 = new Mecanico();
            Empresa e1 = new Empresa();
            Venta ven = new Venta();

            if(ComboDataGridFactura.SelectedIndex == 0)
            {
                MessageBox.Show("Debe escoger la tabla que desea actualizar o ver");
            }
            if(ComboDataGridFactura.SelectedIndex == 1)
            {
                ListFactura = f1.GetFacturas();
                DataGridFactura.ItemsSource = ListFactura;
                DataGridFactura.Items.Refresh();
            }
            if(ComboDataGridFactura.SelectedIndex == 2)
            {
                ListServicio = serv.GetServicios();
                DataGridFactura.ItemsSource = ListServicio;
                DataGridFactura.Items.Refresh();
            }
            if(ComboDataGridFactura.SelectedIndex == 3)
            {
                ListProductos = produc.GetProductos();
                DataGridFactura.ItemsSource = ListProductos;
                DataGridFactura.Items.Refresh();
            }
            if (ComboDataGridFactura.SelectedIndex == 4)
            {
                ListVendedor = v1.GetVendedores();
                DataGridFactura.ItemsSource = ListVendedor;
                DataGridFactura.Items.Refresh();
            }
            if(ComboDataGridFactura.SelectedIndex == 5)
            {
                ListMecanico = m1.GetMecanicos();
                DataGridFactura.ItemsSource = ListMecanico;
                DataGridFactura.Items.Refresh();
            }
            if(ComboDataGridFactura.SelectedIndex == 6)
            {
                ListEmpresa = e1.GetEmpresa();
                DataGridFactura.ItemsSource = ListEmpresa;
                DataGridFactura.Items.Refresh();
            }
            if(ComboDataGridFactura.SelectedIndex == 7)
            {
                ListVentas = ven.GetVentas();
                DataGridFactura.ItemsSource = ListVentas;
                DataGridFactura.Items.Refresh();
            }
        }

        //DataGrid Boleta
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Boleta b1 = new Boleta();
            Servicio serv = new Servicio();
            Producto produc = new Producto();
            Vendedor v1 = new Vendedor();
            Mecanico m1 = new Mecanico();
            Empresa e1 = new Empresa();
            Venta ven = new Venta();

            if (ComboDataGridBoleta.SelectedIndex == 0)
            {
                MessageBox.Show("Debe escoger la tabla que desea actualizar o ver");
            }
            if (ComboDataGridBoleta.SelectedIndex == 1)
            {
                ListBoleta = b1.GetBoletas();
                DataGridBoleta.ItemsSource = ListBoleta;
                DataGridBoleta.Items.Refresh();
            }
            if (ComboDataGridBoleta.SelectedIndex == 2)
            {
                ListServicio = serv.GetServicios();
                DataGridBoleta.ItemsSource = ListServicio;
                DataGridBoleta.Items.Refresh();
            }
            if (ComboDataGridBoleta.SelectedIndex == 3)
            {
                ListProductos = produc.GetProductos();
                DataGridBoleta.ItemsSource = ListProductos;
                DataGridBoleta.Items.Refresh();
            }
            if (ComboDataGridBoleta.SelectedIndex == 4)
            {
                ListVendedor = v1.GetVendedores();
                DataGridBoleta.ItemsSource = ListVendedor;
                DataGridBoleta.Items.Refresh();
            }
            if (ComboDataGridBoleta.SelectedIndex == 5)
            {
                ListMecanico = m1.GetMecanicos();
                DataGridBoleta.ItemsSource = ListMecanico;
                DataGridBoleta.Items.Refresh();
            }
            if (ComboDataGridBoleta.SelectedIndex == 6)
            {
                ListEmpresa = e1.GetEmpresa();
                DataGridBoleta.ItemsSource = ListEmpresa;
                DataGridBoleta.Items.Refresh();
            }
            if (ComboDataGridBoleta.SelectedIndex == 7)
            {
                ListVentas = ven.GetVentas();
                DataGridBoleta.ItemsSource = ListVentas;
                DataGridBoleta.Items.Refresh();
            }
        }

        //Cambios al cambiar combobox factura
        private void ComboQueAgregarFactura_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {            
            if(ComboQueAgregarFactura.SelectedIndex == 1)
            {
                MontoFactura.Visibility = Visibility.Visible;
                ComboPatenteProducto.Visibility = Visibility.Visible;
                ServicioFactura.Visibility = Visibility.Hidden;
                FechaEntregaFactura.Visibility = Visibility.Visible;
                FechaIngresoFactura.Visibility = Visibility.Visible;
                ProductoFacturaTextBox.Visibility = Visibility.Hidden;
                RutClienteFactura.Visibility = Visibility.Visible;
                NombreClienteFactura.Visibility = Visibility.Visible;
                ApellidosClienteFactura.Visibility = Visibility.Visible;
                ComboRutVendedor.Visibility = Visibility.Visible;
                ComboRutMecanicos.Visibility = Visibility.Hidden;
                ComboIDSucursal.Visibility = Visibility.Visible;
                ComboRutEmpresa.Visibility = Visibility.Visible;
                ComboSexoClienteFactura.Visibility = Visibility.Visible;
                EdadClienteFactura.Visibility = Visibility.Visible;
            }
            if(ComboQueAgregarFactura.SelectedIndex == 2)
            {
                MontoFactura.Visibility = Visibility.Visible;
                ComboPatenteProducto.Visibility = Visibility.Hidden;
                ServicioFactura.Visibility = Visibility.Visible;
                FechaEntregaFactura.Visibility = Visibility.Visible;
                FechaIngresoFactura.Visibility = Visibility.Visible;
                ProductoFacturaTextBox.Visibility = Visibility.Visible;
                RutClienteFactura.Visibility = Visibility.Visible;
                NombreClienteFactura.Visibility = Visibility.Visible;
                ApellidosClienteFactura.Visibility = Visibility.Visible;
                ComboRutVendedor.Visibility = Visibility.Hidden;
                ComboRutMecanicos.Visibility = Visibility.Visible;
                ComboIDSucursal.Visibility = Visibility.Visible;
                ComboRutEmpresa.Visibility = Visibility.Visible;
                ComboSexoClienteFactura.Visibility = Visibility.Visible;
                EdadClienteFactura.Visibility = Visibility.Visible;
            }
        }
        //Fin Cambios al cambiar combobox factura

        //Boton limpiar Factura
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            MontoFactura.Text = "";
            ComboPatenteProducto.SelectedIndex = -1;
            ServicioFactura.Text = "";
            FechaEntregaFactura.Text = "";
            FechaIngresoFactura.Text = "";
            ProductoFacturaTextBox.Text = "";
            RutClienteFactura.Text = "";
            NombreClienteFactura.Text = "";
            ApellidosClienteFactura.Text = "";
            ComboRutVendedor.SelectedIndex = -1;
            ComboRutMecanicos.SelectedIndex = -1;
            ComboIDSucursal.SelectedIndex = -1;
            ComboRutEmpresa.SelectedIndex = -1;
            ComboSexoClienteFactura.SelectedIndex = 0;
            EdadClienteFactura.Text = "";
        }
        //Fin btn limpiar factura

        

        //Fin btn_registrar_factura
        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            try
            {
                if(ComboQueAgregarFactura.SelectedIndex == 1)
                {
                    double v_iva = 0.19;
                    int v_iva_total = Convert.ToInt32(double.Parse(MontoFactura.Text) * v_iva);
                    int total_venta = Convert.ToInt32(int.Parse(MontoFactura.Text) + v_iva_total);
                    int i = ComboPatenteProducto.SelectedIndex;
                    Producto per1 = ListProductos[i];
                    Producto p1 = new Producto()
                    {
                        patente_producto = per1.patente_producto,
                        kilometraje = per1.kilometraje,
                        año = per1.año,
                        marca = per1.marca,
                        modelo = per1.modelo,
                        tipo = per1.tipo,
                        precio = per1.precio
                    };                    
                    Venta v1 = new Venta()
                    {
                        cantidad = int.Parse(MontoFactura.Text),
                        iva = v_iva_total,
                        monto_total = total_venta,
                        descripcion = "Modelo: " + p1.modelo + ", Marca: " + p1.marca + ", Año: " + p1.año + ", Patente: " + p1.patente_producto + ", Tipo Producto (1 = Auto - 2= Camion): " + p1.tipo,
                        rut_vendedor = ComboRutVendedor.Text
                    };
                    Factura f1 = new Factura()
                    {
                        monto_factura = int.Parse(MontoFactura.Text),
                        monto_iva_factura = v_iva_total,
                        fecha_ingreso_factura = DateTime.Parse(FechaIngresoFactura.Text),
                        fecha_entrega_factura = DateTime.Parse(FechaEntregaFactura.Text),
                        descripcion_factura = "vacio",
                        descripcion_cliente_factura ="Rut cliente: " + RutClienteFactura.Text + ", Nombre cliente: " + NombreClienteFactura.Text + ", Apellidos: " + ApellidosClienteFactura.Text + ", Sexo: " + ComboSexoClienteFactura.Text + ", Edad: " + EdadClienteFactura.Text,
                        rut_factura = ComboRutVendedor.Text,
                        rut_cliente_factura = RutClienteFactura.Text,
                        rut_empresa_factura = ComboRutEmpresa.Text,
                        patente_producto_factura = ComboPatenteProducto.Text
                    };
                    Servicio s1 = new Servicio()
                    {
                        fecha_entrega = DateTime.Parse(FechaEntregaFactura.Text),
                        costo_servicio = int.Parse(MontoFactura.Text),
                        patente_servicio = ProductoFacturaTextBox.Text,
                        descripcion = ServicioFactura.Text
                    };
                    
                    if (f1.CrearFacturaProducto())
                    {
                        if (s1.CrearServicio())
                        {
                            if (v1.CrearVenta())
                            {
                                MessageBox.Show("La factura se ha creado con exito");
                                MontoFactura.Text = "";
                                ComboPatenteProducto.SelectedIndex = -1;
                                ServicioFactura.Text = "";
                                FechaEntregaFactura.Text = "";
                                FechaIngresoFactura.Text = "";
                                ProductoFacturaTextBox.Text = "";
                                RutClienteFactura.Text = "";
                                NombreClienteFactura.Text = "";
                                ApellidosClienteFactura.Text = "";
                                ComboRutVendedor.SelectedIndex = -1;
                                ComboRutMecanicos.SelectedIndex = -1;
                                ComboIDSucursal.SelectedIndex = -1;
                                ComboRutEmpresa.SelectedIndex = -1;
                                ComboSexoClienteFactura.SelectedIndex = 0;
                                EdadClienteFactura.Text = "";
                            }
                            else
                            {
                                throw new ArgumentException("Venta");
                            }
                        }
                        else
                        {
                            throw new ArgumentException("Servicio");
                        }
                    }
                    else
                    {
                        throw new ArgumentException("factura");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Fin btn Registrar factura

        //Cambios al cambiar combobox Boleta
        private void ComboQueAgregarBoleta_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if(ComboQueAgregarBoleta.SelectedIndex == 1)
            {
                MontoBoleta.Visibility = Visibility.Visible;
                ProductoTextBoxBoleta.Visibility = Visibility.Hidden;
                ComboPatenteProductoBoleta.Visibility = Visibility.Visible;
                ServicioBoleta.Visibility = Visibility.Hidden;
                FechaEntregaBoleta.Visibility = Visibility.Visible;
                FechaIngresoBoleta.Visibility = Visibility.Visible;
                RutClienteBoleta.Visibility = Visibility.Visible;
                NombreClienteBoleta.Visibility = Visibility.Visible;
                ApellidosClienteBoleta.Visibility = Visibility.Visible;
                ComboRutVendedorBoleta.Visibility = Visibility.Visible;
                ComboRutMecanicoBoleta.Visibility = Visibility.Hidden;
                ComboIDSucursalBoleta.Visibility = Visibility.Visible;
                ComboRutEmpresaBoleta.Visibility = Visibility.Visible;
                ComboSexoClienteBoleta.Visibility = Visibility.Visible;
                EdadClienteBoleta.Visibility = Visibility.Visible;
            }
            if(ComboQueAgregarBoleta.SelectedIndex == 2)
            {
                MontoBoleta.Visibility = Visibility.Visible;
                ProductoTextBoxBoleta.Visibility = Visibility.Visible;
                ComboPatenteProductoBoleta.Visibility = Visibility.Hidden;
                ServicioBoleta.Visibility = Visibility.Visible;
                FechaEntregaBoleta.Visibility = Visibility.Visible;
                FechaIngresoBoleta.Visibility = Visibility.Visible;
                RutClienteBoleta.Visibility = Visibility.Visible;
                NombreClienteBoleta.Visibility = Visibility.Visible;
                ApellidosClienteBoleta.Visibility = Visibility.Visible;
                ComboRutVendedorBoleta.Visibility = Visibility.Hidden;
                ComboRutMecanicoBoleta.Visibility = Visibility.Visible;
                ComboIDSucursalBoleta.Visibility = Visibility.Visible;
                ComboRutEmpresaBoleta.Visibility = Visibility.Visible;
                ComboSexoClienteBoleta.Visibility = Visibility.Visible;
                EdadClienteBoleta.Visibility = Visibility.Visible;
            }
        }
        //Fin Cambios al cambiar combobox Boleta       

        //btn Limpiar Boleta
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            MontoBoleta.Text = "";
            ProductoTextBoxBoleta.Text = "";
            ComboPatenteProductoBoleta.SelectedIndex = -1;
            ServicioBoleta.Text = "";
            FechaEntregaBoleta.Text = "";
            FechaIngresoBoleta.Text = "";
            RutClienteBoleta.Text = "";
            NombreClienteBoleta.Text = "";
            ApellidosClienteBoleta.Text = "";
            ComboRutVendedorBoleta.SelectedIndex = -1;
            ComboRutMecanicoBoleta.SelectedIndex = -1;
            ComboIDSucursalBoleta.SelectedIndex = -1;
            ComboRutEmpresaBoleta.SelectedIndex = -1;
            ComboSexoClienteBoleta.SelectedIndex = 0;
            EdadClienteBoleta.Text = "";
        }

        private void DetenerPrograma(object sender, EventArgs e)
        {
            if (!valor)
            {
                Environment.Exit(0);
            }
        }
    }
}
