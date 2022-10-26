using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SistemaProyecto3.Negocio;
using System.Data;
using System.Data.SqlClient;


namespace SistemaProyecto3.Presentacion
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"data source=DESKTOP-NOB891J;initial catalog=Proyecto_3;user id=SA;password=1234567;MultipleActiveResultSets=True;");
            try
            {
                Usuario u1 = new Usuario();
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                String query = "SELECT COUNT (1), usuario, contraseña_usuario, tipo_usuario FROM USUARIO WHERE usuario = @user AND contraseña_usuario = @pass GROUP BY usuario, contraseña_usuario, tipo_usuario";
                String query2 = "SELECT tipo_usuario FROM USUARIO WHERE usuario = @user AND contraseña_usuario = @pass";
                SqlCommand sqlCod = new SqlCommand(query, sqlCon);
                SqlCommand sqlcod2 = new SqlCommand(query2, sqlCon);
                sqlCod.CommandType = CommandType.Text;
                sqlCod.Parameters.AddWithValue("@user", user.Text);
                sqlCod.Parameters.AddWithValue("@pass", contraseña.Password);
                sqlcod2.Parameters.AddWithValue("@user", user.Text);
                sqlcod2.Parameters.AddWithValue("@pass", contraseña.Password);
                int count = Convert.ToInt32(sqlCod.ExecuteScalar());
                int tipo = Convert.ToInt16(sqlcod2.ExecuteScalar());
                if (count == 1)
                {
                    if (tipo == 1)
                    {
                        MessageBox.Show("Bienvenido admin");
                        user.Text = "";
                        contraseña.Password = "";
                        PantallaAdmin pa = new PantallaAdmin();
                        pa.Show();
                        this.Close();
                    }
                    else if (tipo == 2)
                    {
                        MessageBox.Show("Bienvenido vendedor");
                        user.Text = "";
                        contraseña.Password = "";
                        PantallaVendedor pv = new PantallaVendedor();
                        pv.Show();
                        this.Close();
                    }
                }
                else if (user.Text.Length == 0 || contraseña.Password.Length == 0)
                {
                    MessageBox.Show("Uno o más campos estan vacios");
                }
                else if (user.Text != u1.usuario1 || contraseña.Password != u1.contraseña_usuario)
                {
                    MessageBox.Show("Datos incorrectos");
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
            finally
            {
                sqlCon.Close();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
