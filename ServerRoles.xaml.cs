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

namespace ControlSeguridadBD
{
    /// <summary>
    /// Interaction logic for ServerRoles.xaml
    /// </summary>
    public partial class ServerRoles : Window
    {
        public ServerRoles()
        {
            InitializeComponent();
        }

        private void btnModificar3_Click(object sender, RoutedEventArgs e)
        {
            clsConexion conex = new clsConexion();

            if (txtlogin2.Text == "")
            {
                MessageBox.Show("Debe escribir nomobre de logi");
                txtlogin2.Background = Brushes.Red;

            }
            if (txtrol.Text == "")
            {
                MessageBox.Show("Debe escribir nomobre de Rol de servidor");
                txtrol.Background = Brushes.Red;
            }
            else
            {

                MessageBox.Show(conex.AsignarServerRol(txtlogin2.Text, txtrol.Text));
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            clsConexion conex = new clsConexion();
            MessageBox.Show(conex.QuitarServerRol(txtlogin2.Text, txtrol.Text));
        }

        private void btnBuscar3_Click(object sender, RoutedEventArgs e)
        {
            clsConexion conex = new clsConexion();
            if (conex.cargarLogin(txtlogin2.Text) != "")
            {
                if (conex.buscarRolLogin(txtlogin2.Text) != "")
                {
                    txtrol.Text = conex.buscarRolLogin(txtlogin2.Text);
                }
                else
                {
                    MessageBox.Show("Login no tiene rol de servidor asociado");
                }
            }
            else
            {
                MessageBox.Show("Login no existe");
            }
        }
    }
}
