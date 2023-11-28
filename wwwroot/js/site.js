// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const userData = getData(getCookieValue("UserData"));
document.getElementById("txtEmailUser").innerHTML = userData.email;
document.getElementById("txtNameUser").innerHTML = userData.name;
document.getElementById("txtIdUser").innerHTML = userData.id;
