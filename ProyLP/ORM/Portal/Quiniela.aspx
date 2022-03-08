<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Quiniela.aspx.cs" Inherits="Portal.Quiniela" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js" type="text/javascript"></script>

    <script src="specimen_files/easytabs.js" type="text/javascript" charset="utf-8"></script>
    <link rel="stylesheet" href="specimen_files/specimen_stylesheet.css" type="text/css" />
    <link rel="stylesheet" href="css/quiniela.css" type="text/css" />

    <style>
        .inputs {
            height: 41px;
            width: 35px;
            border-color: transparent;
            background-image: url(images/quiniela/bg_marcador.png);
            font-family: score_boardregular;
            color: #FFED00;
            font-size: 35px;
            border-color: rgba(0,0,0,.15);
            border: 1px solid #000;
            -webkit-border-radius: 9px;
            -moz-border-radius: 9px;
            border-radius: 9px;
            outline: 0;
            box-shadow: none;
        }
    </style>

    <style>
        html {
            /*added to prevent scroll bars in radwindow*/
            overflow: hidden;
        }
    </style>

    <script type="text/javascript">
        $(document).ready(function () {
            $('#container').easyTabs({ defaultContent: 1 });
        });

        function validar() {
            var resultado = "";
            $('#tblPartidos input[type=text]').each(function (i) {

                if ($(this).val() == "") resultado = "SI";
            });

            if (resultado == "SI") {
                alert('Ingresa todos los resultados');
            }
            else {
                document.getElementById("ibtnGuardar").click();
            }
        }

    </script>


</head>
<body>
    <form id="form1" runat="server">
        <script>

            function validarGuardar() {


                document.getElementById("ibtnGuardar").click();


            }
        </script>

        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>

        <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Width="100%">
            <div id="divQuiniela" runat="server">
                <div style="position: absolute; left: 45px; top: 235px; z-index: 1000">
                    <asp:ImageButton ID="ibtnAnterior" runat="server" ImageUrl="images/quiniela/btn_anterior.png" onmouseover="this.src='images/quiniela/btn_anterior-hover.png'" onmouseout="this.src='images/quiniela/btn_anterior.png'" OnClick="ibtnAnterior_Click" /></div>
                <table style="background-image: url(images/quiniela/bg_quinielas.jpg); background-repeat: no-repeat; width: 700px; height: 560px">
                    <tr>

                        <td>
                            <table width="478px" style="background-image: url(images/quiniela/bg-marco.png); background-repeat: no-repeat; position: relative; top: 70px; height: 442px; left: 100px">
                                <tr>
                                    <td colspan="2">
                                        <div class="section" style="position: relative; top: 58px; left: 105px">
                                            <div class="grid12 firstcol">
                                                <div class="glyph_range" style="font-family: 'score_boardregular'; background-color: transparent;">
                                                    <asp:Label ID="lblFecha" runat="server" Text="PARTIDOS DEL "></asp:Label></div>
                                                <input type="hidden" runat="server" id="diaQuniela" />
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <div style="position: absolute; top: 90px; left: 90px;">
                                            <telerik:RadListView ID="rlvPartidos" runat="server" Width="478px" Height="100%">
                                                <ItemTemplate>
                                                    <table style="height: 65px">
                                                        <tr>
                                                            <td style="width: 146px; background-image: url(images/quiniela/bg_pais.png); background-repeat: no-repeat;">
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td style="position: relative; left: 5px; top: 5px">
                                                                            <asp:Image ID="imgBanderaLocal" runat="server" ImageUrl='<%# Eval("bandera_local") %>' /></td>
                                                                        <td style="position: relative; right: 4px; bottom: 2px">
                                                                            <asp:TextBox ID="txtMarcadorLocal" runat="server" Text='<%#Bind("goles_local")%>' CssClass="Huge inputs"></asp:TextBox>
                                                                            <cc1:MaskedEditExtender ID="mascaralocal" runat="server" MaskType="Number" TargetControlID="txtMarcadorLocal" Mask="9"></cc1:MaskedEditExtender>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>

                                                            <td style="width: 10px">&nbsp;
                                                            </td>
                                                            <td style="width: 146px; background-image: url(images/quiniela/bg_pais.png); background-repeat: no-repeat;">
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td style="position: relative; left: 7px; bottom: 2px">
                                                                            <asp:TextBox ID="txtMarcadorVisitante" runat="server" Text='<%#Bind("goles_visitante")%>' CssClass="Huge inputs"></asp:TextBox>
                                                                            <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" MaskType="Number" TargetControlID="txtMarcadorVisitante" Mask="9"></cc1:MaskedEditExtender>
                                                                        </td>
                                                                        <td style="position: relative; left: 5px; top: 5px">
                                                                            <asp:Image ID="imgBanderaVisitante" runat="server" ImageUrl='<%# Eval("bandera_visitante") %>' />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                                <input type="hidden" runat="server" value='<%# Eval("partido_id") %>' id="hdnPartidoID" />



                                                            </td>

                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </telerik:RadListView>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="position: fixed; left: 375px; top: 445px;">
                                        <asp:ImageButton ID="ibtnHistorico" runat="server" ImageUrl="~/images/quiniela/btn_historico.png" onmouseover="this.src='images/quiniela/btn_historico-hover.png'" onmouseout="this.src='images/quiniela/btn_historico.png'" OnClick="ibtnHistorico_Click" /></td>

                                    <td align="left" style="position: fixed; left: 165px; top: 445px;">
                                        <asp:ImageButton ID="itnGuardarV" runat="server" ImageUrl="~/images/quiniela/btn_guardar.png" onmouseover="this.src='images/quiniela/btn_guardar-hover.png'" onmouseout="this.src='images/quiniela/btn_guardar.png'" OnClientClick="validar(); return false;" /><div style="display: none">
                                            <asp:ImageButton ID="ibtnGuardar" runat="server" OnClick="ibtnGuardar_Click" /></div>
                                    </td>
                                </tr>
                            </table>
                        </td>

                    </tr>
                </table>
                <div style="position: absolute; top: 235px; left: 530px">
                    <asp:ImageButton ID="ibtnSiguiente" runat="server" ImageUrl="images/quiniela/btn_siguiente.png" onmouseover="this.src='images/quiniela/btn_siguiente-hover.png'" onmouseout="this.src='images/quiniela/btn_siguiente.png'" OnClick="ibtnSiguiente_Click" /></div>
            </div>
            <div id="divHistorico" runat="server" style="display: none">
                <table width="99%">
                    <tr>
                        <td style="height: 95px; background-repeat: no-repeat; background-image: url(images/Quiniela/header_historico_ok.jpg)">&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <telerik:RadGrid ID="gridHistorico" runat="server" AllowPaging="true" PageSize="13" AutoGenerateColumns="false" OnNeedDataSource="gridHistorico_NeedDataSource" Skin="Office2010Blue" EnableEmbeddedScripts="true" ShowFooter="True">
                                <MasterTableView DataKeyNames="participante_id">
                                    <Columns>
                                        <telerik:GridBoundColumn DataField="fecha" UniqueName="fecha" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="local" HeaderText="Local" UniqueName="Local"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="visitante" HeaderText="Visitante" UniqueName="Visitante"></telerik:GridBoundColumn>
                                        <telerik:GridTemplateColumn UniqueName="Marcador" HeaderText="Marcador real">
                                            <ItemTemplate>
                                                <%#Eval("marcador_local") %> - <%#Eval("marcador_visitante") %>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn UniqueName="Pronostico" HeaderText="Mi pronóstico">
                                            <ItemTemplate>
                                                <%#Eval("goles_local") %> - <%#Eval("goles_visitante") %>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn DataField="puntos" HeaderText="Goles ganados" UniqueName="puntos" Aggregate="Sum" FooterText="Total: "></telerik:GridBoundColumn>
                                    </Columns>
                                    <NoRecordsTemplate>
                                        <div style="height: 30px; cursor: pointer;">
                                            No hay registros que mostrar
                                        </div>
                                    </NoRecordsTemplate>
                                </MasterTableView>
                                <PagerStyle Mode="NumericPages" PagerTextFormat="{4} Página {0} de {1}, registros {2} al {3} de {5}" />
                            </telerik:RadGrid>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:ImageButton ID="ibtnRegresar" runat="server" OnClick="ibtnRegresar_Click" ImageUrl="~/Images/quiniela/btn-regresar.png" onmouseover="this.src='Images/quiniela/btn-regresar-hover.png'" onmouseout="this.src='Images/quiniela/btn-regresar.png'" />
                        </td>
                    </tr>
                </table>
            </div>
        </telerik:RadAjaxPanel>

    </form>
</body>
</html>
