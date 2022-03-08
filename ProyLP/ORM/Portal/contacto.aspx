<%@ Page Title="" Language="C#" MasterPageFile="~/contenido.master" AutoEventWireup="true" CodeBehind="contacto.aspx.cs" Inherits="Portal.contacto" %>

<%@ MasterType VirtualPath="~/contenido.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contenido_head" runat="server">
    <style>
        #cuadrilla-productos {
            height: 540px !important;
            overflow: hidden;
            position: absolute;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function ($) {
            $('#cuadrilla-productos').perfectScrollbar({
                wheelSpeed: 15,
                wheelPropagation: false
            });
        });
    </script>

    <!-- Archivos del Acordión -->
    <link rel="stylesheet" href="css/smk-accordion.css" />
    <script type="text/javascript" src="src/smk-accordion.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function ($) {


            $(".accordion_example3").smk_Accordion({
                showIcon: false, //boolean
            });

        });
    </script>
    <!-- Termina archivos del acordión -->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido_body" runat="server">
    <div id="contenedor" class="main">
        <h3>Contacto</h3>
        <section id="categorias">

            <!-- Accordion begin -->
            <div class="accordion_example3" id="columna-izquierda">

                <!-- Datos Generales -->
                <div class="accordion_in acc_active">
                    <div class="acc_head">Contáctanos, conocer tu opinión es importante para nosotros.</div>
                    <div class="acc_content">
                        <div class="contacto">
                            <table>
                                <tr>
                                    <td align="right">Nombre: </td>
                                    <td>
                                        <asp:TextBox ID="txtNombre" runat="server" CssClass="cuadro_texto" Width="300px"></asp:TextBox></td>
                                        <asp:RequiredFieldValidator ID="reqNombre" runat="server" ControlToValidate="txtNombre"
                                            ValidationGroup="Comentarios" ErrorMessage="Su nombre es requerido">&nbsp;</asp:RequiredFieldValidator>
                                        <cc1:ValidatorCalloutExtender ID="valNombre" runat="server" TargetControlID="reqNombre">
                                        </cc1:ValidatorCalloutExtender>
                                </tr>
                                <tr>
                                    <td align="right">Número de cliente: </td>
                                    <td>
                                        <asp:TextBox ID="txtClave" runat="server" CssClass="cuadro_texto" Width="300px"></asp:TextBox></td>
                                        <asp:RequiredFieldValidator ID="reqClave" runat="server" ControlToValidate="txtClave"
                                            ValidationGroup="Comentarios" ErrorMessage="Su número de cliente es requerido">&nbsp;</asp:RequiredFieldValidator>
                                        <cc1:ValidatorCalloutExtender ID="valClave" runat="server" TargetControlID="reqClave">
                                        </cc1:ValidatorCalloutExtender>
                                </tr>
                                <tr>
                                    <td align="right">Correo electrónico: </td>
                                    <td>
                                        <asp:TextBox ID="txtEmail" runat="server" CssClass="cuadro_texto" Width="300px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td align="right">Teléfono (con LADA): </td>
                                    <td>
                                        <asp:TextBox ID="txtTelefono" runat="server" CssClass="cuadro_texto" Width="300px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td align="right">Tipo de mensaje: </td>
                                    <td>
                                        <asp:DropDownList ID="ddlTipoMensaje" runat="server" CssClass="cuadro_texto" Width="305" DataValueField="id" DataTextField="descripcion">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="reqTipoMensaje" runat="server" ControlToValidate="ddlTipoMensaje"
                                            ValidationGroup="Comentarios" ErrorMessage="Seleccione un tipo de comentario" InitialValue="0">&nbsp;</asp:RequiredFieldValidator>
                                        <cc1:ValidatorCalloutExtender ID="valTipoMensaje" runat="server" TargetControlID="reqTipoMensaje">
                                        </cc1:ValidatorCalloutExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">Comentarios: </td>
                                    <td>
                                        <asp:TextBox ID="txtComentarios" runat="server" CssClass="Comentarios" Width="305px" Height="70px" TextMode="MultiLine" PlaceHolder="Escribir un comentario..."></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="reqComentarios" runat="server" ControlToValidate="txtComentarios"
                                            ValidationGroup="Comentarios" ErrorMessage="Debe escribir un comentario">&nbsp;</asp:RequiredFieldValidator>
                                        <cc1:ValidatorCalloutExtender ID="valComentarios" runat="server" TargetControlID="reqComentarios">
                                        </cc1:ValidatorCalloutExtender>
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <asp:LinkButton ID="btnEnviar" runat="server" Text="Enviar" CssClass="boton-gris" ValidationGroup="Comentarios" OnClick="btnEnviar_Click"></asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>
</asp:Content>
