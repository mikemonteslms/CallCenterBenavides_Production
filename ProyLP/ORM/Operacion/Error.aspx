<%@ Page Title="" Language="C#" MasterPageFile="~/SiteError.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="ORMOperacion.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
    <div style="position:relative; top: 50px; width: 800px; text-align:center">
        <asp:Label ID="Label1" runat="server" CssClass="texto14 negrita">¡Ocurri&oacute; un error inesperado!</asp:Label>
        <br />
        <asp:Label runat="server" CssClass="texto14 negrita" ID="lbl404" Text="La p&aacute;gina solicitada o recurso no fue encontrado." />
        <asp:Label runat="server" CssClass="texto14 negrita" ID="lbl408" Text="La solicitud ha agotado el tiempo. Esto puede ser causado por un tr&aacute;fico demasiado alto. Por favor int&eacute;ntelo de nuevo m&aacute;s tarde." />
        <asp:Label runat="server" CssClass="texto14 negrita" ID="lbl505" Text="El servidor encontr&oacute; una condici&oacute;n inesperada que le impidi&oacute; cumplir con la solicitud. Por favor int&eacute;ntelo de nuevo m&aacute;s tarde." />
        <asp:Label runat="server" CssClass="texto14 negrita" ID="lblError" Visible="false" Text="Hubo algunos problemas de procesamiento de su solicitud." />
        <br />
        <br />        
        <asp:LinkButton ID="lnkSesion" runat="server" CssClass="texto14 negrita" OnClick="lnkSesion_Click">Iniciar nueva sesi&oacute;n.</asp:LinkButton>        
    </div>
    </center>
</asp:Content>
