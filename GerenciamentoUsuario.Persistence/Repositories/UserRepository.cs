using Dapper;
using GerenciamentoUsuario.Domain.DTO;
using GerenciamentoUsuario.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GerenciamentoUsuario.Persistence.Repositories
{
    public class UserRepository : SqlDataAccess, IUserRepository
    {
        public UserRepository() : base(SqlConfig.ConnectionString){}

        public List<UserDTO> FindAllUsers()
        {
            using (var db = GetChargingSqlDbConnection)
            {
                return db.Query<UserDTO>("SELECT * FROM USUARIOS").ToList();
            }
        }

        public UserDTO FindUserByID(int id)
        {
            using (var db = GetChargingSqlDbConnection)
            {
                return db.Query<UserDTO>(
                    $"SELECT * FROM USUARIOS WHERE Id = {id} ").FirstOrDefault();
            }
        }

        public void Create(UserDTO user)
        {
            using (var db = GetChargingSqlDbConnection)
            {
                UserDTO dto = new UserDTO
                {
                    Id = user.Id,
                    Nome = user.Nome,
                    Email = user.Email,
                    Cpf = user.Cpf,
                    DataNasc = user.DataNasc,
                    Senha_hash = user.Senha_hash
                };

                db.Execute($@"INSERT INTO Usuarios(Nome, Email,Cpf,DataNasc,Senha_Hash) VALUES(@Nome, @Email, @Cpf, @DataNasc, @Senha_hash)", user);
            }
        }
        public void Update(UserDTO user)
        {
            using (var db = GetChargingSqlDbConnection)
            {
                UserDTO dto = new UserDTO
                {
                    Id = user.Id,
                    Nome = user.Nome,
                    Email = user.Email,
                    Cpf = user.Cpf,
                    DataNasc = user.DataNasc,
                    Senha_hash = user.Senha_hash
                };

                db.Execute($@"UPDATE Usuarios SET  Nome = @Nome, Email = @Email, Cpf = @Cpf, DataNasc = @DataNasc, Senha_hash = @Senha_Hash WHERE Id = @Id", user);
            }
        }

        public UserDTO Delete(int id)
        {
            using (var db = GetChargingSqlDbConnection)
            {                   
                return db.Query<UserDTO>($@"DELETE Usuarios WHERE Id = {id}").FirstOrDefault();
            }
        }

        public bool CheckEmailAndPassword(UserDTO user)
        {
            try
            {

                using (var db = GetChargingSqlDbConnection)
                {
                    UserDTO dto = new UserDTO
                    {
                        Email = user.Email,
                        Cpf = user.Cpf,

                    };

                    return db.QuerySingleOrDefault<bool>($@"SELECT * FROM Usuarios WHERE Email = @Email OR Cpf = @Cpf ", dto);
                    
                }
            }catch(Exception e)
            {
                return true;
            }
        }
    }
}
