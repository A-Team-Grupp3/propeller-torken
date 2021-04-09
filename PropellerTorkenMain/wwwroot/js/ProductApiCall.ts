const OrderUri = 'api/Order';
const CustomerUri = 'api/Customer';

function createOrder() {
    const firstName = document.getElementById('firstName');
    const lastName = document.getElementById('lastName');
    const address = document.getElementById('street');
    const city = document.getElementById('city');
    const email = document.getElementById('email');
    const phoneNumber = document.getElementById('phoneNumber');
    const zipCode = document.getElementById('zipCode');
    const custId = this.queryCustomer(firstName); // Kolla om kund
    fetch(OrderUri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body:
    }).then(Response => Response.json())
        .then(data => _displayItems(data)).catch(error => console.error("Couldn't complete.", error));
}
function queryCustomer(customer: string) {
    return fetch(this.CustomerUri + "?name=" + customer).then(response => response.json()).then(data => data[0].customerId);
}

function _displayItems(data: string): any {
    const elem = document.getElementById('orderIdDiv');
    const flasher = document.createElement('h4');
    flasher.textContent = data;
    elem.appendChild(flasher);
}

function getCookie(name: string): string | null {
    const nameLenPlus = (name.length + 1);
    return document.cookie
        .split(';')
        .map(c => c.trim())
        .filter(cookie => {
            return cookie.substring(0, nameLenPlus) === `${name}=`;
        })
        .map(cookie => {
            return decodeURIComponent(cookie.substring(nameLenPlus));
        })[0] || null;
}

function getIdFromRequest(data: any): any {
    var jsondata = JSON.parse(data);
    return jsondata.customerId;
}