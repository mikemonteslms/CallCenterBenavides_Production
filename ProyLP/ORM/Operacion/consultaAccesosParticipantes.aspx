<%@ Page Title="" Language="C#" MasterPageFile="~/contenido.Master" AutoEventWireup="true" CodeBehind="consultaAccesosParticipantes.aspx.cs" Inherits="ORMOperacion.consultaAccesosParticipantes" %>

<%@ MasterType VirtualPath="~/contenido.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head_contenido" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body_contenido" runat="server">
    <center>
            <table border="0">
                <tr>
                    <td>
                        <h4>Bitacora de Accesos</h4>
                        <asp:GridView ID="gvHistoricoAccesos" runat="server" AutoGenerateColumns="false" AlternatingRowStyle-BackColor="#E2F1FC"
                            ShowHeader="true" ShowFooter="true" Width="900px" AllowPaging="True" OnPageIndexChanging="gvHistoricoAccesos_PageIndexChanging" PageSize="25" CssClass="texto11">
                            <PagerStyle CssClass="PagerStyle texto11" />
                            <Columns>
                                <asp:BoundField DataField="distribuidor" HeaderText="Distribuidor" ItemStyle-Width="250" ItemStyle-CssClass="texto" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="programa" HeaderText="Programa" ItemStyle-Width="100" ItemStyle-CssClass="texto" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="fecha" HeaderText="Fecha - Hora" ItemStyle-Width="150" ItemStyle-CssClass="texto" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="opcion" HeaderText="Opción" ItemStyle-Width="400" ItemStyle-CssClass="texto" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left" />
                            </Columns>
                            <EmptyDataTemplate>
                            <table width="900" class="hs texto11">
                                <tr>
                                    <td colspan="4">No se encontraron registros.
                                    </td>
                                </tr>
                            </table>
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </td>                    
                </tr>                
            </table>
    </center>
</asp:Content>
