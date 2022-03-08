<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"   CodeBehind="usuarios.aspx.cs" Inherits="CallcenterNUevo.Controles.ControlMnu.usuarios" %>
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
            return false;
        }
    </script>

    <br /><br /><br />
    <center>
            <asp:UpdatePanel ID="upBuscaUsuarios" runat="server">
                <ContentTemplate>
                    <asp:MultiView ID="mvUsuarios" runat="server" ActiveViewIndex="0">
                        <asp:View ID="vBusqueda" runat="server">
                        <h3 style="color:darkblue">Busqueda de usuarios</h3> 
                            <asp:HiddenField ID="selUsuario" runat="server" />
                        <asp:Table ID="tblBuscaUsuarios" runat="server" CellPadding="15" CellSpacing="15" Width="350px">
                            <asp:TableRow >
                                <asp:TableCell >

                                </asp:TableCell>
                                 <asp:TableCell>
                                
                            </asp:TableCell>
                                 <asp:TableCell HorizontalAlign="Right">
                                <asp:ImageButton ID="imgbtnAltaUsuario" ImageUrl="../../Images/alta_user.ico" runat="server" ToolTip="Nuevo Usuario" OnClick="imgbtnAltaUsuario_Click"></asp:ImageButton>
                            </asp:TableCell>
                            </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:Label ID="lblUsuario" runat="server" Text="Usuario:"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell ColumnSpan="2">
                                <asp:TextBox ID="txtBuscaUsuario" runat="server"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                <br />
                                <asp:Table ID="tblbotonescons" runat="server">
                                    <asp:TableRow>
                                        <asp:TableCell>
                                            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click"></asp:Button>
                                        </asp:TableCell>
                                        <asp:TableCell>
                                            <asp:Button ID="btnCancelaBusca" runat="server" Text="Cancelar" OnClick="btnCancelaBusca_Click"></asp:Button>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                            <asp:Table id="tblgrid" runat="server">
                            <asp:TableRow>
                                <asp:TableCell ColumnSpan="2">
                                      <br />
                                        <telerik:RadGrid ID="grvDatosUsuarios"  runat="server" PageSize="5" AutoGenerateColumns="False" AllowPaging="true"  AllowSorting="true" OnItemCommand="grvDatosUsuarios_ItemCommand" CellSpacing="2" GridLines="Both"    Culture="es-MX" OnPageIndexChanged="grvDatosUsuarios_PageIndexChanged" Width="750px">
                                        <GroupingSettings CollapseAllTooltip="Collapse all groups" />
                                            <MasterTableView NoMasterRecordsText="No se encontro información" AllowMultiColumnSorting="true">
                                           <RowIndicatorColumn Visible="False">
                                                    </RowIndicatorColumn>
                                                    <Columns>        
                                                        <telerik:GridTemplateColumn  HeaderText="Opciones" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemTemplate> 
                                                                        <asp:Button ID="btnEliminar" ToolTip="Elimina usuario" runat="server"  Text="Eliminar" Width="80px" CommandArgument='<%# Eval("Usuario")%>' Font-Size="13px" CommandName="EliminaUsuario" TabIndex="2"/>
                                                            </ItemTemplate>
                                                            
                                                        </telerik:GridTemplateColumn> 
                                                        <telerik:GridTemplateColumn  HeaderText="" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemTemplate> 
                                                                        <asp:Button ID="btnEditar" ToolTip="Editar usuario" runat="server"  Text="Editar" Width="80px" CommandArgument='<%# Eval("Usuario")%>' Font-Size="13px" CommandName="EditaUsuario" TabIndex="2"/>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridBoundColumn DataField="Usuario" FilterControlAltText="Filter column2 column" HeaderStyle-ForeColor="White" HeaderText="Usuario" UniqueName="column2">
                                                            </telerik:GridBoundColumn>  
                                                        <telerik:GridBoundColumn DataField="eMail" ItemStyle-Width="200px" FilterControlAltText="Filter column3 column" HeaderStyle-ForeColor="White" HeaderText="eMail" UniqueName="column3">
                                                            </telerik:GridBoundColumn>  
                                                        <telerik:GridBoundColumn DataField="password" ItemStyle-Width="40px" FilterControlAltText="Filter column4 column" HeaderStyle-ForeColor="White" HeaderText="Password" UniqueName="column4">
                                                            </telerik:GridBoundColumn>  
                                                        <telerik:GridBoundColumn DataField="NombreUsuario" ItemStyle-Width="150px" FilterControlAltText="Filter column4 column" HeaderStyle-ForeColor="White" HeaderText="Nombre Usuario" UniqueName="column5">
                                                            </telerik:GridBoundColumn>  
                                                    </Columns>
                          
                                              <PagerStyle PageSizeControlType="None"/>
                                        </MasterTableView>
                                        <SortingSettings SortedBackColor="#FFF6D6" EnableSkinSortStyles="false"></SortingSettings>
                                        <HeaderStyle Width="100px"></HeaderStyle>
                                        <PagerStyle FirstPageToolTip="Primera Página" GoToPageButtonToolTip="Ir a página" LastPageToolTip="Última página" NextPagesToolTip="Siguientes páginas" NextPageToolTip="Siguiente página" PagerTextFormat="Cambiar página: {4} &amp;nbsp;página &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;, registro &lt;strong&gt;{2}&lt;/strong&gt; a &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeControlType="None" PrevPagesToolTip="Páginas anteriores" PrevPageToolTip="Página anterior" />
                                        </telerik:RadGrid>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        </asp:View>
                        <asp:View ID="vAltaUsuario" runat="server">
                        <h3 style="color:darkblue">Alta de usuarios</h3><br />
                            <asp:Table ID="tblusuarios" runat="server" >
                            <asp:TableRow>
                                <asp:TableCell Width="120px" HorizontalAlign="Left" >
                                    <asp:Label ID="Label1" runat="server" Text="Usuario:"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="txtUsuario" runat="server" tabindex="0"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell RowSpan="6">
                                    <asp:Table ID="tblRoles" runat="server">
                                         <asp:TableRow>
                                            <asp:TableCell HorizontalAlign="Left" VerticalAlign="Top" >
                                                &nbsp;&nbsp;&nbsp;<asp:Label ID="Label4" runat="server" Font-Bold="true" Text="Asignar Rol:"></asp:Label>
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
                            <%--<asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="Label9" runat="server" Text="Nombre:"></asp:Label>
                                </asp:TableCell>
                                 <asp:TableCell>
                                     <asp:TextBox ID="txtNombre" runat="server" tabindex="0"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>--%>
                            <asp:TableRow>
                                <asp:TableCell HorizontalAlign="Left" >
                                    <asp:Label ID="Label3" runat="server" Text="e-Mail:"></asp:Label>
                                </asp:TableCell>
                                 <asp:TableCell>
                                     <asp:TextBox ID="txtmail" runat="server" tabindex="1"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                           <%-- <asp:TableRow>
                                <asp:TableCell HorizontalAlign="Left" >
                                    <asp:Label ID="Label2" runat="server" Text="Contraseña:"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="txtpwd" runat="server" TextMode="Password" tabindex="3"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                              <asp:TableRow>
                                <asp:TableCell HorizontalAlign="Left" >
                                    <asp:Label ID="Label5" runat="server" Text="Confirmar contraseña:"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="txtpwdconf" runat="server"  TextMode="Password"  tabindex="4"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>--%>
                            <asp:TableRow>
                                <asp:TableCell ColumnSpan="2">
                                    <asp:Table ID="tblbotones2" runat="server" Width="250px" >
                                    <asp:TableRow>
                                        <asp:TableCell>
                                            <br />
                                            <asp:Button ID="btnRegistrar" runat="server" CssClass="input" Text="Registra usuario" OnClick="btnRegistrar_Click" Width="145px"/>
                                        </asp:TableCell>
                                        <asp:TableCell>
                                            <br />
                                            <asp:Button ID="btnCancelar" runat="server" CssClass="input" Text="Cancelar"  OnClick="btnCancelar_Click" Width="100px"/>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    </asp:Table>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        </asp:View>
                        <asp:View ID="VEditaUsuario" runat="server">
                        <h3 style="color:darkblue">Edición de usuarios</h3><br />
                            <asp:Table ID="tblEditaUser" runat="server" >
                            <asp:TableRow>
                                <asp:TableCell Width="120px" HorizontalAlign="Left" >
                                    <asp:Label ID="Label6" runat="server" Text="Usuario:"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="txtUsuarioM" runat="server" tabindex="0" Enabled="false" ></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell RowSpan="6">
                                    <asp:Table ID="tblRolesM" runat="server">
                                         <asp:TableRow>
                                            <asp:TableCell HorizontalAlign="Left" VerticalAlign="Top" >
                                                &nbsp;&nbsp;&nbsp;<asp:Label ID="Label7" runat="server" Font-Bold="true" Text="Asignar Rol:"></asp:Label>
                                            </asp:TableCell>
                                            <asp:TableCell>
                                            <asp:CheckBoxList   id="chklstRolesM" 
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
                                <%--<asp:TableRow>
                                <asp:TableCell HorizontalAlign="Left" >
                                    <asp:Label ID="Label10" runat="server" Text="Nombre:"></asp:Label>
                                </asp:TableCell>
                                 <asp:TableCell>
                                     <asp:TextBox ID="txtNombreM" runat="server" tabindex="1" ></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>--%>
                            <asp:TableRow>
                                <asp:TableCell HorizontalAlign="Left" >
                                    <asp:Label ID="Label8" runat="server" Text="e-Mail:"></asp:Label>
                                </asp:TableCell>
                                 <asp:TableCell>
                                     <asp:TextBox ID="txteMailM" runat="server" tabindex="1"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell HorizontalAlign="Left" >
                                    <asp:Label ID="Label11" runat="server" Text="Password:"></asp:Label>
                                </asp:TableCell>
                                 <asp:TableCell>
                                     <asp:TextBox ID="txtPasswordEdit" runat="server" Enabled="false"></asp:TextBox>
                                     &nbsp;&nbsp;&nbsp;<asp:Button ID="btnResetPwd" runat="server" Font-Size="12px" Text="Reset password" OnClick="btnResetPwd_Click" Width="150px"></asp:Button>
                                </asp:TableCell>
                            </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell ColumnSpan="2" HorizontalAlign="Left">
                                        <asp:CheckBox ID="chkActivo" runat="server" Text="Activo" TextAlign ="Right"></asp:CheckBox>
                                    </asp:TableCell>
                                </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell ColumnSpan="2">
                                    <asp:Table ID="tblbotones" runat="server" Width="250px" >
                                    <asp:TableRow>
                                        <asp:TableCell>
                                            <br />
                                            <asp:Button ID="btnModificar" runat="server" CssClass="input" Text="Modificar usuario" OnClick="btnModificar_Click" Width="145px"/>
                                        </asp:TableCell>
                                        <asp:TableCell>
                                            <br />
                                            <asp:Button ID="btnCanclearM" runat="server" CssClass="input" Text="Cancelar"  OnClick="btnCanclearM_Click" Width="100px"/>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    </asp:Table>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        </asp:View>
                     </asp:MultiView>

                    <div id="popReg" style="display: none; background-color: rgba(0, 0, 0, 0.5); z-index: 20000; left: 0%; position: absolute; top: 0px; width:100%; height: 100%; text-align: center;">
					<div  style="background-color: #333333; max-width: 400px; padding: 15px; width: 100%; display: inline-block; vertical-align: middle; height: 160px; margin-top:18%; max-height: 440px;">
					    <div class="modal-content"  style="background-color:#E2E1E1; height:135px; background-image:url(; background-repeat: repeat-x"../Images/background2.jpg");>
						    <div style=" margin-top:0%;">
                                  <asp:Table ID="tblBotones3" runat="server" HorizontalAlign="Center" CellSpacing="5" CellPadding="3" Width="320">
								<asp:TableRow>
									<asp:TableCell RowSpan="3" HorizontalAlign="Center"  VerticalAlign="Middle">
                                        <img src="../../Imagenes_Benavides/botones/question.png" width="45" height="45"/>
									</asp:TableCell>
								</asp:TableRow>
								<asp:TableRow>
									<asp:TableCell>
									</asp:TableCell>
									<asp:TableCell ColumnSpan="3" HorizontalAlign="Center"  >
										<h2>
											<asp:Label ID="lblmsg1" runat="server" Font-Size="14px" Font-Bold="true" Text ="El usuario se eliminara" ></asp:Label><br />
											<asp:Label ID="lblmsg2" runat="server" Font-Size="14px" Font-Bold="true" Text ="¿desea continuar?"></asp:Label><br />
										</h2>
									</asp:TableCell>
								</asp:TableRow>
								<asp:TableRow>
									<asp:TableCell>
									</asp:TableCell>
									<asp:TableCell>
										<asp:Button ID="btnSi" runat="server" CssClass="input" OnClick="btnSi_Click" Width="100" Text="Sí" />
									</asp:TableCell>
									 <asp:TableCell Width="20px">
									</asp:TableCell>
									<asp:TableCell>
										<asp:Button ID="btnNo" runat="server" CssClass="input"  Width="100"  Text="No" />
									</asp:TableCell>
								</asp:TableRow>
							</asp:Table>
                            </div>
	                    </div>
	                </div>
                </div>
                </ContentTemplate>
            </asp:UpdatePanel>
    </center>
</asp:Content>
