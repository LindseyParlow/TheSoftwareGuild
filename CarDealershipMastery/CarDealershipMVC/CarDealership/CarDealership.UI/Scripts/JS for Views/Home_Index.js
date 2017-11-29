$(document).ready(function () {
	allFeaturedVehicles();
	getDetailsFeatured();
	returnToSearch();
});

function allSpecials() {
	$.ajax({
		type: "GET",
		url: "http://localhost:59129/home/specials",
		success: function (specialArray) {
			//alert("success")
		}
	})
}


function allFeaturedVehicles() {
	$.ajax({
		type: "GET",
		url: "http://localhost:59129/home/featured",
		success: function (vehicleArray) {
			//alert("success")
			$("#nonFilteredFeaturedVehicles").show();

			var nonFilteredFeaturedVehicles = $("#nonFilteredFeaturedVehicles");

			$.each(vehicleArray, function (index, vehicle) {

				var vehicleInfo = '<div class="col-md-2 panel panel-default" id="featuredVehicleDiv" data-featuredvehicleid="' + vehicle.vehicleId + '" align="center" style="margin: 40px; padding:10px"><p>' + '<img src="../Images/' + vehicle.imagePath + '" class="imageFormat" />' + '</p>' +
					'<p>' + vehicle.year + " " + vehicle.vehicleModel.vehicleMake.vehicleMakeDescription + " " + vehicle.vehicleModel.vehicleModelDescription + '</p>' +
				'<p>' + "$" + vehicle.salePrice + '</p</div>'

				nonFilteredFeaturedVehicles.append(vehicleInfo);
			});
		},
		error: function () {
			//alert("error")
		}
	});
}

function getDetailsFeatured() {
	$(document).on("click", "#featuredVehicleDiv", function () {
		var vehicleId = $(this).data("featuredvehicleid");

		$("#mainContent").hide();
		$("#detailsForOneVehicle").show();

		$.ajax({
			type: "GET",
			url: "http://localhost:59129/inventory/details/" + vehicleId,
			success: function (vehicle) {
				//alert("success")

				if (vehicle.purchaseStatus.purchaseStatusDescription == "Sold") {
					var contactOrSold = '<input type="button" class="btn btn-danger" value="Unavailable- Sold" />';
				}
				else {
					var contactOrSold = '<input type="button" class="btn btn-primary" id="contactUsButton" onClick="window.location=\'/Home/Contact/' + vehicle.vinNumber + '\'" value="Contact Us"/>';
				}

				var vehicleInfo = '<div><h1>Details</h1></div>' + '<div class="col-md-12" style="border: 2px solid black; padding: 10px"><div class="col-md-3"><p>' + vehicle.year + " " + vehicle.vehicleModel.vehicleMake.vehicleMakeDescription + " " + vehicle.vehicleModel.vehicleModelDescription + '</p>' +
					'<p>' + '<img src="../Images/' + vehicle.imagePath + '" class="imageFormat" />' + '</p></div>' +
					'<div class="col-md-3"><p>' + "Body Style: " + vehicle.vehicleBody.vehicleBodyDescription + '</p>' +
					'<p>' + "Trans: " + vehicle.transmission.transmissionType + '</p>' +
					'<p>' + "Color: " + vehicle.vehicleColor + '</p></div>' +
					'<div class="col-md-3"><p>' + "Interior: " + vehicle.interiorColor + '</p>' +
					'<p>' + "Mileage: " + vehicle.mileage + '</p>' +
					'<p>' + "VIN: " + vehicle.vinNumber + '</p></div>' +
					'<div class="col-md-3"><p>' + "Sales Price: " + vehicle.salePrice + '</p>' +
					'<p>' + "MSRP: " + vehicle.msrpPrice + '</p></div>' +
					'<div class="col-md-12">' + "Description: " + vehicle.vehicleDescription + '</div>' +
					'<div class="col-md-12">' + contactOrSold + '<button class="btn btn-primary" id="returnButton">Return To Search</button></div></div>'

				$("#detailsForOneVehicle").append(vehicleInfo);

			},
			error: function () {
				//alert("error")
			}
		});
	})
}

function returnToSearch() {
	$(document).on("click", "#returnButton", function () {

		$("#mainContent").show();
		$("#detailsForOneVehicle").empty();
		$("#detailsForOneVehicle").hide();
	})
}