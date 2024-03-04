// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const inputField = document.getElementById("c_code");
const applyButton = document.getElementById("button-addon2");

console.log(inputField);

// Initially disable the button
applyButton.disabled = true;

// Event listener to handle input changes
inputField.addEventListener("input", () => {
	if (inputField.value.trim() !== "") {
		applyButton.disabled = false;
	} else {
		applyButton.disabled = true;
	}
});