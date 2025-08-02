using PracticaExamen.BC.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaExamen.BC.ReglasDeNegocio
{
    public class ReglasLog
    {
        public static async Task<(bool, string)> LogValido(Log log)
        {
            if (log.tableLog is null)
                return (false, "EL log no es valido, la tabla es nulo");
            if (log.tableLog.Equals(String.Empty))
                return (false, "El log no es valido, la tabla esta vacio");
            if (log.typeLog is null)
                return (false, "EL log no es valido, el tipo es nulo");
            if (log.typeLog.Equals(String.Empty))
                return (false, "El log no es valido, el tipo esta vacio");
            if (log.descriptionLog is null)
                return (false, "EL log no es valido, la description es nulo");
            if (log.descriptionLog.Equals(String.Empty))
                return (false, "El log no es valido, la description esta vacio");
            if (log.dateLog == DateTime.MinValue)
                return (false, "El log no es válido, la fecha está vacía");

            return (true, string.Empty);
        }
    }
}
