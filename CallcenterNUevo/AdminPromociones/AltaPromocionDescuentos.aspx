<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaPromocionDescuentos.aspx.cs" Inherits="CallcenterNUevo.AdminPromociones.AltaPromocionDescuentos" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <script src="../Scripts/jquery-1.7.1.min.js"></script>
      <script src="../Scripts/jquery-ui-1.8.20.min.js"></script>
     <link href="cssAdminProm/cssAdminPromocion.css" rel="stylesheet" />
    <script src="jsAdminProm/jsAdminPromocion.js"></script>
      
	  <script type="text/javascript">
    function GetKey(e) {
        var keynum;
        if (window.event) { keynum = e.keyCode; }
        else if (e.which) { keynum = e.which; }
        return keynum;
    }

    function GetChar(ev) {
        var ev = ev || window.event;
        var chr = ev.charCode || ev.keyCode;
        return String.fromCharCode(chr);
    }

    function ValidarTecla(ev) {
        var key = GetKey(ev);
        if (key > 63) {
            var chr = GetChar(ev);
            if (/[\d|\.|,]/.test(chr)) {
                return true;
            } else {
                return false;
            }
        } else {
            return true;
        }
    }

    function ValidarTexto(ele) {
        var valor = ele.value;
        if (/^\d[,|\.]\d*/.test(valor) == false) {
            alert("El valor no es válido.");
        } else {
            if ((parseFloat(valor) < 0) || (parseFloat(valor) > 5)) {
                alert("Debe estar entre cero y cinco.");
            }
        }
    }
</script>


     <style type="text/css">
        .overlay  
        {
            position: fixed;
            z-index: 98;
            top: 0px;
            left: 0px;
            right: 0px;
            bottom: 0px;
            background-color: #aaa; 
            filter: alpha(opacity=80); 
            opacity: 0.8; 
        }

        .overlayContent
        {
            z-index: 99;
            margin: 250px auto;
            width: 32px;
            height: 32px;
        }

        .titulo
        {
            font-family: Arial;
            font-size: 16pt;
            color: #004A99;
        }
       
        .fuenteReporte
        {
            font-family: Arial Narrow;
            font-size: 12pt;
            color:#2B347A;
        }

        .RadGrid_Default .rgHeader, .RadGrid_Default th.rgResizeCol, .RadGrid_Default .rgHeaderWrapper {
            background: #2B347A 0 -2300px repeat-x !important;
            color: #fff !important;
            font-size: 12pt !important;
        }

        .cajatexto {
            border: 1px solid #808080;
        }

        .BackGround {
           background-color:#808080;
           opacity:0.6;
           filter:alpha(opacity=60);
          }

        .RadButton.rbButton.css3Shadows {
        border: 0;
        border-radius: 5px;
        box-shadow: 1px 2px 5px #666;
        }

         input[type=submit] {
            background-color: #f70606;
            color: #fff;
            border: 1px solid #808080;
            font-family: Arial;
            font-size: 12pt;
            border-radius: 10px;
            width: 80px;
         }

        input[type=submit]:hover {
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

        .gradient {
          width: 200px;
          height: 200px;

          background: #00ff00; /* Para exploradores sin css3 */

           /* Para el WebKit (Safari, Google Chrome etc) */
          background: -webkit-gradient(linear, left top, left bottom, from(#fff), to(#CCCCCC));
  
          /* Para Mozilla/Gecko (Firefox etc) */
          background: -moz-linear-gradient(top, #00ff00, #000000);
  
          /* Para Internet Explorer 5.5 - 7 */
          filter: progid:DXImageTransform.Microsoft.gradient(startColorstr=#00ff00, endColorstr=#000000, GradientType=0);
  
          /* Para Internet Explorer 8 */
          -ms-filter: "progid:DXImageTransform.Microsoft.gradient(startColorstr=#FF0000FF, endColorstr=#FFFFFFFF)";

          border:1px solid #595959; border-right:5px solid #595959; border-bottom:2.5px solid #595959;
     }
    </style>


        <asp:Label runat="server" ID="lblTitulo" Text="Alta de Promociones de descuentos"  Font-Size="16px" ForeColor="DarkBlue"/>
        <br />

        <asp:UpdatePanel ID="upAltaPromocionDescuentos" runat="server">
        <ContentTemplate>
        <br />
                <asp:Panel runat="server" ID="pnlAltaPromDescuento" ScrollBars="Auto" Width="100%" Height="100%"> 
                    <asp:Table ID="tblPromoDesc" runat="server" HorizontalAlign="Center"   Width="800px" Height="100%">
                    <asp:TableRow>
                        <asp:TableCell Height="38px">
                            <asp:Label ID="Label2" runat="server" Text="Nombre de Promoción:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell Height="38px">
                            <asp:TextBox ID="txtNombrePromocion" runat="server" Width ="350px"></asp:TextBox>
                        </asp:TableCell>
                        </asp:TableRow>
                       
                    <asp:TableRow>
                        <asp:TableCell Height="38px">
                            <asp:Label ID="Label6" runat="server" Text="Cantidad de descuento:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell Height="38px">
                            <asp:TextBox ID="txtCantidadDescuento" runat="server" onKeypress="return ValidarTecla(event);"  Width ="140px" MaxLength="6" ></asp:TextBox>
                            <asp:Label ID="Label9" runat="server" Text=" % (Valores permitidos 1 - 100)"></asp:Label>&nbsp;
                            
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell Height="38px">
                            <asp:Label ID="Label4" runat="server" Text="Fecha Inicio:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell Height="38px">
                            <telerik:RadDatePicker ID="rdpFIni" runat="server"  Culture="es-MX" RenderMode="Lightweight"  Width="140px" ></telerik:RadDatePicker>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell Height="38px">
                            <asp:Label ID="Label5" runat="server" Text="Fecha Fin:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell Height="38px">
                            <telerik:RadDatePicker ID="rdpFFin" runat="server"  Culture="es-MX" RenderMode="Lightweight"  Width="140px" ></telerik:RadDatePicker>
                        </asp:TableCell>
                    </asp:TableRow>
                       <asp:TableRow>
                            <asp:TableCell Height="38px">
                            <asp:Label runat="server" text="Límite período:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell Height="38px">
                                <telerik:RadComboBox ID="rcbLimPeriodo" AutoPostBack="true" RenderMode="Lightweight"  AllowCustomText="true" Filter="Contains" MarkFirstMatch="true"    runat="server"   OnSelectedIndexChanged="rcbLimPeriodo_SelectedIndexChanged"  Width="145px"  TabIndex="0"  Enabled="true" >
                                </telerik:RadComboBox>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow >
                        <asp:TableCell >
                            <asp:Label runat="server" text="Límite:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell >
                            <asp:TextBox ID="txtLimite" runat="server" Width="140px" AutoPostBack ="true" OnTextChanged="txtLimite_TextChanged"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="ftbeLimite" runat="server" FilterType="Numbers" TargetControlID="txtLimite"></cc1:FilteredTextBoxExtender>
                        </asp:TableCell>
                    </asp:TableRow>
                    
                    <asp:TableRow>
                        <asp:TableCell ColumnSpan ="2">
                            <asp:Table runat="server" Width="650px">
                                <asp:TableRow >
                                    <asp:TableCell Height="38px" Width="100px">
                                        <asp:Label ID="lbñDias" runat="server" Text="Días:"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell Height="38px">
                                         <asp:CheckBox ID="chkLunes" runat="server" Text ="Lunes" TextAlign="Left"/>
                                    </asp:TableCell>
                                    <asp:TableCell Height="38px">
                                        <asp:CheckBox ID="chkMartes" runat="server" Text ="Martes" TextAlign="Left"/>
                                    </asp:TableCell>
                                    <asp:TableCell Height="38px">
                                        <asp:CheckBox ID="chkMiercoles" runat="server" Text ="Miércoles" TextAlign="Left"/>
                                    </asp:TableCell>
                                    <asp:TableCell Height="38px">
                                        <asp:CheckBox ID="chkJueves" runat="server" Text ="Jueves" TextAlign="Left"/>
                                    </asp:TableCell>
                                    <asp:TableCell Height="38px">
                                        <asp:CheckBox ID="chkViernes" runat="server" Text ="Viernes" TextAlign="Left"/>
                                    </asp:TableCell>
                                    <asp:TableCell Height="38px">
                                        <asp:CheckBox ID="chkSabado" runat="server" Text ="Sábado" TextAlign="Left"/>
                                    </asp:TableCell>
                                    <asp:TableCell Height="38px">
                                        <asp:CheckBox ID="chkDomingo" runat="server" Text ="Domingo" TextAlign="Left"/>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell Height="38px">
                            <asp:Label ID="Label7" runat="server" Text=" Servicio Domicilio:"></asp:Label>
                            <br/><br/>
                        </asp:TableCell>
                         <asp:TableCell Height="38px">
                             <asp:CheckBox ID="chkServicioDom" runat="server" Text =""/>
                             <br/><br/>
                        </asp:TableCell>
                    </asp:TableRow>
                
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label ID="Label8" runat="server" Text="Adicional Inapam:"></asp:Label>
                            <br/><br/>
                        </asp:TableCell>
                        <asp:TableCell>
                                <asp:CheckBox ID="chkINAPAM" runat="server"  TextAlign="Left"  />
                                <br/><br/>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                             <asp:TableCell>
                                <asp:Label ID="Label11" runat="server" Text="Aplica acumulación base:"></asp:Label>
                                <br/><br/>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:CheckBox ID="chkACBase" runat="server"  TextAlign="Left"  />
                                <br/><br/>
                        </asp:TableCell>
                        </asp:TableRow>
                    <asp:TableRow>
                         <asp:TableCell>
                             <asp:Label ID="Label12" runat="server" Text="Aplica con acumulación de piezas:"></asp:Label>
                            <br/><br/>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:CheckBox ID="chkACPiezas" runat="server"  TextAlign="Left"  />
                            <br/><br/>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow >
                            <asp:TableCell VerticalAlign="Top" >
                                <asp:Label ID="Label1" runat="server" Text="Bin:"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell >
                                <asp:CheckBoxList ID="chkBIN" runat="server" />
                            </asp:TableCell>
                        </asp:TableRow>
                    <asp:TableRow>
                    <asp:TableCell Height="38px" Width="275px">
                        <asp:Label ID="Label10" runat="server" Text="Sucursales:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell Height="38px">
                        <asp:FileUpload ID="fldUpSucursales" runat="server" cssClass="input" />
                    </asp:TableCell>
                    <asp:TableCell Width="40px" HorizontalAlign="Left">
                        <asp:ImageButton ID="imgbtnHelpSuc" ImageUrl = "../../Imagenes_Benavides/botones/question.png"  ToolTip="Ayuda" runat="server"  Width="20px" OnClick="imgbtnHelpSuc_Click"/>
                    </asp:TableCell>
                    <asp:TableCell Width="150px" >
                        <asp:CheckBox ID="chkNivNac" runat="server" Text="Nivel Nacional" AutoPostBack="true"  OnCheckedChanged="chkNivNac_CheckedChanged" />
                    </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                    <asp:TableCell Height="38px">
                        <asp:Label ID="Label3" runat="server" Text="Productos:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell Height="38px">
                        <asp:FileUpload ID="fldUpProductos" runat="server" cssClass="input" />
                    </asp:TableCell>
                    <asp:TableCell Height="38px">
                        <asp:ImageButton ID="imgbtnHelpProd" ImageUrl = "../../Imagenes_Benavides/botones/question.png"  ToolTip="Ayuda"  runat="server"  Width="20px" OnClick="imgbtnHelpProd_Click"/>
                    </asp:TableCell>
                    </asp:TableRow>
                   
                    <asp:TableRow>
                        <asp:TableCell ColumnSpan="2">
                            <br />
                            <asp:Table ID="tblbotones" runat="server" HorizontalAlign ="left" Width="200px">
                                <asp:TableRow>
                                    <asp:TableCell >
                                        <asp:Button runat="server" ID="btnGuardar"  Text="Guardar" Width="100px" OnClick="btnGuardar_Click" CssClass="input" />
                                    </asp:TableCell>
                                    <asp:TableCell >
                                        <asp:Button runat="server" ID="btnCancelar"  Text="Cancelar" Width="100px" OnClick="btnCancelar_Click" CssClass="input" />
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </asp:TableCell>
                     </asp:TableRow> 
            </asp:Table>
            </asp:Panel>




            <div id="popReg" style="display: none; background-color: rgba(0, 0, 0, 0.5); z-index: 20000; left: 0%; position: absolute; top: 0px; width:100%; height: 100%; text-align: center;">
					<div  style="background-color: #333333; max-width: 420px; padding: 15px; width: 100%; display: inline-block; vertical-align: middle; height:550px; margin-top:18%; max-height: 550px;">
					    <div class="modal-content"  style="background-color:#E2E1E1; height:525px; background-image:url(; background-repeat: repeat-x"../Images/background2.jpg");>
						    <div class="modal-header">
                                <%--<button id="btnCloseReg" type="button" class="close" data-dismiss="modal" runat="server">&times;</button>--%>
                                  <asp:Table ID="tblAyuda" runat="server" CellSpacing="12" CellPadding="8" HorizontalAlign="Center" Width="350px">
                                     <asp:TableRow >
                                        <asp:TableCell>
                                            <asp:Label ID="lblpop" runat="server" Text=""></asp:Label>
                                            <br /><br />
                                        </asp:TableCell>
                                     </asp:TableRow>
                                     <asp:TableRow >
                                        <asp:TableCell HorizontalAlign="Center">
                                            <asp:Image ID="imgPop" runat="server" ImageUrl=" ../../Imagenes_Benavides/botones/question.png" />
                                            <br />
                                        </asp:TableCell>
                                     </asp:TableRow>
                                      <asp:TableRow >
                                        <asp:TableCell>
                                            <asp:Button ID="btnpopAceptar" runat="server" Text="Aceptar" />
                                        </asp:TableCell>
                                     </asp:TableRow>
                                </asp:Table>
                            </div>
	                    </div>
	                </div>
                </div>

        </ContentTemplate> 
        </asp:UpdatePanel>
</asp:Content>
