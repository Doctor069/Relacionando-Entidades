using NET_6_criando_uma_web.Models.Movie_theater;
using NET_6_Relacionando_Entidades.Models;

namespace NET_6_criando_uma_web.Models
{
    public class Sessao
    {
        //1:n --- um para muitos
        public int? FilmeId { get; set; }
        public virtual Filme Filme { get; set; }
        public int? CinemaId { get; set; }  // --- int? --- ? pode ser nulo no sistema
        public virtual Cinema Cinema { get; set; }

        //N:N  --- muitos para muitos

    }
}
