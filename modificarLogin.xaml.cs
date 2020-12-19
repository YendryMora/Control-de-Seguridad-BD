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
    /// Interaction logic for modificarLogin.xaml
    /// </summary>
    public partial class modificarLogin : Window
    {
        clsConexion conex = new clsConexion();

        // variale global
        private string tipo;
        private string objeto;
        public modificarLogin()
        {
            InitializeComponent();
        }


        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {

            if (tipo == "rol")
            {
                txtBlockContra.Text = "Esquema";
                txtNom.Text = objeto;
                MessageBox.Show(conex.modificarRolEsquema(txtNom.Text, txtContra.Text));
                this.Close();
            }
            if (tipo == "login")
            {
                txtNom.Text = objeto;
                MessageBox.Show(conex.modificarlogincontra(txtNom.Text, txtContra.Text));
                this.Close();
            }

        }
        // tiene el proceso, que son: rol, usuarios
        public void Proceso(string num/*, string nomobjeto*/)
        {
            tipo = num;
            //objeto = nomobjeto;
        }

        private void txtNom_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
