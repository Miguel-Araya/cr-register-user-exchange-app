import { useEffect} from "react";
import { useLocation } from "wouter";
import { useState } from "react";
import UsuarioView from "../Components/UsuarioView";
import { Toaster, toast } from "sonner";
import axios from "axios";
import { apiRoutes } from "../Config/apiRoutes";
import Loading from "../Components/Loading";

function PageUsuario() {
  const [usuarios, setUsuarios] = useState(null);
  
  const [, setLocation] = useLocation();
  useEffect(() => {

    async function getUsuarios() {
      const response = await fetch(
        apiRoutes.getUser
      );
      const data = await response.json();
      setUsuarios(data);
      console.log(data);
    }
    getUsuarios();
  }, [setLocation]);
  
  const deleteUser = async (id) => {

    try {
      await axios.delete(
        `${apiRoutes.deleteUser}?cedula=${id}`
      );

      //Filtrar y dejar los usuarios que no se eliminaron
      setUsuarios(usuarios.filter(usuario => usuario.cardUser !== id));

      toast.success("Se elimino correctamente");

    } catch (error) {
      toast.error("Error al eliminar el usuario");
      console.error("Error al enviar datos:", error);
    }
  };

  const handleNotNullUsuarios = () => (

    usuarios?.length <= 0 ? <p className="flex justify-center text-xl mt-2 font-bold">No hay usuarios</p> : <Loading/>

  )

  const updateUser = async (data) => {

    console.log(data);
    try {
      await axios.put(
        apiRoutes.updateUser
        ,data
      );
      
      toast.success("Se actualizo correctamente");

    } catch (error) {
      toast.error("Error al actualizar el usuario");
      console.error("Error al enviar datos:", error);
    }
  };

  return (
    <>
      {usuarios?.length > 0 ? (
        usuarios.map((item) => (
          <UsuarioView
            key={item.cardUser}
            cardUser={item.cardUser}
            name={item.name}
            lastName={item.lastName}
            phoneNumber={item.phoneNumber}
            userBirthdate={item.userBirthdate}
            email={item.email}
            password={item.password}
            update={updateUser}
            deleteUser={deleteUser}
          />
        ))
      ) : (
        handleNotNullUsuarios()
      )}

      <Toaster
        theme="dark"
        position="top-right"
        duration={2000}
        visibleToasts={2}
      />
    </>
  );
}

export default PageUsuario;
