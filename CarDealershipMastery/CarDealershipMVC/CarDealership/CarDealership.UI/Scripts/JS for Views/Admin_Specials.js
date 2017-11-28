$(document).ready(function () {
	loadSpecials();
});

function loadSpecials() {
	$.ajax({
		type: "GET",
		url: "http://localhost:59129/specials",
		success: function (specialArray) {
			alert("success")

			listOfSpecials = $("#listOfSpecials");

			$.each(specialArray, function (index, special) {

				var specialInfo = '<div class="col-md-12" style="border: 2px solid black; margin: 10px"><div class="col-md-2"><div class="searchResultsNewVehicles">' +
					'<h3><img src="../Images/dollarsign.png" id="dollarSignPicture" /></h3></div></div>' +
					'<div class="col-md-10"><div class="searchResultsNewVehicles">' +
					'<h3>' + special.specialTitle + '</h3>' +
					'<p>' + special.specialDescription + '</p>' +
					'<p align="right">' + '<button class="btn btn-danger" id="deleteSpecial">Delete</button>' + '</p>' +
					'</div ></div ></div >' +
					'<div class="col-md-12"></div>';

				listOfSpecials.append(specialInfo);

			});
		},
		error: function () {

		}
	});
}





