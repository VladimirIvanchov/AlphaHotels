$('#logs-container').on('click', '.status-dropdown span', function (ev) {
    ev.stopPropagation();

    $(this).parent().click();
});

$('#logs-container').on('click', '.status-dropdown', function (ev) {
    ev.preventDefault();

    var $currentLink = $(ev.target);

    var url = $currentLink.parent().data('url');
    var $this = $(this);

    if ($this.children().last().children().length < 2) {
        $this.children().last().children().remove();

        $.get(url, function (data) {
            $this.children().last().append(data);
        });
    }
});

$('#logs-container').on('click', '.change-log-status', function (ev) {
    ev.preventDefault();

    var $currentLink = $(ev.target);
    var url = $currentLink[0].href;

    $.get(url, function (data) {
        if (data > 0) {
            Swal.fire({
                position: 'top-end',
                type: 'success',
                title: 'Successfully changed status!',
                showConfirmButton: false,
                timer: 1500
            })
        }
    });
});
