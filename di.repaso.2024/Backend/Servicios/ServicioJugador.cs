using di.repaso._2024.Backend.Modelo;

namespace di.repaso._2024.Backend.Servicios
{
    public class ServicioJugador : ServicioGenerico<jugadore>
    {
        private nbaContext contexto;

        public ServicioJugador(nbaContext context) : base(context)
        {
            contexto = context;
        }

        public int getLastId()
        {
            jugadore ju = contexto.Set<jugadore>().OrderByDescending(j => j.codigo).FirstOrDefault();
            return ju.codigo;
        }

        public List<string> getPosiciones()
        {
            var pos = from ju in contexto.jugadores
                        group ju by ju.Posicion into p
                        select p.Key;
            return pos.ToList();
        }
		
		public List<string> getTemporadas()
        {
            var result = from par in contexto.partidos
                         group par by par.temporada into t
                         select t.Key;
            return result.ToList();
        }
    }
}
