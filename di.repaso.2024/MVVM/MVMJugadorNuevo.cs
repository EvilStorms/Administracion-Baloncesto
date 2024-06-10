using di.repaso._2024.Backend.Modelo;
using di.repaso._2024.Backend.Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace di.repaso._2024.MVVM
{
    public class MVMJugadorNuevo : MVBaseCRUD<jugadore>, INotifyPropertyChanged, IDataErrorInfo
    {
        private nbaContext nbaContext;
        private ServicioEquipo equipoServ;
        private ServicioJugador jugadorServ;
        private jugadore _jugadore;

        public MVMJugadorNuevo()
        {

        }

        public MVMJugadorNuevo(nbaContext nbaContext)
        {
            this.nbaContext = nbaContext;
            inicializa();
        }
        private void inicializa()
        {
            equipoServ = new ServicioEquipo(nbaContext);
            jugadorServ = new ServicioJugador(nbaContext);
            _jugadore = new jugadore();
            servicio = jugadorServ;
        }

        public jugadore jugadore { get { return _jugadore; } set { _jugadore = value; NotifyPropertyChanged(nameof(jugadore)); } }

        public List<string> listaPosiciones { get { return jugadorServ.getPosiciones(); } }

        public List<equipo> listaEquipos { get { return equipoServ.getAll; } }

        public bool Guardar()
        {
            return add(jugadore);
        }
    }
}
