var OrderUri = 'api/Order';
var CustomerUri = 'api/Customer';
var cookieData = sessionStorage.getItem('cart');
function createOrder() {
    var firstName = document.getElementById('firstName');
    var lastName = document.getElementById('lastName');
    var address = document.getElementById('street');
    var city = document.getElementById('city');
    var email = document.getElementById('email');
    var phoneNumber = document.getElementById('phoneNumber');
    var zipCode = document.getElementById('zipCode');
    var custId = this.queryCustomer(firstName); // Kolla om kund
    fetch(OrderUri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(cookieData)
    }).then(function (Response) { return Response.json(); })
        .then(function (data) { return _displayItems(data); }).catch(function (error) { return console.error("Couldn't complete.", error); });
}
function queryCustomer(customer) {
    return fetch(this.CustomerUri + "?name=" + customer).then(function (response) { return response.json(); }).then(function (data) { return data[0].customerId; });
}
function _displayItems(data) {
    var elem = document.getElementById('orderIdDiv');
    var flasher = document.createElement('h4');
    flasher.textContent = data;
    elem.appendChild(flasher);
}
function getCookie(name) {
    var nameLenPlus = (name.length + 1);
    return document.cookie
        .split(';')
        .map(function (c) { return c.trim(); })
        .filter(function (cookie) {
        return cookie.substring(0, nameLenPlus) === name + "=";
    })
        .map(function (cookie) {
        return decodeURIComponent(cookie.substring(nameLenPlus));
    })[0] || null;
}
function getIdFromRequest(data) {
    var jsondata = JSON.parse(data);
    return jsondata.customerId;
}
//# sourceMappingURL=ProductApiCall.js.map