
<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="CallcenterNUevo.Perfil.Perfil" %>

<%@ Register src="../Controles/HeaderCliente.ascx" tagname="HeaderCliente" tagprefix="uc1" %>
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
        .titulo
        {
            font-family: Arial;
            font-size: 16pt;
            color: #004A99;
        }    
        .fuenteReporte
        {
            font-family: Arial Narrow;
            font-size: 12pt;
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
     <asp:Panel ID="pnlTitulo" runat="server" >
            <div>
                <span class="titulo">Perfil de cliente</span><br /><br />
            </div>
     </asp:Panel>
     <asp:Panel ID="pnlHeader" runat="server">
        <uc1:HeaderCliente ID="HeaderCliente1" runat="server" />
    </asp:Panel>
    <br />
    <asp:Panel ID="pnlInfo" runat="server">
        <table style="width:360px">
            <tr>
                <%--<td class="fuenteReporte" style="font-weight:bold;">¿Inscrito a club peques?</td>--%>
               <%-- <td><asp:Label ID="lblclubPeques" runat="server" CssClass="fuenteReporte" Text="Si" Visible="false" ></asp:Label></td>
                <td style="width:50px"></td>--%>
                <%--<td class="fuenteReporte" style="font-weight:bold;">¿Acepta recibir promoción?</td>--%>
                <td class="fuenteReporte" style="font-weight:bold;">¿Acepta contacto de Correo Electrónico?</td>
                <td><asp:Label ID="lblRecibePromo" runat="server" Text="" CssClass="fuenteReporte"></asp:Label></td>
                <td>&nbsp;&nbsp;&nbsp;<asp:LinkButton runat="server" ID="lnkModRecibPromo" PostBackUrl="~/CALLCENTER/CancelaContactoXPadecimiento.aspx" Text="Modificar" style="color:red;"></asp:LinkButton></td>
            </tr>
        </table>
        <br />
        <table style="width:600px">
             <tr>
                 <td class="fuenteReporte" style="font-weight:bold;">Traspasos</td>
             </tr>
            <tr>
                <td class="fuenteReporte">
                    <asp:Label ID="lblTraspaso" runat="server"></asp:Label>
                </td>
            </tr>
             <tr style="display:none">
                <td class="fuenteReporte" style="font-weight:bold;">Padecimientos</td>
            </tr>
            <tr style="display:none">
                <td class="fuenteReporte">
                    <asp:CheckBoxList ID="chkPadecimientos" runat="server" Enabled="False" DataSourceID="SqlDataSource1" DataTextField="Padecimiento_strDescripcionLarga" DataValueField="Padecimiento_intID" RepeatDirection="Horizontal" RepeatColumns="2" Width="500px"></asp:CheckBoxList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Padecimiento_intID], [Padecimiento_strDescripcionCorta],[Padecimiento_strDescripcionLarga] FROM [tblPadecimiento]
where [Padecimiento_intID] not in (7,8,3)"></asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td><br /></td>
            <tr>
                <td class="fuenteReporte" style="font-weight:bold;">
                    Tarjetas asociadas al correo electrónico registrado.
                </td>
            </tr>
            <tr>
                <td class="fuenteReporte">
                    <asp:Literal ID="ltlTarjeta" runat="server" Text=""></asp:Literal>
                </td>
            </tr>
            <tr>
                <td><br /></td>
            </tr>
            <tr>
                <td class="fuenteReporte" style="font-weight:bold;">Promociones y Descuentos - <a href="Promociones.aspx" target="_self" style="color:red;">Ver</a></td>
            </tr>
            <tr>
                <td class="fuenteReporte">
                    <asp:Literal ID="ltlPromos" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td><br /></td>
            </tr>
            <tr>
                <td class="fuenteReporte" style="font-weight:bold;">Beneficios especiales - <a href="BeneficiosEsp.aspx" target="_self" style="color:red;">Ver</a></td>
            </tr>
            <tr>
                <td class="fuenteReporte">
                    <asp:Literal ID="ltlEspeciales" runat="server"></asp:Literal>
                </td>
            </tr>
        </table>
    </asp:Panel>
</center>
</asp:Content>
