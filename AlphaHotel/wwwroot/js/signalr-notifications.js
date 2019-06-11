var connection = new signalR.HubConnectionBuilder().withUrl("/alllogbooklogs").build();

connection.start().catch(function (err) {
    return console.error(err.toString());
});

connection.on("NewLog", function (log) {
    var newLog =
        `<div class="container-logs">
        <div class="">${log.authorUsername}</div>
        <div class=""><em>${log.description}</em></div>
        <div class="">Just now!</div>
        <div class="">${log.category}</div>
        <div></div>
        <div class="status-div" data-url="/manager/logbook/ShowStatusesOtherThanLogs/${log.id}">
            <select class="status-dropdown nice-select" data-url="/manager/logbook/ShowStatusesOtherThanLogs/${log.id}">
                <option value=${log.status}>${log.status}</option>
            </select>
    </div>
    </div >
        <hr />`
    $('#all-logs').prepend(newLog);
});

connection.on("SendNotification", function () {
    Swal.fire({
        title: 'New log added!',
        type: 'info',
        animation: false,
        customClass: {
            popup: 'animated tada'
        }
    })
});

function sendToAllManagers(log) {
    connection.invoke("Send", log);
};