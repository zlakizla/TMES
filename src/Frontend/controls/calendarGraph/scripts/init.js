function Build()
{
   var RequestedOrder = document.getElementById("RequestedOrderInput").value;
   AjaxRequest("api/order/" + RequestedOrder,null,ValidateOrder)
}

function ValidateOrder(result)
{
   alert(result.Name);
}