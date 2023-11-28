// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function getCookieValue(cookieName) {
    // Separa las cookies por punto y coma y las coloca en un array
    const cookies = document.cookie.split('; ');
    console.log(document.cookie)
    // Busca la cookie con el nombre especificado
    for (const cookie of cookies) {
        const [name, value] = cookie.split('=');
        if (name === cookieName) {
            // Decodifica el valor de la cookie y retorna
            return decodeURIComponent(value);
        }
    }

    // Retorna null si la cookie no se encuentra
    return null;
}
function getData(data) {
    if (data == null) return
    // Dividir la cadena por '-'
    const parts = data.split('-');

    // Obtener las partes y realizar los reemplazos
    const email = parts[0].replace('%40', '@');
    const name = parts[1].replace('%20', ' ');
    const id = parts[2];

    // Retornar un objeto con las propiedades requeridas
    return { email, name, id };
}
const userData = getData(getCookieValue("UserData"))
document.getElementById("txtEmailUser").innerHTML = userData.email
document.getElementById("txtNameUser").innerHTML = userData.name
document.getElementById("txtIdUser").innerHTML = userData.id


