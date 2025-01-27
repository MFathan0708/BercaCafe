﻿var table;
var splitDate;
$('.input-daterange-datepicker').daterangepicker({
    buttonClasses: ['btn', 'btn-sm'],
    applyClass: 'btn-danger',
    cancelClass: 'btn-inverse'
});

$(function () {
    $('input[name="daterange"]').daterangepicker({
        startDate: moment().startOf('month'),
        endDate: moment(),
        locale: {
            format: 'MMM/DD/YYYY',

        }
    });
});

$(document).ready(function () {
    splitDate = $('#dateFilter').val().toString().split('-');
    table = $('#tblDivisonReport').DataTable({
        "paging": true,
        "autoWidth": false,
        "responsive": true,
        "ajax": {
            "url": "https://localhost:44331/api/Reports/ReportDivisi/?fromDate=" + splitDate[0].toString().trim().replaceAll('/', '-') + "&thruDate=" + splitDate[0].toString().trim().replaceAll('/', '-'),
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
                extend: "excelHtml5", className: "btnExcel btn btn-rounded", text: '<i class="fa fa-file-excel-o"> Excel</i>', titleAttr: 'Excel'
            },
        ],
        initComplete: function () {
            var btns = $('.btnExcel');
            btns.css("background-color", "Green");
            btns.css("color", "white");
        },
        columns: [
            {
                render: function (data, type, row, meta) {
                    return meta.row + meta.settings._iDisplayStart + 1 + '.';
                }
            },
            {
                data: "vendor"
            },
            {
                data: "direktoratName"
            },
            {
                data: "divisionname"
            },
            {
                data: "dept"
            },
            {
                data: "jml"
            }
        ],
    });
    table.on('order.dt search.dt', function () {
        table.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
            cell.innerHTML = i + 1;
        });
    }).draw();
});

$("#dateFilter").on('change', function () {    // 2nd way
    searchFromDate();
});

function searchFromDate() {
    $('#tblDivisonReport').DataTable().clear().draw();
    splitDate = $('#dateFilter').val().toString().split('-');
    table = $('#tblDivisonReport').DataTable({
        "paging": true,
        "autoWidth": false,
        "responsive": true,
        "ajax": {
            "url": "https://localhost:44331/api/Reports/ReportDivisi/?fromDate=" + splitDate[0].toString().trim().replaceAll('/', '-') + "&thruDate=" + splitDate[1].toString().trim().replaceAll('/', '-'),
            "type": "GET",
            "dataType": "json",
            "dataSrc": "result",
            async: true,
            error: function (data) {
                console.log(data);
            }
        },
        "language": {
            "emptyTable": "No data available in table"
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
                extend: "excelHtml5", className: "btnExcel btn btn-rounded", text: '<i class="fa fa-file-excel-o"> Excel</i>', titleAttr: 'Excel'
            },
        ],
        initComplete: function () {
            var btns = $('.btnExcel');
            btns.css("background-color", "Green");
            btns.css("color", "white");
        },
        columns: [
            {
                render: function (data, type, row, meta) {
                    return meta.row + meta.settings._iDisplayStart + 1 + '.';
                }
            },
            {
                data: "vendor"
            },
            {
                data: "direktoratName"
            },
            {
                data: "divisionname"
            },
            {
                data: "dept"
            },
            {
                data: "jml"
            }
        ],
    });
    table.on('order.dt search.dt', function () {
        table.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
            cell.innerHTML = i + 1;
        });
    }).draw();
};