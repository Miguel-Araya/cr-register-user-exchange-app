# Sistema de Registro de usuarios y Consulta del Tipo de Cambio – CR

## Descripción

`cr-register-exchange-app` es una aplicación web moderna desarrollada con **React** que permite registrar usuarios mediante formularios con **validaciones**, y consultar el **tipo de cambio actual del dólar estadounidense (USD) al colón costarricense (CRC)** utilizando la API pública de Hacienda de Costa Rica.

Este proyecto incluye:

* Manejo de estados con React Hooks.
* Validación de formularios con `react-hook-form`.
* Máscaras de entrada con `react-input-mask`.
* Estilización responsiva con Tailwind CSS.
* Notificaciones personalizadas con `sonner`.
* Consumo de APIs externas con `axios`.

## Funcionalidades Principales

* Registro de usuarios con formulario completo: nombre, apellido, cédula, teléfono, correo, contraseña y fecha de nacimiento.
* Validaciones en tiempo real para:

  * Cédula: formato `##-####-####`
  * Teléfono: formato `####-####`
  * Contraseña con requisitos definidos
* Máscaras de entrada para mejorar la experiencia del usuario.
* Consulta del tipo de cambio desde la API de Hacienda.
* Notificaciones de éxito y error.
* Diseño responsivo para diferentes tamaños de pantalla.

## Tecnologías

### Frontend

* React y Vite
* Tailwind CSS
### Backend
* .NET Core
* Entity FrameWork

## Arquitectura Backend

* Clean Arquitecture (Onion)

## Instalación y Uso

### Requisitos Previos

* Node.js (versión LTS recomendada)
* npm o Yarn

### Pasos para Ejecutar

1. Clonar el repositorio:

   git clone https://github.com/Miguel-Araya/cr-register-user-exchange-app.git

   cd cr-register-exchange-app

3. Instalar las dependencias:

   npm install
   o
   yarn install


4. Configurar las variables de entorno:

   Crea un archivo `.env` en la raíz del proyecto y agrega las variables necesarias. Ejemplo:

   VITE_REACT_APP_API=http://localhost:5251/api
   
   > Si estás utilizando Vite, las variables deben iniciar con `VITE_`. Si usas Create React App, utiliza `REACT_APP_`.

5. Iniciar la aplicación en modo desarrollo:

   npm run dev
   o
   yarn dev

   La aplicación estará disponible en `http://localhost:5251` (o el puerto asignado por Vite).
   
