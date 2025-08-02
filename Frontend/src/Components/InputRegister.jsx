import React from "react";
import InputMask from "react-input-mask";

const InputRegister = React.forwardRef(({
  type,
  id,
  label,
  register,
  error,
  passwordRequirements,
  mask,
  maskChar,
  alwaysShowMask = false,
  ...props
}, ref) => {

  const renderRequirements = (reqKey, reqDetail) => (
    <li
      key={`${reqKey}`}
      className={`flex items-center ${
        reqDetail.value ? "text-green-600" : "text-red-600"
      } mb-1`}
    >
      <span className="mr-2">{reqDetail.value ? "✓" : "✗"}</span>
      {reqDetail.description}
    </li>
  );

  const inputClassName = "w-full p-2 text-sm text-gray-900 bg-white border border-gray-400 rounded-lg shadow-md focus:outline-none focus:ring-2 focus:ring-blue-400 hover:bg-white";

  if (mask) {
    return (
      <div className="mb-2">
        <label htmlFor={id} className="block">
          {label}
        </label>
        <InputMask
          mask={mask}
          maskChar={maskChar}
          alwaysShowMask={alwaysShowMask}
          type={type}
          id={id}
          {...register} 
          className={inputClassName}
          {...props}
        />
        {error && (
          <p className="text-red-500 italic mt-1">{error.message}</p>
        )}
        {id === "password" && passwordRequirements && (
          <div className="mt-2">
            <p className="text-gray-700 text-sm font-bold mb-2">
              Tu contraseña debe cumplir:
            </p>
            <ul className="list-none p-0 m-0 bg-gray-50 italic">
              {Object.entries(passwordRequirements).map(([key, detail]) =>
                renderRequirements(key, detail)
              )}
            </ul>
          </div>
        )}
      </div>
    );
  }

  return (
    <div className="mb-2">
      <label htmlFor={id} className="block">
        {label}
      </label>
      <input
        type={type}
        id={id}
        {...register} 
        className={inputClassName}
        {...props}
      />
      {error && (
        <p className="text-red-500 italic mt-1">{error.message}</p>
      )}
      {id === "password" && passwordRequirements && (
        <div className="mt-2">
          <p className="text-gray-700 text-sm font-bold mb-2">
            Tu contraseña debe cumplir:
          </p>
          <ul className="list-none p-0 m-0 bg-gray-50 italic">
            {Object.entries(passwordRequirements).map(([key, detail]) =>
              renderRequirements(key, detail)
            )}
          </ul>
        </div>
      )}
    </div>
  );
});

export default InputRegister;