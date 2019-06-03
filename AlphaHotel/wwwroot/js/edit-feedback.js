﻿$('#edit-feedback').submit(function (ev) {
    ev.preventDefault();

    var $this = $(this);
    var url = $this.attr('action');

    var dataToSend = $this.serialize();

    var isValid = $this.valid();
    debugger;
    if (isValid) {
        debugger;
        $.post(url, dataToSend, function (response) {
            Swal.fire({
                position: 'top-end',
                type: 'success',
                title: 'Successfully edited feedback',
                showConfirmButton: false,
                timer: 1500
            })
        }).fail(function (error) {
            Swal.fire({
                type: 'error',
                title: 'Oops...',
                text: error.responseText
            })
        });
    }
    else {
        debugger;
        Swal.fire({
            type: 'error',
            title: 'Oops...',
            text: 'Invalid parameters!'
        })
    }
});