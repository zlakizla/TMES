function Build()
{
   var RequestedOrder = document.getElementById("RequestedOrderInput").value;
   AjaxRequest("api/order/" + RequestedOrder,null,ValidateOrder);
   
   AjaxRequest("api/order/" + RequestedOrder + "/build",null,ShowDetails);
   
}

function ValidateOrder(result)
{
   //alert(result.Name);
}

function ShowDetails(result)
{
    var data = JSON.stringify({data: result});
  //  alert(data);
    gantt.parse(data);
}