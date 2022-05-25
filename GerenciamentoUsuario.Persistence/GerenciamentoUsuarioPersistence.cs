using GerenciamentoUsuario.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoUsuario.Persistence
{
    public class GerenciamentoUsuarioPersistence : IGerenciamentoUsuarioPersistence
    {
        private readonly DataContext _context;

        public GerenciamentoUsuarioPersistence(DataContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
        public Task<User> GetAllUserById(int IdUser)
        {
            throw new NotImplementedException();
        }
        public async Task<User[]> GetAllUsersAsync(string usuario)
        {
            var allUsers = _context.Usuarios.OrderBy(user => user.IdUsuario);


            return await allUsers.ToArrayAsync();
        }
    }
}
