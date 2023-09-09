# Seguridad
La seguridad es un tema muy importante en cualquier sistema, por lo que se debe tener en cuenta que tipo de seguridad se va a implementar en el sistema.
## Seguridad en el sistema
Para la seguridad en el sistema se usará un sistema de autenticación y autorización sin roles, es decir, que no se usará roles para la autorización de los usuarios. Si no cookies con tokens. Esto se establece en el archivo `Program.cs` en la función `ConfigureServices` con el siguiente código:
```csharp
//Ejemplo del codigo
services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
        options.LogoutPath = "/Account/Logout";
        options.AccessDeniedPath = "/Account/AccessDenied";
    });
```
### Autenticación de sesiones
La autenticación se hará con un sistema de tokens, en el cual se creará un token para cada usuario que se registre en el sistema, y este token se guardará en una cookie en el navegador del usuario.
- JWT : JSON Web Token, es la librería que se usa para verificar los tokens.
- Cookie : Es un archivo que se guarda en el navegador del usuario.
### Autorización de contraseña
La autorización de contraseña se hará con un sistema de hash, en el cual se creará un hash para cada contraseña que se registre en el sistema, y este hash se guardará en la base de datos. Junto al hash se guardará un Salt, que es un valor aleatorio que se usa para crear el hash.

- Hash : Es un algoritmo que se usa para encriptar datos.
- Salt : Es un valor aleatorio que se usa para crear el hash.