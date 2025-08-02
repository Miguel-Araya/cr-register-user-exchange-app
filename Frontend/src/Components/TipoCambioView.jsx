function TipoCambioView({ tipoCambio }) {
  return (
    <div className="flex justify-center">
      <div className="flex justify-center p-4 mb-4 border rounded-lg shadow-md">
        <div>
          <div>
            Tipo de cambio (Dólar - Venta): {tipoCambio.dolar.venta.valor}
          </div>
          <div>
            Tipo de cambio (Dólar - Compra): {tipoCambio.dolar.compra.valor}
          </div>
          <div>
            Tipo de cambio (Euro): {tipoCambio.euro.dolares} USD /{" "}
            {tipoCambio.euro.colones} CRC
          </div>
        </div>
      </div>
    </div>
  );
}

export default TipoCambioView;
