using PracticaExamen.BC.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaExamen.BW.Interfaces.DA
{
    public interface IGestionarUsuarioDA
    {
        Task<bool> registreUsuario(Usuario usuario);
        Task<bool> actualiceUsuario(Usuario usuario);
        Task<bool> elimineUsuario(string cedula);
        Task<Usuario> obtengaDatosUsuario(string cardUsuario, string password);
        Task<IEnumerable<Usuario>> obtengaUsuarios();
    }
}
