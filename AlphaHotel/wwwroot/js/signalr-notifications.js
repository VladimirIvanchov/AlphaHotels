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
            <select class="status-dropdown nice-select" id="dropdown-logbook-status" data-url="/manager/logbook/ShowStatusesOtherThanLogs/${log.id}" style="display: none;">
                <option value=${log.status}>${log.status}</option>
            </select>
            <div class="nice-select status-dropdown" tabindex="0">
                <span class="current">${log.status}</span>
                <ul class="list">
                    <li data-value="${log.status}" class="option selected">
                        ${log.status}
                    </li>
                </ul>
            </div>
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