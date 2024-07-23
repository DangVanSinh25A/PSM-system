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

// ============================= Handle API ===========================

document.addEventListener("DOMContentLoaded", function () {
  var rateId = sessionStorage.getItem("id");
  console.log("RateId", rateId);

  // ===================== Display data from criteria =====================
  fetch(
    `http://192.168.1.131:5034/api/room-type?hotelId=${sessionStorage.getItem(
      "hotelId"
    )}`
  )
    .then((response) => response.json())
    .then((data) => {
      const roomTypes = data.value;
      const roomTypeSelect = document.getElementById("roomType");

      while (roomTypeSelect.options.length > 1) {
        roomTypeSelect.remove(1);
      }

      roomTypes.forEach((roomType) => {
        const option = document.createElement("option");
        option.value = roomType.id;
        option.textContent = roomType.name;
        roomTypeSelect.appendChild(option);
      });
    })
    .catch((error) => {
      console.error("Error fetching room types:", error);
    });

  fetch("https://api2-pnv.bluejaypos.vn/api/cancel-policy")
    .then((response) => response.json())
    .then((data) => {
      const cancelPolicies = data.value;
      const cancelPolicySelect = document.getElementById("cancelPolicy");

      while (cancelPolicySelect.options.length > 1) {
        cancelPolicySelect.remove(1);
      }
      cancelPolicies.forEach((cancelPolicy) => {
        const option = document.createElement("option");
        option.value = cancelPolicy.id;
        option.textContent = cancelPolicy.name;
        cancelPolicySelect.appendChild(option);
      });
    })
    .catch((error) => {
      console.error("Error fetching cancel policies:", error);
    });
  fetch("http://192.168.1.131:5034/api/payment-constraint")
    .then((response) => response.json())
    .then((data) => {
      const payments = data.value;
      const paymentSelected = document.getElementById("paymentConstraint");

      while (paymentSelected.options.length > 1) {
        paymentSelected.remove(1);
      }
      payments.forEach((paymentConstraint) => {
        const option = document.createElement("option");
        option.value = paymentConstraint.id;
        option.textContent = paymentConstraint.name;
        paymentSelected.appendChild(option);
      });
    })
    .catch((error) => {
      console.error("Error fetching cancel policies:", error);
    });

  // Fetch dữ liệu từ API
fetch("https://api2-pnv.bluejaypos.vn/api/additional")
.then((response) => response.json())
.then((data) => {
  const additionals = data.value;
  // Lấy phần tử ul để thêm các checkbox vào
  const ulElement = document.getElementById('addtional');
  
  // Xóa tất cả các phần tử li hiện có (nếu cần)
  ulElement.innerHTML = '';
  
  // Tạo và thêm các phần tử li mới vào ul
  additionals.forEach((additional, index) => {
    // Tạo thẻ li
    const li = document.createElement('li');
    
    // Tạo checkbox
    const checkbox = document.createElement('input');
    checkbox.type = 'checkbox';
    checkbox.id = `checkbox-${index}`;
    
    // Tạo label
    const label = document.createElement('label');
    label.setAttribute('for', checkbox.id);
    label.textContent = additional.name;
    
    // Thêm checkbox và label vào li
    li.appendChild(checkbox);
    li.appendChild(label);
    
    // Thêm li vào ul
    ulElement.appendChild(li);
  });
})
.catch((error) => {
  console.error("Error fetching data:", error);
});

  // ===================== Display data from RateId =====================
  if (rateId) {
    fetch(`https://api2-pnv.bluejaypos.vn/api/rate-plan/${rateId}`)
      .then((response) => response.json())
      .then((data) => {
        const ratePlan = data.ratePlans[0].ratePlan;
        // console.log(ratePlan);

        document.getElementById("name").value = ratePlan.name;
        document.getElementById("price").value = ratePlan.price;
        document.getElementById("dayStart").value =
          ratePlan.daystart.split("T")[0];
        document.getElementById("dayEnd").value = ratePlan.dayEnd.split("T")[0];
        document.getElementById("roomType").value = ratePlan.roomType.name;
        document.getElementById("occupancyLimit").value =
          ratePlan.occupancyLimit;
        document.getElementById("cancelPolicy").value =
          ratePlan.cancelPolicy.name;
        document.getElementById("paymentConstraint").value =
          ratePlan.paymentConstraint.name;
        document.getElementById("status").value = ratePlan.status ? 1 : 2;

        // =========== Display data in room type ===============
        const roomTypeSelect = document.getElementById("roomType");
        const selectedOption = roomTypeSelect.querySelector(
          `option[value='${ratePlan.roomType.id}']`
        );
        if (selectedOption) {
          selectedOption.textContent = ratePlan.roomType.name;
          roomTypeSelect.value = ratePlan.roomType.id;
        }
        // =========== Display data in cancel policy ===============
        const cancelSelect = document.getElementById("cancelPolicy");
        const selectedCancel = cancelSelect.querySelector(
          `option[value='${ratePlan.cancelPolicy.id}']`
        );
        if (selectedCancel) {
          selectedCancel.textContent = ratePlan.cancelPolicy.name;
          cancelSelect.value = ratePlan.cancelPolicy.id;
        }
        // =========== Display data in payment constraint ===============
        const paymentSelect = document.getElementById("paymentConstraint");
        const paymentSelected = paymentSelect.querySelector(
          `option[value='${ratePlan.paymentConstraint.id}']`
        );
        if (paymentSelected) {
          paymentSelected.textContent = ratePlan.paymentConstraint.name;
          paymentSelect.value = ratePlan.paymentConstraint.id;
        }
        // =========== Display data in additional ==============
       
      })
      .catch((error) => console.error("Error fetching rate plan:", error));
  }
});
