using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaExamen.SG.DTO
{
    public class FormatoFecha
    {
        public static string FormatoFechaEstructurada(DateTime fechaInicio)
        {
            return fechaInicio.ToString("dd/MM/yyyy");
        }
    }
}
