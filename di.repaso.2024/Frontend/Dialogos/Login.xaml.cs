using di.repaso._2024.Backend.Modelo;
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

namespace di.repaso._2024.Frontend.Dialogos
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private nbaContext? nbaContext;
        public Login()
        {
            if (ConectaBD())
            {
                InitializeComponent();
            }
            else
            {
                MessageBox.Show("ERROR!!! No hay comunicacion con la base de datos\n" +
                    "Ponte en contacto con tu administrador de sistemas",
                    "ACCESO A LA BASE DE DATOS", MessageBoxButton.OK, MessageBoxImage.Error);
                Application.Current.Shutdown();
            }

        }
        private bool ConectaBD()
        {
            bool conecta = true;
            nbaContext = new nbaContext();
            try
            {
                //nbaContext.Database.OpenConnection();
            }
            catch (Exception ex)
            {
                conecta = false;
            }
            return conecta;
        }

        private void btnIniciarSesion_Click(object sender, RoutedEventArgs e)
        {
            MainWindow ventanaPrincipal = new MainWindow(nbaContext);
            ventanaPrincipal.Show();
            this.Close();
        }
    }
}
