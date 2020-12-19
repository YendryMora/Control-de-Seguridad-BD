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
    /// Interaction logic for Modificar.xaml
    /// </summary>
    public partial class Modificar : Window
    {

        clsConexion conex = new clsConexion();
        ControlUsuario cu = new ControlUsuario();
        ControlRoles cr = new ControlRoles();
        public Modificar()
        {
            InitializeComponent();
            if( tipo == "login")
            {
                txtNom.Text = cu.nombre;
            }
       
        }

        //// variale global
        private string tipo;
        //private string objeto;
        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            if (tipo == "rol")
            {
             
                MessageBox.Show(conex.modificarRolName(txtNom.Text, txtNewNom.Text));
                this.Close();
            }
            if(tipo == "login")
            {
                //txtNom.Text = objeto;
                MessageBox.Show(conex.modificarloginname(txtNom.Text, txtNewNom.Text));
                this.Close();
            }
            if (tipo == "usuario")
            {
                /// falta codigo de modificar nombre se usuario
            }


        }
        public void Proceso(string num/*, string nomObjeto*/)
        {
            tipo = num;
            //objeto = nomObjeto;
        }


    }
}
