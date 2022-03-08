<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="administracionPerfiles.aspx.cs" Inherits="CallcenterNUevo.Controles.ControlMnu.AdministracionPerfiles" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>


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

        .BackGround {
           background-color:#808080;
           opacity:0.6;
           filter:alpha(opacity=60);
          }

        .RadButton.rbButton.css3Shadows {
        border: 0;
        border-radius: 5px;
        box-shadow: 1px 2px 5px #666;
        }

         input[type=submit] {
            background-color: #f70606;
            color: #fff;
            border: 1px solid #808080;
            font-family: Arial;
            font-size: 12pt;
            border-radius: 10px;
            width: 80px;
         }

        input[type=submit]:hover {
            background-color: #2B347A;            
         }


        inputexp[type=submit] {
            background-color: #f70606;
            color: #fff;
            border: 1px solid #808080;
            font-family: Arial;
            font-size: 12pt;
            border-radius: 10px;
            width: 75px;
         }

        inputexp[type=submit]:hover {
            background-color: #2B347A;            
         }

        .gradient {
          width: 200px;
          height: 200px;

          background: #00ff00; /* Para exploradores sin css3 */

           /* Para el WebKit (Safari, Google Chrome etc) */
          background: -webkit-gradient(linear, left top, left bottom, from(#fff), to(#CCCCCC));
  
          /* Para Mozilla/Gecko (Firefox etc) */
          background: -moz-linear-gradient(top, #00ff00, #000000);
  
          /* Para Internet Explorer 5.5 - 7 */
          filter: progid:DXImageTransform.Microsoft.gradient(startColorstr=#00ff00, endColorstr=#000000, GradientType=0);
  
          /* Para Internet Explorer 8 */
          -ms-filter: "progid:DXImageTransform.Microsoft.gradient(startColorstr=#FF0000FF, endColorstr=#FFFFFFFF)";

          border:1px solid #595959; border-right:5px solid #595959; border-bottom:2.5px solid #595959;
     }
    </style>

    <br /><br /><br />
    <center>
            <asp:UpdatePanel ID="upBuscaRoles" runat="server">
                <ContentTemplate>
                    <asp:HiddenField ID="selRpleId" runat="server" />
                        <asp:MultiView ID="mvRoles" runat="server" ActiveViewIndex="0">
                        <asp:View ID="vcatRoles" runat="server">
                        <h3>Catálogo de roles</h3>
                            <asp:Table id="tblgrid" runat="server">
                            <asp:TableRow>
                                <asp:TableCell ColumnSpan="2" VerticalAlign="Top">
                                      <br />
                                        <telerik:RadGrid ID="grvDatosRoles"  runat="server" PageSize="5" AutoGenerateColumns="False" AllowPaging="true"  AllowSorting="true" OnItemCommand="grvDatosRoles_ItemCommand" CellSpacing="2" GridLines="Both"  Culture="es-MX" OnPageIndexChanged="grvDatosRoles_PageIndexChanged" Width="450px">
                                        <GroupingSettings CollapseAllTooltip="Collapse all groups" />
                                            <MasterTableView NoMasterRecordsText="No se encontro información" AllowMultiColumnSorting="true">
                                           <RowIndicatorColumn Visible="False">
                                                    </RowIndicatorColumn>
                                                    <Columns>   
                                                        <telerik:GridTemplateColumn  HeaderText="" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemTemplate> 
                                                                        <asp:Button ID="btnVerDetalle" ToolTip="Ver detalle" runat="server"  Text="Ver" Width="80px" CommandArgument='<%# Eval("RoleId")%>' Font-Size="13px" CommandName="VerDetalle" TabIndex="0"/>
                                                        </ItemTemplate>
                                                        </telerik:GridTemplateColumn>     
                                                        <telerik:GridTemplateColumn  HeaderText="Opciones" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemTemplate> 
                                                                        <asp:Button ID="btnEditar" ToolTip="Editar" runat="server"  Text="Editar" Width="80px" CommandArgument='<%# Eval("RoleId")%>' Font-Size="13px" CommandName="EdtarRol" TabIndex="0"/>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                         <telerik:GridBoundColumn DataField="RoleId" FilterControlAltText="Filter column1 column" HeaderStyle-ForeColor="White" HeaderText="RolID" UniqueName="column1" Visible="false">
                                                            </telerik:GridBoundColumn>   
                                                        <telerik:GridBoundColumn DataField="RoleName" FilterControlAltText="Filter column2 column" HeaderStyle-ForeColor="White" HeaderText="Nombre Rol" UniqueName="column2">
                                                            </telerik:GridBoundColumn>  
                                                        <telerik:GridBoundColumn DataField="Descripcion" ItemStyle-Width="200px" FilterControlAltText="Filter column3 column" HeaderStyle-ForeColor="White" HeaderText="Descripción" UniqueName="column3">
                                                            </telerik:GridBoundColumn>  
                                                    </Columns>
                                              <PagerStyle PageSizeControlType="None"/>
                                        </MasterTableView>
                                        <SortingSettings SortedBackColor="#FFF6D6" EnableSkinSortStyles="false"></SortingSettings>
                                        <HeaderStyle Width="100px"></HeaderStyle>
                                        <PagerStyle FirstPageToolTip="Primera Página" GoToPageButtonToolTip="Ir a página" LastPageToolTip="Última página" NextPagesToolTip="Siguientes páginas" NextPageToolTip="Siguiente página" PagerTextFormat="Cambiar página: {4} &amp;nbsp;página &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;, registro &lt;strong&gt;{2}&lt;/strong&gt; a &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeControlType="None" PrevPagesToolTip="Páginas anteriores" PrevPageToolTip="Página anterior" />
                                        </telerik:RadGrid>
                                </asp:TableCell>
                                <asp:TableCell VerticalAlign="Top">
                                    &nbsp;&nbsp;
                                    <asp:ImageButton ID="imgbtnAltaRoles" ImageUrl="../../Images/imgRoles.jpg" runat="server" Width="45px" Height="45px" ToolTip="Nuevo Rol" OnClick="imgbtnAltaRoles_Click"></asp:ImageButton>
                                    &nbsp;&nbsp;
                            </asp:TableCell>
                                <asp:TableCell VerticalAlign="Top">
                                    <telerik:RadGrid ID="grvDetalleSubmnuxRol"  runat="server"  AutoGenerateColumns="false" OnPageIndexChanged="grvDetalleSubmnuxRol_PageIndexChanged"  AllowSorting="true"  CellSpacing="2" GridLines="Both"     Culture="es-MX"  Width="450px">
                                        <GroupingSettings CollapseAllTooltip="Collapse all groups" />
                                            <MasterTableView NoMasterRecordsText="No se encontro información" AllowMultiColumnSorting="true">
                                           <RowIndicatorColumn Visible="False">
                                                    </RowIndicatorColumn>
                                                    <Columns> 
                                                        <telerik:GridTemplateColumn  HeaderText="Rol" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemTemplate> 
                                                                <asp:Label ID="lblNombreRol" runat="server" Text ='<%# Eval("NombreRol")%>'></asp:Label></label>
                                                        </ItemTemplate>
                                                        </telerik:GridTemplateColumn>     
                                                        <telerik:GridTemplateColumn  HeaderText="Sub Menú" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemTemplate> 
                                                                <asp:Label ID="lblNombreSubmnu" runat="server" Text ='<%# Eval("NombreSubmnu")%>'></asp:Label></label>
                                                        </ItemTemplate>
                                                        </telerik:GridTemplateColumn>    
                                                    </Columns>
                                        </MasterTableView>
                                    </telerik:RadGrid>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        </asp:View>
                        <asp:View ID="vModificaRol" runat="server">
                        <h3>Modificar roles</h3>
                            <asp:Table ID="tblModRol" runat="server">
                                <asp:TableRow>
                                    <asp:TableCell>
                                        <asp:Label ID="Label1" runat="server" Text="Nombre Rol:"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtNomRol" runat="server" ></asp:TextBox>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell>
                                        <asp:Label ID="Label2" runat="server" Text="Descripción Rol:"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtDescRol" runat="server" TextMode="MultiLine" Width="200px" Height="45px"></asp:TextBox>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell>
                                        <asp:Table ID="tblbotones" runat="server">
                                            <asp:TableRow>
                                                <asp:TableCell>
                                                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click"></asp:Button>
                                                </asp:TableCell>
                                                <asp:TableCell>
                                                    <asp:Button ID="btnCanclear" runat="server" Text="Cancelar" OnClick="btnCanclear_Click"></asp:Button>
                                                </asp:TableCell>
                                            </asp:TableRow>
                                        </asp:Table>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </asp:View>
                        <asp:View ID="vAltaRol" runat="server">
                        <h3>Alta de roles</h3>
                             <asp:Table ID="tblAltaRoles" runat="server">
                                <asp:TableRow>
                                    <asp:TableCell>
                                        <asp:Label ID="Label3" runat="server" Text="Nombre Rol:"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtNomRolAlta" runat="server"></asp:TextBox>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell>
                                        <asp:Label ID="Label4" runat="server" Text="Descripción Rol:"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtDesRol" runat="server" TextMode="MultiLine" Width="200px" Height="45px"></asp:TextBox>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell>
                                        <asp:Table ID="Table2" runat="server">
                                            <asp:TableRow>
                                                <asp:TableCell>
                                                    <asp:Button ID="btnRegistraNvoRol" runat="server" Text="Guardar" OnClick="btnRegistraNvoRol_Click"></asp:Button>
                                                </asp:TableCell>
                                                <asp:TableCell>
                                                    <asp:Button ID="btnCancelaAltaRol" runat="server" Text="Cancelar" OnClick="btnCancelaAltaRol_Click"></asp:Button>
                                                </asp:TableCell>
                                            </asp:TableRow>
                                        </asp:Table>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </asp:View>
                        </asp:MultiView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </center>
</asp:Content>
