document.getElementById("sign_up_registrar").addEventListener("click", () => {
	const userName = document.getElementById("txtNameRegistro").value;
	const password = document.getElementById("txtPasswordRegistro").value;
	const email = document.getElementById("txtEmailRegistro").value;
	console.log(userName, password, email);
	if (userName == "" || password == "" || email == "") {
		return;
	}
	const url = "http://localhost:7178/Account/SesionRest/signup";
	const requestOption = {
		method: "POST",
		headers: {
			"Content-Type": "application/json",
		},
		body: JSON.stringify({
			name: userName,
			password: password,
			email: email,
		}),
	};
	fetch(url, requestOption).then(
		(response) => (location.href = "http://localhost:7178")
	);
});
document.getElementById("log_in_iniciar").addEventListener("click", () => {
	const url = "http://localhost:7178/Account/SesionRest/login";
	const email = document.getElementById("txtEmailLogin").value;
	const password = document.getElementById("txtPasswordLogin").value;
	console.log(email, password);
	if (email == "" || password == "") {
		return;
	}
	const requestOption = {
		method: "POST",
		headers: {
			"Content-Type": "application/json",
		},
		body: JSON.stringify({
			email: email,
			password: password,
		}),
	};

	fetch(url, requestOption).then(
		(response) => (location.href = "http://localhost:7178")
	);
});
