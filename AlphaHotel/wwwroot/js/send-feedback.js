$('#send-feedback-form').on('submit', function (ev) {
    ev.preventDefault();

    var $this = $(this);

    var url = window.location.pathname;
    var id = url.substring(url.lastIndexOf('/') + 1);
    var attrUrl = $this.attr('action');

    var dataToSend = $this.serialize();
    dataToSend = dataToSend + '&BusinessId=' + id;

    var isValid = $this.valid();

    if (isValid) {
        $.post(attrUrl, dataToSend, function (response) {
            $(function () {
                $('#exampleModal').modal('toggle');

            });

        }).fail(function (error) {

        });
    }
    //else {
    //    toastr.fail(error);
    //}
});

$('#exampleModal').on('hidden.bs.modal', function (e) {
    $(this)
        .find("input,textarea,select")
        .val('')
        .end()
        .find("input[type=checkbox], input[type=radio]")
        .prop("checked", "")
        .end();
})