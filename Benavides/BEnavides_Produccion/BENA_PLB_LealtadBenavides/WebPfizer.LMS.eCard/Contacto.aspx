<%@ Page Language="C#" MasterPageFile="~/NBenavidesMaster.Master" AutoEventWireup="true"
    CodeBehind="Contacto.aspx.cs" Inherits="WebPfizer.LMS.eCard.Contacto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <script type="text/javascript" language="javascript">
     function diHola(mensaje, pagina) {
         alert(mensaje);
         window.location.href = (pagina);
     }
</script>

    <div id="divcontacto" >
    <table class="tablaSinbordes"  style="background-color: #D7D7D7">
    <tr>
    <td>
     <table class="tablaSinbordes">
        <tr>
            <td style="width:30px; height:30px;">
                </td>
            <td>
                </td>
            <td style="width:30px;">
                </td>
        </tr>
        <tr>
            <td>
                </td>
            <td>
                <table style="background-image: url('Imagenes_Benavides/MasterNueva/11-contacto/bg-contacto-495x560.png'); width:495px; height:560px;">
                <tr>
                <td>

                    <table class="tablaSinbordes">
                        <tr>
                            <td style="height:150px; width:30px;"">
                               </td>
                            <td style="height:150px;">
                                </td>
                        </tr>
                        <tr>
                            <td>
                               </td>
                            <td>
                                <asp:Label ID="lblContactoMP" runat="server" CssClass="LabelRegistro" 
                                    Text="Contacto"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="height:15px;">
                               </td>
                            <td style="height:15px;">
                            </td>
                        </tr>
                        <tr>
                            <td>
                               </td>
                            <td>
                                <asp:Label ID="lblMsnMP" runat="server" Font-Names="FuturaStd-Book" ForeColor="#666666"  Font-Size="14px"
                                    Text="Escribe tus sugerencias o comentarios."></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                               </td>
                            <td>
                                <asp:Label ID="lblMsn2MP" runat="server" Font-Names="FuturaStd-Book" 
                                    ForeColor="#FF0033"  Font-Size="14px"
                                    Text="(*) Campos obligatorios" Visible="False"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="height:20px;">
                               </td>
                            <td style="height:20px;">
                            </td>
                        </tr>
                        <tr>
                            <td>
                               </td>
                            <td>
                                <table class="tablaSinbordes">
                                    <tr>
                                        <td style="width:180px;">
                                            <asp:Label ID="lblNombreMP" runat="server" CssClass="LabelRegistro" 
                                                Text="Nombre"></asp:Label>
                                        </td>                                      
                                        <td>
                                            <asp:TextBox ID="txtNombreMP" runat="server" MaxLength="200" Width="250px" 
                                                Font-Names="FuturaStd-Book" ForeColor="#666666"  Font-Size="14px" BorderWidth="0"
                                                Height="25px" Enabled="False"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="height:10px;">
                               </td>
                            <td style="height:10px;">
                            </td>
                        </tr>
                        <tr>
                            <td>
                               </td>
                            <td>
                                <table class="tablaSinbordes">
                                    <tr>
                                        <td style="width:180px;">
                                            <asp:Label ID="lblTarjetaMP" runat="server" CssClass="LabelRegistro" 
                                                Text="Tarjeta"></asp:Label>
                                        </td>                                        
                                        <td>
                                            <asp:TextBox ID="txtTarjetaMP" runat="server" MaxLength="20" Width="250px" 
                                                Font-Names="FuturaStd-Book" ForeColor="#666666"  Font-Size="14px" BorderWidth="0"
                                                Height="25px" Enabled="False"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="height:10px;">
                               </td>
                            <td style="height:10px;">
                            </td>
                        </tr>
                        <tr>
                            <td>
                               </td>
                            <td>
                                <table class="tablaSinbordes">
                                    <tr>
                                        <td style="width:180px;">
                                            <asp:Label ID="lblCorreoMP" runat="server" CssClass="LabelRegistro" 
                                                Text="Correo electrónico"></asp:Label>
                                        </td>                                     
                                        <td>
                                            <asp:TextBox ID="txtCorreoMP" runat="server" MaxLength="50" Width="250px" 
                                                Font-Names="FuturaStd-Book" ForeColor="#666666"  Font-Size="14px" BorderWidth="0"
                                                Height="25px" Enabled="False"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="height:20px;">
                               </td>
                            <td style="height:20px;">
                                <asp:RegularExpressionValidator ID="REVMP" runat="server" Font-Names="FuturaStd-Book" Font-Size="14px" 
                                    ControlToValidate="txtCorreoMP" 
                                    ErrorMessage="El correo electrónico no es válido" 
                                    ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                    ValidationGroup="ValidaContacto"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="height:1px;">
                               </td>
                            <td style="height:1px;">
                                <hr width="435" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                               </td>
                            <td>
                                <asp:TextBox ID="txtComentarioMP" runat="server" Font-Names="FuturaStd-Book" ForeColor="#666666"  Font-Size="14px" BorderWidth="0"
                                    Text="Escribe aqui tu comentario.." TextMode="MultiLine" Height="65px" 
                                    Width="435px"></asp:TextBox><br />
                                <asp:Label ID="lblError" runat="server"  Font-Names="FuturaStd-Book" Font-Size="14px" ForeColor="#FF0033"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:30px;">
                               </td>
                            <td style="height:10px;">
                                </td>
                        </tr>
                        <tr>
                            <td>
                               </td>
                            <td align="right">
                                <asp:ImageButton ID="imgbtnEnviarMP" runat="server" 
                                    
                                    ImageUrl="~/Imagenes_Benavides/MasterNueva/7-olvidaste_contrasena/btn-enviar.jpg" 
                                    ValidationGroup="ValidaContacto" onclick="imgbtnEnviarMP_Click" />
                            </td>
                        </tr>
                    </table>

                </td>
                </tr>
                </table>
                </td>
            <td>
                </td>
        </tr>
        <tr>
            <td style="width:30px; height:30px;">
                </td>
            <td>
                </td>
            <td>
                </td>
        </tr>
    </table>
    </td>
    </tr>
    </table>

   </div>
   <div runat="server" visible="false">
   <table><tr><td style="width:40px;"></td><td>
   <asp:Label ID="Label1" runat="server" Text="Para cualquier duda o comentario escríbenos a " Font-Names="FuturaStd-Bold" 
                            Font-Size="14px" ForeColor="#2B347A"></asp:Label><a href="mailto:contactoBI@benavides.com.mx" >contactoBI@benavides.com.mx</a>
   </td></tr></table>
</div>
                            
   </asp:Content>