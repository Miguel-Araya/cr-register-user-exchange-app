import NavBar from "./Components/NavBar"
import { Route } from "wouter"
import { appRoutes, ROUTES_NAMES } from "./Config/routes.js"

function App() {
  return (
    <>

    <NavBar />

    <Route key="default" path={`${ROUTES_NAMES.ROOT}`} component={appRoutes.find(route => route.name === ROUTES_NAMES.HOME)?.component} />

    {appRoutes.map(route=>(

      <Route key={`${route.name}`} path={`${route.path}`} component={route.component} />

    ))}

    </>
  )
}

export default App;
