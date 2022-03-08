<%@ Page Language="C#" MasterPageFile="~/NBenavidesMaster.Master" AutoEventWireup="true"
    CodeBehind="ActualizaDatos.aspx.cs" Inherits="WebPfizer.LMS.eCard.ActualizaDatos" Title="" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">     
    <script type="text/javascript">
        function ValidaSoloNumeros() {
            if ((event.keyCode < 48) || (event.keyCode > 57))
                event.returnValue = false;
        }

        function txNombres() {
            if ((event.keyCode != 32) && (event.keyCode < 65) || (event.keyCode > 90) && (event.keyCode < 97) || (event.keyCode > 122))
                event.returnValue = false;
        }
</script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
                 
            <div style="width:610px; height:790px; background-color:#D7D7D7;">
            <table class="tablaSinbordes"><tr><td style="width:30px; height:30px;"></td><td></td><td></td><td></td>
                <td>
                   </td>
                </tr>
            <tr><td></td><td>
                <asp:Label ID="Label11" runat="server" CssClass="LabelRegistro" 
                    Text="Nombre(s)"></asp:Label>
                </td><td style="width:40px;"></td><td>
                <asp:Label ID="Label12" runat="server" CssClass="LabelRegistro" 
                    Text="Código postal"></asp:Label>
                </td>
                <td>
                   </td>
                </tr>
                <tr><td style="height:10px;"></td><td></td><td></td><td></td>
                    <td>
                       </td>
                </tr>
                <tr><td></td><td>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="CajaTextoMisDatos" 
                        MaxLength="100"></asp:TextBox></td><td></td><td>
                        <table class="tablaSinbordes"><tr><td>
                            <asp:TextBox ID="txtCP" runat="server" CssClass="CajaTextoMisDatos" 
                        MaxLength="5" AutoPostBack="True" ontextchanged="txtCP_TextChanged" Width="169px"></asp:TextBox></td><td>
                                <asp:LinkButton ID="lnkValidaCP" runat="server" CssClass="linksBenaRecupera" 
                                    onclick="lnkValidaCP_Click">Validar C.P.</asp:LinkButton>
                                <asp:ImageButton ID="btnValidarCP" runat="server" 
                        ImageUrl="~/Imagenes_Benavides/MasterNueva/8-registro/img-check-25x25.png" 
                        onclick="btnValidarCP_Click" Visible="False" /></td></tr></table>                                        
                    </td>
                    <td>
                       </td>
                </tr>
                    <tr><td style="height:10px;"></td><td></td><td></td><td></td>
                        <td>
                           </td>
                </tr>
             <tr><td></td><td>
                <asp:Label ID="Label13" runat="server" CssClass="LabelRegistro" 
                    Text="Apellido paterno"></asp:Label>
                </td><td style="width:40px;"></td><td>
                <asp:Label ID="Label14" runat="server" CssClass="LabelRegistro" 
                    Text="Estado"></asp:Label>
                </td>
                 <td>
                    </td>
                </tr>
                <tr><td style="height:10px;"></td><td></td><td></td><td></td>
                    <td>
                       </td>
                </tr>
                <tr><td></td><td>
                <asp:TextBox ID="txtAP" runat="server" CssClass="CajaTextoMisDatos" MaxLength="50"></asp:TextBox></td><td></td><td>
                    <asp:DropDownList ID="ddlEstado" runat="server" AutoPostBack="True" 
                        BorderWidth="0" Font-Names="FuturaStd-Book" Font-Size="14px" 
                        ForeColor="#666666" Height="25px" Width="200px" 
                        onselectedindexchanged="ddlEstado_SelectedIndexChanged">
                    </asp:DropDownList>
                    </td>
                    <td>
                       </td>
                </tr>
                    <tr><td style="height:10px;"></td><td></td><td></td><td></td>
                        <td>
                           </td>
                </tr>
                 <tr><td></td><td>
                <asp:Label ID="Label15" runat="server" CssClass="LabelRegistro" 
                    Text="Apellido materno"></asp:Label>
                </td><td style="width:40px;"></td><td>
                <asp:Label ID="Label16" runat="server" CssClass="LabelRegistro" 
                    Text="Delegación o municipio"></asp:Label>
                </td>
                     <td>
                        </td>
                </tr>
                <tr><td style="height:10px;"></td><td></td><td></td><td></td>
                    <td>
                       </td>
                </tr>
                <tr><td></td><td>
                <asp:TextBox ID="txtAM" runat="server" CssClass="CajaTextoMisDatos" MaxLength="50"></asp:TextBox></td><td></td><td>
                    <asp:DropDownList ID="ddlCiudad" runat="server" AutoPostBack="True" 
                        BorderWidth="0" Font-Names="FuturaStd-Book" Font-Size="14px" 
                        ForeColor="#666666" Height="25px" Width="200px">
                    </asp:DropDownList>
                    </td>
                    <td>
                       </td>
                </tr>
                <tr><td style="height:10px;"></td><td></td><td></td><td></td>
                    <td>
                       </td>
                </tr>
                 <tr><td></td><td>
                <asp:Label ID="Label17" runat="server" CssClass="LabelRegistro" 
                    Text="Correo electrónico"></asp:Label>
                </td><td style="width:40px;"></td><td>
                     <asp:Label ID="Label22" runat="server" CssClass="LabelRegistro" 
                         Text="¿Cúales son las categorias de tu interés?"></asp:Label>
                     </td>
                     <td>
                        </td>
                </tr>
                <tr><td style="height:10px;"></td><td></td><td></td><td></td>
                    <td>
                       </td>
                </tr>
                <tr><td></td><td>
                   <table><tr><td>
                       <asp:TextBox ID="txtMail" runat="server" 
                 Width="100px" Height="25" BorderWidth="0" Font-Names="FuturaStd-Book" 
                 Font-Size="14px" ForeColor="#666666" MaxLength="100"></asp:TextBox>
         </td><td><asp:Label ID="Label1" runat="server" Font-Names="FuturaStd-Bold" 
                            Font-Size="14px" ForeColor="#666666" Text="@"></asp:Label></td><td>
                                <asp:DropDownList ID="ddlDominios" runat="server" AutoPostBack="True" 
                                    Font-Names="FuturaStd-Book" Font-Size="14px" ForeColor="#666666"
                                    Width="100px" Height="25px" BorderWidth="0"
                            onselectedindexchanged="ddlDominios_SelectedIndexChanged">
                               
                                </asp:DropDownList>
                        </td></tr></table></td><td></td><td rowspan="11" valign="top">
                    <asp:CheckBoxList ID="chkCategorias" runat="server" 
                        Font-Names="FuturaStd-Book" Font-Size="14px" ForeColor="#666666">
                    </asp:CheckBoxList>
                    </td>
                    <td>
                       </td>
                </tr>
                 <tr><td style="height:10px;"></td><td></td><td></td>
                     <td>
                        </td>
                </tr>
                 <tr><td></td><td>
                 <table><tr><td><asp:Label ID="lblEscribaDominio" runat="server" Font-Names="FuturaStd-Book" 
                            Font-Size="14px" ForeColor="#666666" 
                Text="Escriba el dominio de su correo" Visible="False"></asp:Label></td><td>
                        <asp:TextBox ID="txtDominio" runat="server" Width="100px" 
                            Font-Names="FuturaStd-Book" Font-Size="14px" Height="25" BorderWidth="0" 
                             Visible="False" MaxLength="100"></asp:TextBox>
                        </td></tr></table>
                 </td><td></td>
                     <td>
                        </td>
                </tr>
                 <tr><td style="height:10px;"></td><td></td><td></td>
                     <td>
                        </td>
                </tr>
                 <tr><td></td><td>
                <asp:Label ID="Label19" runat="server" CssClass="LabelRegistro" 
                    Text="Teléfono celular"></asp:Label>
                </td><td style="width:40px;"></td>
                     <td>
                        </td>
                </tr>
                <tr><td style="height:10px;"></td><td></td><td></td>
                    <td>
                       </td>
                </tr>
                <tr><td></td><td>
                <asp:TextBox ID="txtCelular" runat="server" CssClass="CajaTextoMisDatos" 
                        MaxLength="10"></asp:TextBox></td><td></td>
                    <td>
                       </td>
                </tr>
                 <tr><td style="height:10px;"></td><td></td><td></td>
                     <td>
                        </td>
                </tr>
                 <tr><td></td><td>
                <asp:Label ID="Label18" runat="server" CssClass="LabelRegistro" 
                    Text="Fecha de nacimiento"></asp:Label>
                </td><td style="width:40px;"></td>
                     <td>
                        </td>
                </tr>
                <tr><td style="height:10px;"></td><td></td><td></td>
                    <td>
                       </td>
                </tr>
                <tr><td></td><td align="left">
                        <table><tr><td >
                        <asp:DropDownList ID="ddlAno" runat="server" Width="60px"  BorderWidth="0"
                            Font-Names="FuturaStd-Book" ForeColor="#666666"  Font-Size="14px" 
                                    AutoPostBack="True" Height="25px" 
                                onselectedindexchanged="ddlAno_SelectedIndexChanged">
                        </asp:DropDownList>
                            </td><td>
                        <asp:DropDownList ID="ddlMes" runat="server" Width="95px"  BorderWidth="0"
                            Font-Names="FuturaStd-Book" ForeColor="#666666"  Font-Size="14px" 
                                    AutoPostBack="True" Height="25px" 
                                    onselectedindexchanged="ddlMes_SelectedIndexChanged">
                        </asp:DropDownList>
                            </td><td>
                        <asp:DropDownList ID="ddlDia" runat="server" Width="60px" Font-Names="FuturaStd-Book" 
                                    ForeColor="#666666"  Font-Size="14px" BorderWidth="0"
                        Height="25px">
                        </asp:DropDownList>
                            </td></tr></table>
                        </td><td></td>
                    <td>
                       </td>
                </tr>
                 <tr><td style="height:10px;"></td><td></td><td></td><td></td>
                     <td>
                        </td>
                </tr>
                 <tr><td></td><td>
                <asp:Label ID="Label20" runat="server" CssClass="LabelRegistro" 
                    Text="Género"></asp:Label>
                </td><td style="width:40px;"></td><td>
                     </td>
                     <td>
                        </td>
                </tr>
                <tr><td style="height:10px;"></td><td></td><td></td><td></td>
                    <td>
                       </td>
                </tr>
                <tr><td></td><td>
                    <asp:RadioButtonList ID="rdoGenero" runat="server" 
                        RepeatDirection="Horizontal">
                        <asp:ListItem Value="1"><img alt='' src='Imagenes_Benavides/MasterNueva/8-registro/img-genero-25x25-2.png'></asp:ListItem>
                        <asp:ListItem Value="2"><img alt='' src='Imagenes_Benavides/MasterNueva/8-registro/img-genero-25x25-1.png'></asp:ListItem>
                        <%--<asp:ListItem Value="3" Enabled="false">Indefinido</asp:ListItem>--%>
                    </asp:RadioButtonList>
                    </td><td></td><td>
                    </td>
                    <td>
                       </td>
                </tr>
                 <tr><td style="height:10px;"></td><td></td><td></td><td></td>
                     <td>
                        </td>
                </tr>
                 <tr><td></td><td>
                <asp:Label ID="Label21" runat="server" CssClass="LabelRegistro" 
                    Text="¿Tienes hijos?"></asp:Label>
                </td><td style="width:40px;"></td><td>
                     </td>
                     <td>
                        </td>
                </tr>
                <tr><td style="height:10px;"></td><td></td><td></td><td></td>
                    <td>
                       </td>
                </tr>
                <tr><td></td><td>
                    <asp:RadioButtonList ID="rdoHijos" runat="server" AutoPostBack="True" 
                        Font-Names="FuturaStd-Book" Font-Size="14px" 
                        ForeColor="#666666" RepeatDirection="Horizontal">
                        <asp:ListItem Value="1">Si</asp:ListItem>
                        <asp:ListItem Value="0">No</asp:ListItem>
                    </asp:RadioButtonList>
                    </td><td></td><td>
                    </td>
                    <td>
                       </td>
                </tr>
                 <tr><td style="height:20px;"></td><td></td><td></td><td></td>
                    <td>
                       </td>
                </tr>
                <tr><td></td><td><asp:ImageButton ID="btnCancelar" runat="server" 
                        
                        ImageUrl="~/Imagenes_Benavides/MasterNueva/7-olvidaste_contrasena/btn-regresar.jpg" 
                        onclick="btnCancelar_Click" /></td><td></td><td>
                    <asp:ImageButton ID="btnGuardar" runat="server" 
                        
                        ImageUrl="~/Imagenes_Benavides/MasterNueva/13-cambiar_contrasena/btn-guardar.jpg" 
                        onclick="btnGuardar_Click" /></td>
                    <td>
                       </td>
                </tr>
                  <tr><td style="height:30px;"></td><td></td><td></td><td></td>
                    <td>
                       </td>
                </tr>  
                    
            </table>
            </div>         
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
