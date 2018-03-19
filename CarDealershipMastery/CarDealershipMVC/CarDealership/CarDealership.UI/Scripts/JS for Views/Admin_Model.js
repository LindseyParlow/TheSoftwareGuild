$(document).ready(function () {
	loadModelTable();
});

function loadModelTable() {

	$.ajax({
		type: "GET",
		url: "http://localhost:59129/inventory/models/ordered",
		success: function (modelDetailsArray) {
			//alert("success");

			$.each(modelDetailsArray, function (index, modelDetail) {

				var dateOfAdd = (new Date(modelDetail.dateAdded)).toLocaleDateString('en-US');

				var modelInfo = '<tr><td id="column1" style="width: 100px">' + modelDetail.vehicleMake.vehicleMakeDescription + '</td>' +
					'<td id="column1" style="width: 100px">' + modelDetail.vehicleModelDescription + '</td>' +
					'<td id="column1" style="width: 100px">' + dateOfAdd + '</td>' +
					'<td id="column1" style="width: 200px">' + modelDetail.user.email + '</td></tr>';

				$("#modelInfoTable").append(modelInfo);
			});
		},
		error: function () {
			//alert("error");
		}
	});
}