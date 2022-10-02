var menuid;
var cardBool = false;

$(document).ready(function (){
    $("#hrTag").attr({ style: 'visibility: hidden;' });
});

function clickShowModal(name, menuId) {
    var regex = new RegExp(/[0-9]{10}/);
    if (regex.test($('#cardNumber').val().toString().trim()) && cardBool) {
        menuid = menuId;
        $('#exampleModalLabel1').text('New Order - ' + name);
        $('#exampleModal').modal('show');
    } else {
        swal({
            title: "Error",
            text: "Silahkan isi terlebih dahulu nomor kartu dengan benar",
            type: "error",
        });
    }
}
function createOrder() {
    var cardNumber = $('#cardNumber').val().toString().trim();
    var type = document.querySelector('input[name="radioType"]:checked');
    var cup = document.querySelector('input[name="radioCup"]:checked');
    if (type == null) {
        swal({
            title: "Gagal Membuat Pesanan",
            text: "Silahkan pilih jenis terlebih dahulu",
            type: "error",
        });
    } else if (cup == null) {
        swal({
            title: "Gagal Membuat Pesanan",
            text: "Silahkan pilih cup terlebih dahulu",
            type: "error",
        });
    } else if (cardNumber == null) {
        swal({
            title: "Gagal Membuat Pesanan",
            text: "Silahkan mengisi nomor kartu terlebih dahulu",
            type: "error",
        });
    } else {
        $.ajax({
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            url: 'https://localhost:44331/api/Orders/',
            data: '{"CardNo": "' + cardNumber + '", "menuID":' + menuid + ', "cupID":' + cup.value + ', "typeMenu":' + type.value + '}'
        }).fail(function (message) {
            swal({
                title: "Gagal Membuat Pesanan",
                text: message.responseJSON.message,
                type: "error",
            }, function () {

                $('#exampleModal').modal('toggle');
            });
        }).done(function (message) {
            swal({
                title: "Berhasil",
                text: message.message,
                type: "success",
            }, function () {

                $('#exampleModal').modal('toggle');
            });
        });
    }
}

$("#cardNumber").on('change', function () {
    var regex = new RegExp(/[0-9]{10}/);
    if (regex.test($('#cardNumber').val().toString().trim())) {
        $.ajax({
            type: 'GET',
            contentType: 'application/json; charset=utf-8',
            url: 'https://localhost:44331/api/EmployeeUser/getByCard?cardNo=' + $('#cardNumber').val().toString().trim()
        }).fail(function (message) {
            swal({
                title: "Error",
                text: message.responseJSON.message,
                type: "error",
            });
            document.getElementById("hName").innerHTML = '';
            $("#hrTag").attr({ style: 'visibility: hidden;' });
            document.getElementById("hDept").innerHTML = '';
            cardBool = false;
        }).done(function (message) {
            document.getElementById("hName").innerHTML = message.result.employeeName;
            $("#hrTag").attr({ style: 'visibility: visible;' });
            document.getElementById("hDept").innerHTML = message.result.dept;
            cardBool = true;
        });
    } else {
        cardBool = false;
        document.getElementById("hName").innerHTML = '';
        $("#hrTag").attr({ style: 'visibility: hidden;' });
        document.getElementById("hDept").innerHTML = '';
    }
});