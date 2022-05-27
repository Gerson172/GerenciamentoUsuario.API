using GerenciamentoUsuario.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoUsuario.Persistence.Interfaces
{
    public interface IUserRepository
    {
        List<UserDTO> FindAllUsers();
        UserDTO FindUserByID(int id);
        void Create(UserDTO user);
        void Update(UserDTO user);
        UserDTO Delete(int id);
        bool CheckEmailAndPassword(UserDTO user);
    }
}
