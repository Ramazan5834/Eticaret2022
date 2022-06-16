
function ShowMessage(message, type) {
    if (type == "s") {
        swal({
            title: '��lem Ba�ar�l�',
            text: message,
            type: 'success',
            showCancelButtonClass: 'btn-success',
            confirmButtonText: 'Tamam'
        });
    }
    else {
        swal({
            title: '��lem Ba�ar�s�z',
            text: message,
            type: 'error',
            showCancelButtonClass: 'btn-danger',
            confirmButtonText: 'Tamam'
        });
    }
}
