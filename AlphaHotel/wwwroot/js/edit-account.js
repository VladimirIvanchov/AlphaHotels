$('#edit-account').submit(function (ev) {
    ev.preventDefault();

    var $this = $(this);
    var url = $this.attr('action');

    var dataToSend = $this.serialize();

    var isValid = $this.valid();
    debugger;
    if (isValid) {
        $.post(url, dataToSend, function (response) {
            debugger;
            Swal.fire({
                position: 'top-end',
                type: 'success',
                title: 'Successful edited account: ' + response.userName,
                showConfirmButton: false,
                timer: 1500
            })
        }).fail(function (error) {
            debugger;
            Swal.fire({
                type: 'error',
                title: 'Oops...',
                text: error.responseText
            })
        });
    }
    else {
        Swal.fire({
            type: 'error',
            title: 'Oops...',
            text: 'Invalid parameters!'
        })
    }
});