$(document).ready(function () {
    $('#dealerForm').submit(function (e) {
        e.preventDefault();
        var CompanyName = $('#txtCompanyName').val();
        var Authorized = $('#txtAuthorized').val();
        var Address = $('#txtAddress').val();
        var Phone = $('#txtPhone').val();
        var Email = $('#txtEmail').val();
        var CustomerId = $('#btnUpdate').data('id');
        var request = {};
        request.CompanyName = CompanyName;
        request.Authorized = Authorized;
        request.Address = Address;
        request.Phone = Phone;
        request.Email = Email;
        request.Id = CustomerId;
        CallAjax(updateCustomerUrl, request).done(function (response) {
            $.unblockUI();
            if (response.number == 1) {
                
                $('#modalMessage').empty();
                $('#modalContent').addClass('modal-success');
                $('#modalMessage').append(response.message);
                $('#contactModal').modal({

                });
                $('#contactModal').on('hidden.bs.modal', function () {
                    window.location.href = '/Client/Customer/List';
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