using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaExamen.BC.Modelos
{
    public class TipoCambio
    {
        public Moneda Dolar { get; set; }
        public Euro Euro { get; set; }
    }

    public class Moneda
    {
        public Transaccion Venta { get; set; }
        public Transaccion Compra { get; set; }
    }

    public class Transaccion
    {
        public string Fecha { get; set; }
        public decimal Valor { get; set; }
    }

    public class Euro
    {
        public string Fecha { get; set; }
        public decimal Dolares { get; set; }
        public decimal Colones { get; set; }
    }
}
