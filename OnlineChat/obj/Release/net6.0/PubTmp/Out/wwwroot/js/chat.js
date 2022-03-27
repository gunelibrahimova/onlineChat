"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();
var userId;

document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message, myId) {

    if (userId == myId) {
        $('#chat-list').append(`
        <li>
           
            <div class="message my-message">
                `+ message + `
            </div>
        </li>
    `);
        scrollToBottom();
    }
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

$("#sendButton").on("click", function () {
    var message = $("#messageInput").val();
    
    var myId = $("#myId").val();
    if (message.trim().length == 0) {
        return;
    }
    $('#chat-list').append(`
        <li class="clearfix">
            <div class="message other-message float-right">
                `+ message + `
            </div>
        </li>
    `);
    $("#messageInput").val('');
    scrollToBottom();
    connection.invoke("SendMessage", userId, message, myId).catch(function (err) {
        return console.error(err.toString());
    });
})

function scrollToBottom() {
    var pixelFromTop = 500;
    $(".chat-history").animate({ scrollTop: $(".chat-history")[0].scrollHeight }, 1000);
}
