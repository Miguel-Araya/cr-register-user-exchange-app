import PageUsuario from "../Pages/PageUsuario.jsx"
import PageRegister from "../Pages/PageRegister.jsx"
import PageTipoCambio from "../Pages/PageTipoCambio.jsx"

const ROUTES_NAMES = {
  HOME: "Home"
  ,ROOT: "/"
}

const appRoutes = [
  { path: '/usuarios', component: PageUsuario, name: ROUTES_NAMES.HOME}
  ,{ path: '/register', component: PageRegister, name: 'Registrar'}
  ,{ path: '/tipocambio', component: PageTipoCambio, name: 'Tipo de Cambio'}
  ,
];

export {appRoutes, ROUTES_NAMES}