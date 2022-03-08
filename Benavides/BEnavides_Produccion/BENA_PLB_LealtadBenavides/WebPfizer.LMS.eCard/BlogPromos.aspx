<%@ Page Title="" Language="C#" MasterPageFile="~/NBenavidesMaster.Master" AutoEventWireup="true" CodeBehind="BlogPromos.aspx.cs" Inherits="WebPfizer.LMS.eCard.BlogPromos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <style type="text/css">
    #titulo
    {
        margin: 12pt 0 0 0;
        font: 16pt FuturaStd-Bold;
        color: #666666;       
    }
</style>
<div style="width:100%; margin-left: 15px; margin-right: 15px;height:450px; overflow:auto">
   <div id="titulo">Mis notificaciones</div>
   <div style="height:15px;"></div>
   <div style="border-color: transparent; border-style: none; border-width: 0px; width: 600px; height: 385px; overflow: auto; ">  
        <asp:Table ID="tblProducts" runat="server">                            
        </asp:Table>
   </div>
</div>
</asp:Content>
