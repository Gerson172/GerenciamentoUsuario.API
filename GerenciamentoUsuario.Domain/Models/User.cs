using System;
using System.ComponentModel.DataAnnotations;

namespace GerenciamentoUsuario.Domain.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public String Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public String Email { get; set; }

        //[Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public String Cpf { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public DateTime DataNasc { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public String Senha_hash { get; set; }
    }
}
