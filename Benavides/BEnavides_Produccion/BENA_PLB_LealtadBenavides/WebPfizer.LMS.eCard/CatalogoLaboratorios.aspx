
<%@ Page Language="C#" MasterPageFile="~/NBenavidesMaster.Master" AutoEventWireup="true"
    CodeBehind="CatalogoLaboratorios.aspx.cs" Inherits="WebPfizer.LMS.eCard.CatalogoLaboratorios" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
         
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
                                                         
   <div id="divAzul" runat="server" style="background-color:#2B347A; width:610px;">
   <table class="tablaSinbordes">
<tr>
<td><asp:Image ID="Image1" runat="server" 
        ImageUrl="~/Imagenes_Benavides/MasterNueva/4-mis_beneficios_blue/img-beneficios-blue.png" /></td>
</tr>    
</table>       
<table class="tablaSinbordes">
<tr><td style="width:30px; height:15px;"></td><td></td></tr>
<tr><td></td><td><asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes_Benavides/MasterNueva/4-mis_beneficios_blue/btn-beneficios-blue-235x60-5.png" /></td></tr>
<tr><td style="height:15px;"></td><td></td></tr>
</table>
   </div> 
     <div id="div2" runat="server" style="background-color:#FFFFFF;">         
   <table>
   <tr>
   <td style="width:15px;"></td>
   <td><br /></td>
                            </tr>
   <tr>
   <td style="width:30px;"></td>
   <td><asp:Label ID="Label2a" runat="server" Text="[ Da click sobre el laboratorio para conocer las promociones participantes ]" Font-Names="FuturaStd-Book" 
                            Font-Size="14px" ForeColor="#666666"></asp:Label>   
                            </td>
                            </tr>
   <tr>
   <td style="width:15px;"></td>
   <td></td>
    </tr>
   <tr>
   <td style="width:30px;"></td>
   <td> <asp:Panel ID ="panelCatalogoLaboratorios" runat ="server" 
        HorizontalAlign ="Center"  >
    <table class="tablaSinbordes"  width ="100%" >
    
    <tr>  
    <td align="left">                                 
    <asp:Panel ID ="ScrollablePanel" runat ="server" ScrollBars ="Auto"  
             BackColor ="Transparent"   >
                                    <asp:GridView ID="gvLaboratorios" runat="server" AllowPaging="true" 
                                        AutoGenerateColumns="false" BorderWidth="0" CellPadding="5" CellSpacing="5"  
                                        GridLines="None"                                         
                                         ShowHeader="false"    ShowFooter="false" 
                                        PagerSettings-Visible="False" onrowdatabound="gvLaboratorios_RowDataBound" 
                                        onrowcommand="gvLaboratorios_RowCommand">
                                        <Columns>
                                          
        <asp:TemplateField>
            <ItemTemplate>
            <asp:LinkButton ID="lnkSeleccion0" runat="server" CommandName="Seleccion0"> 
                
               
                <asp:Image id="imgCol1" imageurl="" runat="server"/>  
                 
  
                <asp:Label ID="lblIDLabC1" runat="server" Text="" Visible="false"></asp:Label>
                

                </asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField>
            <ItemTemplate>
            <asp:LinkButton ID="lnkSeleccion1" runat="server" CommandName="Seleccion1"> 
                
            
                <asp:Image id="imgCol2" imageurl="" runat="server"/>
                 

                 <asp:Label ID="lblIDLabC2" runat="server" Text="" Visible="false"></asp:Label>              
                 
                
              
                </asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField>
            <ItemTemplate>
            <asp:LinkButton ID="lnkSeleccion2" runat="server" CommandName="Seleccion2"> 
                
         
                <asp:Image id="imgCol3" imageurl="" runat="server"/>  
                  
  
                 <asp:Label ID="lblIDLabC3" runat="server" Text="" Visible="false"></asp:Label>        
                 
        
                </asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField>
            <ItemTemplate>
            <asp:LinkButton ID="lnkSeleccion3" runat="server" CommandName="Seleccion3"> 
                
         
                <asp:Image id="imgCol4" imageurl="" runat="server"/> 
                 
 
                 <asp:Label ID="lblIDLabC4" runat="server" Text="" Visible="false"></asp:Label>         
                 
         
                </asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField>
            <ItemTemplate>
            <asp:LinkButton ID="lnkSeleccion4" runat="server" CommandName="Seleccion4"> 
                
         
                <asp:Image id="imgCol5" imageurl="" runat="server"/>      
                  
      
                 <asp:Label ID="lblIDLabC5" runat="server" Text="" Visible="false"></asp:Label>    
                 
    
                </asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
                                        </Columns>                                       
                                    </asp:GridView>
                              </asp:Panel>         
        </td>
    </tr>

        <tr>
            <td width="100px">
                </td>
            <td width="600px">
                </td>
        </tr>

    </table>
     </asp:Panel>  </td>
                            </tr>
                            </table>
   </div>
     <div id="div1" runat="server" style="background-color:#2B347A;">         
<table class="tablaSinbordes">
<tr><td style="width:15px; height:15px;"></td><td></td><td style="width:15px;"></td></tr>
<tr><td></td><td align="center">
    <asp:Label ID="Label1" runat="server" Text="*Aplican restricciones en productos participantes con base en los términos y condiciones. Consulta promociones actuales y productos participantes de estos laboratorios en el teléfono 01 800 248 55 55. Activa tu promoción Novartis llamando al 01 800 726 15 15" Font-Names="FuturaStd-Book" 
                            Font-Size="10px" ForeColor="#FFFFFF"></asp:Label>
    </td><td align="center">
        </td></tr>
<tr><td style="height:15px;"></td><td></td><td></td></tr>

</table>
   </div> 

        <asp:HyperLink ID="lnkImagenDetalle" runat="server"></asp:HyperLink>

        <cc1:ModalPopupExtender ID="popImagenDetalle" runat ="server" DropShadow ="false"  
            TargetControlID ="lnkImagenDetalle" PopupControlID ="panelImagenDetalle" 
            OkControlID ="btnCloseImagenDetalle"
            BackgroundCssClass ="modalBackground" >
        </cc1:ModalPopupExtender>
        <br />
    <div style="float: right; margin-right: 25px" class="linksBenaRecupera"><a class="linksBenaRecupera" style="font-weight: bold" href="javascript:window.history.back();">Volver</a></div>       
      <asp:Panel ID="panelImagenDetalle" runat ="server"  CssClass="bmxDetallePremio" 
           >
            <asp:updatepanel ID="UpdatePanel1" runat="server">  
            <ContentTemplate>
            
      <table class="tablaSinbordes" style="width:500px;">
    <tr>
    <td align="right">
    <asp:ImageButton ID="btnCloseImagenDetalle" runat="server" ImageAlign="Top" 
                  ImageUrl="~/Imagenes_Benavides/MasterNueva/btn-cerrar.jpg" 
                  onclick="btnCloseImagenDetalle_Click" />
    </td>        
    </tr>
    </table>
     <table style="background-image: url('Imagenes_Benavides/MasterNueva/bg-popup_01.png'); background-repeat: no-repeat; width:500px; border-style: none; border-collapse:collapse; padding:0; margin:0; border-bottom-width:0;" cellpadding="0" cellspacing="0">
   <tr>
   <td style="width:740px; height:30px;">
   
   </td>
   </tr>
   </table>
    <div style="width:500px; height:470px; background:#FFFFFF;" >
   
     <table class="tablaSinbordes">
     <tr><td></td><td>
     <asp:Image ID="imgLab" runat="server" />
     </td></tr>
     <tr><td style="width:30px; height:30px;"></td><td></td></tr>
      <tr><td></td><td>
      <table><tr><td style="width:100px;">
      
      <asp:Label ID="lblMensaje" Width="430px" runat="server" Font-Names="FuturaStd-Book"  Visible="false"
                            Font-Size="14px" ForeColor="#666666" style="text-align:justify;" 
                  
              Text=""></asp:Label>
               <asp:Panel ID="Panel2" runat="server" BackColor="Transparent" Height="350px" 
                         Width="430px">
                         <table class="tablaSinbordes" style="width:400px; background-color:#436DB5;"><tr><td style="width:200px;">
                             <asp:Label ID="Label2" runat="server" Text="Producto" Font-Names="FuturaStd-Bold" Font-Size="12px" ForeColor="#FFFFFF" ></asp:Label></td><td style="width:100px;"><asp:Label ID="Label3" runat="server" Text="Promoción" Font-Names="FuturaStd-Bold" Font-Size="12px" ForeColor="#FFFFFF" ></asp:Label></td><td><asp:Label ID="Label4" runat="server" Text="Laboratorio" Font-Names="FuturaStd-Bold" Font-Size="12px" ForeColor="#FFFFFF" ></asp:Label></td></tr></table>
               <div style="width: 100%; height: 100%; overflow: auto">         
          <asp:GridView ID="grdPromociones" runat="server" AutoGenerateColumns="false" ShowHeader="false"                                                       
                                                        Width="400px" Height="100px"  
                       Font-Names="FuturaStd-Book" Font-Size="12px" ForeColor="#666666" 
                       CellPadding="0" GridLines="None"
                                                        BackColor="White" >
                                                        <AlternatingRowStyle BackColor="#E6E6E6" Font-Names="FuturaStd-Book" Font-Size="12px" ForeColor="#666666"  />
                                                        <HeaderStyle CssClass="headerfreezer"  />
                                                        <RowStyle CssClass="gridMisMov" />
                                                        <Columns>
                                                         <asp:BoundField DataField="Producto" HeaderText="Producto" ItemStyle-Width="20px" />
                                                          <asp:BoundField DataField="Promocion" HeaderText="Promocion" ItemStyle-Width="20px" />
                                                           <asp:BoundField DataField="Laboratorio" HeaderText="Laboratorio" ItemStyle-Width="20px" />
                                                        </Columns>
          </asp:GridView>
          </div>
          </asp:Panel>
              </td></tr>
                  </table>
             </td></tr>
     </table>   
     </div>           
  <table style="background-image: url('Imagenes_Benavides/MasterNueva/bg-popup_02.png'); background-repeat: no-repeat; width:500px; border-style: none; border-collapse:collapse; padding:0; margin:0; border-bottom-width:0;" cellpadding="0" cellspacing="0">
   <tr>
   <td style="width:740px; height:30px;">
   
   </td>
   </tr>
   </table>
                   </ContentTemplate>
                    </asp:updatepanel>                                                                                    
        </asp:Panel>                                       
</asp:Content>
