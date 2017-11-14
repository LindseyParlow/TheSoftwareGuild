$(document).ready(function () {
	//allNewVehicles();
	vehiclesByQuickSearch();
	getDetailsNew();
	returnToSearch();
});




function vehiclesByQuickSearch() {
	$("#searchNewVehicles").on("click", function () {

		$("#filteredNewVehicles").text("");

		var input = $("#inputForNewSearch").val();
		var minPrice = $("#minPriceDropList").val();
		var maxPrice = $("#maxPriceDropList").val();
		var minYear = $("#minYearDropList").val();
		var maxYear = $("#maxYearDropList").val();

		if (input == "" && minPrice == 0 && maxPrice == 999999999 && minYear == 1001 && maxYear == 9999) {

			$.ajax({
				type: "GET",
				url: "http://localhost:59129/inventory/new/all",
				success: function (vehicleArray) {
					//alert("success")

					
					
					$("#SearchBarSection").show();
					$("#SearchResultsHeading").show();
					$("#VehicleDetailsHeading").hide();
					$("#singleVehicleDetails").hide();

					var filteredNewVehicles = $("#filteredNewVehicles");

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
							'<p><button class="btn btn-primary" id="detailsButton" data-vehicleid="' + vehicle.vehicleId + '">Details</button></p></div>';

						filteredNewVehicles.append(vehicleInfo);
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
				url: "http://localhost:59129/inventory/new/" + input + "/" + minPrice + "/" + maxPrice + "/" + minYear + "/" + maxYear,
				success: function (vehicleArray) {
					//alert("success")
					
					
					$("#filteredNewVehicles").text("");
					$("#SearchBarSection").show();
					$("#SearchResultsHeading").show();
					$("#VehicleDetailsHeading").hide();
					$("#singleVehicleDetails").hide();

					var filteredNewVehicles = $("#filteredNewVehicles");

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
							'<p><button class="btn btn-primary" id="detailsButton" data-vehicleid="' + vehicle.vehicleId + '">Details</button></p></div>';

						filteredNewVehicles.append(vehicleInfo);
					});

				},
				error: function () {
					//alert("error")
				}
			});
		}
	})
}

function getDetailsNew() {
	$(document).on("click", "#detailsButton", function () {
		var vehicleId = $(this).data('vehicleid');

		$.ajax({
			type: "GET",
			url: "http://localhost:59129/inventory/details/" + vehicleId,
			success: function (vehicle) {
				alert("success")

				
				$("#filteredNewVehicles").hide();
				$("#SearchBarSection").hide();
				$("#SearchResultsHeading").hide();
				$("#VehicleDetailsHeading").show();
				$("#singleVehicleDetails").show();

				var vehicleInfo = '<div class="col-md-3"><p>' + vehicle.year + " " + vehicle.vehicleModel.vehicleMake.vehicleMakeDescription + " " + vehicle.vehicleModel.vehicleModelDescription + '</p>' +
					'<p>' + "PIC GOES HERE!" + '</p></div>' +
					'<div class="col-md-3"><p>' + "Body Style: " + vehicle.vehicleBody.vehicleBodyDescription + '</p>' +
					'<p>' + "Trans: " + vehicle.transmission.transmissionType + '</p>' +
					'<p>' + "Color: " + vehicle.vehicleColor + '</p></div>' +
					'<div class="col-md-3"><p>' + "Interior: " + vehicle.interiorColor + '</p>' +
					'<p>' + "Mileage: " + vehicle.mileage + '</p>' +
					'<p>' + "VIN: " + vehicle.vinNumber + '</p></div>' +
					'<div class="col-md-3"><p>' + "Sales Price: " + vehicle.salePrice + '</p>' +
					'<p>' + "MSRP: " + vehicle.msrpPrice + '</p></div>' + 
					'<div class="col-md-12">' + "Description: " + vehicle.vehicleDescription + '</div>' +
					'<div class="col-md-12"><button class="btn btn-primary" id="contactUsButton">Contact Us</button><button class="btn btn-primary" id="returnButton">Return To Search</button></div>'

				$("#singleVehicleDetails").append(vehicleInfo);

			},
			error: function () {
				alert("error")
			}
		});
	})
}

function returnToSearch() {
	$(document).on("click", "#returnButton", function () {

		$("#SearchResultsHeading").show();
		$("#VehicleDetailsHeading").hide();
		$("#SearchBarSection").show();
		$("#singleVehicleDetails").text("");
		$("#singleVehicleDetails").show();
		$("#filteredNewVehicles").show();
	})
}