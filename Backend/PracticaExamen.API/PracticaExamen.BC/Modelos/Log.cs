using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaExamen.BC.Modelos
{
    public class Log
    {
        public long  idLog {  get; set; }
        public string typeLog { get; set; }
        public string tableLog { get; set; }
        public string descriptionLog { get; set; }
        public DateTime dateLog { get; set; }
    }
}
