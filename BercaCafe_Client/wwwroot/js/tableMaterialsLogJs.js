﻿var table;
var saveData = [];
function convertToRupiah(angka) {
    var rupiah = '';
    var angkarev = angka.toString().split('').reverse().join('');
    for (var i = 0; i < angkarev.length; i++) if (i % 3 == 0) rupiah += angkarev.substr(i, 3) + '.';
    return 'Rp. ' + rupiah.split('', rupiah.length - 1).reverse().join('');
};

$(document).ready(function () {
    getData();
});

/*setTimeout(function () {
    getData();
}, 20000)*/
function addStock() {
    var regex = new RegExp(/([a-zA-Z]|[0-9]).*/);
    if (regex.test($('#brandName').val().toString().trim())) {
        if ($('#total').val() == 0 || $('#total').val() == '') {
            swal({
                title: "Gagal",
                text: "Total tidak boleh kosong atau berisi nilai 0!",
                type: "error"
            }, function () {
                setTimeout(() => $('#total').focus(), 110);
            });
        } else if ($('#composition').val() == 0 || $('#composition').val() == '') {
            swal({
                title: "Gagal",
                text: "Composition tidak boleh kosong atau berisi nilai 0!",
                type: "error"
            }, function () {
                setTimeout(() => $('#composition').focus(), 110);
            });
        } else if ($('#price').val() == 0 || $('#price').val() == '') {
            swal({
                title: "Gagal",
                text: "Price tidak boleh kosong atau berisi nilai 0!",
                type: "error"
            }, function () {
                setTimeout(() => $('#price').focus(), 110);
            });
        }
        else {
            var dataPost = {
                "CompTypeID": $('#compTypeSelector').val(),
                "MaterialsName": $('#brandName').val(),
                "MaterialsStock": $('#total').val(),
                "MaterialsQuantity": $('#composition').val(),
                "MaterialsUnit": $('#unitSelector').val(),
                "Price": $('#price').val()
            };
            $.ajax({
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                url: 'https://localhost:44331/api/Stocks/AddMaterialsAll',
                data: JSON.stringify(dataPost)
            }).done((result) => {
                swal({
                    title: "Berhasil",
                    text: "Berhasil menambahkan stock baru.",
                    type: "success",
                }, function () {
                    location.reload(true);
                });
            }).fail(function (message) {
                swal({
                    title: "Gagal",
                    text: message.responseJSON.message,
                    type: "error",
                });
            })
        }
    } else {
        swal({
            title: "Gagal",
            text: "Nama brand tidak boleh kosong!",
            type: "error"
        }, function () {
            setTimeout(() => $('#brandName').focus(), 110);
        });
    }
}

function getData() {
    $('#tblMaterialsLog').DataTable().clear().draw();
    var dataResults = [];
    $.ajax({
        "url": "https://localhost:44331/api/Stocks/MaterialsLog",
        "type": "GET",
        dataType: "JSON"
    }).done((result) => {
        dataResults = result.result;
        table = $('#tblMaterialsLog').DataTable({
            "paging": true,
            "autoWidth": false,
            "responsive": true,
            data: dataResults,
            "bDestroy": true,
            "lengthChange": false,
            "displayLength": 10,
            filter: true,
            orderMulti: false,
            "columnDefs": [{
                "defaultContent": "-",
                "targets": "_all"
            }],
            order: ([[0, "asc"], [1, "asc"]]),
            lengthMenu: [['10', '20', '50', '100', '-1'], ['10', '20', '50', '100', 'Show All']],
            dom: 'Bfrtip',
            "buttons": [
                {
                    extend: "excelHtml5", className: "btnExcel btn btn-rounded", text: '<i class="fa fa-file-excel-o"> Excel</i>', titleAttr: 'Export data to Excel'
                },
                {
                    text: '<i class="fa fa-shopping-basket"> Add Stock</i>',
                    className: "btn btn-rounded btn-primary",
                    action: function () {
                        $('#exampleModal').modal('show');
                    }
                }
            ],
            initComplete: function () {
                var btns = $('.btnExcel');
                btns.css("background-color", "Green");
                btns.css("color", "white");
            },
            columns: [
                {
                    data: "compTypeId"
                },
                {
                    data: "typeName"
                },
                {
                    data: "materialsName"
                },
                {
                    data: "materialsStock"
                },
                {
                    data: "materialsQuantity"
                },
                {
                    data: "materialsUnit"
                },
                {
                    data: "price", render: function (rupiah) {
                        var data = convertToRupiah(rupiah);
                        return data;
                    }
                },
                {
                    data: "totalPrice", render: function (rupiah) {
                        var data = convertToRupiah(rupiah);
                        return data;
                    }
                },
                {
                    data: "inputDate", render: function (dataLog) {
                        var dates = moment(dataLog.toString()).format("DD MMM YYYY, HH:mm:ss");
                        return dates;
                    }
                }
            ],
        });
        table.on('order.dt search.dt', function () {
            table.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
                cell.innerHTML = i + 1;
            });
        }).draw();
        getCompType();
    })
}

$("#compTypeSelector").on('change', function () {
    $('#unitSelector').empty();
    $(saveData).each(function (_, i) {
        if ($('#compTypeSelector').val() == i.compTypeId) {
            $('#unitSelector').append($('<option/>').val(i.compUnit).text(i.compUnit));
            return false;
        }
    });
});

function getCompType() {
    $('#compTypeSelector').empty();
    $('#unitSelector').empty();
    var dataResults = [];
    $.ajax({
        "url": "https://localhost:44331/api/Stocks/CompTypeAll",
        "type": "GET",
        dataType: "JSON"
    }).done((result) => {
        dataResults = result.result;
        saveData = dataResults;
        $(dataResults).each(function (_, i) {
            $('#compTypeSelector').append($('<option/>').val(i.compTypeId).text(i.typeName));
        });
        $('#unitSelector').append($('<option/>').val(dataResults[0].compUnit).text(dataResults[0].compUnit));
        /*dataResults = result.result;
        dataResults = dataResults.filter((value, index, self) =>
            index === self.findIndex((t) => (
                t.compTypeId === value.compTypeId && t.typeName === value.typeName
            ))
        )
        $(dataResults).each(function (_, i) {
            $('#compTypeSelector').append($('<option/>').val(i.compTypeId).text(i.typeName));
        });*/
    })
}