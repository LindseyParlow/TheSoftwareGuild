$(document).ready(function () {
	allFeaturedVehicles();
	//vehiclesByQuickSearch();
});

function allSpecials() {
	$.ajax({
		type: "GET",
		url: "http://localhost:59129/home/specials",
		success: function (specialArray) {
			alert("success")
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

				var vehicleInfo = '<div class="col-md-2 panel panel-default" style="margin: 10px"><p>' + "PIC GOES HERE!!!" + '</p>' +
					'<p>' + vehicle.year + " " + vehicle.vehicleModel.vehicleMake.vehicleMakeDescription + " " + vehicle.vehicleModel.vehicleModelDescription + '</p>' +
				'<p>' + vehicle.salePrice + '</p</div>'

				nonFilteredFeaturedVehicles.append(vehicleInfo);
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