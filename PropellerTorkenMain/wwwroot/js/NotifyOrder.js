"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/orderHub").build();

connection.start().then(function () {
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("CustomerConfirmButton").addEventListener("click", function (event) {
    var message = "Det finns en ny order att hantera";
    connection.invoke("SendMessage", message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});