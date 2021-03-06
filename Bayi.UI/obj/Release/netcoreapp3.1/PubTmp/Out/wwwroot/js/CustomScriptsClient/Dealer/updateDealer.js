﻿

$(document).ready(function () {
    $('#updateDealerForm').submit(function (e) {
       
        e.preventDefault();
        var CompanyName = $('#txtCompanyName').val();
        var Authorized = $('#txtAuthorized').val();
        var Address = $('#txtAddress').val();
        var Phone = $('#txtPhone').val();
        var Email = $('#txtEmail').val();
        var request = {};
        request.CompanyName = CompanyName;
        request.Authorized = Authorized;
        request.Address = Address;
        request.Phone = Phone;
        request.Email = Email;

        CallAjax(updateDealerUrl, request).done(function (response) {
            $.unblockUI();
            if (response.number == 1) {
                
                $('#modalMessage').empty();
                $('#modalContent').addClass('modal-success');
                $('#modalMessage').append(response.message);
                $('#contactModal').modal({


                });
                $('#contactModal').on('hidden.bs.modal', function () {
                    window.location.href = '/Client/Product/StockStatus';
                });


            }
            if (response.number == 2) {


                $('#modalMessage').empty();
                $('#modalContent').addClass('modal-danger');
                $('#modalMessage').append(response.message);
                $('#contactModal').modal({

                });
                $('#contactModal').on('hidden.bs.modal', function () {
                    window.location.reload();
                });

            }

        });
    });
});