// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(function () {
    $('select').select2({
        width:"100%"
    });
  //  $('select').selectize();
});



//$('select').chosen();
function msgOperationSucceded(msg) {


    document.querySelector('.modal .modal-body p').innerHTML = msg;

    if (document.getElementById('master-html').dir == 'rtl') {
        document.querySelector('.modal .modal-header .modal-title').innerHTML = "نجاح";
    }
    else {
        document.querySelector('.modal .modal-header .modal-title').innerHTML = "Succecfully";
    }
}
$(function () {
    if (document.getElementById('msgOperationSucced') != null) {
        let msgOperaionSucceded = document.getElementById('msgOperationSucced').value;
        if (msgOperaionSucceded != "") {

            msgOperationSucceded(msgOperaionSucceded);
            document.querySelector('.modal').style.display = 'block';
        }
    }   


    $('.btn-delete').click(function () {
        $('#ConfirmDelete').show();
        if (document.getElementById('master-html').dir == 'rtl') {
            $('#ConfirmDelete .modal-body p').html('هل تريد الحذف');
        }
        else {
            $('#ConfirmDelete .modal-body p').html('Do You Want To Delete');
        }
    });
    $('#ConfirmDelete .btn-close').click(function () {
        $('#ConfirmDelete').hide();
    });
    $('#ConfirmDelete .btn-dicline').click(function () {
        $('#ConfirmDelete').hide()
    });
});

function msgCannotDeleteField() {
    if (document.getElementById('master-html').dir == 'rtl') {
        document.querySelector('.modal .modal-body p').innerHTML = "لا يمكن حذف هذا الحقل";
    }
    else {
        document.querySelector('.modal .modal-body p').innerHTML = "This Field Cannot Be Deleted";
    }
}
