using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticaExamen.API.DTOs;
using PracticaExamen.API.Utilitarios;
using PracticaExamen.BW.Interfaces.BW;

namespace PracticaExamen.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoCambioController : ControllerBase
    {
        private readonly IGestionarTipoCambioBW gestionarTipoCambioBW;
        public TipoCambioController(IGestionarTipoCambioBW gestionarTipoCambioBW)
        {
            this.gestionarTipoCambioBW = gestionarTipoCambioBW;
        }
        [HttpGet]
        public Task<string> ObtenerTipoCambio(DateTime fechaInicio, DateTime fechaFinal)
        {
            return gestionarTipoCambioBW.obtengaTipoCambio(fechaInicio, fechaFinal);
        }
        [HttpGet]
        [Route("TraerTipoCambio")]
        public async Task<TipoCambioDTO> TraerTipoCambio() {
            return await TipoCambioDTOMapper.ConvertirTipoCambioADTO(await gestionarTipoCambioBW.obtengaTipoCambio());
        }
    }
}
