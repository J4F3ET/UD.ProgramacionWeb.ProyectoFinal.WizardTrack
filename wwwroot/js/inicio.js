document.getElementById("listIncome");
document.getElementById("listDebt");
document.getElementById("listSpent");
function generatorItem(data, type) {
	var item = document.createElement("li");
	item.classList.add("list-group-item");
	item.classList.add("list-group-item-action");
	item.classList.add("d-flex");
	item.classList.add("gap-3");
	item.classList.add("py-3");
	var image = document.createElement("img");
	switch (type) {
		case "debt":
			image.src = "~/assets/icons/bank.svg";
			break;
		case "spent":
			image.src = "~/assets/icons/piggy-bank.svg";
			break;
		default:
			image.src = "~/assets/icons/wallet.svg";
			break;
	}
	image.alt = "twbs";
	image.width = "32";
	image.height = "32";
	image.classList.add("text-dark");
	//<div class="d-flex gap-2 w-100 justify-content-between">
	var divExterno = document.createElement("div");
	divExterno.classList.add("d-flex");
	divExterno.classList.add("gap-2");
	divExterno.classList.add("w-100");
	divExterno.classList.add("justify-content-between");
	//Div interno 1
	var divInterno1 = document.createElement("div");
	var h6 = document.createElement("h6");
	h6.classList.add("mb-0");
	h6.innerText = data.name;
	var p = document.createElement("p");
	p.classList.add("mb-0");
	p.classList.add("opacity-75");
	p.innerText = data.description;
	divInterno1.appendChild(h6);
	// Div interno 2
	var divInterno2 = document.createElement("div");
	var small = document.createElement("small");
	small.classList.add("opacity-50");
	small.classList.add("text-nowrap");
	small.classList.add("me-3");
	switch (type) {
		case "debt":
			let date = new Date(data.starDate);
			small.innerText = IPOfecha.setTime(date);
			break;
		case "spent":
			small.innerText = new Date(data.spentDate);
			break;
		default:
			small.innerText = new Date(data.incomeDate);
			break;
	}
	var input = document.createElement("input");
	switch (type) {
		case "debt":
			input.id = `debt-${data.id}`;
			break;
		case "spent":
			input.id = `spent-${data.id}`;
			break;
		default:
			input.id = `income-${data.id}`;
			break;
	}
	input.type = "checkbox";
	input.classList.add("btn-check");
	var label = document.createElement("label");
	label.classList.add("btn");
	label.classList.add("btn-outline-success");
	label.for = input.id;
	label.innerText = "Finalizar";
	// Agregar elementos
	divInterno2.appendChild(small);
	divInterno2.appendChild(input);
	divInterno2.appendChild(label);
	divExterno.appendChild(divInterno1);
	divExterno.appendChild(divInterno2);
	item.appendChild(image);
	item.appendChild(divExterno);
	return item;
}
const generatorListIncome = (data) => {
	const list = document.getElementById("listIncome");
	data.forEach((element) => {
		list.appendChild(generatorItem(element, "income"));
	});
};
const generatorListDebt = (data) => {
	const list = document.getElementById("listDebt");
	data.forEach((element) => {
		list.appendChild(generatorItem(element, "debt"));
	});
};
const generatorListSpent = (data) => {
	const list = document.getElementById("listSpent");
	data.forEach((element) => {
		list.appendChild(generatorItem(element, "spent"));
	});
};
const callBackGeneratorLists = (data) => {
	console.log(data);
	generatorListIncome(data.incomes);
	generatorListDebt(data.debts);
	generatorListSpent(data.spents);
};
fetchData(callBackGeneratorLists);
