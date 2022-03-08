<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InscripcionClubPeques.aspx.cs" Inherits="WebPfizer.LMS.eCard.InscripcionClubPeques" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
  
    <style type="text/css">
*
{
padding: 0px;
    margin-left: 0px;
    margin-right: 0px;
    margin-top: 0px;
}

    </style>
  
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table >
            <tr>
                <td>                    
                    <asp:Label ID="Label1" runat="server" Text="¿Compras productos de cuidado durante el embarazo?"></asp:Label></td>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="¿Tienes hijos menores a 3 años?"></asp:Label></td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                   <asp:RadioButtonList ID="rblEmbarazo" runat="server" Font-Names="Arial" Font-Size="9pt"
                                        RepeatColumns="1" ForeColor="#857F7A">
                                        <asp:ListItem Value="1">Si</asp:ListItem>
                                        <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
    </asp:RadioButtonList></td>
                <td>
                   <asp:RadioButtonList ID="rblHijos" runat="server" Font-Names="Arial" Font-Size="9pt"
                                        RepeatColumns="1" ForeColor="#857F7A">
                                        <asp:ListItem Value="1">Si</asp:ListItem>
                                        <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
    </asp:RadioButtonList></td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                   <asp:Label ID="Label2" runat="server" Text="¿Cuándo nacerá tu bebé?"></asp:Label></td>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="¿Cuántos hijos menores a 3 años tienes?"></asp:Label></td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
                <td>
                   <asp:RadioButtonList ID="rblHijos1" runat="server" Font-Names="Arial" Font-Size="9pt"
                                        RepeatColumns="1" ForeColor="#857F7A">
                                        <asp:ListItem Value="1">1</asp:ListItem>
                                        <asp:ListItem Value="2">2</asp:ListItem>
    </asp:RadioButtonList>
                   <asp:RadioButtonList ID="rblHijos2" runat="server" Font-Names="Arial" Font-Size="9pt"
                                        RepeatColumns="1" ForeColor="#857F7A">
                                        <asp:ListItem Value="3">3</asp:ListItem>
                                        <asp:ListItem Value="4">4</asp:ListItem>
    </asp:RadioButtonList></td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                   <asp:Label ID="Label5" runat="server" Text="Nombre"></asp:Label></td>
                <td>
                   <asp:Label ID="Label18" runat="server" Text="Fecha Nacimiento"></asp:Label></td>
                <td>
                   <asp:Label ID="Label19" runat="server" Text="Género"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </td>
                <td>
                   <asp:Label ID="Label6" runat="server" Font-Names="Arial" Font-Size="8pt" ForeColor="#79716B"
                            Text="Año"></asp:Label>
                        <asp:DropDownList ID="DropDownList1" runat="server" Width="55px" Font-Names="Arial" Font-Size="8pt"
                            ForeColor="#857F7A" OnSelectedIndexChanged="ddlAno_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList>
                        <asp:Label ID="Label7" runat="server" Font-Names="Arial" Font-Size="8pt" ForeColor="#79716B"
                            Text="Mes"></asp:Label>
                        <asp:DropDownList ID="DropDownList2" runat="server" Width="80px" Font-Names="Arial" Font-Size="8pt"
                            ForeColor="#857F7A" OnSelectedIndexChanged="ddlMes_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList>
                        <asp:Label ID="Label8" runat="server" Font-Names="Arial" Font-Size="8pt" ForeColor="#79716B"
                            Text="Día"></asp:Label>
                        <asp:DropDownList ID="DropDownList3" runat="server" Width="43px" Font-Names="Arial" Font-Size="8pt"
                            ForeColor="#857F7A">
                        </asp:DropDownList></td>
                <td>
                                    <asp:RadioButtonList ID="rdoGenero" runat="server" 
                        Font-Names="Arial" Font-Size="9pt"
                                         ForeColor="#857F7A" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="1"><img alt='' src='Imagenes_Benavides/man.png'></asp:ListItem>
                                        <asp:ListItem Value="2"><img alt='' src='Imagenes_Benavides/woman.png'></asp:ListItem>
                                        <%--<asp:ListItem Value="3" Enabled="false">Indefinido</asp:ListItem>--%>
                                    </asp:RadioButtonList>                                   
                                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                </td>
                <td>
                   <asp:Label ID="Label9" runat="server" Font-Names="Arial" Font-Size="8pt" ForeColor="#79716B"
                            Text="Año"></asp:Label>
                        <asp:DropDownList ID="DropDownList4" runat="server" Width="55px" Font-Names="Arial" Font-Size="8pt"
                            ForeColor="#857F7A" OnSelectedIndexChanged="ddlAno_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList>
                        <asp:Label ID="Label10" runat="server" Font-Names="Arial" Font-Size="8pt" ForeColor="#79716B"
                            Text="Mes"></asp:Label>
                        <asp:DropDownList ID="DropDownList5" runat="server" Width="80px" Font-Names="Arial" Font-Size="8pt"
                            ForeColor="#857F7A" OnSelectedIndexChanged="ddlMes_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList>
                        <asp:Label ID="Label11" runat="server" Font-Names="Arial" Font-Size="8pt" ForeColor="#79716B"
                            Text="Día"></asp:Label>
                        <asp:DropDownList ID="DropDownList6" runat="server" Width="43px" Font-Names="Arial" Font-Size="8pt"
                            ForeColor="#857F7A">
                        </asp:DropDownList></td>
                <td>
                                    <asp:RadioButtonList ID="rdoGenero0" runat="server" 
                        Font-Names="Arial" Font-Size="9pt"
                                         ForeColor="#857F7A" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="1"><img alt='' src='Imagenes_Benavides/man.png'></asp:ListItem>
                                        <asp:ListItem Value="2"><img alt='' src='Imagenes_Benavides/woman.png'></asp:ListItem>
                                        <%--<asp:ListItem Value="3" Enabled="false">Indefinido</asp:ListItem>--%>
                                    </asp:RadioButtonList>                                   
                                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label12" runat="server" Font-Names="Arial" Font-Size="8pt" ForeColor="#79716B"
                            Text="Año"></asp:Label>
                        <asp:DropDownList ID="DropDownList7" runat="server" Width="55px" Font-Names="Arial" Font-Size="8pt"
                            ForeColor="#857F7A" OnSelectedIndexChanged="ddlAno_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList>
                        <asp:Label ID="Label13" runat="server" Font-Names="Arial" Font-Size="8pt" ForeColor="#79716B"
                            Text="Mes"></asp:Label>
                        <asp:DropDownList ID="DropDownList8" runat="server" Width="80px" Font-Names="Arial" Font-Size="8pt"
                            ForeColor="#857F7A" OnSelectedIndexChanged="ddlMes_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList>
                        <asp:Label ID="Label14" runat="server" Font-Names="Arial" Font-Size="8pt" ForeColor="#79716B"
                            Text="Día"></asp:Label>
                        <asp:DropDownList ID="DropDownList9" runat="server" Width="43px" Font-Names="Arial" Font-Size="8pt"
                            ForeColor="#857F7A">
                        </asp:DropDownList></td>
                <td>
                                    <asp:RadioButtonList ID="rdoGenero1" runat="server" 
                        Font-Names="Arial" Font-Size="9pt"
                                         ForeColor="#857F7A" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="1"><img alt='' src='Imagenes_Benavides/man.png'></asp:ListItem>
                                        <asp:ListItem Value="2"><img alt='' src='Imagenes_Benavides/woman.png'></asp:ListItem>
                                        <%--<asp:ListItem Value="3" Enabled="false">Indefinido</asp:ListItem>--%>
                                    </asp:RadioButtonList>                                   
                                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label15" runat="server" Font-Names="Arial" Font-Size="8pt" ForeColor="#79716B"
                            Text="Año"></asp:Label>
                        <asp:DropDownList ID="DropDownList10" runat="server" Width="55px" Font-Names="Arial" Font-Size="8pt"
                            ForeColor="#857F7A" OnSelectedIndexChanged="ddlAno_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList>
                        <asp:Label ID="Label16" runat="server" Font-Names="Arial" Font-Size="8pt" ForeColor="#79716B"
                            Text="Mes"></asp:Label>
                        <asp:DropDownList ID="DropDownList11" runat="server" Width="80px" Font-Names="Arial" Font-Size="8pt"
                            ForeColor="#857F7A" OnSelectedIndexChanged="ddlMes_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList>
                        <asp:Label ID="Label17" runat="server" Font-Names="Arial" Font-Size="8pt" ForeColor="#79716B"
                            Text="Día"></asp:Label>
                        <asp:DropDownList ID="DropDownList12" runat="server" Width="43px" Font-Names="Arial" Font-Size="8pt"
                            ForeColor="#857F7A">
                        </asp:DropDownList></td>
                <td>
                                    <asp:RadioButtonList ID="rdoGenero2" runat="server" 
                        Font-Names="Arial" Font-Size="9pt"
                                         ForeColor="#857F7A" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="1"><img alt='' src='Imagenes_Benavides/man.png'></asp:ListItem>
                                        <asp:ListItem Value="2"><img alt='' src='Imagenes_Benavides/woman.png'></asp:ListItem>
                                        <%--<asp:ListItem Value="3" Enabled="false">Indefinido</asp:ListItem>--%>
                                    </asp:RadioButtonList>                                   
                                </td>
            </tr>
        </table>
    
    </div>
    
    </form>
</body>
</html>
