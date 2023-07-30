using NET_6_criando_uma_web.Data.Dtos.Session;
using System.ComponentModel.DataAnnotations;

namespace NET_6_criando_uma_web.Data.Dtos.Movie
{
    public class ReadFilmeDto
    {
        public string Titulo { get; set; }

        public string Genero { get; set; }

        public int Duracao { get; set; }
        public DateTime HoraDaConsulta { get; set; } = DateTime.Now;

        public ICollection<ReadSessaoDto> Sessoes { get; set; }
    }
}
