$(document).ready(function () {

    $('#changePasswordForm').submit(function (e) {
        e.preventDefault();
        var txtOldPassword = $('#txtOldPassword').val();
        var txtNewPassword = $('#txtNewPassword').val();
        var request = {};
        request.CurrentPassword = txtOldPassword;
        request.NewPassword = txtNewPassword;

        CallAjax(updatePasswordUrl, request).done(function (response) {
            $.unblockUI();
            if (response.number == 1) {

                $('#modalMessage').empty();
                $('#modalContent').addClass('modal-success');
                $('#modalMessage').append(response.message);
                $('#contactModal').modal();
                $('#contactModal').on('hidden.bs.modal', function () {
                    window.location.href = '/client/Product/stockstatus';
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


