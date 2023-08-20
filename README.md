# Documentación

Como interactua MVC con .Net core
# Indice
- [Controlador](#controlador)
    - [Crear un controller como API REST](#crear-un-controller-como-api-rest)
    - [Crear un controller como Aplicación web](#crear-un-controller-como-aplicación-web)
- [Modelo](#modelo)
- [Vista](#vista)
- [Entity Framework](#entity-framework)

## Controlador

Exites dos tipos de controllers en .Net core, los controllers MVC y los controllers API.

- Controllers MVC: Los controllers MVC son los que se usan para crear una aplicación web, mientras que los controllers API son los que se usan para crear una API.
- Controllers API: Los controllers API son los que se usan para crear una API, estos controllers no tienen vistas, solo retornan datos.

En este caso se usará un controller MVC.

### Crear un controller como API REST
Para crear un enrutador como API REST se debe crear un controller con el nombre `UserController` y heredar de `ControllerBase` en vez de `Controller`.

```csharp
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Hola mundo");
    }
}
```
La ruta que se esta creando es `api/User` y el método que se esta creando es `Get` y este método retorna un `Ok` con el mensaje `Hola mundo`.
### Crear un controller como Aplicación web

Si creamos un controller y le ponemos `UserController` y la idea es que "por cada controlador exista un vista"

```csharp
public class UserController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
```

Si se le da click derecho a `Index` y se le da a `Add View`(de preferencia `Vista de Razor`) se creará una vista con el nombre `Index` en la carpeta `Views/User`(creara automaticamente la carpeta `User` si no existe).
## Modelo
Los modelos son la representación de los datos que se van a usar en la aplicación, estos modelos se crean en la carpeta `Models` y se pueden usar en los controllers y en las vistas.
```csharp
public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
}
```
**En el controlador**
```csharp
public class UserController : Controller
{
    public IActionResult Index()
    {
        User user = new User();
        user.Id = 1;
        user.Name = "Juan";
        return View(user);
    }
}
```
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
    Scaffold-DbContext "Server=localhost;Database=NOMBRE_DE_LA_BASE_DE_DATOS;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models/DataBase
```
- Scaffold-DbContext: Este comando permite mapear la base de datos a clases de C#.
- "Server=localhost;Database=NOMBRE_DE_LA_BASE_DE_DATOS;Trusted_Connection=True;": Esta es la cadena de conexión a la base de datos.
- Microsoft.EntityFrameworkCore.SqlServer: Este es el proveedor de la base de datos, en este caso es SQL Server.
- -OutputDir: Este es el directorio en donde se crearan los modelos de la base de datos.
Al ejecutar este comando se crearan los modelos de la base de datos en la carpeta `Models/DataBase`. Esto quiere decir que se crearan n cantidad de clases de C# que representan las tablas de la base de datos.

Nota: No use las clases de que genera el Scaffold-DbContext, cree sus propias clases y use las clases que genera el Scaffold-DbContext como referencia. Ya que esto evite sobre cargar el servidor con datos que solo se necesitan en la base de datos o que poco se usan.