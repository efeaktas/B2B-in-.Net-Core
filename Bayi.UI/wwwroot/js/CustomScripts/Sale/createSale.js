$(document).ready(function () {

    $('#txtUnitSalePrice').priceFormat({
        prefix: '',
        suffix: '₺'
    });
    var selectedPrice = $('#selectProduct').children("option:selected").data('price');
    var selected = $('#selectProduct').children("option:selected").data('stock');
    var unitPrice = $('#txtUnitSalePrice').val();
    var quantity = $('#txtSaleQuantity').val();
    $('#txtProductStock').val(selected);
    $('#txtUnitSalePrice').val(selectedPrice);

    $('#txtTotalPrice').val(unitPrice * quantity);
    $('#txtSaleQuantity').attr({
        "max": selected
    });


    //Satış Adeti Değiştiğinde Toplam Tutar Değişir
    $('#txtUnitSalePrice').on({
        change: function () {

            var unitPrice = $('#txtUnitSalePrice').val();
            //numeral sayıdaki . ve virgülleri attı çarpma işlemi için
            unitPrice = numeral(unitPrice).value();
            var quantity = $('#txtSaleQuantity').val();
            var totalPrice = unitPrice * quantity;
            //totalPrice'ı tekrardan formatladım ekrana yansıtırken
            var totalPrice = numeral(totalPrice).format('0, 0[.]00 $');
            $('#txtTotalPrice').val(totalPrice.replace('$', '₺'));
        },
        keyup: function () {

            var unitPrice = $('#txtUnitSalePrice').val();
            unitPrice = numeral(unitPrice).value();
            var quantity = $('#txtSaleQuantity').val();
            var totalPrice = unitPrice * quantity;
            var totalPrice = numeral(totalPrice).format('0, 0[.]00 $');
            $('#txtTotalPrice').val(totalPrice.replace('$', '₺'));
        }
    });

    //Satış Fiyatı Değiştiğinde Toplam Tutar Değişir
    $('#txtSaleQuantity').on({
        change: function () {

            var unitPrice = $('#txtUnitSalePrice').val();
            unitPrice = numeral(unitPrice).value();
            var quantity = $('#txtSaleQuantity').val();
            var totalPrice = unitPrice * quantity;
            var totalPrice = numeral(totalPrice).format('0, 0[.]00 $');
            $('#txtTotalPrice').val(totalPrice.replace('$', '₺'));
        },
        keyup: function () {

            var unitPrice = $('#txtUnitSalePrice').val();
            unitPrice = numeral(unitPrice).value();
            var quantity = $('#txtSaleQuantity').val();
            var totalPrice = unitPrice * quantity;
            var totalPrice = numeral(totalPrice).format('0, 0[.]00 $');
            $('#txtTotalPrice').val(totalPrice.replace('$', '₺'));
        }
    });

    $('#selectProduct').change(function () {

        var selectedPrice = $('#selectProduct').children("option:selected").data('price');
        var selected = $(this).children("option:selected").data('stock');
        $('#txtProductStock').val(selected);
        $('#txtSaleQuantity').attr({
            "max": selected
        });
        $('#txtUnitSalePrice').val(selectedPrice);
        var unitPrice = $('#txtUnitSalePrice').val();
        unitPrice = numeral(unitPrice).value();
        var quantity = $('#txtSaleQuantity').val();
        var totalPrice = unitPrice * quantity;
        var totalPrice = numeral(totalPrice).format('0, 0[.]00 $');
        $('#txtTotalPrice').val(totalPrice.replace('$', '₺'));

    });
    $('#saleForm').submit(function (e) {

        e.preventDefault();
        var productId = $('#selectProduct').children("option:selected").data('id');
        var dealerId = $('#selectDealer').children("option:selected").data('id');
        var quantity = $('#txtSaleQuantity').val();
        var salePrice = $('#txtUnitSalePrice').val();
        salePrice = salePrice.replace('₺', '');
        var saleTime = new Date();
        saleTime = saleTime.toLocaleDateString('zh-Hans-CN');
        var request = {};
        request.ProductId = productId;
        request.DealerId = dealerId;
        request.Quantity = quantity;
        request.SaleTime = saleTime;
        request.SalePrice = salePrice;


        CallAjax(createSaleUrl, request).done(function (response) {
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