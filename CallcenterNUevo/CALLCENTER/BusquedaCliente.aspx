<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BusquedaCliente.aspx.cs" Inherits="CallcenterNUevo.CALLCENTER.BusquedaCliente" %>
<%@ MasterType VirtualPath="~/Site.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
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

    <center>
        <br /><br />
        <asp:UpdatePanel ID="upBuscaClientes" runat="server" >
            <ContentTemplate>
                    <asp:Panel ID="Panel2" runat="server" >
                    <div>
                    <span class="titulo">Búsqueda de cliente</span><br /><br />
                    </div>
                    </asp:Panel>
                    <asp:Panel ID="pnlFiltro" runat="server">
                    <table style="text-align:left; width:500px">
                    <tr>
                    <td  class="fuenteReporte">Tarjeta:</td>
                    <td></td>
                    <td><asp:TextBox ID="txtTarjeta" runat="server" Width="250px"></asp:TextBox></td>
                    </tr>
                    <tr>
                    <td class="fuenteReporte">Celular:</td>
                    <td></td>
                    <td><asp:TextBox ID="txtCelular" runat="server" Width="250px"></asp:TextBox></td>
                    </tr>
                    <tr>
                    <td class="fuenteReporte">Correo Eléctrónico:</td>
                    <td></td>
                    <td><asp:TextBox ID="txtEmail" runat="server" Width="250px"></asp:TextBox></td>
                    </tr>
                    <tr>
                    <td class="fuenteReporte">Nombre:</td>
                    <td></td>
                    <td><asp:TextBox ID="txtNombre" runat="server" Width="250px"></asp:TextBox></td>
                    </tr>
                    <tr>
                    <td class="fuenteReporte">Apellido Paterno:</td>
                    <td></td>
                    <td><asp:TextBox ID="txtAPaterno" runat="server" Width="250px"></asp:TextBox></td>
                    </tr>
                    <tr>
                    <td class="fuenteReporte">Apellido Materno:</td>
                    <td></td>
                    <td><asp:TextBox ID="txtAMaterno" runat="server" Width="250px"></asp:TextBox></td>
                    </tr>
                    <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    </tr>
                    <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td style="text-align: right;">
                    <asp:Button ID="btnBusqueda" runat="server" Text="Buscar" OnClick="btnBusqueda_Click" />
                    </td>
                    </tr>
                    </table>
                    </asp:Panel>
                    <br /><br /> 
                    <telerik:RadGrid ID="rdgResultado" runat="server"
                    EmptyDataText="No hay datos que mostrar" PageSize="20" Font-Size="11px" 
                    BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" 
                    BorderWidth="1px" CellPadding="3" AutoGenerateColumns="False" Culture="es-ES" GroupPanelPosition="Top" OnItemCommand="rdgResultado_ItemCommand" AllowPaging="True" OnPageIndexChanged="rdgResultado_PageIndexChanged" OnItemDataBound="rdgResultado_ItemDataBound">
                    <GroupingSettings CollapseAllTooltip="Collapse all groups"></GroupingSettings>
                    <MasterTableView NoMasterRecordsText="No se encontro información">
                    <RowIndicatorColumn Visible="False">
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn Created="True">
                    </ExpandCollapseColumn>
                    <Columns>
                    <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" UniqueName="TemplateColumn">
                    <ItemTemplate>
                    <asp:Button ID="btnSelect" runat="server" CommandName="Select" CommandArgument='<%# Eval("Tarjeta_strNumero") + "|" + Eval("TarjetaEstatus_intID") %>' Text="Ver detalle" />
                    </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridBoundColumn DataField="Tarjeta_strNumero" FilterControlAltText="Filter column1 column" HeaderText="Tarjeta" UniqueName="column1">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Cliente_strPrimerNombre" FilterControlAltText="Filter column2 column" HeaderText="Nombre" UniqueName="column2">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Cliente_strApellidoPaterno" FilterControlAltText="Filter column3 column" HeaderText="Ap. Paterno" UniqueName="column3">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Cliente_strApellidoMaterno" FilterControlAltText="Filter column3 column" HeaderText="Ap. Materno" UniqueName="column3">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Cliente_strCorreoElectronico" FilterControlAltText="Filter column5 column" HeaderText="Correo Electrónico" UniqueName="column5">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="TarjetaEstatus_strEstatus" FilterControlAltText="Filter column4 column" HeaderText="Estatus" UniqueName="column4">
                    </telerik:GridBoundColumn>
                    </Columns>
                    <PagerStyle PageSizeControlType="None"></PagerStyle>
                    </MasterTableView>
                    <HeaderStyle BackColor="#2B347A" ForeColor="#fff" Font-Size="12pt" />
                    <PagerStyle ChangePageSizeButtonToolTip="" FirstPageToolTip="Primera página" GoToPageButtonToolTip="Ir a la página" LastPageToolTip="Última página" NextPagesToolTip="Siguiente página" NextPageToolTip="Siguiente página" PagerTextFormat="Cambiar página: {4} &amp;nbsp;página &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;, registro &lt;strong&gt;{2}&lt;/strong&gt; al &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;" PageSizeControlType="None" PageSizeLabelText="" PrevPagesToolTip="Páginas anteriores" PrevPageToolTip="Página anterior" />
                    </telerik:RadGrid>
            </ContentTemplate>
        </asp:UpdatePanel>
       
    </center>
</asp:Content>
