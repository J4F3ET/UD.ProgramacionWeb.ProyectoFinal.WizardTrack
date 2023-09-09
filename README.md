# Documentación

Como interactua MVC con .Net core

# Indice
- [Glosario de Rutas de REST API](#glosario-de-rutas-de-rest-api)
- [Controlador](#controlador)
  - [Crear un controller como API REST](#crear-un-controller-como-api-rest)
  - [Crear un controller para las vistas](#crear-un-controller-para-las-vistas)
- [Modelo](#modelo)
- [Vista](#vista)
- [Entity Framework](#entity-framework)

## Vista

En las vistas se usa un motor de plantillas llamado Razor, este motor de plantillas permite usar código C# en las vistas con el indice `.cshtml`.

```php
@model Model.User
@{
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";
}
<h1>Index</h1>
<p>Id: @Model.Id</p>
<p>Name: @Model.Name</p>
```

De esta manera podemos usar el modelo que le pasamos al controlador en la vista.

## Entity Framework

Entity Framework es un ORM que permite mapear las tablas de una base de datos a clases de C#.

Se debe instalar el paquete `Microsoft.EntityFrameworkCore.SqlServer` y `Microsoft.EntityFrameworkCore.Tools` para poder usar Entity
Framework.

- Microsoft.EntityFrameworkCore.SqlServer: Este paquete permite usar Entity Framework con SQL Server.
- Microsoft.EntityFrameworkCore.Tools: Este paquete permite usar las herramientas de Entity Framework y mappear la base de datos a clases de C#.
  En la consola de NuGet se debe ejecutar el siguiente comando para poder usar las herramientas de Entity Framework.

```bash
    Scaffold-DbContext "Server=DESKTOP-BEMQCO7\SQLEXPRESS;Database=wizardtrack;User=sa;Password=123456;TrustServerCertificate=true" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models/Database/Conn
```

- Scaffold-DbContext: Este comando permite mapear la base de datos a clases de C#.
- "Server=localhost;Database=NOMBRE_DE_LA_BASE_DE_DATOS;Trusted_Connection=True;": Esta es la cadena de conexión a la base de datos.
- Microsoft.EntityFrameworkCore.SqlServer: Este es el proveedor de la base de datos, en este caso es SQL Server.
- -OutputDir: Este es el directorio en donde se crearan los modelos de la base de datos.
  Al ejecutar este comando se crearan los modelos de la base de datos en la carpeta `Models/DataBase`. Esto quiere decir que se crearan n cantidad de clases de C# que representan las tablas de la base de datos.

Nota: No use las clases de que genera el Scaffold-DbContext, cree sus propias clases y use las clases que genera el Scaffold-DbContext como referencia. Ya que esto evite sobre cargar el servidor con datos que solo se necesitan en la base de datos o que poco se usan.
![Alt text](image.png)



