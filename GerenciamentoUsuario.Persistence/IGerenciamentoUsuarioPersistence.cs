using GerenciamentoUsuario.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoUsuario.Persistence
{
    public interface IGerenciamentoUsuarioPersistence
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        Task<User> GetAllUserById(int IdUser);
        Task<User[]> GetAllUsersAsync(string usuario);


    }
}
