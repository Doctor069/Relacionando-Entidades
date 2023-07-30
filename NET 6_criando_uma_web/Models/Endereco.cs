using NET_6_criando_uma_web.Models.Movie_theater;
using System.ComponentModel.DataAnnotations;

namespace NET_6_criando_uma_web.Models
{
    public class Endereco
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public string Logradouro { get; set; }

        public int Numero { get; set; }

        public virtual Cinema Cinema { get; set; } // Relação 1:1 --- o cinema apenas pode possuir um endereço
    }
}
