document
	.createElement("sign_up_registrar")
	.addEventListener("click", function () {
		sendSingUpRequest();
	});
function sendSingUpRequest() {
	const url = "http://localhost:7178/Account/SesionRest/Signup";
	const userName = document.getElementById("txtNameRegistro").value;
	const password = document.getElementById("txtPasswordRegistro").value;
	const email = document.getElementById("txtEmailRegistro").value;
	const userData = {
		name: userName,
		password: password,
		email: email,
	};
	const requestOption = {
		method: "POST",
		headers: {
			"Content-Type": "application/json",
		},
		body: JSON.stringify(userData),
	};

	fetch(url, requestOption)
		.then((response = response.JSON))
		.then((data) => {
			console.log("Respuesta del back:", data);
		})
		.cath((error) => {
			console.log("Error al realizar la solicutud", error);
		});
	console.log(userData);
}