$(document).ready(function () {
    loadItems();
    addMoneyToMachine();
    selectItemFromMachine();
    puchaseSelectedItem();
    returnChangeAndReset();
});

function loadItems() {
    $.ajax({
        type: "GET",
        url: "http://localhost:8080/items",
        success: function(itemArray) {
            var vendingChoices = $("#vendingChoices");
            $.each(itemArray, function(index, item) {
                
                var itemInfo = '<div class="col-md-3 itemToGrab" data-id="'+item.id + '"><p>' + item.id + "</p>" +
                                "<p>" + item.name + "</p>"  + 
                                "<p>" + item.price.toFixed(2) + "</p>" + 
                                "<br/>" + 
                                "<p>" + "Quantity Left: " + item.quantity + "</p></div";

                vendingChoices.append(itemInfo)
            });
            
            
        },
        error: function () {

        }
    });
}

function addMoneyToMachine() {
    var totalCost = 0;
        $("#addDollar").on("click", function () {
            totalCost = (Number(totalCost) + Number(1));
            $("#totalIn").val(totalCost.toFixed(2));
        })
        $("#addQuarter").on("click", function () {
            totalCost = Number(totalCost) + Number(.25);
            $("#totalIn").val(totalCost.toFixed(2));
        })
        $("#addDime").on("click", function () {
            totalCost = Number(totalCost) + Number(.10);
            $("#totalIn").val(totalCost.toFixed(2));
        })
        $("#addNickel").on("click", function () {
            totalCost = Number(totalCost) + Number(.05);
            $("#totalIn").val(totalCost.toFixed(2));
        })
}

function selectItemFromMachine() {
    $("#vendingChoices").on("click", ".itemToGrab", function () {
        var id = $(this).data("id");
        $("#desiredItem").val(id);
    });
}

function puchaseSelectedItem() {
    $("#makePurchase").on("click", function () {
        var amount = $("#totalIn").val()
        var id = $("#desiredItem").val();
        $.ajax({
            type: "GET",
            url: "http://localhost:8080/money/" + amount + "/item/" + id,
            success: function(change) {;
                
                var itemVendResponse = "Thank you!!!" 
                
                var itemVendChange = change.quarters + " quarters, " + change.dimes + " dimes, " + change.nickels + " nickels";
                
                $("#messages").val(itemVendResponse);
                $("#change").val(itemVendChange);
                $("#totalIn").val(0);
                addMoneyToMachine();
                $("#vendingChoices").empty();
                loadItems();
            },
            error: function (xhr) {
                if(id<1){
                    var error = "Please select an item!";
                }
                else{
                    var error = xhr.responseJSON.message;
                    
                }
                
                $("#messages").val(error)
            }
        });
    })
}

function returnChangeAndReset() {
    $("#changeReturn").on("click", function() {
        $("#messages").val("");
        $("#desiredItem").val("");
        $("#change").val("");
    })
}

