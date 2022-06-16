
function ShowMessage(message, type) {
    if (type == "s") {
        swal({
            title: 'Ýþlem Baþarýlý',
            text: message,
            type: 'success',
            showCancelButtonClass: 'btn-success',
            confirmButtonText: 'Tamam'
        });
    }
    else {
        swal({
            title: 'Ýþlem Baþarýsýz',
            text: message,
            type: 'error',
            showCancelButtonClass: 'btn-danger',
            confirmButtonText: 'Tamam'
        });
    }
}
