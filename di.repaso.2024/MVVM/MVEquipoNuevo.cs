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
    public class MVEquipoNuevo : MVBaseCRUD<equipo>, INotifyPropertyChanged, IDataErrorInfo
    {
        private nbaContext nbaContext;
        private ServicioEquipo equipoServ;
        private equipo _equipo;

        public MVEquipoNuevo() { }

        public MVEquipoNuevo(nbaContext nbaContext)
        {
            this.nbaContext = nbaContext;
            inicializa();
        }

        private void inicializa()
        {
            _equipo = new equipo();
            equipoServ = new ServicioEquipo(nbaContext);
            servicio = equipoServ;

        }

        public equipo Equipo { get { return _equipo; } set { _equipo = value; NotifyPropertyChanged(nameof(Equipo)); } }

        public List<string> listaConferencias { get { return equipoServ.getConferencias(); } }

        public List<string> listaDivisiones { get { return equipoServ.getDivisiones(); } }

        public bool nomEqUnico { get { return equipoServ.NombreUnico(_equipo.Nombre); } }

        public List<equipo> listaEquipos { get { return equipoServ.getAll; } }

        public bool Guardar()
        {
            return add(Equipo);
        }
    }
}
