$(document).ready(function () {

    
    $('#orderForm').submit(function (e) {
        
        e.preventDefault();
        var productId = $('#selectProduct').children("option:selected").data('id');
        var quantity = $('#txtProductStock').val();
        var statement = $('#txtStatement').val();
        var saleTime = new Date();
        saleTime = saleTime.toLocaleDateString('zh-Hans-CN');  

        var request = {};
        request.ProductId = productId;
        request.Quantity = quantity;
        request.Statement = statement;
        request.SaleTime = saleTime;


        CallAjax(createOrderUrl, request).done(function (response) {
            $.unblockUI();
            if (response.number == 1) {
               
                $('#modalMessage').empty();
                $('#modalContent').addClass('modal-success');
                $('#modalMessage').append(response.message);
                $('#contactModal').modal({

                });
                $('#contactModal').on('hidden.bs.modal', function () {
                    window.location.href = '/Client/Order/List';
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