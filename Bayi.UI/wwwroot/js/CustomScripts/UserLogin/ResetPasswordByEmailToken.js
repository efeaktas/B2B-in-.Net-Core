
    $(document).ready(function(){
        var $submitBtn = $("#btnSubmit");
        var $passwordBox = $("#txtPassword");
        var $confirmBox = $("#txtConfirmPassword");
        var insertAfter = $('#insertAfter')
        var $errorMsg = $('<span id="error_msg">Şifre Eşleşmiyor.</span>');
        // This is incase the user hits refresh - some browsers will maintain the disabled state of the button.
        $submitBtn.removeAttr("disabled");

        function checkMatchingPasswords(){
            if($confirmBox.val() != " && $passwordBox.val != "){
                if( $confirmBox.val() != $passwordBox.val() ){
        $submitBtn.attr("disabled", "disabled");
                    $errorMsg.insertAfter(insertAfter);
                }
            }
        }
        function resetPasswordError() {
            $submitBtn.removeAttr("disabled");
            var $errorCont = $("#error_msg");
            if ($errorCont.length > 0) {
                $errorCont.remove();
            }
        }
        $("#txtConfirmPassword, #txtPassword")
             .on("keydown", function(e){
                /* only check when the tab or enter keys are pressed
                 * to prevent the method from being called needlessly  */
                if(e.keyCode == 13 || e.keyCode == 9) {
        checkMatchingPasswords();
                }
             })
             .on("blur", function(){
        // also check when the element looses focus (clicks somewhere else)
        checkMatchingPasswords();
             }).on("focus", function () {
                 // reset the error message when they go to make a change
                 resetPasswordError();
             })
        $('#changePasswordForm').submit(function (e) {
            debugger;
            e.preventDefault();
            var Email = $('#txtEmail').val();
            var Token = $('#txtToken').val();

            var request = {};
            request.Email = Email;
            request.Token = Token;
            request.Password = $passwordBox.val();
            CallAjax(updatePasswordByEmail, request).done(function (response) {
                $.unblockUI();
                if (response.number == 1) {
                    
                    $('#modalMessage').empty();
                    $('#modalContent').addClass('modal-success');
                    $('#modalMessage').append(response.message);
                    $('#contactModal').modal();
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