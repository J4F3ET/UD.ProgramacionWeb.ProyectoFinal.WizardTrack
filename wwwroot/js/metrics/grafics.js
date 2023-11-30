function dataIncome(data) {
	// Acceder a los valores de "incomes"
	const sumByMonth = Array.from({length: 12}, () => 0);
	// Recorrer los ingresos y sumar por mes
	data.incomes.forEach((income) => {
		const date = new Date(income.incomeDate);
		const month = date.getMonth();

		// Sumar el monto al mes correspondiente
		sumByMonth[month] += income.amount;
	});
	return sumByMonth;
}
function dataDebt(data) {
	// Acceder a los valores de "incomes"
	const sumByMonth = Array.from({length: 12}, () => 0);
	// Recorrer los ingresos y sumar por mes
	data.debts.forEach((debt) => {
		const date = new Date(debt.starDate);
		const month = date.getMonth();

		// Sumar el monto al mes correspondiente
		sumByMonth[month] += debt.amount;
	});
	return sumByMonth;
}
function dataSpent(data) {
	// Acceder a los valores de "spents"
	const types = data.spents.map((spent) => spent.name);
	const sumByType = Array.from({length: types.length}, () => 0);
	// Recorrer los ingresos y sumar por mes
	data.spents.forEach((spent) => {
		let type = types.indexOf(spent.name);
		sumByType[type] += spent.amount;
	});
	return {types, sumByType};
}
function dataIncomeDebtSpent(data) {
	const currentMonth = new Date().getMonth();
	const spent = data.spents.filter((spent) => {
		return new Date(spent.spentDate).getMonth() === currentMonth;
	});

	const income = data.incomes.filter((income) => {
		return new Date(income.incomeDate).getMonth() === currentMonth;
	});

	const debt = data.debts.filter((debt) => {
		return new Date(debt.starDate).getMonth() === currentMonth;
	});

	const sumIncome = income.reduce(
		(sum, currentItem) => sum + (currentItem.amount || 0),
		0
	);
	const sumDebt = debt.reduce(
		(sum, currentItem) => sum + (currentItem.amount || 0),
		0
	);
	const sumSpent = spent.reduce(
		(sum, currentItem) => sum + (currentItem.amount || 0),
		0
	);
	return {sumIncome, sumDebt, sumSpent};
}
const statisticIncomeDebt = (dataRest) => {
	const dataResponse = dataIncome(dataRest);
	let canvas = document.getElementById("statisticIncome").getContext("2d");
	const data = {
		labels: [
			"Enero",
			"Febrero",
			"Marzo",
			"Abril",
			"Mayo",
			"Junio",
			"Julio",
			"Agosto",
			"Septiembre",
			"Octubre",
			"Noviembre",
			"Diciembre",
		],
		datasets: [
			{
				label: "Ingresos por mes",
				data: dataResponse,
				fill: false,
				borderColor: "rgb(75, 192, 192)",
			},
			{
				label: "Deudas por mes",
				data: dataDebt(dataRest),
				fill: false,
				borderColor: "rgb(192, 75, 81)",
			},
		],
	};
	const config = {
		type: "line",
		data: data,
		options: {
			responsive: true,
			maintainAspectRatio: false,
			scales: {
				y: {
					// defining min and max so hiding the dataset does not change scale range
					min: dataResponse.min,
					max: dataResponse.max,
				},
			},
		},
	};
	return new Chart(canvas, config);
};
const statisticSpent = (dataRest) => {
	const dataResponse = dataSpent(dataRest);
	let canvas = document.getElementById("statisticSpent").getContext("2d");
	const data = {
		labels: dataResponse.types,
		datasets: [
			{
				data: dataResponse.sumByType,
				fill: false,
				borderColor: "rgb(95, 192, 75)",
			},
		],
	};
	const config = {
		type: "line",
		data: data,
		options: {
			responsive: true,
			maintainAspectRatio: false,
			scales: {
				y: {
					// defining min and max so hiding the dataset does not change scale range
					min: dataResponse.sumByType.min,
					max: dataResponse.sumByType.max,
				},
			},
			plugins: {
				legend: {
					display: false,
				},
				title: {
					display: true,
					text: `Gastos`,
				},
			},
		},
	};
	return new Chart(canvas, config);
};

const statisticIncomeDebtSpent = (dataRest) => {
	const mesString = [
		"Enero",
		"Febrero",
		"Marzo",
		"Abril",
		"Mayo",
		"Junio",
		"Julio",
		"Agosto",
		"Septiembre",
		"Octubre",
		"Noviembre",
		"Diciembre",
	];
	const currentMonth = new Date().getMonth();
	const dataResponse = dataIncomeDebtSpent(dataRest);
	let canvas = document.getElementById("statisticSaveCount").getContext("2d");
	const data = {
		labels: ["Ingresos", "Deudas", "Gastos"],
		datasets: [
			{
				label: "Montos",
				data: [
					dataResponse.sumIncome,
					dataResponse.sumDebt,
					dataResponse.sumSpent,
				],
				backgroundColor: [
					"rgb(95, 192, 75)",
					"rgb(192, 75, 81)",
					"rgb(75, 192, 192)",
				],
				borderColor: "rgba(0, 0, 0, 0.1)", // Color del borde
				borderWidth: 1, // Ancho del borde
			},
		],
	};

	const config = {
		type: "bar",
		data: data,
		options: {
			responsive: true,
			responsive: true,
			maintainAspectRatio: false,
			elements: {
				bar: {
					borderWidth: 2,
				},
			},
			scales: {
				y: {
					// defining min and max so hiding the dataset does not change scale range
					min: dataResponse.min,
					max: dataResponse.max,
				},
			},
			plugins: {
				legend: {
					display: false,
				},
				title: {
					display: true,
					text: `Ingresos, deudas y gastos del mes de ${mesString[currentMonth]}`,
				},
			},
		},
	};
	return new Chart(canvas, config);
};
function releaseTypeDataItem(data) {
	if ("spentDate" in data) {
		return data.spentDate;
	} else if ("incomeDate" in data) {
		return data.incomeDate;
	} else {
		return data.starDate;
	}
}
function releaseDataToReport(data, currentMonth) {
	var sumItem = 0;
	data.forEach((item) => {
		itemDate = new Date(releaseTypeDataItem(item));
		if (itemDate.getMonth() === currentMonth) {
			sumItem += item.amount;
		}
	});
	return sumItem;
}
function generatorReportInPage(dataRest) {
	const currentMonth = new Date().getMonth();
	const mesString = [
		"Enero",
		"Febrero",
		"Marzo",
		"Abril",
		"Mayo",
		"Junio",
		"Julio",
		"Agosto",
		"Septiembre",
		"Octubre",
		"Noviembre",
		"Diciembre",
	];
	// Crear el contenedor
	const divContainer = document.createElement("div");
	divContainer.classList.add("container");
	// Crear el titulo
	const divRowTitle = document.createElement("div");
	divRowTitle.classList.add("row");
	const pTitle = document.createElement("p");
	pTitle.classList.add("display-6");
	pTitle.classList.add("text-center");
	pTitle.id = "reportTitle";
	pTitle.innerText = `Informe de ${mesString[currentMonth]}`;
	divRowTitle.appendChild(pTitle);
	divContainer.appendChild(divRowTitle);
	// Crear los inputs
	const divRowSpent = generatorDivReport(
		"reportSpentByMonth",
		"Gastos:",
		releaseDataToReport(dataRest.spents, currentMonth)
	);
	divContainer.appendChild(divRowSpent);
	const divRowIncome = generatorDivReport(
		"reportIcomesByMonth",
		"Ingresos:",
		releaseDataToReport(dataRest.incomes, currentMonth)
	);
	divContainer.appendChild(divRowIncome);
	const divRowDebt = generatorDivReport(
		"reportDebtByMonth",
		"Deuda:",
		releaseDataToReport(dataRest.debts, currentMonth)
	);
	divContainer.appendChild(divRowDebt);
	const divRowSaveCount = generatorDivReport(
		"reportSaveCountByMonth",
		"Ahorro:",
		releaseDataToReport(dataRest.saveCounts, currentMonth)
	);
	divContainer.appendChild(divRowSaveCount);
	// Agregar el contenedor al body
	const divReport = document.getElementById("reportDiv");
	divReport.appendChild(divContainer);
	return divReport;
}

function generatorDivReport(inputId, inputLabel, inputValue) {
	const divRow = document.createElement("div");
	divRow.classList.add("row", "g-3", "align-items-center");
	// Crear el label
	const divColLabel = generatorLabel(inputLabel, inputId, "label");
	divRow.appendChild(divColLabel);
	// Crear el input
	const divColInput = generatorLabel(inputValue, inputId, "input");
	divRow.appendChild(divColInput);
	return divRow;
}
function generatorLabel(labelText, labelFor, typeLabel) {
	const divColLabel = document.createElement("div");
	divColLabel.classList.add("col-auto");
	const label = document.createElement(typeLabel);
	if (typeLabel === "label") {
		label.classList.add("col-form-label");
		label.innerText = labelText;
		label.for = labelFor;
	} else {
		label.classList.add("form-control-plaintext");
		label.id = labelFor;
		label.value = labelText;
		label.id = labelFor;
		label.type = "text";
		label.readOnly = true;
	}
	divColLabel.appendChild(label);
	return divColLabel;
}

const generatorReportPdf = (canvasReport, canvas) => {
	const {jsPDF} = window.jspdf;
	const pdf = new jsPDF();
	pdf.addImage(
		canvasReport.toDataURL("image/png"),
		"PNG",
		10,
		10,
		canvas.width,
		canvas.height
	);
	canvas.forEach((item) => {
		pdf.addImage(
			item.toDataURL("image/png"),
			"PNG",
			10,
			10,
			canvas.width,
			canvas.height
		);
	});
	pdf.save("report.pdf");
};
const statisticAllCallBacks = (data) => {
	const canvasIncomeDebt = statisticIncomeDebt(data);
	const canvasSpent = statisticSpent(data);
	const canvasIncomeDebtSpent = statisticIncomeDebtSpent(data);
	const report = generatorReportInPage(data);
	const canvas = {
		1: canvasIncomeDebt.canvas.toDataURL("image/png"),
		2: canvasSpent.canvas.toDataURL("image/png"),
		3: canvasIncomeDebtSpent.canvas.toDataURL("image/png"),
	};
	document.getElementById("btnPrintReportPDF").addEventListener("click", () => {
		generatorReportPdf(report, canvas);
	});
};
fetchData(statisticAllCallBacks);
