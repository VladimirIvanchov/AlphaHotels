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
