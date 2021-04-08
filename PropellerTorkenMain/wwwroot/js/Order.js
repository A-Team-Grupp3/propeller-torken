"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/orderHub").build();

connection.on("RecieveMessage", function (message) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var encodedMsg = msg;
    window.alert(encodedMsg);
});

connection.start().then(function () {
    document.getElementById("CustomerConfirmButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});