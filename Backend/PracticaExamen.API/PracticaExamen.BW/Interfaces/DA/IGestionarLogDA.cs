using PracticaExamen.BC.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaExamen.BW.Interfaces.DA
{
    public interface IGestionarLogDA
    {
        Task<bool> registreLog(Log log);
    }
}
