using di.repaso._2024.Backend.Modelo;
using di.repaso._2024.MVVM;
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

namespace di.repaso._2024.Frontend.ControlUsuario
{
    /// <summary>
    /// Lógica de interacción para UCEquipo.xaml
    /// </summary>
    public partial class UCEquipo : UserControl
    {
        private nbaContext nbacontext;
        private MVEquipoNuevo mvEquipo;
        public UCEquipo(nbaContext nbaContext)
        {
            InitializeComponent();
            this.nbacontext = nbaContext;
            Inicializa();
        }
        private void Inicializa()
        {
            mvEquipo = new MVEquipoNuevo(nbacontext);
            DataContext = mvEquipo;
        }

        private void chkAgruparDivision_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void chkAgruparDivision_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void chkAgruparConferencia_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void chkAgruparConferencia_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void txtBuscador_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
