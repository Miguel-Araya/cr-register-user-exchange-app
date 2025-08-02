using PracticaExamen.BC.Modelos;
using PracticaExamen.SG.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaExamen.SG.DTO
{
    public class TIpoCambioMapper
    {
        public static TipoCambio MapperTipoCambio(TipoCambioSGBueno tipoCambioSGBueno)
        {
            return new TipoCambio
            {
                Dolar = new Moneda
                {
                    Venta = new Transaccion
                    {
                        Fecha = tipoCambioSGBueno.Dolar.Venta.Fecha,
                        Valor = tipoCambioSGBueno.Dolar.Venta.Valor
                    },
                    Compra = new Transaccion
                    {
                        Fecha = tipoCambioSGBueno.Dolar.Compra.Fecha,
                        Valor = tipoCambioSGBueno.Dolar.Compra.Valor
                    }
                },
                Euro = new Euro
                {
                    Fecha = tipoCambioSGBueno.Euro.Fecha,
                    Dolares = tipoCambioSGBueno.Euro.Dolares,
                    Colones = tipoCambioSGBueno.Euro.Colones
                }
            };
        }
    }
}
