using System.ComponentModel.DataAnnotations;

namespace TrabalhoDAAW.Models
{
    public class CadastroUsuario
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string senha { get; set; }
        [Required]
        public string email { get; set; }

    }
}
