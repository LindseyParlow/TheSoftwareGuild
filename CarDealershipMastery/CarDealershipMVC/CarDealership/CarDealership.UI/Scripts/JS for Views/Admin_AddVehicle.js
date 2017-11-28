$(document).ready(function () {
	makeAndModelDropdown();
	deleteVehicle();
	confirmDelete();
	cancelDelete();
});

function makeAndModelDropdown() {
	$('#makeDropdown').change(function () {
		$("#modelDropdown").empty();
		$.ajax({
			type: "POST",
			url: "/Admin/GetModelsByMake",
			data: { makeId: $('#makeDropdown').val() },
			datatype: "json",
			success: function (data) {
				//alert("success");

				$.each(data, function (index, model) {

					var modelOption = '<option value="' + model.VehicleModelId + '">' + model.VehicleModelDescription + '</option>'

					$("#modelDropdown").append(modelOption);
				})
			}
		});
	});
}
function deleteVehicle() {
	$("#deleteVehicleButton").on("click", function () {
		$("#editFormSection").hide();
		$("#deleteVehicleSection").show();
	})
}

function confirmDelete() {
	$("#deleteButton").on("click", function () {
		var vehicleId = $("#vehicleId").val();
		$.ajax({
			type: "DELETE",
			url: "http://localhost:59129/vehicle/" + vehicleId + "/delete",
			success: function () {
				alert("Vehicle has been deleted.")
				window.location.href = "http://localhost:59129/Admin/Index";
			},
			error: function () {
				alert("error")
			}
		})
	})
}

function cancelDelete() {
	$("#cancelButton").on("click", function () {
		var vehicleId = $("#vehicleId").val();
		window.location = "";
	})
}
		