<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HeaderCliente.ascx.cs" Inherits="CallcenterNUevo.Controles.HeaderCliente" %>
<%@ Reference VirtualPath="~/Site.Master" %>
 <script type="text/javascript" src="../Scripts/jquery-2.1.0.js"> </script>
 <script type="text/javascript" src="../Scripts/jquery-ui-1.10.4.js"></script>
 <link rel="stylesheet" href="../Content/themes/base/jquery.ui.datepicker.css"/>
 <link rel="stylesheet" href="../Content/themes/base/jquery.ui.theme.css"/>
 <link rel="stylesheet" href="../Content/themes/base/jquery.ui.core.css"/>
<script type="text/javascript">
    function MostrarEdit(){
        document.getElementById("select").style.display = "none";
        document.getElementById("update").style.display = "";
        return false;
    }
    function OcultarEdit()
    {
        document.getElementById("select").style.display = "";
        document.getElementById("update").style.display = "none";
        return false;
    }
</script>

    <table style="width:100%; text-align:left;">
        <tr>
            <td class="fuenteReporte" style="font-weight:bold;">Tarjeta:</td>
            <td><asp:Label ID="lblTarjeta" runat="server" Text="" CssClass="fuenteReporte"></asp:Label></td>
            <td style="width:30px"></td>
            <td class="fuenteReporte" style="font-weight:bold;">Nombre:</td>
            <td><asp:Label ID="lblNombre" runat="server" Text="" CssClass="fuenteReporte"></asp:Label></td>
            <td style="width:30px"></td>
            <td class="fuenteReporte" style="font-weight:bold;">Vigencia<asp:ImageButton ID="btnModificar" runat="server" ImageUrl="~/Imagenes_Benavides/registro.png" Width="20px" Visible="false" OnClientClick=" return MostrarEdit();" Height="20px"/>:</td>
            <td><div id="select"><asp:Label ID="lblVigencia" runat="server" Text="" CssClass="fuenteReporte"></asp:Label></div>
                <div id="update" style="display:none"><asp:TextBox ID="txtfecha" runat="server" CssClass="dtPicker readO"></asp:TextBox>&nbsp;<asp:ImageButton runat="server" ID="ibtnGuardarVig" ImageUrl="~/Imagenes_Benavides/botones/save.png" Width="30px" OnClick="ibtnGuardarVig_Click" /><asp:ImageButton runat="server" ID="btnCancelar" ImageUrl="~/Imagenes_Benavides/botones/undo_Menu.png" Width="30px" OnClientClick="return OcultarEdit();" /></div>
            </td>
            <td style="width:30px"></td>
            <td class="fuenteReporte" style="font-weight:bold;">Estatus:</td>
            <td><asp:Label ID="lblEstatus" runat="server" Text="" CssClass="fuenteReporte"></asp:Label></td>
        </tr>
        <tr>
            <td class="fuenteReporte" style="font-weight:bold;">Celular:</td>
            <td><asp:Label ID="lblCelular" runat="server" Text="" CssClass="fuenteReporte"></asp:Label></td>
            <td></td>
            <td class="fuenteReporte" style="font-weight:bold;">Correo Electrónico:</td>
            <td><asp:Label ID="lblEmail" runat="server" Text="" CssClass="fuenteReporte"></asp:Label></td>
            <td></td>
            <td class="fuenteReporte" style="font-weight:bold;">Teléfono casa:</td>
            <td><asp:Label ID="lblTelefonocasa" runat="server" Text="" CssClass="fuenteReporte"></asp:Label></td>
            <td></td>
            <td class="fuenteReporte" style="font-weight:bold;">Fecha cumpleaños:</td>
            <td><asp:Label ID="lblCumpleaños" runat="server" Text="" CssClass="fuenteReporte"></asp:Label></td>
        </tr>
        <tr>
            <td class="fuenteReporte" style="font-weight:bold;">Cel. Confirmado:</td>
            <td><asp:Label ID="lblCelConf" runat="server" CssClass="fuenteReporte"></asp:Label></td>
            <td></td>
            <td class="fuenteReporte" style="font-weight:bold;">Correo confirmado:</td>
            <td><asp:Label ID="lblCorreoconf" runat="server" CssClass="fuenteReporte"></asp:Label></td>
            <td></td>
            <td class="fuenteReporte" style="font-weight:bold;">Confirma Portal:</td>
            <td>
                <asp:Label ID="lblPadecimientos" runat="server" CssClass="fuenteReporte" Visible="false"></asp:Label>
                <asp:Label ID="lblConfirmaPortal" runat="server" CssClass="fuenteReporte"></asp:Label>
            </td>
            <td></td>
            <td class="fuenteReporte" style="font-weight:bold;">Acepta envío de mail:</td>
            <td><asp:Label ID="lblAceptaPromo" runat="server" CssClass="fuenteReporte"></asp:Label></td>
        </tr>
        <tr>
            <td class="fuenteReporte" style="font-weight:bold;">Saldo:</td>
            <td><asp:Label ID="lblSaldo" runat="server" CssClass="fuenteReporte"></asp:Label></td>
            <td></td>
            <td class="fuenteReporte" style="font-weight:bold;">Nivel:</td>
            <td><asp:Label ID="lblNivel" runat="server" CssClass="fuenteReporte"></asp:Label> </td>
            <td></td>
            <td class="fuenteReporte" style="font-weight:bold;">Boomerangs:</td>
            <td><asp:Label ID="lblBoomerang" runat="server" CssClass="fuenteReporte"></asp:Label></td>
            <td></td>
            <td class="fuenteReporte" style="font-weight:bold;">Fecha último movimiento:</td>
            <td><asp:Label ID="lblFechaUcompra" runat="server" CssClass="fuenteReporte"></asp:Label></td>
        </tr>
        <tr>
            <td class="fuenteReporte" style="font-weight:bold;">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td class="fuenteReporte" style="font-weight:bold;">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td class="fuenteReporte" style="font-weight:bold;">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td class="fuenteReporte" style="font-weight:bold;">Inicio de Membresia:</td>
            <td><asp:Label ID="lblInicioM" runat="server" CssClass="fuenteReporte"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="11" style="height:15px"></td>
        </tr>
        <tr>
           <td colspan="11" style="height:1px; background-color:red;"></td>
        </tr>
    </table>
<br />
<script>
    $(".dtPicker").datepicker({ dateFormat: 'dd/mm/yy', monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'], dayNames: ['Domingo', 'Lunes', 'Martes', 'Miércoles', 'Jueves', 'Viernes', 'Sábado'], dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mie', 'Jue', 'Vie', 'Sab'], dayNamesMin: ['Dom', 'Lun', 'Mar', 'Mie', 'Jue', 'Vie', 'Sab'] });
</script>

