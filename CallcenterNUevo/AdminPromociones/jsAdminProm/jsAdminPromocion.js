function isokmaxlength(e, val, maxlengt)
{
    var charCode = (typeof e.which == "number") ? e.which : e.keyCode

    if (!(charCode == 44 || charCode == 46 || charCode == 0 || charCode == 8 || (val.value.length < maxlengt))) {
        return false;
    }
}

function MostrarPopup() {
    var divpopReg = document.getElementById("popReg");
    divpopReg.style.visibility = "visible";
}

function CerrarPopup() {
    var divpopReg = document.getElementById("popReg");
    divpopReg.style.visibility = "hidden";
}

function RegresarPagina() {
    history.back();
}

$(document).ready(function () {

    $('.close').on("click", function () {
        debugger;
        $('#popReg').fadeOut('slow');
        return false;
    });

    //$('#MainContent_btnCloseReg').click(function () {
    //    alert("cancelar");
    //});

    $('#MainContent_btnNo').on("click", function () {
        $('#popReg').fadeOut('slow');
        //$('#MainContent_txtCorreo').focus();
        return false;
    });
});

function ShowReg() {
    //debugger;
    var _docHeight = (document.height !== undefined) ? document.height : document.body.scrollHeight;
    var _docWidth = (document.width !== undefined) ? document.width : document.body.offsetWidth;

    $('#popReg').fadeIn('slow');
    $('#popReg').height(_docHeight);

    //$('#popReg div')[0].removeAttr('height');
    //$('#popReg div')[0].attr('height', '180');

    return false;
}