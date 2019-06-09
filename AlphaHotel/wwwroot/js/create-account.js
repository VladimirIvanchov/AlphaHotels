$('#moderator , #manager').on('click', function (ev) {
    var $currentLink = $(ev.target);
    var url = $currentLink.data('url'); 

    $('#logbook-area').remove();

    if (!$('#admin-dynamic').length) {
        $.get(url, function (data) {
            $(data).insertBefore('#register-btn');
        });
    }
});

$('#register-area').on('click', '.business-name', function (ev) {
    var $currentLink = $(ev.target);
    var url = $currentLink.data('url');

    if ($('#manager').is(':checked')) {
        $.get(url, function (data) {
            $('#logbook-area').remove();
            $(data).insertBefore('#register-btn');
        });
    }
});

$('#administrator').on('click', function (ev) {
    $('#logbook-area').remove();
    $('#admin-dynamic').remove();
});

$('#registerForm').submit(function (ev) {
    ev.preventDefault();
    debugger;
    var $this = $(this);
    var url = $this.attr('action');

    var dataToSend = $this.serialize();
   
    var isValid = $this.valid();

    if (isValid) {
        $.post(url, dataToSend, function (response) {
            Swal.fire({
                position: 'top-end',
                type: 'success',
                title: 'Successfully created account: ' + response.userName,
                showConfirmButton: false,
                timer: 1500
            })
        }).fail(function (error) {
            debugger;
            Swal.fire({
                type: 'error',
                title: 'Oops...',
                text: error.responseText /*error.responseJSON.value.errors[0].errors[0].errorMessage*/
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