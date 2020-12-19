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
    /// Interaction logic for ventanaSA.xaml
    /// </summary>
    public partial class ventanaSA : Window
    {
        
        public ventanaSA()
        {
            
            InitializeComponent();

            if (MainWindow.serverRol.Equals("auditoria"))
            {
                btnReportes.IsEnabled = true;
                btnCU.IsEnabled = false;
                btnCR.IsEnabled = false;
                btnLista.IsEnabled = true;
            }
            if (MainWindow.serverRol.Equals("sysadmin"))
            {
                btnReportes.IsEnabled = true;
                btnCU.IsEnabled = true;
                btnCR.IsEnabled = true;
                btnLista.IsEnabled = true;
            }
            if (MainWindow.serverRol.Equals("securityadmin"))
            {
                btnReportes.IsEnabled = false;
                btnCU.IsEnabled = true;
                btnCR.IsEnabled = false;
                btnLista.IsEnabled = true;
            }
        }

        private void btnCU_Click(object sender, RoutedEventArgs e)
        {
            ControlUsuario cu = new ControlUsuario();
            this.Close();
            cu.ShowDialog(); // abre ventana de control de usarios
         
       
           
        }


        private void btnCR_Click(object sender, RoutedEventArgs e)
        {
            ControlRoles cr = new ControlRoles();
            this.Close();
            cr.ShowDialog(); // abre ventana de control de usuarios
        }

        private void btnReportes_Click(object sender, RoutedEventArgs e)
        {
            Filtros ventana = new Filtros();
            this.Close();
            ventana.ShowDialog();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnLista_Click(object sender, RoutedEventArgs e)
        {
            ListaPermisos ventana = new ListaPermisos();
            ventana.ShowDialog();
        }
    }
}
