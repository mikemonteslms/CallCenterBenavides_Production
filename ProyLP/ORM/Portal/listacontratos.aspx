<%@ page language="C#" autoeventwireup="true" codebehind="listacontratos.aspx.cs" inherits="Portal.listacontratos" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title></title>
    <script src="/js/jquery-1.10.2.min.js"></script>
    <link href="/css/estilos.css" rel="stylesheet" type="text/css">
    <link href="/src/perfect-scrollbar.css" rel="stylesheet">
    <script src="/src/jquery.mousewheel.js"></script>
    <script src="/src/perfect-scrollbar.js"></script>
    <style>
        #cuadrilla-productos {
            height: 387px !important;
            width:730px !important;
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
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <div id="plecagris" style="width:0;">
            </div>
            <div id="vw-header">
                <a href="#">
                    <h1 id="logoLoyalty"><span>Loyalty World</span></h1>
                </a>
                <div id="plecavw">
                </div>
            </div>
        </header>
        <div id="contenedor" class="main">
            <main>
<h3>Lista de contratos por asignar</h3>
                    <div id="contenedor-movimientos" class="left">
	<div class="barra-titulo">
    	<p class="concepto" style="width: 120px;">Producto</p>
        <p class="fecha" style="width: 120px;">Contrato</p>
        <p class="fecha" style="width: 200px;">Chasis</p>
        <p class="kilometros" style="width: 245px;">Tipo de auto</p>
    </div>
                            <section id="cuadrilla-productos">
        <asp:GridView id="gvContratos" runat="server" AutoGenerateColumns="false" ShowHeader="false" GridLines="None">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
    <div class="barra-contenido">
    	<p class="concepto" style="width:115px;"><%# Eval("Product group") %></p>
    </div>
                </ItemTemplate>
            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
    <div class="barra-contenido">
    	<p class="concepto" style="width:103px;"><%# Eval("numero_contrato") %></p>
    </div>
                </ItemTemplate>
            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
    <div class="barra-contenido">
    	<p class="concepto" style="width: 184px;"><%# Eval("chasis") %></p>
    </div>
                </ItemTemplate>
            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
    <div class="barra-contenido">
    	<p class="concepto" style="width:237px;"><%# Eval("tipo_auto") %></p>
    </div>
                </ItemTemplate>
            </asp:TemplateField>
                            </Columns>
            </asp:GridView>
</section>
</div>
</main>
        </div>
    </form>
</body>
</html>
