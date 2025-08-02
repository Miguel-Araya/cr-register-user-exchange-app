import { useEffect, useState } from "react";
import { useLocation } from "wouter";
import TipoCambioView from "../Components/TipoCambioView";
import { apiRoutes } from "../Config/apiRoutes";
import Loading from "../Components/Loading";

function PageTipoCambio() {
  const [tipoCambio, setTipoCambio] = useState(null);

  const [, setLocation] = useLocation();
  
  useEffect(() => {
    async function getDolar() {
      const response = await fetch(
        apiRoutes.getExchangeRate
      );
      const data = await response.json();
      setTipoCambio(data);
    }
    getDolar();
  }, [setLocation]);

  return (
    <>
      {tipoCambio ? (
        <TipoCambioView tipoCambio={tipoCambio} />
      ) : (
        <Loading/>
      )}
    </>
  );
}

export default PageTipoCambio;
