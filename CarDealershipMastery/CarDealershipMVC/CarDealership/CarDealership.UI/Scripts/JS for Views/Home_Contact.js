$(document).ready(function () {
	getDealershipPhoneNumbers();
});

function getDealershipPhoneNumbers() {
	$.ajax({
		type: "GET",
		url: "http://localhost:59129/dealership/phoneNumbers",
		success: function (phoneArray) {
			//alert("success")

			var dealershipPhones = $("#dealershipPhones");

			$.each(phoneArray, function (index, phone) {

				var phoneList = phone.phoneType + ": " + phone.phoneNumber + '<br/>';

				dealershipPhones.append(phoneList);
			})
		},
		error: function () {
			//alert("error")
		}
	})

}