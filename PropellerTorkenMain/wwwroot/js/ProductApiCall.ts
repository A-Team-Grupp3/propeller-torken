const CustomerUri = 'api/Customer';

function getCustId() {
    const hiddenElem = document.getElementById('CustomerId');
    let firstName = document.getElementById('Customer_Firstname').getAttribute('value');
    queryCustomer(firstName); // Kolla om kund
    if (!(hiddenElem.getAttribute('value'))) {
        hiddenElem.setAttribute('value', null);
    }
}
async function queryCustomer(customer: string) {
    var awaitFetch = await fetch(this.CustomerUri + "?name=" + customer)
        .then(response => response.json());
    return awaitFetch;
}

function getIdFromRequest(data: any): any {
    var jsondata = JSON.parse(data);
    return jsondata.customerId;
}