<%@ Page Language="C#" MasterPageFile="~/NBenavidesMaster.Master" AutoEventWireup="true"
    CodeBehind="Promociones.aspx.cs" Inherits="WebPfizer.LMS.eCard.Promociones" Title="" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <table class="tablaSinbordes" style="">
 <tr><td></td><td>
    <asp:Label ID="Label1" runat="server" Text="Selecciona una opción para ver las promociones" Font-Names="FuturaStd-Bold" 
                            Font-Size="14px" ForeColor="#666666"></asp:Label>&nbsp;&nbsp;<asp:DropDownList ID="ddlPromociones" runat="server" 
            Font-Names="FuturaStd-Book" Font-Size="14px" ForeColor="#666666"
                                    Width="150px" Height="25px" BorderWidth="0" 
            onselectedindexchanged="ddlPromociones_SelectedIndexChanged" 
            AutoPostBack="True">
        </asp:DropDownList></td><td style="width:30px;"></td></tr>
    <tr><td style="height:0px;"></td><td>
        </td><td></td></tr>
    <tr><td></td><td>
        
        </td><td></td></tr>

    </table>
    <br />
    <div style="width:550px; height:390px; background-color:#D7D7D7;">
    <table class="tablaSinbordes">
 <tr><td style="width:30px;"></td><td align="center">
  <div style="border-color: transparent; border-style: none; border-width: 0px; width: 550px; height: 385px; overflow: auto; ">  
  <br />
      <asp:GridView ID="grdImagenes" runat="server" AutoGenerateColumns="false" ShowHeader="false" BorderStyle="None" BorderWidth="0px" BorderColor="Transparent" GridLines="None">
       <Columns>
       <asp:TemplateField>
        <ItemTemplate>               
                <img style='width: 500px; height: 350px;  border: 0px none transparent;' src='<%# Eval("promo_preview") %>' name='<%# Eval("Idpromocion") %>' alt=""/><br /><br />
            </a>
        </ItemTemplate>
       </asp:TemplateField>
       </Columns>
       <AlternatingRowStyle BorderStyle="None" />
       <RowStyle BorderStyle="None" />
      </asp:GridView>
     </div>
        </td><td></td></tr>
<tr><td></td><td>
    </td><td style="width:30px;"></td></tr>
    <tr><td style="height:10px;"></td><td>
        </td><td></td></tr>
    <tr><td></td><td>
        </td><td></td></tr>

    </table>
</div>
</asp:Content>