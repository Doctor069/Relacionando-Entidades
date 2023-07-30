using System.ComponentModel.DataAnnotations;

namespace NET_6_criando_uma_web.Models.Movie_theater
{
    public class Cinema
    {
        [Key]
        [Required]
        public int IdCinema { get; set; }

        [Required(ErrorMessage = "O campo é obrigatorio ser preenchiodo")]
        public string NomeCinema { get; set; }

        //Relação de 1:1 --- no caso cada cinema possui um unico endereco --- alem que um cinema precisa de um endereço, e um endereço nao precisa de um cinema
        public int EnderecoId { get; set; } 
        public virtual Endereco Endereco { get; set; }

        //relação 1:n
        public virtual ICollection<Sessao> Sessoes { get; set; }
    }
}
