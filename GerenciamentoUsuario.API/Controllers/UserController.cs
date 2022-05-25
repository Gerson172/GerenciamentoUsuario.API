using GerenciamentoUsuario.Domain.Models;
using GerenciamentoUsuario.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoUsuario.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        public readonly DataContext _context;


        public UserController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<User> Get() 
        {
            // caso não tiver nenhum usuário relatado, mostrar http correto.
            return _context.Usuarios;
        }

        [HttpGet("{id}")]
        public IEnumerable<User> GetById(int id) 
        {
            return _context.Usuarios.Where(usuario => usuario.IdUsuario == id);
        }

        [HttpPost]
        public string Post()
        {
            // - senhas devem ser salvas em formato hash
            // - não deve permitir usuários com mesmo e-mail e cpf

            return "Teste post";
        }

        [HttpPut]
        public string Put()
        {
            // não alterar caso o email e cpf já esteja cadastrado no banco.
            return "Teste put";
        }
        [HttpDelete]
        public string Delete()
        {
            return "Teste delete";
        }
    }
}
