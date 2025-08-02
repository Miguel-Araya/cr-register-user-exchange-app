using PracticaExamen.API.DTOs;
using PracticaExamen.BC.Modelos;

namespace PracticaExamen.API.Utilitarios
{
    public class UsuarioDTOMapper
    {
        public static async Task<UsuarioDTO> convertirUsuarioADTO(Usuario usuario)
        {
            if (usuario == null)
            {
                throw new ArgumentNullException(nameof(usuario), "El objeto Usuario no puede ser null");
            }

            return new UsuarioDTO()
            {
                Name = usuario.Name,
                LastName = usuario.LastName,
                CardUser = usuario.CardUser,
                Password = usuario.Password,
                PhoneNumber = usuario.PhoneNumber,
                Email = usuario.Email,
                UserBirthdate = usuario.UserBirthdate,
            };

        }
        public static async Task<Usuario> convertirDTOAUsuario(UsuarioDTO usuarioDTO)
        {
            return new Usuario()
            {
                Name = usuarioDTO.Name,
                LastName = usuarioDTO.LastName,
                PhoneNumber = usuarioDTO.PhoneNumber,
                Email = usuarioDTO.Email,
                Password = usuarioDTO.Password,
                UserBirthdate = usuarioDTO.UserBirthdate,
                CardUser = usuarioDTO.CardUser,
            };
        }
        public static async Task<IEnumerable<UsuarioDTO>> convertirListaDeUsariosADTO(IEnumerable<Usuario> usuarios)
        {
            IEnumerable<UsuarioDTO> usuarioDTOs = usuarios.Select(u => new UsuarioDTO()
            {
                Name = u.Name,
                LastName = u.LastName,
                PhoneNumber = u.PhoneNumber,
                Email = u.Email,
                UserBirthdate = u.UserBirthdate,
                Password = u.Password,
                CardUser = u.CardUser,

            });
            return usuarioDTOs;
        }
        public static async Task<IEnumerable<Usuario>> convertirListaDeDTOAUsuarios(IEnumerable<UsuarioDTO> usuariosDTO)
        {
            IEnumerable<Usuario> usuarios = usuariosDTO.Select(u => new Usuario()
            {
                Name = u.Name,
                LastName = u.LastName,
                PhoneNumber = u.PhoneNumber,
                Email = u.Email,
                UserBirthdate = u.UserBirthdate,
                Password = u.Password,
                CardUser = u.CardUser,
            });
            return usuarios;
        }
    }
}
