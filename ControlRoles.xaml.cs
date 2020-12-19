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
using System.Windows.Controls.Primitives;

namespace ControlSeguridadBD
{
    /// <summary>
    /// Interaction logic for ControlRoles.xaml
    /// </summary>
    public partial class ControlRoles : Window
    {
        clsConexion conex = new clsConexion();

        public ControlRoles()
        {
            InitializeComponent();
        }

        private void btnCrear_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(conex.insertarrol(txtNombreRol.Text, txtesquema.Text));
        }

        private void btnAsignar_Click(object sender, RoutedEventArgs e)
        {
            if (txttabla.Text == null)
            {
                MessageBox.Show("Falta el nombre de la tabla");
                txttabla.Background = Brushes.Red;
            }
            else
            {
                if (cbInsert.IsChecked == true)
                {
                    MessageBox.Show(conex.agrePermiso("INSERT", txttabla.Text, txtRol1.Text));
                }
                if (cbDelete.IsChecked == true)
                {
                    MessageBox.Show(conex.agrePermiso("DELETE ", txttabla.Text, txtRol1.Text));
                }
                if (cbSelect.IsChecked == true)
                {
                    MessageBox.Show(conex.agrePermiso("SELECT", txttabla.Text, txtRol1.Text));
                }
                if (cbUpdate.IsChecked == true)
                {
                    MessageBox.Show(conex.agrePermiso("UPDATE", txttabla.Text, txtRol1.Text));
                }

            }
        }

        private void btnQuitar_Click(object sender, RoutedEventArgs e)
        {

            if (cbInsert2.IsChecked == true)
            {
               MessageBox.Show(conex.agrePermiso("INSERT", txttabla2.Text, txtRol3.Text));
            }
            if (cbDelete2.IsChecked == true)
            {
               MessageBox.Show( conex.agrePermiso("DELETE ", txttabla2.Text, txtRol3.Text));
            }
            if (cbSelect2.IsChecked == true)
            {
               MessageBox.Show( conex.agrePermiso("SELECT", txttabla2.Text, txtRol3.Text));
            }
            if (cbUpdate2.IsChecked == true)
            {
               MessageBox.Show(conex.agrePermiso("UPDATE", txttabla2.Text, txtRol3.Text));
            }

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(conex.agreUsuario(txtRol2.Text, txtUsuario2.Text));
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {

            ControlModifica conexModificar = new ControlModifica();
            conexModificar.Ventana("rol"/*, txtNombreRol.Text, txtesquema.Text)*/);
            conexModificar.ShowDialog();
        }

        private void btnModificarPermiso_Click(object sender, RoutedEventArgs e)
        {
            if (txttabla.Text == null || txtRol2.Text == null)
            {
                MessageBox.Show("No se permiten espacios en blanco");
                txttabla.Background = Brushes.Red;
                txtRol2.Background = Brushes.Red;
            }
            else
            {
                int cont = 0;
                if (cbInsert.IsChecked == true)
                {
                    cont = cont + 1;
                    MessageBox.Show( conex.denePermiso("INSERT", txttabla.Text, txtRol1.Text));
                }
                else
                {

                   MessageBox.Show( conex.agrePermiso("INSERT", txttabla.Text, txtRol1.Text));
                }
                if (cbDelete.IsChecked == true)
                {
                    cont = cont + 1;
                   MessageBox.Show( conex.denePermiso("DELETE ", txttabla.Text, txtRol1.Text));
                }
                else
                {
                   MessageBox.Show( conex.agrePermiso("DELETE", txttabla.Text, txtRol1.Text));
                }
                if (cbSelect.IsChecked == true)
                {
                    cont = cont + 1;
                    MessageBox.Show( conex.denePermiso("SELECT", txttabla.Text, txtRol1.Text));
                }
                else
                {
                   MessageBox.Show( conex.agrePermiso("SELECT", txttabla.Text, txtRol1.Text));
                }
                if (cbUpdate.IsChecked == true)
                {
                    cont = cont + 1;
                  MessageBox.Show(  conex.denePermiso("UPDATE", txttabla.Text, txtRol1.Text));
                }
                else
                {
                  MessageBox.Show(  conex.agrePermiso("UPDATE", txttabla.Text, txtRol1.Text));
                }
                if (cont == 0)
                {
                    MessageBox.Show("Debe Marcar un Permiso");
                }
            }
        }



        private void ModificarUsuario_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(conex.quitarUsuario(txtRol2.Text, txtUsuario2.Text));
            limpiarAsignaUsuario();
        }

        private void btnModificarPerm_Click(object sender, RoutedEventArgs e)

        {

            int cont = 0;
            if (cbInsert.IsChecked == true)
            {
                cont = cont + 1;
                MessageBox.Show(conex.agrePermiso("INSERT", txttabla.Text, txtRol1.Text));
            }
            else
            {

              MessageBox.Show(  conex.denePermiso("INSERT", txttabla.Text, txtRol1.Text));
            }
            if (cbDelete.IsChecked == true)
            {
                cont = cont + 1;
              MessageBox.Show(conex.agrePermiso("DELETE ", txttabla.Text, txtRol1.Text));
            }
            else
            {
               MessageBox.Show( conex.denePermiso("DELETE", txttabla.Text, txtRol1.Text));
            }
            if (cbSelect.IsChecked == true)
            {
                cont = cont + 1;
               MessageBox.Show( conex.agrePermiso("SELECT", txttabla.Text, txtRol1.Text));
            }
            else
            {
               MessageBox.Show( conex.denePermiso("SELECT", txttabla.Text, txtRol1.Text));
            }
            if (cbUpdate.IsChecked == true)
            {
                cont = cont + 1;
                MessageBox.Show( conex.agrePermiso("UPDATE", txttabla.Text, txtRol1.Text));
            }
            else
            {
               MessageBox.Show( conex.denePermiso("UPDATE", txttabla.Text, txtRol1.Text));
            }
            if (cont == 0)
            {
                MessageBox.Show("Debe Marcar un Permiso");

            }

        }

        private void buscar()
        {
            if (cbDelete.IsChecked == true && cbDelete2.IsChecked == true)
            {
                MessageBox.Show("No se pueden marcar las 2 opciones");
                cbDelete.IsChecked = false;
            }
            if (cbInsert.IsChecked == true && cbInsert2.IsChecked == true)
            {
                MessageBox.Show("No se pueden marcar las 2 opciones");
                cbInsert.IsChecked = false;
            }
            if (cbSelect.IsChecked == true && cbSelect2.IsChecked == true)
            {
                MessageBox.Show("No se pueden marcar las 2 opciones");
                cbSelect.IsChecked = false;
            }
            if (cbUpdate.IsChecked == true && cbUpdate2.IsChecked == true)
            {
                MessageBox.Show("No se pueden marcar las 2 opciones");
                cbUpdate.IsChecked = false;
            }
        }

        private void cbInsert_Checked(object sender, RoutedEventArgs e)
        {
            buscar();
        }

        private void cbSelect_Checked(object sender, RoutedEventArgs e)
        {
            buscar();
        }

        private void cbDelete_Checked(object sender, RoutedEventArgs e)
        {
            buscar();
        }

        private void cbUpdate_Checked(object sender, RoutedEventArgs e)
        {
            buscar();
        }

        private void cbInsert2_Checked(object sender, RoutedEventArgs e)
        {
            buscar();
        }

        private void cbSelect2_Checked(object sender, RoutedEventArgs e)
        {
            buscar();
        }

        private void cbDelete2_Checked(object sender, RoutedEventArgs e)
        {
            buscar();
        }

        private void cbUpdate2_Checked(object sender, RoutedEventArgs e)
        {
            buscar();
        }

        private void btnsalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnconsultar_Click(object sender, RoutedEventArgs e)
        {
            if (conex.cargarrol(txtNombreRol.Text) == "si")
            {
                if (conex.cargaSchem(txtNombreRol.Text) != "")
                {
                    txtesquema.Text = conex.cargaSchem(txtNombreRol.Text);
                    
                }
                else
                {
                    txtesquema.Text = "dbo";
                }

            }
            else
            {
                MessageBox.Show("No existe rol");
            }

        }

        private void btnCrear_Click_1(object sender, RoutedEventArgs e)
        {
            int num =0; 
            
            if (txtNombreRol.Text == null || txtNombreRol.Text == "")
            {
                num = 1;
                txtNombreRol.Background = Brushes.Red;

                if (txtesquema.Text == null || txtesquema.Text == "")
                {
                    txtesquema.Text = "dbo";
                }
               
            } 

            if(num == 0)
            {
                txtNombreRol.Background = Brushes.White;
                MessageBox.Show(conex.insertarrol(txtNombreRol.Text, txtesquema.Text));

            }
            else
            {
                MessageBox.Show("Escriba Nombre de Rol");
            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(conex.EliminarRol(txtNombreRol.Text));
            limpiarCreaRol();
        }

        private void txtesquema_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button_Click_2(object sender, RoutedEventArgs e)
        {
            // se limpia la patalla antes de empezar a buscar
            limpiarAsignar();

            // boton buscar permisos con grant
            // busqueda con rol
            if (txtRol1.Text != "" && txttabla.Text == "")
            {
                string objecto =// me trae la tabla de la cual el rol tiene permiso
               conex.cargarObjeto(txtRol1.Text);

                if (objecto != null || objecto != "")
                {
                    txttabla.Text = objecto;
                    if (conex.permisoGrant(txtRol1.Text, objecto, "INSERT") == "INSERT")
                    {
                        cbInsert.IsChecked = true;
                    }

                    if (conex.permisoGrant(txtRol1.Text, objecto, "UPDATE") == "UPDATE")
                    {
                        cbUpdate.IsChecked = true;

                    }

                    if (conex.permisoGrant(txtRol1.Text, objecto, "DELETE") == "DELETE")
                    {
                        cbDelete.IsChecked = true;

                    }

                    if (conex.permisoGrant(txtRol1.Text, objecto, "SELECT") == "SELECT")
                    {
                        cbSelect.IsChecked = true;

                    }

                }
                else
                {
                    MessageBox.Show("NO hay tabla asociada");
                }
            }

            /// busqueda con tabla
            if (txtRol1.Text == "" && txttabla.Text != "")
            {
                string objecto =// contiene el rol
              conex.cargaTablaGrant(txttabla.Text);
                if (objecto != null || objecto != "")
                {
                    txtRol1.Text = objecto;
                    if (conex.permisoRolGrant(txttabla.Text, objecto, "INSERT") == "INSERT")
                    {
                        cbInsert.IsChecked = true;
                    }

                    if (conex.permisoRolGrant(txttabla.Text, objecto, "UPDATE") == "UPDATE")
                    {
                        cbUpdate.IsChecked = true;

                    }

                    if (conex.permisoRolGrant(txttabla.Text, objecto, "DELETE") == "DELETE")
                    {
                        cbDelete.IsChecked = true;

                    }

                    if (conex.permisoRolGrant(txttabla.Text, objecto, "SELECT") == "SELECT")
                    {
                        cbSelect.IsChecked = true;

                    }

                }
                else
                {
                    MessageBox.Show("NO hay tabla asociada");
                }
            }
            // busqueda de permisos con tabla y rol en comun 
                if (txtRol1.Text != "" && txttabla.Text != "")
                {
                if (conex.cargaTablaRolGrant(txtRol1.Text, txttabla.Text, "SELECT") == "SELECT")
                    {
                        cbSelect.IsChecked = true;
                    }

                if(conex.cargaTablaRolGrant(txtRol1.Text, txttabla.Text, "INSERT") == "INSERT")
                {
                    cbInsert.IsChecked = true; 
                }
                if (conex.cargaTablaRolGrant(txtRol1.Text, txttabla.Text, "DELETE") == "DELETE")
                {
                    cbDelete.IsChecked = true;
                }
                if (conex.cargaTablaRolGrant(txtRol1.Text, txttabla.Text, "UPDATE") == "UPDATE")
                {
                    cbUpdate.IsChecked = true; 
                }
            }else
            {
                MessageBox.Show("No se aceptan espacios en blanco");
                txtRol1.Background = Brushes.Red;
                txttabla.Background = Brushes.Red;
            }
            

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

            // limpia pantalla antes de empezar 
            limpiarDenegar();
            // boton de busqueda de permisos con deny
            // busqueda con rol
            if (txtRol3.Text != "" && txttabla2.Text == "")
            {
                string objecto =// contiene la tabla
               conex.cargarObjeto(txtRol3.Text);
                if (objecto != null || objecto != "")
                {
                    txttabla2.Text = objecto;
                    if (conex.permisoDeny(txtRol3.Text, objecto, "INSERT") == "INSERT")
                    {
                        cbInsert2.IsChecked = true;
                    }

                    if (conex.permisoDeny(txtRol3.Text, objecto, "UPDATE") == "UPDATE")
                    {
                        cbUpdate2.IsChecked = true;

                    }
                    if (conex.permisoDeny(txtRol3.Text, objecto, "DELETE") == "DELETE")
                    {
                        cbDelete2.IsChecked = true;

                    }

                    if (conex.permisoDeny(txtRol3.Text, objecto, "SELECT") == "SELECT")
                    {
                        cbSelect2.IsChecked = true;
                    }
                }
                else
                {
                    MessageBox.Show("NO hay tabla asociada");

                }

            }
            // busqueda con tabla
           if(txtRol3.Text == "" && txttabla2.Text != "")
            {

                string objecto =// me trae la tabla de la cual el rol tiene permiso
              conex.cargaRolDeny(txttabla2.Text);
                if (objecto != null || objecto != "")
                {
                   
                    txtRol3.Text = objecto;
                    if (conex.permisoRolDeny(txttabla2.Text, objecto, "INSERT") == "INSERT")
                    {
                        cbInsert2.IsChecked = true;
                    }

                    if (conex.permisoRolDeny(txttabla2.Text, objecto, "UPDATE") == "UPDATE")
                    {
                        cbUpdate2.IsChecked = true;

                    }

                    if (conex.permisoRolDeny(txttabla2.Text, objecto, "DELETE") == "DELETE")
                    {
                        cbDelete2.IsChecked = true;

                    }

                    if (conex.permisoRolDeny(txttabla2.Text, objecto, "SELECT") == "SELECT")
                    {
                        cbSelect2.IsChecked = true;

                    }
                    else
                    {
                        MessageBox.Show("no existe rol asociado");
                    }

                }
                else
                {
                    MessageBox.Show("NO hay rol asociado");
                }
          
            }

           // busqueda de permisos que  rol y tabla tenga en comun
           if(txtRol3.Text != "" && txttabla2.Text != "")
            {
                if (conex.cargaTablaRolDeny(txtRol3.Text, txttabla2.Text, "INSERT") == "INSERT")
                {
                    cbInsert2.IsChecked = true; 
                }
                if (conex.cargaTablaRolDeny(txtRol3.Text, txttabla2.Text, "UPDATE") == "UPDATE")
                {
                    cbUpdate2.IsChecked = true; 
                }
                if (conex.cargaTablaRolDeny(txtRol3.Text, txttabla2.Text, "SELECT") == "SELECT")
                {
                    cbSelect2.IsChecked = true;
                }

                if (conex.cargaTablaRolDeny(txtRol3.Text, txttabla2.Text, "DELETE") == "DELETE")
                {
                    cbDelete2.IsChecked = true;
                }
                else
                {
                    MessageBox.Show("NO hay permisos");
                }
            }
        }// fin del boton buscar con deny

        private void limpiarCreaRol()// limpia los campos de crear rol, el nombre del rol y el esquema al que este pertenece
        {
            txtNombreRol.Text = "";
            txtesquema.Text = "";
        }
        private void limpiarAsignar() // limpia los checksbox de asignar
        {
            cbDelete.IsChecked = false;
            cbInsert.IsChecked = false;
            cbSelect.IsChecked = false;
            cbUpdate.IsChecked = false;
        }
        private void limpiarDenegar() // limpia los checksbox de denegar
        {
            cbDelete2.IsChecked = false;
            cbInsert2.IsChecked = false;
            cbSelect2.IsChecked = false;
            cbUpdate2.IsChecked = false;
        }
        private void limpiarAsignaUsuario() // limpia los campos de asigan usuario a rol, campo de nombre de susario y el campo de rol
        {
            txtRol2.Text = "";
            txtUsuario2.Text = "";
        }
    }
}

