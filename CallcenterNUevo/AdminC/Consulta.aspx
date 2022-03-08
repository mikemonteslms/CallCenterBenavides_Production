<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Consulta.aspx.cs" Inherits="CallcenterNUevo.AdminC.Consulta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <style>
        .RadGrid_Default .rgHeader, .RadGrid_Default th.rgResizeCol, .RadGrid_Default .rgHeaderWrapper {
            background: #2B347A 0 -2300px repeat-x !important;
            color: #fff !important;
            font-size: 12pt !important;
        }
        .RadGrid_Bootstrap .rgHeader, .RadGrid_Bootstrap .rgHeader a {
             background: #2B347A 0 -2300px repeat-x !important;
            color: #fff !important;            
        }
        input[type=text] {
            border: 1px;
            border-style: solid;
            border-color: #495ef1;
            border-radius: 5px;
            width: 300px;
            color: #000000;
        }
        input[type=text]::-webkit-input-placeholder { /* WebKit browsers */
        color: #808080;
        }
        input[type=text]:-moz-placeholder { /* Mozilla Firefox 4 to 18 */
        color: #808080;
        }
        input[type=text]::-moz-placeholder { /* Mozilla Firefox 19+ */
        color: #808080;
        }
        input[type=text]:-ms-input-placeholder { /* Internet Explorer 10+ */
        color: #808080;
        }

        .Texto {
            width: 550px;
            font-family: Arial;
            font-size: 12pt;
            color: #2b347a;
        }

        h3 {
            font-family: Arial;
            color: #2b347a;
        }
        .titulo {
            font-family: Arial;
            font-size: 16pt;
            color: #2B347A;
            margin-left: -100px;
        }

        table {
            border-collapse: collapse;
            border-spacing: 10px 5px;
             height:auto !important;
        }

        .tooltipDemo {
            background: #f70606;
            border-radius: 5px;
            color: #fff !important;
            width: 150px;
            left: 0px;
            top: 0px;
            font-size: 11px;
        }
        input[type=submit] {
            background-color: #f70606;
            color: #fff;
            border: 1px solid #808080;
            font-family: Arial;
            font-size: 12pt;
            border-radius: 10px;
            width: 80px;
         }
        input[type=submit]:hover {
            background-color: #2B347A;            
         }
         .modalDialog {
            position: fixed;
            font-family: Arial, Helvetica, sans-serif;
            top: 0;
            right: 0;
            bottom: 0;
            left: 0;
            background: rgba(0,0,0,0.8);
            z-index: 99999;
            -webkit-transition: opacity 400ms ease-in;
            -moz-transition: opacity 400ms ease-in;
            transition: opacity 400ms ease-in;
            display: none;
            /*pointer-events: none;*/

        }

        /*.modalDialog:target {
            display: block;
            pointer-events: auto;
        }*/

        .modalDialog > div {
            width: 400px;
            position: relative;
            margin: 10% auto;
            padding: 5px 20px 13px 20px;
            border-radius: 10px;
            background: #fff;
            background: -moz-linear-gradient(#fff, #999);
            background: -webkit-linear-gradient(#fff, #999);
            background: -o-linear-gradient(#fff, #999);
            z-index: 999999;
        }
    </style>
    <center><br /><br />
        <div id="title" class="titulo">Búsqueda de cupón</div><br /><br />
        <asp:Panel ID="pnlBusqueda" runat="server" GroupingText="" Width="650px">
            <div style="width:600px;">
                <asp:TextBox ID="txtBuscar" runat="server" MaxLength="13"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="fteBuscar" runat="server" FilterType="Numbers"
                                                                TargetControlID="txtBuscar">
                 </cc1:FilteredTextBoxExtender>
                <asp:Button ID="btnBuscar" runat="server" style="float:right; width:170px" Text="Buscar" OnClick="btnBuscar_Click"/><br /><br />             
            </div>
        </asp:Panel>
                 
                <asp:Panel ID="pnlResultados" runat="server" Visible="false" >
                    <telerik:RadGrid runat="server"  ID="rgResultado" AutoGenerateColumns="false" Skin="Bootstrap" CellSpacing="-1" GridLines="Both" AllowPaging="True" Culture="es-MX" OnPageIndexChanged="rgResultado_PageIndexChanged">
                        <GroupingSettings CollapseAllTooltip="Collapse all groups"  />
                        <MasterTableView NoMasterRecordsText="No hay información para mostrar">
                            <Columns>                                
                                <telerik:GridBoundColumn DataField="Cupón" FilterControlAltText="Filter column1 column" HeaderText="Cupón" UniqueName="column1">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="TipoCupon" FilterControlAltText="Filter column2 column" HeaderText="TipoCupon" UniqueName="column2">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="IdPromo" FilterControlAltText="Filter column2 column" HeaderText="ID Promo" UniqueName="column2">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Nombre promoción" ItemStyle-Width="150px" FilterControlAltText="Filter column3 column" HeaderText="Nombre promoción" UniqueName="column3">
                                </telerik:GridBoundColumn>  
                                <telerik:GridBoundColumn DataField="Mensaje" ItemStyle-Height="80px" ItemStyle-Width="400px" FilterControlAltText="Filter column4 column" HeaderText="Mensaje (POS)" UniqueName="column4">
                                </telerik:GridBoundColumn>   
                                <telerik:GridBoundColumn DataField="Sucursal"  FilterControlAltText="Filter column5 column" HeaderText="Sucursal" UniqueName="column5">
                                </telerik:GridBoundColumn>  
                                <telerik:GridBoundColumn DataField="Estatus"   FilterControlAltText="Filter column6 column" HeaderText="Estatus" UniqueName="column6">
                                </telerik:GridBoundColumn> 
                                <telerik:GridBoundColumn DataField="Uso único"  ItemStyle-Width="170px" FilterControlAltText="Filter column6 column" HeaderText="Uso único" UniqueName="column6">
                                </telerik:GridBoundColumn>  
                                <telerik:GridBoundColumn DataField="Asignaciones"  FilterControlAltText="Filter column7 column" HeaderText="Asignaciones" UniqueName="column7">
                                </telerik:GridBoundColumn> 
                                <telerik:GridBoundColumn DataField="Fecha solicitud"  FilterControlAltText="Filter column8 column" HeaderText="Fecha solicitud" UniqueName="column8">
                                </telerik:GridBoundColumn> 
                                <telerik:GridBoundColumn DataField="Fecha fin"  FilterControlAltText="Filter column9 column" HeaderText="Fecha fin" UniqueName="column9">
                                </telerik:GridBoundColumn> 
                                <telerik:GridBoundColumn DataField="Usuario alta" FilterControlAltText="Filter column10 column" HeaderText="Usuario alta" UniqueName="column10">
                                </telerik:GridBoundColumn> 
                            </Columns>
                        </MasterTableView>
                        <HeaderStyle BackColor="#2B347A" ForeColor="#fff" Font-Size="12pt" />
                    </telerik:RadGrid>
                </asp:Panel>
                <asp:Panel ID="pnlSinInfo" runat="server">
                    <h3>No se encontro información</h3>
                </asp:Panel>
    </center>
</asp:Content>
