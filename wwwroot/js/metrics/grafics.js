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
		return new Date(spent.spentDate).getMonth() + 1 === currentMonth;
	});

	const income = data.incomes.filter((income) => {
		return new Date(income.incomeDate).getMonth() + 1 === currentMonth;
	});

	const debt = data.debts.filter((debt) => {
		return new Date(debt.starDate).getMonth() + 1 === currentMonth;
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
	new Chart(canvas, config);
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
	new Chart(canvas, config);
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
	new Chart(canvas, config);
};
const statisticAllCallBacks = (data) => {
	statisticIncomeDebt(data);
	statisticSpent(data);
	statisticIncomeDebtSpent(data);
};
fetchData(statisticAllCallBacks);
