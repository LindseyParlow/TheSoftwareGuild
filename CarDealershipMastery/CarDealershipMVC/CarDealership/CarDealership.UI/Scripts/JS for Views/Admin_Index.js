$(document).ready(function () {
	vehiclesByQuickSearch();
	//redirectToEdit();
});




function vehiclesByQuickSearch() {
	$("#searchAdminVehicles").on("click", function () {

		$("#filteredAdminVehicles").text("");

		var input = $("#inputForAdminSearch").val();
		var minPrice = $("#minPriceDropList").val();
		var maxPrice = $("#maxPriceDropList").val();
		var minYear = $("#minYearDropList").val();
		var maxYear = $("#maxYearDropList").val();

		if (input == "" && minPrice == 0 && maxPrice == 999999999 && minYear == 1001 && maxYear == 9999) {

			$.ajax({
				type: "GET",
				url: "http://localhost:59129/sales/index/all",
				success: function (vehicleArray) {
					//alert("success")

					$("#SearchBarSection").show();
					$("#SearchResultsHeading").show();
					$("#VehicleDetailsHeading").hide();
					$("#singleVehicleDetails").hide();

					var filteredAdminVehicles = $("#filteredAdminVehicles");

					$.each(vehicleArray, function (index, vehicle) {

						var adminEditButton = '<input type="button" class="btn btn-danger" id="editButton" onClick="window.location=\'/Admin/EditVehicle/' + vehicle.vehicleId + '\'" value="Edit"/>';


						var vehicleInfo = '<div class="col-md-12" style="border: 2px solid black; padding: 10px; margin-bottom: 20px"><div class="col-md-3"><p>' + vehicle.year + " " + vehicle.vehicleModel.vehicleMake.vehicleMakeDescription + " " + vehicle.vehicleModel.vehicleModelDescription + '</p>' +
							'<p>' + '<img src="../Images/' + vehicle.imagePath + '" class="imageFormat" />' + '</p></div>' +
							'<div class="col-md-3"><p>' + "Body Style: " + vehicle.vehicleBody.vehicleBodyDescription + '</p>' +
							'<p>' + "Trans: " + vehicle.transmission.transmissionType + '</p>' +
							'<p>' + "Color: " + vehicle.vehicleColor + '</p></div>' +
							'<div class="col-md-3"><p>' + "Interior: " + vehicle.interiorColor + '</p>' +
							'<p>' + "Mileage: " + vehicle.mileage + '</p>' +
							'<p>' + "VIN: " + vehicle.vinNumber + '</p></div>' +
							'<div class="col-md-3"><p>' + "Sales Price: " + vehicle.salePrice + '</p>' +
							'<p>' + "MSRP: " + vehicle.msrpPrice + '</p>' +
							'<p>' + adminEditButton + '</p></div></div>';

						filteredAdminVehicles.append(vehicleInfo);
					});
				},
				error: function () {
					//alert("error")
				}
			});
		}
		else {

			if (input == "") {
				input = "noVehicleInput";
			}

			$.ajax({
				type: "GET",
				url: "http://localhost:59129/sales/" + input + "/" + minPrice + "/" + maxPrice + "/" + minYear + "/" + maxYear,
				success: function (vehicleArray) {
					//alert("success")


					$("#filteredAdminVehicles").text("");
					$("#SearchBarSection").show();
					$("#SearchResultsHeading").show();
					$("#VehicleDetailsHeading").hide();
					$("#singleVehicleDetails").hide();

					var filteredAdminVehicles = $("#filteredAdminVehicles");

					$.each(vehicleArray, function (index, vehicle) {

						var vehicleInfo = '<div class="col-md-12" style="border: 2px solid black; padding: 10px; margin-bottom: 20px"><div class="col-md-3"><p>' + vehicle.year + " " + vehicle.vehicleModel.vehicleMake.vehicleMakeDescription + " " + vehicle.vehicleModel.vehicleModelDescription + '</p>' +
							'<p>' + '<img src="../Images/' + vehicle.imagePath + '" class="imageFormat" />' + '</p></div>' +
							'<div class="col-md-3"><p>' + "Body Style: " + vehicle.vehicleBody.vehicleBodyDescription + '</p>' +
							'<p>' + "Trans: " + vehicle.transmission.transmissionType + '</p>' +
							'<p>' + "Color: " + vehicle.vehicleColor + '</p></div>' +
							'<div class="col-md-3"><p>' + "Interior: " + vehicle.interiorColor + '</p>' +
							'<p>' + "Mileage: " + vehicle.mileage + '</p>' +
							'<p>' + "VIN: " + vehicle.vinNumber + '</p></div>' +
							'<div class="col-md-3"><p>' + "Sales Price: " + vehicle.salePrice + '</p>' +
							'<p>' + "MSRP: " + vehicle.msrpPrice + '</p>' +
							'<p><button class="btn btn-danger" id="editButton" data-vehicleid="' + vehicle.vehicleId + '">Edit</button></p></div></div>';

						filteredAdminVehicles.append(vehicleInfo);
					});

				},
				error: function () {
					//alert("error")
				}
			});
		}
	});
}



//function redirectToEdit() {
//	$(document).on("click", "#editButton", function () {
//		window.location.href = '/Admin/Edit';
//		return false;
//	});
//}

