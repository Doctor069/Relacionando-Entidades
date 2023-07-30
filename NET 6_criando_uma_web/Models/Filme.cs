using NET_6_criando_uma_web.Models;
using System.ComponentModel.DataAnnotations;

namespace NET_6_Relacionando_Entidades.Models
{
    public class Filme
    {
        [Key]
        [Required]
        public int IdFilme { get; set; }

        [Required(ErrorMessage = "Titulo do filme é obrigatorio")] // Required quer dizer que tal campo tem que ser obrigatorio atender tais medidads
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Genero obrigaorio ser preenchido")] // ErrorMessage - caso nao seja preenchido aparecerar
        public string Genero { get; set; }

        [Required]
        [Range(70, 600, ErrorMessage = "A duração tem que ser entre 70 e 600 minutos")] // Range - entre 70 e 600 minutos é permitido
        public int Duracao { get; set; }

        //1:n --- um para muitos
        public virtual ICollection<Sessao> Sessoes { get; set; }
    }
}
