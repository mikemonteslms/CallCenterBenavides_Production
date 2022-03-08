<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroLLamadas.aspx.cs" Inherits="WebPfizer.LMS.eCard.RegistroLLamadas" %>

<%@ MasterType VirtualPath="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 <title>Registro de Llamadas</title>
    <link href="EstilosBenavides.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="Calendar.css" rel="stylesheet" type="text/css" media="screen" />
<center>
   <div id="fondo" style="background-image: url(Imagenes_Benavides/acceso-registro-header.jpg); width: 1010px; height: auto; background-repeat:no-repeat;" >
    <center> 
        <br />
        <br />
        <table style="width: 533px">
            <tr>
                <td align="left" colspan="2">
                        <asp:Label ID="lblRegistro" runat="server" Text="Registro de Llamadas" 
                            Font-Bold="True" Font-Size="16pt" ForeColor="#004A99" Font-Names="Arial" ></asp:Label></td>
            </tr>
            <tr>
                <td colspan="2" align="left">
                    <asp:Label ID="Label1" runat="server" Text="Son obligatorios los datos marcados con " ForeColor="#777E7F" Font-Names="Arial"></asp:Label><font color="#777E7F">(</font><font color="#E42313"><b>*</b></font><font color="#777E7F">)</font></td>
            </tr>
            <tr>
                <td align="left" colspan="2">
                    <asp:Label ID="lblTarjeta" runat="server" Text="No. de Tarjeta:" 
                        Font-Bold="True" ForeColor="#004A99" Font-Names="Arial" Font-Size="10pt"></asp:Label>
                                            <font color="#004A99">(</font><font color="#E42313"><b>*</b></font><font color="#004A99">)</font><asp:TextBox 
                        ID="txtTarjeta" runat="server" CssClass="Texto" MaxLength="19" ToolTip="Ingrese el número de Tarjeta"
                                                Width="140px"></asp:TextBox>
                        <asp:Label ID="lblTipo" runat="server" Text="Tipo Llamada:" ForeColor="#004A99" 
                            CssClass="Etiqueta" Font-Bold="True"></asp:Label>
                                            <asp:DropDownList ID="cmbTipoLlamada" runat="server" Width="156px" AutoPostBack="True" OnSelectedIndexChanged="cmbTipoLlamada_SelectedIndexChanged">
                                            </asp:DropDownList>
                        </td>
            </tr>
            <tr>
                <td align="left" colspan="2">
                        <asp:Label ID="lblQuien" runat="server" Text="Quien Llama:" 
                        ForeColor="#004A99" Font-Names="Arial" Font-Size="10pt" Font-Bold="True" 
                            Visible="False"></asp:Label>
                                            <asp:DropDownList ID="cmbQuienLlama" runat="server" 
                            Width="140px" Visible="False">
                                            </asp:DropDownList>
                        <asp:Label ID="lblExterior" runat="server" Text="SubTipo de Llamada:" 
                            ForeColor="#004A99" CssClass="Etiqueta" Font-Bold="True"></asp:Label>
                                            <asp:DropDownList ID="cmbSubTipoLlamada" runat="server" 
                            Width="140px">
                                            </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="left">
                        <asp:Label ID="lblSucursal" runat="server" Text="Sucursal:" ForeColor="#004A99" 
                            CssClass="Etiqueta" Font-Bold="True" Font-Names="Arial"></asp:Label><span
                            style="color: #004a99">(</span><font color="#E42313"><b>*</b></font><font color="#004A99">)</font>
                                            <asp:DropDownList ID="cmbSucursal" runat="server" CssClass="Combo" ToolTip="Seleccione la Sucursal"
                                                Width="160px">
                                            </asp:DropDownList>
                        </td>
                <td align="left">
                        &nbsp;</td>
            </tr>
            <tr>
                <td align="left" colspan="2" class="Etiqueta">
                        &nbsp;<asp:Label ID="lblNombre" runat="server" Text="Nombre:" ForeColor="#004A99" 
                            CssClass="Etiqueta" Font-Bold="True" Font-Names="Arial"></asp:Label><span
                            style="color: #004a99">(</span><font color="#E42313"><b>*</b></font><font color="#004A99">)</font>
                                            <asp:TextBox ID="txtNombre" runat="server" CssClass="Texto" 
                            MaxLength="50" Width="140px"></asp:TextBox>
                        <asp:Label ID="lblTelefono" runat="server" Text="Teléfono de Contacto:" 
                            ForeColor="#004A99" CssClass="Etiqueta" Font-Bold="True" Font-Names="Arial"></asp:Label>
                                            <asp:TextBox ID="txtTelefono" runat="server" 
                            CssClass="Texto" MaxLength="30" Width="140px"></asp:TextBox>
                        </td>
            </tr>
            <tr>
                <td align="left" colspan="2">
                        <asp:Label ID="lblTipoComen" runat="server" Text="TIpo Nota/Comentario:" 
                            ForeColor="#004A99" CssClass="Etiqueta" Font-Bold="True" Visible="False"></asp:Label>
                                            <asp:DropDownList ID="cmbTipoComentario" runat="server" 
                            Width="160px" AutoPostBack="True" Visible="False">
                                        </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="left" colspan="2">
                        <asp:Label ID="lblNotas" runat="server" Text="Notas/Comentario:" 
                            ForeColor="#004A99" CssClass="Etiqueta" Font-Bold="True"></asp:Label>
                                            <asp:TextBox ID="txtComentario" runat="server" 
                            CssClass="Texto" Height="60px" MaxLength="200"
                                                TextMode="MultiLine" Width="400px"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="left">
                </td>
                <td align="left">
                
                </td>
              
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:ImageButton ID="btnCancelar" runat="server" 
                        ImageUrl="~/Imagenes_Benavides/botones/cancelar-btn.png" 
                        OnClick="btnCancelar_Click" />
                    &nbsp;
                    &nbsp;&nbsp;
                        <asp:ImageButton ID="btnRegistrar" runat="server" 
                        ImageUrl="~/Imagenes_Benavides/botones/registrar-btn.png" 
                        onclick="btnRegistrar_Click" /></td>
            </tr>
        </table>
    </center>
   </div>
  </asp:Content>  
