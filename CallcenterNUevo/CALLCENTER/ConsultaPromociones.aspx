<%@ Page EnableEventValidation="false" Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"   CodeBehind="ConsultaPromociones.aspx.cs" Inherits="CallcenterNUevo.CALLCENTER.ConsultaPromosiones" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!--Consultas de Promociones en dos secciones
    1.-Dimensiones Iniciales
    2.-Busqueda Avanzada
    Author: RIGM
    Fecha:  05/06/2017-->

    <link href="Calendar.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="../Content/EstilosBenavides.css" rel="stylesheet" />
<!--**********************************************************************************************-->
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

    <script type="text/javascript">

        function SecBusqueda(tipoprom) {
            if (tipoprom == "Cupones") {
                var divDI = document.getElementById("divDI");
                divDI.style.visibility = "hidden";

                var divAV = document.getElementById("divAv");
                divAV.style.visibility = "hidden";

                var divCupon = document.getElementById("divCupon");
                divCupon.style.visibility = "visible";

                var divDatos = document.getElementById("divDatos");
                divDatos.style.visibility = "hidden";

                var divDatosCupon = document.getElementById("divDatosCupon");
                divDatosCupon.style.visibility = "visible";

                var divExp = document.getElementById("divExportar");
                divExp.style.display = "none";
            }
            else if (tipoprom == "Imagenes") {
                var divDI = document.getElementById("divDI");
                divDI.style.visibility = "hidden";

                var divAV = document.getElementById("divAv");
                divAV.style.visibility = "hidden";

                var divDatos = document.getElementById("divDatos");
                divDatos.style.visibility = "hidden";

                var divCupon = document.getElementById("divCupon");
                divCupon.style.visibility = "hidden";

                var divDatosCupon = document.getElementById("divDatosCupon");
                divDatosCupon.style.visibility = "hidden";

                var divDI = document.getElementById("divDI");
                divDI.style.visibility = "visible";

                var divDatosImagenes = document.getElementById("divDatosImagenes");
                divDatosImagenes.style.visibility = "visible";

                var divExp = document.getElementById("divExportar");
                divExp.style.display = "none";
            }
            else {
                var divDI = document.getElementById("divDI");
                divDI.style.visibility = "visible";

                var divCupon = document.getElementById("divCupon");
                divCupon.style.visibility = "hidden";

                var divAV = document.getElementById("divAv");
                divAV.style.visibility = "hidden";

                var divDatos = document.getElementById("divDatos");
                divDatos.style.visibility = "visible";

                var divDatosCupon = document.getElementById("divDatosCupon");
                divDatosCupon.style.visibility = "hidden";

                var divExp = document.getElementById("divExportar");
                divExp.style.display = "visible";

            }
        }

        function SecBusquedaOcultar() {

            var divDI = document.getElementById("divDI");
            divDI.style.visibility = "visible";

            var divAV = document.getElementById("divAv");
            divAV.style.visibility = "hidden";

            var divfondo = document.getElementById("divfondo");
            divfondo.style.height = "520px";

            var divDatos = document.getElementById("divDatos");
            divDatos.style.top = "52%";

            var divDatosCupon = document.getElementById("divDatosCupon");
            divDatosCupon.style.top = "52%";

            var divCupon = document.getElementById("divCupon");
            divCupon.style.visibility = "hidden";

            var divDatos = document.getElementById("divDatos");
            divDatos.style.visibility = "visible";

            var divDatosCupon = document.getElementById("divDatosCupon");
            divDatosCupon.style.visibility = "hidden";

            var divExp = document.getElementById("divExportar");
            divExp.style.display = "none";
        }

        function BusquedaAvanzada() {
            var divAV = document.getElementById("divAv");
            divAV.style.visibility = "visible";

            var divDI = document.getElementById("divDI");
            divDI.style.visibility = "hidden";

            var divCupon = document.getElementById("divCupon");
            divCupon.style.visibility = "hidden";

            var divDatos = document.getElementById("divDatos");
            divDatos.style.visibility = "hidden";

            var divExp = document.getElementById("divExportar");
            divExp.style.display = "none";
        }

        function OcultarBusquedaAvanzada() {
            var divAV = document.getElementById("divAv");
            divAV.style.visibility = "hidden";

            var divDI = document.getElementById("divDI");
            divDI.style.visibility = "visible";

            var divCupon = document.getElementById("divCupon");
            divCupon.style.visibility = "hidden";

            OcultaDivDatosCupon();
        }

        function OcultaDivDatosCupon() {
            var divDatos = document.getElementById("divDatos");
            divDatos.style.visibility = "hidden";

            var divDatosCupon = document.getElementById("divDatosCupon");
            divDatosCupon.style.visibility = "hidden";
        }

        function ctrlMensajes(mensaje) {
            alert(mensaje);
        }

        function MuestraExportar() {
            var divExp = document.getElementById("divExportar");
            divExp.style.display = "block";
        }

        function AbrirPopup() {
            var divAV = document.getElementById("divAv");
            divAV.style.visibility = "hidden";

            var divTitulo = document.getElementById("divTitulo");
            divTitulo.style.visibility = "hidden";

            var divfondo = document.getElementById("divfondo");
            divfondo.style.height = "316px";

            var ventana = document.getElementById("divAllPromociones");
            ventana.style.marginTop = "150px";
            ventana.style.left = ((document.body.clientWidth - 1200) / 2) + "px";
            ventana.style.display = "block";

            var divExpAllProm = document.getElementById("divExpAllProm");
            divExpAllProm.style.display = "block";

            //En caso de ser IE
            if (navigator.userAgent.indexOf("Explorer") == -1 && navigator.userAgent.indexOf("Chrome") == -1) {
                divExpAllProm.style.top = "14%";
            }

            //FireFox
            if (navigator.userAgent.indexOf("Firefox") > -1) {
                divExpAllProm.style.top = "16%";
            }
        }

        function ocultarVentana() {
            CerrarOpcionesExporExcel();
            var ventana = document.getElementById("divAllPromociones");
            ventana.style.display = "none";

            var divAV = document.getElementById("divAv");
            divAV.style.visibility = "visible";

            var divExpAllProm = document.getElementById("divExpAllProm");
            divExpAllProm.style.display = "none";

            var divExpAllLab = document.getElementById("divExpAllLab");
            divExpAllLab.style.display = "none";

            var divTitulo = document.getElementById("divTitulo");
            divTitulo.style.visibility = "visible";

            var divfondo = document.getElementById("divfondo");
            divfondo.style.height = "520px";
        }

        function AbrirPopupVenc(valor) {
            var divAV = document.getElementById("divAv");
            divAV.style.visibility = "hidden";

            var divTitulo = document.getElementById("divTitulo");
            divTitulo.style.visibility = "hidden";

            var divfondo = document.getElementById("divfondo");
            divfondo.style.height = "316px";

            if (valor == 1) {
                var divDatCuponVenc = document.getElementById("divDatCuponVenc");
                divDatCuponVenc.style.position = "absolute";
                divDatCuponVenc.style.top = "15%;";
                divDatCuponVenc.style.display = "block";

                var divDatVarios = document.getElementById("divDatVarios");
                divDatVarios.style.display = "none";
            } else {//Se agrega variable que sera aculta:  divDatMixMatchVenc
                var divDatMixMatchVenc = document.getElementById("divDatMixMatchVenc");
                divDatMixMatchVenc.style.height = "316px";
                divDatMixMatchVenc.hidden = "true";

                var divDatCuponVenc = document.getElementById("divDatCuponVenc");
                divDatCuponVenc.style.display = "none";

                var divDatVarios = document.getElementById("divDatVarios");
                divDatVarios.style.display = "block";
            }

            var divExpAllVenc = document.getElementById("divExpAllVenc");
            divExpAllVenc.style.display = "block";

            var divVencimiento = document.getElementById("divVencimiento");
            divVencimiento.style.marginTop = "150px";
            divVencimiento.style.left = ((document.body.clientWidth - 1200) / 2) + "px";
            divVencimiento.style.display = "block";
        }

        function ocultarVentanaVenc() {
            var divExpAllVenc = document.getElementById("divExpAllVenc");
            divExpAllVenc.style.display = "none";

            var divVencimiento = document.getElementById("divVencimiento");
            divVencimiento.style.display = "none";

            var divAV = document.getElementById("divAv");
            divAV.style.visibility = "visible";

            var divTitulo = document.getElementById("divTitulo");
            divTitulo.style.visibility = "visible";

            var divfondo = document.getElementById("divfondo");
            divfondo.style.height = "520px";

            var divExpAllLab = document.getElementById("divExpAllLab");
            divExpAllLab.style.display = "none";
        }

        function AbrirPopupLab() {
            var divAV = document.getElementById("divAv");
            divAV.style.visibility = "hidden";

            var divTitulo = document.getElementById("divTitulo");
            divTitulo.style.visibility = "hidden";

            var divfondo = document.getElementById("divfondo");
            divfondo.style.height = "316px";

            var divDatCuponVenc = document.getElementById("divDatCuponVenc");
            divDatCuponVenc.style.position = "relative";
            divDatCuponVenc.style.top = "45%;";
            divDatCuponVenc.style.display = "block";


            var divDatVarios = document.getElementById("divDatVarios");
            divDatVarios.style.display = "block";

            var divVencimiento = document.getElementById("divVencimiento");
            divVencimiento.style.marginTop = "150px";
            divVencimiento.style.left = ((document.body.clientWidth - 1200) / 2) + "px";
            divVencimiento.style.display = "block";

            var divExpAllLab = document.getElementById("divExpAllLab");
            divExpAllLab.style.display = "block";

            //En caso de ser IE
            if (navigator.userAgent.indexOf("Explorer") == -1 && navigator.userAgent.indexOf("Chrome") == -1) {
                divExpAllLab.style.top = "14%";
            }


            //FireFox
            if (navigator.userAgent.indexOf("Firefox") > -1) {
                divExpAllLab.style.top = "16%";
            }
        }

        function ocultarVentanaLab() {
            ocultarVentanaVenc();
        }

        function OpcionesExporExcel() {

            var divOpcionesExportExcel = document.getElementById("divOpcionesExportExcel");
            divOpcionesExportExcel.style.display = "block";

            var divExpAllProm = document.getElementById("divExpAllProm");
            divExpAllProm.style.display = "block";

            var divVencimiento = document.getElementById("divVencimiento");
            divVencimiento.style.display = "none";

            //En caso de ser IE
            if (navigator.userAgent.indexOf("Explorer") == -1 && navigator.userAgent.indexOf("Chrome") == -1) {
                var width = 0;
                width = ((document.body.clientWidth - 1200) / 2);
                divOpcionesExportExcel.style.top = "23%";
                divOpcionesExportExcel.style.left = "180px";
                var divOpc = document.getElementById("divOpc");
                divOpc.style.top = "23%";
                divOpc.style.left = width + 2;
                divExpAllProm.style.top = "14%";
            }


            //FireFox
            if (navigator.userAgent.indexOf("Firefox") > -1) {
                divOpcionesExportExcel.style.top = "26%";
                divOpcionesExportExcel.style.left = "125px";
                var divOpc = document.getElementById("divOpc");
                divOpc.style.top = "30%";
                divOpc.style.left = "125";
                divExpAllProm.style.top = "16%";
            }


        }

        function CerrarOpcionesExporExcel() {
            var divExpAllProm = document.getElementById("divExpAllProm");
            divExpAllProm.style.display = "block";

            var divOpcionesExportExcel = document.getElementById("divOpcionesExportExcel");
            divOpcionesExportExcel.style.display = "none";

            //En caso de ser IE
            if (navigator.userAgent.indexOf("Explorer") == -1 && navigator.userAgent.indexOf("Chrome") == -1) {
                divExpAllProm.style.top = "14%";
            }


            //FireFox
            if (navigator.userAgent.indexOf("Firefox") > -1) {
                divExpAllProm.style.top = "16%";
            }
        }

        function OpcionesExporExcelLab() {

            var divOpcionesLabExportExcel = document.getElementById("divOpcionesLabExportExcel");
            divOpcionesLabExportExcel.style.display = "block";

            var divExpAllLab = document.getElementById("divExpAllLab");
            divExpAllLab.style.display = "block";

            var divVencimiento = document.getElementById("divVencimiento");
            divVencimiento.style.display = "none";

            AbrirPopupLab();
            //En caso de ser IE
            if (navigator.userAgent.indexOf("Explorer") == -1 && navigator.userAgent.indexOf("Chrome") == -1) {
                var divOpcLab = document.getElementById("divOpcLab");
                divOpcionesLabExportExcel.style.top = "26%";
                divOpcionesLabExportExcel.style.left = "330px";
                divOpcLab.style.top = "26%";
                divOpcLab.style.left = "330px";
            }

            //FireFox
            if (navigator.userAgent.indexOf("Firefox") > -1) {
                var divOpcLab = document.getElementById("divOpcLab");
                divOpcionesLabExportExcel.style.top = "30%";
                divOpcionesLabExportExcel.style.left = "290px";
                divOpcLab.style.top = "30%";
                divOpcLab.style.left = "290px";
            }
        }

        function CerrarOpcionesExporExcelLab() {

            //Para mantener visible el boton de exportar
            var divExpAllLab = document.getElementById("divExpAllLab");
            divExpAllLab.style.display = "block";

            //Para mantener la posición del div
            var divDatCuponVenc = document.getElementById("divDatCuponVenc");
            divDatCuponVenc.style.position = "relative";
            divDatCuponVenc.style.top = "45%;";
            divDatCuponVenc.style.display = "block";

            //Para ocultar div de opciones de exportar
            var divOpcionesLabExportExcel = document.getElementById("divOpcionesLabExportExcel");
            divOpcionesLabExportExcel.style.display = "none";

            //En caso de ser IE
            if (navigator.userAgent.indexOf("Explorer") == -1 && navigator.userAgent.indexOf("Chrome") == -1) {
                divExpAllLab.style.top = "14%";
            }


            //FireFox
            if (navigator.userAgent.indexOf("Firefox") > -1) {
                divExpAllLab.style.top = "16%";
            }
        }

        function MuestraImagenEspera(valor) {
            if (valor == "DI") {
                var imgCargando = document.getElementById("imgCargando");
                imgCargando.style.display = "block";
            } else if (valor == "DICup") {
                var imgCargandoCup = document.getElementById("imgCargandoCup");
                imgCargandoCup.style.display = "block";
            } else if (valor == "AVxProd") {
                var imgCargandoProd = document.getElementById("imgCargandoProd");
                imgCargandoProd.style.display = "block";
            } else if (valor == "AVVenc") {
                var imgCargandoVenc = document.getElementById("imgCargandoVenc");
                imgCargandoVenc.style.display = "block";
            } else if (valor == "AVTM") {
                var imgCargandoTM = document.getElementById("imgCargandoTM");
                imgCargandoTM.style.display = "block";
            } else if (valor == "AVLAB") {
                var imgCargandoLab = document.getElementById("imgCargandoLab");
                imgCargandoLab.style.display = "block";
            }

        }

        function OcultaImagenEspera(valor) {
            if (valor == "DI") {
                var imgCargando = document.getElementById("imgCargando");
                imgCargando.style.display = "none";
            } else if (valor == "DICup") {
                var imgCargandoCup = document.getElementById("imgCargandoCup");
                imgCargandoCup.style.display = "none";
            } else if (valor == "AVxProd") {
                var imgCargandoProd = document.getElementById("imgCargandoProd");
                imgCargandoProd.style.display = "none";
            } else if (valor == "AVVenc") {
                var imgCargandoVenc = document.getElementById("imgCargandoVenc");
                imgCargandoVenc.style.display = "none";
            } else if (valor == "AVTM") {
                var imgCargandoTM = document.getElementById("imgCargandoTM");
                imgCargandoTM.style.display = "none";
            } var imgCargandoLab = document.getElementById("imgCargandoLab");
            imgCargandoLab.style.display = "none";
        }
     </script>
<!--**********************************************************************************************-->

        <div id="divTitulo">
            <span class="titulo">Consulta de Promociones</span>
            <br/>
        </div>
        <asp:UpdatePanel ID="UpTipoConsulta" updatemode="Conditional" runat="server">
        <ContentTemplate >
            <asp:CheckBox runat="server" ID="chkAv" AutoPostBack="true" Text="Consulta Avanzada" OnCheckedChanged="chkAv_Changed"/>
        </ContentTemplate>
        </asp:UpdatePanel>

        <div id="divfondo" style="position:static;top:0%;background-image: url(Imagenes_Benavides/acceso-registro-header.jpg);
            width: auto; height:520px; background-repeat: no-repeat;">
               
            <asp:UpdatePanel ID="UpBusquedas" updatemode="Conditional" runat="server">
            <ContentTemplate >
                <div id="divDI" style="position:absolute;top:32%; height:200px;width:1200px;">
                    <asp:Panel ID="pnlFiltro1" runat="server" GroupingText="Dimensiones iniciales">
                        <table id="tblDI"  style="vertical-align:top;position:absolute;width:100%"">
                            <tr>
                            <td style="text-align:left;"  >
                                <span style="color:#2B347A;">Tipo de Promoción: </span>
                            </td>
                            <td style="text-align:left">
                                <telerik:RadComboBox RenderMode="Lightweight" AutoPostBack="true" AllowCustomText="False" ID="rdcTipoPromo" runat="server" OnSelectedIndexChanged="rdcTipoPromo_Changed"   Width="180px">
                                    <Items>
                                        <telerik:RadComboBoxItem Text="Piezas Gratis" Value="1" Selected="true" />
                                        <telerik:RadComboBoxItem Text="Acumulación DE" Value="2" />
                                        <telerik:RadComboBoxItem Text="Dinero Electrónico" Value="3" />
                                        <telerik:RadComboBoxItem Text="Cupones" Value="4" />
                                        <telerik:RadComboBoxItem Text="Promociones Portal BI" Value="5" />
                                        <telerik:RadComboBoxItem Text="Mix & Match" Value="6" />
                                    </Items>
                                </telerik:RadComboBox>
                            </td>
                            <td class="fuenteReporte" style="text-align:left">Segmento: </td>
                            <td>
                                <telerik:RadComboBox RenderMode="Lightweight" AllowCustomText="False" ID="rdcSegmento" runat="server"  Width="130px">
                                    <Items>
                                        <telerik:RadComboBoxItem Text="Todas" Value="0" Selected="true"/>
                                        <telerik:RadComboBoxItem Text="Club Peques" Value="1"/>
                                        <telerik:RadComboBoxItem Text="BI General" Value="2" />
                                    </Items>
                                </telerik:RadComboBox>
                            </td>

                            <td class="fuenteReporte" style="text-align:left">Estatus: </td>
                            <td>
                                <telerik:RadComboBox RenderMode="Lightweight" AllowCustomText="False" ID="rdcEstatus" runat="server" AutoPostBack="true" OnTextChanged="rdcEstatus_TextChanged" Width="130px">
                                    <Items>
                                        <telerik:RadComboBoxItem Text="Todas" Value="0" Selected="true"/>
                                        <telerik:RadComboBoxItem Text="Vigentes" Value="1"/>
                                        <telerik:RadComboBoxItem Text="No Vigentes" Value="2" />
                                    </Items>
                                </telerik:RadComboBox>
                            </td>
                            <td>
                                <telerik:RadTextBox ID="txtCodIntDI" runat="server" Width="120px" Height="27px"   OnTextChanged="txtCodIntDI_TextChanged" Visible="false"></telerik:RadTextBox>
                            </td>
                            <td class="fuenteReporte" style="text-align:left">Elementos por página:</td>
                            <td>
                                <telerik:RadComboBox RenderMode="Lightweight" AllowCustomText="False" ID="rdcItemsxPagina" runat="server" Width="100px">
                                    <Items>
                                        <telerik:RadComboBoxItem Text="Todos" Value="0" Selected="true"/>
                                        <telerik:RadComboBoxItem Text="5" Value="5"/>
                                        <telerik:RadComboBoxItem Text="10" Value="10" />
                                        <telerik:RadComboBoxItem Text="20" Value="20" />
                                    </Items>
                                </telerik:RadComboBox>
                            </td>
                            <td style="width:100px">
                                <asp:Button ID="rbtnBuscarDI" runat="server"  CssClass="input" style="float:right; width:140px" Text="Buscar" OnClientClick="MuestraImagenEspera('DI')" OnClick="rbtnBuscarDI_Click" />
                                <div  id="imgCargando" style="position:absolute; display:none;top:0%;width:140px;align-items:center;text-align:center;">
                                    <img  style="top:0%;align-items:center;text-align:center;" src="../Images/aero_light.gif"  />
                                </div>
                            </td>
                            </tr>
                         </table>
                    </asp:Panel>
                </div>
                <div id="divCupon" style="position:absolute;top:32%;height:200px;width:1200px;visibility:hidden;">
                        <asp:Panel ID="pnlCupones" runat="server" GroupingText="Dimensiones iniciales">
                    <div class="demo-container no-bg">
                        <asp:Table ID="tblCupones" runat="server" Width="100%" CellSpacing="1" CellPadding="5">
                            <asp:TableRow>
                                <asp:TableCell Width="100px" VerticalAlign="top" HorizontalAlign="Center">
                                    Tipo de Promoción:
                                </asp:TableCell>
                                <asp:TableCell VerticalAlign="Top">
                                <telerik:RadComboBox RenderMode="Lightweight" AutoPostBack="true" AllowCustomText="False" ID="rcbTipoPromCupones" runat="server" OnSelectedIndexChanged="rdcTipoPromoCupon_Changed"   Width="150px">
                                    <Items>
                                        <telerik:RadComboBoxItem Text="Piezas Gratis" Value="1" Selected="true"/>
                                        <telerik:RadComboBoxItem Text="Acumulación DE" Value="2"/>
                                        <telerik:RadComboBoxItem Text="Dinero Electrónico" Value="3" />
                                        <telerik:RadComboBoxItem Text="Cupones" Value="4" />
                                        <telerik:RadComboBoxItem Text="Promociones Portal BI" Value="5" />
                                        <telerik:RadComboBoxItem Text="Mix & Match" Value="6" />
                                    </Items>
                                </telerik:RadComboBox>
                                </asp:TableCell >
                                <asp:TableCell Width="160px" VerticalAlign="Top" HorizontalAlign="Center">
                                   Número de cupón:
                                </asp:TableCell>
                                <asp:TableCell VerticalAlign="Top">
                                    <telerik:RadTextBox ID="txtNumCupon" AutoPostBack="true" OnTextChanged="txtNumCupon_Textchange" DisplayText="Num. Cupón" runat="server" Width="150px"></telerik:RadTextBox>
                                </asp:TableCell >
                                <asp:TableCell VerticalAlign="Top" Width="120px" HorizontalAlign="Center">
                                    Del:
                                </asp:TableCell>
                                <asp:TableCell VerticalAlign="Top" Width="160" HorizontalAlign="Center">
                                    <telerik:RadDatePicker ID="rdpFIni" runat="server" Culture="es-MX" RenderMode="Lightweight" DateInput-DisplayText="Fecha Inicial" OnSelectedDateChanged="rdpFIni_SelectedDateChanged" Width="140px"></telerik:RadDatePicker>
                                </asp:TableCell>
                                <asp:TableCell VerticalAlign="Top"  Width="120px" HorizontalAlign="Center">
                                    Al:
                                </asp:TableCell>
                                <asp:TableCell VerticalAlign="Top" Width="160" HorizontalAlign="Center">
                                    <telerik:RadDatePicker ID="rdpFFin" runat="server" Culture="es-MX" RenderMode="Lightweight" DateInput-DisplayText="Fecha Final" OnSelectedDateChanged="rdpFFin_SelectedDateChanged" Width="140px"></telerik:RadDatePicker>
                                </asp:TableCell>
                                <asp:TableCell Width="185px" VerticalAlign="Top" HorizontalAlign="Center">
                                    Elementos por página:
                                </asp:TableCell>
                                <asp:TableCell VerticalAlign="Top">
                                    <telerik:RadComboBox RenderMode="Lightweight" AllowCustomText="False" ID="rdcItemsxPaginaCupon" runat="server" Width="100px">
                                    <Items>
                                        <telerik:RadComboBoxItem Text="Todos" Value="0" Selected="true"/>
                                        <telerik:RadComboBoxItem Text="5" Value="5"/>
                                        <telerik:RadComboBoxItem Text="10" Value="10" />
                                        <telerik:RadComboBoxItem Text="20" Value="20" />
                                    </Items>
                                    </telerik:RadComboBox>
                                </asp:TableCell>
                                <asp:TableCell Width="150px" VerticalAlign="Top" HorizontalAlign="Center">
                                    <asp:Button ID="rbtnBuscarCupones" runat="server" CssClass="input"  style="float:right; width:140px" Text="Buscar" OnClientClick="MuestraImagenEspera('DICup')" OnClick="rbtnBuscarCupones_Click" />
                                     <div  id="imgCargandoCup" style="position:absolute; display:none;top:25%;width:140px;align-items:center;text-align:center;">
                                        <img  style="top:0%; align-items:center;text-align:center;" src="../Images/aero_light.gif"  />
                                    </div>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </div>
                    </asp:Panel>
                </div>
                <div id="divAv" style="position:absolute;top:32%; height:250px;width:1200px;">
                    <asp:Panel ID="pnlBusquedaAvanzada" runat="server" GroupingText="Búsqueda Avanzada">
                    <div class="demo-container no-bg">
                        <telerik:RadTabStrip RenderMode="Lightweight" ID="tabBusquedaAv" runat="server"  EnableDragToReorder="true" Skin="Silk" MultiPageID="RadMultiPag1" SelectedIndex="0">
                            <Tabs>
                                <telerik:RadTab Text="Producto" Selected="true"></telerik:RadTab>
                                <telerik:RadTab Text="Vencimiento"></telerik:RadTab>
                                <telerik:RadTab Text="Tipo de Mecánica"></telerik:RadTab>
                                <telerik:RadTab Text="Laboratorio"></telerik:RadTab>
                            </Tabs>
                        </telerik:RadTabStrip>
                        <telerik:RadMultiPage ID="RadMultiPag1" runat="server"  CssClass="RadMultiPage" SelectedIndex="0">
                            <telerik:RadPageView ID="rpvProducto" runat="server" CssClass="RadMultiPage"  Height="250" Style="overflow: hidden">
                                <br />
                                    <table style=" border-collapse: separate;  border-spacing: 5px; margin: 0 auto; width:800px;">
                                            <tr>
                                                <td style="padding: 0px;">
                                                    <asp:Label ID="Label1" runat="server" Text="Ingresa el código interno o de barras del producto que deseas buscar"></asp:Label>
                                                </td>
                                                <td style="padding: 0px;">
                                                    <asp:Label ID="Label2" runat="server" Text="Elementos por página"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                    <td style="padding: 0px;vertical-align:top;">
                                                        <div  style="background-color:lightgray;text-align:center;width:250px;height:35px;">
                                                        <telerik:RadTextBox ID="txtNumIntCodBar" runat="server" AutoPostBack="true" Width="200px" DisplayText="Ingresar código interno o de barras" OnTextChanged="txtNumIntCodBar_TextChanged" ></telerik:RadTextBox>
                                                        </div>
                                                    </td>
                                                    <td style="padding: 0px;vertical-align:top;">
                                                        <div  style="background-color:lightgray;text-align:center;height:35px;">
                                                        <telerik:RadComboBox RenderMode="Lightweight" AllowCustomText="False" ID="rdcitemsxPagProd" runat="server"  Width="100px">
                                                        <Items>
                                                            <telerik:RadComboBoxItem Text="Todos" Value="0" Selected="true"/>
                                                            <telerik:RadComboBoxItem Text="5" Value="5"/>
                                                            <telerik:RadComboBoxItem Text="10" Value="10" />
                                                            <telerik:RadComboBoxItem Text="20" Value="20" />
                                                        </Items>
                                                    </telerik:RadComboBox>
                                                    </div>
                                                    </td>
                                                <td style="padding: 0px;vertical-align:top;text-align:right;width:150px;">
                                                    <asp:Button ID="rbtnBuscarProd"  runat="server" Text="Buscar" CssClass="input"  style="float:right; width:150px" OnClientClick="MuestraImagenEspera('AVxProd')"  OnClick="rbtnBuscarProd_Click"></asp:Button>
                                                    <div  id="imgCargandoProd" style="position:absolute; display:none;width:150px;align-items:center;text-align:center;">
                                                        <img  style="top:0%; align-items:center;text-align:center;" src="../Images/aero_light.gif"  />
                                                    </div>
                                                </td>
                                            </tr>
                                    </table>
                            </telerik:RadPageView>
                            <telerik:RadPageView ID="rpvVencimiento" runat="server" Height="255" Style="overflow: hidden">
                                <br />
                                <table style=" border-collapse: separate;  border-spacing: 0px; margin: 0 auto; width:700px;">
                                        <tr>
                                            <td colspan="4" style="padding: 5px;">
                                                <asp:Label ID="Label3" runat="server" Text="Indica el tipo de promoción y filtros de vencimiento que requieres consultar."></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                        <td style="padding: 5px;"  >
                                            <span style="color:#2B347A;">Tipo de Promoción: </span>
                                        </td>
                                        <td style="padding: 5px;">
                                            <telerik:RadComboBox RenderMode="Lightweight" AutoPostBack="true" AllowCustomText="False" ID="rdcTipoPromVenc" runat="server" OnSelectedIndexChanged="rdcTipoPromVenc_Changed"   Width="150px">
                                            <Items>
                                                <telerik:RadComboBoxItem Text="Piezas Gratis" Value="1" Selected="true"/>
                                                <telerik:RadComboBoxItem Text="Acumulación DE" Value="2"/>
                                                <telerik:RadComboBoxItem Text="Dinero Electrónico" Value="3" />
                                                <telerik:RadComboBoxItem Text="Cupones" Value="4" />
                                                <telerik:RadComboBoxItem Text="Mix & Match" Value="6" />
                                            </Items>
                                            </telerik:RadComboBox>
                                        </td>
                                        <td  colspan="2" style="padding: 5px;text-align:right;width:150px;">
                                            <asp:Button ID="rbtnBusscarVenc" runat="server" CssClass="input" Text="Buscar" style="float:right; width:150px;" Font-Bold="true" OnClientClick="MuestraImagenEspera('AVVenc')" OnClick="rbtnBuscarVenc_Click"></asp:Button>
                                            <div  id="imgCargandoVenc" style="position:absolute; display:none;width:150px;left:62%">
                                                <img  style="top:0%; align-items:center;text-align:center;" src="../Images/aero_light.gif"  />
                                            </div>
                                        </td>
                                        </tr>
                                        <tr>
                                        <td style="padding: 5px;" >
                                            <div  style="background-color:lightgray;text-align:center;">
                                            <asp:RadioButton ID="rdbVenciadas" AutoPostBack="true" runat="server" Text="Vencidas" GroupName="vencimiento" />
                                            </div
                                        </td>
                                        <td style="padding: 5px;">
                                            <div  style="background-color:lightgray;text-align:center;">
                                            <asp:RadioButton ID="rdbVencidasMes" AutoPostBack="true" runat="server" Text="Vencidas en el mes" GroupName="vencimiento" />
                                            </div>
                                        </td>
                                        <td style="padding: 5px;">
                                            <div  style="background-color:lightgray;text-align:center;">
                                            <asp:Label ID="Label4" runat="server" Text="Vencidas en un rango de Fechas"></asp:Label>
                                            <br />
                                            <telerik:RadDatePicker ID="rdpDel" runat="server" DateInput-DisplayText="Vencidas entre"  Culture="es-MX" RenderMode="Lightweight" OnSelectedDateChanged="rdpDel_SelectedDateChanged" Width="150px"></telerik:RadDatePicker>
                                            <telerik:RadDatePicker ID="rdpAl" runat="server" DateInput-DisplayText="Y el" Culture="es-MX" RenderMode="Lightweight" OnSelectedDateChanged="rdpAl_SelectedDateChanged" Width="150px"></telerik:RadDatePicker>
                                            </div>
                                        </td>
                                        <td style="padding: 5px;vertical-align:top;background-color:lightgray;text-align:center;"  >
                                            <asp:Label ID="Label5" runat="server" Text="Por vencer en:"></asp:Label>
                                            <br/>
                                                <telerik:RadComboBox RenderMode="Lightweight" AllowCustomText="False" ID="rcbPorVencer" AutoPostBack="true" OnSelectedIndexChanged="rcbPorVencer_SelectedIndexChanged" runat="server"  Width="100px">
                                                    <Items>
                                                        <telerik:RadComboBoxItem Text="" Value="0" Selected="true"/>
                                                        <telerik:RadComboBoxItem Text="5" Value="5" />
                                                        <telerik:RadComboBoxItem Text="10" Value="10" />
                                                        <telerik:RadComboBoxItem Text="15" Value="15" />
                                                    </Items>
                                                </telerik:RadComboBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="padding: 5px;">
                                            <asp:Label ID="Label6" runat="server" Text="Selecciona cuantos elementos por página requieres"></asp:Label>
                                            <br/>
                                            <telerik:RadComboBox RenderMode="Lightweight" AllowCustomText="False" ID="rcbitemsxpagVenc" runat="server"  Width="100px">
                                                    <Items>
                                                        <telerik:RadComboBoxItem Text="Todos" Value="0" Selected="true"/>
                                                        <telerik:RadComboBoxItem Text="5" Value="5"/>
                                                        <telerik:RadComboBoxItem Text="10" Value="10" />
                                                        <telerik:RadComboBoxItem Text="20" Value="20" />
                                                    </Items>
                                            </telerik:RadComboBox>
                                        </td>
                                    </tr>
                                </table>
                            </telerik:RadPageView>
                            <telerik:RadPageView ID="rpvTipoMecanica" runat="server" Height="250" Style="overflow: hidden">
                                <br />
                                <table style=" border-collapse: separate;  border-spacing: 0px; margin: 0 auto; width:700px;">
                                    <tr>
                                        <td colspan="2" style="padding: 5px;" >
                                            <asp:Label ID="Label7" runat="server" Text="Selecciona el estatus y tipo de mecánica que buscas."></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px;" >
                                            <asp:Label ID="Label8" runat="server" Text="Estatus:"></asp:Label>
                                            <br/>
                                            <telerik:RadComboBox RenderMode="Lightweight" AllowCustomText="False" ID="rcmbEstatusTipoMec"  runat="server" Width="150px">
                                                <Items>
                                                    <telerik:RadComboBoxItem Text="Todas" Value="0" Selected="true"/>
                                                    <telerik:RadComboBoxItem Text="Vigentes" Value="1"/>
                                                    <telerik:RadComboBoxItem Text="No Vigentes" Value="2" />
                                                </Items>
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>
                                            <asp:Button ID="rbtnBuscarTipoMec" runat="server" CssClass="input" Text="Buscar" style="float:right; width:150px;" Font-Bold="true" OnClientClick="MuestraImagenEspera('AVTM')" OnClick="rbtnBuscarTipoMec_Click"></asp:Button>
                                            <div  id="imgCargandoTM" style="position:absolute; display:none;width:150px;left:72%">
                                                <img  style="top:0%; align-items:center;text-align:center;" src="../Images/aero_light.gif"  />
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px;" >
                                            <asp:Label ID="Label9" runat="server" Text="Tipo Mecánica:"></asp:Label>
                                            <br/>
                                            <telerik:RadComboBox RenderMode="Lightweight" AllowCustomText="False" ID="rcbTipoMec" runat="server" Width="100px">
                                                <Items>
                                                    <telerik:RadComboBoxItem Text="A + A" Value="0" Selected="true"/>
                                                    <telerik:RadComboBoxItem Text="A + B" Value="1"/>
                                                </Items>
                                            </telerik:RadComboBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="padding: 5px;">
                                            <asp:Label ID="Label10" runat="server" Text="Elementos por página"></asp:Label>
                                            <br/>
                                            <telerik:RadComboBox RenderMode="Lightweight" AllowCustomText="False" ID="rcbitemsxPagTipoMec" runat="server"  Width="100px">
                                                    <Items>
                                                        <telerik:RadComboBoxItem Text="Todos" Value="0" Selected="true"/>
                                                        <telerik:RadComboBoxItem Text="5" Value="5"/>
                                                        <telerik:RadComboBoxItem Text="10" Value="10" />
                                                        <telerik:RadComboBoxItem Text="20" Value="20" />
                                                    </Items>
                                            </telerik:RadComboBox>
                                        </td>
                                    </tr>
                                </table>
                            </telerik:RadPageView>
                            <telerik:RadPageView ID="rpvLaboratorio" runat="server" Height="200" Style="overflow: hidden">
                                <br/>
                                <table style=" border-collapse: separate;  border-spacing: 0px; margin: 0 auto; width:600px;">
                                    <tr>
                                        <td  style="padding: 5px;" >
                                            <telerik:RadTextBox ID="txtIdLaboratorio" AutoPostBack="true"  DisplayText="ID Laboratorio" runat="server" Width="150px" OnTextChanged="txtIdLaboratorio_TextChanged"></telerik:RadTextBox>
                                        </td>
                                        <td style="padding: 5px;" >
                                            <telerik:RadTextBox ID="txtNomProveedor" AutoPostBack="true"  DisplayText="Nombre Proveedor" runat="server" Width="150px" OnTextChanged="txtNomProveedor_TextChanged"></telerik:RadTextBox>
                                        </td>
                                        <td>
                                            <asp:Button ID="rbtnBuscarLab" runat="server" CssClass="input" Text="Buscar" style="float:right; width:150px;" Font-Bold="true" OnClientClick="MuestraImagenEspera('AVLAB')" OnClick="rbtnBuscarLab_Click"></asp:Button>
                                            <div  id="imgCargandoLab" style="position:absolute; display:none;width:150px;left:67%">
                                                <img  style="top:0%; align-items:center;text-align:center;" src="../Images/aero_light.gif"  />
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td  style="padding: 5px;">
                                            <asp:Label ID="Label11" runat="server" Text="Elementos por página"></asp:Label>
                                            <br/>
                                            <telerik:RadComboBox RenderMode="Lightweight" AllowCustomText="False" ID="rcbitemsxPagLab" AutoPostBack ="false" runat="server"  Width="100px">
                                                    <Items>
                                                        <telerik:RadComboBoxItem Text="Todos" Value="0" Selected="true"/>
                                                        <telerik:RadComboBoxItem Text="5" Value="5"/>
                                                        <telerik:RadComboBoxItem Text="10" Value="10" />
                                                        <telerik:RadComboBoxItem Text="20" Value="20" />
                                                    </Items>
                                            </telerik:RadComboBox>
                                        </td>
                                    </tr>
                                </table>
                            </telerik:RadPageView>
                        </telerik:RadMultiPage>
                    </div>
                </asp:Panel>
                </div>
            </ContentTemplate>
            </asp:UpdatePanel>

            <!--Dimensiones Iniciales botón de exportar y grids para cada promoción-->
            <div ID="divExportar" style="position:absolute;overflow:hidden;top:45%; height:40px; width:1175px;text-align:right;display:none;">
            <asp:ImageButton ID="rbtnExportarExcel" alternateText="Xlsx" ImageUrl="../Imagenes_Benavides/botones/Excel.png" Height="35" Width="35" runat="server" OnClick="rbtnExportarExcel_Click" ToolTip="Exportar a Excel"/>
            </div>
           
            <asp:UpdatePanel runat="server" ID="UpDatos">
                    <ContentTemplate>
                        <br/>
                        <div style="float:right"></div>
                        <br/>
                        <div ID="divDatos" style="position:absolute;overflow:auto;top:52%; height:300px; width:1200px;">
                            <telerik:RadGrid ID="grvDatos"  runat="server"  AllowPaging="True" AllowSorting="True" CellSpacing="-1" CellPadding="-1" Culture="es-MX" GroupPanelPosition="Top" OnPageIndexChanged="grvDatos_PageIndexChanged"    OnSortCommand="grvDatos_SortCommand" Skin="Bootstrap" GridLines="Both" Visible="false">
                            <GroupingSettings CollapseAllTooltip="Collapse all groups" />
                            <MasterTableView NoMasterRecordsText="No se encontro información"
                                AllowMultiColumnSorting="true">
                                <RowIndicatorColumn Visible="False">
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn Created="True">
                                    <HeaderStyle Width="1000px" />
                                </ExpandCollapseColumn>
                                <PagerStyle PageSizeControlType="None"/>
                            </MasterTableView>
                                <SortingSettings SortedBackColor="#FFF6D6" EnableSkinSortStyles="false"></SortingSettings>
                        <HeaderStyle Width="100px"></HeaderStyle>
                            <PagerStyle FirstPageToolTip="Primera Página" GoToPageButtonToolTip="Ir a página" LastPageToolTip="Última página" NextPagesToolTip="Siguientes páginas" NextPageToolTip="Siguiente página" PagerTextFormat="Cambiar página: {4} &amp;nbsp;página &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;, registro &lt;strong&gt;{2}&lt;/strong&gt; a &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeControlType="None" PrevPagesToolTip="Páginas anteriores" PrevPageToolTip="Página anterior" />
                        </telerik:RadGrid>
                        </div>
                        <div ID="divDatosCupon" style="position:absolute;overflow:auto;top:52%; height:300px; width:1200px;visibility:hidden;">
                            <telerik:RadGrid ID="grvDatosCupon"  runat="server" AutoGenerateColumns="true" AllowPaging="True" AllowSorting="True" CellSpacing="-1" CellPadding="-1"  Culture="es-MX" GroupPanelPosition="Top" OnPageIndexChanged="grvDatosCupon_PageIndexChanged"    OnSortCommand="grvDatosCupon_SortCommand" Skin="Bootstrap" GridLines="Both">
                            <GroupingSettings CollapseAllTooltip="Collapse all groups" />
                            <MasterTableView NoMasterRecordsText="No se encontro información"
                                AllowMultiColumnSorting="true">
                                <RowIndicatorColumn Visible="False">
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn Created="True">
                                    <HeaderStyle Width="41px" />
                                </ExpandCollapseColumn>
                                <PagerStyle PageSizeControlType="None"/>
                            </MasterTableView>
                                <SortingSettings SortedBackColor="#FFF6D6" EnableSkinSortStyles="false"></SortingSettings>
                        <HeaderStyle Width="100px"></HeaderStyle>
                            <PagerStyle FirstPageToolTip="Primera Página" GoToPageButtonToolTip="Ir a página" LastPageToolTip="Última página" NextPagesToolTip="Siguientes páginas" NextPageToolTip="Siguiente página" PagerTextFormat="Cambiar página: {4} &amp;nbsp;página &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;, registro &lt;strong&gt;{2}&lt;/strong&gt; a &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeControlType="None" PrevPagesToolTip="Páginas anteriores" PrevPageToolTip="Página anterior" />
                        </telerik:RadGrid>
                        </div>
                        <div ID="divDatosImagenes" style="position:absolute;overflow:auto;top:52%; height:300px; width:1200px;visibility:hidden;">
                             <telerik:RadGrid ID="grvImagenes"  runat="server"  AllowPaging="True" AllowSorting="True" CellSpacing="-1" CellPadding="-1"  Culture="es-MX" GroupPanelPosition="Top" OnPageIndexChanged="grvImagenes_PageIndexChanged"    OnSortCommand="grvImagenes_SortCommand" Skin="Bootstrap" GridLines="Both">
                            <GroupingSettings CollapseAllTooltip="Collapse all groups" />
                            <MasterTableView NoMasterRecordsText="No se encontro información"
                                AllowMultiColumnSorting="true">
                                <RowIndicatorColumn Visible="False">
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn Created="True">
                                    <HeaderStyle Width="41px" />
                                </ExpandCollapseColumn>
                                <PagerStyle PageSizeControlType="None"/>
                            </MasterTableView>
                                <SortingSettings SortedBackColor="#FFF6D6" EnableSkinSortStyles="false"></SortingSettings>
                        <HeaderStyle Width="100px"></HeaderStyle>
                            <PagerStyle FirstPageToolTip="Primera Página" GoToPageButtonToolTip="Ir a página" LastPageToolTip="Última página" NextPagesToolTip="Siguientes páginas" NextPageToolTip="Siguiente página" PagerTextFormat="Cambiar página: {4} &amp;nbsp;página &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;, registro &lt;strong&gt;{2}&lt;/strong&gt; a &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeControlType="None" PrevPagesToolTip="Páginas anteriores" PrevPageToolTip="Página anterior" />
                        </telerik:RadGrid>
                        </div>
                    </ContentTemplate>
             </asp:UpdatePanel>
             <!--FIN Dimensiones Iniciales-->
        </div>       

            <!--Exporta todas las promociones-->
            <asp:UpdatePanel runat="server" ID="UpExpAllProm">
                    <ContentTemplate>
                        <!--Botón exporta todas las promociones-->
                        <div ID="divExpAllProm" style="position:absolute;top:16%; height:40px; width:1175px;text-align:left;display:none;">
                            <asp:ImageButton ID="imgbtnExpAllExcel" ImageUrl="../Imagenes_Benavides/botones/Excel.png" Height="35" Width="35" runat="server"  OnClick="imgbtnExpAllExcel_Click" ToolTip="Exportar a Excel_test"/>
                        </div>
                    </ContentTemplate>
             </asp:UpdatePanel>
             
            <!--Botón exportar Vencimientos-->
            <div ID="divExpAllVenc" style="position:absolute;overflow:auto;top:14%; height:40px; width:1175px;text-align:left;display:none;">
                <asp:ImageButton ID="imgbtnExpVenc" ImageUrl="../Imagenes_Benavides/botones/Excel.png" Height="35" Width="35" runat="server"  OnClick="imgbtnExpVenc_Click" ToolTip="Exportar a Excel"/>
            </div>  

            <!--Exporta todas las promociones de laboratorio-->
            <asp:UpdatePanel runat="server" ID="UpExpAllLab">
            <ContentTemplate>
                <div ID="divExpAllLab" style="position:absolute;overflow:none;top:16%; height:40px; width:1175px;text-align:left;display:none;">
                <asp:ImageButton ID="imgbtnExpLab" ImageUrl="../Imagenes_Benavides/botones/Excel.png" Height="35" Width="35" runat="server"  OnClick="imgbtnExpLab_Click" ToolTip="Exportar a Excel"/>
            </div>  
             </ContentTemplate>
            </asp:UpdatePanel>
            
            
                    <div ID="divOpcionesExportExcel" style="position: absolute;background-color:transparent;opacity:0.8; width: 250px; height: 200px; top: 30%; left: 85px; font-family:Verdana, Arial, Helvetica, sans-serif; font-size: 12px; font-weight: normal; border:medium; margin-right: 0px;z-index:1; display:none;">
                            <br /> <br /> <br /> <br /> <br /> <br /> <br />
                            <!--Opciones de exportación de las dif promociones-->
                        <div id="divOpc" style="position:absolute; top:30%;background-color:lightgray;left:480px; height:180px; width:245px;text-align:center;" class="gradient" >
                        <br />    
                        <asp:Table ID="tblOpciones" HorizontalAlign="Center" Width="245px" runat="server">
                                <asp:TableRow >
                                    <asp:TableCell ColumnSpan="2" >
                                        <asp:RadioButton ID="rdbPG" runat="server" Font-Size="14px" Text="Piezas Gratis" GroupName="ExportaExcel" />
                                    </asp:TableCell>
                                </asp:TableRow>
                                 <asp:TableRow>
                                     <asp:TableCell ColumnSpan="2">
                                        <asp:RadioButton ID="rdbAcumDE" runat="server" Font-Size="14px" Text ="Acumulación DE" GroupName="ExportaExcel" />
                                    </asp:TableCell>
                                 </asp:TableRow>
                                 <asp:TableRow>
                                     <asp:TableCell ColumnSpan="2">
                                        <asp:RadioButton ID="rdbDE" runat="server" Font-Size="14px" Text ="Dinero Electrónico" GroupName="ExportaExcel" />
                                    </asp:TableCell>
                                 </asp:TableRow>
                                <asp:TableRow>
                                     <asp:TableCell ColumnSpan="2">
                                        <asp:RadioButton ID="rdbMixMatch" runat="server" Font-Size="14px" Text ="Mix & Match" GroupName="ExportaExcel" />
                                    </asp:TableCell>
                                 </asp:TableRow>
                                 <asp:TableRow>
                                     <asp:TableCell Height="20px"></asp:TableCell>
                                 </asp:TableRow>
                                 <asp:TableRow>
                                     <asp:TableCell>
                                         <asp:Button ID="rbtnExportar" runat="server" CssClass="inputexp" Font-Size="14px" Text="Exportar" OnClick="rbtnExportar_Click" Width="75px"></asp:Button>
                                     </asp:TableCell>
                                     <asp:TableCell>
                                         <asp:UpdatePanel runat="server" ID="UpCerrarOpciones">
                                        <ContentTemplate>
                                            <asp:Button ID="rbtnCerrar" runat="server" CssClass="inputexp" Text="Cerrar" OnClick="rbtnCerrar_Click" Width="75px"></asp:Button>
                                        </ContentTemplate>
                                        </asp:UpdatePanel>
                                     </asp:TableCell>
                                 </asp:TableRow>
                            </asp:Table>
                    </div>
                    </div>

                    <div id="divAllPromociones" style="position: absolute;background-color:lightgray; width: 1200px; height: 390px; top: 0%; left: 85px; font-family:Verdana, Arial, Helvetica, sans-serif; font-size: 12px; font-weight: normal; border:medium; background-color: #FAFAFA; color: #000000; overflow:auto; display:none; margin-right: 0px;">
                        <div id="divCerrar" style="position:relative;border:none;top:0%; height:25px; width:1175px;text-align:right; ">
                            <asp:UpdatePanel ID="upCerrarAllPromociones" runat="server">
                                <ContentTemplate>
                                    <asp:ImageButton ID="imgbtnCerrar" ImageUrl="../Imagenes_Benavides/botones/cerrar-btn.jpg" OnClick="imgbtnCerrar_Click" ToolTip="Cerrar"  height="20" width="20" runat="server" />
                                </ContentTemplate>
                            </asp:UpdatePanel>    
                        </div>
                        <%--<div ID="divOpcionesExportExcel" style="position:absolute; top:140%;background-color:lightgray;left:530px; height:180px; width:245px;text-align:center;display:none;z-index:1;" class="gradient" >--%>
                        <asp:UpdatePanel runat="server" ID="UpGridsDatProducto">
                                                <ContentTemplate>
                                                    <div style="float:right"></div>
                                                    <br />
                                                    <b>Piezas Gratis</b>
                                                    <div ID="divDatPzasGratis" style="overflow:auto;background-color:lightgray; height:300px; width:1175px;">
                                                            <telerik:RadGrid ID="grvPzasGratis"  runat="server"  AllowPaging="True" AllowSorting="True" CellSpacing="-1" CellPadding="-1" Culture="es-MX" GroupPanelPosition="Top" OnPageIndexChanged="grvPzasGratis_PageIndexChanged"    OnSortCommand="grvPzasGratis_SortCommand" Skin="Bootstrap" GridLines="Both">
                                                            <GroupingSettings CollapseAllTooltip="Collapse all groups" />
                                                            <MasterTableView NoMasterRecordsText="No se encontro información"
                                                                AllowMultiColumnSorting="true">
                                                                <RowIndicatorColumn Visible="False">
                                                                </RowIndicatorColumn>
                                                                <ExpandCollapseColumn Created="True">
                                                                    <HeaderStyle Width="1000px" />
                                                                </ExpandCollapseColumn>
                                                                <PagerStyle PageSizeControlType="None"/>
                                                            </MasterTableView>
                                                                <SortingSettings SortedBackColor="#FFF6D6" EnableSkinSortStyles="false"></SortingSettings>
                                                            <HeaderStyle Width="100px"></HeaderStyle>
                                                            <PagerStyle FirstPageToolTip="Primera Página" GoToPageButtonToolTip="Ir a página" LastPageToolTip="Última página" NextPagesToolTip="Siguientes páginas" NextPageToolTip="Siguiente página" PagerTextFormat="Cambiar página: {4} &amp;nbsp;página &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;, registro &lt;strong&gt;{2}&lt;/strong&gt; a &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeControlType="None" PrevPagesToolTip="Páginas anteriores" PrevPageToolTip="Página anterior" />
                                                            </telerik:RadGrid>
                                                    </div>
                                                    <br />
                                                    <b>Acumulación DE</b>
                                                    <div ID="divDatAcumDE" style="overflow:auto; height:300px; width:1175px;">
                                                            <telerik:RadGrid ID="grvAcumDE"  runat="server"  AllowPaging="True" AllowSorting="True" CellSpacing="-1" CellPadding="-1" Culture="es-MX" GroupPanelPosition="Top" OnPageIndexChanged="grvAcumDE_PageIndexChanged"    OnSortCommand="grvAcumDE_SortCommand" Skin="Bootstrap" GridLines="Both">
                                                        <GroupingSettings CollapseAllTooltip="Collapse all groups" />
                                                        <MasterTableView NoMasterRecordsText="No se encontro información"
                                                            AllowMultiColumnSorting="true">
                                                            <RowIndicatorColumn Visible="False">
                                                            </RowIndicatorColumn>
                                                            <ExpandCollapseColumn Created="True">
                                                                <HeaderStyle Width="1000px" />
                                                            </ExpandCollapseColumn>
                                                            <PagerStyle PageSizeControlType="None"/>
                                                        </MasterTableView>
                                                            <SortingSettings SortedBackColor="#FFF6D6" EnableSkinSortStyles="false"></SortingSettings>
                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                        <PagerStyle FirstPageToolTip="Primera Página" GoToPageButtonToolTip="Ir a página" LastPageToolTip="Última página" NextPagesToolTip="Siguientes páginas" NextPageToolTip="Siguiente página" PagerTextFormat="Cambiar página: {4} &amp;nbsp;página &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;, registro &lt;strong&gt;{2}&lt;/strong&gt; a &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeControlType="None" PrevPagesToolTip="Páginas anteriores" PrevPageToolTip="Página anterior" />
                                                        </telerik:RadGrid>
                                                    </div>
                                                    <br />
                                                    <b>Dinero Electrónico</b>
                                                    <div ID="divDatDE" style="overflow:auto; height:300px; width:1175px;">
                                                            <telerik:RadGrid ID="grvDE"  runat="server"  AllowPaging="True" AllowSorting="True" CellSpacing="-1" CellPadding="-1" Culture="es-MX" GroupPanelPosition="Top" OnPageIndexChanged="grvDE_PageIndexChanged"    OnSortCommand="grvDE_SortCommand" Skin="Bootstrap" GridLines="Both">
                                                        <GroupingSettings CollapseAllTooltip="Collapse all groups" />
                                                        <MasterTableView NoMasterRecordsText="No se encontro información"
                                                            AllowMultiColumnSorting="true">
                                                            <RowIndicatorColumn Visible="False">
                                                            </RowIndicatorColumn>
                                                            <ExpandCollapseColumn Created="True">
                                                                <HeaderStyle Width="1000px" />
                                                            </ExpandCollapseColumn>
                                                            <PagerStyle PageSizeControlType="None"/>
                                                        </MasterTableView>
                                                            <SortingSettings SortedBackColor="#FFF6D6" EnableSkinSortStyles="false"></SortingSettings>
                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                        <PagerStyle FirstPageToolTip="Primera Página" GoToPageButtonToolTip="Ir a página" LastPageToolTip="Última página" NextPagesToolTip="Siguientes páginas" NextPageToolTip="Siguiente página" PagerTextFormat="Cambiar página: {4} &amp;nbsp;página &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;, registro &lt;strong&gt;{2}&lt;/strong&gt; a &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeControlType="None" PrevPagesToolTip="Páginas anteriores" PrevPageToolTip="Página anterior" />
                                                        </telerik:RadGrid>
                                                    </div>
                                                    <br />
                                                    <b>Mix & Match</b>
                                                    <div ID="divDatMixMatch" style="overflow:auto; height:300px; width:1175px;">
                                                            <telerik:RadGrid ID="grvMixMatch"  runat="server"  AllowPaging="True" AllowSorting="True" CellSpacing="-1" CellPadding="-1" Culture="es-MX" GroupPanelPosition="Top" OnPageIndexChanged="grvMixMatch_PageIndexChanged"    OnSortCommand="grvMixMatch_SortCommand" Skin="Bootstrap" GridLines="Both">
                                                        <GroupingSettings CollapseAllTooltip="Collapse all groups" />
                                                        <MasterTableView NoMasterRecordsText="No se encontro información"
                                                            AllowMultiColumnSorting="true">
                                                            <RowIndicatorColumn Visible="False">
                                                            </RowIndicatorColumn>
                                                            <ExpandCollapseColumn Created="True">
                                                                <HeaderStyle Width="1000px" />
                                                            </ExpandCollapseColumn>
                                                            <PagerStyle PageSizeControlType="None"/>
                                                        </MasterTableView>
                                                            <SortingSettings SortedBackColor="#FFF6D6" EnableSkinSortStyles="false"></SortingSettings>
                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                        <PagerStyle FirstPageToolTip="Primera Página" GoToPageButtonToolTip="Ir a página" LastPageToolTip="Última página" NextPagesToolTip="Siguientes páginas" NextPageToolTip="Siguiente página" PagerTextFormat="Cambiar página: {4} &amp;nbsp;página &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;, registro &lt;strong&gt;{2}&lt;/strong&gt; a &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeControlType="None" PrevPagesToolTip="Páginas anteriores" PrevPageToolTip="Página anterior" />
                                                        </telerik:RadGrid>
                                                    </div>
                                                </ContentTemplate>
                                                </asp:UpdatePanel>
                    </div>
    
                     <div ID="divOpcionesLabExportExcel" style="position: absolute;background-color:transparent;opacity:0.8; width: 250px; height: 200px; top: 28%; left: 270px; font-family:Verdana, Arial, Helvetica, sans-serif; font-size: 12px; font-weight: normal; border:medium;z-index:1; display:none;">
                            <div id="divOpcLab" style="position:absolute; top:28%;background-color:lightgray;left:270px; height:180px; width:245px;text-align:center;" class="gradient" >
                                <br /><br />
                                <asp:Table ID="tblOpcionesLabExportExcel" HorizontalAlign="Center" Width="245px" runat="server">
                                <asp:TableRow>
                                <asp:TableCell ColumnSpan="2">
                                    <asp:RadioButton ID="rdbtnPGLab" runat="server" Font-Size="14px"  Text="Piezas Gratis" GroupName="LabExportaExcel" />
                                </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                <asp:TableCell ColumnSpan="2">
                                    <asp:RadioButton ID="rdbtnACDELab" runat="server" Font-Size="14px"  Text ="Acumulación DE" GroupName="LabExportaExcel" />
                                </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                <asp:TableCell ColumnSpan="2">
                                    <asp:RadioButton ID="rdbtnMixMatchLab" runat="server" Font-Size="14px"  Text ="Mix & Match" GroupName="LabExportaExcel" />
                                </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                </asp:TableRow>
                                <asp:TableRow>
                                <asp:TableCell Height="10px"></asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Button ID="btnExpOpcLab" runat="server" CssClass="inputexp" Text="Exportar" OnClick="btnExpOpcLab_Click" Width="75px"></asp:Button>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                                    <ContentTemplate>
                                        <asp:Button ID="btnCerrarOpcLab" runat="server" CssClass="inputexp" Text="Cerrar" OnClick="btnCerrarOpcLab_Click" Width="75px"></asp:Button>
                                    </ContentTemplate>
                                    </asp:UpdatePanel>
                                </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                            </div>
                    </div>
                    <div id="divVencimiento" style="position: absolute;background-color:lightgray; width: 1200px; height: 390px; top: 0%; left: 0; font-family:Verdana, Arial, Helvetica, sans-serif; font-size: 12px; font-weight: normal; border:medium; background-color: #FAFAFA; color: #000000; overflow:auto; display:none; margin-right: 0px;">
                            <div id="divCerrarVencimientos" style="position:relative;border:none;top:0%; height:25px; width:1175px;text-align:right; margin-right: 0px; margin-top:0;">
                              <asp:ImageButton ID="imbtnCerrarVenc" ImageUrl="../Imagenes_Benavides/botones/cerrar-btn.jpg" OnClick="imbtnCerrarVenc_Click" ToolTip="Cerrar"  height="20" width="20" runat="server" />
                         </div>
                            <asp:UpdatePanel runat="server"  ID="UpGridsDatVencimiento">
                            <ContentTemplate>
                            <div style="float:right"></div>
                            <br/>
                            <asp:Label ID="lblTituloPromocionVenc" runat="server" Text="Piezas Gratis"></asp:Label>
                                <div ID="divDatVarios" style="overflow:auto;background-color:lightgray; height:300px; width:1175px;">
                                    <telerik:RadGrid ID="grvVariosVenc"  runat="server"  AllowPaging="True" AllowSorting="True" CellSpacing="-1" CellPadding="-1" Culture="es-MX" GroupPanelPosition="Top" OnPageIndexChanged="grvVariosVenc_PageIndexChanged"  ActiveItemStyle-VerticalAlign="Top"  OnSortCommand="grvVariosVenc_SortCommand" Skin="Bootstrap" GridLines="Both">
                                    <GroupingSettings CollapseAllTooltip="Collapse all groups" />
                                    <MasterTableView NoMasterRecordsText="No se encontro información"
                                        AllowMultiColumnSorting="true">
                                        <RowIndicatorColumn Visible="False">
                                        </RowIndicatorColumn>
                                        <ExpandCollapseColumn Created="True">
                                            <HeaderStyle Width="1000px" />
                                        </ExpandCollapseColumn>
                                        <PagerStyle PageSizeControlType="None"/>
                                    </MasterTableView>
                                        <SortingSettings SortedBackColor="#FFF6D6" EnableSkinSortStyles="false"></SortingSettings>
                                    <HeaderStyle Width="100px"></HeaderStyle>
                                    <PagerStyle FirstPageToolTip="Primera Página" GoToPageButtonToolTip="Ir a página" LastPageToolTip="Última página" NextPagesToolTip="Siguientes páginas" NextPageToolTip="Siguiente página" PagerTextFormat="Cambiar página: {4} &amp;nbsp;página &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;, registro &lt;strong&gt;{2}&lt;/strong&gt; a &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeControlType="None" PrevPagesToolTip="Páginas anteriores" PrevPageToolTip="Página anterior" />
                                    </telerik:RadGrid>
                                </div>
                            <br />
                                <div ID="divDatCuponVenc" style="position:absolute;border:none;top:15%;overflow:auto; height:300px; width:1175px;">
                                <asp:Label ID="lbldivDatCuponVenc" runat="server" Text=""></asp:Label>
                                    <telerik:RadGrid ID="grvCuponVenc"  runat="server"  AllowPaging="True" AllowSorting="True" CellSpacing="-1" CellPadding="-1" Culture="es-MX" GroupPanelPosition="Top" OnPageIndexChanged="grvCuponVenc_PageIndexChanged" OnSortCommand="grvCuponVenc_SortCommand" Skin="Bootstrap" GridLines="Both">
                                    <GroupingSettings CollapseAllTooltip="Collapse all groups" />
                                    <MasterTableView NoMasterRecordsText="No se encontro información"
                                        AllowMultiColumnSorting="true">
                                        <RowIndicatorColumn Visible="False">
                                        </RowIndicatorColumn>
                                        <ExpandCollapseColumn Created="True">
                                            <HeaderStyle Width="1000px" />
                                        </ExpandCollapseColumn>
                                        <PagerStyle PageSizeControlType="None"/>
                                    </MasterTableView>
                                        <SortingSettings SortedBackColor="#FFF6D6" EnableSkinSortStyles="false"></SortingSettings>
                                    <HeaderStyle Width="100px"></HeaderStyle>
                                    <PagerStyle FirstPageToolTip="Primera Página" GoToPageButtonToolTip="Ir a página" LastPageToolTip="Última página" NextPagesToolTip="Siguientes páginas" NextPageToolTip="Siguiente página" PagerTextFormat="Cambiar página: {4} &amp;nbsp;página &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;, registro &lt;strong&gt;{2}&lt;/strong&gt; a &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeControlType="None" PrevPagesToolTip="Páginas anteriores" PrevPageToolTip="Página anterior" />
                                    </telerik:RadGrid>

                                    <telerik:RadGrid ID="grvAcDELab"  runat="server" Visible ="false"  AllowPaging="True" AllowSorting="True" CellSpacing="-1" CellPadding="-1" Culture="es-MX" GroupPanelPosition="Top" OnPageIndexChanged="grvAcDELab_PageIndexChanged" OnSortCommand="grvAcDELab_SortCommand" Skin="Bootstrap" GridLines="Both">
                                    <GroupingSettings CollapseAllTooltip="Collapse all groups" />
                                    <MasterTableView NoMasterRecordsText="No se encontro información"
                                        AllowMultiColumnSorting="true">
                                        <RowIndicatorColumn Visible="False">
                                        </RowIndicatorColumn>
                                        <ExpandCollapseColumn Created="True">
                                            <HeaderStyle Width="1000px" />
                                        </ExpandCollapseColumn>
                                        <PagerStyle PageSizeControlType="None"/>
                                    </MasterTableView>
                                        <SortingSettings SortedBackColor="#FFF6D6" EnableSkinSortStyles="false"></SortingSettings>
                                    <HeaderStyle Width="100px"></HeaderStyle>
                                    <PagerStyle FirstPageToolTip="Primera Página" GoToPageButtonToolTip="Ir a página" LastPageToolTip="Última página" NextPagesToolTip="Siguientes páginas" NextPageToolTip="Siguiente página" PagerTextFormat="Cambiar página: {4} &amp;nbsp;página &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;, registro &lt;strong&gt;{2}&lt;/strong&gt; a &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeControlType="None" PrevPagesToolTip="Páginas anteriores" PrevPageToolTip="Página anterior" />
                                    </telerik:RadGrid>
                                </div>
                          <br />
                                    <asp:Label ID="lbldivDatMixMatchVenc" runat="server" Text=""></asp:Label>
                                    <div ID="divDatMixMatchVenc" style="position:absolute;border:none;top:187%;overflow:auto; height:300px; width:1175px;">
                                        <telerik:RadGrid ID="grvMixMatchLab"  runat="server" Visible="false" AllowPaging="True" AllowSorting="True" CellSpacing="-1" CellPadding="-1" Culture="es-MX"  OnPageIndexChanged="grvMixMatchLab_PageIndexChanged" OnSortCommand="grvMixMatchLab_SortCommand" Skin="Bootstrap" GridLines="Both">
                                        <GroupingSettings CollapseAllTooltip="Collapse all groups" />
                                        <MasterTableView NoMasterRecordsText="No se encontro información"
                                            AllowMultiColumnSorting="true">
                                            <RowIndicatorColumn Visible="False">
                                            </RowIndicatorColumn>
                                            <ExpandCollapseColumn Created="True">
                                                <HeaderStyle Width="1000px" />
                                            </ExpandCollapseColumn>
                                            <PagerStyle PageSizeControlType="None"/>
                                        </MasterTableView>
                                            <SortingSettings SortedBackColor="#FFF6D6" EnableSkinSortStyles="false"></SortingSettings>
                                        <HeaderStyle Width="100px"></HeaderStyle>
                                        <PagerStyle FirstPageToolTip="Primera Página" GoToPageButtonToolTip="Ir a página" LastPageToolTip="Última página" NextPagesToolTip="Siguientes páginas" NextPageToolTip="Siguiente página" PagerTextFormat="Cambiar página: {4} &amp;nbsp;página &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;, registro &lt;strong&gt;{2}&lt;/strong&gt; a &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeControlType="None" PrevPagesToolTip="Páginas anteriores" PrevPageToolTip="Página anterior" />
                                        </telerik:RadGrid>
                                    </div>
                       </ContentTemplate>
                       </asp:UpdatePanel>
                    </div>

     <asp:Panel ID="pnlImagen" runat="server">
            <asp:Image ID="imgPop" runat="server" />
     </asp:Panel>
    <asp:HiddenField ID="hdnPopUp" runat="server" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="pnlImagen" BackgroundCssClass="BackGround" TargetControlID="hdnPopUp"></ajaxToolkit:ModalPopupExtender>
</asp:Content>
