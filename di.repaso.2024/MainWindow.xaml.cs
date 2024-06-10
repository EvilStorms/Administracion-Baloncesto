using di.repaso._2024.Backend.Modelo;
using di.repaso._2024.Frontend.ControlUsuario;
using di.repaso._2024.Frontend.Dialogos;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace di.repaso._2024
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private nbaContext nbaContext;

        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(nbaContext nbaContext)
        {
            InitializeComponent();
            this.nbaContext = nbaContext;
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAnyadirEquipo_Click(object sender, RoutedEventArgs e)
        {
            DialogoAnyadirEquipo anyadirEquipo = new DialogoAnyadirEquipo(nbaContext);
            anyadirEquipo.Show();
        }

        private void anyadirJugador_Click(object sender, RoutedEventArgs e)
        {
            DialogoAnyadirJugador anyadirJugador = new DialogoAnyadirJugador(nbaContext);
            anyadirJugador.Show();
        }

        private void listaEquipos_Click(object sender, RoutedEventArgs e)
        {
            UCEquipo uc = new UCEquipo(nbaContext);
            if(!gridCentral.Children.Contains(uc)) gridCentral.Children.Clear();
            gridCentral.Children.Add(uc);
        }
    }
}