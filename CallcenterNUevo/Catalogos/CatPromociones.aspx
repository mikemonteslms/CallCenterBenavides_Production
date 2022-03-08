<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CatPromociones.aspx.cs" Inherits="CallcenterNUevo.Cat.CatPromociones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
         <script type="text/javascript" src="../Scripts/jquery-2.1.0.js"> </script>
     <script type="text/javascript" src="../Scripts/jquery-ui-1.10.4.js"></script>
        <link rel="stylesheet" href="../Content/Site.css"/>
 <link rel="stylesheet" href="../Content/themes/base/jquery.ui.datepicker.css"/>
 <link rel="stylesheet" href="../Content/themes/base/jquery.ui.theme.css"/>
 <link rel="stylesheet" href="../Content/themes/base/jquery.ui.core.css"/>
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
    </style>
        <center>
      <asp:HiddenField runat="server" ID="hdnIdMecanicaNivel" />
     <asp:HiddenField runat="server" ID="hdnNombre" />
     <h1><span class="titulo">Consulta Promociones</span></h1><br />
    <table class="fuenteReporte" style="text-align:left" >
        <tr style="border-bottom:2px solid black;">
            <td>
               
            </td>
            <td colspan="3" >
                <h2>
                    <asp:Label Text="" runat="server" ID="lblCategoriaMecanica" Visible="false" />
                </h2>                
            </td>
            <td colspan="1" style="text-align:right;">
                  <asp:Button Text="Nuevo" runat="server" ID="btnNueva" OnClick="btnNueva_Click" Visible="false" />
                <asp:Button Text="Cancelar" runat="server" ID="btnCancelar" style="display:none;" OnClick="btnCancelar_Click" Visible="false" /> 
            </td>
        </tr>
        <tr>
            <td style="border-top:2px solid black; padding-top: 30px;" colspan="5"></td>
        </tr>
        <tr>
            <td>Tarjeta
            </td>
            <td>
                <asp:TextBox ID="txtTarjeta" runat="server" AutoPostBack="True" OnTextChanged="txtTarjeta_TextChanged"></asp:TextBox>
            </td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td>Club
            </td>
            <td>
                <asp:DropDownList runat="server" ID="cboClub">
                </asp:DropDownList>
            </td>
            <td></td>
            <td>Nivel
            </td>
            <td>
                <asp:CheckBoxList runat="server" ID="chkNivel" RepeatDirection="Horizontal"></asp:CheckBoxList>
            </td>
        </tr>
        <tr>
            <td>Edad Inicial:
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtEdadIni" CssClass="numeric" />
            </td>
            <td></td>
            <td>Edad Final:
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtEdadFin" CssClass="numeric"  />
            </td>
        </tr>
        <tr style="display:none">
            <td>Beneficio Inicial:
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtBeneficioIni" CssClass="numeric"  />
            </td>
            <td></td>
            <td>Beneficio Final:
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtBeneficioFin" CssClass="numeric"  />
            </td>
        </tr>
        <tr style="display:none;">
            <td>Compra Inicial:
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtCompraIni" CssClass="numeric"  />
            </td>
            <td></td>
            <td>Compra Final:
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtCompraFin" CssClass="numeric"  />
            </td>
        </tr>
        <tr>
            <td>Fecha Inicial:
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtFechaIni" CssClass="dtPicker" />
            </td>
            <td></td>
            <td>Fecha Final:
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtFechaFin" CssClass="dtPicker" />
            </td>
        </tr>
        <tr>
            <td>Periodo:
            </td>
            <td>
                <asp:DropDownList runat="server" ID="cboPeriodo">
                </asp:DropDownList>
            </td>
            <td></td>
            <td>Límite:
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtLimite" CssClass="numeric"  />
            </td>
        </tr>
        <tr>
            <td>Nombre:
            </td>
            <td colspan="4">
                <asp:TextBox runat="server" ID="txtNombre" />
            </td>
        </tr>
        <tr>
            <td>Descripción:
            </td>
            <td colspan="4">
                <asp:TextBox runat="server" ID="txtDescripcion" />
            </td>
        </tr>
        <tr>
            <td>Estatus:
            </td>
            <td>
                <asp:DropDownList runat="server" ID="cboEstatus">
                </asp:DropDownList>
            </td>
            <td></td>
            <td></td>
            <td style="text-align: right">
              
            </td>
        </tr>

        <tr>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td style="text-align: right">
              
                <asp:Button Text="Consultar" runat="server" ID="btnConsultar" OnClick="btnConsultar_Click" />
              
            </td>
        </tr>

    </table><br /><br />
    <div style="width: 100%;">
        <table class="Grid" style="width:100%">
            <asp:Repeater runat="server" ID="rptConsulta">
                <HeaderTemplate>
                    <tr style="background: #2B347A 0 -2300px repeat-x !important; color: #fff !important; font-size: 12pt !important;">   
                            <th style="display:none">Accion</th>                    
                            <th>Club</th>
                            <th>Nombre</th>
                            <th>Descripción</th>
                            <th>Nivel</th>
                            <th>Edad Inicial</th>
                            <th>Edad Final</th>
                            <th>Beneficio Inicial</th>
                            <th>Beneficio Final</th>
                            <th>Fecha Inicial</th>
                            <th>Fecha Final</th>
                            <th>Periodo</th>
                            <th>Limite</th>
                            <th>Status</th>  
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="fuenteReporte" style="border:1px solid #eae7e7">
                        <td style="display:none">
                          <%--  <a href="Detalle.aspx?Id=<%# DataBinder.Eval(Container.DataItem, "Id_MecanicaConfiguracion") %>&Nv=<%# DataBinder.Eval(Container.DataItem, "Id_Nivel") %>">Detalle</a>
                             <% if (((Entidades.MecanicaConfiguracionConsulta)Session["Mecanica"]).id_categoriaMecanica == 1 )
                                { %>
                            <a href="EdicionNM.aspx?Id=<%# DataBinder.Eval(Container.DataItem, "Id_MecanicaConfiguracion") %>&Nv=<%# DataBinder.Eval(Container.DataItem, "Id_Nivel") %>">Editar</a>
                            <% } else {%>
                            <a href="EdicionLista.aspx?Id=<%# DataBinder.Eval(Container.DataItem, "Id_MecanicaConfiguracion") %>&Nv=<%# DataBinder.Eval(Container.DataItem, "Id_Nivel") %>">Editar</a>
                            <% }%>
                           <a href="CancelarPromocion.aspx?Id=<%# DataBinder.Eval(Container.DataItem, "Id_MecanicaConfiguracion") %>&Nv=<%# DataBinder.Eval(Container.DataItem, "Id_Nivel") %>" onclick="return confirm('La mecánica será cancelada. Esta seguro?')">Cancelar</a> 
                             <a href="#" onclick="Cancela(<%# DataBinder.Eval(Container.DataItem, "Id_MecanicaConfiguracion") %>,'<%# DataBinder.Eval(Container.DataItem, "Nombre") %>');return false;">Cancelar</a>  
                            <a href="Copiar.aspx?Id=<%# DataBinder.Eval(Container.DataItem, "Id_MecanicaConfiguracion") %>&Nv=<%# DataBinder.Eval(Container.DataItem, "Id_Nivel") %>">Copiar</a>                                              
                            <input type="hidden" class="Id" value="<%# DataBinder.Eval(Container.DataItem, "Id_MecanicaConfiguracion") %>" /> --%>
                        </td>
                        <td>
                            <%# DataBinder.Eval(Container.DataItem, "DescClub") %>
                        </td>
                        <td>
                            <%# DataBinder.Eval(Container.DataItem, "Nombre") %>
                        </td>
                        <td>
                            <%# DataBinder.Eval(Container.DataItem, "Descripcion") %>
                        </td>
                        <td>
                            <%# DataBinder.Eval(Container.DataItem, "DescNivel") %>
                        </td>
                        <td>
                            <%# DataBinder.Eval(Container.DataItem, "EdadIni") %>
                        </td>
                        <td>
                            <%# DataBinder.Eval(Container.DataItem, "EdadFin") %>
                        </td>
                        <td>
                            <%# DataBinder.Eval(Container.DataItem, "BeneficioIni") %>
                        </td>
                        <td>
                            <%# DataBinder.Eval(Container.DataItem, "BeneficioFin") %>
                        </td>
                        <td>
                            <%# DataBinder.Eval(Container.DataItem, "FechaIni","{0:dd/MM/yyyy}") %>
                        </td>
                        <td>
                            <%# DataBinder.Eval(Container.DataItem, "FechaFin","{0:dd/MM/yyyy}") %>
                        </td>
                        <td>
                            <%# DataBinder.Eval(Container.DataItem, "Perido") %>
                        </td>
                        <td>
                            <%# DataBinder.Eval(Container.DataItem, "Limite") %>
                        </td>
                        <td>
                            <%# DataBinder.Eval(Container.DataItem, "Status") %>
                        </td>
                        
                    </tr>
                </ItemTemplate>
                 <AlternatingItemTemplate>
                    <tr style="background-color:white; border:1px solid #eae7e7" class="fuenteReporte">
                        <td style="display:none">
                            <a href="Detalle.aspx?Id=<%# DataBinder.Eval(Container.DataItem, "Id_MecanicaConfiguracion") %>&Nv=<%# DataBinder.Eval(Container.DataItem, "Id_Nivel") %>">Detalle</a>
                            <% if (((Entidades.MecanicaConfiguracionConsulta)Session["Mecanica"]).id_categoriaMecanica == 1)
                               { %>
                            <a href="EdicionNM.aspx?Id=<%# DataBinder.Eval(Container.DataItem, "Id_MecanicaConfiguracion") %>&Nv=<%# DataBinder.Eval(Container.DataItem, "Id_Nivel") %>">Editar</a>
                            <% } else {%>
                            <a href="EdicionLista.aspx?Id=<%# DataBinder.Eval(Container.DataItem, "Id_MecanicaConfiguracion") %>&Nv=<%# DataBinder.Eval(Container.DataItem, "Id_Nivel") %>">Editar</a>
                            <% }%>
                            <%--<a href="CancelarPromocion.aspx?Id=<%# DataBinder.Eval(Container.DataItem, "Id_MecanicaConfiguracion") %>&Nv=<%# DataBinder.Eval(Container.DataItem, "Id_Nivel") %>" onclick="return confirm('La mecánica será cancelada. Esta seguro?')">Cancelar</a>--%>  
                             <a href="#" onclick="Cancela(<%# DataBinder.Eval(Container.DataItem, "Id_MecanicaConfiguracion") %>,'<%# DataBinder.Eval(Container.DataItem, "Nombre") %>');return false;">Cancelar</a>  
                            <a href="Copiar.aspx?Id=<%# DataBinder.Eval(Container.DataItem, "Id_MecanicaConfiguracion") %>&Nv=<%# DataBinder.Eval(Container.DataItem, "Id_Nivel") %>">Copiar</a>                  
                            <input type="hidden" class="Id" value="<%# DataBinder.Eval(Container.DataItem, "Id_MecanicaConfiguracion") %>" />
                        </td>
                        <td>
                            <%# DataBinder.Eval(Container.DataItem, "DescClub") %>
                        </td>
                        <td>
                            <%# DataBinder.Eval(Container.DataItem, "Nombre") %>
                        </td>
                        <td>
                            <%# DataBinder.Eval(Container.DataItem, "Descripcion") %>
                        </td>
                        <td>
                            <%# DataBinder.Eval(Container.DataItem, "DescNivel") %>
                        </td>
                        <td>
                            <%# DataBinder.Eval(Container.DataItem, "EdadIni") %>
                        </td>
                        <td>
                            <%# DataBinder.Eval(Container.DataItem, "EdadFin") %>
                        </td>
                        <td>
                            <%# DataBinder.Eval(Container.DataItem, "BeneficioIni") %>
                        </td>
                        <td>
                            <%# DataBinder.Eval(Container.DataItem, "BeneficioFin") %>
                        </td>
                        <td>
                            <%# DataBinder.Eval(Container.DataItem, "FechaIni","{0:dd/MM/yyyy}") %>
                        </td>
                        <td>
                            <%# DataBinder.Eval(Container.DataItem, "FechaFin","{0:dd/MM/yyyy}") %>
                        </td>
                        <td>
                            <%# DataBinder.Eval(Container.DataItem, "Perido") %>
                        </td>
                        <td>
                            <%# DataBinder.Eval(Container.DataItem, "Limite") %>
                        </td>
                        <td>
                            <%# DataBinder.Eval(Container.DataItem, "Status") %>
                        </td>
                        
                    </tr>
                </AlternatingItemTemplate>
            </asp:Repeater>
        </table>
    </div>


    <script>
        $(".dtPicker").datepicker({ dateFormat: 'dd/mm/yy', monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'], dayNames: ['Domingo', 'Lunes', 'Martes', 'Miércoles', 'Jueves', 'Viernes', 'Sábado'], dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mie', 'Jue', 'Vie', 'Sab'], dayNamesMin: ['Dom', 'Lun', 'Mar', 'Mie', 'Jue', 'Vie', 'Sab'] });

        $(function () {
            $(".btnDetalle").button({
                icons: {
                    primary: "ui-icon-circle-zoomout"
                },
                text: false
            });
            $(".btnEditar").button({
                icons: {
                    primary: "ui-icon-pencil"
                },
                text: false
            });
            $(".btnInactivar").button({
                icons: {
                    primary: "ui-icon-circle-arrow-s"
                },
                text: false
            });
        });

        $(document).on("input", ".numeric", function () {
            this.value = this.value.replace(/[^0-9\.]/g, '');
        });

        function MostrarDetalle(IdMecConf) {
            window.location.href = "/Detalle.aspx?Id=" + IdMecConf;
            return false;
        }

        function Cancela(IdMecanica, NombreMecanica) {

            var r = confirm("La mecánica será cancelada. Esta seguro?");

            var IdMN = $("#ctl00_ctl00_ContentPlaceHolder1_body_contenido_hdnIdMecanicaNivel");
            var NM = $("#ctl00_ctl00_ContentPlaceHolder1_body_contenido_hdnNombre");


            IdMN.val(IdMecanica);
            NM.val(NombreMecanica);

            if (r == true) {
                document.getElementById("ctl00_ctl00_ContentPlaceHolder1_body_contenido_btnCancelar").click();
                alert('Mecánica cancelada exitósamente. ');
            } else {
                txt = "You pressed Cancel!";
            }
            return false;
        }
    </script>
</center>
</asp:Content>
