using GerenciamentoUsuario.Domain.DTO;
using GerenciamentoUsuario.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System;

namespace GerenciamentoUsuario.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        public readonly IGerenciamentoUsuarioPersistence _context;
        public readonly ILogger _logger;


        public UserController(IGerenciamentoUsuarioPersistence context, ILogger<GerenciamentoUsuarioPersistence> logger)
        {
            _context = context;
            _logger = logger;
        }

        [SwaggerOperation(Summary = "Consulta todos os usuários")]
        [HttpGet("FindAllUsers")]
        public IActionResult FindAllUsers() 
        {
            try
            {
                var result = _context.FindAllUsersRepository();
                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Erro ao realizar a operação!");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [SwaggerOperation(Summary = "Encontra usuários cadastrados por Id")]
        [HttpGet("FindUsersById/{id}")]
        public IActionResult FindUsersById(int id) 
        {
            try
            {
                var result = _context.FindUserByIDRepository(id);
                if (result == null)
                    return NotFound();

                return Ok(result);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao realizar a operação!");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [SwaggerOperation(Summary = "Cria um usuário")]
        [HttpPost("CreateUser")]
        public IActionResult CreateUser(UserDTO user)
        {
            try
            {
                var result = _context.CreateRepository(user);
                if (result == null)
                    return BadRequest();

                return StatusCode(StatusCodes.Status201Created);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao realizar a operação!");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [SwaggerOperation(Summary = "Atualiza os dados de um usuario")]
        [HttpPut("UpdateUser")]
        public IActionResult UpdateUser(UserDTO user)
        {
            // não alterar caso o email e cpf já esteja cadastrado no banco.
            try
            {
                var result = _context.UpdateRepository(user);
                if (result == null)
                    return BadRequest();

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao realizar a operação!");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [SwaggerOperation(Summary = "Deleta um usuários")]
        [HttpDelete("DeleteUser")]
        public IActionResult Delete(int id)
        {
            try
            {
                var result = _context.DeleteRepository(id);
                if (result == null)
                    return NotFound();

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao realizar a operação!");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
