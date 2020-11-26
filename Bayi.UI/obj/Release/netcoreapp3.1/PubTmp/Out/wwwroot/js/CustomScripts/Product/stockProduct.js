$(document).ready(function () {
    $('#stockForm').submit(function (e) {
        
        e.preventDefault();
        var productId = $('#selectProduct').children("option:selected").data('id');
        var quantity = $('#txtQuantity').val();
        var request = {};
        request.ProductId = productId;
        request.Quantity = quantity;
        CallAjax(stockProductUrl, request).done(function (response) {
            $.unblockUI();
            if (response.number == 1) {
               
                $('#modalMessage').empty();
                $('#modalContent').addClass('modal-success');
                $('#modalMessage').append(response.message);
                $('#contactModal').modal({

                });
                $('#contactModal').on('hidden.bs.modal', function () {
                    window.location.href = '/Admin/Product/List';
                });

            }
            if (response.number == 2) {

                $('#modalMessage').empty();
                $('#modalContent').addClass('modal-danger');
                $('#modalMessage').append(response.message);
                $('#contactModal').modal();
                $('#contactModal').on('hidden.bs.modal', function () {
                    window.location.reload();
                });
            }
        });
    });
});