<%@ Page Title="" Language="C#" MasterPageFile="~/contenido.Master" AutoEventWireup="true" CodeBehind="registrar-gsf.aspx.cs" Inherits="ORMOperacion.registrar.registrar_gsf" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head_contenido" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body_contenido" runat="server">
Agregar GSF
    <div style="height:800px; width: 1200px; overflow: scroll">
    <asp:GridView id="gvGSF" runat="server" AutoGenerateColumns="true"></asp:GridView>
        </div>
    <asp:Button id="btnInsertar" runat="server" Text="Agregar" OnClick="btnInsertar_Click" />
    <asp:Button id="btnExportar" runat="server" Text="Exportar" OnClick="btnExportar_Click" />
</asp:Content>
