using PracticaExamen.BC.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaExamen.BW.Interfaces.BW
{
    public interface IGestionarTipoCambioBW
    {
        Task<string> obtengaTipoCambio(DateTime fechaInicio, DateTime fechaFinal);
        Task<TipoCambio> obtengaTipoCambio();
    }
}
