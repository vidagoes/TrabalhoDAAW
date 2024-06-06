﻿using System.ComponentModel.DataAnnotations;

namespace TrabalhoDAAW.Models
{
    public class Produto
    {
        public int Id { get; set; }

        public string Modelo { get; set; }

        public string Cor { get; set; }

        [Display(Name = "Tipo da Corda")]
        public string TipoCorda { get; set; }

        public string Tipo { get; set; }

        public int MarcaId { get; set; }

        public Marca? Marca { get; set; }
        [Required]
        public decimal Preco { get; set; }

        public string LinkImagem { get; set; }
    }
}