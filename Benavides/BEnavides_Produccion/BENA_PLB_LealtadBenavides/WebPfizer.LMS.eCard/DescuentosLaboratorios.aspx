<%@ Page Language="C#" MasterPageFile="~/NBenavidesMaster.Master" AutoEventWireup="true"
    CodeBehind="DescuentosLaboratorios.aspx.cs" Inherits="WebPfizer.LMS.eCard.DescuentosLaboratorios" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
                                                         
   <div id="divAzul" runat="server" style="background-color:#D7D7D7; width:610px;">
   <table class="tablaSinbordes">
<tr>
<td><asp:Image ID="Image1" runat="server" 
        
        ImageUrl="~/Imagenes_Benavides/MasterNueva/5-mis_beneficios_platino/img-beneficios-platino.png" /></td>
</tr>    
</table>       
<table class="tablaSinbordes">
<tr><td style="width:30px; height:15px;"></td><td></td></tr>
<tr><td></td><td><asp:Image ID="Image2" runat="server" 
        
        ImageUrl="~/Imagenes_Benavides/MasterNueva/5-mis_beneficios_platino/btn-beneficios-platino-235x60-10.png" /></td></tr>
<tr><td style="height:15px;"></td><td></td></tr>
</table>
   </div> 
     <div id="div2" runat="server" style="background-color:#FFFFFF;">         
   <table class="tablaSinbordes">
   <tr>
   <td style="width:15px;"></td>
   <td><br /></td>
                            </tr>
   <tr>
   <td style="width:30px;"></td>
   <td>
       <table class="tablaSinbordes" >
           <tr>
               <td>
                   <asp:Label ID="Label1" runat="server" Text="Estado" Font-Names="FuturaStd-Book" 
                            Font-Size="14px" ForeColor="#666666"></asp:Label>
                   </td>
               <td style="width:20px;">
                   </td>
               <td>
                   <asp:Label ID="Label2" runat="server" Text="Delegación o municipio" Font-Names="FuturaStd-Book" 
                            Font-Size="14px" ForeColor="#666666"></asp:Label>
                   </td>
               <td style="width:20px;">
                   </td>
               <td>
                   <asp:Label ID="Label3" runat="server" Text="Laboratorio" Font-Names="FuturaStd-Book" 
                            Font-Size="14px" ForeColor="#666666"></asp:Label>
                   </td>
           </tr>
           <tr>
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
                   <asp:DropDownList ID="ddEstado" runat="server" Font-Names="FuturaStd-Book" 
                            Font-Size="14px" ForeColor="#666666" AutoPostBack="True" 
                       onselectedindexchanged="ddEstado_SelectedIndexChanged" Width="150px">
                   </asp:DropDownList>
                   </td>
               <td>
                   </td>
               <td>
                   <asp:DropDownList ID="ddCiudad" runat="server" Font-Names="FuturaStd-Book" 
                            Font-Size="14px" ForeColor="#666666" AutoPostBack="True" 
                       Enabled="False" onselectedindexchanged="ddCiudad_SelectedIndexChanged" 
                       Width="150px">
                   </asp:DropDownList>
                   </td>
               <td>
                   </td>
               <td>
                   <asp:DropDownList ID="ddLaboratorio" runat="server" Font-Names="FuturaStd-Book" 
                            Font-Size="14px" ForeColor="#666666" AutoPostBack="True" 
                       Enabled="False" Width="150px" 
                       onselectedindexchanged="ddLaboratorio_SelectedIndexChanged">
                   </asp:DropDownList>
                   </td>
           </tr>
           <tr>
               <td>
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
       </table>
                            </td>
                            </tr>
   <tr>
   <td style="width:15px;"></td>
   <td></td>
    </tr>
   <tr>
   <td style="width:15px;"></td>
   <td>
       <hr />
       </td>
    </tr>
   <tr>
   <td style="width:30px;"></td>
   <td>  
   <asp:Panel ID="Panel2" runat="server" BackColor="Transparent" Height="200px" 
                         Width="500px">   
          <div style="width: 100%; height: 100%; overflow: auto">       
          <asp:GridView ID="grdPromociones" runat="server" AutoGenerateColumns="false"                                                        
                                                        Width="400px" Height="100px"  
                       Font-Names="FuturaStd-Book" Font-Size="12px" ForeColor="#666666" 
                       CellPadding="0" GridLines="None"
                                                        BackColor="White" >
                                                        <AlternatingRowStyle BackColor="#E6E6E6" Font-Names="FuturaStd-Book" 
                                                            Font-Size="12px" ForeColor="#666666"  />
                                                        <HeaderStyle   />
                                                        <RowStyle CssClass="gridMisMov" />
                                                        <Columns>
                                                         <asp:BoundField DataField="DescripcionEstado"  HeaderImageUrl="~/Imagenes_Benavides/MasterNueva/21-descuentos_laboratorios/img-tabla-descuentos/img-tabla-descuentos_01.jpg"
                                                                ItemStyle-Width="20px" ItemStyle-HorizontalAlign="Center"/>
                                                          <asp:BoundField DataField="DescripcionMunicipio"  HeaderImageUrl="~/Imagenes_Benavides/MasterNueva/21-descuentos_laboratorios/img-tabla-descuentos/img-tabla-descuentos_02.jpg"
                                                                ItemStyle-Width="20px" ItemStyle-HorizontalAlign="Center"/>
                                                           <asp:BoundField DataField="LaboratorioDescripcion"  HeaderImageUrl="~/Imagenes_Benavides/MasterNueva/21-descuentos_laboratorios/img-tabla-descuentos/img-tabla-descuentos_03.jpg"
                                                                ItemStyle-Width="20px" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:BoundField DataField="Servicio"  HeaderImageUrl="~/Imagenes_Benavides/MasterNueva/21-descuentos_laboratorios/img-tabla-descuentos/img-tabla-descuentos_04.jpg"
                                                            ItemStyle-Width="20px" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:BoundField DataField="Descuento"  HeaderImageUrl="~/Imagenes_Benavides/MasterNueva/21-descuentos_laboratorios/img-tabla-descuentos/img-tabla-descuentos_05.jpg"
                                                            ItemStyle-Width="20px" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="#2B347A" />
                                                        </Columns>
          </asp:GridView>
          </div>
        </asp:Panel>
       </td>
                            </tr>
   <tr>
   <td style="width:30px; height:30px;"></td>
   <td>  
   </td>
                            </tr>
   <tr>
   <td style="width:30px;"></td>
   <td>   
         <asp:Label ID="Label4" runat="server" 
             Text="Operado y a cargo de ACE Seguros, S.A.<br />Consulta laboratorios participantes en la página <a href='http:\\www.benavides.com.mx'>www.benavides.com.mx</a><br />Para aclarar dudas y consultar tu saldo llama si costo al 01 800 444 25 25. <br />Para información acerca de tu seguro o caso de siniestro, servicio de ambulancia, descuentos en laboratorios de análisis clínicos y orientación telefónica comunícate al 01 800 237 62 66 o ingresa a <a href='http:\\www.acegroup.com/mx-es'>www.acegroup.com/mx-es</a>" Font-Names="FuturaStd-Book" 
                            Font-Size="14px" ForeColor="#666666" Width="500px"></asp:Label> 
   </td>
                            </tr>
                            <tr>
   <td style="width:30px;"></td>
   <td>   
    <br />    
   </td>
                            </tr>
                            </table>
   </div>
        <br />
    <div style="float: right; margin-right: 25px" class="linksBenaRecupera"><a class="linksBenaRecupera" style="font-weight:bold" href="javascript:window.history.back();">Volver</a></div> 
                     
                        

     
</asp:Content>