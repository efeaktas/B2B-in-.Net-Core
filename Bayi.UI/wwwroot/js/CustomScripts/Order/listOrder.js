

$(document).ready(function () {
    $('#thUpdate').removeClass('sorting');
    $('#thUpdate').click(function () {
        $('#thUpdate').removeClass('sorting_asc').removeClass('sorting_desc');
    });

    $('#example1_wrapper > div:nth-child(1) > div:nth-child(1) > div > button.btn.btn-secondary.buttons-print > span').text('Yazdır');
    $('#example1_previous > a').text('Geri');
    $('#example1_next > a').text('İleri');

    $('#example1_wrapper > div:nth-child(1) > div:nth-child(1) > div > div').remove();
    $('#example1_wrapper > div:nth-child(1) > div:nth-child(1) > div > button.btn.btn-secondary.buttons-copy.buttons-html5').remove();
    $('#example1_wrapper > div:nth-child(1) > div:nth-child(1) > div > button.btn.btn-secondary.buttons-csv.buttons-html5').remove();
    $('#example1_info').remove();

    $('.isRead').click(function (e) {

        var value = $(e.delegateTarget).prop('checked');
        var id = $(e.delegateTarget).data('id');
        request = {};
        request.Value = value;
        request.Id = id;
        CallAjax('/Admin/Order/IsRead', request).done(function () {
            $.unblockUI();
            window.location.reload();
        });

    });

});