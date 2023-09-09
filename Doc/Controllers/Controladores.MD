# Controladores del app

## Indice

- [Glosario de Rutas de REST API](#glosario-de-rutas-de-rest-api)
- [Controlador](#controlador)
  - [Crear un controller como API REST](#crear-un-controller-como-api-rest)
  - [Crear un controller para las vistas](#crear-un-controller-para-las-vistas)

## Glosario de Rutas de REST API

### https://localhost:7178/Account/SingUpService

1. **POST**: Crear un usuario, este método crea un usuario en la base de datos.

```json
//Objeto para la petición.
{
	"name": "root",
	"email": "root@hotmail.com",
	"password": "1234"
}
//Objeto para la respuesta, y agrega las cookies de sesion
{
    "id": 1,
    "name": "root",
    "email": "root@hotmail.com"
}
```

### https://localhost:7178/Account/LoginService

2. **POST**: Iniciar sesión. Este método inicia sesión en la aplicación.
en el header debe existtir el parametro Authorization con el valor Basic + base64(email:password).

```json
//Objeto para la petición.
{
	"email": "root",
	"password": "1234"
}
```
### https://localhost:7178/Account/LogOut

2. **GET**: Cerrar sesión. Este método cierra sesión en la aplicación.

## Controladores

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

### Crear un controller para las vistas

Para crearn un controlador de las vistas en la aplicacion debemos dirigirnos a la carpeta Controller/ViewController.

1. Creamos un controlador con la opción MVC Controller con acciones de lectura y escritura.
2. Seleccionamos el modelo que queremos usar en el controlador.
3. Creamos dentro de la carpeta Views una carpeta con el nombre del controlador.

Por cada método que se cree en el controlador se debe crear una vista con el mismo nombre del método dentro de la carpeta del controlador en la carpeta Views.

Ejemplo:

Creamos el controlador "SingUpController" con el método `Index`.
Entonces creamos una carpeta con el nombre SingUp dentro de la carpeta Views y dentro de esta carpeta creamos una vista con el nombre Index que hacer referencia al método creado.

```
Raiz
  ├── Controllers
  │   ├── ServicesControllers
  │   └── ViewsControllers
  │       └── SingUpController
  ├── Model
  │
  └── Views
      └── SingUp
          └── Index.cshtml

```

Asi deberia verce la estructura de carpetas. Y dentro de SingUpController deberia estar el método Index.

```csharp
public IActionResult Index()
{
    return View();
}
```
