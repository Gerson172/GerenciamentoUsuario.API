using GerenciamentoUsuario.Domain.DTO;
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
        List<UserDTO> FindAllUsersRepository();
        UserDTO FindUserByIDRepository(int id);
        UserDTO CreateRepository(UserDTO user);
        UserDTO UpdateRepository(UserDTO user);
        UserDTO DeleteRepository(int id);
    }
}
