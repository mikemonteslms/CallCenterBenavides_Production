<%@ Page Title="" Language="C#" MasterPageFile="~/MasterECard.Master" AutoEventWireup="true"
    CodeBehind="RegistroCliente_EncuestaInicial_Nuevo.aspx.cs" Inherits="WebPfizer.LMS.eCard.RegistroCliente_EncuestaInicial_Nuevo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
   <script>
       (function (i, s, o, g, r, a, m) {
           i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
               (i[r].q = i[r].q || []).push(arguments)
           }, i[r].l = 1 * new Date(); a = s.createElement(o),
  m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
       })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

       ga('create', 'UA-73644905-1', 'auto');
       ga('send', 'pageview');

</script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <table width="641px" style="background-color: #EBEBEB" >
        <tr>
        <td style="width:10px;">
            &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Names="Arial" 
                        Font-Size="9pt" ForeColor="#79716B" Text="Te invitamos a mantenerte informado acerca de tu Programa Beneficio Inteligente, además de obtener las mejores promociones.
"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>                
                <td>
                    <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Names="Arial" 
                        Font-Size="9pt" ForeColor="Red" Text="*">
                        </asp:Label>
                    <asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Names="Arial" 
                        Font-Size="9pt" ForeColor="#79716B" Text="Campos obligatorios."></asp:Label>
                </td>
            </tr>
        </table>
            <table width="641px" style="background-color: #EBEBEB" cellspacing="15px">
                <tr>
                    <td width="320px" align="left" valign="top">
                        <asp:Label ID="Label10" runat="server" Text="No. de Tarjeta:" ForeColor="#79716B" Font-Bold="True" Font-Names="Arial" Font-Size="9pt"></asp:Label>
                        <br />
                        <asp:TextBox ID="txtTarjeta" runat="server" Width="120px" Font-Names="Arial" Font-Size="9pt"
                                ForeColor="#857F7A" MaxLength="19"></asp:TextBox>
                        <br /><br />
                        <asp:Label ID="Label11" runat="server" Text="Datos Personales" ForeColor="#79716B" Font-Bold="True" Font-Names="Arial" Font-Size="9pt"></asp:Label>
                        <br /><br />
                        <asp:Label ID="lblFechaNacimiento" runat="server" Text="Fecha de Nacimiento" ForeColor="#79716B"
                            Font-Bold="True" Font-Names="Arial" Font-Size="9pt"></asp:Label>
                        <br />
                        <asp:Label ID="lblAño" runat="server" Font-Names="Arial" Font-Size="8pt" ForeColor="#79716B"
                            Text="Año"></asp:Label>
                        <asp:DropDownList ID="ddlAno" runat="server" Width="55px" Font-Names="Arial" Font-Size="8pt"
                            ForeColor="#857F7A" OnSelectedIndexChanged="ddlAno_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList>
                        <asp:Label ID="lblMes" runat="server" Font-Names="Arial" Font-Size="8pt" ForeColor="#79716B"
                            Text="Mes"></asp:Label>
                        <asp:DropDownList ID="ddlMes" runat="server" Width="80px" Font-Names="Arial" Font-Size="8pt"
                            ForeColor="#857F7A" OnSelectedIndexChanged="ddlMes_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList>
                        <asp:Label ID="lblDia" runat="server" Font-Names="Arial" Font-Size="8pt" ForeColor="#79716B"
                            Text="Día"></asp:Label>
                        <asp:DropDownList ID="ddlDia" runat="server" Width="43px" Font-Names="Arial" Font-Size="8pt"
                            ForeColor="#857F7A">
                        </asp:DropDownList>
                        <br /><br />
                         <asp:Label ID="Label4" runat="server" Text="Estado civil:" ForeColor="#79716B" Font-Bold="True"
                                        Font-Names="Arial" Font-Size="9pt"></asp:Label>
                                    <asp:DropDownList ID="ddlEstadoCivil" runat="server" Width="110px" AppendDataBoundItems="True"
                                        Font-Names="Arial" Font-Size="9pt" ForeColor="#857F7A">
                                        <asp:ListItem Value="-1">--Selecciona--</asp:ListItem>
                                    </asp:DropDownList>
                         <br /><br />
                         <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Names="Arial" 
                            Font-Size="9pt" ForeColor="Red" Text="*">
                        </asp:Label>
                         <asp:Label ID="lblGenero" runat="server" Text="Género:" ForeColor="#79716B" Font-Bold="True"
                                        Font-Names="Arial" Font-Size="9pt"></asp:Label>
                                    <asp:Panel ID="Panel1" runat="server" Height="65px" ScrollBars="None">
                                    <asp:RadioButtonList ID="rdoGenero" runat="server" Font-Names="Arial" Font-Size="9pt"
                                        RepeatColumns="1" ForeColor="#857F7A">
                                        <asp:ListItem Value="1"><img alt='' src='Imagenes_Benavides/man.png'></asp:ListItem>
                                        <asp:ListItem Value="2"><img alt='' src='Imagenes_Benavides/woman.png'></asp:ListItem>
                                        <%--<asp:ListItem Value="3" Enabled="false">Indefinido</asp:ListItem>--%>
                                    </asp:RadioButtonList>
                                    </asp:Panel>
                                   
                                    <asp:Label ID="Label13" runat="server" Font-Bold="True" 
                            Font-Names="Arial" Font-Size="9pt" ForeColor="Red" Text="*">
                        </asp:Label>
                                   
                                    <asp:Label ID="lblMail" runat="server" Text="Correo eléctronico:" ForeColor="#79716B"
                            Font-Bold="True" Font-Names="Arial" Font-Size="9pt"></asp:Label>
                        <br />
                        <asp:TextBox ID="txtMail" runat="server" Width="120px" Font-Names="Arial" Font-Size="9pt"
                            ForeColor="#857F7A"></asp:TextBox>
                        <asp:Label ID="lblDominio" runat="server" Text="@" ForeColor="#857F7A" Font-Bold="True"
                            Font-Names="Arial" Font-Size="9pt"></asp:Label>
                        <asp:TextBox ID="txtDominio" runat="server" Width="120px" Font-Names="Arial" Font-Size="9pt"
                            ForeColor="#857F7A"></asp:TextBox>
                        <%--<asp:DropDownList ID="ddlDominios" runat="server" Width="100px" Font-Names="Arial"
                            Font-Size="9pt" ForeColor="#857F7A">
                        </asp:DropDownList>--%>
                        <br /><br />
                        
                        <asp:Label ID="Label14" runat="server" Text="Tel. Fijo" ForeColor="#79716B"
                            Font-Bold="True" Font-Names="Arial" Font-Size="9pt"></asp:Label>
                        <br />                        
                        <asp:TextBox ID="txtTelFijo" runat="server"></asp:TextBox>
                        <br /><br />
                        <asp:Label ID="lblCelular" runat="server" Text="Teléfono Celular:" ForeColor="#79716B"
                            Font-Bold="True" Font-Names="Arial" Font-Size="9pt"></asp:Label>
                        <br />
                        <asp:Label ID="Label3" runat="server" Text="(044)" ForeColor="#79716B" Font-Bold="True"
                            Font-Names="Arial" Font-Size="9pt"></asp:Label>
                        <asp:TextBox ID="txtCelular" runat="server" Width="120px" MaxLength="10" Font-Names="Arial"
                            Font-Size="9pt" ForeColor="#857F7A"></asp:TextBox>
                            <br /><br />
                        <asp:Label ID="Label16" runat="server" Font-Bold="True" Font-Names="Arial" 
                            Font-Size="9pt" ForeColor="Red" Text="*">
                        </asp:Label>
                        <asp:Label ID="Label15" runat="server" Text="C.P." ForeColor="#79716B"
                            Font-Bold="True" Font-Names="Arial" Font-Size="9pt"></asp:Label>
                            <br />
                            <asp:TextBox ID="txtCPCliente" runat="server" Width="80px" MaxLength="5" Font-Names="Arial"
                            Font-Size="9pt" ForeColor="#857F7A"></asp:TextBox>
                            <br /><br />
                            <asp:Label ID="lblHijos" runat="server" Text="¿Tienes hijos?" ForeColor="#79716B"
                                        Font-Bold="True" Font-Names="Arial" Font-Size="9pt"></asp:Label>
                                    <asp:RadioButtonList ID="rdoHijos" runat="server" Font-Names="Arial" Font-Size="9pt"
                                        RepeatColumns="1" ForeColor="#857F7A">
                                        <asp:ListItem Value="1">Si</asp:ListItem>
                                        <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                                    </asp:RadioButtonList>                        
                    </td>
                    <td width="321px" align="left" valign="top">
                        <table>
                        <tr>
                        <td>
                        <asp:Label ID="lblPadecimientos" runat="server" Text="¿Posees algún padecimiento crónico?"
                            ForeColor="#79716B" Font-Bold="True" Font-Names="Arial" Font-Size="9pt"></asp:Label>
                            <br />
                            <asp:RadioButtonList ID="rblPadecimiento" runat="server" Font-Names="Arial" 
                                Font-Size="9pt" ForeColor="#79716B" AutoPostBack="True" 
                                onselectedindexchanged="rblPadecimiento_SelectedIndexChanged" 
                                RepeatDirection="Horizontal">
                            <asp:ListItem Value="1">Si</asp:ListItem>
                            <asp:ListItem Value="2">No</asp:ListItem>
                            </asp:RadioButtonList>
                        <asp:CheckBoxList ID="chkPadecimientos" runat="server" Font-Names="Arial" Font-Size="9pt"
                            ForeColor="#857F7A" OnSelectedIndexChanged="chkPadecimientos_SelectedIndexChanged"
                            AutoPostBack="true">
                        </asp:CheckBoxList>
                        <br />
                        <asp:Label ID="lblOtroPadecimiento" runat="server" Text="Captura Otro Padecimiento:" Visible="false"
                            ForeColor="#79716B" Font-Bold="True" Font-Names="Arial" Font-Size="9pt"></asp:Label>
                        <br />
                        <asp:TextBox ID="txtOtroPadecimiento" runat="server" Width="178px" Font-Names="Arial"
                            Font-Size="9pt" ForeColor="#857F7A" Visible="False"></asp:TextBox>
                            <br /><br />
                        </td>
                        </tr>
                            <tr>
                                <td align="left" valign="top">
                                    <asp:Label ID="lblCategorias" runat="server" Text="Categorías de interés:" ForeColor="#79716B"
                                        Font-Bold="True" Font-Names="Arial" Font-Size="9pt"></asp:Label>
                                    <asp:CheckBoxList ID="chkCategorias" runat="server" Font-Names="Arial" Font-Size="9pt"
                                        ForeColor="#857F7A">
                                    </asp:CheckBoxList>
                                    <br />
                                </td>
                            </tr>                            
                        </table>
                         <asp:Label ID="lblMedio" runat="server" Text="¿Por qué medio te gustaría recibir información de Beneficio Inteligente?"
                            ForeColor="#79716B" Font-Bold="True" Font-Names="Arial" Font-Size="9pt"></asp:Label>
                        <asp:CheckBoxList ID="chkMedio" runat="server" Font-Names="Arial" Font-Size="9pt"
                            ForeColor="#857F7A" AutoPostBack="true" OnSelectedIndexChanged="chkMedio_SelectedIndexChanged">
                        </asp:CheckBoxList>
                        <br /><br />
                               <asp:Panel ID="pnlVisible" runat="server" Height="100px" Font-Names="Arial" Font-Size="9pt"
                            Visible="false" Width="65%">
                            <asp:Label ID="Label1" runat="server" Text="Código Postal:" ForeColor="#79716B" Font-Bold="True"
                                Font-Names="Arial" Font-Size="9pt"></asp:Label>
                            <br />
                            <asp:TextBox ID="txtCPVisible" runat="server" Width="80px" Font-Names="Arial" Font-Size="9pt"
                                ForeColor="#857F7A" OnTextChanged="txtCPVisible_TextChanged" AutoPostBack="true"
                                MaxLength="5"></asp:TextBox>
                            <br />
                            <br />
                            <asp:Label ID="Label7" runat="server" Text="Colonia:" ForeColor="#79716B" Font-Bold="True"
                                Font-Names="Arial" Font-Size="9pt"></asp:Label>
                            <br />
                            <asp:DropDownList ID="ddlColoniaVisible" runat="server" AutoPostBack="True" Width="143px"
                                Font-Names="Arial" Font-Size="9pt" ForeColor="#857F7A" OnSelectedIndexChanged="ddlColonia_SelectedIndexChanged1"
                                Enabled="false">
                            </asp:DropDownList>
                            <br />
                            <asp:DropDownList ID="ddlEstadoOculto" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEstado_SelectedIndexChanged"
                                Width="145px" Font-Names="Arial" Font-Size="9pt" ForeColor="#857F7A" Visible="false">
                            </asp:DropDownList>
                            <br />
                            <asp:DropDownList ID="ddlMunicipioOculto" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMunicipio_SelectedIndexChanged"
                                Width="130px" Font-Names="Arial" Font-Size="9pt" ForeColor="#857F7A" Visible="false">
                            </asp:DropDownList>
                            <br />
                            <asp:TextBox ID="txtCalleOculto" runat="server" MaxLength="250" Width="155px" Font-Names="Arial"
                                Font-Size="9pt" ForeColor="#857F7A" Visible="false"></asp:TextBox>
                            <br />
                            <asp:TextBox ID="txtExtOculto" runat="server" Width="35px" MaxLength="10" Font-Names="Arial"
                                Font-Size="9pt" ForeColor="#857F7A" Visible="false"></asp:TextBox>
                            <asp:TextBox ID="txtIntOculto" runat="server" Width="35px" MaxLength="10" Font-Names="Arial"
                                Font-Size="9pt" ForeColor="#857F7A" Visible="false"></asp:TextBox>
                        </asp:Panel>
                        <asp:Panel ID="pnlDomicilio" runat="server" Height="170px" ScrollBars="Vertical"
                            Font-Names="Arial" Font-Size="9pt" Visible="false" Width="65%">
                            <asp:Label ID="Label5" runat="server" Text="Código Postal:" ForeColor="#79716B" Font-Bold="True"
                                Font-Names="Arial" Font-Size="9pt"></asp:Label>
                            <br />
                            <asp:TextBox ID="txtCP" runat="server" Width="80px" Font-Names="Arial" Font-Size="9pt"
                                ForeColor="#857F7A"></asp:TextBox>
                            <br />
                            <br />
                            <asp:Label ID="lblCalle" runat="server" Text="Calle:" ForeColor="#79716B" Font-Bold="True"
                                Font-Names="Arial" Font-Size="9pt"></asp:Label>
                            <asp:TextBox ID="txtActCalle" runat="server" MaxLength="250" Width="155px" Font-Names="Arial"
                                Font-Size="9pt" ForeColor="#857F7A"></asp:TextBox>
                            <br />
                            <br />
                            <asp:Label ID="lblExterior" runat="server" Text="Ext.:" ForeColor="#79716B" Font-Bold="True"
                                Font-Names="Arial" Font-Size="9pt"></asp:Label>
                            <asp:TextBox ID="txtExterior" runat="server" Width="35px" MaxLength="10" Font-Names="Arial"
                                Font-Size="9pt" ForeColor="#857F7A"></asp:TextBox>
                            <asp:Label ID="lblInterior" runat="server" Text="Int.:" ForeColor="#79716B" Font-Bold="True"
                                Font-Names="Arial" Font-Size="9pt"></asp:Label>
                            <asp:TextBox ID="txtInterior" runat="server" Width="35px" MaxLength="10" Font-Names="Arial"
                                Font-Size="9pt" ForeColor="#857F7A"></asp:TextBox>
                            <br />
                            <br />
                            <asp:Label ID="lblEstado" runat="server" Text="Estado:" ForeColor="#79716B" Font-Bold="True"
                                Font-Names="Arial" Font-Size="9pt"></asp:Label>
                            <asp:DropDownList ID="ddlEstado" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEstado_SelectedIndexChanged"
                                Width="145px" Font-Names="Arial" Font-Size="9pt" ForeColor="#857F7A">
                            </asp:DropDownList>
                            <br />
                            <br />
                            <asp:Label ID="lblMunicipio" runat="server" Text="Municipio:" ForeColor="#79716B"
                                Font-Bold="True" Font-Names="Arial" Font-Size="9pt"></asp:Label>
                            <asp:DropDownList ID="ddlMunicipio" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMunicipio_SelectedIndexChanged"
                                Width="130px" Font-Names="Arial" Font-Size="9pt" ForeColor="#857F7A">
                            </asp:DropDownList>
                            <br />
                            <br />
                            <asp:Label ID="lblColonia" runat="server" Text="Colonia:" ForeColor="#79716B" Font-Bold="True"
                                Font-Names="Arial" Font-Size="9pt"></asp:Label>
                            <asp:DropDownList ID="ddlColonia" runat="server" AutoPostBack="True" Width="143px"
                                Font-Names="Arial" Font-Size="9pt" ForeColor="#857F7A" OnSelectedIndexChanged="ddlColonia_SelectedIndexChanged1">
                            </asp:DropDownList>                                                        
                            
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td width="320px" align="left" valign="top">
                        <table>
                            <tr>
                                <td align="left" valign="top">
                                    
                                </td>
                                <td width="15px">
                                </td>
                                <td align="left" valign="top">
                                    
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td width="321px" align="left" valign="top">
                       
                    </td>
                </tr>
                <tr>
                    <td width="320px" align="left" valign="top">
                        
                        <br />
                        <br />
                        <asp:Label ID="Label2" runat="server" Text="¿Cuántas personas viven en tu casa?"
                            ForeColor="#79716B" Font-Bold="True" Font-Names="Arial" Font-Size="9pt"></asp:Label>
                        <br />
                        <asp:TextBox ID="txtCuantos" runat="server" Width="80px" MaxLength="2"></asp:TextBox>
                    </td>
                    <td width="321px" align="left" valign="top">
                 
                    </td>
                </tr>
                <tr>
                    <td width="320px" align="left" valign="top">
                        
                    </td>
                    <td width="321px" align="left" valign="top">
                        
                    </td>
                </tr>
                <tr>
                    <td width="320px" align="center">
                        <asp:ImageButton ID="btnRegistrar" runat="server" ImageUrl="~/Imagenes_Benavides/botones/registrar-btn.png"
                            OnClick="btnRegistrar_Click" />
                    </td>
                    <td width="320px" align="center">
                        <asp:ImageButton ID="btnCancelar" runat="server" ImageUrl="~/Imagenes_Benavides/botones/cancelar-btn.png"
                            OnClick="btnCancelar_Click" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
