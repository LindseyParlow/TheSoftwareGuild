$(document).ready(function () {
	loadMakeTable();
});

function loadMakeTable() {

	$.ajax({
		type: "GET",
		url: "http://localhost:59129/inventory/makes/ordered",
		success: function (makeDetailsArray) {
			//alert("success");

			$.each(makeDetailsArray, function (index, makeDetail) {

				var dateOfAdd = (new Date(makeDetail.dateAdded)).toLocaleDateString('en-US');

				var makeInfo = '<tr><td id="column1" style="width: 100px">' + makeDetail.vehicleMakeDescription + '</td>' +
					'<td id="column1" style="width: 100px">' + dateOfAdd + '</td>' +
					'<td id="column1" style="width: 200px">' + makeDetail.user.email + '</td></tr>';

				$("#makeInfoTable").append(makeInfo);
			});
		},
		error: function () {
			//alert("error");
		}
	});
}