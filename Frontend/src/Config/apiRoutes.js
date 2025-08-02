const apiURL = import.meta.env.VITE_REACT_APP_API;

export const apiRoutes = {
    registerUser: `${apiURL}/Usuario/registrarUsuario`
    ,getDataUser: `${apiURL}/Usuario/traerDatosUsuario`
    ,getExchangeRate: `${apiURL}/TipoCambio/TraerTipoCambio`
    ,getUser: `${apiURL}/Usuario/traerUsuarios`
    ,deleteUser: `${apiURL}/Usuario/eliminarUsuario`
    ,updateUser: `${apiURL}/Usuario/actualizeUsuario`
}