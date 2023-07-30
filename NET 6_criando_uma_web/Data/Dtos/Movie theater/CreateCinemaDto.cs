using System.ComponentModel.DataAnnotations;

namespace NET_6_criando_uma_web.Data.Dtos.Movie_theater
{
    public class CreateCinemaDto
    {
        [Required(ErrorMessage = "O campo é obrigatorio ser preenchiodo")]
        public string NomeCinema { get; set; }

        public int EnderecoId { get; set; } // Relação 1:1
    }
}
