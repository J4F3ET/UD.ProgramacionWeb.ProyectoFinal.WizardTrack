document.getElementById("sign_up_registrar").addEventListener("click", sendSingUpRequest());

function sendSingUpRequest() {
	const url = "http://localhost:7178/Account/SesionRest/signup";
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

	fetch(url, requestOption).then((response) => console.log("Respuesta del back:", response.json()))
	console.log(userData);
}