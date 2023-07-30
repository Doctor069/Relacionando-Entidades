using NET_6_criando_uma_web.Data.Dtos.EnderecoDto;
using NET_6_criando_uma_web.Data.Dtos.Session;

namespace NET_6_criando_uma_web.Data.Dtos.Movie_theater
{
    public class ReadCinemaDto
    {
        public int IdCinema { get; set; }
        public string NomeCinema { get; set; }

        public ReadEnderecoDto Endereco { get; set; }  // Relação 1:1

        public ICollection<ReadSessaoDto> Sessoes { get; set; }
    }
}
