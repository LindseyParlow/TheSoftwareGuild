 $(document).ready(function () {
	//allSalesVehicles();
	vehiclesByQuickSearch();
	getPurchaseSales();
	cancelToSearch();
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
				url: "http://localhost:59129/sales/index/all",
				success: function (vehicleArray) {
					//alert("success")

					$("#searchBarSection").show();
					$("#searchResultsHeading").show();
					$("#purchaseVehicleHeading").hide();
					$("#singleVehicleDetails").hide();
					$("#salesInfoForm").hide();

					var filteredSalesVehicles = $("#filteredSalesVehicles");

					$.each(vehicleArray, function (index, vehicle) {

						var vehicleInfo = '<div class="col-md-12" style="border: 2px solid black; padding: 10px; margin-bottom: 20px"><div class="col-md-3"><p>' + vehicle.year + " " + vehicle.vehicleModel.vehicleMake.vehicleMakeDescription + " " + vehicle.vehicleModel.vehicleModelDescription + '</p>' +
							'<p>' + '<img src="../Images/' + vehicle.imagePath + '" class="imageFormat" />' + '</p></div>' +
							'<div class="col-md-3"><p>' + "Body Style: " + vehicle.vehicleBody.vehicleBodyDescription + '</p>' +
							'<p>' + "Trans: " + vehicle.transmission.transmissionType + '</p>' +
							'<p>' + "Color: " + vehicle.vehicleColor + '</p></div>' +
							'<div class="col-md-3"><p>' + "Interior: " + vehicle.interiorColor + '</p>' +
							'<p>' + "Mileage: " + vehicle.mileage + '</p>' +
							'<p>' + "VIN: " + vehicle.vinNumber + '</p></div>' +
							'<div class="col-md-3"><p>' + "Sales Price: $" + vehicle.salePrice + '</p>' +
							'<p>' + "MSRP: $" + vehicle.msrpPrice + '</p>' +
							'<p><button class="btn btn-primary" id="purchaseButton" data-vehicleid="' + vehicle.vehicleId + '">Purchase</button></p></div></div>';

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
					$("#salesInfoForm").hide();

					var filteredSalesVehicles = $("#filteredSalesVehicles");

					$.each(vehicleArray, function (index, vehicle) {

						var vehicleInfo = '<div class="col-md-12" style="border: 2px solid black; padding: 10px; margin-bottom: 20px"><div class="col-md-3"><p>' + vehicle.year + " " + vehicle.vehicleModel.vehicleMake.vehicleMakeDescription + " " + vehicle.vehicleModel.vehicleModelDescription + '</p>' +
							'<p>' + '<img src="../Images/' + vehicle.imagePath + '" class="imageFormat" />' + '</p></div>' +
							'<div class="col-md-3"><p>' + "Body Style: " + vehicle.vehicleBody.vehicleBodyDescription + '</p>' +
							'<p>' + "Trans: " + vehicle.transmission.transmissionType + '</p>' +
							'<p>' + "Color: " + vehicle.vehicleColor + '</p></div>' +
							'<div class="col-md-3"><p>' + "Interior: " + vehicle.interiorColor + '</p>' +
							'<p>' + "Mileage: " + vehicle.mileage + '</p>' +
							'<p>' + "VIN: " + vehicle.vinNumber + '</p></div>' +
							'<div class="col-md-3"><p>' + "Sales Price: $" + vehicle.salePrice + '</p>' +
							'<p>' + "MSRP: $" + vehicle.msrpPrice + '</p>' +
							'<p><button class="btn btn-primary" id="purchaseButton" data-vehicleid="' + vehicle.vehicleId + '">Purchase</button></p></div></div>';

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

function getPurchaseSales() {
	$(document).on("click", "#purchaseButton", function () {
		var vehicleId = $(this).data('vehicleid');

		$("#vehicleId").val(vehicleId);

		$.ajax({
			type: "GET",
			url: "http://localhost:59129/sales/purchase/" + vehicleId,
			success: function (vehicle) {
				//alert("success")


				$("#filteredSalesVehicles").hide();
				$("#searchBarSection").hide();
				$("#searchResultsHeading").hide();
				$("#purchaseVehicleHeading").show();
				$("#singleVehicleDetails").show();
				$("#salesInfoForm").show();

				var vehicleInfo = '<div class="col-md-12" style="border: 2px solid black; padding:10px"><div class="col-md-3"><p>' + vehicle.year + " " + vehicle.vehicleModel.vehicleMake.vehicleMakeDescription + " " + vehicle.vehicleModel.vehicleModelDescription + '</p>' +
					'<p>' + '<img src="../Images/' + vehicle.imagePath + '" class="imageFormat" />' + '</p></div>' +
					'<div class="col-md-3"><p>' + "Body Style: " + vehicle.vehicleBody.vehicleBodyDescription + '</p>' +
					'<p>' + "Trans: " + vehicle.transmission.transmissionType + '</p>' +
					'<p>' + "Color: " + vehicle.vehicleColor + '</p></div>' +
					'<div class="col-md-3"><p>' + "Interior: " + vehicle.interiorColor + '</p>' +
					'<p>' + "Mileage: " + vehicle.mileage + '</p>' +
					'<p>' + "VIN: " + vehicle.vinNumber + '</p></div>' +
					'<div class="col-md-3"><p>' + "Sales Price: $" + vehicle.salePrice + '</p>' +
					'<p>' + "MSRP: $" + vehicle.msrpPrice + '</p></div>' +
					'<div class="col-md-12">' + "Description: " + vehicle.vehicleDescription + '</div>' +
					'<div class="col-md-12"><button class="btn btn-primary" id="cancelButton">Cancel</button></div></div>'

				$("#singleVehicleDetails").append(vehicleInfo);

			},
			error: function () {
				//alert("error")
			}
		});
	})
}

function cancelToSearch() {
	$(document).on("click", "#cancelButton", function () {

		$("#searchResultsHeading").show();
		$("#purchaseVehicleHeading").hide();
		$("#searchBarSection").show();
		$("#singleVehicleDetails").text("");
		$("#singleVehicleDetails").show();
		$("#filteredSalesVehicles").show();
		$("#salesInfoForm").hide();
	})
}