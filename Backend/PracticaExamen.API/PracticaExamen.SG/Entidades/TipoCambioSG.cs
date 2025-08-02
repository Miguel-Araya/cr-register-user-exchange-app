using System;
using System.Xml.Serialization;

namespace PracticaExamen.SG.Entidades
{
    [XmlRoot("Datos_de_INGC011_CAT_INDICADORECONOMIC")]
    public class DatosDeIndicadorEconomico
    {
        [XmlElement("INGC011_CAT_INDICADORECONOMIC")]
        public TipoCambioSG TipoCambio { get; set; }
    }

    public class TipoCambioSG
    {
        [XmlElement("COD_INDICADORINTERNO")]
        public int COD_INDICADORINTERNO { get; set; }

        [XmlElement("DES_FECHA")]
        public DateTime DES_FECHA { get; set; }

        [XmlElement("NUM_VALOR")]
        public double NUM_VALOR { get; set; }
    }
}
