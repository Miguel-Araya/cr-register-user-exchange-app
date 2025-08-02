import { useForm } from "react-hook-form";
import { Toaster, toast } from "sonner";
import InputRegister from "../Components/InputRegister";
import axios from "axios";
import Button from "../Components/Button";
import { apiRoutes } from "../Config/apiRoutes";
import { useState, useEffect } from "react";

function PageRegister() {
  const {
    register,
    handleSubmit,
    reset,
    watch,
    formState: { errors },
  } = useForm({

      defaultValues: {
      name: "",
      lastname: "",
      cardUser: "",
      phoneNumber: "",
      email: "",
      password: "",
      userBirthdate: "",
    },

  });

  const formatMaskPhone = "9999-9999";
  const formatMaskCardUser = "99-9999-9999";

  const [passwordRequirements, setPasswordRequirements] = useState({
    length: { description: "Al menos 8 caracteres", value: false },
    uppercase: { description: "Una letra mayúscula", value: false },
    lowercase: { description: "Una letra minúscula", value: false },
    number: { description: "Un número", value: false },
    specialChar: { description: "Un carácter especial (!@#$%^*)", value: false },
  });

  const passwordValue = watch("password");

  useEffect(() => {
    if (passwordValue !== undefined) {
      const currentPassword = passwordValue || ""; // Aseguramos que sea una cadena vacía si es null/undefined

      const hasUppercase = /[A-Z]/;
      const hasLowercase = /[a-z]/;
      const hasNumber = /\d/;
      const hasSpecialChar = /[!@#$%^*]/; 

      setPasswordRequirements({
        length: { ...passwordRequirements.length, value: currentPassword.length >= 8 },
        uppercase: { ...passwordRequirements.uppercase, value: hasUppercase.test(currentPassword) },
        lowercase: { ...passwordRequirements.lowercase, value: hasLowercase.test(currentPassword) },
        number: { ...passwordRequirements.number, value: hasNumber.test(currentPassword) },
        specialChar: { ...passwordRequirements.specialChar, value: hasSpecialChar.test(currentPassword) },
      });
    } else {
      cleanRequirements();
    }
  }, [passwordValue]);

  const cleanRequirements = () => {
    setPasswordRequirements(prevState => ({
      length: { ...prevState.length, value: false },
      uppercase: { ...prevState.uppercase, value: false },
      lowercase: { ...prevState.lowercase, value: false },
      number: { ...prevState.number, value: false },
      specialChar: { ...prevState.specialChar, value: false },
    }));
  };

  const onSubmit = handleSubmit(async (data) => {
    try {

      const response = await axios.post(
        apiRoutes.registerUser,
        data
      );
      toast.success("Registro exitoso");
      reset();
      cleanRequirements();
    } catch (error) {
      toast.error("Error al registrar el usuario");
    }
  });

  return (
    <div className="flex justify-center min-h-screen">
      <form
        onSubmit={onSubmit}
        className="max-w-md w-full p-4 bg-white rounded shadow-md"
      >
        <h2 className="text-2xl font-bold mb-4">Registro</h2>

        <InputRegister
          type="text"
          id="name"
          label="Nombre"
          register={register("name", {
            required: { value: true, message: "Nombre es requerido" },
            minLength: {
              value: 2,
              message: "Nombre debe tener al menos 2 caracteres",
            },
          })}
          error={errors.name}
        />

        <InputRegister
          type="text"
          id="lastname"
          label="Apellido"
          register={register("lastname", {
            required: { value: true, message: "El apellido es requerido" },
            minLength: {
              value: 2,
              message: "El Apellido debe tener al menos 2 caracteres",
            },
          })}
          error={errors.lastname}
        />

        <InputRegister
          type="text"
          id="cardUser"
          label="Cédula"
          mask={formatMaskCardUser}
          maskChar="_"
          register={register("cardUser", {
            required: { value: true, message: "La cédula es requerida" },
            minLength: {
              value: formatMaskCardUser.length,
              message: "La cédula debe tener 10 dígitos.",
            },
            maxLength: {
              value: formatMaskCardUser.length,
              message: "La cédula debe tener 10 dígitos.",
            },
            pattern: {
              value: /^\d{2}-\d{4}-\d{4}$/, 
              message: "La cédula no es válida (formato ##-####-####).",
            },
            validate: (value) => {
              return value.replace(/-/g, '').length === 10 || "Por favor, complete todos los dígitos de la cédula.";
            }
          })}
          error={errors.cardUser}
        />

        <InputRegister
          type="text"
          id="phoneNumber"
          label="Teléfono"
          mask={formatMaskPhone}
          maskChar="_"
          register={register("phoneNumber", {
            required: { value: true, message: "El teléfono es requerido" },
            minLength: {
              value: formatMaskPhone.length,
              message: "El teléfono debe tener 8 dígitos.",
            },
            maxLength: {
              value: formatMaskPhone.length,
              message: "El teléfono debe tener 8 dígitos.",
            },
            pattern: {
              value: /^\d{4}-\d{4}$/, 
              message: "El teléfono no es válido (formato ####-####).",
            },
            validate: (value) => {
              return value.replace(/-/g, '').length === 8 || "Por favor, complete todos los dígitos del teléfono.";
            }
          })}
          error={errors.phoneNumber}
        />

        <InputRegister
          type="email"
          id="email"
          label="Correo"
          register={register("email", {
            required: { value: true, message: "El correo es necesario" },
            minLength: {
              value: 2,
              message: "El correo debe tener al menos 2 caracteres",
            },
            maxLength: {
              value: 100,
              message: "Excedió el número permitido de caracteres (100)",
            },
            pattern: {
              value: /^[a-z0-9]+@[a-z0-9]+\.[a-z]{2,}$/i,
              message: "El correo no es válido",
            },
          })}
          error={errors.email}
        />

        <InputRegister
          type="password"
          id="password"
          label="Contraseña"
          register={register("password", {
            required: { value: true, message: "La contraseña es necesaria" },
            minLength: {
              value: 8,
              message: "La contraseña debe tener al menos 8 caracteres",
            },
            pattern: {
              value: /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^*]).{8,}$/,
              message: "La contraseña no es valida",
            },
          })}
          error={errors.password}
          passwordRequirements={passwordRequirements}
        />

        <InputRegister
          type="date"
          id="userBirthdate"
          label="Fecha de nacimiento"
          register={register("userBirthdate", {
            required: { value: true, message: "La fecha de nacimiento es necesaria" },
            validate: (value) => {
              const date = new Date(value);
              const now = new Date();
              const diff = now.getFullYear() - date.getFullYear();
              return diff >= 18 || "Debe ser mayor de edad (18)";
            },
          })}
          error={errors.userBirthdate}
        />

        <Button text="Registrar" />
      </form>
      <Toaster
        theme="dark"
        position="top-right"
        duration={2000}
        visibleToasts={2}
      />
    </div>
  );
}

export default PageRegister;