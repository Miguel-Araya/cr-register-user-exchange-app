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
    public class GestionarLogBW:IGestionarLogBW
    {
        private readonly IGestionarLogDA gestionarLogDA; 
        public GestionarLogBW(IGestionarLogDA gestionarLogDA)
        {
            this.gestionarLogDA = gestionarLogDA;
        }

        public async Task<bool> registreLog(Log log)
        {
            (bool esValido, string mensaje) validacionReglaLog= await ReglasLog.LogValido(log);
            if (!validacionReglaLog.esValido){
                return false;
            }
            return await gestionarLogDA.registreLog(log);

        }
    }
}
