

$(document).ready(function () {
    $('#txtBuyingPrice').priceFormat({
        prefix: '',
        suffix: '₺'
    });
    $('#txtSalePrice').priceFormat({
        prefix: '',
        suffix: '₺'
    });
    $('#createProductForm').submit(function (e) {
        
        e.preventDefault();
        var ProductName = $('#txtProductName').val();
        var Quantity = $('#txtQuantity').val();
        var SalePrice = $('#txtSalePrice').val();
        var BuyingPrice = $('#txtBuyingPrice').val();
        var request = {};
        SalePrice = SalePrice.replace('₺', '');
        BuyingPrice = BuyingPrice.replace('₺', '');
        request.ProductName = ProductName;
        request.Quantity = Quantity;
        request.SalePrice = SalePrice;
        request.BuyingPrice = BuyingPrice;


        CallAjax(createProductUrl, request).done(function (response) {
            $.unblockUI();
            if (response.number == 1) {
                debugger;
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