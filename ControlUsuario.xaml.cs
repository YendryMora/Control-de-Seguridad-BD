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
using System.Drawing;

namespace ControlSeguridadBD
{
    /// <summary>
    /// Interaction logic for ControlUsuario.xaml
    /// </summary>
    
    public partial class ControlUsuario : Window
    {

    
        private modificarLogin modificarLogin;
        private Modificar modificar;
        public string nombre;
        public string login;
        

        public ControlUsuario()
        {
            
            InitializeComponent();

            if (MainWindow.serverRol.Equals("securityadmin"))
            {
                txtNomUser.IsEnabled = false;
                txtNomLogin2.IsEnabled = false;
                btnBuscar.IsEnabled = false;
                btnCrear3.IsEnabled = false;
                btnModifi3.IsEnabled = false;
                btnEliminaUsario.IsEnabled = false;
                button.IsEnabled = false;//botón de asignar rol de servidor
            }

            //solo comprueba que sea securityadmin, si es sysadmin todo estará habilitado
            //if (.Equals("securityadmin"))
            //{
            //    txtNomUser.IsEnabled = false;
            //    txtNomLogin2.IsEnabled = false;
            //    btnBuscar.IsEnabled = false;
            //    btnCrear3.IsEnabled = false;
            //    btnModifi3.IsEnabled = false;
            //    btnEliminaUsario.IsEnabled = false;
            //    button.IsEnabled = false;//botón de asignar rol de servidor
            //}


        }

    public ControlUsuario(modificarLogin modificarLogin)
        {
            this.modificarLogin = modificarLogin;
        }

        public ControlUsuario(Modificar modificar)
        {
            this.modificar = modificar;
        }

        private void btnCrear_Click(object sender, RoutedEventArgs e)
        {
            if (txtNomLogin.Text == "" || txtNomLogin.Text == null)
            {
                MessageBox.Show("Espacio en Blanco");
                //txtNomLogin.Background = Brushes.Red;
            }
            if (txtContra.Text == "" || txtContra.Text == null)
            {
                MessageBox.Show("Espacio en Blanco");
                //txtContra.Background = Brushes.Red;
            }
            if (txtBD.Text == "" || txtBD.Text == null)
            {
                MessageBox.Show("Nombre de Base de datos en Blanco,base de datos por default es MASTER");
                txtBD.Text = "MASTER";
            }
            else
            {
                clsConexion conex = new clsConexion();
                if (conex.ifexistBD(txtBD.Text) == txtBD.Text)
                {
                    MessageBox.Show(conex.insertarlogin(txtNomLogin.Text, txtContra.Text, txtBD.Text));
                }
                else
                {
                    MessageBox.Show("NO existe esta base de datos");
                    //txtBD.Background = Brushes.Red;
                }
            }
               
             
            }
        

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            ControlModifica ventanalogin = new ControlModifica();
            ventanalogin.Ventana("login"/*, txtNomLogin.Text, txtContra.Text*/);
            ventanalogin.ShowDialog();
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            clsConexion conex = new clsConexion();
            MessageBox.Show(conex.EliminarLogin(txtNomLogin.Text));
            limpiarLogin();
        }

        private void btnCrear3_Click(object sender, RoutedEventArgs e)
        {
            clsConexion conex = new clsConexion();
            MessageBox.Show(conex.insertaruser(txtNomUser.Text, txtNomLogin2.Text));
        }

        private void btnModifi3_Click(object sender, RoutedEventArgs e)
        {
            nombre = txtNomUser.Text;
            login = txtNomLogin.Text; // cambiar nombre por user
            ControlModifica ventanalogin = new ControlModifica();
            ventanalogin.Ventana("usuario"/*, txtNomUser.Text , txtNomLogin2.Text*/);
            ventanalogin.ShowDialog();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if(txtNomUser.IsEnabled == false)
            {
                MainWindow mw = new MainWindow();
                this.Close();
                mw.ShowDialog();



            }
            else
            {
                MainWindow mw = new MainWindow();
                this.Close();
                mw.ShowDialog();
            }

        }

        private void btnConsultar1_Click(object sender, RoutedEventArgs e)

        {
            clsConexion conex = new clsConexion();
            if ( conex.cargarLogin(txtNomLogin.Text) == txtNomLogin.Text) // verifica si login existe
            {
                MessageBox.Show("Ya existe login");
                if(conex.cargarBDlogin(txtNomLogin.Text ) != ""  && conex.cargarBDlogin(txtNomLogin.Text) != null) // buscar que tenga una base de datos
                {
                    txtBD.Text = conex.cargarBDlogin(txtNomLogin.Text); // manda el valor obtenido a el nombre de base de datos del formulario
                }else
                {
                    MessageBox.Show("No tiene base de datos asocida");
                }
            }
            else
            {
                MessageBox.Show("no existe");
            }
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            clsConexion conex = new clsConexion();
            if (conex.cargarUsuario(txtNomUser.Text) == "si")
            {
               if(conex.cargarLoginUsuario(txtNomUser.Text) != "no")
                {
                    txtNomLogin2.Text = conex.cargarLoginUsuario(txtNomUser.Text);
                   
                }
                else
                {
                    MessageBox.Show(conex.cargarLoginUsuario(txtNomUser.Text));
                }
            }
            else
            {
                MessageBox.Show("No existe el usuario");
            }
        }

        private void btnEliminaUsario_Click(object sender, RoutedEventArgs e)
        {
            clsConexion conex = new clsConexion();
            MessageBox.Show(conex.EliminarUser(txtNomUser.Text));
            limpiarUsuario();
        }
        private void limpiarLogin()
        {
            txtNomLogin.Text = "";
            txtContra.Text = "";
        }
        private void limpiarUsuario()
        {
            txtNomUser.Text = "";
            txtNomLogin2.Text = "";
        }
        //private void brushes()
        //{

        //    txtNomUser.IsEnabled = false;
        //    txtNomLogin2.IsEnabled = false;
        //    btnCrear3.IsEnabled = false;
        //    btnModifi3.IsEnabled = false;
        //    btnEliminaUsario.IsEnabled = false;
        //    btnBuscar.IsEnabled = false;
        //    txtNomUser.Foreground = Brushes.White;
        //    txtNomLogin2.Foreground = Brushes.White;
        //    btnCrear3.Foreground = Brushes.White;
        //    btnModifi3.Foreground = Brushes.White;
        //    btnEliminaUsario.Foreground = Brushes.White;
        //    btnBuscar.Foreground = Brushes.White;
        //    textBlock_titulo.Foreground = Brushes.White;
        //    textBlock_login.Foreground = Brushes.White;
        //    textBlock_nombre.Foreground = Brushes.White;
        //    txtNomUser.BorderBrush = Brushes.White;
        //    txtNomLogin2.BorderBrush = Brushes.White;
        //    btnCrear3.BorderBrush = Brushes.White;
        //    btnModifi3.BorderBrush = Brushes.White;



        //}

        private void btnModificar3_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnBuscar3_Click(object sender, RoutedEventArgs e)
        {
          
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            ServerRoles sr = new ServerRoles();
            sr.ShowDialog();
                 
        }

        private void ctbestablecer_Click(object sender, RoutedEventArgs e)
        {
            clsConexion conex = new clsConexion();
            if (cbdesha.IsEnabled == true)
            {
                MessageBox.Show(conex.DenyConex(txtNomLogin.Text));
            }
            if (cbdesha.IsEnabled == true)
                {
                MessageBox.Show(conex.GrantConex(txtNomLogin.Text));
            }
        }
      

        private void cbhabilitar_Checked(object sender, RoutedEventArgs e)
        {
            cbdesha.IsEnabled = false;
        }

        private void cbhabilitar_Unchecked(object sender, RoutedEventArgs e)
        {
            cbdesha.IsEnabled = true;
        }

        private void cbdesha_Checked(object sender, RoutedEventArgs e)
        {
            cbhabilitar.IsEnabled = false;
        }

        private void cbdesha_Unchecked(object sender, RoutedEventArgs e)
        {
            cbhabilitar.IsEnabled = true;
        }
    }
}
