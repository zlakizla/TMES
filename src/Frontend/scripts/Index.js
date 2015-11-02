
// Все что ниже - надо разгрести :< 
function LoadBlock(Direction, Index, Denotation, Depth)
{
    var Method;
    if (Direction == "Up")
    {
        Method = 'Test1';
    }
    else if (Direction == "Down")
    {
        Method = 'OpenParent';
    }
    else if (Direction == null)
    {
        Method = 'LoadWorkDetail';
    }
    else
    {
        throw new ExceptionInformation("Direction is incorrect");
    }
    var Url = 'Home/' + Method + '/';
    $.ajax({
        url: Url,
        type: 'GET',
        cache: false,
        data:
        {
            Index: Index,
            Denotation: Denotation,
            Depth: Depth
        },
        success: function (result) {
            if (Direction != null)
            {
                $('.NavigatorExploder').html(result);
            }
            else
            {
                $('.NavigatorWorkDetail').html(result);
            }
           
        },
        error: function (e1, e2, e3) {

        }
    });
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
         LoadBlock('Up',Index, Denotation, Depth);
         LoadBlock(null, Index, Denotation, Depth);
     });

    $('.NavigatorMenu').live('click',
        function ()
        {
            var Index = $(this).find('.Index').html();
            var Denotation = $(this).find('.Denotation').html();
            var Depth = $(this).find('.Depth').html();
            LoadBlock('Down', Index, Denotation, Depth);
            LoadBlock(null, Index, Denotation, Depth);
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
}

