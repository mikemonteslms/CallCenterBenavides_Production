<%@ Page Title="" Language="C#" MasterPageFile="~/contenido.master" AutoEventWireup="true" CodeBehind="mecanica.aspx.cs" Inherits="Portal.mecanica" %>

<%@ MasterType VirtualPath="~/contenido.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contenido_head" runat="server">
    <link href="src/perfect-scrollbar.css" rel="stylesheet">
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>
    <script src="src/jquery.mousewheel.js"></script>
    <script src="src/perfect-scrollbar.js"></script>
    <style>
        #cuadrilla-productos {
            height: 470px !important;
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
        <main id="mecanica">

<h3>MECÁNICA</h3>
 <asp:MultiView id="mvMecanica" runat="server">
     <asp:View ID="vGerentesVendedores" runat="server">
          	 <!-- Accordion begin -->
		<div class="accordion_example3">
		
			<!-- Section 1 -->
			<div class="accordion_in acc_active">
				<div class="acc_head">¿Cómo acumulo kilómetros?</div>
				<div class="acc_content">
					<p>Los Gerentes de Ventas y Asesores de Ventas, podrán acumular kilómetros mediante las ventas de productos de Volkswagen Servicios Financieros, mismos que se verán reflejados en la cuenta individual asignada a cada Participante:
					</p><br />
                    <p>
                    	<b>- Colocación*</b> <br />
						<b>- Prospección/Seguimiento:</b> Porcentajes de seguimiento a prospectos en el Sistema de Prospección de Volkswagen de México.<br />
						<b>- Seguros de venta tradicional o mercado abierto.* </b><br />
                        <b>- Promociones:</b> Se comunicarán mediante correo electrónico y en la página web. <br />
                    </p>
                    <br />
                    <div class="cuadro-info">
                    	 <div class="titulo-cuadro-info">
                       	<p><span>Volkswagen Bank</span></p>
                       </div>
                      <div class="contenido-1">
                      	<p>Credit</p>
                      </div>
                      <div class="numero-contenido">
                      	<p>200</p>
                      </div>
                      
                       <div class="contenido-1">
                      	<p>Premium Credit</p>
                      </div>
                      <div class="numero-contenido">
                      	<p>400</p>
                      </div>
                    </div>
                    
                    
                    <div class="cuadro-info">
                      <div class="titulo-cuadro-info">
                       	<p><span>Volkswagen Leasing</span></p>
                       </div>
                       
                        <div class="contenido-1">
                      	<p>Credit</p>
                      </div>
                      <div class="numero-contenido">
                      	<p>200</p>
                      </div>
                       <div class="contenido-1">
                      	<p>Premium Credit</p>
                      </div>
                      <div class="numero-contenido">
                      	<p>300</p>
                      </div>
                      <div class="contenido-1">
                      	<p>Leasing</p>
                      </div>
                      <div class="numero-contenido">
                      	<p>400</p>
                      </div>
                    </div>
<div class="cuadro-info">
    <div class="titulo-cuadro-info">
        <p><span>% de Seguimiento</span></p>
    </div>
    <div class="contenido-1">
        <p>0-30%</p>
    </div>
            <div class="numero-contenido">
            <p>0</p>
        </div>
    <div class="contenido-1">
        <p>31-70%</p>
    </div>
            <div class="numero-contenido">
            <p>50</p>
        </div>
    <div class="contenido-1">
        <p>71-80%</p>
    </div>
            <div class="numero-contenido">
            <p>100</p>
        </div>
    <div class="contenido-1">
        <p>81-90%</p>
    </div>
            <div class="numero-contenido">
            <p>150</p>
        </div>
    <div class="contenido-1">
        <p>91-100%</p>
    </div>
            <div class="numero-contenido">
            <p>200</p>
        </div>

</div>                    
                    
                    
                     <div class="cuadro-info">
                      <div class="titulo-cuadro-info">
                       	<p><span>Seguros Mercado Abierto</span></p>
                       </div>
                       
                        <div class="contenido-1">
                      	<p>Seguro vendido</p>
                      </div>
                      <div class="numero-contenido">
                      	<p>200</p>
                      </div>
                    </div>
                    
                     <p class="texto-small">*Las ventas demo, movilidad ni flotillas contarán para la generación de Kilómetros.</p>
                     
                     <p class="destacado-mecanica" style=""><b>- Bonos:</b> Bienvenida, cumpleaños, aniversario laboral y encuestas o quinielas.<br /></p>
                     <br />
                     <div class="cuadro-info" style="width:265px;">
                        <div class="contenido-1" style="width:200px;">
                      	<p>Bienvenida y Aniversario Laboral</p>
                      </div>
                      <div class="numero-contenido">
                      	<p>50<br /><br /></p>
                      </div>
                      
                       <div class="contenido-1" style="width:200px;">
                      	<p>Cumpleaños</p>
                      </div>
                      <div class="numero-contenido">
                      	<p>100</p>
                      </div>
                      
                       <div class="contenido-1" style="width:200px;">
                      	<p>Encuesta y Quinielas</p>
                      </div>
                      <div class="numero-contenido">
                      	<p>50</p>
                      </div>
                    </div>
                    
                    
                     <p class="destacado-mecanica" style=""><b>- University:</b> <br /></p>
                     <br />
                     <div class="cuadro-info" style="width:582px;">
                        <div class="contenido-1" style="width:517px;">
                      	<p><b>IBT</b> Curso de certificación internacional para Asesores de Ventas (1 vez al año)</p>
                      </div>
                      <div class="numero-contenido">
                      	<p>300</p>
                      </div>
                    </div>
				</div>
			</div>

			<!-- Section 2 -->
			<div class="accordion_in">
				<div class="acc_head">¿Quiénes participan?</div>
				<div class="acc_content">
					 <p>
                    	<span>A.</span> <b>Gerente de Ventas</b> <br />
						<span>B.</span> <b>Asesores de Ventas</b> <br />
                    </p>
				</div>
			</div>

		

		</div>
		<!-- Accordion end -->  

     </asp:View>
     <asp:View ID="vGSF" runat="server">
                   	 <!-- Accordion begin -->
		<div class="accordion_example3">
		
			<!-- Section 1 -->
			<div class="accordion_in acc_active">
				<div class="acc_head">¿Cómo acumulo kilómetros?</div>
				<div class="acc_content">
					<p>Los Gerente de Servicios Financieros deberán:
					</p><br />
                    <p>
                    	<b>-</b> Asignar las ventas por colocación y seguros al Asesor de Ventas correspondiente.<br /><br />
						<b>-</b> Motivar a los Asesores de Ventas con la finalidad de incrementar las ventas de productos Volkswagen Servicios Financieros Participantes para lograr los objetivos de Penetración y Eficiencia de la Concesionaria.<br /><br />
						<b>-</b> Conocer las bases del Programa para asesorar a los Participantes.<br /><br />
                        <b>-</b> Revisar y monitorear los resultados de sus Asesores de Ventas a través de la página web del Programa.<br /><br />
                        <b>-</b> Informar bajas o cambios de los Participantes al Centro de Atención Telefónico del Programa.<br /><br />
                    </p>
                    <p>Los Gerente de Servicios Financieros podrán ganar Kilómetros de la siguiente forma:<br /><br />
<p class="destacado-mecanica"><b>- Asignación de Ventas por Colocación</b></p>
</p>
                    <p>El Gerente de Servicios Financieros obtiene <b>500 Kilómetros</b> por realizar el 100% de la asignación de ventas a la fuerza de ventas de su Concesionaria en el mes; en caso de que el Gerente de Servicios Financieros no realice alguna asignación, su cuenta permanecerá en cero.</p><br />
<p class="destacado-mecanica"><b>- Porcentaje de Penetración</b></p>
                    <p>El Gerente de Servicios Financieros obtiene Kilómetros de acuerdo al rango de porcentaje de penetración que obtuvo la Concesionaria en cada mes, estos Kilómetros están definidos de la siguiente manera:</p>
                    <br />
                    <table class="cuadro-info-gsf">
                        <tr>
                            <td rowspan="2" class="contenido-1-gsf">&nbsp;</td>
                            <td colspan="6" class="titulo-cuadro-info-gsf"><span>Cantidad de autos</span></td>
                        </tr>
                        <tr>
                            <td class="subtitulo-gsf">0 a 4</td>
                            <td class="subtitulo-gsf">5 a 10</td>
                            <td class="subtitulo-gsf">11 a 20</td>
                            <td class="subtitulo-gsf">21 a 30</td>
                            <td class="subtitulo-gsf">31 a 40</td>
                            <td class="subtitulo-gsf">41 o más</td>
                        </tr>
                        <tr>
                            <td class="contenido-1-gsf">0 - 14.99 %</td>
                            <td class="numero-contenido-gsf">0</td>
                            <td class="numero-contenido-gsf">0</td>
                            <td class="numero-contenido-gsf">0</td>
                            <td class="numero-contenido-gsf">300</td>
                            <td class="numero-contenido-gsf">500</td>
                            <td class="numero-contenido-gsf">1,000</td>
                        </tr>
                        <tr>
                            <td class="contenido-1-gsf">15 - 24.99 %</td>
                            <td class="numero-contenido-gsf">0</td>
                            <td class="numero-contenido-gsf">100</td>
                            <td class="numero-contenido-gsf">300</td>
                            <td class="numero-contenido-gsf">500</td>
                            <td class="numero-contenido-gsf">1,000</td>
                            <td class="numero-contenido-gsf">1,500</td>
                        </tr>
                        <tr>
                            <td class="contenido-1-gsf">25 - 31.99 %</td>
                            <td class="numero-contenido-gsf">0</td>
                            <td class="numero-contenido-gsf">300</td>
                            <td class="numero-contenido-gsf">500</td>
                            <td class="numero-contenido-gsf">1,000</td>
                            <td class="numero-contenido-gsf">1,500</td>
                            <td class="numero-contenido-gsf">1,750</td>
                        </tr>
                        <tr>
                            <td class="contenido-1-gsf">32 - 37.99 %</td>
                            <td class="numero-contenido-gsf">0</td>
                            <td class="numero-contenido-gsf">500</td>
                            <td class="numero-contenido-gsf">1,000</td>
                            <td class="numero-contenido-gsf">1,500</td>
                            <td class="numero-contenido-gsf">1,750</td>
                            <td class="numero-contenido-gsf">2,000</td>
                        </tr>
                        <tr>
                            <td class="contenido-1-gsf">38 - 44.99 %</td>
                            <td class="numero-contenido-gsf">100</td>
                            <td class="numero-contenido-gsf">1,000</td>
                            <td class="numero-contenido-gsf">2,000</td>
                            <td class="numero-contenido-gsf">2,500</td>
                            <td class="numero-contenido-gsf">3,000</td>
                            <td class="numero-contenido-gsf">3,500</td>
                        </tr>
                        <tr>
                            <td class="contenido-1-gsf">45 ó más %</td>
                            <td class="numero-contenido-gsf">500</td>
                            <td class="numero-contenido-gsf">2,000</td>
                            <td class="numero-contenido-gsf">2,500</td>
                            <td class="numero-contenido-gsf">3,000</td>
                            <td class="numero-contenido-gsf">3,500</td>
                            <td class="numero-contenido-gsf">4,500</td>
                        </tr>
                    </table>
                    <br />
                    <p class="texto-small"><b>Nota:</b> El porcentaje de penetración es el número de contratos de Volkswagen Servicios Financieros generados en el mes respecto al total de ventas generadas dentro de la Concesionaria.</p><br />
                    <p class="destacado-mecanica"><b>- Porcentaje de Eficiencia</b></p>
                    <p>El Gerente de Servicios Financieros obtiene Kilómetros de acuerdo al rango de porcentaje de eficiencia (contratos activados entre todas las solicitudes viables autorizadas y detenidas) que obtuvo la Concesionaria en cada mes, estos Kilómetros están definidos de la siguiente manera:</p><br />
                                        <div class="cuadro-info">
                        <div class="contenido-1">
                      	<p>0 - 49.99 %</p>
                      </div>
                      <div class="numero-contenido">
                      	<p>0</p>
                      </div>
                        <div class="contenido-1">
                      	<p>50 - 64.99 %</p>
                      </div>
                      <div class="numero-contenido">
                      	<p>500</p>
                      </div>
                        <div class="contenido-1">
                      	<p>65 - 69.99 %</p>
                      </div>
                      <div class="numero-contenido">
                      	<p>1,000</p>
                      </div>
                        <div class="contenido-1">
                      	<p>70 - 79.99 %</p>
                      </div>
                      <div class="numero-contenido">
                      	<p>2,000</p>
                      </div>
                        <div class="contenido-1">
                      	<p>80 - 89.99 %</p>
                      </div>
                      <div class="numero-contenido">
                      	<p>3,000</p>
                      </div>
                        <div class="contenido-1">
                      	<p>90 - 100 %</p>
                      </div>
                      <div class="numero-contenido">
                      	<p>4,000</p>
                      </div>
</div>
                    <br />
                    <br />
                    <p class="destacado-mecanica"><b>- Bonos</b></p>
                    
                    <div class="cuadro-info-2">
                        <div class="contenido-2">
                      	<p>Bienvenida y aniversario laboral</p>
                      </div>
                      <div class="numero-contenido">
                      	<p>50</p>
                      </div>
                        <div class="contenido-2">
                      	<p>Cumpleaños</p>
                      </div>
                      <div class="numero-contenido">
                      	<p>100</p>
                      </div>
                        <div class="contenido-2">
                      	<p>Encuesta y quinielas</p>
                      </div>
                      <div class="numero-contenido">
                      	<p>150</p>
                      </div>
                        </div>
                                        <p class="destacado-mecanica"><b>- University</b></p>
                    <table class="cuadro-info-gsf">
                        <tr>
                            <td class="mecanica-university">Curso Inducción para Nuevos GSF</td>
                            <td class="mecanica-university">Capacitación para el Gerente de Servicios Financieros (1 vez al año).</td>
                            <td class="mecanica-university">100</td>
                        </tr>
                        <tr>
                            <td class="mecanica-university">Curso PLD</td>
                            <td class="mecanica-university">Curso de certificación internacional para Asesores de Ventas (1 vez al año).</td>
                            <td class="mecanica-university">100</td>
                        </tr>
                        <tr>
                            <td class="mecanica-university">Curso Leasing</td>
                            <td class="mecanica-university">Capacitación del producto de Leasing (1 vez al año).</td>
                            <td class="mecanica-university">200</td>
                        </tr>
                        <tr>
                            <td class="mecanica-university">Curso Cálculo de ingresos</td>
                            <td class="mecanica-university">Cálculo de ingresos de las diferentes tipos de personas (1 vez al año).</td>
                            <td class="mecanica-university">150</td>
                        </tr>
                        <tr>
                            <td class="mecanica-university">Conexión a la transmisión de la oferta</td>
                            <td class="mecanica-university">Conexión vía web para ver la oferta del mes, transmisión on line (mensual).</td>
                            <td class="mecanica-university">100</td>
                        </tr>
                    </table>

			</div>
                </div>
			<!-- Section 2 -->
			<div class="accordion_in">
				<div class="acc_head">¿Quiénes participan?</div>
				<div class="acc_content">
					 <p>
                    	<span>A.</span> <b>Gerente de Servicios Financieros</b> <br />
                    </p>
				</div>
			</div>

		

		</div>
		<!-- Accordion end -->  

     </asp:View>
 </asp:MultiView>
    
    
    
    
    	
</main>
    </div>
</asp:Content>
