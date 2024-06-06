using System.ComponentModel.DataAnnotations;

namespace TrabalhoDAAW.Models
{
    public class Suporte
    {
        [Key]
        public int MessageId { get; set; }

        public string Nome { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "O Email prenchido não é um email válido.")]
        public string Email { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        public string Conteudo { get; set; }

        public DateTime DataEnvio { get; set; } = DateTime.Now;

    }
}
