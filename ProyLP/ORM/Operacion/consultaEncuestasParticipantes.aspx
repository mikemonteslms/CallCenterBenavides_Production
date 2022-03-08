<%@ Page Title="" Language="C#" MasterPageFile="~/contenido.Master" AutoEventWireup="true" CodeBehind="consultaEncuestasParticipantes.aspx.cs" Inherits="ORMOperacion.consultaEncuestasParticipantes" %>

<%@ MasterType VirtualPath="~/contenido.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head_contenido" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body_contenido" runat="server">
    <center>
            <table border="0" width="100%">                
                <tr>                    
                    <td>
                        <div>
                            <h4>Consulta de Encuestas</h4>
                            <asp:SqlDataSource ID="EncuestasDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:GaleniaTest %>"
                                  SelectCommand="SELECT * FROM [encuesta] where tipo_encuesta_id = 3"></asp:SqlDataSource>
                            <asp:GridView ID="encuestas" runat="server" DataSourceID="EncuestasDataSource" AutoGenerateColumns="false"
                                GridLines="None" CellPadding="100" CellSpacing="0" DataKeyNames="id" OnRowDataBound="encuestas_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="ID" Visible="false" ItemStyle-CssClass="texto11" ItemStyle-Width="20px">
                                        <ItemTemplate>
                                            <asp:Label ID="id" runat="server" Text='<%# Bind("id") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-CssClass="texto11" ItemStyle-Width="20px">
                                        <ItemTemplate>
                                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# "imageHandler.ashx?encid=" + DataBinder.Eval(Container.DataItem,"id") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-CssClass="texto11">
                                        <ItemTemplate>
                                            <asp:Label ID="nombre" runat="server" Text='<%# Bind("nombre") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-CssClass="texto11" HeaderText="Material de Estudio">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# "MaterialEncuestaCC.aspx?encid=" + DataBinder.Eval(Container.DataItem,"id") %>'
                                                Text="Ver Material" Width="120px"></asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-CssClass="texto11">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "encuestaTestCC.aspx?encid=" + DataBinder.Eval(Container.DataItem,"id") + "&name=" + DataBinder.Eval(Container.DataItem,"nombre") %>'
                                                Text="Contestar Evaluación" Width="120px"></asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Label ID="calificacion" runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <RowStyle Height="20px" />
                                <AlternatingRowStyle BackColor="#E2F1FC" />
                                <PagerStyle HorizontalAlign="Left" CssClass="paginador"></PagerStyle>
                            </asp:GridView>
                        </div>
                    </td>
                </tr>
            </table>
    </center>
</asp:Content>
