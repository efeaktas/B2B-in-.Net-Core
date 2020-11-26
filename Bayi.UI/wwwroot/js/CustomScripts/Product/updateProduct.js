$(document).ready(function () {
    $('#txtBuyingPrice').priceFormat({
        prefix: '',
        suffix: '₺'
    });
    $('#txtSalePrice').priceFormat({
        prefix: '',
        suffix: '₺'
    });
    $('#productForm').submit(function (e) {
    
        e.preventDefault();
        var ProductName = $('#txtProductName').val();
        var BuyingPrice = $('#txtBuyingPrice').val();
        var SalePrice = $('#txtSalePrice').val();
        var Id = $('#btnUpdate').data('id');
        var request = {};
        SalePrice = SalePrice.replace('₺', '');
        BuyingPrice = BuyingPrice.replace('₺', '');
        request.ProductName = ProductName;
        request.Id = Id;
        request.BuyingPrice = BuyingPrice;
        request.SalePrice = SalePrice;

        CallAjax(updateProductUrl, request).done(function (response) {
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