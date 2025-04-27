using System;
using System.ComponentModel.DataAnnotations;

namespace FerramentaAutismo.Models
{
    public class FAQ
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "A pergunta é obrigatória")]
        [Display(Name = "Pergunta")]
        [StringLength(500, ErrorMessage = "A pergunta não pode exceder 500 caracteres")]
        public string Pergunta { get; set; }

        [Required(ErrorMessage = "A resposta é obrigatória")]
        [Display(Name = "Resposta")]
        public string Resposta { get; set; }

        [Display(Name = "Categoria")]
        [StringLength(100, ErrorMessage = "A categoria não pode exceder 100 caracteres")]
        public string Categoria { get; set; }

        [Display(Name = "Ordem de exibição")]
        public int Ordem { get; set; }

        [Display(Name = "Ativo")]
        public bool Ativo { get; set; } = true;

        [Display(Name = "Data de criação")]
        public DateTime DataCriacao { get; set; } = DateTime.Now;
    }
}
