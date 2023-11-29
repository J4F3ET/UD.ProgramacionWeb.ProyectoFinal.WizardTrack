function createInputDate(labelFor, inputValue) {
	const divCol = document.createElement("div");
	divCol.classList.add("col");
	const label = document.createElement("label");
	label.for = labelFor;
	label.classList.add("form-label");
	switch (labelFor) {
		case "formInputStartDate":
			label.innerHTML = "Fecha de inicio";
			break;
		case "formInputEndDate":
			label.innerHTML = "Fecha de finalización";
			break;
		default:
			label.innerHTML = "Fecha";
			break;
	}
	const input = document.createElement("input");
	input.type = "date";
	input.id = labelFor;
	input.classList.add("form-control");
	input.disabled = true;

	if (inputValue) {
		let date = new Date(inputValue);
		let day = date.getDate();
		let month = date.getMonth() + 1;
		let year = date.getFullYear();
		input.value = `${year}-${month.toString().padStart(2, "0")}-${day
			.toString()
			.padStart(2, "0")}`;
	}

	divCol.appendChild(label);
	divCol.appendChild(input);

	return divCol;
}
function releaseInputDate(data, type) {
	const divRow = document.createElement("div");
	divRow.classList.add("mb-3");
	divRow.classList.add("row");

	if (type == "debt" || type == "saveCount") {
		const divCol1 = createInputDate("formInputStartDate", data.starDate);
		const divCol2 = createInputDate("formInputEndDate", data.endDate);
		divRow.appendChild(divCol1);
		divRow.appendChild(divCol2);
	} else if (type == "income") {
		const divCol = createInputDate("formInputIncomeDate", data.incomeDate);
		divRow.appendChild(divCol);
	} else {
		const divCol = createInputDate("formInputIncomeDate", data.spentDate);
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
	document.getElementById("modal-title").innerHTML = "Modificar";
	const modalBody = document.getElementById("modalBody");
	modalBody.innerHTML = "";
	const form = document.createElement("form");
	form.classList.add("container");
	form.id = "form";
	const inputType = createInput("formInputType", "", type, "text", true);
	const inputId = createInput("formInputId", "", data.id, "number", true);
	const inputIdUser = createInput(
		"formInputIdUser",
		"",
		data.idUser,
		"number",
		true
	);
	const divName = createInput("formInputName", "Nombre", data.name, "text");
	const divDescription = createInput(
		"formInputDescription",
		"Descripción",
		data.description,
		"text"
	);
	const divAmount = createInput(
		"formInputAmount",
		"Monto",
		data.amount,
		"number"
	);
	form.appendChild(inputType);
	form.appendChild(inputId);
	form.appendChild(inputIdUser);
	form.appendChild(divName);
	form.appendChild(divDescription);
	form.appendChild(divAmount);
	switch (type) {
		case "debt":
			const divInterest = createInput(
				"formInputInterest",
				"Interés",
				data.interest,
				"number"
			);
			const divInstallments = createInput(
				"formInputInstallments",
				"Cuotas",
				data.installments,
				"number"
			);
			form.appendChild(divInterest);
			form.appendChild(divInstallments);
			break;
		case "income":
			const divFrequency = createInput(
				"formInputFrequency",
				"Frecuencia",
				data.frecuency,
				"text"
			);
			form.appendChild(divFrequency);
			break;
		case "spent":
			const divCount = createInput(
				"formInputCount",
				"Cantidad",
				data.count,
				"text"
			);
			form.appendChild(divCount);
			break;
	}
	form.appendChild(releaseInputDate(data, type));
	modalBody.appendChild(form);
}
