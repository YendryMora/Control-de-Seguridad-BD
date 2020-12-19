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
    /// Interaction logic for ControlModifica.xaml
    /// </summary>
    public partial class ControlModifica : Window
    {
        public ControlModifica()
        {
            InitializeComponent();
        }
        private string tipo;// tipo de ventana
        //private string valor; // valor a cambiar
        //private string objeto; 
  

      
        private void btnContra_Click(object sender, RoutedEventArgs e)
        {
            if (tipo == "rol")
            {
               modificarLogin modificar = new modificarLogin();
                modificar.Proceso("rol"/*, objeto*/);
                modificar.ShowDialog();
                this.Close();
            }
            if (tipo == "usuario")
            {
                modificarLogin modificar = new modificarLogin();
                modificar.Proceso("usuario"/*, objeto*/);
                modificar.ShowDialog();
                this.Close();
            }
            if (tipo == "login")
            {
                modificarLogin modificar = new modificarLogin();
                modificar.Proceso("login"/*, objeto*/);
                modificar.ShowDialog();
                this.Close();
            }
        }

        private void btnNom_Click(object sender, RoutedEventArgs e)
        {
            if (tipo == "rol")
            {
                Modificar modificar = new Modificar();
                modificar.Proceso("rol"/*, objeto*/);
                modificar.ShowDialog();
                this.Close();
            }
            if (tipo == "usuario")
            {
                Modificar modificar = new Modificar();
                modificar.Proceso("usuario"/*, objeto*/);
                modificar.ShowDialog();
                this.Close();
            }
            if (tipo == "login")
            {
                Modificar modificar = new Modificar();
                modificar.Proceso("login"/*, objeto*/);
                modificar.ShowDialog();
                this.Close();
            }

        }
        public void Ventana(string nom/*, string valor1, string valor2)*/)
        {
            tipo = nom;
            //valor = valor1;
            //objeto = valor2;
        }
    }
}
