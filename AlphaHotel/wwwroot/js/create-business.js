$('#create-business').submit(function (ev) {
    ev.preventDefault();
    debugger;
    var $this = $(this);
    var url = $this.attr('action');
    var dataToSend = new FormData($this.get(0));
    //var dataToSend = $this.serialize();
    debugger;
    var isValid = $this.valid();
    if (isValid) {
        $.post(url, dataToSend, function (response) {
            debugger;
            Swal.fire({
                position: 'top-end',
                type: 'success',
                title: 'Successfully created business' + response.name,
                showConfirmButton: false,
                timer: 1500
            })
        }).fail(function (error) {
            debugger;
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

    //var $this = $(this);
    //var url = $this.attr('action');
    //var fdata = new FormData();

    //var fileInput = $('#CoverPicture')[0];
    //var file = fileInput.files[0];
    //fdata.append("File", file);

    //// You can update the jquery selector to use a css class if you want
    //$("input[type='text'").each(function (x, y) {
    //    fdata.append($(y).name, $(y).val());
    //    debugger;
    //});

    //$.ajax({
    //    type: 'post',
    //    url: url,
    //    data: fdata,
    //    processData: false,
    //    contentType: false
    //}).done(function (response) {
    //    Swal.fire({
    //        position: 'top-end',
    //        type: 'success',
    //        title: 'Successfully created business' + response.name,
    //        showConfirmButton: false,
    //        timer: 1500
    //    })
    //}).fail(function (error) {
    //    Swal.fire({
    //        type: 'error',
    //        title: 'Oops...',
    //        text: error.responseText
    //    })
    //});
