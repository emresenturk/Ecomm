$("#ShowNextListingPage").click(function() {
    var currentPage = $("#CurrentPage").val();
    currentPage = 1 + parseInt(currentPage);
    $("#CurrentPage").val(currentPage);
    $.ajax({
        url: "/Listing/Products",
        data: { page:  currentPage},
        type: "GET",
        async: true,
        cache: false
    }).done(function(response) {
        $("#Products li:not(#ProductTemplate)").remove();
        $("#Products").append(response);
        initListingCartButton();
        if (currentPage > 1) {
            $("#ShowPreviousListingPage").show();
        }
    });
});

$("#ShowPreviousListingPage").click(function () {
    var currentPage = $("#CurrentPage").val();
    currentPage = -1 + parseInt(currentPage);
    $("#CurrentPage").val(currentPage);
    $.ajax({
        url: "/Listing/Products",
        data: { page: currentPage },
        type: "GET",
        async: true,
        cache: false
    }).done(function (response) {
        $("#Products li:not(#ProductTemplate)").remove();
        $("#Products").append(response);
        initListingCartButton();
        if (currentPage === 1) {
            $("#ShowPreviousListingPage").hide();
        }
    });

});