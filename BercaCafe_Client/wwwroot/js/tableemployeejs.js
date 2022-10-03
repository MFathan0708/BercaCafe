var table;
var splitDate;
$('.input-daterange-datepicker').daterangepicker({
    buttonClasses: ['btn', 'btn-sm'],
    applyClass: 'btn-danger',
    cancelClass: 'btn-inverse'
});
$(".select2").select2();
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
    $('#departmentSelector').empty();
    $.ajax({
        type: 'GET',
        url: "https://localhost:44331/api/Reports/DepartmentList",
        async: true,
        success: function (data) {
            $(data.result).each(function (_, i) {
                $('#departmentSelector').append($('<option/>').val(i).text(i));
            });
        }
    })
    splitDate = $('#dateFilter').val().toString().split('-');
    table = $('#tblEmployeeReport').DataTable({
        "paging": true,
        "autoWidth": false,
        "responsive": true,
        "ajax": {
            "url": "https://localhost:44331/api/Reports/ReportEmployee/?fromDate=" + splitDate[0].toString().trim().replaceAll('/', '-') + "&thruDate=" + splitDate[0].toString().trim().replaceAll('/', '-') + "&department=--ALL--&employeeId=0",
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
            "targets": "_all",
            targets: [0, 5],
            orderable: false,
            searchable: false
        }],
        order: ([[0, "asc"], [2, "asc"]]),
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
                data: "employeeKey"
            },
            {
                data: "employeeName"
            },
            {
                data: "dept"
            },
            {
                data: "logTime", render: function (dataLog) {
                    var dates = moment(dataLog.toString()).format("DD MMM YYYY, HH:mm:ss");
                    return dates;
                }
            },
            {
                data: "vendor"
            }
        ],
    });
    table.on('order.dt search.dt', function () {
        table.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
            cell.innerHTML = i + 1;
        });
    }).draw();
});

$("#dateFilter").on('change', function () {
    searchFromDate();
});

$("#departmentSelector").on('change', function () {
    searchFromDate();
});

$("#employeeId").on('change', function () {
    searchFromDate();
});

function searchFromDate() {
    var empId = 0;
    console.log($('#employeeId').val());
    if ($('#employeeId').val() != null) {
        empId = $('#employeeId').val();
    }
    $('#tblEmployeeReport').DataTable().clear().draw();
    splitDate = $('#dateFilter').val().toString().split('-');
    table = $('#tblEmployeeReport').DataTable({
        "paging": true,
        "autoWidth": false,
        "responsive": true,
        "ajax": {
            "url": "https://localhost:44331/api/Reports/ReportEmployee/?fromDate=" + splitDate[0].toString().trim().replaceAll('/', '-') + "&thruDate=" + splitDate[1].toString().trim().replaceAll('/', '-') + "&department=" + $('#departmentSelector').select2('data').toString().replaceAll("&", "%26") + "&employeeId=" + empId,
            "type": "GET",
            "dataType": "json",
            "dataSrc": "result",
            async: true,
            error: function (data) {
            }
        },
        "language": {
            "emptyTable": "No data available in table"
        },
        "bDestroy": true,
        "lengthChange": true,
        "displayLength": 10,
        filter: true,
        orderMulti: false,
        "columnDefs": [{
            "defaultContent": "-",
            "targets": "_all",
            targets: [0, 5],
            orderable: false,
            searchable: false
        }],
        order: ([[0, "asc"], [2, "asc"]]),
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
                data: "employeeKey"
            },
            {
                data: "employeeName"
            },
            {
                data: "dept"
            },
            {
                data: "logTime", render: function (dataLog) {
                    var dates = moment(dataLog.toString()).format("DD MMM YYYY, HH:mm:ss");
                    return dates;
                }
            },
            {
                data: "vendor"
            }
        ],
    });
    table.on('order.dt search.dt', function () {
        table.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
            cell.innerHTML = i + 1;
        });
    }).draw();
};