<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReporteTickets3MesesTl.aspx.cs" Inherits="WebPfizer.LMS.eCard.ReporteTickets3MesesTl" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
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
            color:#2B347A;
            margin-left: -100px;
        }
        .headerDias
        {
            border: 1px double #808080 !important;
            text-align: center !important;
        }
        .headerAzul
        {
            background-color: #DCE6F4 !important;
            background-image: none !important;
            color: #17178B !important;
            border: 1px double #808080 !important;
            text-align: center !important;
        }
        .headerGris
        {
            background-image: none !important;
            color: #877E7B !important;
            border: 1px double #808080 !important;
            text-align: center !important;
        }
        .headerVerde
        {
            background-color: #80FF80 !important;
            background-image: none !important;
            color: Green !important;
            border: 1px double #808080 !important;
            text-align: center !important;
        }
         .itemAzul
        {
            color: Blue !important;
            text-align: center !important;
            width: 62px !important;
        }
        .itemGris
        {
            color: #877E7B !important;
            text-align: center !important;
            width: 62px !important;
        }
        .itemVerde
        {
            color: Green !important;
            text-align: center !important;
            width: 62px !important;
        }
        .divTitulo
        {
            width: 100%;
            position: relative;
            text-align:center;
        }
    </style>
    <script type="text/javascript">
        function ActivaCombo(Valor) {
            alert(Valor);
        }
    </script>
    
    <link href="EstilosBenavides.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="Calendar.css" rel="stylesheet" type="text/css" media="screen" />
    <center>
        <div class="titulo">Reporte de Tickets</div>
        <asp:UpdatePanel ID="uppReportes" runat="server">
            <ContentTemplate>

                <asp:HiddenField ID="hdfTitulo" runat="server" />
                <asp:HiddenField ID="hdfRegion" runat="server" />
                <asp:HiddenField ID="hdfZona" runat="server" />
                <asp:HiddenField ID="hdfSucursal" runat="server" />
                <asp:HiddenField ID="hdfMes" runat="server" />
                <asp:HiddenField ID="hdfAnio" runat="server" />
                <asp:HiddenField ID="hdfLeyendaMes1" runat="server" />
                <asp:HiddenField ID="hdfLeyendaMes2" runat="server" />
                <asp:HiddenField ID="hdfLeyendaMes3" runat="server" />

                <div style="padding: 0px 160px;">
                    <div id="fondo" style="background-image: url(Imagenes_Benavides/acceso-registro-header.jpg);
                        width: 1010px; height: 100%; background-repeat: no-repeat;">                        
                        <br /><br />
                        <asp:Panel ID="pnlReporteActivaciones" runat="server" Height="100%">
                            <div style="padding: 20px 78px;margin-left:-50px">
                                <asp:Label ID="lblTutulo" runat="server" CssClass="titulo" style="margin-left:-270px" Height="50px" Text="TICKETS POR TRIMESTRE"></asp:Label>
                                <br /><br />
                                <div  style="margin-left:-270px" >
                                    <telerik:RadButton RenderMode="Lightweight" ID="rRbtRegion" runat="server" ToggleType="Radio"
                                        ButtonType="ToggleButton" AutoPostBack="true" Width="20" Height="20" GroupName="filtro"
                                        Checked="true" OnClick="Button_Click">
                                    </telerik:RadButton>
                                    <asp:Label ID="lblRegion" runat="server" CssClass="Etiqueta" Text="REGIÓN: " Width="90px"></asp:Label>
                                    <telerik:RadComboBox RenderMode="Lightweight" ID="rCbxRegion"
                                        AllowCustomText="true" runat="server" AutoPostBack="true"
                                        Width="300px" Filter="Contains" Enabled="false"
                                        DataTextField="Region_strID" EmptyMessage="- Seleciona una Región -"
                                        OnSelectedIndexChanged="rCbxRegion_SelectedIndexChanged"></telerik:RadComboBox>
                                    <br>
                                    <br>
                                    <telerik:RadButton RenderMode="Lightweight" ID="rRbtZona" runat="server" ToggleType="Radio"
                                        ButtonType="ToggleButton" AutoPostBack="true" Width="20" Height="20" GroupName="filtro"
                                        OnClick="Button_Click">   
                                    </telerik:RadButton>
                                    <asp:Label ID="lblZona" runat="server" CssClass="Etiqueta" Text="ZONA: " Width="90px"></asp:Label>
                                    <telerik:RadComboBox RenderMode="Lightweight" ID="rCbxZona"
                                        AllowCustomText="true" runat="server" AutoPostBack="true"
                                        Width="300px" Filter="Contains" Enabled="false"
                                        DataTextField="Zona_strID" EmptyMessage="- Seleciona una Zona -"
                                        OnSelectedIndexChanged="rCbxZona_SelectedIndexChanged"></telerik:RadComboBox>
                                    <br>
                                    <br>
                                    <telerik:RadButton RenderMode="Lightweight" ID="rRbtSucursal" runat="server" ToggleType="Radio"
                                        ButtonType="ToggleButton" AutoPostBack="true" Width="20" Height="20" GroupName="filtro"
                                        OnClick="Button_Click">
                                    </telerik:RadButton>
                                    <asp:Label ID="lblSucursal" runat="server" CssClass="Etiqueta" Text="SUCURSAL: " Width="90px"></asp:Label>
                                    <telerik:RadComboBox RenderMode="Lightweight" ID="rcbScucursales" 
                                        AllowCustomText="true" runat="server" AutoPostBack="true"
                                        Width="300px" Height="400px" Filter="Contains" Enabled="false"                                 
                                        DataTextField="Sucursal_strNombre" EmptyMessage="- Seleccione sucursal -" 
                                        OnSelectedIndexChanged="rcbScucursales_SelectedIndexChanged">
                                    </telerik:RadComboBox>
                                </div>
                                <br />
                                <br />
                                <div style="padding: 0px 0px; ">
                                    <asp:Label ID="lblMes" runat="server"  CssClass="titulo" style="margin-left: -475px;" Text="Mes:" Width="100px"></asp:Label>
                                    <asp:Label ID="lblAnio" runat="server" CssClass="titulo" style="margin-left: 0px;" Text="Año:" Width="100px"></asp:Label>
                                    <br />
                                    <asp:DropDownList ID="ddlMes" runat="server" AutoPostBack="true" Width="100px"
                                        onselectedindexchanged="ddlMes_SelectedIndexChanged" ></asp:DropDownList>
                                    <asp:DropDownList ID="ddlAnio" runat="server" AutoPostBack="true" Width="100px"
                                        onselectedindexchanged="ddlAnio_SelectedIndexChanged"></asp:DropDownList>
                                    <asp:Label ID="lblEspacio" runat="server" Text="" Width="100px"></asp:Label>
                                    <asp:Button ID="btnGeneraReporte" runat="server" Text="GENERAR REPORTE"
                                        CssClass="Etiqueta" onclick="btnGeneraReporte_Click" />
                                    <asp:Button ID="btnExportaReporte" runat="server" Text="EXPORTAR A EXCEL"
                                        CssClass="Etiqueta" onclick="btnExportaReporte_Click" />
                                    <asp:ImageButton ID="btnCancelar" runat="server" Height="30px" 
                                        ImageUrl="~/Imagenes_Benavides/botones/undo.png" Width="30px" 
                                        onclick="btnCancelar_Click" Visible="false" />
                                </div>
                                <br /><br />
                                <div class="divTitulo">
                                    <asp:Label ID="lblTitulo" runat="server" Text="" CssClass="titulo"></asp:Label>
                                </div>
                                <div>
                                    <telerik:RadGrid ID="rGrdActivaciones" runat="server"
                                        Width="845px" Height="500px"
                                        AllowPaging="True" AllowSorting="True"
                                        AllowFilteringByColumn="false" CellSpacing="0" GridLines="None" 
                                        PageSize="31" onsortcommand="rGrdActivaciones_SortCommand" >
                                        <ClientSettings>
                                            <Scrolling AllowScroll="True" ScrollHeight="400px" UseStaticHeaders="true" />
                                        </ClientSettings>
                                        <MasterTableView ShowFooter="True" AutoGenerateColumns="False" >
                                            <ColumnGroups>
                                                <telerik:GridColumnGroup Name="Azul" HeaderText="BI AZUL" HeaderStyle-CssClass="headerAzul"
                                                    HeaderStyle-Font-Bold="true" />
                                                <telerik:GridColumnGroup Name="Platino" HeaderText="BI PLATINO" HeaderStyle-CssClass="headerGris"
                                                    HeaderStyle-Font-Bold="true" />
                                                <telerik:GridColumnGroup Name="Total" HeaderText="TOTAL TICKETS" HeaderStyle-CssClass="headerVerde"
                                                    HeaderStyle-Font-Bold="true" />
                                            </ColumnGroups>
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="Dias" HeaderText="DIAS" ReadOnly="true" HeaderStyle-CssClass="headerDias"
                                                    ItemStyle-Width="47px" HeaderStyle-Font-Underline="true" ItemStyle-HorizontalAlign="Center">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="AZUL_MES_1" HeaderText="" HeaderStyle-CssClass="headerAzul"
                                                    HeaderStyle-ForeColor="#17178B" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Underline="true"
                                                    ReadOnly="true" ColumnGroupName="Azul" ItemStyle-CssClass="itemAzul" DataFormatString="{0:#,##0}"
                                                    Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}" FooterStyle-HorizontalAlign="Center">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="AZUL_MES_2" HeaderText="" HeaderStyle-CssClass="headerAzul"
                                                    HeaderStyle-ForeColor="#17178B" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Underline="true"
                                                    ReadOnly="true" ColumnGroupName="Azul" ItemStyle-CssClass="itemAzul" DataFormatString="{0:#,##0}"
                                                    Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}" FooterStyle-HorizontalAlign="Center">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="AZUL_MES_ACTUAL" HeaderText="" HeaderStyle-CssClass="headerAzul"
                                                    HeaderStyle-ForeColor="#17178B" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Underline="true"
                                                    ReadOnly="true" ColumnGroupName="Azul" ItemStyle-CssClass="itemAzul" DataFormatString="{0:#,##0}"
                                                    Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}" FooterStyle-HorizontalAlign="Center">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="PLATINO_MES_1" HeaderText="" HeaderStyle-CssClass="headerGris"
                                                    HeaderStyle-ForeColor="#877E7B" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Underline="true"
                                                    ReadOnly="true" ColumnGroupName="Platino" ItemStyle-CssClass="itemGris" DataFormatString="{0:#,##0}"
                                                    Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}" FooterStyle-HorizontalAlign="Center">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="PLATINO_MES_2" HeaderText="" HeaderStyle-CssClass="headerGris"
                                                    HeaderStyle-ForeColor="#877E7B" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Underline="true"
                                                    ReadOnly="true" ColumnGroupName="Platino" ItemStyle-CssClass="itemGris" DataFormatString="{0:#,##0}"
                                                    Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}" FooterStyle-HorizontalAlign="Center">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="PLATINO_MES_ACTUAL" HeaderText="" HeaderStyle-CssClass="headerGris"
                                                    HeaderStyle-ForeColor="#877E7B" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Underline="true"
                                                    ReadOnly="true" ColumnGroupName="Platino" ItemStyle-CssClass="itemGris" DataFormatString="{0:#,##0}"
                                                    Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}" FooterStyle-HorizontalAlign="Center">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="TOTAL_MES_1" HeaderText="" HeaderStyle-CssClass="headerVerde"
                                                    HeaderStyle-ForeColor="Green" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Underline="true"
                                                    ReadOnly="true" ColumnGroupName="Total" ItemStyle-CssClass="itemVerde" DataFormatString="{0:#,##0}"
                                                    Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}" FooterStyle-HorizontalAlign="Center">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="TOTAL_MES_2" HeaderText="" HeaderStyle-CssClass="headerVerde"
                                                    HeaderStyle-ForeColor="Green" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Underline="true"
                                                    ReadOnly="true" ColumnGroupName="Total" ItemStyle-CssClass="itemVerde" DataFormatString="{0:#,##0}"
                                                    Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}" FooterStyle-HorizontalAlign="Center">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="TOTAL_MES_ACTUAL" HeaderText="" HeaderStyle-CssClass="headerVerde"
                                                    HeaderStyle-ForeColor="Green" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Underline="true"
                                                    ReadOnly="true" ColumnGroupName="Total" ItemStyle-CssClass="itemVerde" DataFormatString="{0:#,##0}"
                                                    Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}" FooterStyle-HorizontalAlign="Center">
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
                            <img src="../Images/aero_light.gif" alt="Procesando" border="1" />
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </ContentTemplate>
        </asp:UpdatePanel>
     </center>
    </asp:Content>