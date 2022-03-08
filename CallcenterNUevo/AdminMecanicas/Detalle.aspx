<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="CallcenterNUevo.AdminMecanicas.Detalle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
     <script type="text/javascript" src="../Scripts/jquery-2.1.0.js"> </script>
     <script type="text/javascript" src="../Scripts/jquery-ui-1.10.4.js"></script>
        <link rel="stylesheet" href="../Content/Site.css"/>
 <link rel="stylesheet" href="../Content/themes/base/jquery.ui.datepicker.css"/>
 <link rel="stylesheet" href="../Content/themes/base/jquery.ui.theme.css"/>
 <link rel="stylesheet" href="../Content/themes/base/jquery.ui.core.css"/>
     <style type="text/css">
       .titulo
        {
            font-family: Arial;
            font-size: 16pt;
            color:#2B347A;
        }
 </style>
<center>
    <table>
        <tr style="border-bottom: 2px solid black;">
            <td>
                <h1 class="titulo">Detalle</h1>
            </td>
            <td colspan="3">
                <h2>
                    <asp:Label Text="" runat="server" ID="lblCategoriaMecanica" CssClass="titulo" />
                </h2>
            </td>
            <td colspan="1" style="text-align: right;">
                <asp:Button Text="Regresar" runat="server" ID="btnCancelar" />

            </td>
        </tr>
        <tr>
            <td style="border-top: 2px solid black; padding-top: 30px;" colspan="5"></td>
        </tr>
        <tr>
            <td>Categoria Mecanica:
            </td>
            <td colspan="4">
                <asp:TextBox runat="server" ID="txtCategoria" Style="width: 80%" CssClass="readO" />
            </td>
        </tr>
        <tr>
            <td>Nombre:
            </td>
            <td colspan="4">
                <asp:TextBox runat="server" ID="txtNombre" Style="width: 80%" CssClass="readO" />
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
                <asp:TextBox runat="server" ID="txtDescripcion" Style="width: 80%" CssClass="readO" />
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
                <asp:TextBox runat="server" ID="txtClub" CssClass="readO" />
            </td>
            <td></td>
            <td>Nivel
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtNivel"  CssClass="readO" />
            </td>
        </tr>
        <tr>
            <td>Edad Inicial:
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtEdadIni" CssClass="numeric readO" />
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
                <asp:TextBox runat="server" ID="txtEdadFin" CssClass="numeric readO" />
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
                <asp:TextBox runat="server" ID="txtBeneficioIni" CssClass="numeric readO" />
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
                <asp:TextBox runat="server" ID="txtBeneficioFin" CssClass="numeric readO" />
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
                <asp:TextBox runat="server" ID="txtCompraIni" CssClass="numeric readO" />
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
                <asp:TextBox runat="server" ID="txtCompraFin" CssClass="numeric readO" />
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
                <asp:TextBox runat="server" ID="txtFechaIni" CssClass="dtPicker readO" />
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
                <asp:TextBox runat="server" ID="txtFechaFin" CssClass="dtPicker readO" />
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
                <asp:TextBox runat="server" ID="txtPeriodo"  CssClass="readO" />
            </td>
            <td></td>
            <td>Límite:
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtLimite" CssClass="numeric readO" />
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
                <asp:TextBox runat="server" ID="txtEstatus" CssClass="numeric readO" />
            </td>
            <td></td>
            <td>
                Tipo Precio:
            </td>
            <td> 
                <asp:TextBox runat="server" ID="txtTipoPrecio" CssClass="readO" />
            </td>
        </tr>

        <tr>
            <td colspan="2"></td>
            <td></td>
            <td colspan="2"></td>
        </tr>

        <tr>
            <td colspan="2">
                <table class="Grid">
                    <tr style="text-align:center; font-weight:bold; background-color:white; color:#2B347A">
                        <th colspan="3">PIEZAS
                        </th>
                    </tr>
                    <tr style="background-color:#eae7e7; border:1px solid #eae7e7"> 
                        <th>Cantidad
                        </th>
                        <th>Producto
                        </th>
                        <th>Codigo Barras
                        </th>
                    </tr>
                    <asp:Repeater runat="server" ID="rptPiezas">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <%# DataBinder.Eval(Container.DataItem, "Cantidad") %>
                                </td>
                                <td>
                                    <%# DataBinder.Eval(Container.DataItem, "DescripcionProducto") %>
                                </td>
                                <td>
                                    <%# DataBinder.Eval(Container.DataItem, "CodigoBarras") %>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr style="background-color:white; border:1px solid #eae7e7">
                                <td>
                                    <%# DataBinder.Eval(Container.DataItem, "Cantidad") %>
                                </td>
                                <td>
                                    <%# DataBinder.Eval(Container.DataItem, "DescripcionProducto") %>
                                </td>
                                <td>
                                    <%# DataBinder.Eval(Container.DataItem, "CodigoBarras") %>
                                </td>
                            </tr>

                        </AlternatingItemTemplate>
                    </asp:Repeater>

                </table>

            </td>
            <td></td>
            <td colspan="2">
                <table class="Grid">
                    <tr style="text-align:center; font-weight:bold; background-color:white; color:#2B347A">
                        <th colspan="3">BENEFICIO
                        </th>
                    </tr>
                    <tr style="text-align:center; font-weight:bold;">
                        <th>Cantidad
                        </th>
                        <th>Producto
                        </th>
                        <th>Codigo Barras
                        </th>
                    </tr>
                    <asp:Repeater runat="server" ID="rptBeneficio">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <%# DataBinder.Eval(Container.DataItem, "Cantidad") %>
                                </td>
                                <td>
                                    <%# DataBinder.Eval(Container.DataItem, "DescripcionProducto") %>
                                </td>
                                <td>
                                    <%# DataBinder.Eval(Container.DataItem, "CodigoBarras") %>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr style="background-color:white; border:1px solid #eae7e7">
                                <td>
                                    <%# DataBinder.Eval(Container.DataItem, "Cantidad") %>
                                </td>
                                <td>
                                    <%# DataBinder.Eval(Container.DataItem, "DescripcionProducto") %>
                                </td>
                                <td>
                                    <%# DataBinder.Eval(Container.DataItem, "CodigoBarras") %>
                                </td>
                            </tr>

                        </AlternatingItemTemplate>
                    </asp:Repeater>

                </table>
            </td>
        </tr>

    </table>
    <script>
        $(".dtPicker").datepicker({ dateFormat: 'dd/mm/yy', monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'], dayNames: ['Domingo', 'Lunes', 'Martes', 'Miércoles', 'Jueves', 'Viernes', 'Sábado'], dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mie', 'Jue', 'Vie', 'Sab'], dayNamesMin: ['Dom', 'Lun', 'Mar', 'Mie', 'Jue', 'Vie', 'Sab'] });


        $(document).on("input", ".numeric", function () {
            this.value = this.value.replace(/[^0-9\.]/g, '');
        });

        $(".readO").prop("disabled", true).prop("readonly", true);
    </script>
</center>
</asp:Content>
