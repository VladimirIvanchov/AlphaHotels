$('#send-feedback-form').on('submit', function (ev) {
    ev.preventDefault();
    debugger;
    var $this = $(this);

    var url = window.location.pathname;
    var id = url.substring(url.lastIndexOf('/') + 1);
    var attrUrl = $this.attr('action');

    var dataToSend = $this.serialize();
    dataToSend = dataToSend + '&BusinessId=' + id;
    debugger;
    var isValid = $this.valid();

    if (isValid) {
        $.post(attrUrl, dataToSend, function (response) {
            debugger;
            $(function () {
                $('#exampleModal').modal('toggle');
            });

            if (response.author.length > 0) {
                Swal.fire({
                    position: 'top-end',
                    type: 'success',
                    title: response.author + ' ' + 'added a new comment!',
                    showConfirmButton: false,
                    timer: 1500
                })
            }
            else {
                Swal.fire({
                    position: 'top-end',
                    type: 'success',
                    title: 'A new comment was added!',
                    showConfirmButton: false,
                    timer: 1500
                })
            }
            debugger;
           
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
            text: 'Something went wrong!'
        })
    }
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