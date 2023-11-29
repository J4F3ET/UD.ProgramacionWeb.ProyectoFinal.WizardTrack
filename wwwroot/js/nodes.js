// No olvides poner los puntitos para evitar dolores de cabeza por fa
const $ = (id) => document.querySelector(id);

const Toast = Swal.mixin({
	toast: true,
	showConfirmButton: false,
	timer: 2000,
	timerProgressBar: true,
	didOpen: (toast) => {
		toast.addEventListener("mouseenter", Swal.stopTimer);
		toast.addEventListener("mouseleave", Swal.resumeTimer);
	},
});

// Botones de navegación
const btn_sign_up_registrar = $("#sign_up_registrar");
const btn_sign_up_login = $("#sign_up_iniciar");
const btn_log_in_registrar = $("#log_in_registrar");
const btn_log_in_login = $("#log_in_iniciar");

// Para el sign up
const section_sign_up = $("#section_sign_up");

// Para el logn in
const section_log_in = $("#section_log_in");