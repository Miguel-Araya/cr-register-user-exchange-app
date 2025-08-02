using PracticaExamen.BC.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaExamen.BW.Interfaces.SG
{
    public interface IGestionarTipoCambioSG
    {
        Task<string> obtengaTipoCambio(DateTime fechaInicio, DateTime fechaFinal);
        Task<TipoCambio> obtengaTipoCambio();
    }
}
