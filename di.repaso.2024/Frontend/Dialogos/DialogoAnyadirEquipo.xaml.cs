using di.repaso._2024.Backend.Modelo;
using di.repaso._2024.MVVM;
using MahApps.Metro.Controls;
using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.Controls.Dialogs;
using Org.BouncyCastle.Pqc.Crypto.Lms;

namespace di.repaso._2024.Frontend.Dialogos
{
    /// <summary>
    /// Lógica de interacción para DialogoAnyadirEquipo.xaml
    /// </summary>
    public partial class DialogoAnyadirEquipo : MetroWindow
    {
        private nbaContext nbaContext;
        private MVEquipoNuevo mvEquipoNuevo;
        public DialogoAnyadirEquipo(nbaContext nbaContext)
        {
            InitializeComponent();
            this.nbaContext = nbaContext;
            mvEquipoNuevo = new MVEquipoNuevo(nbaContext);
            this.AddHandler(Validation.ErrorEvent, new RoutedEventHandler(mvEquipoNuevo.OnErrorEvent));
            this.DataContext = mvEquipoNuevo;
            mvEquipoNuevo.btnGuardar = btnGuardar;
        }

        private async void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (mvEquipoNuevo.IsValid(this))
            {
                if (mvEquipoNuevo.Guardar())
                {
                    await this.ShowMessageAsync("GESTION EQUIPO", 
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
