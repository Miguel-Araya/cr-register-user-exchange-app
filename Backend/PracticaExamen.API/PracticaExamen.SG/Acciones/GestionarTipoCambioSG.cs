using PracticaExamen.BC.Constantes;
using PracticaExamen.BC.Modelos;
using PracticaExamen.BW.Interfaces.SG;
using PracticaExamen.SG.DTO;
using PracticaExamen.SG.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace PracticaExamen.SG.Acciones
{
    public class GestionarTipoCambioSG: IGestionarTipoCambioSG
    {
        private readonly HttpClient httpClient;
        public GestionarTipoCambioSG(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        //este contenido fue recuperado de la pagina de hacienda, link: return "https://gee.bccr.fi.cr//Indicadores/Suscripciones/WS/wsindicadoreseconomicos.asmx/ObtenerIndicadoresEconomicosXML?Indicador=317&FechaInicio={fechaInicio}&FechaFinal={fechaFinal}&Nombre=edwin&SubNiveles=N&CorreoElectronico=edwinclash232@gmail.com&Token=1POM4IMO24";
        //las credenciales de acceso son producto del proceso de suscripcion a la pagina del bccr, la cual cuenta con un servicio de tipo cambio, el cual se puede acceder mediante un token de acceso, el cual se obtiene al suscribirse a la pagina. En este caso nosotros realizamos el proceso y esas son las credenciales resultantes, por favor no difundir las credenciales de acceso.
        //basado en el repertorio publico de ruiznorlan, el cual el link es le siguiente: https://github.com/ruiznorlan/public-apis-cr?tab=readme-ov-file#autobus
        public async Task<string> obtengaTipoCambio(DateTime fechaInicio, DateTime fechaFinal)
        {
            HttpResponseMessage respuesta = await httpClient.GetAsync(URLTipoCambio.TipoCambio(FormatoFecha.FormatoFechaEstructurada(fechaInicio), FormatoFecha.FormatoFechaEstructurada(fechaFinal)));
            if (!respuesta.IsSuccessStatusCode)
                throw new HttpRequestException($"Error al obtener el mensaje");

            string xmlContent = await respuesta.Content.ReadAsStringAsync();

            // Cargar el XML en un XDocument y extraer el contenido relevante
            XDocument doc = XDocument.Parse(xmlContent);
            var innerXml = doc.Root.Value;

            XmlSerializer serializer = new XmlSerializer(typeof(DatosDeIndicadorEconomico));

            using (StringReader reader = new StringReader(innerXml))
            {
                DatosDeIndicadorEconomico datos = (DatosDeIndicadorEconomico)serializer.Deserialize(reader);
                return datos.TipoCambio.NUM_VALOR+"";
            }
        }
        
        //este contenido fue recuperado de la pagina de hacienda, link: return "https://api.hacienda.go.cr/indicadores/tc";
        //basado en el repertorio publico de ruiznorlan, el cual el link es le siguiente: https://github.com/ruiznorlan/public-apis-cr?tab=readme-ov-file#autobus
        public async Task<TipoCambio> obtengaTipoCambio()
        {
           HttpResponseMessage respuesta = await httpClient.GetAsync(URLTipoCambio.haciendaTipoCambio());
            if (!respuesta.IsSuccessStatusCode)
                throw new HttpRequestException($"Error al obtener el mensaje");
           

            TipoCambioSGBueno tipoCambio = await respuesta.Content.ReadFromJsonAsync<TipoCambioSGBueno>();

            return TIpoCambioMapper.MapperTipoCambio(tipoCambio);
          
        }
    }
}
