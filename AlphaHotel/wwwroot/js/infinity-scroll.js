$(document).on('show.bs.modal', '#exampleModalLong', function (event) {
    $('.modal-body').scroll(function () {
        if ($(this).scrollTop() + $(this).innerHeight() >= $(this)[0].scrollHeight) {
            var currUrl = window.location.pathname;
            var id = currUrl.substring(currUrl.lastIndexOf('/') + 1);

            var url = '/feedback/listadditionalfeedbacksforscroll';

            var pageNumber = Math.ceil(($('#show-feedback-body').children().length / 10) + 1);
            
            $.get(url, { businessId: id, pageNumber: pageNumber }, function (data) {
                $('#show-feedback-body').append(data)
            });
        }
    });
});

$('#all-feedbacks-btn').on('click', function (ev) {
    var currUrl = window.location.pathname;
    var id = currUrl.substring(currUrl.lastIndexOf('/') + 1);

    var $currentLink = $(ev.target);
    var url = $currentLink.data('url');

    var pageNumber = $('#show-feedback-body').length + 1;

    $.get(url, { businessId: id, pageNumber: pageNumber }, function (data) {
        $('#all-feedback').append(data)
        $('#exampleModalLong').modal('show');
    });

    $('#all-feedbacks-btn').off();
});