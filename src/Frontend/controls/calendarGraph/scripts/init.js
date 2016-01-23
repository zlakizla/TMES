var tE, tW, RequestedOrder;

$(document).ready(function () {

    tE = $('#ExploderTable').dataTable({
        "bPaginate": false,
        "bInfo": false,
        "bFilter": false,
        "columns":
        [
            {"data":"id_record"},
            { "data": "Type" },
            { "data": "Ind" },
            { "data": "Denotation" },
            { "data": "Amount" },
            { "data": "Depth" }
        ],
        "columnDefs": [
            {
                "className": "hidden",
                "targets": [0]
            }
        ]
    });

    tW = $('#WorkDetaleTable').dataTable({
        "bPaginate": false,
        "bInfo": false,
        "bFilter": false,
        "columns":
        [
            { "data": "Ind" },
            { "data": "Denotation" },
            { "data": "Chain" },
            { "data": "Department" },
            { "data": "Duration" },
            { "data": "Operation" }
        ],
        "order": [[2, "asc"]]
    });

    tE.on('click', 'tbody tr', function () {
        var field = $('td', this);

        var idRecord = field.eq(0).text();
        var ind = field.eq(2).text();
        var denotation = field.eq(3).text();

        var dv = $('#Navigate');
        dv.append("<span class='nv' style='background-color: #757c81; cursor:pointer' id=" + idRecord + ">" + ind + " " + denotation + "</span>      ");

        AjaxRequest("api/order/" + RequestedOrder + "/" + idRecord + "/Exploder", null, Exploder);
        AjaxRequest("api/Order/" + idRecord + "/WorkDetail", null, WorkDetail);

        $('.nv').on('click', function () {

            var item = $(this);
            idRecord = item.attr('id');
            AjaxRequest("api/order/" + RequestedOrder + "/" + idRecord + "/Exploder", null, Exploder);
            AjaxRequest("api/Order/" + idRecord + "/WorkDetail", null, WorkDetail);
            for (var i = 0; i < 17; i++) {
                console.log(item.next('span').remove());
            }
        });
    });
});

function Build()
{
    RequestedOrder = document.getElementById("RequestedOrderInput").value;
    AjaxRequest("api/order/" + RequestedOrder, null, ValidateOrder);
    AjaxRequest("api/order/" + RequestedOrder + "/-1" + "/Exploder", null, Exploder);
    AjaxRequest("api/order/" + RequestedOrder + "/build", null, ShowDetails);
 
}

function ValidateOrder(result)
{
   //alert(result.Name);
}

function ShowDetails(result)
{
    var data = JSON.stringify({data: result});
    gantt.parse(data);
}

function Exploder(result) {
    tE.fnClearTable();
    tE.fnAddData(result);
}

function WorkDetail(result) {
    tW.fnClearTable();
    tW.fnAddData(result);
}