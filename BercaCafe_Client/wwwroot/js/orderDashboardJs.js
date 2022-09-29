var menuid;

function clickShowModal(name, menuId) {
    menuid = menuId;
    console.log(menuid);
    $('#exampleModalLabel1').text('New Order - ' + name);
    $('#exampleModal').modal('show');
}

function createOrder() {
    console.log(document.querySelector('input[name="radioType"]:checked').value);
}