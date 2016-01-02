var IsBillOfMaterialsModeActive = false;

function SelectBOM(sender)
{
   // alert('pek');
    if(IsBillOfMaterialsModeActive == false)
    {
        $(sender).addClass('Toggle');
        IsBillOfMaterialsModeActive = true;
    }
    else
    {
        $(sender).removeClass('Toggle');
        IsBillOfMaterialsModeActive = false;
    }
}