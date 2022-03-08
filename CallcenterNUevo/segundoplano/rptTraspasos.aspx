<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rptTraspasos.aspx.cs" Inherits="CallcenterNUevo.segundoplano.rptTraspasos" %>
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
            font-family: Arial Narrow;
            font-size: 12pt;
            color:#2B347A;
        }
        .titulo
        {
            font-family: Arial;
            font-size: 16pt;
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
<div id="fondo" style="background-image: url(Imagenes_Benavides/acceso-registro-header.jpg);
            width: 1010px; height: 100%; background-repeat: no-repeat;">
            <br /><br /><br />
            <asp:Panel ID="Panel2" runat="server" >
                 <asp:UpdatePanel ID="uppReportes" runat="server">
                    <ContentTemplate>
                <div>
                    <span class="titulo">Archivo de Texto FTP Traspasos</span><br /><br />
                </div>
                <div>
                    <!--<span class="fuenteReporte">Reporte actualizado el día <asp:Label ID="lblFecha" runat="server" Text=""></asp:Label></span>-->
                  <div style="float:right;"> <asp:Button ID="btnGenerar" runat="server" OnClick="btnGenerar_Click" Text="Generar archivo" /></div> 
                </div><br /><br />   
                        </ContentTemplate>
                    </asp:UpdatePanel>         
            <asp:UpdateProgress ID="uprReportes" runat="server" AssociatedUpdatePanelID="uppReportes">
                <ProgressTemplate>
                    <div class="overlay" />
                    <div class="overlayContent">
                        <img src="~/Images/aero_light.gif" alt="Procesando" border="1" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
        </asp:Panel>
    </div>
        </center>
</asp:Content>
