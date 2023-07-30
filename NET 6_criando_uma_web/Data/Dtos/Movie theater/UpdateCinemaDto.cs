using System.ComponentModel.DataAnnotations;

namespace NET_6_criando_uma_web.Data.Dtos.Movie_theater
{
    public class UpdateCinemaDto
    {
        [Required(ErrorMessage = "O campo é obrigatorio ser preenchiodo")]
        public string NomeCinema { get; set; }
    }
}
