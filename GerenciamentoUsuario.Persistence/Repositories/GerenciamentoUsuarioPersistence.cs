using GerenciamentoUsuario.Domain.DTO;
using GerenciamentoUsuario.Domain.Models;
using GerenciamentoUsuario.Persistence.Interfaces;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoUsuario.Persistence
{
    public class GerenciamentoUsuarioPersistence : IGerenciamentoUsuarioPersistence
    {
        private readonly IUserRepository _repos;
        public readonly ILogger _logger;

        public GerenciamentoUsuarioPersistence(IUserRepository repos, ILogger<GerenciamentoUsuarioPersistence> logger)
        {
            _repos = repos;
            _logger = logger;
        }
        public List<UserDTO> FindAllUsersRepository()
        {
            var users = _repos.FindAllUsers();
            return users;
        }

        public UserDTO FindUserByIDRepository(int id)
        {
            var user = _repos.FindUserByID(id);
            return user;
        }

        public UserDTO CreateRepository(UserDTO user)
        {
            byte[] salt = new byte[128 / 8];
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetNonZeroBytes(salt);
            }
            var senha = user.Senha_hash;
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: senha,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 8));

            user.Senha_hash = hashed;

            var check = CheckEmailAndPassword(user);
            if (check)
            {
                _logger.LogError($"Valor de email ou cpf já existe! {user.Email} - {user.Cpf}");
                return null;
            }

            _repos.Create(user);
            return user;
            
        }

        public UserDTO UpdateRepository(UserDTO user)
        {
            var check = CheckEmailAndPassword(user);
            if (check)
            {
                _logger.LogError($"Valor de email ou cpf já existe! {user.Email} - {user.Cpf}");
                return null;
            }

            _repos.Update(user);
            return user;
        }

        public UserDTO DeleteRepository(int id)
        {
            var userDelete = _repos.Delete(id);
            return userDelete;
        }
        private bool CheckEmailAndPassword(UserDTO user)
        {
            var checkEmailAndPassword = _repos.CheckEmailAndPassword(user);
            if (checkEmailAndPassword)
                return true;

            return false;
        }
    }
}
