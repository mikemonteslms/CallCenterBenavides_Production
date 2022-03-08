<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TiemposPromedioPOS.aspx.cs" Inherits="CallcenterNUevo.Estadisticas.TiemposPromedioPOS" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../../Scripts/jquery-1.7.1.min.js"></script>
    <script src="../../Scripts/jquery-ui-1.8.20.min.js"></script>
    <link href="cssAdminProm/cssAdminPromocion.css" rel="stylesheet" />
     
     <asp:UpdatePanel id="upTiemposPromedioPOS"  runat="server">
        <ContentTemplate>
            <div id="popReg" style="background-color: #666666; z-index: 1000; left: 0%; position: absolute; top:100px; width:100%; height: 100%;">
                <br /><br />
                        &nbsp;&nbsp;&nbsp;<asp:Label runat="server" ID="lblTitulo" Text="Medición de Procesos POS." Font-Names="Times New Roomans" Font-Size="20px" ForeColor="White"/>
                        <br /><br />
                <center>
                    <div class="modal-content"  style="background-color:#222222; height:480px; Width:1200px;")>
                        <br /><br />
                                             <asp:Label ID="lblAnio" runat="server" Text ="Año:" ForeColor="White"></asp:Label>
                                             &nbsp; &nbsp;<telerik:RadComboBox RenderMode="Lightweight" AllowCustomText="False" AutoPostBack="true" ID="rdcAnio" runat="server" OnSelectedIndexChanged="rdcAnio_SelectedIndexChanged"  Width="130px">
                                            </telerik:RadComboBox>
                                             &nbsp; &nbsp;<asp:Label ID="lblMeses" runat="server" Text ="Mes:" Visible="false" ForeColor="White"></asp:Label>
                                             &nbsp; &nbsp;<telerik:RadComboBox RenderMode="Lightweight" AllowCustomText="False" AutoPostBack="true" ID="rdcMes" runat="server" OnSelectedIndexChanged="rdcMes_SelectedIndexChanged"  Width="130px" Visible="false">
                                            </telerik:RadComboBox>
                        <br />
                        <center>
                            &nbsp;&nbsp;&nbsp;<telerik:RadHtmlChart runat="server" ID="grpTiemposPromedio"  Width="1200" Height="400" >
                                              </telerik:RadHtmlChart>
                        </cente>
                    </div>
                </center>
            </div>
        </ContentTemplate> 
     </asp:UpdatePanel> 
</asp:Content>
