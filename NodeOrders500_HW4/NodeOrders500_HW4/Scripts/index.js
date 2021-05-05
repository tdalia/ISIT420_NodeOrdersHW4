
var apiUrl = 'https://localhost:44317/api/values/';

// Populate stores combo box
getStoreByCity();
getEmployees();

function init() {
    getStoreByCity();
}

function getStoreByCity() {
    $.get(apiUrl + "/storeByCity", function (data, status) {  // AJAX get

        // console.log("Store By City: ", data);

        // Populates stores combo box
        var storesSelect = document.getElementById("stores");
        for (var i = 0; i < data.length; i++) {
            var el = document.createElement("option");
            el.textContent = data[i].City;
            el.value = data[i].StoreId;
            storesSelect.appendChild(el);
        }

    });
};

function getEmployees() {
    $.get(apiUrl + "/empList", function (data, status) {  // AJAX get

        // console.log("Store By City: ", data);

        // Populates stores combo box
        var employeeSelect = document.getElementById("employee");
        for (var i = 0; i < data.length; i++) {
            var el = document.createElement("option");
            el.textContent = data[i].EmployeeFullName;
            el.value = data[i].SalesPersonId;
            employeeSelect.appendChild(el);
        }

    });
};

function getCityInfo() {
    console.log("Selection City: ", document.getElementById("stores").value);
}

