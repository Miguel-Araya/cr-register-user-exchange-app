import { useForm } from "react-hook-form";

function UsuarioView({ cardUser, name, lastName, phoneNumber, userBirthdate, email, password, update, deleteUser }) {
  const { register, handleSubmit } = useForm({
    defaultValues: {
      name: name,
      lastName: lastName,
      password: password,
      phoneNumber: phoneNumber,
      userBirthdate: userBirthdate,
      email: email,
    }
  });

  const onSubmit = (data) => {
    
    const updatedData = { ...data, cardUser };
    update(updatedData);

  };

  return (
    <div className="flex justify-center">
    <form onSubmit={handleSubmit(onSubmit)} className="p-4 mb-4 border rounded-lg shadow-md">
      <h2 className="mb-2 text-xl font-bold">{cardUser}</h2>

      <label className="font-semibold">Nombre:</label>
      <input
        className="m-1 border-2 border-black p-1 rounded focus:outline-none focus:ring-2 focus:ring-blue-400 hover:border-blue-500"
        type="text"
        {...register("name")}
      />
      <br />

      <label className="font-semibold">Apellido:</label>
      <input
        className="m-1 border-2 border-black p-1 rounded focus:outline-none focus:ring-2 focus:ring-blue-400 hover:border-blue-500" 
        type="text"
        {...register("lastName")}
      />
      <br />

      <label className="font-semibold">Teléfono:</label>
      <input
        className="m-1 border-2 border-black p-1 rounded focus:outline-none focus:ring-2 focus:ring-blue-400 hover:border-blue-500"
        type="text"
        {...register("phoneNumber")}
      />
      <br />

      <label className="font-semibold">Fecha Nacimiento:</label>
      <input
        className="m-1 border-2 border-black p-1 rounded focus:outline-none focus:ring-2 focus:ring-blue-400 hover:border-blue-500"
        type="datetime-local"
        {...register("userBirthdate")}
      />
      <br />

      <label className="font-semibold">Correo:</label>
      <input
        className="m-1 border-2 border-black p-1 rounded focus:outline-none focus:ring-2 focus:ring-blue-400 hover:border-blue-500"
        type="email"
        {...register("email")}
      />
      <br />

      <button
        type="submit"
        className="px-4 py-2 mt-2 text-white rounded bg-blue-600 hover:bg-blue-700"
      >
        Editar
      </button>
      
      <button
        type="button" // Cambia el type a button para evitar conflictos con el submit del formulario
        className="px-4 py-2 mt-2 ml-3 text-white bg-red-600 rounded hover:bg-red-700"
        onClick={() => deleteUser(cardUser)}
      >
        Eliminar
      </button>
    </form>
    </div>
  );
}

export default UsuarioView;
