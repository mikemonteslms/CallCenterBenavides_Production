<%@ Page Language="C#" MasterPageFile="~/NBenavidesMaster.Master" AutoEventWireup="true"
    CodeBehind="ClubPequesRegistro.aspx.cs" Inherits="WebPfizer.LMS.eCard.ClubPequesRegistro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <script type="text/javascript" language="javascript">
     function diHola(mensaje, pagina) {
         alert(mensaje);
         window.location.href = (pagina);
     }
</script>
    
    <table style="background-image: url('Imagenes_Benavides/MasterNueva/8-registro/bg-registro-clubpeques/bg-registro-clubpeques_1.png'); background-repeat: no-repeat; width:740px; border-style: none; border-collapse:collapse; padding:0; margin:0; border-bottom-width:0;" cellpadding="0" cellspacing="0">
   <tr>
   <td style="width:740px; height:30px;">
   
   </td>
   </tr>
   </table>

   <table style="background-image: url('Imagenes_Benavides/MasterNueva/8-registro/bg-registro-clubpeques/bg-registro-clubpeques_2.png'); background-repeat: repeat-y; width:740px;">
   <tr>
   <td> <table cellpadding="0" cellspacing="0" style="border-style: none; border-collapse:collapse; padding:0; margin:0; border-bottom-width:0;">                   
           <tr>
               <td style="width:270px;">
                   </td>
               <td>
                   <img class="style2" 
                       src="Imagenes_Benavides/MasterNueva/8-registro/img-clubpeques-logo-200x140.png" /></td>
           </tr>
          
           <tr>
               <td style="height:40px;">
                   </td>
               <td>
                    </td>
           </tr>
          
       </table>
   <table  class="tablaSinbordes"><tr><td style="width:30px;"></td>
       <td>
           <asp:Label ID="Label24" runat="server" Font-Names="FuturaStd-Bold" 
               Font-Size="14px" ForeColor="#FF0033" Text="*"></asp:Label>
           <asp:Label ID="lblPeques1" runat="server" CssClass="LabelPanelPeque" 
               Text="¿Estas Embarazada?"></asp:Label>
          </td>
       </tr>
       <tr>
           <td>
               </td>
           <td style="height:10px;">
               </td>
       </tr>
       <tr>
           <td>
               </td>
           <td>
               <asp:RadioButtonList ID="rblEmbarazo" runat="server" 
                   Font-Names="FuturaStd-Book" Font-Size="14px" ForeColor="#2B347A" 
                   RepeatDirection="Horizontal" 
                   onselectedindexchanged="rblEmbarazo_SelectedIndexChanged" 
                   AutoPostBack="True">
                   <asp:ListItem Value="1">Si</asp:ListItem>
                   <asp:ListItem Value="0">No</asp:ListItem>
               </asp:RadioButtonList>
           </td>
       </tr>
       <tr>
           <td>
               </td>
           <td style="height:10px;">
               </td>
       </tr>
       <tr>
           <td>
               </td>
           <td>
               <asp:Label ID="lblNacera" runat="server" Font-Names="FuturaStd-Bold" 
                   Font-Size="14px" ForeColor="#FF0033" Text="*" Visible="False"></asp:Label>
               <asp:Label ID="lblPeques21" runat="server" CssClass="LabelPanelPeque" 
                   Text="¿Cuándo nacerá tu bebé?"></asp:Label>
           </td>
       </tr>
       <tr>
           <td>
               </td>
           <td style="height:10px;">
               </td>
       </tr>
       <tr>
           <td>
               </td>
           <td>
               <table>
                   <tr>
                       <td>
                           <asp:DropDownList ID="ddlAnoPeque" runat="server" AutoPostBack="True" 
                               BorderWidth="0" Font-Names="FuturaStd-Book" Font-Size="14px" 
                               ForeColor="#666666" Height="25px" 
                               onselectedindexchanged="ddlAnoPeque_SelectedIndexChanged" Width="85px">
                           </asp:DropDownList>
                       </td>
                       <td style="width:10px;">
                       </td>
                       <td>
                           <asp:DropDownList ID="ddlMesPeque" runat="server" AutoPostBack="True" 
                               BorderWidth="0" Font-Names="FuturaStd-Book" Font-Size="14px" 
                               ForeColor="#666666" Height="25px" 
                               onselectedindexchanged="ddlMesPeque_SelectedIndexChanged" Width="125px">
                           </asp:DropDownList>
                       </td>
                       <td style="width:10px;">
                       </td>
                       <td>
                           <asp:DropDownList ID="ddlDiaPeque" runat="server" BorderWidth="0" 
                               Font-Names="FuturaStd-Book" Font-Size="14px" ForeColor="#666666" Height="25px" 
                               Width="85px" Visible="False">
                           </asp:DropDownList>
                       </td>
                   </tr>
               </table>
           </td>
       </tr>
       <tr>
           <td>
               </td>
           <td style="height:10px;">
               </td>
       </tr>
       <tr>
           <td>
               </td>
           <td>
               <asp:Label ID="Label26" runat="server" Font-Names="FuturaStd-Bold" 
                   Font-Size="14px" ForeColor="#FF0033" Text="*"></asp:Label>
               <asp:Label ID="lblPeques22" runat="server" CssClass="LabelPanelPeque" 
                   Text="¿Tienes hijos menores a 3 años?"></asp:Label>
           </td>
       </tr>
       <tr>
           <td>
               </td>
           <td style="height:10px;">
               </td>
       </tr>
       <tr>
           <td>
               </td>
           <td>
               <asp:RadioButtonList ID="rblTienesHijos" runat="server" 
                   Font-Names="FuturaStd-Book" Font-Size="14px" ForeColor="#2B347A" 
                   RepeatDirection="Horizontal" 
                   onselectedindexchanged="rblTienesHijos_SelectedIndexChanged" 
                   AutoPostBack="True">
                   <asp:ListItem Value="1">Si</asp:ListItem>
                   <asp:ListItem Value="0">No</asp:ListItem>
               </asp:RadioButtonList>
           </td>
       </tr>
       <tr>
           <td>
               </td>
           <td style="height:10px;">
               </td>
       </tr>
       <tr>
           <td>
               </td>
           <td>
               <asp:Label ID="Label27" runat="server" Font-Names="FuturaStd-Bold" 
                   Font-Size="14px" ForeColor="#FF0033" Text="*"></asp:Label>
               <asp:Label ID="lblPeques23" runat="server" CssClass="LabelPanelPeque" 
                   Text="¿Cuántos hijos menores a 3 años tienes?"></asp:Label>
           </td>
       </tr>
       <tr>
           <td>
               </td>
           <td style="height:10px;">
               </td>
       </tr>
       <tr>
           <td>
               </td>
           <td>
               <asp:DropDownList ID="ddlCuantosHijos" runat="server" AutoPostBack="True" 
                   BorderWidth="0" Font-Names="FuturaStd-Book" Font-Size="14px" 
                   ForeColor="#666666" Height="25px"                    
                   Width="130px" Enabled="False" 
                   onselectedindexchanged="ddlCuantosHijos_SelectedIndexChanged">
                   <asp:ListItem Value="0">Selecciona</asp:ListItem>
                   <asp:ListItem Value="1">1</asp:ListItem>
                   <asp:ListItem Value="2">2</asp:ListItem>
                   <asp:ListItem Value="3">3</asp:ListItem>
                   <asp:ListItem Value="4">4</asp:ListItem>
               </asp:DropDownList>
           </td>
       </tr>
       <tr>
           <td>
               </td>
           <td style="height:10px;">
               </td>
       </tr>
       </table>
           
    
       <table id="tablaH" visible="false" runat="server" cellpadding="0" cellspacing="0" style="border-style: none; border-collapse:collapse; padding:0; margin:0; border-bottom-width:0;">                   
           <tr>
               <td style="width:35px;">
                   </td>
               <td>
                           <asp:Label ID="lblPeques24" runat="server" CssClass="LabelPanelPeque" 
                               Text="Nombre(s)"></asp:Label>
                           </td>
               <td style="width:20px;">
                           </td>
               <td>
                           <asp:Label ID="lblPeques25" runat="server" CssClass="LabelPanelPeque" 
                               Text="Fecha de nacimiento"></asp:Label>
                           </td>
               <td style="width:20px;">
                           </td>
               <td>
                           <asp:Label ID="lblPeques26" runat="server" CssClass="LabelPanelPeque" 
                               Text="Género"></asp:Label>
                           </td>
           </tr>
           <tr>
               <td style="width:35px; height:10px;">
                   </td>
               <td style="height:10px;">
                           </td>
               <td>
                           </td>
               <td>
                           </td>
               <td>
                           </td>
               <td>
                           </td>
           </tr>
           <tr>
               <td>
                    <asp:HiddenField ID="hdnHijo1" runat="server" Value="0"/>
                   </td>
               <td>
                    <asp:TextBox ID="txtNomH1" runat="server" Height="25px" Width="245px" Font-Names="FuturaStd-Book" ForeColor="#666666"  Font-Size="14px"
                        BorderWidth="0"></asp:TextBox>
                </td>
               <td>
                    </td>
               <td>
                   <table cellpadding="0" cellspacing="0" style="border-style: none; border-collapse:collapse; padding:0; margin:0; border-bottom-width:0;"><tr><td>
                        <asp:DropDownList ID="ddlAnoFNP1" runat="server" Width="60px" BorderWidth="0" 
                          Font-Names="FuturaStd-Book" ForeColor="#666666"  Font-Size="14px" 
                           AutoPostBack="True" Height="25px" 
                            onselectedindexchanged="ddlAnoFNP1_SelectedIndexChanged">
                        </asp:DropDownList>
                        </td><td style="width:10px;"></td><td>
                        <asp:DropDownList ID="ddlMesFNP1" runat="server" Width="100px" BorderWidth="0" 
                           Font-Names="FuturaStd-Book" ForeColor="#666666"  Font-Size="14px" 
                           AutoPostBack="True" Height="25px" 
                            onselectedindexchanged="ddlMesFNP1_SelectedIndexChanged">
                        </asp:DropDownList>
                        </td><td style="width:10px;"></td><td>
                        <asp:DropDownList ID="ddlDiaFNP1" runat="server" Width="50px" BorderWidth="0" 
                          Font-Names="FuturaStd-Book" ForeColor="#666666"  Font-Size="14px" 
                            Height="25px">
                        </asp:DropDownList>
                        </td></tr></table></td>
               <td>
                   </td>
               <td>
                   <asp:RadioButtonList ID="rdoGeneroP1" runat="server"  
                                          RepeatDirection="Horizontal">                                        
                                        <asp:ListItem Value="2"><img alt='' src='Imagenes_Benavides/MasterNueva/8-registro/img-genero-25x25-4.png'></asp:ListItem>
                                        <asp:ListItem Value="1"><img alt='' src='Imagenes_Benavides/MasterNueva/8-registro/img-genero-25x25-3.png'></asp:ListItem>                                       
                                        <%--<asp:ListItem Value="3" Enabled="false">Indefinido</asp:ListItem>--%>
                                    </asp:RadioButtonList></td>
           </tr>
           <tr>
               <td style="width:35px; height:10px;">
                   </td>
               <td style="height:10px;">
                           </td>
               <td>
                           </td>
               <td>
                           </td>
               <td>
                           </td>
               <td>
                           </td>
           </tr>
           <tr>
               <td>
                    <asp:HiddenField ID="hdnHijo2" runat="server" Value="0" />
                   </td>
               <td>
                    <asp:TextBox ID="txtNomH2" runat="server" Height="25px" Width="245px" Font-Names="FuturaStd-Book" ForeColor="#666666"  Font-Size="14px"
                        BorderWidth="0" Visible="False"></asp:TextBox>
                </td>
               <td>
                    </td>
               <td>
                   <table cellpadding="0" cellspacing="0" style="border-style: none; border-collapse:collapse; padding:0; margin:0; border-bottom-width:0;">
                       <tr>
                           <td>
                               <asp:DropDownList ID="ddlAnoFNP2" runat="server" AutoPostBack="True"  BorderWidth="0"
                                   Font-Names="FuturaStd-Book" ForeColor="#666666"  Font-Size="14px" Width="60px" 
                                   Height="25px" Visible="False" 
                                   onselectedindexchanged="ddlAnoFNP2_SelectedIndexChanged">
                               </asp:DropDownList>
                           </td>
                           <td style="width:10px;">
                           </td>
                           <td>
                               <asp:DropDownList ID="ddlMesFNP2" runat="server" AutoPostBack="True"  BorderWidth="0"
                                   Font-Names="FuturaStd-Book" ForeColor="#666666"  Font-Size="14px"
                                   Width="100px" 
                                   Height="25px" Visible="False" 
                                   onselectedindexchanged="ddlMesFNP2_SelectedIndexChanged">
                               </asp:DropDownList>
                           </td>
                           <td style="width:10px;">
                           </td>
                           <td>
                        <asp:DropDownList ID="ddlDiaFNP2" runat="server" Width="50px" BorderWidth="0" 
                         Font-Names="FuturaStd-Book" ForeColor="#666666"  Font-Size="14px" Height="25px" 
                                   Visible="False">
                        </asp:DropDownList>
                           </td>
                       </tr>
                   </table>
               </td>
               <td>
                   </td>
               <td>
                   <asp:RadioButtonList ID="rdoGeneroP2" runat="server"  
                                          RepeatDirection="Horizontal" Visible="False">                                        
                                        <asp:ListItem Value="2"><img alt='' src='Imagenes_Benavides/MasterNueva/8-registro/img-genero-25x25-4.png'></asp:ListItem>
                                        <asp:ListItem Value="1"><img alt='' src='Imagenes_Benavides/MasterNueva/8-registro/img-genero-25x25-3.png'></asp:ListItem>                                       
                                        <%--<asp:ListItem Value="3" Enabled="false">Indefinido</asp:ListItem>--%>
                                    </asp:RadioButtonList></td>
           </tr>
           <tr>
               <td style="width:35px; height:10px;">
                   </td>
               <td style="height:10px;">
                           </td>
               <td>
                           </td>
               <td>
                           </td>
               <td>
                           </td>
               <td>
                           </td>
           </tr>
           <tr>
               <td>
                    <asp:HiddenField ID="hdnHijo3" runat="server" Value="0" />
                   </td>
               <td>
                    <asp:TextBox ID="txtNomH3" runat="server" Height="25px" Width="245px" Font-Names="FuturaStd-Book" ForeColor="#666666"  Font-Size="14px"
                        BorderWidth="0" Visible="False"></asp:TextBox>
                </td>
               <td>
                    </td>
               <td>
                   <table cellpadding="0" cellspacing="0" style="border-style: none; border-collapse:collapse; padding:0; margin:0; border-bottom-width:0;">
                       <tr>
                           <td>
                               <asp:DropDownList ID="ddlAnoFNP3" runat="server" AutoPostBack="True"  BorderWidth="0"
                                   Font-Names="FuturaStd-Book" ForeColor="#666666"  Font-Size="14px" Width="60px" 
                                   Height="25px" Visible="False" 
                                   onselectedindexchanged="ddlAnoFNP3_SelectedIndexChanged">
                               </asp:DropDownList>
                           </td>
                           <td style="width:10px;">
                           </td>
                           <td>
                               <asp:DropDownList ID="ddlMesFNP3" runat="server" AutoPostBack="True"  BorderWidth="0"
                                   Font-Names="FuturaStd-Book" ForeColor="#666666"  Font-Size="14px" Width="100px" 
                                   Height="25px" Visible="False" 
                                   onselectedindexchanged="ddlMesFNP3_SelectedIndexChanged">
                               </asp:DropDownList>
                           </td>
                           <td style="width:10px;">
                           </td>
                           <td>
                        <asp:DropDownList ID="ddlDiaFNP3" runat="server" Width="50px"  BorderWidth="0"
                           Font-Names="FuturaStd-Book" ForeColor="#666666"  Font-Size="14px" Height="25px" 
                                   Visible="False">
                        </asp:DropDownList>
                           </td>
                       </tr>
                   </table>
               </td>
               <td>
                   </td>
               <td>
                   <asp:RadioButtonList ID="rdoGeneroP3" runat="server"  
                                          RepeatDirection="Horizontal" Visible="False">
                                          <asp:ListItem Value="2"><img alt='' src='Imagenes_Benavides/MasterNueva/8-registro/img-genero-25x25-4.png'></asp:ListItem>
                                          <asp:ListItem Value="1"><img alt='' src='Imagenes_Benavides/MasterNueva/8-registro/img-genero-25x25-3.png'></asp:ListItem>                                        
                                        <%--<asp:ListItem Value="3" Enabled="false">Indefinido</asp:ListItem>--%>
                                    </asp:RadioButtonList></td>
           </tr>
           <tr>
               <td style="width:35px; height:10px;">
                   </td>
               <td style="height:10px;">
                           </td>
               <td>
                           </td>
               <td>
                           </td>
               <td>
                           </td>
               <td>
                           </td>
           </tr>
           <tr>
               <td>
                   <asp:HiddenField ID="hdnHijo4" runat="server" Value="0" />
                   </td>
               <td>
                    <asp:TextBox ID="txtNomH4" runat="server" Height="25px" Width="245px" Font-Names="FuturaStd-Book" ForeColor="#666666"  Font-Size="14px"
                        BorderWidth="0" Visible="False"></asp:TextBox>
                </td>
               <td>
                    </td>
               <td>
                  <table cellpadding="0" cellspacing="0" style="border-style: none; border-collapse:collapse; padding:0; margin:0; border-bottom-width:0;">
                       <tr>
                           <td>
                               <asp:DropDownList ID="ddlAnoFNP4" runat="server" AutoPostBack="True"  BorderWidth="0"
                                   Font-Names="FuturaStd-Book" ForeColor="#666666"  Font-Size="14px" Width="60px" 
                                   Height="25px" Visible="False" 
                                   onselectedindexchanged="ddlAnoFNP4_SelectedIndexChanged">
                               </asp:DropDownList>
                           </td>
                           <td style="width:10px;">
                           </td>
                           <td>
                               <asp:DropDownList ID="ddlMesFNP4" runat="server" AutoPostBack="True"  BorderWidth="0"
                                   Font-Names="FuturaStd-Book" ForeColor="#666666"  Font-Size="14px" Width="100px" 
                                   Height="25px" Visible="False" 
                                   onselectedindexchanged="ddlMesFNP4_SelectedIndexChanged">
                               </asp:DropDownList>
                           </td>
                           <td style="width:10px;">
                           </td>
                           <td>
                        <asp:DropDownList ID="ddlDiaFNP4" runat="server" Width="50px"  BorderWidth="0"
                           Font-Names="FuturaStd-Book" ForeColor="#666666"  Font-Size="14px" Height="25px" 
                                   Visible="False">
                        </asp:DropDownList>
                           </td>
                       </tr>
                   </table>
               </td>
               <td>
                   </td>
               <td>
                   <asp:RadioButtonList ID="rdoGeneroP4" runat="server"  
                                          RepeatDirection="Horizontal" Visible="False">
                                        <asp:ListItem Value="2"><img alt='' src='Imagenes_Benavides/MasterNueva/8-registro/img-genero-25x25-4.png'></asp:ListItem>
                                        <asp:ListItem Value="1"><img alt='' src='Imagenes_Benavides/MasterNueva/8-registro/img-genero-25x25-3.png'></asp:ListItem>                                                                               
                                        <%--<asp:ListItem Value="3" Enabled="false">Indefinido</asp:ListItem>--%>
                                    </asp:RadioButtonList></td>
           </tr>
       </table>
       <table><tr><td style="width:30px;">
           </td>
           <td>
               <asp:CheckBox ID="chkTerminos" runat="server" Checked="true" 
                   Font-Names="FuturaStd-Bold" Font-Size="14px" ForeColor="#666666" 
                   Text="Acepto Términos y Condiciones" />
           </td>
           </tr>
           <tr>
                        <td  align="left">

                            &nbsp;</td>
                            <td>

                            <asp:CheckBox ID="chkRecibirInfo" runat="server" Checked="true" 
                                Font-Names="FuturaStd-Bold" Font-Size="14px" ForeColor="#666666" 
                                Text="Acepto recibir información y promociones de Farmacias Benavides." 
                                Enabled="true" />

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
               <td>
                   <asp:Label ID="Label28" runat="server" Font-Names="FuturaStd-Book" 
                       Font-Size="14px" ForeColor="#FF0033" Text="(*)Campos obligatorios"></asp:Label>
               </td>
           </tr>
           <tr>
               <td>
                   </td>
               <td style="height:20px;">
                   </td>
           </tr>
           <tr>
                        <td>
                            </td>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <asp:ImageButton ID="btnCancelar" runat="server" 
                                            ImageUrl="~/Imagenes_Benavides/MasterNueva/7-olvidaste_contrasena/btn-regresar.jpg" 
                                            OnClick="btnCancelar_Click" />
                                    </td>
                                    <td style="width:40px;">
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="btnRegistrar" runat="server" 
                                            ImageUrl="~/Imagenes_Benavides/MasterNueva/8-registro/btn-aceptar.jpg" 
                                            OnClick="btnRegistrar_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
       </table>
       </td>
   </tr>
   </table>
   
   <table style="background-image: url('Imagenes_Benavides/MasterNueva/8-registro/bg-registro-clubpeques/bg-registro-clubpeques_3.png'); background-repeat: no-repeat; width:740px; border-style: none; border-collapse:collapse; padding:0; margin:0; border-bottom-width:0;" cellpadding="0" cellspacing="0">
   <tr>
   <td style="width:740px; height:30px;">
   
   </td>
   </tr>
   </table>
   
    

 </asp:Content>