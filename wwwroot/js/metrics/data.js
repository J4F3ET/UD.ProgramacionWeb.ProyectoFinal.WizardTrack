function getCookieValue(cookieName) {
	// Separa las cookies por punto y coma y las coloca en un array
	const cookies = document.cookie.split("; ");
	// Busca la cookie con el nombre especificado
	for (const cookie of cookies) {
		const [name, value] = cookie.split("=");
		if (name === cookieName) {
			// Decodifica el valor de la cookie y retorna
			return decodeURIComponent(value);
		}
	}

	// Retorna null si la cookie no se encuentra
	return null;
}
function getData(data) {
	if (data == null) return;
	// Dividir la cadena por '-'
	const parts = data.split("-");
	// Obtener las partes y realizar los reemplazos
	const email = parts[0].replace("%40", 64);
	const name = parts[1].replace("%20", " ");
	const id = parts[2];

	// Retornar un objeto con las propiedades requeridas
	return {email, name, id};
}
function fetchData(callBack) {
	url = "http://localhost:7178/api/DataRest";
	const userData = getData(getCookieValue("UserData"));
	const Email = userData.email;
	const Name = userData.name;
	const Id = userData.id;
	if (userData == null) return;
	fetch(url, {
		method: "POST",
		body: JSON.stringify({
			Email,
			Name,
			Id,
		}),
		headers: {
			"Content-type": "application/json; charset=UTF-8",
		},
	})
		.then((response) => response.json())
		.then((json) => {
			callBack(json);
		});
}
