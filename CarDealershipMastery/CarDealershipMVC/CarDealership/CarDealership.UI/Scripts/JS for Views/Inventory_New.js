$(document).ready(function () {
	allNewVehicles();
	//vehiclesByQuickSearch();
});

function allNewVehicles() {
	$.ajax({
		type: "GET",
		url: "http://localhost:59129/inventory/new/all",
		success: function (vehicleArray) {
			//alert("success")
			$("#nonFilteredNewVehicles").show();
			$("#filteredNewVehicles").hide();

			var nonFilteredNewVehicles = $("#nonFilteredNewVehicles");

			$.each(vehicleArray, function (index, vehicle) {

				var vehicleInfo = '<div class="col-md-3"><p>' + vehicle.year + " " + vehicle.vehicleModel.vehicleMake.vehicleMakeDescription + " " + vehicle.vehicleModel.vehicleModelDescription + '</p>' +
					'<p>' + "PIC GOES HERE!" + '</p></div>' +
					'<div class="col-md-3"><p>' + "Body Style: " + vehicle.vehicleBody.vehicleBodyDescription + '</p>' +
					'<p>' + "Trans: " + vehicle.transmission.transmissionType + '</p>' +
					'<p>' + "Color: " + vehicle.vehicleColor + '</p></div>' +
					'<div class="col-md-3"><p>' + "Interior: " + vehicle.interiorColor + '</p>' +
					'<p>' + "Mileage: " + vehicle.mileage + '</p>' +
					'<p>' + "VIN: " + vehicle.vinNumber + '</p></div>' +
					'<div class="col-md-3"><p>' + "Sales Price: " + vehicle.salePrice + '</p>' +
					'<p>' + "MSRP: " + vehicle.msrpPrice + '</p>' +
					'<p><button class="btn btn-primary" id="admBtn">Details</button></p></div>';

				nonFilteredNewVehicles.append(vehicleInfo);
			});
		},
		error: function () {
			//alert("error")
		}
	});
}


function vehiclesByQuickSearch() {
	$
}