using PracticaExamen.API.DTOs;
using PracticaExamen.BC.Modelos;

namespace PracticaExamen.API.Utilitarios
{
    public class TipoCambioDTOMapper
    {
        public static async Task<TipoCambioDTO> ConvertirTipoCambioADTO(TipoCambio tipoCambio)
        {
            if (tipoCambio == null)
            {
                throw new ArgumentNullException(nameof(tipoCambio), "El objeto TipoCambio no puede ser null");
            }

            return new TipoCambioDTO
            {
                Dolar = new DTOs.MonedaDTO
                {
                    Venta = new TransaccionDTO
                    {
                        Fecha = tipoCambio.Dolar.Venta.Fecha,
                        Valor = tipoCambio.Dolar.Venta.Valor
                    },
                    Compra = new TransaccionDTO
                    {
                        Fecha = tipoCambio.Dolar.Compra.Fecha,
                        Valor = tipoCambio.Dolar.Compra.Valor
                    }
                },
                Euro = new EuroDTO
                {
                    Fecha = tipoCambio.Euro.Fecha,
                    Dolares = tipoCambio.Euro.Dolares,
                    Colones = tipoCambio.Euro.Colones
                }
            };
        }

        public static async Task<TipoCambio> ConvertirDTOATipoCambio(TipoCambioDTO tipoCambioDTO)
        {
            if (tipoCambioDTO == null)
            {
                throw new ArgumentNullException(nameof(tipoCambioDTO), "El objeto TipoCambioDTO no puede ser null");
            }

            return new TipoCambio
            {
                Dolar = new Moneda
                {
                    Venta = new Transaccion
                    {
                        Fecha = tipoCambioDTO.Dolar.Venta.Fecha,
                        Valor = tipoCambioDTO.Dolar.Venta.Valor
                    },
                    Compra = new Transaccion
                    {
                        Fecha = tipoCambioDTO.Dolar.Compra.Fecha,
                        Valor = tipoCambioDTO.Dolar.Compra.Valor
                    }
                },
                Euro = new Euro
                {
                    Fecha = tipoCambioDTO.Euro.Fecha,
                    Dolares = tipoCambioDTO.Euro.Dolares,
                    Colones = tipoCambioDTO.Euro.Colones
                }
            };
        }
    }
}
