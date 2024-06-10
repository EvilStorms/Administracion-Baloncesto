using di.repaso._2024.Backend.Modelo;
using di.repaso._2024.MVVM;
using MahApps.Metro.Controls;
using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace di.repaso._2024.Frontend.Dialogos
{
    /// <summary>
    /// Lógica de interacción para DialogoAnyadirJugador.xaml
    /// </summary>
    public partial class DialogoAnyadirJugador : MetroWindow
    {
        private MVMJugadorNuevo mvJugadorNuevo;
        private nbaContext nbaContext;
        public DialogoAnyadirJugador(nbaContext nbaContext)
        {
            InitializeComponent();
            this.nbaContext = nbaContext;
            mvJugadorNuevo = new MVMJugadorNuevo(nbaContext);
            this.AddHandler(Validation.ErrorEvent, new RoutedEventHandler(mvJugadorNuevo.OnErrorEvent));
            this.DataContext = mvJugadorNuevo;
            mvJugadorNuevo.btnGuardar = btnGuardar;
        }

        private async void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (mvJugadorNuevo.IsValid(this))
            {
                if (mvJugadorNuevo.Guardar())
                {
                    await this.ShowMessageAsync("GESTION JUGADOR",
                        "TODO CORRECTO!!! Se ha guardado el objeto en la base de datos");
                }
            }
            this.Close();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
