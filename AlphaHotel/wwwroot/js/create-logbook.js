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
    
    $.post(url, dataToSend, function (response) {
        toastr.success('Successful created logbook: ' + response.logBookName);
        $('#logBooks-list').append('<li class="list-group-item list-group-item-dark">' + response.logBookName + '</li>');
    }).fail(function (error) {
        toastr.error(error.responseText);
    });
});