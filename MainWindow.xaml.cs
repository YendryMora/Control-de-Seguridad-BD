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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ControlSeguridadBD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {

     
        public string rolserver;
        public int cont = 0;
        public string nombreLogin;
        public string nombreServerRol;
        public string nombreRolBD;
        public string conextividadcero;
        public string conextividadunio;
        clsConexion conex = new clsConexion();

        public static string serverRol;
        public MainWindow()
        {
            InitializeComponent();

        }
      

        private void btnIngresar_Click(object sender, RoutedEventArgs e)
        {


            if (cont == 0)
            {
                conextividadcero = conex.conectividad(txtUsuario.Text);
                conextividadunio = conex.conectividad(txtUsuario.Text);
                nombreLogin = conex.cargarLogin(txtUsuario.Text);
                nombreServerRol = conex.serverRol(txtUsuario.Text);
                //nombreRolBD = conex.rolBD(txtUsuario.Text);

    }


            if ( conextividadcero == "0")
            {


                if (nombreLogin == txtUsuario.Text)
                {

                    if (nombreServerRol == "securityadmin")
                    {

                        if (conex.ValidarContra(txtUsuario.Text, txtContra.Password) == "contraseña correcta")
                        {
                            // aqui va el nombre de la vantana que debe abrir segun rol rol que tenga

                            serverRol = "securityadmin";
                            ventanaSA sa = new ventanaSA();

                            this.Close();

                            sa.ShowDialog();


                        }

                        else
                        {
                            if (conex.ValidarContra(txtUsuario.Text, txtContra.Password) == "No se pudo conectar")
                            {
                                MessageBox.Show("Contraseña Erronea");
                                cont = 1 + cont;
                                bloqueo(cont);


                            }
                        }

                    }


                    //if (txtUsuario.Text == "sa")
                    //{
                    //clsConexion conex = new clsConexion();
                    //if (conex.ValidarContra(txtUsuario.Text, txtContra.Text) == "contraseña correcta")
                    //    {

                    //        ventanaSA vsa = new ventanaSA();
                    //    this.Close();
                    //        vsa.ShowDialog();


                    //    }
                    //    if (conex.ValidarContra(txtUsuario.Text, txtContra.Text) == "No se pudo conectar")
                    //    {
                    //        MessageBox.Show("Contraseña Erronea");
                    //        cont = 1 + cont;
                    //        bloqueo(cont);
                    //    }


                    //}

                    if (nombreServerRol == "sysadmin")
                    {

                        if (conex.ValidarContra(txtUsuario.Text, txtContra.Password) == "contraseña correcta")
                        {
                            serverRol = "sysadmin";
                            ventanaSA vsa = new ventanaSA();
                            this.Close();
                            vsa.ShowDialog();

                        }
                        else
                        {
                            if (conex.ValidarContra(txtUsuario.Text, txtContra.Password) == "No se pudo conectar")
                            {
                                MessageBox.Show("Contraseña Erronea");
                                cont = 1 + cont;
                                bloqueo(cont);
                            }

                        }

                    }

                    if (nombreServerRol == "auditoria")
                    {

                        if (conex.ValidarContra(txtUsuario.Text, txtContra.Password) == "contraseña correcta")
                        {
                            serverRol = "auditoria";
                            ventanaSA vsa = new ventanaSA();
                            this.Close();
                            vsa.ShowDialog();

                        }
                        else
                        {
                            if (conex.ValidarContra(txtUsuario.Text, txtContra.Password) == "No se pudo conectar")
                            {
                                MessageBox.Show("Contraseña Erronea");
                                cont = 1 + cont;
                                bloqueo(cont);
                            }

                        }

                    }
                }

                if (nombreServerRol != "sysadmin" && nombreServerRol != "securityadmin" && nombreServerRol != "auditoria")
                {
                    MessageBox.Show("Este usuario no tiene permiso para entrar en esta aplicacion");
                }
            }else
                if (conextividadunio == "1")
            {
                MessageBox.Show("Este usuario esta bloqueado");
            }


        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void bloqueo (int conta)
        {
            if (conta == 3)
            {
                //MessageBox.Show("Usuario Bloqueado temporalmente");
                txtContra.IsEnabled = false;
                txtUsuario.IsEnabled = false;
                btnIngresar.IsEnabled = false;
                //MessageBox.Show(conex.bloqueaLogin(txtUsuario.Text));
            }else
            {

            }
        }
    }
}
