using PracticaExamen.BC.Modelos;
using PracticaExamen.BW.Interfaces.DA;
using PracticaExamen.DA.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaExamen.DA.Acciones
{
    public class GestionarLogDA:IGestionarLogDA
    {
        private readonly AdmUsuarioContext _context;
        public GestionarLogDA(AdmUsuarioContext context) { 
            _context = context;
        }

        public async Task<bool> registreLog(Log log)
        {
            Entidades.LogDA logDA = new()
            {
                typeLog = log.typeLog,
                dateLog = log.dateLog,
                tableLog = log.tableLog,
                descriptionLog = log.descriptionLog,
            };
           _context.Logs.Add(logDA);
            var resultado = _context.SaveChangesAsync();
            if (resultado.Result < 0)
            {
                return false;
            }
            return true;
        }
    }
}
