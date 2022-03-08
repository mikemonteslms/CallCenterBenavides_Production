<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ComboBeneficio.aspx.cs" Inherits="CallcenterNUevo.Cat.ComboBeneficio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">}
    
     <script type="text/javascript" src="../Scripts/jquery-2.1.0.js"> </script>
     <script type="text/javascript" src="../Scripts/jquery-ui-1.10.4.js"></script>
        <link rel="stylesheet" href="../Content/Site.css"/>
 <link rel="stylesheet" href="../Content/themes/base/jquery.ui.datepicker.css"/>
 <link rel="stylesheet" href="../Content/themes/base/jquery.ui.theme.css"/>
 <link rel="stylesheet" href="../Content/themes/base/jquery.ui.core.css"/>

    <table>
         <tr style="border-bottom:2px solid black;">
            <td>
                <h1 style="color:#ff006e;">Beneficio</h1>
            </td>
            <td colspan="3" >
                <h2>
                    <asp:Label Text="" runat="server" ID="lblCategoriaMecanica" />
                </h2>                
            </td>
            <td colspan="1" style="text-align:right;">
                <asp:Button Text="Cancelar" runat="server" ID="btnCancelar" OnClick="btnCancelar_Click" />                                
                 <asp:Button Text="Guardar" runat="server" ID="btnGuardar" OnClick="btnGuardar_Click"  style="display:none;"  /> 
                <input type="button" name="btnSiguiente" value="Guardar" onclick="ObtenerSeleccion();" />
                <asp:Button Text="Limpiar" runat="server" ID="btnLimpiar" OnClick="btnLimpiar_Click"  />                                
            </td>
        </tr>
        <tr>
            <td style="border-top:2px solid black; padding-top: 30px;" colspan="5"></td>
        </tr>
        <tr>
            <td>Nombre:
            </td>
            <td>
                <asp:Label Text="" runat="server" ID="lblNombre" />
            </td>
            <td></td>
            <td>Descripción:
            </td>
            <td>
                <asp:Label Text="" runat="server" ID="lblDescripción" />
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <table>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <input type="text" id="txtCategoria" value="" />
                                    </td>
                                    <td>
                                        <a href="#" onclick="BuscarCategoria()">
                                            <img src="../Images/i_Buscar.png" style="height: 24px; width: 24px;" />
                                        </a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top;">
                            <div id="divCategorias" class="Categorias" style="max-height: 400px; width: 350px; overflow: scroll; background-color: #fff">
                            </div>
                        </td>
                        <td style="vertical-align: top;">
                            <div id="divPresentaciones" style="max-height: 400px; width: 350px; overflow: scroll; background-color: #fff">
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <div id="divPlantilla" style="display: none;">
        <div class="item" style="display: list-item;">
            <table>
                <tr>
                    <td>
                        <input type="button" id="btnSel##" class="btnSel" value=" + " onclick="BuscarProductos(this, '#####');" />
                    </td>
                    <td>
                        <label class="Nombre">CC#####</label>
                    </td>

                </tr>
            </table>
        </div>
    </div>
    <div id="divPlantillaProducto" style="display: none;">
        <div class="itemProd" style="display: list-item;">
            <table>
                <tr>
                    <td>
                        <input type="checkbox" id="chk###" class="###Cat" style="width: 10px;" onchange="Habilita(this)" />
                    </td>
                    <td>
                        <input type="text" id="txt####" class="txtSel numeric" style="width: 30px;" disabled="disabled" />
                    </td>
                    <td>
                        <label class="Nombre">Prod#####</label>
                    </td>
                </tr>
            </table>
        </div>
    </div>

    <div id="divPlantillaCategoria" style="display: none;">
        <div class="itemProdCat ###Cat" style="display: list-item;">
            <table>
                <tr>
                    <td>
                        <label class="Nombre">#####</label>
                    </td>

                </tr>
            </table>
        </div>
    </div>

    <script>
        function BuscarCategoria() {

            var strCategoria = $("#txtCategoria").val();
            var objBusqueda = { "strBusqueda": strCategoria };
            $.ajax({
                type: "POST",
                url: "~/AdminMecanicas/NM_Piezas.aspx/GetCategorias",
                data: JSON.stringify(objBusqueda),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var contenedor = $("#divCategorias");
                    contenedor.html("");
                    if (response.d != undefined) {

                        var objRespuesta = eval(response.d);
                        /*obtiene la plantilla*/
                        var plantilla = $("#divPlantilla").html();

                        for (i = 0; i < objRespuesta.length; i++) {

                            var info = plantilla.replace("#####", objRespuesta[i].Descripcion);

                            info = info.replace("CC#####", objRespuesta[i].Descripcion);
                            info = info.replace("btnSel##", objRespuesta[i].id_producto_categoria);
                            contenedor.append(info);
                        }
                    }
                },
                failure: function (response) {
                    alert(response.d);
                }
            });
        }

        function BuscarProductos(btn, Prod) {

            var strCategoria = btn.id;
            var objBusqueda = { "strBusqueda": strCategoria };
            $.ajax({
                type: "POST",
                url: "NM_Piezas.aspx/GetProductos",
                data: JSON.stringify(objBusqueda),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var contenedor = $("#divPresentaciones");

                    if (response.d != undefined) {

                        var objRespuesta = eval(response.d);

                        /*obtiene la plantilla*/
                        var plantilla = $("#divPlantillaProducto").html();
                        var plantillaCategoria = $("#divPlantillaCategoria").html();
                        var classCat = "Cat" + strCategoria;
                        var infoCat = plantillaCategoria.replace("#####", Prod);
                        infoCat = infoCat.replace("###Cat", classCat);
                        contenedor.append(infoCat);

                        for (i = 0; i < objRespuesta.length; i++) {

                            var info = plantilla.replace("Prod#####", objRespuesta[i].Producto_strDescripcion);
                            info = info.replace("chk###", objRespuesta[i].Producto_intCvo);
                            info = info.replace("txt####", 'txt' + objRespuesta[i].Producto_intCvo);
                            info = info.replace("###Cat", classCat);
                            contenedor.append(info);
                        }
                    }
                },
                failure: function (response) {
                    alert(response.d);
                }
            });
        }

        function Habilita(chk) {
            var txt = $("#txt" + chk.id);
            if (!chk.checked) {
                txt.attr("disabled", "disabled")
            }
            else {
                txt.removeAttr("disabled");
            }
        }

        function ObtenerSeleccion() {
            var objPresSel = $("#divPresentaciones").find(".itemProd").find("[type='checkbox']:checked");
            var numPresSel = objPresSel.length;
            var Seleccion = [];
            var flgContinue = "true";

            if (numPresSel < 1) {
                alert("Debe agregar al menos una presentacion");
                return false;
            }
            else {
                var iP = 0;

                for (iP = 0 ; iP < numPresSel; iP++) {
                    var objSel = $(objPresSel[iP]);
                    var Cat_Id = objSel.attr('class').replace("Cat", "");
                    var idProd = objSel.attr('id').replace("chk", "");
                    var txtCantidad = $("#txt" + idProd);
                    var objCategoria = { "IdCategoria": Cat_Id, "Cantidad": txtCantidad.val(), "IdProducto": idProd };
                    //alert("Producto - " + idProd);
                    if (txtCantidad.val() == '' || txtCantidad.val() < 1) { alert('Capture una cantidad para cada producto por favor.'); flgContinue = "false"; break; }
                    Seleccion.push(objCategoria);
                }

                if (Seleccion.length > 0 && flgContinue == "true") {
                    EnviarInfoProductos(Seleccion);
                }
            }
            return false;
        }

        function EnviarInfoProductos(Seleccion) {
            var objBusqueda = { "objSeleccion": Seleccion };
            $.ajax({
                type: "POST",
                url: "ComboBeneficio.aspx/GuardarProductosBeneficio",
                data: JSON.stringify(objBusqueda),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    if (response.d != undefined) {
                        //alert('Ok!');
                        document.getElementById("ctl00_ctl00_ContentPlaceHolder1_body_contenido_btnGuardar").click();
                        alert('La mecánica se guardo con éxito!!!');
                    }
                },
                failure: function (response) {
                    alert(response.d);
                    return false;
                }
            });
        }


        $(document).on("input", ".numeric", function () {
            this.value = this.value.replace(/[^0-9\.]/g, '');
        });
    </script>
</asp:Content>
