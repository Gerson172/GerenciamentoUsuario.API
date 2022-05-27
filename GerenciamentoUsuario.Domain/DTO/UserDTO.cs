using GerenciamentoUsuario.Domain.Models;
using System;

namespace GerenciamentoUsuario.Domain.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public String Email { get; set; }
        public String Cpf { get; set; }
        public DateTime DataNasc { get; set; }
        public String Senha_hash { get; set; }

        public User MapToEntity() => new User
        {
            Id = Id,
            Nome = Nome,
            Email = Email,
            Cpf = Cpf,
            DataNasc = DataNasc,
            Senha_hash = Senha_hash
        };
    }
}
