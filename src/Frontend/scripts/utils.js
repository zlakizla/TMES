function AjaxRequest(url, data, success, error)
{
	//alert('Request send to url:' + url);
	$.ajax
	(
		{
			url: url,
			type: 'GET',
			cache: false,
			async: false,
			data: data,
			success: function (result) 
			{	
				success();
			},
			error: function (e1, e2, e3) 
			{
				success();
			}
    	}
	);	
}