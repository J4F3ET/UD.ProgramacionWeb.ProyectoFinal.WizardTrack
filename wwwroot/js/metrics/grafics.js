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
const statisticIncome = (dataRest) => {
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
		],
	};
	const config = {
		type: "line",
		data: data,
		options: {
			responsive: true,
			maintainAspectRatio: false,
			animations: {
				tension: {
					duration: 1000,
					easing: "linear",
					from: 1,
					to: 0,
					loop: true,
				},
			},
			scales: {
				y: {
					// defining min and max so hiding the dataset does not change scale range
					min: dataResponse.min,
					max: dataResponse.max,
				},
			},
		},
	};
	var chart = new Chart(canvas, config);
};
const statisticDebt = (dataRest) => {
	const dataResponse = dataDebt(dataRest);
	let canvas = document.getElementById("statisticDebt").getContext("2d");
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
				label: "Deudas por mes",
				data: dataResponse,
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
			animations: {
				tension: {
					duration: 1000,
					easing: "linear",
					from: 1,
					to: 0,
					loop: true,
				},
			},
			scales: {
				y: {
					// defining min and max so hiding the dataset does not change scale range
					min: dataResponse.min,
					max: dataResponse.max,
				},
			},
		},
	};
	var chart = new Chart(canvas, config);
};
const statisticAllCallBacks = (data) => {
	statisticIncome(data);
	statisticDebt(data);
};
fetchData(statisticAllCallBacks);
