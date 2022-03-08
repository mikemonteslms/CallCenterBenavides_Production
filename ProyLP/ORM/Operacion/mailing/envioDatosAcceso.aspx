<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="envioDatosAcceso.aspx.cs" Inherits="ORMOperacion.mailing.envioDatosAcceso" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:Panel ID="pnlQuery" runat="server" Height="160" Width="700" ScrollBars="Auto"
        Wrap="true" CssClass="txtQuery">
        Inicio
        <span class="cuadro_texto3">
            <asp:TextBox ID="txtInicio" runat="server" Width="40px"></asp:TextBox>
        </span>
        Fin
        <span class="cuadro_texto3">
            <asp:TextBox ID="txtFin" runat="server" Width="40px"></asp:TextBox>
        </span>
        <asp:Button ID="btnEnviar" CssClass="boton" runat="server" Text="Enviar" OnClick="btnEnviar_Click" />
        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
    </asp:Panel>
</asp:Content>
