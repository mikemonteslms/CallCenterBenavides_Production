<%@ Page Title="" Language="C#" MasterPageFile="~/contenido.master" AutoEventWireup="true" CodeBehind="ranking.aspx.cs" Inherits="Portal.ranking" %>

<%@ MasterType VirtualPath="~/contenido.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contenido_head" runat="server">
    <link href="src/perfect-scrollbar.css" rel="stylesheet">
    <script src="src/jquery.mousewheel.js"></script>
    <script src="src/perfect-scrollbar.js"></script>
    <style>
        #cuadrilla-productos {
            height: 470px !important;
            overflow: hidden;
            position: absolute;
        }

        .uno {
            background-color: #666;
        }

            .uno p {
                color: #ffffff !important;
            }

        .dos {
            background-color: #bbbbbb;
        }

            .dos p {
                color: #525252 !important;
            }

        .tres {
            background-color: #dfdfdf;
        }

            .tres p {
                color: #525252 !important;
            }

        .cuatro {
            background-color: #f3f3f3;
        }

            .cuatro p {
                color: #525252 !important;
            }

        .cinco {
            background-color: #fff;
        }

            .cinco p {
                color: #525252 !important;
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
<h3>Ranking</h3>
<div class="bloque-ranking">
	<p><b>Asesores de Venta</b></p>
    <br />    
    <div id="contenedor-movimientos" class="left">
        <div class="barra-titulo">
           <p class="columna-titulo" style="width:35px">No.</p>
           <p class="columna-titulo" style="width:284px;">Asesor</p>
           <p class="kilometros">Kilómetros</p>
        </div>
        <asp:ListView id="lvRankingVendedor" runat="server" OnItemDataBound="lvRankingVendedor_ItemDataBound" >
            <ItemTemplate>
        <asp:Panel id="pnlContenido" runat="server" class="barra-contenido">
            <p class="columna-contenido" style="width:40px;"><%# Eval("rank") %></p>
            <p class="columna-contenido" style="width:288px;"><%# Eval("asesor") %></p>
            <p class="columna-contenido"><%# Convert.ToInt32(Eval("puntos")).ToString("N0") %></p>
            </asp:Panel>
                </ItemTemplate>
                            <EmptyDataTemplate>
        <div class="barra-contenido" style="background: #666;">
            <p class="columna-contenido" style="width:480px; color:#ffffff !important;">No se encontraron registros</p>
        </div> 
                </EmptyDataTemplate>
        </asp:ListView>
</div>
</div>
<div class="bloque-ranking">

	<p><b>Ventas de Concesionaria</b></p>
    <br />    
        <div id="contenedor-movimientos" class="left">
        <div class="barra-titulo">
           <p class="columna-titulo" style="width:35px">No.</p>
           <p class="columna-titulo" style="width:284px;">Concesionaria</p>
           <p class="kilometros">Kilómetros</p>
        </div>
        <asp:ListView id="lvRankingConcesionaria" runat="server" OnItemDataBound="lvRankingVendedor_ItemDataBound" >
            <ItemTemplate>
        <asp:Panel id="pnlContenido" runat="server" class="barra-contenido">
            <p class="columna-contenido" style="width:40px;"><%# Eval("rank") %></p>
            <p class="columna-contenido" style="width:288px;"><%# Eval("distribuidor") %></p>
            <p class="columna-contenido"><%# Convert.ToInt32(Eval("puntos")).ToString("N0") %></p>
            </asp:Panel>
                </ItemTemplate>
                            <EmptyDataTemplate>
        <div class="barra-contenido" style="background: #666;">
            <p class="columna-contenido" style="width:480px; color:#ffffff !important;">No se encontraron registros</p>
        </div> 
                </EmptyDataTemplate>
        </asp:ListView>
</div>

    </div>
    </main>
    </div>
</asp:Content>
