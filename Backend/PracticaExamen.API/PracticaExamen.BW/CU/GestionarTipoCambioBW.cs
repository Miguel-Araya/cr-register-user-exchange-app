using PracticaExamen.BC.Modelos;
using PracticaExamen.BW.Interfaces.BW;
using PracticaExamen.BW.Interfaces.SG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaExamen.BW.CU
{
    public class GestionarTipoCambioBW : IGestionarTipoCambioBW
    {
        private readonly IGestionarTipoCambioSG gestionarTipoCambioSG;
       
        public GestionarTipoCambioBW(IGestionarTipoCambioSG gestionarTipoCambioSG)
        {
            this.gestionarTipoCambioSG = gestionarTipoCambioSG;
        }
        public Task<string> obtengaTipoCambio(DateTime fechaInicio, DateTime date)
        {
           return gestionarTipoCambioSG.obtengaTipoCambio(fechaInicio, date);
        }
        public Task<TipoCambio> obtengaTipoCambio()
        {
            return gestionarTipoCambioSG.obtengaTipoCambio();
        }
    }
}
