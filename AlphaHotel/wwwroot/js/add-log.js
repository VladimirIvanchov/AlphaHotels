$('#add-log-btn').on('click', function (ev) {
    var url = '/manager/logbook/getlogbooksandcategories';

    $.get(url, function (data) {
        $('#dropdown-partial').append(data);
        $('#add-log-btn').off();
    });
});

$('#add-log-form').on('submit', function (ev) {
    ev.preventDefault();

    var $this = $(this);
    var url = $this.attr('action');

    var dataToSend = $this.serialize();

    var isValid = $this.valid();

    if (isValid) {
        $.post(url, dataToSend, function (response) {
            sendToAllManagers(response);
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
    }
});
