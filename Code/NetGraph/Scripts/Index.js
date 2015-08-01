function Build()
{
    $('#myform')[0].submit();
   
}

$(function ()
{
 
    $('#ExploderTable tbody tr').live('click',
     function ()
     {
         var Id = $(this).find('.Id').html();
         var Index = $(this).find('.Index').html();
         var Denotation = $(this).find('.Denotation').html();
         var Depth = $(this).find('.Depth').html();
         
         $.ajax({
             url: 'Home/Test1/',
             type: 'GET',
             cache: false,
             data:
                {
               
                    Index: Index,
                    Denotation: Denotation,
                    Depth: Depth
             },
             success: function (result) {
                 $('.NavigatorExploder').html(result);
             },
             error: function(e1,e2,e3)
             {
            
             }
         });

     });



    WorksRender();
    WorksBehaviour();
    WorkDetailIni();

 
});
var Work;
var ActualWork;

function ShortColor(Color)
{
    var pek = '';
    for (var i = 0; i < 9 ; i++)
    {
        if(i != 1 && i != 2)
        {
            pek += Color[i];
        }
    }
    return pek;
}
function WorksRender()
{
    ActualWork = $('.ActualWork');
    Work = $('.Work');
    var MaxDuration = 0;
    var MaxLength = 900;
    var MinLength = 100;
    for (var i = 0; i < Work.length; i++)
    {
        Work[i].Duration = parseFloat($(Work[i]).find('.Duration').val().replace(',', '.'));
        Work[i].Color = $(Work[i]).find('.Color').val();
       
        $(Work[i]).css({ "background-color": ShortColor(Work[i].Color) });

        if(MaxDuration < Work[i].Duration)
        {
            MaxDuration = Work[i].Duration;
        }
        
    }
    MaxDuration = 1600;
    var StepDuration = MaxLength / MaxDuration;
   
    for (var i = 0; i < Work.length; i++)
    {
        Work[i].StepDuration = StepDuration;
        $(Work[i]).css("width", 10 + StepDuration * Work[i].Duration);
    }

     

}

function WorksBehaviour()
{
    var Work = $('.Work');
    Work.bind('click', function (event)
    {
        $('.SelectedWork').removeClass('SelectedWork');
        $(this).addClass('SelectedWork');
        Refresh();
    });
    WorksResize();
}

function WorksResize()
{
  //  var Work = $('.Work');
    for (var i = 0; i < Work.length; i++)
    {
        $(Work[i]).resizable(
        {
            maxHeight: 30,
            maxWidth: 1000,
            minWidth: 20 + Work[i].Duration * Work[i].StepDuration,
            minHeight: 30,
            resize: function (e, args)
            {
                var NewWidth = args.size.width / this.StepDuration - 60;
                //Work[i].StepDuration * 
                $(this).find('.DurationText').html(NewWidth.toFixed(0));
            }
        });
        $(Work[i]).draggable(
        {
            containment: "parent",
            axis: "x",

        });
    }
}

function WorkDetailIni()
{
    var WorkDetail = $('.WorkDetail');
    WorkDetail.dialog();
}

function Refresh()
{
    //$("#par").load('@Url.Action("Skits","KitSection")' + '?id=' + 1 + '&status=' + 1)
    var Id = $('.SelectedWork').find('.Id').val();
    var Data = JSON.stringify({ Id: Id });

    $.ajax({
        url: "Work/GetWorkDetails",
        type: "get",
        data: "Order=4&Id=" + Id, //if you need to post Model data, use this
        success: function (result)
        {
          //  $('#par').html(result);
        },
        error: function (ek, pek, error)
        {
         /*   var x = window.open();
            x.document.open();
            x.document.write(ek.responseText);
            x.document.close();*/
        }
    });

  //  $("#par").load('@Html.Partial("WorkDetail", new NetGraph.ViewModels.WorkDetailViewModel())');
}

