const customSelect = document.querySelector(".custom-select");
const selectBtn = document.querySelector(".select-button");
const selectedValue = document.querySelector(".selected-value");
const optionsList = document.querySelectorAll(".select-dropdown li");
const selectedValues = [];

selectBtn.addEventListener("click", (event) => {
  event.preventDefault();
  customSelect.classList.toggle("active");
  selectBtn.setAttribute(
    "aria-expanded",
    selectBtn.getAttribute("aria-expanded") === "true" ? "false" : "true"
  );
});

optionsList.forEach((option) => {
  const checkbox = option.querySelector("input[type='checkbox']");
  const label = option.querySelector("label");
  const value = label.textContent;

  checkbox.addEventListener("change", (e) => {
    if (e.target.checked) {
      if (!selectedValues.includes(value)) {
        selectedValues.push(value);
      }
    } else {
      const index = selectedValues.indexOf(value);
      if (index > -1) {
        selectedValues.splice(index, 1);
      }
    }
    selectedValue.textContent = selectedValues.join(", ");
    // Hidden dropdown after choosed
    customSelect.classList.remove("active");
    selectBtn.setAttribute("aria-expanded", "false");
  });
});