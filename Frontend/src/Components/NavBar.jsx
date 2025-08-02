import { useState } from "react"
import { Link, useLocation} from "wouter";
import userImage from '../assets/usuario.png';
import { appRoutes, ROUTES_NAMES } from "../Config/routes.js"

function NavBar() {
    const [menuOpen, setMenuOpen] = useState(false);

    const toggleMenu = () => {
        setMenuOpen(!menuOpen);
    };

    const [currentPath] = useLocation();
    
    const isPathActive = (appRouteItem) => (

        currentPath == appRouteItem.path || (appRouteItem.name === ROUTES_NAMES.HOME && currentPath == ROUTES_NAMES.ROOT)

    )

  return (
    <nav className="flex flex-col justify-center bg-gray-800 text-white py-4">
        <div  className="flex items-center justify-between w-full max-w-7xl px-4">

        <div className="flex items-center">
       
                <img src={userImage} alt="imagen_usuario" />
                <span className="font-semibold text-xl">Usuarios</span>
                </div>

                <div className="mt-4 hidden lg:flex">
                {appRoutes.map(item=>{
                    
                    const isActive = isPathActive(item);
                    
                    return(
                        <Link key={item.name} href={`${item.path}`} className={`block px-4 py-2 text-white hover:bg-gray-500 ${isActive ? "bg-gray-600" : ""}`}>
                            {item.name}
                        </Link>
                    )

                })} 
                             
                </div>

                <button className="block lg:hidden" onClick={toggleMenu}>
                    {menuOpen ? (
                        <svg className="w-6 h-6" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                            <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M6 18L18 6M6 6l12 12" />
                        </svg>
                    ) : (
                        <svg className="w-6 h-6" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                            <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M4 6h16M4 12h16m-7 6h7" />
                        </svg>
                    )}
                </button>
                
        </div>
                
        {menuOpen && (
                <div className="mt-4">
                   
                    {appRoutes.map(item=>{

                        const isActive = isPathActive(item);

                        return(
                        <Link key={`${item.name}`} href={item.path} className={`block px-4 py-2 text-white hover:bg-gray-500 ${isActive ? "bg-gray-600" : ""}`}>
                            {item.name}
                        </Link>
                        )

                    })}
                   
                </div>
            )}

    </nav>
  )
}

export default NavBar