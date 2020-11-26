

$(document).ready(function () {
  
    var selected = $('#selectProduct').children("option:selected").data('stock');
    $('#txtProductStock').val(selected);
    $('#txtSaleQuantity').attr({
        "max": selected
    });
    $('#selectProduct').change(function () {

        var selected = $(this).children("option:selected").data('stock');
        $('#txtProductStock').val(selected);
        $('#txtSaleQuantity').attr({
            "max": selected
        });
    });
    $('#btnSubtract').click(function (e) {
        
       
        e.preventDefault();
        var selected = $('#selectProduct').children("option:selected").data('stock');
        var productId = $('#selectProduct').children("option:selected").data('id');
        var quantity = $('#txtQuantity').val();
        if (quantity > selected || quantity == "" || quantity<0) {
            $('#modalMessage').empty();
            $('#modalContent').addClass('modal-danger');
            $('#modalMessage').append('Çıkarılıcak Adet Tam Sayı ve Sıfırdan Büyük Olmak Zorundadır.Aynı Zamanda Mevcut Stok Adetinden Fazla Olamaz..');
            $('#contactModal').modal();
            $('#contactModal').on('hidden.bs.modal', function () {
                window.location.reload();
            });
        }
        else {
            var request = {};
            request.ProductId = productId;
            request.Quantity = quantity;
            CallAjax(subtractStockProductUrl, request).done(function (response) {
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
        }
 
    });
});