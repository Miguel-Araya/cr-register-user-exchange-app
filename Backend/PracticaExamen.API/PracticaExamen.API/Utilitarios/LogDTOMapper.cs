using PracticaExamen.API.DTOs;
using PracticaExamen.BC.Modelos;

namespace PracticaExamen.API.Utilitarios
{
    public class LogDTOMapper
    {
        public static async Task<LogDTO> convertirLogADTO(Log log) {
            return new()
            {
                tableLog = log.tableLog,
                dateLog = log.dateLog,
                descriptionLog = log.descriptionLog,
                typeLog = log.typeLog,

            };
        
        }
        public static async Task<Log> convertirDTOALog(LogDTO logDTO)
        {
            return new()
            {
                tableLog = logDTO.tableLog,
                dateLog = logDTO.dateLog,
                descriptionLog = logDTO.descriptionLog,
                typeLog = logDTO.typeLog,

            };

        }
    }
}
