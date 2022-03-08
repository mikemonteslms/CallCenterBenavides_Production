<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroGeneral.aspx.cs" Inherits="CallcenterNUevo.Cat.RegistroGeneral" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <center>     

     <script type="text/javascript" src="../Scripts/jquery-2.1.0.js"> </script>
     <script type="text/javascript" src="../Scripts/jquery-ui-1.10.4.js"></script>
        <link rel="stylesheet" href="../Content/Site.css"/>
 <link rel="stylesheet" href="../Content/themes/base/jquery.ui.datepicker.css"/>
 <link rel="stylesheet" href="../Content/themes/base/jquery.ui.theme.css"/>
 <link rel="stylesheet" href="../Content/themes/base/jquery.ui.core.css"/>
          <style type="text/css">
        .overlay  
        {
            position: fixed;
            z-index: 98;
            top: 0px;
            left: 0px;
            right: 0px;
            bottom: 0px;
            background-color: #aaa; 
            filter: alpha(opacity=80); 
            opacity: 0.8; 
        }
        .overlayContent
        {
            z-index: 99;
            margin: 250px auto;
            width: 32px;
            height: 32px;
        }
        .titulo
        {
            font-family: Arial;
            font-size: 16pt;
            color: #004A99;
        }
       
        .fuenteReporte
        {
            font-family: Arial Narrow;
            font-size: 12pt;
            color:#2B347A;
        }
        .RadGrid_Default .rgHeader, .RadGrid_Default th.rgResizeCol, .RadGrid_Default .rgHeaderWrapper {
            background: #2B347A 0 -2300px repeat-x !important;
            color: #fff !important;
            font-size: 12pt !important;
        }
        .cajatexto {
            border: 1px solid #808080;
        }
    </style> 
    <table>
        <tr style="border-bottom: 2px solid black;">
            <td>
                <h1 class="titulo">Registro</h1>
            </td>
            <td colspan="3">
                <h2><asp:Label Text="" runat="server" ID="lblCategoriaMecanica" CssClass="titulo" /></h2>
            </td>
            <td colspan="1" style="text-align: right;">
                <asp:Button Text="Cancelar" runat="server" ID="Button1" OnClick="btnCancelar_Click" CausesValidation="False" />
                <asp:Button Text="Siguiente" runat="server" ID="Button2" OnClick="btnSiguiente_Click" />
            </td>
        </tr>
        <tr>
            <td style="border-top: 2px solid black; padding-top: 30px;" colspan="5"></td>
        </tr>
        <tr>
            <td>Nombre:
            </td>
            <td colspan="4">
                <asp:TextBox runat="server" ID="txtNombre" Style="width: 80%" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                    ControlToValidate="txtNombre"
                    ErrorMessage="Requerido"
                    ForeColor="Red">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Descripción:
            </td>
            <td colspan="4">
                <asp:TextBox runat="server" ID="txtDescripcion" Style="width: 80%" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                    ControlToValidate="txtDescripcion"
                    ErrorMessage="Requerido"
                    ForeColor="Red">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Club
            </td>
            <td>
                <asp:DropDownList runat="server" ID="cboClub">
                </asp:DropDownList>
            </td>
            <td></td>
            <td>Nivel
            </td>
            <td>
                <asp:CheckBoxList runat="server" ID="chkNivel" RepeatDirection="Horizontal"></asp:CheckBoxList>
            </td>
        </tr>
        <tr>
            <td>Edad Inicial:
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtEdadIni" CssClass="numeric" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                    ControlToValidate="txtEdadIni"
                    ErrorMessage="Requerido"
                    ForeColor="Red">
                </asp:RequiredFieldValidator>
            </td>
            <td></td>
            <td>Edad Final:
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtEdadFin" CssClass="numeric" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                    ControlToValidate="txtEdadFin"
                    ErrorMessage="Requerido"
                    ForeColor="Red">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Beneficio Inicial:
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtBeneficioIni" CssClass="numeric" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                    ControlToValidate="txtBeneficioIni"
                    ErrorMessage="Requerido"
                    ForeColor="Red">
                </asp:RequiredFieldValidator>
            </td>
            <td></td>
            <td>Beneficio Final:
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtBeneficioFin" CssClass="numeric" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                    ControlToValidate="txtBeneficioFin"
                    ErrorMessage="Requerido"
                    ForeColor="Red">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Compra Inicial:
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtCompraIni" CssClass="numeric" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                    ControlToValidate="txtCompraIni"
                    ErrorMessage="Requerido"
                    ForeColor="Red">
                </asp:RequiredFieldValidator>
            </td>
            <td></td>
            <td>Compra Final:
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtCompraFin" CssClass="numeric" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"
                    ControlToValidate="txtCompraFin"
                    ErrorMessage="Requerido"
                    ForeColor="Red">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Fecha Inicial:
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtFechaIni" CssClass="dtPicker" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server"
                    ControlToValidate="txtFechaIni"
                    ErrorMessage="Requerido"
                    ForeColor="Red">
                </asp:RequiredFieldValidator>
            </td>
            <td></td>
            <td>Fecha Final:
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtFechaFin" CssClass="dtPicker" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server"
                    ControlToValidate="txtFechaFin"
                    ErrorMessage="Requerido"
                    ForeColor="Red">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Periodo:
            </td>
            <td>
                <asp:DropDownList runat="server" ID="cboPeriodo">
                </asp:DropDownList>
            </td>
            <td></td>
            <td>Límite:
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtLimite" CssClass="numeric" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server"
                    ControlToValidate="txtLimite"
                    ErrorMessage="Requerido"
                    ForeColor="Red">
                </asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr>
            <td>Estatus:
            </td>
            <td>
                <asp:DropDownList runat="server" ID="cboEstatus">
                </asp:DropDownList>
            </td>
            <td></td>
            <td>
                Tipo Precio:
            </td>
            <td>
                  <asp:DropDownList runat="server" ID="cboTipoPrecio">
                </asp:DropDownList>
            </td>
        </tr>

    </table>
    <script>
        $(".dtPicker").datepicker({ dateFormat: 'dd/mm/yy', monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'], dayNames: ['Domingo', 'Lunes', 'Martes', 'Miércoles', 'Jueves', 'Viernes', 'Sábado'], dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mie', 'Jue', 'Vie', 'Sab'], dayNamesMin: ['Dom', 'Lun', 'Mar', 'Mie', 'Jue', 'Vie', 'Sab'] });


        $(document).on("input", ".numeric", function () {
            this.value = this.value.replace(/[^0-9\.]/g, '');
        });
    </script>
</center>
</asp:Content>
