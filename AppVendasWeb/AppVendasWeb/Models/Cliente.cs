using System.ComponentModel.DataAnnotations;

namespace AppVendasWeb.Models
{
    public class Cliente
    {
        public Guid ClienteId { get; set; }
        [Display(Name = "Nome do Cliente")]
        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo Nome deve ter no máximo 100 caracteres")]
        public string ClienteNome { get; set; }

        [Required(ErrorMessage = "O campo CPF é obrigatório")]
        [StringLength(14, ErrorMessage = "O campo Nome deve ter no máximo 11 caracteres")]
        public string CPF { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "O campo CPF é obrigatório")]
        [StringLength(150, ErrorMessage = "O campo email deve ter no máximo 150 caracteres")]
        public string Email { get; set; }

        [Display(Name = "Data de Nascimento")]
        [Required(ErrorMessage = "O campo Data de Nascimento é obrigatório")]

        public DateOnly DataNascimento { get; set; }

        [StringLength(15)]
        public string? Telefone { get; set; }

        [Display(Name = "Data de Cadastro")]
        public DateTime? DateCadastro { get; set; }

        [Display(Name = "Cadastro Ativo")]
        public bool CadastroAtivo { get; set; }
    }
}
