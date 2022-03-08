<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReporteAsistencias.aspx.cs" Inherits="WebPfizer.LMS.eCard.ReporteAsistencias" %>

<%@ MasterType VirtualPath="~/Site.Master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <title>Registro de Visitas por usuario</title>
    <link href="EstilosBenavides.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="Calendar.css" rel="stylesheet" type="text/css" media="screen" />
<center>
    <div id="fondo" style="background-image: url(Imagenes_Benavides/acceso-registro-header.jpg);
            width: 1010px; height: auto; background-repeat: no-repeat;">
            <br />
                <br />
                <br />
                <br />
               
            <asp:Panel ID="Panel2" runat="server" BackImageUrl="~/Imagenes_Benavides/SaldoMov-fondo.png"
                    Height="600px" CssClass="panelReportes">
                <table style="font-weight:bold">
                    <tr>
                        <td></td>
                        <td class="Etiqueta">Usuario:</td>
                        <td><asp:TextBox ID="txtTarjeta" runat="server"></asp:TextBox></td>
                        <td><asp:ImageButton ID="btnSaldoMovBuscar" runat="server" Height="35px" ImageUrl="~/Imagenes_Benavides/botones/search.png"
                                    ToolTip="Validar Tarjeta" Width="35px" ImageAlign="AbsBottom" 
                                onclick="btnSaldoMovBuscar_Click" />&nbsp;&nbsp;<a href="Home.aspx" style="display:none"><img src="../Imagenes_Benavides/botones/undo.png" Height="30px" Width="30px" border="0"/></a>
                                </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="Etiqueta">
                            Fecha Inicio:</td>
                        <td class="Etiqueta">
                            Mes:
                            <asp:DropDownList ID="ddlMesI" runat="server">
                                <asp:ListItem Text="Enero" Value="01"></asp:ListItem>
                                <asp:ListItem Text="Febrero" Value="02"></asp:ListItem>
                                <asp:ListItem Text="Marzo" Value="03"></asp:ListItem>
                                <asp:ListItem Text="Abril" Value="04"></asp:ListItem>
                                <asp:ListItem Text="Mayo" Value="05"></asp:ListItem>
                                <asp:ListItem Text="Junio" Value="06"></asp:ListItem>
                                <asp:ListItem Text="Julio" Value="07"></asp:ListItem>
                                <asp:ListItem Text="Agosto" Value="08"></asp:ListItem>
                                <asp:ListItem Text="Septiembre" Value="09"></asp:ListItem>
                                <asp:ListItem Text="Octubre" Value="10"></asp:ListItem>
                                <asp:ListItem Text="Noviembre" Value="11"></asp:ListItem>
                                <asp:ListItem Text="Diciembre" Value="12"></asp:ListItem>
                            </asp:DropDownList>
                            &nbsp; Año:
                            <asp:DropDownList ID="ddlAnioI" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="Etiqueta">
                            Fecha Final:</td>
                        <td class="Etiqueta">
                            Mes:
                            <asp:DropDownList ID="ddlMesF" runat="server">
                                <asp:ListItem Text="Enero" Value="01"></asp:ListItem>
                                <asp:ListItem Text="Febrero" Value="02"></asp:ListItem>
                                <asp:ListItem Text="Marzo" Value="03"></asp:ListItem>
                                <asp:ListItem Text="Abril" Value="04"></asp:ListItem>
                                <asp:ListItem Text="Mayo" Value="05"></asp:ListItem>
                                <asp:ListItem Text="Junio" Value="06"></asp:ListItem>
                                <asp:ListItem Text="Julio" Value="07"></asp:ListItem>
                                <asp:ListItem Text="Agosto" Value="08"></asp:ListItem>
                                <asp:ListItem Text="Septiembre" Value="09"></asp:ListItem>
                                <asp:ListItem Text="Octubre" Value="10"></asp:ListItem>
                                <asp:ListItem Text="Noviembre" Value="11"></asp:ListItem>
                                <asp:ListItem Text="Diciembre" Value="12"></asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;Año:
                            <asp:DropDownList ID="ddlAnioF" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="4">&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:GridView ID="gvwResultado" runat="server" AutoGenerateColumns="False" 
                                AllowPaging="true" PageSize="20" Width="450px" 
                                onpageindexchanging="gvwResultado_PageIndexChanging">
                                <AlternatingRowStyle BackColor="#D2D6D9" />
                                <HeaderStyle BackColor="#326FA6" ForeColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="Usuario" HeaderText="Usuario" />
                                    <asp:BoundField DataField="Fecha" DataFormatString="{0:dd/MMMM/yyyy}" 
                                        HeaderText="Fecha" />
                                    <asp:BoundField DataField="Fecha" DataFormatString="{0:hh:mm:ss}" 
                                        HeaderText="Hora" />
                                </Columns>
                            </asp:GridView>    
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
</center>
</asp:Content> 
