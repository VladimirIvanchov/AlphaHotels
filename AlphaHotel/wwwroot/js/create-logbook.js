$('.business-for-logbook').on('click', function (ev) {
    var $currentLink = $(ev.target);
    var url = $currentLink.data('url');

    $.get(url, function (data) {
        $('#create-logbook-area').remove();
        $(data).insertAfter('#choose-location-for-logbook');
    });
});

$('#create-logbook-form').submit(function (ev) {
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
                title: 'Successful created logbook: ' + response.logBookName,
                showConfirmButton: false,
                timer: 1500
            })
            $('#logBooks-list').append('<li class="list-group-item list-group-item-dark">' + response.logBookName + '</li>');
        }).fail(function (error) {
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
    };
});