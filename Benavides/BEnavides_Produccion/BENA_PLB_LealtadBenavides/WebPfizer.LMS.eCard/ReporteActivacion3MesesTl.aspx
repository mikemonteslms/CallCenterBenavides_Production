<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReporteActivacion3MesesTl.aspx.cs" Inherits="WebPfizer.LMS.eCard.ReporteActivacion3MesesTl" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <script>
        (function (i, s, o, g, r, a, m) {
            i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                (i[r].q = i[r].q || []).push(arguments)
            }, i[r].l = 1 * new Date(); a = s.createElement(o),
  m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
        })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

        ga('create', 'UA-43180890-1', 'beneficiointeligente.com.mx');
        ga('send', 'pageview');
    </script>
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
        .fuenteReporte
        {
            color: #004A99;
            font-family: Arial;
            font-size: 16pt;
        }
        .titulo
        {
            font-family: Arial;
            font-size: 16pt;
            color: #004A99;
            vertical-align: text-top;
        }
    </style>
    <title>Reporte de Activación</title>
    <link href="EstilosBenavides.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="Calendar.css" rel="stylesheet" type="text/css" media="screen" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>

        <asp:UpdatePanel ID="uppReportes" runat="server">
            <ContentTemplate>

                <asp:HiddenField ID="hdfSucursalNombre" runat="server" />
                <asp:HiddenField ID="hdfSucursal" runat="server" />
                <asp:HiddenField ID="hdfMes" runat="server" />
                <asp:HiddenField ID="hdfAnio" runat="server" />
                <asp:HiddenField ID="hdfLeyendaMes1" runat="server" />
                <asp:HiddenField ID="hdfLeyendaMes2" runat="server" />
                <asp:HiddenField ID="hdfLeyendaMes3" runat="server" />

                <div style="padding: 0px 160px;">
                    <div id="fondo" style="background-image: url(Imagenes_Benavides/acceso-registro-header.jpg);
                        width: 1010px; height: 100%; background-repeat: no-repeat;">
                        <table width="100%">
                            <tr>
                                <td align="right">
                                    <asp:ImageButton ID="btnCerrarSesion" runat="server" 
                                        ImageUrl="~/Imagenes_Benavides/botones/cerrarsesion-btn.jpg" 
                                        onclick="btnCerrarSesion_Click"/>
                                </td>
                            </tr>
                        </table>
                        <br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
                        <asp:Panel ID="pnlReporteActivaciones" runat="server" BackColor="#EBEBEB" Height="100%">
                            <div style="padding: 20px 50px;">
                                <asp:Label ID="lblTutulo" runat="server" CssClass="titulo" Height="50px" Text="Reporte de activación en una sucursal por periodo"></asp:Label>
                                <br />
                                <asp:Label ID="lblSucursalFiltro" runat="server" CssClass="titulo" Height="30px" Text="Sucursal filtro:"></asp:Label>
                                <br />
                                <telerik:RadTabStrip ID="rTbsSeleccionFiltro" runat="server" MultiPageID="rMlpSeleccionFiltro" CssClass="fuenteReporte"
                                    SelectedIndex="0" Width="500px">
                                    <Tabs>
                                        <telerik:RadTab Text="Sap - Sucursal" CssClass="fuenteReporte" Width="200"></telerik:RadTab>
                                        <telerik:RadTab Text="Ubicación" CssClass="fuenteReporte" Width="200"></telerik:RadTab>
                                    </Tabs>
                                </telerik:RadTabStrip>
                                <telerik:RadMultiPage runat="server" ID="rMlpSeleccionFiltro"  SelectedIndex="0">
                                    <telerik:RadPageView runat="server" ID="rPgvSapSucursal">
                                        <div style="width: 600px; height: 70px; vertical-align: middle; padding: 20px 20px; position: relative; background-color: #C0C0C0;">
                                            <asp:Label ID="lblSapSucursal" runat="server" CssClass="titulo" Text="Sap - Sucursal" width="700px"></asp:Label>
                                            <br /><br />
                                            <telerik:RadComboBox RenderMode="Lightweight" ID="rcbScucursales" 
                                                AllowCustomText="true" runat="server" AutoPostBack="true"
                                                Width="300px" Height="400px" Filter="Contains"                                            
                                                DataTextField="Sucursal_strNombre" EmptyMessage="Seleccione sucursal..." 
                                                onselectedindexchanged="rcbScucursales_SelectedIndexChanged">
                                            </telerik:RadComboBox>
                                        </div>
                                    </telerik:RadPageView><telerik:RadPageView runat="server" ID="rPgvUbicacion">
                                        <div style="width: 600px; height: 70px; padding: 20px 20px; background-color: #C0C0C0;">
                                            <asp:Label ID="lblUbicacion" runat="server" CssClass="titulo" Text="Ubicación" width="700px"></asp:Label>
                                            <br /><br />
                                            <telerik:RadComboBox RenderMode="Lightweight" ID="rCbxRegion" runat="server" Width="186px"
                                                AutoPostBack="true" EmptyMessage="- Seleciona una Región -"
                                                OnSelectedIndexChanged="rCbxRegion_SelectedIndexChanged"></telerik:RadComboBox>
                                            <telerik:RadComboBox RenderMode="Lightweight" ID="rCbxZona" runat="server" Width="186px"
                                                AutoPostBack="true" EmptyMessage="- Seleciona una Zona -"
                                                OnSelectedIndexChanged="rCbxZona_SelectedIndexChanged"></telerik:RadComboBox>
                                            <telerik:RadComboBox RenderMode="Lightweight" ID="rCbxSucursalUbicacion" runat="server" Width="220px"
                                                AutoPostBack="true" EmptyMessage="- Seleciona una Sucursal -"
                                                onselectedindexchanged="rCbxSucursalUbicacion_SelectedIndexChanged" ></telerik:RadComboBox>
                                        </div>
                                    </telerik:RadPageView>
                                </telerik:RadMultiPage>
                                <br />
                                <asp:Label ID="lblPeriodo" runat="server" CssClass="titulo" Height="30px" Text="Periodo:"></asp:Label>
                                <%--<h2>Periodo:</h2>--%>
                                <div style="padding: 0px 20px; ">
                                    <asp:Label ID="lblMes" runat="server"  CssClass="titulo" Text="Mes:" Width="100px"></asp:Label>
                                    <asp:Label ID="lblAnio" runat="server" CssClass="titulo" Text="Año:" Width="100px"></asp:Label>
                                    <br />
                                    <asp:DropDownList ID="ddlMes" runat="server" AutoPostBack="true" Width="100px"
                                        onselectedindexchanged="ddlMes_SelectedIndexChanged" ></asp:DropDownList>
                                    <asp:DropDownList ID="ddlAnio" runat="server" AutoPostBack="true" Width="100px"
                                        onselectedindexchanged="ddlAnio_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                                <br />
                                <div>
                                    <asp:Button ID="btnGeneraReporte" runat="server" Text="Genera Reporte" 
                                        CssClass="Etiqueta" onclick="btnGeneraReporte_Click" />
                                    <asp:Button ID="btnExportaReporte" runat="server" Text="Exporta Excel" 
                                        CssClass="Etiqueta" onclick="btnExportaReporte_Click" />
                                    <asp:ImageButton ID="btnCancelar" runat="server" Height="30px" 
                                        ImageUrl="~/Imagenes_Benavides/botones/undo.png" Width="30px" 
                                        onclick="btnCancelar_Click" />
                                </div>
                                <br /><br />
                                <div>
                                    <telerik:RadGrid RenderMode="Lightweight" ID="rGrdActivaciones" runat="server" 
                                        Width="845px" Height="500px"
                                        AllowPaging="True" AllowSorting="True"
                                        AllowFilteringByColumn="false" CellSpacing="0" GridLines="None" 
                                        PageSize="31" onsortcommand="rGrdActivaciones_SortCommand" >
                                        <ClientSettings>
                                            <Scrolling AllowScroll="True" ScrollHeight="400px" UseStaticHeaders="true" />
                                        </ClientSettings>
                                        <MasterTableView ShowFooter="True" AutoGenerateColumns="False" >
                                            <ColumnGroups>
                                                <telerik:GridColumnGroup Name="Azul" HeaderText="BI AZUL"
                                                    HeaderStyle-HorizontalAlign="Center" />
                                                <telerik:GridColumnGroup Name="Platino" HeaderText="BI PLATINO"
                                                    HeaderStyle-HorizontalAlign="Center" />
                                                <telerik:GridColumnGroup Name="Total" HeaderText="TOTAL ACTIVACIONES"
                                                    HeaderStyle-HorizontalAlign="Center" />
                                            </ColumnGroups>
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="Dias" HeaderText="DIAS" ReadOnly="true"
                                                    ItemStyle-Width="100px" HeaderStyle-Font-Underline="true">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="AZUL_MES_1" HeaderText="" HeaderStyle-Font-Underline="true"
                                                    ReadOnly="true" ColumnGroupName="Azul" ItemStyle-ForeColor="Blue"
                                                    Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="AZUL_MES_2" HeaderText="" HeaderStyle-Font-Underline="true"
                                                    ReadOnly="true" ColumnGroupName="Azul" ItemStyle-ForeColor="Blue"
                                                    Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="AZUL_MES_ACTUAL" HeaderText="" HeaderStyle-Font-Underline="true"
                                                    ReadOnly="true" ColumnGroupName="Azul" ItemStyle-ForeColor="Blue"
                                                    Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="PLATINO_MES_1" HeaderText="" HeaderStyle-Font-Underline="true"
                                                    ReadOnly="true" ColumnGroupName="Platino" ItemStyle-ForeColor="#FF8040"
                                                    Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="PLATINO_MES_2" HeaderText="" HeaderStyle-Font-Underline="true"
                                                    ReadOnly="true" ColumnGroupName="Platino" ItemStyle-ForeColor="#FF8040"
                                                    Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="PLATINO_MES_ACTUAL" HeaderText="" HeaderStyle-Font-Underline="true"
                                                    ReadOnly="true" ColumnGroupName="Platino" ItemStyle-ForeColor="#FF8040"
                                                    Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="TOTAL_MES_1" HeaderText="" HeaderStyle-Font-Underline="true"
                                                    ReadOnly="true" ColumnGroupName="Total" ItemStyle-ForeColor="Green"
                                                    Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="TOTAL_MES_2" HeaderText="" HeaderStyle-Font-Underline="true"
                                                    ReadOnly="true" ColumnGroupName="Total" ItemStyle-ForeColor="Green"
                                                    Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="TOTAL_MES_ACTUAL" HeaderText="" HeaderStyle-Font-Underline="true"
                                                    ReadOnly="true" ColumnGroupName="Total" ItemStyle-ForeColor="Green"
                                                    Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                                </telerik:GridBoundColumn>
                                            </Columns>
                                        </MasterTableView>
                                    </telerik:RadGrid>
                                </div>
                                <br /><br /><br />
                            </div>
                        </asp:Panel>
                    </div>
                </div>

                <asp:UpdateProgress ID="uprReportes" runat="server" AssociatedUpdatePanelID="uppReportes">
                    <ProgressTemplate>
                        <div class="overlay" />
                        <div class="overlayContent">
                            <img src="Images/aero_light.gif" alt="Procesando" border="1" />
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>