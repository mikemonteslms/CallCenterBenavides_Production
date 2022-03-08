<%@ page title="" language="C#" masterpagefile="~/contenido.master" autoeventwireup="true" codebehind="default.aspx.cs" inherits="Portal._default" %>

<%@ mastertype virtualpath="~/contenido.master" %>
<asp:content id="Content1" contentplaceholderid="contenido_head" runat="server">
</asp:content>
<asp:content id="Content2" contentplaceholderid="contenido_body" runat="server">
    <div id="contenedor" style="margin-top: 14px;">
        <section id="slider">

            <div id="textoSlide">
                <div id="tituloSlide">
                    <%--<span class="grisTitulo">Rally en el Desierto.</span><br>
                    ¡Bienvenido!--%>
                </div>
                <div id="subtituloSlide">
                    <%--Prepárate para ganar con un programa exclusivo para ti.<a href="mecanica.aspx"><p id="boton2"><span id="triangulo">&nbsp;</span>&nbsp;&nbsp;&nbsp;Descubre cómo</p>
                    </a>--%>
                </div>
            </div>
            
        </section>
        <section id="destacados">
            <article id="comentarios">
                <div class="titulo" style="padding-top: 4px; height:22px;">Deja tu comentario</div>
                <div id="cuerpo1">
                    <asp:TextBox ID="frm_mensaje" runat="server" PlaceHolder="Escribir un comentario..." TextMode="MultiLine" Width="256" Height="65"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqComentarios" runat="server" ControlToValidate="frm_mensaje"
                        ValidationGroup="Comentarios" ErrorMessage="Debe escribir un comentario">&nbsp;</asp:RequiredFieldValidator>
                    <cc1:ValidatorCalloutExtender ID="valComentarios" runat="server" TargetControlID="reqComentarios">
                    </cc1:ValidatorCalloutExtender>
                    <asp:LinkButton ID="lnkEnviar" runat="server" ValidationGroup="Comentarios" OnClick="btnEnviarComent_Click"> <p id="boton">Enviar&nbsp;&nbsp;&nbsp;<span id="triangulo">&nbsp;</span></p></asp:LinkButton>
                </div>
            </article>
            <article id="respuestas">
                <div class="titulo">Lo que los demás dicen<a href="#" class="tooltip1" title="¡Hola! Ofrecemos una disculpa por el tiempo de espera a tu solcitud, todas las respuestas las enviaremos a tu correo. Recuerda que las ventas de productos finanieros te generan Kilómetros… ¡Participa!"><span title=""><img src="images/info-icon.png" alt="" style="vertical-align: middle!important; float:right; padding-right:15px;" /></span></a></div>
                <div id="cuerpo2" style="overflow-y:auto; height:100px;">
                    <asp:Repeater ID="rptBlog" runat="server">
                        <ItemTemplate>
                            <div class="subtitulo"><%# Eval("nombre_completo") %></div>
                            <asp:Label ID="lblComentario" runat="server" Text='<%# Eval("mensaje") %>'></asp:Label>
                            <hr />
                        </ItemTemplate>
                    </asp:Repeater>
                    <%--<div id="arearespuesta">
                    <div id="cuerpo3">
                        <div class="subtitulo2">Respuestas</div>
                        Lorem ipsum dolor sit amet, consectetur adipisicing elit,sed do eiusmod tempor incididunt.
                    </div>
                </div>--%>
                </div>
            </article>
            <article id="canje">
                <div class="titulo" style="padding-top: 4px; height:22px;">Premio sugerido</div>
                <div id="cuerpo2">
                    <div class="producto"><a href="#" class="tooltip">Los Cabos 2 pers. Hotel Bel Air<span id="foto1"></span></a><span class="puntos">161,869 ptos</span></div>
                    <div class="producto2"><a href="#" class="tooltip">iPad Air RD Wifi + Cell 16 GB<span id="foto2"></span></a><span class="puntos">74,869 ptos</span></div>
                    <div class="producto2"><a href="#" class="tooltip">Bicicleta Urbana Retro Dama R26<span id="foto3"></span></a><span class="puntos">18,566 ptos</span></div>
                    <div class="producto2"><a href="#" class="tooltip">Tiempo Aire Telcel $50 MXN<span id="foto4"></span></a><span class="puntos">402 ptos</span></div>
                </div>
            </article>
        </section>
    </div>
</asp:content>
