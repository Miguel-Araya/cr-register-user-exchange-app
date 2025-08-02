namespace PracticaExamen.API.DTOs
{
   
        public class TipoCambioDTO
        {
            public MonedaDTO Dolar { get; set; }
            public EuroDTO Euro { get; set; }
        }

        public class MonedaDTO
    {
            public TransaccionDTO Venta { get; set; }
            public TransaccionDTO Compra { get; set; }
        }

        public class TransaccionDTO
    {
            public string Fecha { get; set; }
            public decimal Valor { get; set; }
        }

        public class EuroDTO
    {
            public string Fecha { get; set; }
            public decimal Dolares { get; set; }
            public decimal Colones { get; set; }
        }
    }

