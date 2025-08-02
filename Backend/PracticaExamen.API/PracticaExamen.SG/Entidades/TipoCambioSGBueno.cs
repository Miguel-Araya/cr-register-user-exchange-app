using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaExamen.SG.Entidades
{
    
        public class TipoCambioSGBueno
        {
            public MonedaSGBueno Dolar { get; set; }
            public EuroSGBueno Euro { get; set; }
        }

        public class MonedaSGBueno
    {
            public TransaccionSGBueno Venta { get; set; }
            public TransaccionSGBueno Compra { get; set; }
        }

        public class TransaccionSGBueno
    {
            public string Fecha { get; set; }
            public decimal Valor { get; set; }
        }

        public class EuroSGBueno
    {
            public string Fecha { get; set; }
            public decimal Dolares { get; set; }
            public decimal Colones { get; set; }
        }
    }

