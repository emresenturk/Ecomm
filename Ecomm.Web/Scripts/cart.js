var refreshCartSummary = function() {
    $.ajax({
        url: "/Cart/CartSummary",
        type: "GET",
        async: true,
        cache: false
    }).done(function(response) {
        $("#CartSummaryContainer a").remove();
        $("#CartSummaryContainer").append(response);
    });
};

var initListingCartButton = function () {
    $("button[name='AddToCart']").click(function() {
        var erpCode = $(this).val();
        var quantity = 1;
        var request = {
            erpCode: erpCode,
            quantity: quantity
        };

        $.ajax({
            url: "/Cart/AddToCart",
            type: "POST",
            data: request,
            async: true,
            cache: false
        }).done(function() {
            
        });
    });
};

var initRemoveFromCartButton = function() {
    $("button[name='RemoveFromCart']").click(function () {
        var id = $(this).val();
        var quantity = 0;
        var request = { id: id, newQuantity: quantity };

        $.ajax({
            url: "/Cart/UpdateCartQuantity",
            data: request,
            type: "POST", // This should be PUT but that requires chaning settings in IIS, and not everyone is willing to do that,
            async: true,
            cache: false
        }).done(function() {
            $.ajax({
                url: "/Cart/CartContents",
                type: "GET",
                async: true,
                cache: false
            }).done(function(response) {
                $("#CartContentsContainer").empty();
                $("#CartContentsContainer").append(response);
                initRemoveFromCartButton();
            });
            refreshCartSummary();
        });
    });
}

initListingCartButton();