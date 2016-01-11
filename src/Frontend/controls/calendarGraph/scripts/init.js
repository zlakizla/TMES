function Build()
{
    var RequestedOrder = document.getElementById("RequestedOrderInput").value;
   // alert(RequestedOrder);
   AjaxRequest("api/order/" + RequestedOrder,null,ValidateOrder);
   AjaxRequest("api/order/" + RequestedOrder + "/0" + "/Exploder", null, Exploder);
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

function Exploder(result)
{
    //alert();
    var data = JSON.stringify({ data: result })
    $('#ExploderTable').dataTable();
    //alert();
}