//$('#logbook-btn').click(function (ev) {
//    ev.preventDefault();

//    var $this = $(this);

//    var url = window.location.pathname;
//    var businessId = url.substring(url.lastIndexOf('/') + 1);

//    var attrUrl = $this.attr('action');

//    var urlWithId = attrUrl + '/' + businessId;
//    $.get(urlWithId, function (data) {
//        $(data).add
//    });
//});

//$('#category-btn').click(function (ev) {
//    ev.preventDefault();

//    var $this = $(this);

//    var url = window.location.pathname;
//    var businessId = url.substring(url.lastIndexOf('/') + 1);

//    var attrUrl = $this.attr('action');

//    var urlWithId = attrUrl + '/' + businessId;
//    $.get(urlWithId, function (data) {
//        $(data).add
//    });
//});

//$('select').on('click', function (ev) {
//    ev.preventDefault();
    
//    var $currentLink = $(ev.target);

//    var url = $currentLink.parent().data('url');
//    var $this = $(this);

//    if ($this.children().last().children().length < 2) {
//        $this.children().last().children().remove();

//        $.get(url, function (data) {
//            $this.children().last().append(data);
//        });
//    }
//});

$('#modal-btn').on('click', function (ev) {

    var $this = $(this);

    var url = '/manager/logbook/getlogbooksandcategories';

    $.get(url, function (data) {
        $('#dropdown-partial').append(data);
    });
});
