var table;
function convertToRupiah(angka) {
    var rupiah = '';
    var angkarev = angka.toString().split('').reverse().join('');
    for (var i = 0; i < angkarev.length; i++) if (i % 3 == 0) rupiah += angkarev.substr(i, 3) + '.';
    return 'Rp. ' + rupiah.split('', rupiah.length - 1).reverse().join('');
};

$(document).ready(function () {
    var idComp;
    table = $('#tblMaterialsLog').DataTable({
        "paging": true,
        "autoWidth": false,
        "responsive": true,
        "ajax": {
            "url": "https://localhost:44331/api/Stocks/MaterialsLog",
            "type": "GET",
            "dataType": "json",
            "dataSrc": "result",
            async: true,
            error: function (data) {
            }
        },
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
                extend: "excel", className: "btn btn-rounded", text: '<i class="fa fa-file-excel-o"> Excel</i>', titleAttr: 'Excel',
                attr: { style: "background-color: Green;color: white;" }
            },
        ],
        columns: [
            {
                data: "compTypeId", render: function (data, type, row, meta) {
                    idComp = data;
                    return meta.row + meta.settings._iDisplayStart + 1 + '.';
                }
            },
            {
                data: "typeName", render: function (data) {
                    //console.log(idComp);
                    $('#compTypeSelector').append($('<option/>').val(idComp).text(data));
                    return data;
                }
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
});