using System.ComponentModel.DataAnnotations;

namespace TrabalhoDAAW.Models
{
    public class Marca
    {
        [Display(Name = "Marca")]
        public int Marcaid { get; set; }

        [Display(Name = "Marca")]
        public string Nome { get; set; }
    }
}
