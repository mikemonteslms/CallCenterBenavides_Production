<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroClienteCallCenter.aspx.cs"
    Inherits="Portal_Benavides.RegistroClienteCallCenter" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ MasterType VirtualPath="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="Styles/MisEstilos.css" rel="stylesheet" type="text/css" />
    <title>Registro de Cliente</title>
    <link href="EstilosBenavides.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="Calendar.css" rel="stylesheet" type="text/css" media="screen" />
    <script src="../Scripts/jquery-1.7.1.min.js"></script>
    <script src="../Scripts/jquery-ui-1.8.20.min.js"></script>

     <script type="text/javascript">

         $(document).ready(function () {

             $('.close').on("click", function () {
                 debugger;
                 $('#popReg').fadeOut('slow');
                 return false;
             });

             $('#MainContent_btnCancelar').click(function () {
                 alert("cancelar");
             });

             $('#MainContent_btnNo').on("click", function () {                 
                 $('#popReg').fadeOut('slow');
                 $('#MainContent_txtCorreo').focus();
                 return false;
             });
             


         });        


         function ShowReg() {
             //debugger;
             var _docHeight = (document.height !== undefined) ? document.height : document.body.scrollHeight;
             var _docWidth = (document.width !== undefined) ? document.width : document.body.offsetWidth;

             $('#popReg').fadeIn('slow');
             $('#popReg').height(_docHeight);

             //$('#popReg div')[0].removeAttr('height');
             //$('#popReg div')[0].attr('height', '180');

             return false;
         }



        function Mayusculas(input) {
            input.value = input.value.toUpperCase();
        }

        function soloNumeros(e) {

            var key = window.Event ? e.which : e.keyCode

            return (key >= 48 && key <= 57)

        }

        function remover_acentos(str) {
            alert("entro: " + str);
            var map = {"á":"A","é":"E","í":"I","ó":"O","ú":"U","Á":"A","É":"E","Í":"I","Ó":"O","Ú":"U"}; 
            alert("paso map");
        var res = ""; //Está variable almacenará el valor de str, pero sin acentos 
        for (var i=0;i<str.length;i++)
        {
            
            c = str.charAt(i);
            alert(c);
            res += map[c] || c;
            alert(res);
        }
            return res;
        }


    </script>

     <style type="text/css">        
    .tooltipDemo {
            background: #f70606;            
            border-radius: 5px;
            color: #fff !important;
            width: 150px;
            left: 0px;
            top: 0px;        
            font-size:11px;                            
        }

        input[type=submit] {
            background-color: #f70606;
            color: #fff;
            border: 1px solid #808080;
            font-family: Arial;
            font-size: 10pt;
            border-radius: 10px;
            }

        input[type=submit]:hover {
            background-color: #2B347A;            
         }


         input_tarjeta[type=submit] {
            background-color: #f70606;
            color: #fff;
            border: 1px solid #808080;
            font-family: Arial;
            font-size: 12pt;
            border-radius: 10px;
            width: 120px;
         }

        input_tarjeta[type=submit]:hover {
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
   
         .auto-style1 {
             height: 40px;
             width: 150px;
         }
         .auto-style5 {
             height: 20px;
         }
         .auto-style6 {
             width: 58px;
             height: 20px;
         }
   
         .auto-style8 {
             height: 20px;
             width: 165px;
         }
         .auto-style10 {
             width: 800px;
         }
         .auto-style11 {
             width: 165px
         }
         .auto-style12 {
             width: 58px;
         }
         .auto-style15 {
             width: 150px;
         }
         .auto-style16 {
             width: 150px;
             height: 20px;
         }
         .auto-style17 {
             width: 149px;
         }
         .auto-style18 {
             width: 149px;
             height: 20px;
         }
   
    </style>

    <center>
        <%--<div id="fondo" style="background-image: url(Imagenes_Benavides/acceso-registro-header.jpg);
            width: 1010px; height: 756px; background-repeat: no-repeat;">--%>
            <div id="divContenedorRegistro" style="width:100%;align-content:center;align-items:center;align-self:center;border:none">
                <br />
                <br />
                <table id="tblRegistroCte" border="0"  class="auto-style10"  >
                    <tr>
                        <td colspan="4" style="text-align:left;"><asp:Label ID="lblRegistro" runat="server" Text="Registro de Datos Personales" Font-Bold="True"
                                Font-Size="16pt" ForeColor="#004A99" Font-Names="Arial"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="4"></td>
                    </tr>
                    <tr>
                        <td colspan="4" style="text-align:left">
                            <asp:Label ID="Label1" runat="server" Text="Son obligatorios los datos marcados con "
                                ForeColor="Red" Font-Names="Arial" CssClass="Etiqueta"></asp:Label><font color="Red">(*)</font>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1"><asp:Label ID="Label4" Width="150px" runat="server" ForeColor="White"></asp:Label></td>
                        <td class="auto-style11"></td>
                        <td class="auto-style17"></td>
                        <td class="auto-style12">&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="text-align:left;" class="auto-style15" >
                            <asp:Label ID="lblTarjeta" runat="server" Text="Tarjeta" ForeColor="#004A99" CssClass="Etiqueta"
                                Font-Bold="True" Font-Size="9pt"></asp:Label>&nbsp;<font style="width:150px" color="Red">*</font>
                            </td>
                        
                        <td style="text-align:left;" class="auto-style11">
                            <asp:TextBox ID="txtTarjeta" runat="server" MaxLength="19" Width="150px"></asp:TextBox>
                        </td>
                        <td  style="text-align:left;text-align:center;" class="auto-style17">
                            <asp:Button ID="btnVerificar" runat="server" CssClass="input_tarjeta" OnClick="btnVerificar_Click" Text="Validar Tarjeta" CausesValidation="false" Height="24px" Width="120px"/>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style15">&nbsp;</td>
                        <td class="auto-style11">&nbsp;</td>
                        <td class="auto-style17">&nbsp;</td>
                        <td class="auto-style12">&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="text-align:left;" class="auto-style15">
                            <asp:Label ID="lblAP" runat="server" Text="Apellido Paterno" Font-Bold="True" ForeColor="#004A99"
                                Font-Names="Arial" Font-Size="9pt"></asp:Label>
                            <asp:Label ID="lblValidaAP" runat="server" ForeColor="Red" Text="*" Visible="true"></asp:Label>
                        </td>
                        
                        <td style="text-align:left;" class="auto-style11">
                            <asp:TextBox ID="txtAP" runat="server" Width="150px" MaxLength="30" Enabled="False"  ></asp:TextBox>
                            <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtAP" Display="Dynamic" ErrorMessage="Solo se permiten letras mayúsculas." ToolTip="Solo se permiten letras mayúsculas." ValidationExpression="([A-Z])" SetFocusOnError="true" CssClass="tooltipDemo" ValidationGroup="ValidaDatos"></asp:RegularExpressionValidator>--%>
                            </td>
                        </tr>
                    <tr>
                        <td class="auto-style15">&nbsp;</td>
                        <td class="auto-style11">&nbsp;</td>
                        <td class="auto-style17">&nbsp;</td>
                        <td class="auto-style12">&nbsp;</td>
                    </tr>
                        <tr>
                        <td style="text-align:left;" class="auto-style15">
                            <asp:Label ID="lblAM" runat="server" Text="Apellido Materno" ForeColor="#004A99"
                                Font-Names="Arial" Font-Size="9pt" Font-Bold="True"></asp:Label>
                            <asp:Label ID="lblValidaAM" runat="server" ForeColor="Red" Text="*" Visible="true"></asp:Label>
                            </td>
                        <td style="text-align:left;" class="auto-style11">
                            <asp:TextBox ID="txtAM" runat="server" Width="150px" MaxLength="30" Enabled="False"></asp:TextBox>
                             <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtAM" Display="Dynamic" ErrorMessage="Solo se permiten letras mayúsculas." ToolTip="Solo se permiten letras mayúsculas." ValidationExpression="([A-Z\s.]*)" SetFocusOnError="true" CssClass="tooltipDemo" ValidationGroup="ValidaDatos">* Solo se permiten letras mayúsculas sin acentos.</asp:RegularExpressionValidator>--%>
                            </td>
                        </tr>
                        <tr>
                        <td style="text-align:left;" class="auto-style15">
                            &nbsp;</td>
                        <td style="text-align:left;" class="auto-style11">
                            &nbsp;</td>
                        <td class="auto-style17">&nbsp;</td>
                        <td style="text-align:left;" class="auto-style12">
                            &nbsp;</td>
                        <tr>
                        <td style="text-align:left;" class="auto-style15">
                            <asp:Label ID="lblNombre" runat="server" Text="Nombre:" ForeColor="#004A99" Font-Names="Arial"
                                Font-Size="9pt" Font-Bold="True"></asp:Label>
                            <asp:Label ID="lblValidaNombre" runat="server" ForeColor="Red" Text="*" Visible="true"></asp:Label>
                            </td>
                        
                        <td style="text-align:left;" class="auto-style11">
                            <asp:TextBox ID="txtNombre" runat="server" Width="150px" MaxLength="30" Enabled="False"></asp:TextBox>
                            <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtNombre" Display="Dynamic" ErrorMessage="Solo se permiten letras mayúsculas." ToolTip="Solo se permiten letras mayúsculas sin acentos." ValidationExpression="([A-Z\s.]*)" SetFocusOnError="true" CssClass="tooltipDemo" ValidationGroup="ValidaDatos">* Solo se permiten letras mayúsculas sin acentos.</asp:RegularExpressionValidator>--%>
                        </td>
                        </tr>
                    <tr>
                        <td class="auto-style15">&nbsp;</td>
                        <td class="auto-style11">&nbsp;</td>
                        <td class="auto-style17">&nbsp;</td>
                        <td class="auto-style12">&nbsp;</td>
                    </tr>
                        <tr>
                        <td style="text-align:left;" class="auto-style15">
                            <asp:Label ID="lblgenero" runat="server" CssClass="Etiqueta" Font-Bold="True" Text="Genero"
                                Font-Size="9pt"></asp:Label>
                            <asp:Label ID="lblValidaGenero" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                            </td>
                        <td style="text-align:left;" class="auto-style11">
                            <asp:DropDownList ID="ddlGenero" runat="server" Enabled="False">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align:left;" class="auto-style15">
                            &nbsp;</td>
                        <td style="text-align:left;" class="auto-style11">
                            &nbsp;</td>
                        <td class="auto-style17">&nbsp;</td>
                        <td class="auto-style12">&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="text-align:left;" class="auto-style15">
                            <asp:Label ID="Label2" runat="server" Text="Fecha de Nacimiento" ForeColor="#004A99"
                                CssClass="Etiqueta" Font-Bold="True" Font-Names="Arial" Font-Size="9pt"></asp:Label><span style="color:red; font: 9pt arial;">*</span>
                            <asp:Label ID="lblValidaFecha" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                        </td>
                       
                        <td colspan="3" style="text-align:left;">
                             <asp:Label ID="Label7" Width="25px" runat="server" Font-Names="Arial" Font-Size="8pt" ForeColor="#004A99"
                                Text="Año"></asp:Label>
                            <asp:DropDownList ID="ddlAno" runat="server" AutoPostBack="True" Font-Size="8pt"
                                OnSelectedIndexChanged="ddlAno_SelectedIndexChanged" Enabled="False" Width="100px">
                            </asp:DropDownList>
                            <asp:Label ID="Label8" Width="25px" runat="server" Font-Names="Arial" Font-Size="8pt" ForeColor="#004A99"
                                Text="Mes"></asp:Label>
                            <asp:DropDownList ID="ddlMes" runat="server" AutoPostBack="True" Enabled="False"
                                Font-Size="8pt" OnSelectedIndexChanged="ddlMes_SelectedIndexChanged" Width="100px">
                            </asp:DropDownList>
                            <asp:Label ID="Label9" Width="25px" runat="server" Font-Names="Arial" Font-Size="8pt" ForeColor="#004A99"
                                Text="Día"></asp:Label>
                            <asp:DropDownList ID="ddlDia" runat="server" Enabled="False" Font-Size="8pt" Width="100px">
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td style="text-align:left;" class="auto-style15">
                            &nbsp;</td>
                        <td colspan="3" style="text-align:left;">
                            &nbsp;</td>
                    </tr>
                   
                    <tr>
                        <td style="text-align:left;" class="auto-style15">
                            <asp:Label ID="lblCorreo" runat="server" Text="Correo Electronico:" ForeColor="#004A99"
                                CssClass="Etiqueta" Font-Bold="True" Font-Names="Arial" Font-Size="9pt"></asp:Label>
                            <asp:Label ID="lblValidaCorreo" runat="server" ForeColor="Red" Text="*" Visible="true"></asp:Label>
                            </td>
                       
                        <td style="text-align:left;" class="auto-style11">
                            <asp:TextBox ID="txtCorreo" runat="server" MaxLength="80" Enabled="false" ValidationGroup="ValidaDatos" Width="150px" ></asp:TextBox>
                        </td>
                        <td class="auto-style17">
                            <asp:CheckBox ID="chkCorreo" runat="server" AutoPostBack="true" OnCheckedChanged="chkCorreo_CheckedChanged"  Font-Names="Arial" Font-Size="9pt" ForeColor="#004A99" Text=" No tiene correo electrónico" Width="199px" Enabled="false" />
                        </td>
                        <td class="auto-style12">
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtCorreo"
                                ErrorMessage="El correo electrónico no es válido" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                ValidationGroup="ValidaDatos" Width="220px"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align:left;" class="auto-style15">
                            &nbsp;</td>
                        <td style="text-align:left;" class="auto-style11">
                            &nbsp;</td>
                        <td style="text-align:left;" class="auto-style17">
                            &nbsp;</td>
                        <td style="text-align:left;" class="auto-style12">
                            &nbsp;</td>
                    </tr>
                     <tr>
                        <td style="text-align:left;" class="auto-style15">
                            <asp:Label ID="lblCelular" runat="server" Text="Teléfono Celular" ForeColor="#004A99"
                                CssClass="Etiqueta" Font-Bold="True" Font-Names="Arial" Font-Size="9pt" Visible="false"></asp:Label>
                            <asp:Label ID="lblValidaCelular" runat="server" ForeColor="Red" Text="*" Visible="false"></asp:Label>
                            </td>
                        <td style="text-align:left;" class="auto-style11">
                            <asp:TextBox ID="txtCelular" runat="server" MaxLength="10" Width="150px" Enabled="False" Visible="false"></asp:TextBox>
                            </td>
                         </tr>
                    <tr>
                        <td class="auto-style15">&nbsp;</td>
                        <td class="auto-style11">&nbsp;</td>
                        <td class="auto-style17">&nbsp;</td>
                        <td class="auto-style12">&nbsp;</td>
                    </tr>
                    <tr style="display:none">
                        <td style="text-align:left;" class="auto-style15">
                            <asp:Label ID="lblTelefono" runat="server" Text="Teléfono:" ForeColor="#004A99" CssClass="Etiqueta"
                                Font-Bold="True" Font-Names="Arial" Font-Size="9pt"></asp:Label>
                            </td>
                        
                        <td style="text-align:left;" class="auto-style11">
                            <asp:TextBox ID="txtTelefono" runat="server" Width="150px" MaxLength="10" Enabled="False"></asp:TextBox>
                            </td>
                        <td class="auto-style17">&nbsp;</td>
                        <td class="auto-style12"></td>
                    </tr>
                    <tr style="display:none">
                        <td style="text-align:left;" class="auto-style16">
                            </td>
                        <td style="text-align:left;" colspan="3" class="auto-style5">
                            </td>
                    </tr>
                    <tr style="display:none">
                        <td style="text-align:left;" colspan="4">
                            <asp:Label ID="lblDireccion" runat="server" Text="Direccion:" ForeColor="#777E7F"
                                Font-Names="Arial" Font-Size="10pt"></asp:Label>
                            <span style="color: #777e7f">(</span><font color="#E42313"><b>*</b></font><font color="#777E7F">)</font>
                        </td>
                    </tr>
                    <tr style="display:none">
                        <td style="text-align:left;" colspan="4">
                            &nbsp;</td>
                    </tr>
                    <tr style="display:none">
                        <td style="text-align:left;" class="auto-style15">
                            <asp:Label ID="lblCalle" runat="server" Text="Calle" ForeColor="#004A99" CssClass="Etiqueta"
                                Font-Bold="True" Font-Size="9pt"></asp:Label>
                            <asp:Label ID="lblValidaCalle" runat="server" ForeColor="Red" Text="*" Visible="false"></asp:Label>
                            </td>
                        
                        <td style="text-align:left;" class="auto-style11">
                            <asp:TextBox ID="txtCalle" runat="server" MaxLength="250" Width="150px" Enabled="False"></asp:TextBox>
                            </td>
                        
                        <td style="text-align:left;" class="auto-style17">
                            <asp:Label ID="lblExterior" runat="server" Text="Ext." ForeColor="#004A99" CssClass="Etiqueta"
                                Font-Bold="True" Font-Size="9pt"></asp:Label>
                            <asp:Label ID="lblValidaExterior" runat="server" ForeColor="Red" Text="*" Visible="false"></asp:Label>
                            </td>
                        <td style="text-align:left;" class="auto-style12">
                            <asp:TextBox ID="txtNumExterior" runat="server" Width="50px" MaxLength="10" Enabled="False"></asp:TextBox>
                            </td>
                    </tr>
                    <tr style="display:none">
                        <td style="text-align:left;" class="auto-style15">
                            &nbsp;</td>
                        <td style="text-align:left;" class="auto-style11">
                            &nbsp;</td>
                        <td style="text-align:left;" class="auto-style17">
                            &nbsp;</td>
                        <td style="text-align:left;" class="auto-style12">
                            &nbsp;</td>
                    </tr>
                    <tr style="display:none">
                        <td style="text-align:left;" class="auto-style15">
                            <asp:Label ID="lblInterior" runat="server" Text="Num. Int" ForeColor="#004A99" CssClass="Etiqueta"
                                Font-Bold="True" Font-Size="9pt"></asp:Label>
                            </td>
                       
                        <td style="text-align:left;" class="auto-style11">
                            <asp:TextBox ID="txtNumInterior" runat="server" Width="50px" MaxLength="10" Enabled="False"></asp:TextBox>
                            </td>
                        
                        <td style="text-align:left;" class="auto-style17">
                            <asp:Label ID="lblEstado" runat="server" Text="Estado" ForeColor="#004A99" CssClass="Etiqueta"
                                Font-Bold="True" Font-Size="9pt"></asp:Label>
                            <asp:Label ID="lblValidaEstado" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                            </td>
                        <td style="text-align:left;" class="auto-style12">
                            <asp:DropDownList ID="ddlEstado" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEstado_SelectedIndexChanged"
                                Width="110px" Enabled="False">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr style="display:none">
                        <td style="text-align:left;" class="auto-style15">
                            &nbsp;</td>
                        <td style="text-align:left;" class="auto-style11">
                            &nbsp;</td>
                        <td style="text-align:left;" class="auto-style17">
                            &nbsp;</td>
                        <td style="text-align:left;" class="auto-style12">
                            &nbsp;</td>
                    </tr>
                    <tr style="display:none">
                        <td style="text-align:left;" class="auto-style15">
                            <asp:Label ID="lblMunicipio" runat="server" Text="Municipio" ForeColor="#004A99"
                                CssClass="Etiqueta" Font-Bold="True" Font-Size="9pt"></asp:Label>
                            <asp:Label ID="lblValidaMunicipio" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                            </td>
                        
                        <td style="text-align:left;" class="auto-style11">
                            <asp:DropDownList ID="ddlMunicipio" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMunicipio_SelectedIndexChanged"
                                Width="130px" Enabled="False">
                            </asp:DropDownList>
                            </td>
                        
                        <td style="text-align:left;" class="auto-style17">
                            <asp:Label ID="lblColonia" runat="server" Text="Colonia" ForeColor="#004A99" CssClass="Etiqueta"
                                Font-Bold="True" Font-Size="9pt"></asp:Label>
                            <asp:Label ID="lblValidaColonia" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                            </td>
                        <td style="text-align:left;" class="auto-style12">
                            <asp:DropDownList ID="ddlColonia" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlColonia_SelectedIndexChanged"
                                Width="170px" Enabled="False">
                            </asp:DropDownList>
                            </td>
                    </tr>
                    <tr style="display:none">
                        <td style="text-align:left;" class="auto-style15">
                            &nbsp;</td>
                        <td style="text-align:left;" class="auto-style11">
                            &nbsp;</td>
                        <td style="text-align:left;" class="auto-style17">
                            &nbsp;</td>
                        <td style="text-align:left;" class="auto-style12">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="text-align:left;" class="auto-style15">
                            <asp:Label ID="lblCP" runat="server" Text="C.P." ForeColor="#004A99" CssClass="Etiqueta"
                                Font-Bold="True" Font-Size="9pt"></asp:Label>
                            </td>
                        <td style="text-align:left;" class="auto-style11">
                            <asp:TextBox ID="txtCP" runat="server" Width="50px" MaxLength="5" Enabled="False"></asp:TextBox>
                        </td>
                        <td style="text-align:left;" class="auto-style17">
                            &nbsp;</td>
                        <td style="text-align:left;" class="auto-style12">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style15">&nbsp;</td>
                        <td class="auto-style11">&nbsp;</td>
                        <td class="auto-style17">&nbsp;</td>
                        <td class="auto-style12">&nbsp;</td>
                    </tr>
                    <tr style="">
                        <td style="text-align:left;" class="auto-style15">
                            &nbsp;</td>
                        <td style="text-align:left;" class="auto-style11">
                            &nbsp;</td>
                        <td style="text-align:left;" class="auto-style17">
                            &nbsp;</td>
                        <td style="text-align:left;" class="auto-style12">
                            &nbsp;</td>
                    </tr>
                    <tr style="">
                        <td style="text-align:left; color: rgb(0, 74, 153); font-size: 9pt; font-weight: bold;" colspan="4">
                            <asp:CheckBox ID="chkAceptaTerminos" runat="server" Text="Acepto Términos y Condiciones" />
                        </td>
                    </tr>
                    <tr style="">
                        <td style="text-align:left;" class="auto-style15">
                            &nbsp;</td>
                        <td style="text-align:left;" class="auto-style11">
                            &nbsp;</td>
                        <td style="text-align:left;" class="auto-style17">
                            &nbsp;</td>
                        <td style="text-align:left;" class="auto-style12">
                            &nbsp;</td>
                    </tr>
                    <tr style="">
                        <td style="text-align:left;color: rgb(0, 74, 153); font-size: 9pt; font-weight: bold;" colspan="4">
                            <asp:CheckBox ID="chkAceptaRecibirInfo" runat="server" CssClass="" Text="Acepto recibir información y promociones de Farmacias Benavides" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align:left;" class="auto-style16">
                            </td>
                        <td style="text-align:left;" class="auto-style8">
                            </td>
                        <td style="text-align:left;" class="auto-style18">
                            </td>
                        <td style="text-align:left;" class="auto-style6">
                            </td>
                    </tr>
                    <tr>
                        <td style="text-align:left;" class="auto-style15">
                            &nbsp;</td>
                        
                        <td style="text-align:left;" class="auto-style11">
                            <asp:ImageButton ID="btnCancelar" runat="server" ImageUrl="~/Imagenes_Benavides/botones/cancelar-btn.png"
                                OnClick="btnCancelar_Click" CausesValidation="false" Visible="true" />
                            </td>
                        
                        <td style="text-align:left;text-align:left;" class="auto-style17">
                            <asp:ImageButton ID="btnRegistrar" runat="server" OnClick="btnRegistrar_Click" ImageUrl="~/Imagenes_Benavides/botones/registrar-btn.png" ValidationGroup="ValidaDatos" />
                            </td>
                        <td style="text-align:left;" class="auto-style12">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="text-align:right;" colspan="2">
                                &nbsp;</td>
                        <td style="text-align:left;" class="auto-style17">
                            &nbsp;</td>
                        <td style="text-align:left;" class="auto-style12">
                                &nbsp;</td>
                    </tr>
                </table>
                                    
                <div id="dvCuestionarioCC" runat="server" visible="false">
                                <asp:Panel ID="pnlCuestionarioCC" runat="server">
                                     <table style="width: 600px; background-color: #E6E6E6;">
                                        <tr>
                                            <td colspan="3" style="height:25px"></td>                                           
                                        </tr>
                                        <tr>
                                            <td style="width:25px"></td>
                                            <td>
                                                <table style="width: 550px">
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblMsnMP" runat="server" Text="Sr./Sra." Font-Names="Arial" ForeColor="#777E7F"
                                                    Font-Size="12px"></asp:Label>
                                                &nbsp
                                                <asp:Label ID="lblNombreMensaje" runat="server" Font-Names="Arial" ForeColor="#004A99"
                                                    Font-Size="12px"></asp:Label>
                                                &nbsp
                                                <asp:Label ID="Label3" runat="server" Text="a continuación le haré 5 preguntas que nos ayudarán a conocerlo/a mejor para poder ofrecerle más y mejores ofertas."
                                                    Font-Names="Arial" ForeColor="#777E7F" Font-Size="12px"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: text-bottom; text-align:center">
                                                <br />
                                                <asp:Label ID="Label5" runat="server" Text="¿Está de acuerdo?" Font-Names="Arial"
                                                    ForeColor="#777E7F" Font-Size="12px"></asp:Label><br />
                                                <asp:LinkButton ID="lnkAceptar" runat="server" Text="Aceptar" ForeColor="#004A99"
                                                    CssClass="Etiqueta" Font-Bold="True" Font-Size="14px" OnClick="lnkAceptar_Click"></asp:LinkButton>
                                                &nbsp &nbsp &nbsp &nbsp &nbsp
                                                <asp:LinkButton ID="lnkCancelar" runat="server" Text="Cancelar" ForeColor="#004A99"
                                                    CssClass="Etiqueta" Font-Bold="True" Font-Size="14px" OnClick="lnkCancelar_Click"></asp:LinkButton>
                                            </td>
                                        </tr>
                                    </table>
                                            </td>
                                            <td style="width:25px"></td>
                                        </tr>
                                        <tr>
                                            <td colspan="3"  style="height:25px"></td>                                           
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <cc1:ModalPopupExtender ID="mpeCuestionarioCC" runat="server" PopupControlID="pnlCuestionarioCC"
                                    TargetControlID="btnRegistrar" DynamicServicePath="" BackgroundCssClass="modalBackground">
                                </cc1:ModalPopupExtender>
                            </div>
            </div>
    
    

    <div id="popReg" style="display: none; background-color: rgba(0, 0, 0, 0.5); z-index: 20000; left: 0%; position: absolute; top: 0px; width: 100%; height: 100%; text-align: center;">
        <div  style="background-color: #333333; max-width: 400px; padding: 15px; width: 100%; display: inline-block; vertical-align: middle; height: 160px; margin-top:18%; max-height: 445px;">
            <div class="modal-content"  style="background-color:#E2E1E1; height:135px; background-image:url(; background-repeat: repeat-x"../Images/background2.jpg");
            

                <div class="modal-header">
                    <button id="btnCloseReg" type="button" class="close" data-dismiss="modal" runat="server">&times;</button>
                    
                    <asp:Table ID="tblBotones" runat="server" HorizontalAlign="Center" CellSpacing="5" CellPadding="3" Width="320">
                        <asp:TableRow>
                            <asp:TableCell RowSpan="3" HorizontalAlign="Center"  VerticalAlign="Middle">
                               <img src="../Imagenes_Benavides/botones/question.png" width="45" height="45" />
                            </asp:TableCell>
                             <asp:TableCell ColumnSpan="2">
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                            </asp:TableCell>
                            <asp:TableCell ColumnSpan="3" HorizontalAlign="Center"  >
                                <h2>
                                    <asp:Label ID="lblmsg1" runat="server" Font-Size="14px" Font-Bold="true" Text ="No ingresó correo electrónico"></asp:Label><br />
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
                                <asp:Button ID="btnNo" runat="server" CssClass="input" Width="100"  Text="No" />
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </div>
       
            </div>
        </div>
    </div>
</asp:Content>



