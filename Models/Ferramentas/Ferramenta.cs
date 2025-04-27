using System;
using System.ComponentModel.DataAnnotations;

namespace FerramentaAutismo.Models
{
    public class Ferramenta
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome da ferramenta é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome não pode exceder 100 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A descrição da ferramenta é obrigatória")]
        [StringLength(500, ErrorMessage = "A descrição não pode exceder 500 caracteres")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O tipo da ferramenta é obrigatório")]
        [StringLength(50, ErrorMessage = "O tipo não pode exceder 50 caracteres")]
        public string Tipo { get; set; }

        [Url(ErrorMessage = "Forneça uma URL válida")]
        public string UrlAcesso { get; set; }

        [StringLength(100)]
        public string IconeClasse { get; set; }

        public string ImagemUrl { get; set; }

        [Range(0, 5, ErrorMessage = "A classificação deve estar entre 0 e 5")]
        public decimal Classificacao { get; set; }

        [StringLength(200)]
        public string PublicoAlvo { get; set; }

        public bool EhGratuita { get; set; }

        public DateTime DataCadastro { get; set; } = DateTime.Now;
    }
}