// ==========Room type========
const customSelect = document.querySelector(".custom-select");
const selectBtn = document.querySelector(".select-button");

selectBtn.addEventListener("click", (event) => {
  event.preventDefault();
  customSelect.classList.toggle("active");
  selectBtn.setAttribute(
    "aria-expanded",
    selectBtn.getAttribute("aria-expanded") === "true" ? "false" : "true"
  );
});
const selectedValue = document.querySelector(".selected-value");
const optionsList = document.querySelectorAll(".select-dropdown li");
const selectedValues = [];
optionsList.forEach((option) => {
  function handler(e) {
    // Click Events
    if (e.type === "click" && e.clientX !== 0 && e.clientY !== 0) {
      const value = this.children[1].textContent;
      if (!selectedValues.includes(value)) {
        selectedValues.push(value);
      } else {
        selectedValues.remove(value);
      }
      selectedValue.textContent = selectedValues.join(", ");
      customSelect.classList.remove("active");
    }
    // Key Events
    if (e.key === "Enter") {
      selectedValue.textContent = this.textContent;
      customSelect.classList.remove("active");
    }
  }

  option.addEventListener("keyup", handler);
  option.addEventListener("click", handler);
});


//https://api2-pnv.bluejaypos.vn/home

// https://api2-pnv.bluejaypos.vn/api/special/rate-plan
// POST

// {
//     "RatePlanId": 17,
//     "DayStart": "2026-08-01",
//     "DayEnd": "2026-09-01",
//     "Price": "500",
//     "SpecialDay": [
//         "2026-08-04",
//         "2026-08-11",
//         "2026-08-18",
//         "2026-08-25",
//         "2026-09-01"
//     ]
// }