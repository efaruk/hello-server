
// Tabler Theme Management Begin
function toggleTheme() {
	var themeStorageKey = "tablerTheme";
	var defaultToggleTheme = "dark";
	var selectedTheme;
	var storedTheme = localStorage.getItem(themeStorageKey);
	if (storedTheme) {
		if (storedTheme === 'light') {
			selectedTheme = 'dark';
			document.body.classList.remove("theme-light");
			document.body.classList.add("theme-dark");
		} else {
			selectedTheme = 'light';
			document.body.classList.remove("theme-dark");
			document.body.classList.add("theme-light");
		}
	} else {
		selectedTheme = defaultToggleTheme;
	}

	localStorage.setItem(themeStorageKey, selectedTheme);
	if (selectedTheme === 'dark') {
		document.body.setAttribute("data-bs-theme", selectedTheme);
	} else {
		document.body.removeAttribute("data-bs-theme");
	}
}

function loadUserTheme() {
	var themeStorageKey = "tablerTheme";
	var storedTheme = localStorage.getItem(themeStorageKey);

	if (storedTheme === 'dark') {
		document.body.setAttribute("data-bs-theme", storedTheme);
		document.body.classList.remove("theme-light");
		document.body.classList.add("theme-dark");
	} else {
		document.body.removeAttribute("data-bs-theme");
		document.body.classList.remove("theme-dark");
		document.body.classList.add("theme-light");
	}
}

loadUserTheme();

// Tabler Theme Management End