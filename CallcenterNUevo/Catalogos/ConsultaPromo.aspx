<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsultaPromo.aspx.cs" Inherits="CallcenterNUevo.Cat.ConsultaPromo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<center>
          <script type="text/javascript" src="../Scripts/jquery-2.1.0.js"> </script>
     <script type="text/javascript" src="../Scripts/jquery-ui-1.10.4.js"></script>
        <link rel="stylesheet" href="../Content/Site.css"/>
 <link rel="stylesheet" href="../Content/themes/base/jquery.ui.datepicker.css"/>
 <link rel="stylesheet" href="../Content/themes/base/jquery.ui.theme.css"/>
 <link rel="stylesheet" href="../Content/themes/base/jquery.ui.core.css"/>
    <style type="text/css">
       .titulo
        {
            font-family: Arial;
            font-size: 16pt;
            color:#2B347A;
        }
 </style>
      <asp:HiddenField runat="server" ID="hdnIdMecanicaNivel" />
     <asp:HiddenField runat="server" ID="hdnNombre" />

    <table >
        <tr style="border-bottom:2px solid black;">
            <td>
                <h1 class="titulo">Consulta</h1>
            </td>
            <td colspan="3" >
                <h2>
                    <asp:Label Text="" runat="server" ID="lblCategoriaMecanica" CssClass="titulo" />
                </h2>                
            </td>
            <td colspan="1" style="text-align:right;">
                  <asp:Button Text="Nuevo" runat="server" ID="btnNueva" OnClick="btnNueva_Click" />
                <asp:Button Text="Consultar" runat="server" ID="btnConsultar" OnClick="btnConsultar_Click" />
                <asp:Button Text="Cancelar" runat="server" ID="btnCancelar" style="display:none;" OnClick="btnCancelar_Click" /> 
            </td>
        </tr>
        <tr>
            <td style="border-top:2px solid black; padding-top: 30px;" colspan="5"></td>
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
        <tr>
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
        <tr>
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
            <td colspan="4" style="text-align:left;">
                <asp:TextBox runat="server" ID="txtNombre" />
            </td>
        </tr>
        <tr>
            <td>Descripción:
            </td>
            <td colspan="4" style="text-align:left;">
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

    </table>
    <div style="width: 100%; height: 500px; overflow:scroll;">
        <table class="Grid">

            <asp:Repeater runat="server" ID="rptConsulta">
                <HeaderTemplate>
                    <tr style="background-color:#eae7e7; border:1px solid #eae7e7">   
                            <th>Accion</th>                    
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
                    <tr>
                        <td>
                            <a href='../AdminMecanicas/Detalle.aspx?Id=<%# DataBinder.Eval(Container.DataItem, "Id_MecanicaConfiguracion") %>&amp;Nv=<%# DataBinder.Eval(Container.DataItem, "Id_Nivel") %>'>Detalle</a>
                             <% if (((Entidades.MecanicaConfiguracionConsulta)Session["Mecanica"]).id_categoriaMecanica == 1 )
                                { %>
                            <a href='../AdminMecanicas/EdicionNM.aspx?Id=<%# DataBinder.Eval(Container.DataItem, "Id_MecanicaConfiguracion") %>&amp;Nv=<%# DataBinder.Eval(Container.DataItem, "Id_Nivel") %>'>Editar</a>
                            <% } else {%>
                            <a href='../AdminMecanicas/EdicionLista.aspx?Id=<%# DataBinder.Eval(Container.DataItem, "Id_MecanicaConfiguracion") %>&amp;Nv=<%# DataBinder.Eval(Container.DataItem, "Id_Nivel") %>'>Editar</a>
                            <% }%>
                            <%--<a href="CancelarPromocion.aspx?Id=<%# DataBinder.Eval(Container.DataItem, "Id_MecanicaConfiguracion") %>&Nv=<%# DataBinder.Eval(Container.DataItem, "Id_Nivel") %>" onclick="return confirm('La mecánica será cancelada. Esta seguro?')">Cancelar</a>  --%>
                             <a href="#" onclick="Cancela(<%# DataBinder.Eval(Container.DataItem, "Id_MecanicaConfiguracion") %>,'<%# DataBinder.Eval(Container.DataItem, "Nombre") %>');return false;">Cancelar</a>  
                            <a href='../AdminMecanicas/Copiar.aspx?Id=<%# DataBinder.Eval(Container.DataItem, "Id_MecanicaConfiguracion") %>&amp;Nv=<%# DataBinder.Eval(Container.DataItem, "Id_Nivel") %>'>Copiar</a>                                              
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
                </ItemTemplate>
                 <AlternatingItemTemplate>
                    <tr style="background-color:white; border:1px solid #eae7e7">
                        <td>
                            <a href='../AdminMecanicas/Detalle.aspx?Id=<%# DataBinder.Eval(Container.DataItem, "Id_MecanicaConfiguracion") %>&amp;Nv=<%# DataBinder.Eval(Container.DataItem, "Id_Nivel") %>'>Detalle</a>
                            <% if (((Entidades.MecanicaConfiguracionConsulta)Session["Mecanica"]).id_categoriaMecanica == 1){ %>
                            <a href='../AdminMecanicas/EdicionNM.aspx?Id=<%# DataBinder.Eval(Container.DataItem, "Id_MecanicaConfiguracion") %>&amp;Nv=<%# DataBinder.Eval(Container.DataItem, "Id_Nivel") %>'>Editar</a>
                            <% } else {%>
                            <a href='../AdminMecanicas/EdicionLista.aspx?Id=<%# DataBinder.Eval(Container.DataItem, "Id_MecanicaConfiguracion") %>&amp;Nv=<%# DataBinder.Eval(Container.DataItem, "Id_Nivel") %>'>Editar</a>
                            <% }%>
                            <%--<a href="CancelarPromocion.aspx?Id=<%# DataBinder.Eval(Container.DataItem, "Id_MecanicaConfiguracion") %>&Nv=<%# DataBinder.Eval(Container.DataItem, "Id_Nivel") %>" onclick="return confirm('La mecánica será cancelada. Esta seguro?')">Cancelar</a>--%>  
                             <a href="#" onclick="Cancela(<%# DataBinder.Eval(Container.DataItem, "Id_MecanicaConfiguracion") %>,'<%# DataBinder.Eval(Container.DataItem, "Nombre") %>');return false;">Cancelar</a>  
                            <a href='../AdminMecanicas/Copiar.aspx?Id=<%# DataBinder.Eval(Container.DataItem, "Id_MecanicaConfiguracion") %>&amp;Nv=<%# DataBinder.Eval(Container.DataItem, "Id_Nivel") %>'>Copiar</a>                  
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

            var IdMN = $("#MainContent_hdnIdMecanicaNivel");
            var NM = $("#MainContent_hdnNombre");


            IdMN.val(IdMecanica);
            NM.val(NombreMecanica);

            if (r == true) {
                document.getElementById("MainContent_btnCancelar").click();
                alert('Mecánica cancelada exitósamente. ');
            } else {
                txt = "You pressed Cancel!";
            }
            return false;
        }
    </script>
</center>
</asp:Content>