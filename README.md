# Codificación

### Librerias por utilizar
- Tools:  Para administrar las migraciones y estructurar las entidades en nuestra base de datos:
- Pomelo MySQL:  Para realizar la conexión y comunicación con la base de datos MySQL.
- JwtBearer: Para generar la autenticación y autorización de usuarios generando un Token JWT como pase.

Para utilizarlos hay que instalar las siguientes librerias:
- Instalar en NuGet Microsoft.EntityFrameworkCore.Tools
- Instalar en NuGet Pomelo.EntityFrameworkCore.MySql
- Instalar en NuGet Microsoft.AspNetCore.Authentication.JwtBearer en el proyecto

### Generar archivo secrets.json
+ Para guardar nuestras credenciales de manera secreta por cuestiones de seguridad, se realizan los siguientes pasos
    + Click derecho en nuestro proyecto principal y seleccionar **Administrar secretos del usuario**.
    + Se nos generará un archivo llamado secrets.json donde se colocará la siguientes lineas con base a la configuración de su base de datos.
    	+ El token se generó de manera aleatoria en MySQL con la funcion **SELECT UUID();** para esta prueba.

```
	{
		  "JWT_TOKEN": "token aleatorio con la función SELECT UUID()",
		  "CONNECT_DB": "server=localhost;user={Usuario en MySQL};password={Contraseña de MySQL};database={nombre de la base de datos}"
	}
```

### Generar la migración de las clases para convertirlas en tablas de MySQL
+ Para generar las columnas que se utilizarán para MySQL, abrimos nuestra consola de administrador de paquetes y ejecutamos los siguientes comandos:
	+ **Add-Migration 'nombre de la migración'** para generar una carpeta llamada Migrations que mantendra la estructura del modelo para nuestra base de datos
	+ **Update database** para generar la estructura de nuestras tablas en MySQL
		+ Importante revisar que tenemos nuestra base de datos creada en MySQL antes de ejecutar el anterior comando
