$(document).ready(function () {

 
    var unitPrice = $('#txtUnitSalePrice').val();
    var quantity = $('#txtSaleQuantity').val();
    var productStock=$('#txtProductStock').val();

    $('#txtTotalPrice').val(unitPrice * quantity);
    $('#txtSaleQuantity').attr({
        "max": productStock
    });


    //Satış Adeti Değiştiğinde Toplam Tutar Değişir
    $('#txtUnitSalePrice').on({
        change: function () {
            var unitPrice = $('#txtUnitSalePrice').val();
            var quantity = $('#txtSaleQuantity').val();
            $('#txtTotalPrice').val(unitPrice * quantity);
        },
        keyup: function () {
            var unitPrice = $('#txtUnitSalePrice').val();
            var quantity = $('#txtSaleQuantity').val();
            $('#txtTotalPrice').val(unitPrice * quantity);
        }
    });

    //Satış Fiyatı Değiştiğinde Toplam Tutar Değişir
    $('#txtSaleQuantity').on({
        change: function () {
            var unitPrice = $('#txtUnitSalePrice').val();
            var quantity = $('#txtSaleQuantity').val();
            $('#txtTotalPrice').val(unitPrice * quantity);
        },
        keyup: function () {
            var unitPrice = $('#txtUnitSalePrice').val();
            var quantity = $('#txtSaleQuantity').val();
            $('#txtTotalPrice').val(unitPrice * quantity);
        }
    });

    $('#saleForm').submit(function (e) {
      
        e.preventDefault();
        var quantity = $('#txtSaleQuantity').val();
        var salePrice = $('#txtUnitSalePrice').val();
        var id = $('#btnUpdate').data('id');
        var request = {};

        request.Id = id;
        request.Quantity = quantity;
        request.SalePrice = salePrice;


        CallAjax(updateSaleUrl, request).done(function (response) {
            $.unblockUI();
            if (response.number == 1) {
              
                $('#modalMessage').empty();
                $('#modalContent').addClass('modal-success');
                $('#modalMessage').append(response.message);
                $('#contactModal').modal({

                });
                $('#contactModal').on('hidden.bs.modal', function () {
                    window.location.href = '/Admin/Sale/List';
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