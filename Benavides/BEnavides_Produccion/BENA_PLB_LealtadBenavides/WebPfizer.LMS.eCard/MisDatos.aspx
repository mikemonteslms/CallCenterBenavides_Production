<%@ Page Language="C#" MasterPageFile="~/NBenavidesMaster.Master" AutoEventWireup="true"
    CodeBehind="MisDatos.aspx.cs" Inherits="WebPfizer.LMS.eCard.MisDatos" Title="" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div style="width:555px; height:510px; background-color:#D7D7D7;">
<table class="tablaSinbordes">
            <tr><td style="width:30px; height:30px;"></td><td>
                </td><td ></td><td>
                </td>
                <td>
                    </td>
                </tr>
            <tr><td style="width:30px;"></td><td>
                <asp:Label ID="Label11" runat="server" CssClass="LabelRegistro" 
                    Text="Nombre(s)"></asp:Label>
                </td><td style="width:40px;"></td><td>
                <asp:Label ID="Tarjeta" runat="server" CssClass="LabelRegistro" 
                    Text="Tarjeta"></asp:Label>
                </td>
                <td rowspan="26" valign="bottom">
                    <asp:Image ID="Image2" runat="server" 
        
        ImageUrl="~/Imagenes_Benavides/MasterNueva/2-mis_datos/img-mis_datos-85x420.png" /></td>
                </tr>
                <tr><td style="height:10px;"></td><td></td><td></td><td></td>
                </tr>
                <tr><td></td><td>
                <asp:Label ID="lblNombre" runat="server" CssClass="LabelMisDatos"></asp:Label>
                    </td><td></td><td>
                <asp:Label ID="lblTarjeta" runat="server" CssClass="LabelMisDatos"></asp:Label>
                    </td>
                </tr>
                    <tr><td style="height:10px;"></td><td></td><td></td><td></td>
                </tr>
             <tr><td></td><td>
                <asp:Label ID="Label13" runat="server" CssClass="LabelRegistro" 
                    Text="Apellido paterno"></asp:Label>
                </td><td style="width:40px;"></td><td>
                <asp:Label ID="Label14" runat="server" CssClass="LabelRegistro" 
                    Text="Género"></asp:Label>
                </td>
                </tr>
                <tr><td style="height:10px;"></td><td></td><td></td><td></td>
                </tr>
                <tr><td></td><td>
                <asp:Label ID="lblAP" runat="server" CssClass="LabelMisDatos"></asp:Label>
                    </td><td></td><td>
                <asp:Label ID="lblGenero" runat="server" CssClass="LabelMisDatos"></asp:Label>
                    </td>
                </tr>
                <tr><td style="height:10px;"></td><td></td><td></td><td></td>
                </tr>
                <tr><td></td><td>
                <asp:Label ID="Label23" runat="server" CssClass="LabelRegistro" 
                    Text="Apellido materno"></asp:Label>
                    </td><td></td><td>
                <asp:Label ID="Label16" runat="server" CssClass="LabelRegistro" 
                    Text="¿Tienes hijos?"></asp:Label>
                    </td>
                </tr>
                 <tr><td style="height:10px;"></td><td></td><td></td><td></td>
                </tr>
                 <tr><td></td><td>
                <asp:Label ID="lblAM" runat="server" CssClass="LabelMisDatos"></asp:Label>
                     </td><td></td><td>
                <asp:Label ID="lblHijos" runat="server" CssClass="LabelMisDatos"></asp:Label>
                     </td>
                </tr>
                    <tr><td style="height:10px;"></td><td></td><td></td><td></td>
                </tr>
                 <tr><td></td><td>
                <asp:Label ID="Label15" runat="server" CssClass="LabelRegistro" 
                    Text="Correo electrónico"></asp:Label>
                </td><td style="width:40px;"></td><td>
                     <asp:Label ID="Label22" runat="server" CssClass="LabelRegistro" 
                         Text="Código postal"></asp:Label>
                </td>
                </tr>
                <tr><td style="height:10px;"></td><td></td><td></td><td></td>
                </tr>
                <tr><td></td><td>
                <asp:Label ID="lblCorreo" runat="server" CssClass="LabelMisDatos"></asp:Label>
                    </td><td></td><td>
                <asp:Label ID="lblCP" runat="server" CssClass="LabelMisDatos"></asp:Label>
                    </td>
                </tr>
                <tr><td style="height:10px;">&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td></tr>
                <tr id="trConfirma" runat="server" style="display:none">
                    <td style="height:10px;"></td>
                    <td colspan="3">
                        <img src="Imagenes_Benavides/botones/email.png" style="height:25px; width:25px"/><span class="LabelMisDatos">¿Aún no recibes tu correo de bienvenida?<br />Si tu dirección de correo electrónico es correcta, reenvialo dando clic </span><asp:LinkButton 
                            ID="lnkConfirma" runat="server" Text="aquí" onclick="lnkConfirma_Click" CssClass="LabelMisDatos" style="color:#2B347A"></asp:LinkButton>
                    </td>
                </tr>
                <tr><td style="height:10px;"></td><td></td><td></td><td></td>
                </tr>
                 <tr><td></td><td>
                <asp:Label ID="Label17" runat="server" CssClass="LabelRegistro" 
                    Text="Teléfono celular"></asp:Label>
                </td><td style="width:40px;"></td><td>
                     <asp:Label ID="Ciudad" runat="server" CssClass="LabelRegistro" Text="Ciudad"></asp:Label>
                     </td>
                </tr>
                <tr><td style="height:10px;"></td><td></td><td></td><td></td>
                </tr>
                <tr><td></td><td>
                <asp:Label ID="lblCelular" runat="server" CssClass="LabelMisDatos"></asp:Label>
                    </td><td></td><td>
                    <asp:Label ID="lblCiudad" runat="server" CssClass="LabelMisDatos"></asp:Label>
                    </td>
                </tr>
                 <tr><td style="height:10px;"></td><td></td><td></td><td></td>
                </tr>
                 <tr><td></td><td>
                <asp:Label ID="Label19" runat="server" CssClass="LabelRegistro" 
                    Text="Fecha de nacimiento"></asp:Label>
                </td><td style="width:40px;"></td><td>
                
                    </td>
                </tr>
                <tr><td style="height:10px;"></td><td></td><td></td><td></td>
                </tr>
                <tr><td></td><td>
                <asp:Label ID="lblFechaN" runat="server" CssClass="LabelMisDatos"></asp:Label>
                    </td><td></td><td>
                
                   </td>
                </tr>
                <tr><td style="height:30px;"></td><td></td><td></td><td></td></tr>
                <tr><td></td><td>
                    <asp:ImageButton ID="btnActualizar" runat="server" 
                        
                        ImageUrl="~/Imagenes_Benavides/MasterNueva/2-mis_datos/btn-actualizar-datos.jpg" 
                        onclick="btnActualizar_Click" />
                    </td><td></td><td>
                    <asp:ImageButton ID="btnCambiar" runat="server" 
                        
                        ImageUrl="~/Imagenes_Benavides/MasterNueva/2-mis_datos/btn-cambiar-contasena.jpg" 
                        onclick="btnCambiar_Click" />
                    </td>
                    </tr>
                <tr><td style="height:30px;"></td><td>
                    </td><td></td><td>
                    </td>
                    </tr>
                </table>
     </div>                              
</asp:Content>