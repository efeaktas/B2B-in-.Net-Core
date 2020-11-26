$(document).ready(function () {
  
    $('#loginForm').submit(function (e) {
       
        e.preventDefault();
        var username = $('#txtEmail').val();
        var password = $('#txtPassword').val();
        var request = {};
        request.Username = username;
        request.Password = password;

        CallAjax('/Account/UserLogin', request).done(function (response) {
         
            $.unblockUI();
            if (response.number == 1) {
         
                window.location.href = '/Admin/Product/List';

            }
            if (response.number == 2) {
              
                window.location.href = '/Client/Product/StockStatus';

            }
            if (response.number == 3) {

              
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