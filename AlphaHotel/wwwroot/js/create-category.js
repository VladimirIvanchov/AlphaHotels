$('#create-category-form').submit(function (ev) {
    ev.preventDefault();

    var $this = $(this);
    var url = $this.attr('action');

    var dataToSend = $this.serialize();

    $.post(url, dataToSend, function (response) {
        toastr.success('Successful created category: ' + response.categoryName);
        $('#logBooks-list').append('<li class="list-group-item list-group-item-dark">' + response.categoryName + '</li>');
    }).fail(function (error) {
        toastr.error(error.responseText);
    });
});