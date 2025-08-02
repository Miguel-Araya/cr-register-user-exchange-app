using PracticaExamen.BC.Modelos;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PracticaExamen.BC.ReglasDeNegocio
{
    public static class ReglasUsuario
    {
        public static async Task<(bool, string)> UsuarioValido(Usuario usuario) {
            if (usuario.Name is null) 
                return (false, "EL Usuario no es valido, el nombre es nulo");
            if (usuario.Name.Equals(String.Empty))
                return (false, "El Usuario no es valido, el nombre esta vacio");
            if (usuario.LastName is null)
                return (false, "EL Usuario no es valido, el apellido es nulo");
            if (usuario.LastName.Equals(String.Empty))
                return (false, "El Usuario no es valido, el apellido esta vacio");
            if (usuario.CardUser is null)
                return (false, "EL Usuario no es valido, la cedula es nulo");
            if (usuario.CardUser.Equals(String.Empty))
                return (false, "El Usuario no es valido, la cedula esta vacio");
            if (usuario.Email is null)
                return (false, "EL Usuario no es valido, el correo es nulo");
            if (usuario.Email.Equals(String.Empty))
                return (false, "El Usuario no es valido, el correo esta vacio");
            if (usuario.PhoneNumber is null)
                return (false, "EL Usuario no es valido, el telefono es nulo");
            if (usuario.PhoneNumber.Equals(String.Empty))
                return (false, "El Usuario no es valido, el telefono esta vacio");
            if (usuario.Password is null)
                return (false, "EL Usuario no es valido, la contraseña es nulo");
            if (usuario.PhoneNumber.Equals(String.Empty))
                return (false, "El Usuario no es valido, la contraseña esta vacio");


            return (true, string.Empty);

        }
        public static async Task<(bool, string)> CedulaValida(string card) {
            string regexPattern = @"^\d{2}-\d{4}-\d{4}$";

            if (Regex.IsMatch(card, regexPattern))
                return (true, "Formato válido.");
            else
                return (false, "Formato inválido. El formato debe ser '##-####-####'.");
        }
    }
}
