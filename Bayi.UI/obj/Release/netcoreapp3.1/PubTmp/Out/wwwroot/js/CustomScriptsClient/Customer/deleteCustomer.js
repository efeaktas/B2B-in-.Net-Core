$(document).ready(function () {
    $('#confirm-delete').on('click', '.btn-ok', function (e) {
        e.preventDefault();
       
        var $modalDiv = $(e.delegateTarget);
        var id = $(this).data('recordId');
        var request = {};
        request.CustomerId = id;
        CallAjax(deleteCustomerUrl, request).done(function (response) {
            $.unblockUI();
            if (response.number == 1) {
                
                $('#modalMessage').empty();
                $('#modalContent').addClass('modal-success');
                $('#modalMessage').append(response.message);
                $('#contactModal').modal({

                });
                $('#contactModal').on('hidden.bs.modal', function () {
                    window.location.href = "/Client/Customer/List";
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
        $modalDiv.addClass('loading');
        setTimeout(function () {
            $modalDiv.modal('hide').removeClass('loading');
        }, 1000)

    });
    $('#confirm-delete').on('show.bs.modal', function (e) {

        var data = $(e.relatedTarget).data();

        $('.btn-ok', this).data('recordId', data.recordId);


    });


    // Bind to modal opening to set necessary data properties to be used to make request


});