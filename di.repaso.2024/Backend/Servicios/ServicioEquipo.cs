using di.repaso._2024.Backend.Modelo;
using Microsoft.EntityFrameworkCore;

namespace di.repaso._2024.Backend.Servicios
{
    public class ServicioEquipo : ServicioGenerico<equipo>
    {

        private nbaContext contexto;

        public ServicioEquipo(nbaContext context) : base(context)
        {
            contexto = context;
        }

        public int getLastId()
        {
            jugadore ju = contexto.Set<jugadore>().OrderByDescending(j => j.codigo).FirstOrDefault();
            return ju.codigo;
        }

        public bool NombreUnico(string nombre)
        {
            return contexto.Set<equipo>().Where(e => e.Nombre == nombre).Count() == 0;
        }

        public List<string> getDivisiones()
        {
            var result = from eq in contexto.equipos
                         group eq by eq.Division into d
                         select d.Key;
            return result.ToList();
            
            /*var result = contexto.Database.SqlQuery<string>("select Division from equipos group by Division").ToList();
            return result;*/
        }

        public List<string> getConferencias()
        {
            var confs = from eq in contexto.equipos
                        group eq by eq.Conferencia into c
                        select c.Key;
            return confs.ToList();
        }

    }
}
