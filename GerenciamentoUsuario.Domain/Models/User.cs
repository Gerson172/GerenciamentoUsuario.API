using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoUsuario.Domain.Models
{
    public class User
    {
        [Key]
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public String Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [EmailAddress(ErrorMessage = "O campo {0} precisa ser um e-mail válido!")]
        public String Email { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public String Cpf { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public DateTime DataNasc { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public String Senha_hash { get; set; }
    }
}
