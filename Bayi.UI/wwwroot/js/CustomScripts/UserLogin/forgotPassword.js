$(document).ready(function () {
   
    $('#forgotPasswordForm').submit(function (e) {
     
        e.preventDefault();
      
        var email = $('#txtEmail').val();
        var request = {};
        request.Email = email;
       
        CallAjax('/Account/ForgotPassword', request).done(function (response) {
            $.unblockUI();
            if (response.number == 1) {
               
                $('#modalMessage').empty();
                $('#modalContent').addClass('modal-success');
                $('#modalMessage').append(response.message);
                $('#contactModal').modal({

                });
                $('#contactModal').on('hidden.bs.modal', function () {
                    window.location.href = '/';
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