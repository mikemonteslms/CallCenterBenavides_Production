<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="mantenimientomenu.aspx.cs" Inherits="CallcenterNUevo.Controles.ControlMnu.mantenimientomenu" %>
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

    <script src="../../Scripts/jquery-1.7.1.min.js"></script>
    <script src="../../Scripts/jquery-ui-1.8.20.min.js"></script>

    <script type="text/javascript" >

        $(document).ready(function () {
            $('#MainContent_btnNo').on("click", function () {
                $('#popReg').fadeOut('slow');
                //$('#MainContent_txtCorreo').focus();
                return false;
            });
        });

        function ShowReg() {
            //debugger;
            var _docHeight = (document.height !== undefined) ? document.height : document.body.scrollHeight;
            var _docWidth = (document.width !== undefined) ? document.width : document.body.offsetWidth;

            $('#popReg').fadeIn('slow');
            $('#popReg').height(_docHeight);

            //$('#popReg div')[0].removeAttr('height');
            //$('#popReg div')[0].attr('height', '180');

            return false;
        }
    </script>

    <br /><br /><br />
    <center>
        <asp:UpdatePanel ID="upBuscaUsuarios" runat="server">
            <ContentTemplate>
                <asp:MultiView ID="mvUsuarios" runat="server" ActiveViewIndex="0">
                     <asp:View ID="vReasignaciones" runat="server">
                        <h4 style="color:darkblue">Roles asignados a un submenú</h4>
                         <br />
                         <asp:Table ID="tblMenus" runat="server" CellPadding="15" CellSpacing="15" Width="650px">
                             <asp:TableRow>
                                 <asp:TableCell>
                                    <asp:Label ID="Label1" runat="server" Text="Seleccione un menú: "></asp:Label>
                                 </asp:TableCell>
                                 <asp:TableCell>
                                     <telerik:RadComboBox ID="rdcMenus" RenderMode="Lightweight" AutoPostBack="true" AllowCustomText="False"  runat="server" OnSelectedIndexChanged="rdcMenus_SelectedIndexChanged"   Width="220px">
                                    </telerik:RadComboBox>
                                 </asp:TableCell>
                                  <asp:TableCell RowSpan="2" VerticalAlign="Top">
                                    <asp:ImageButton ID="imgbtnAltaMenu" runat="server" AlternateText="Agregar nuevo Menú" OnClick="imgbtnAltaMenu_Click"></asp:ImageButton>
                                 <br />
                                    <asp:ImageButton ID="imgbtnAltaSubMenu" runat="server" AlternateText="Agregar nuevo Submenú" OnClick="imgbtnAltaSubMenu_Click"></asp:ImageButton>
                                <br />
                                    <asp:ImageButton ID="imgbtnAgregaRolesSubmenu" runat="server" AlternateText="Asignar roles a Submenus" OnClick="imgbtnAgregaRolesSubmenu_Click"></asp:ImageButton>
                                 </asp:TableCell>
                            </asp:tablerow>
                            
                             <asp:TableRow>
                                 <asp:TableCell ColumnSpan="3">
                                     <br /><br />
                                       <asp:GridView  ID="grvSubMnus"  runat="server" CssClass="gridview" OnRowCommand="grvSubMnus_RowCommand" OnRowDataBound="grvSubMnus_RowDataBound"  OnRowDeleting="grvSubMnus_RowDeleting"  CellSpacing ="1" AutoGenerateColumns ="false"   CellPadding="3" GridLines="Horizontal" HorizontalAlign="left"  Width ="850px"  Height="100%" Caption="Sub menus"  >
                                        <HeaderStyle ForeColor="Black"   />
                                            <Columns>
                                                <asp:TemplateField  HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="DarkBlue" HeaderStyle-ForeColor="White">
                                                    <HeaderTemplate>
                                                        Nombre
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:HiddenField ID="SubmnuId" runat="server" Value='<%# Eval("SubMenuId")%>' />
                                                        <asp:TextBox ID="txtNomSubmnu" runat="server" Text='<%# Eval("Nombre")%>' Width="230px"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                 <asp:TemplateField  HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="DarkBlue" HeaderStyle-ForeColor="White">
                                                    <HeaderTemplate>
                                                        Orden
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                         <asp:TextBox ID="txtOrden" runat= "server" Text='<%# Eval("Orden")%>'  Width="60px"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField  HeaderStyle-HorizontalAlign="Center"  HeaderStyle-BackColor="DarkBlue" HeaderStyle-ForeColor="White">
                                                    <HeaderTemplate>
                                                        Nombre de rol
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:HiddenField ID="RoleId" runat="server" Value='<%# Eval("RoleId")%>' />
                                                        <telerik:RadComboBox ID="cmbNomRol" RenderMode="Lightweight" AllowCustomText="true" Filter="Contains" MarkFirstMatch="true"  DataValueField='<%# Eval("RoleId")%>'  DataTextField='<%# Eval("RoleName")%>'  runat="server"  Width="180px">
                                                        </telerik:RadComboBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField  HeaderStyle-HorizontalAlign="Center"  HeaderStyle-BackColor="DarkBlue" HeaderStyle-ForeColor="White">
                                                    <HeaderTemplate>
                                                        
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="imgbtnEliminarsubMenu" runat="server" CommandArgument='<%# Eval("SubMenuId")%>'  CommandName="Eliminasubmnu" AlternateText="Eliminar submenú" ToolTip="Eliminar submenú" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:commandfield ShowDeleteButton="true" DeleteText="Eliminar rol asociado"   DeleteImageUrl="../Imagenes_Benavides/delete-icon.png" HeaderStyle-BackColor="DarkBlue" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center" headertext="Opciones" HeaderStyle-Width="200px"/>
                                            </Columns>
                                        </asp:GridView>
                                 </asp:TableCell>
                             </asp:TableRow>
                             <asp:TableRow>
                                 <asp:TableCell ColumnSpan="3">
                                     <br />
                                     <asp:table ID="tblbotones" runat="server"  CellSpacing="2" Width="200px">
                                         <asp:TableRow>
                                             <asp:TableCell>
                                                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click"></asp:Button>
                                             </asp:TableCell>
                                             <asp:TableCell>
                                                 <asp:Button ID="Cancelar" runat="server" Text="Cancelar" OnClick="Cancelar_Click"></asp:Button>
                                             </asp:TableCell>
                                         </asp:TableRow>
                                     </asp:table>
                                 </asp:TableCell>
                             </asp:TableRow>
                         </asp:Table>
                     </asp:View>
                    <asp:View ID="vAltaMenus" runat="server">
                        <h4 style="color:darkblue">Alta de menus</h4>
                        <asp:Table ID="Table1" runat="server" CellPadding="25" CellSpacing="15" Width="350px">
                             <asp:TableRow>
                                 <asp:TableCell>
                                    <asp:Label ID="Label2" runat="server" Text="Nombre:"></asp:Label>
                                 </asp:TableCell>
                                 <asp:TableCell>
                                    <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                                 </asp:TableCell>
                             </asp:TableRow>
                            <asp:TableRow>
                                 <asp:TableCell>
                                    <asp:Label ID="Label3" runat="server" Text="Orden:"></asp:Label>
                                 </asp:TableCell>
                                 <asp:TableCell>
                                    <asp:TextBox ID="txtOrden" runat="server" MaxLength="2"></asp:TextBox>
                                    <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Numbers" TargetControlID="txtOrden">
                                    </asp:FilteredTextBoxExtender>
                                 </asp:TableCell>
                             </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <br />
                                    <asp:Button ID="btnGuardarMnu" runat="server" Text="Guardar" OnClick="btnGuardarMnu_Click"></asp:Button>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <br />
                                    <asp:Button ID="btnCancelarMnu" runat="server" Text="Cancelar" OnClick="btnCancelarMnu_Click"></asp:Button>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell ColumnSpan="2">
                                    <asp:GridView  ID="grvMenusExistentes"  runat="server" AutoGenerateColumns="false" CssClass="gridview" Caption="Menus Existentes">
                                        <HeaderStyle ForeColor="Black"   />
                                            <Columns>
                                                <asp:TemplateField  HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="DarkBlue" HeaderStyle-ForeColor="White">
                                                    <HeaderTemplate>
                                                        Menú
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtMenu" runat="server" Text='<%# Eval("Nombre")%>' Width="170px" Enabled="false"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                    </asp:GridView>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </asp:View>
                    <asp:View ID="vAltaSubmenu" runat="server">
                        <h4 style="color:darkblue">Alta de submenus</h4>
                        <asp:Table ID="Table2" runat="server" CellPadding="15" CellSpacing="15" Width="350">
                             <asp:TableRow>
                                 <asp:TableCell>
                                    <asp:Label ID="Label4" runat="server" Text="Menus"></asp:Label>
                                 </asp:TableCell>
                                 <asp:TableCell>
                                     <telerik:RadComboBox ID="rdcMenus2" RenderMode="Lightweight" AutoPostBack="true" AllowCustomText="False"  runat="server" OnSelectedIndexChanged="rdcMenus2_SelectedIndexChanged"   Width="220px">
                                    </telerik:RadComboBox>
                                 </asp:TableCell>
                             </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="Label5" runat="server" Text="Nombre:"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="txtNomSubmenu" runat="server"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="Label6" runat="server" Text="Orden:"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="txtOrdenSubMnu" runat="server"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="Label7" runat="server" Text="Url:"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="txtURL" runat="server"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="Label8" runat="server" Text="Asignar a un rol:"></asp:Label>
                                </asp:TableCell>
                                 <asp:TableCell>
                                     <telerik:RadComboBox ID="rcbRoles" RenderMode="Lightweight" AutoPostBack="true" AllowCustomText="False"  runat="server"    Width="220px">
                                    </telerik:RadComboBox>
                                 </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <br />
                                    <asp:Button ID="btnGuardarSubmnu" runat="server" Text="Guardar" OnClick="btnGuardarSubmnu_Click"></asp:Button>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <br />
                                    <asp:Button ID="btnCancelarSubmnu" runat="server" Text="Cancelar" OnClick="btnCancelarSubmnu_Click"></asp:Button>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </asp:View>
                    <asp:View ID="VAsignaRolesSubMnus" runat="server">
                        <h4 style="color:darkblue">Asignar roles a un submenú</h4><br />
                            <asp:Table ID="tblEditaUser" runat="server">
                            <asp:TableRow>
                                <asp:TableCell VerticalAlign="top"  Width="180px" HorizontalAlign="Left" >
                                    <asp:Label ID="Label11" runat="server" Text="Seleccione un menú:"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell VerticalAlign="top"  Width="120px" HorizontalAlign="Left" >
                                    <telerik:RadComboBox ID="rdcbmnu" RenderMode="Lightweight" AutoPostBack="true" AllowCustomText="False"  runat="server" OnSelectedIndexChanged="rdcbmnu_SelectedIndexChanged"  Width="220px">
                                    </telerik:RadComboBox>
                                </asp:TableCell>
                                 <asp:TableCell RowSpan="2" >
                                    <asp:Table ID="tblRolesM" runat="server">
                                         <asp:TableRow>
                                            <asp:TableCell HorizontalAlign="Left" VerticalAlign="Top" >
                                                &nbsp;&nbsp;&nbsp;<asp:Label ID="Label10" runat="server" Font-Bold="true" Text="Asignar Rol:"></asp:Label>
                                            </asp:TableCell>
                                            <asp:TableCell>
                                            <asp:CheckBoxList   id="chklstRoles" 
                                                                AutoPostBack="false"
                                                                CellPadding="5"
                                                                CellSpacing="5"
                                                                RepeatColumns="1"
                                                                RepeatDirection="Vertical"
                                                                RepeatLayout="OrderedList"
                                                                TextAlign="Right"
                                                                runat="server">
                                            </asp:CheckBoxList>
                                            </asp:TableCell>
                                        </asp:TableRow>
                                    </asp:Table>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell VerticalAlign="top" Width="120px" HorizontalAlign="Left" >
                                    <asp:Label ID="Label9" runat="server" Text="Seleccione un submenú:"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell VerticalAlign="top" Width="120px" HorizontalAlign="Left" >
                                    <telerik:RadComboBox ID="rdcbSubmnuroles" RenderMode="Lightweight" AutoPostBack="true" AllowCustomText="False"  runat="server" OnSelectedIndexChanged="rdcbSubmnuroles_SelectedIndexChanged"  Width="220px">
                                    </telerik:RadComboBox>
                                    <asp:Label ID="lblmsg" runat="server" ForeColor="DarkRed" Font-Size ="12px" Font-Bold ="true" Visible="false"></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell ColumnSpan="2">
                                    <asp:Table ID="tblbotones2" runat="server" Width="250px" >
                                    <asp:TableRow>
                                        <asp:TableCell>
                                            <br />
                                            <asp:Button ID="btnGuardarRolessubmnu" runat="server" CssClass="input" Text="Guardar" OnClick="btnGuardarRolessubmnu_Click" Width="145px"/>
                                        </asp:TableCell>
                                        <asp:TableCell>
                                            <br />
                                            <asp:Button ID="btnCanclearRolessubmenu" runat="server" CssClass="input" Text="Cancelar"  OnClick="btnCanclearRolessubmenu_Click" Width="100px"/>
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
