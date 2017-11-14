$(document).ready(function () {
	//allSalesVehicles();
	vehiclesByQuickSearch();
	getDetailsSales();
	returnToSearch();
});




function vehiclesByQuickSearch() {
	$("#searchSalesVehicles").on("click", function () {

		$("#filteredSalesVehicles").text("");

		var input = $("#inputForSalesSearch").val();
		var minPrice = $("#minPriceDropList").val();
		var maxPrice = $("#maxPriceDropList").val();
		var minYear = $("#minYearDropList").val();
		var maxYear = $("#maxYearDropList").val();

		if (input == "" && minPrice == 0 && maxPrice == 999999999 && minYear == 1001 && maxYear == 9999) {

			$.ajax({
				type: "GET",
				url: "http://localhost:59129/sales/index",
				success: function (vehicleArray) {
					//alert("success")



					$("#searchBarSection").show();
					$("#searchResultsHeading").show();
					$("#purchaseVehicleHeading").hide();
					$("#singleVehicleDetails").hide();

					var filteredSalesVehicles = $("#filteredSalesVehicles");

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

						filteredSalesVehicles.append(vehicleInfo);
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


					$("#filteredSalesVehicles").text("");
					$("#searchBarSection").show();
					$("searchResultsHeading").show();
					$("#purchaseVehicleHeading").hide();
					$("#singleVehicleDetails").hide();

					var filteredSalesVehicles = $("#filteredSalesVehicles");

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

						filteredSalesVehicles.append(vehicleInfo);
					});

				},
				error: function () {
					//alert("error")
				}
			});
		}
	})
}

function getDetailsSales() {
	$(document).on("click", "#detailsButton", function () {
		var vehicleId = $(this).data('vehicleid');

		$.ajax({
			type: "GET",
			url: "http://localhost:59129/sales/purchase/" + vehicleId,
			success: function (vehicle) {
				alert("success")


				$("#filteredSalesVehicles").hide();
				$("#searchBarSection").hide();
				$("#searchResultsHeading").hide();
				$("#purchaseVehicleHeading").show();
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

		$("#searchResultsHeading").show();
		$("#vehicleDetailsHeading").hide();
		$("#searchBarSection").show();
		$("#singleVehicleDetails").text("");
		$("#singleVehicleDetails").show();
		$("#filteredNewVehicles").show();
	})
}