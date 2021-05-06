
var apiUrl = 'https://localhost:44317/api/values/';

// Populate stores combo box
init();

function init() {
    getStoreByCity();
    getEmployees();
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

function getStoreSales() {
    var sel = document.getElementById("stores");
    var storeId = sel.value;
    var nm = sel.options[sel.selectedIndex].text;

    var text = "";

    $.get(apiUrl + "/salesOfStore/" + storeId, function (data, status) {  // AJAX get
        text = "Sales of Store located at  " + nm + " is $" + data + " for the year";
        $("#ans3").text(text);
    }).fail(function (err) {
        text = "Sales of Store located at " + nm + " is $0 for the year";
        $("#ans3").text(text);
    });
};

function getEmployeeSales() {

    var sel = document.getElementById("employee");
    var empId = sel.value;
    var empName = sel.options[sel.selectedIndex].text;
    var text = "";

    $.get(apiUrl + "/salesOfEmployee/" + empId, function (data, status) {  // AJAX get
        text = "Sales of Employee " + empName + " is $" + data + " for the year";
        $("#ans2").text(text);
    }).fail(function (err) {
        text = "Sales of Employee " + empName + " is $0 for the year";
        $("#ans2").text(text);
    });
};

function getMarkups() {
    $.getJSON(apiUrl + "/topCDCounts")
        .done(function (data) {
            $.each(data, function (key, item) {
                // Add a list item for the product.
                $('<li>', { text: "City: " + item.CityName + ", Count: " + item.RowsCount })
                    .appendTo($('#ans1'));
            });
        }).fail(function (err) {
            $("#ans1Err").text("ERROR: Unexpected error occured.");
        });
}


