$('#search-hotel-id').on('click', function (ev) {
    ev.preventDefault();

    var input = $('#myInput')[0].data;
    debugger;
    if (input) {
        window.location.href = '/business/details/' + input;
    }
    else {
        debugger;
        Swal.fire({
            type: 'warning',
            title: 'Oops...',
            text: 'Such a hotel do not exist!'
        })
    }
});