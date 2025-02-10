$(document).ready(function () {
    $('.add-to-wishlist-form').submit(function (event) {
        event.preventDefault();
        var form = $(this);
        $.ajax({
            type: form.attr('method'),
            url: form.attr('action'),
            data: form.serialize(),
            success: function (response) {
                alert('Produkt został dodany do listy życzeń!');
            },
            error: function (response) {
                alert('Wystąpił błąd podczas dodawania produktu do listy życzeń.');
            }
        });
    });
});


$(document).ready(function () {
    $('.remove-from-wishlist-form').submit(function (event) {
        event.preventDefault();
        var form = $(this);
        var productId = form.find('input[name="productId"]').val();
        $.ajax({
            type: form.attr('method'),
            data: form.serialize(),
            success: function (response) {
                if (response.success) {
                    $('#product-' + productId).remove();
                    dataTable.ajax.reload();
                    toastr.success(data.message);
                } else {
                    alert('Wystąpił błąd podczas usuwania produktu z listy życzeń.');
                }
            },
            error: function (response) {
                alert('Wystąpił błąd podczas usuwania produktu z listy życzeń.');
            }
        });
    });
});
