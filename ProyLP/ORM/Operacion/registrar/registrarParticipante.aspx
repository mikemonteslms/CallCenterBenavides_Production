<%@ Page Title="" Language="C#" MasterPageFile="~/contenido.Master" AutoEventWireup="true" CodeBehind="registrarParticipante.aspx.cs" Inherits="ORMOperacion.registrar.registrarParticipante" %>

<%@ Register Assembly="BotonEnviar" Namespace="BotonEnviar" TagPrefix="cc3" %>
<%@ MasterType VirtualPath="~/contenido.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head_contenido" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body_contenido" runat="server">
    <center>
    <div id="rounded-box4">
        <table border="0" width="100%">
            <tr>
                <td align="center">
                    <h4>Registro participantes</h4>
                </td>
            </tr>
            <tr>
                <td>
                    <div>
                        <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="false" Width="50%"
                            OnNeedDataSource="RadGrid1_NeedDataSource" OnItemDataBound="RadGrid1_ItemDataBound"
                            OnItemCommand="RadGrid1_ItemCommand">
                            <MasterTableView CommandItemDisplay="Top">
                                <Columns>                                    
                                    <telerik:GridTemplateColumn UniqueName="clave">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblClave" runat="server">Clave</asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtClave" runat="server" Text='<%# Eval("clave") %>'></asp:TextBox>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn UniqueName="sexo">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblSexo" runat="server">Sexo</asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddlSexo" runat="server"></asp:DropDownList>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>                        
                        <asp:Button ID="btnGenerar" Text="Generar" runat="server" OnClick="btnGenerar_Click" />
                    </div>
                </td>
            </tr>
        </table>
    </div>
    </center>
</asp:Content>
