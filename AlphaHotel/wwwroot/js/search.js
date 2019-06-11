//var time;

$("#search-keyword-log").keyup(function (ev) {
    ev.preventDefault();
    var $keyword = $("#search-keyword-log").val();
    //var currTime = Date.now();

    if ($keyword.length !== 1 /*&& currTime - time > 300*/) {
        var url = "/manager/logbook/findlog?keyword=" + $keyword;

        $.get(url, function (data) {
            $("#all-logs").empty(".container-logs");

            //$("#all-logs").html(data);
            $("#all-logs").append(data);
        });
    }
    //time = currTime;
});
