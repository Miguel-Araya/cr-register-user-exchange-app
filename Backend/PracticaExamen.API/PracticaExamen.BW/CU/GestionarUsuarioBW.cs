using PracticaExamen.BC.Modelos;
using PracticaExamen.BC.ReglasDeNegocio;
using PracticaExamen.BW.Interfaces.BW;
using PracticaExamen.BW.Interfaces.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaExamen.BW.CU
{
    public class GestionarUsuarioBW : IGestionarUsuarioBW
    {
        private readonly IGestionarUsuarioDA DA;
        public GestionarUsuarioBW(IGestionarUsuarioDA gestionarUsuarioDA) {
            this.DA = gestionarUsuarioDA;
        }
        public async Task<bool> actualiceUsuario(Usuario usuario)
        {
            (bool esValido, string mensaje) validacionReglaUsuario = await ReglasUsuario.UsuarioValido(usuario);
            (bool esValido, string mensaje) validacionReglaCedula = await ReglasUsuario.CedulaValida(usuario.CardUser);
            if (!validacionReglaCedula.esValido&&!validacionReglaUsuario.esValido) { 
                return false;
            }
            return await DA.actualiceUsuario(usuario);
        }

        public async Task<bool> elimineUsuario(string cedula)
        {
          
            (bool esValido, string mensaje) validacionReglaCedula = await ReglasUsuario.CedulaValida(cedula);
            if (!validacionReglaCedula.esValido)
            {
                return false;
            }
            return await DA.elimineUsuario(cedula);
        }

        public async Task<Usuario> obtengaDatosUsuario(string cardUsuario, string password)
        {
           
            (bool esValido, string mensaje) validacionReglaCedula = await ReglasUsuario.CedulaValida(cardUsuario);
            if (!validacionReglaCedula.esValido)
            {
                return null;
            }
           
            return await DA.obtengaDatosUsuario(cardUsuario, password);
        }

        public async Task<IEnumerable<Usuario>> obtengaUsuarios()
        {
           return await DA.obtengaUsuarios();
        }

        public async Task<bool> registreUsuario(Usuario usuario)
        {
            
            (bool esValido, string mensaje) validacionReglaDeTarea = await ReglasUsuario.UsuarioValido(usuario);
            if (!validacionReglaDeTarea.esValido)
            {
                return false; 
            }
            
            return await DA.registreUsuario(usuario);
        }

    }
}
