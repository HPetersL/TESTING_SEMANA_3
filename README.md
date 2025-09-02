# Proyecto: Formulario de Ficha Médica

Este proyecto fue desarrollado como parte del módulo **Taller de Testing y Calidad de Software**. Consiste en una aplicación web full-stack creada con ASP.NET Core MVC que permite la creación, actualización y consulta de fichas médicas de pacientes. El enfoque principal del proyecto fue la implementación de validaciones robustas, el aseguramiento de la calidad del software y el despliegue de la aplicación en un entorno de producción.

**URL de la aplicación en vivo:** [http://hpetersl-001-site1.etempurl.com/pruebas](http://hpetersl-001-site1.etempurl.com/pruebas)

## 🚀 Características Principales

* **Gestión de Fichas Médicas:** Creación y actualización de registros en una base de datos SQL Server.
* **Formulario Robusto:** Formulario de 10 campos con validaciones de doble capa (cliente y servidor).
* **Experiencia de Usuario Mejorada (UX):** Validación en tiempo real con JavaScript para una retroalimentación visual instantánea (bordes de color, formato automático de RUT, etc.).
* **Lógica de Negocio:** Prevención de registros duplicados (basado en RUT) con un flujo de confirmación para sobrescribir datos.
* **Funcionalidad de Búsqueda:** Implementación de un filtro de búsqueda de pacientes por apellido.

## 💻 Tecnologías Utilizadas

* **Backend:** C# con ASP.NET Core MVC (.NET 8)
* **Frontend:** HTML, CSS, JavaScript (sin frameworks)
* **Base de Datos:** Microsoft SQL Server
* **ORM:** Entity Framework Core
* **Hosting:** SmarterASP.NET (IIS)
* **Control de Versiones:** Git y GitHub

## 📝 Metodología y Fases del Proyecto

Para el desarrollo de la aplicación y la elaboración del informe de pruebas, se siguió la siguiente metodología:

1.  **Diseño y Creación de la Base de Datos:** Se utilizó SQL Server Management Studio para crear el esquema de la base de datos en un entorno local, definiendo tablas, tipos de datos y restricciones de integridad de datos (`UNIQUE`, `NOT NULL`).

2.  **Desarrollo de la Aplicación (MVC):** Se implementó la aplicación web en Visual Studio 2022 bajo el patrón arquitectónico Modelo-Vista-Controlador (MVC) con ASP.NET Core. Se desarrollaron los tres componentes principales:
    * **Modelo:** Representación de la entidad `FichaMedica` con sus propiedades y atributos de validación (Data Annotations).
    * **Vista:** Creación de la interfaz de usuario con Razor Pages, implementando el formulario y la visualización de datos.
    * **Controlador:** Desarrollo de la lógica de negocio para gestionar las peticiones del usuario, interactuar con la base de datos y aplicar las reglas de validación.

3.  **Integración con la Base de Datos:** Se configuró la conexión entre la aplicación y la base de datos local utilizando Entity Framework Core, permitiendo el almacenamiento y la consulta de información.

4.  **Pruebas Funcionales y de Interfaz (UI):** Se ejecutó un plan de pruebas de caja negra sobre la aplicación desplegada, enfocado en validar la funcionalidad de cada componente. Las pruebas se agruparon por reglas de negocio:
    * Campo con formato y lógica de negocio de RUT.
    * Campos restringidos a solo letras (nombres, apellidos, ciudad).
    * Campos con formato de Teléfono y Email.
    * Campos de selección y opcionales.
    * Funcionalidad de botones (Guardar, Limpiar, Cerrar) y el flujo de sobrescritura.
    * Funcionalidad de búsqueda por apellido.

5.  **Despliegue en Servidor Web:** La aplicación y la base de datos fueron migradas desde el entorno local a un servicio de hosting gratuito para verificar su funcionamiento en un entorno de producción accesible a través de internet.

6.  **Control de Versiones y Documentación:** El código fuente completo del proyecto se versionó y se subió a este repositorio de GitHub para su revisión.

## ⚙️ Cómo Ejecutar el Proyecto Localmente

Para clonar y ejecutar este proyecto en un entorno local, sigue estos pasos:

1.  **Clonar el repositorio:**
    ```bash
    git clone [https://github.com/tu-usuario/Proyecto-FichaMedica.git](https://github.com/tu-usuario/Proyecto-FichaMedica.git)
    ```
2.  **Crear la Base de Datos:** Abre SQL Server Management Studio y ejecuta el script de SQL que se encuentra en la raíz del repositorio o que fue generado durante el desarrollo para crear la tabla `FichasMedicas` y sus restricciones.
3.  **Configurar la Cadena de Conexión:** En el archivo `appsettings.json`, modifica la `DefaultConnection` para que apunte a tu instancia local de SQL Server.
4.  **Ejecutar la Aplicación:** Abre el archivo de solución (`.sln`) en Visual Studio 2022 y presiona F5 para compilar y ejecutar el proyecto.
