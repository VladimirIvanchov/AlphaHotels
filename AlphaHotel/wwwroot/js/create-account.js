$('#moderator , #manager').on('click', function (ev) {
    var $currentLink = $(ev.target);
    var url =   

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
            Swal.fire({
                type: 'error',
                title: 'Oops...',
                text: error.responseJSON.value.errors[0].errors[0].errorMessage
            })
        });
    }
    else {
        for (var i = 0; i < response.errors.length; i++) {
            var error = ko.mapping.fromJS(response.errors[i]);
            self.saveErrors.push(error);
        }

        Swal.fire({
            type: 'error',
            title: 'Oops...',
            text: error
        })
    }
});