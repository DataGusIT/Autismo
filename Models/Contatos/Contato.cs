using System;
using System.ComponentModel.DataAnnotations;

namespace FerramentaAutismo.Models
{
    public class Contato
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do contato é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome não pode exceder 100 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A descrição do contato é obrigatória")]
        [StringLength(500, ErrorMessage = "A descrição não pode exceder 500 caracteres")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O tipo do contato é obrigatório")]
        [StringLength(50, ErrorMessage = "O tipo não pode exceder 50 caracteres")]
        public string Tipo { get; set; }

        [Url(ErrorMessage = "Forneça uma URL válida")]
        public string WebsiteUrl { get; set; }

        [Phone(ErrorMessage = "Forneça um telefone válido")]
        public string Telefone { get; set; }

        [EmailAddress(ErrorMessage = "Forneça um email válido")]
        public string Email { get; set; }

        [StringLength(200)]
        public string Endereco { get; set; }

        [StringLength(100)]
        public string Cidade { get; set; }

        [StringLength(2)]
        public string Estado { get; set; }

        [StringLength(100)]
        public string IconeClasse { get; set; }

        public string ImagemUrl { get; set; }

        [Range(0, 5, ErrorMessage = "A avaliação deve estar entre 0 e 5")]
        public decimal Avaliacao { get; set; }

        public bool AtendimentoOnline { get; set; }

        public bool AtendimentoPresencial { get; set; }

        public DateTime DataCadastro { get; set; } = DateTime.Now;

        public string HorarioFuncionamento { get; set; }
    }
}