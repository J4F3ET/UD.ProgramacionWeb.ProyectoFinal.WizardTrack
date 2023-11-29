function dateFormat(date) {
	let day = date.getDate().toString().padStart(2, "0");
	let month = (date.getMonth() + 1).toString().padStart(2, "0");
	let year = date.getFullYear();
	return `${year}-${month}-${day}`;
}
function createInputDate(labelFor, inputValue) {
	const divCol = document.createElement("div");
	divCol.classList.add("col");
	const label = document.createElement("label");
	const input = document.createElement("input");
	input.disabled = true;
	label.for = labelFor;
	label.classList.add("form-label");
	switch (labelFor) {
		case "formInputStartDate":
			label.innerHTML = "Fecha de inicio";
			break;
		case "formInputEndDate":
			input.disabled = false;
			label.innerHTML = "Fecha de finalización";
			break;
		default:
			label.innerHTML = "Fecha";
			break;
	}
	input.type = "date";
	input.id = labelFor;
	input.classList.add("form-control");
	input.value =
		inputValue != ""
			? dateFormat(new Date(inputValue))
			: dateFormat(new Date());
	input.setAttribute("data-date", input.value);
	divCol.appendChild(label);
	divCol.appendChild(input);
	return divCol;
}
function releaseInputDate(data, type) {
	const divRow = document.createElement("div");
	divRow.classList.add("mb-3");
	divRow.classList.add("row");

	if (type == "debt" || type == "saveCount") {
		const divCol1 = createInputDate(
			"formInputStartDate",
			"email" in data ? "" : data.starDate
		);
		const divCol2 = createInputDate(
			"formInputEndDate",
			"email" in data ? "" : data.endDate
		);
		divRow.appendChild(divCol1);
		divRow.appendChild(divCol2);
	} else if (type == "income") {
		const divCol = createInputDate(
			"formInputIncomeDate",
			"email" in data ? "" : data.incomeDate
		);
		divRow.appendChild(divCol);
	} else {
		const divCol = createInputDate(
			"formInputSpentDate",
			"email" in data ? "" : data.spentDate
		);
		divRow.appendChild(divCol);
	}

	return divRow;
}
function createInput(
	labelFor,
	labelValue,
	inputValue,
	inputType,
	inputDisabled = false
) {
	const div = document.createElement("div");
	div.classList.add(inputDisabled ? "d-none" : "mb-3");
	const label = document.createElement("label");
	label.for = labelFor;
	label.classList.add("form-label");
	label.innerHTML = labelValue;
	const input = document.createElement("input");
	input.type = inputType;
	input.id = labelFor;
	input.classList.add("form-control");
	input.value = inputValue;
	input.hidden = inputDisabled;
	div.appendChild(label);
	div.appendChild(input);
	return div;
}
function generatorForm(data, type) {
	var controller = "SaveCountRest";
	if (data == null) {
		data = getData(getCookieValue("UserData"));
	}
	document.getElementById("modal-title").innerHTML =
		"email" in data ? "Crear" : "Modificar";
	const modalBody = document.getElementById("modalBody");
	modalBody.innerHTML = "";
	const form = document.createElement("form");
	form.classList.add("container");
	form.id = "form";
	const inputType = createInput("formInputType", "", type, "text", true);
	const inputIdUser = createInput(
		"formInputIdUser",
		"",
		"email" in data ? data.id : data.idUser,
		"number",
		true
	);
	const inputId =
		"email" in data
			? null
			: createInput("formInputId", "", data.id, "number", true);
	const divName = createInput(
		"formInputName",
		"Nombre",
		"email" in data ? "" : data.name,
		"text"
	);
	const divDescription = createInput(
		"formInputDescription",
		"Descripción",
		"email" in data ? "" : data.description,
		"text"
	);
	const divAmount = createInput(
		"formInputAmount",
		"Monto",
		data.amount,
		"number"
	);
	form.appendChild(inputType);
	"email" in data ? null : form.appendChild(inputId);
	form.appendChild(inputIdUser);
	form.appendChild(divName);
	form.appendChild(divDescription);
	form.appendChild(divAmount);
	switch (type) {
		case "debt":
			controller = `DebtRest`;
			const divInterest = createInput(
				"formInputInterest",
				"Interés",
				"email" in data ? "" : data.interest,
				"number"
			);
			const divInstallments = createInput(
				"formInputInstallments",
				"Cuotas",
				"email" in data ? "" : data.installments,
				"number"
			);
			form.appendChild(divInterest);
			form.appendChild(divInstallments);
			break;
		case "income":
			controller = `IncomeRest`;
			const divFrequency = createInput(
				"formInputFrequency",
				"Frecuencia",
				"email" in data ? "" : data.frecuency,
				"text"
			);
			form.appendChild(divFrequency);
			break;
		case "spent":
			controller = `SpentRest`;
			const divCount = createInput(
				"formInputCount",
				"Cantidad",
				"email" in data ? "" : data.count,
				"text"
			);
			form.appendChild(divCount);
			break;
	}
	form.appendChild(releaseInputDate(data, type));
	const callBackFetch = (data) => {
		Swal.fire({
			position: "top-end",
			icon: "success",
			title: "Guardado",
			showConfirmButton: false,
			timer: 1500,
		}).then(() => {
			window.location.reload();
		});
	};
	var method = "email" in data ? "POST" : "PUT";
	document.getElementById("btnEnviarModal").setAttribute("data-type", type);
	document
		.getElementById("btnEnviarModal")
		.addEventListener("click", () =>
			fetchAction(
				callBackFetch,
				method,
				controller,
				generatorDataFetch(form, type)
			)
		);
	modalBody.appendChild(form);
}
function generatorDataFetch(form, type) {
	var titleModal = document.getElementById("modal-title").innerHTML;
	const data = {
		IdUser: parseInt(form.querySelector("#formInputIdUser").value),
		Name: form.querySelector("#formInputName").value,
		Description: form.querySelector("#formInputDescription").value,
		Amount: parseInt(form.querySelector("#formInputAmount").value),
	};
	titleModal == "Modificar"
		? (data.Id = parseInt(form.querySelector("#formInputId").value))
		: null;
	switch (type) {
		case "debt":
			data.Interest = parseFloat(
				form.querySelector("#formInputInterest").value
			);
			data.Installments = parseInt(
				form.querySelector("#formInputInstallments").value
			);
			data.StarDate = form
				.querySelector("#formInputStartDate")
				.getAttribute("data-date")
				.valueOf();
			data.EndDate = dateFormat(
				new Date(form.querySelector("#formInputEndDate").value)
			);
			break;
		case "income":
			data.Frecuency = form.querySelector("#formInputFrequency").value;
			data.IncomeDate = form
				.querySelector("#formInputIncomeDate")
				.getAttribute("data-date")
				.valueOf();
			break;
		case "spent":
			data.Count = form.querySelector("#formInputCount").value;
			data.SpentDate = form
				.querySelector("#formInputSpentDate")
				.getAttribute("data-date")
				.valueOf();
			break;
		case "saveCount":
			data.StarDate = form
				.querySelector("#formInputStartDate")
				.getAttribute("data-date")
				.valueOf();
			data.EndDate = form
				.querySelector("#formInputEndDate")
				.getAttribute("data-date")
				.valueOf();
			break;
	}
	return JSON.stringify(data);
}
function fetchAction(callBack, method, controller, data) {
	const url = `http://localhost:7178/api/${controller}`;
	const headers = {
		"Content-Type": "application/json",
	};
	const config =
		data == null
			? {method, headers}
			: {
					method,
					headers,
					body: data,
			  };
	fetch(url, config)
		.then((response) => {
			if (response.ok) {
				return response.json();
			} else {
				throw new Error("Error en la llamada Ajax");
			}
		})
		.then((data) => {
			callBack(data);
		})
		.catch((error) => console.log(error));
}
function deleteItem(data, type) {
	console.log(data);
	var controller = `/	${data.id}/${data.idUser}`;
	switch (type) {
		case "debt":
			controller = `DebtRest` + controller;
			break;
		case "income":
			controller = `IncomeRest` + controller;
			break;
		case "spent":
			controller = `SpentRest` + controller;
			break;
		case "saveCount":
			controller = `SaveCountRest` + controller;
			break;
	}
	const action = (data) => {
		Swal.fire({
			position: "top-end",
			icon: "success",
			title: "Eliminado",
			showConfirmButton: false,
			timer: 1500,
		}).then(() => {
			window.location.reload();
		});
	};
	fetchAction(action, "DELETE", controller, null);
}
const dropdownCreateElement = document.getElementById("dropdownCreateElement");
if (dropdownCreateElement) {
	dropdownCreateElement
		.querySelectorAll(".btnCreateElement")
		.forEach((element) => {
			element.addEventListener("click", () => {
				generatorForm(null, element.getAttribute("data-type"));
			});
		});
} else {
	console.error("Element with ID 'dropdownCreateElement' does not exist");
}
