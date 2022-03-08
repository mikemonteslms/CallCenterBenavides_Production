<%@ Page Language="C#" MasterPageFile="~/contenido.Master" AutoEventWireup="true" CodeBehind="transaccionManual.aspx.cs" Inherits="ORMOperacion.transaccionManual" %>


<%@ MasterType VirtualPath="~/contenido.Master" %>
<%@ Register Assembly="Telerik.OpenAccess.Web.40, Version=2014.3.1027.1, Culture=neutral, PublicKeyToken=7ce17eeaf1d59342" Namespace="Telerik.OpenAccess.Web" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head_contenido" runat="server">
    <link id="styCalendario" runat="server" rel="stylesheet" type="text/css" />

    <style>
        #ulForm li {
            margin-bottom: 5px;
            list-style: none;
        }

        span#ContentPlaceHolder1_body_contenido_RequiredFieldValidator6 {
            margin-left: 0px !important;
        }

        #container .RadComboBox {
            width: 100%;
        }

        #container .RadComboBox_Bootstrap .rcbLabel {
            width: 30% !important;
        }

        #container .RadComboBox_Bootstrap table {
            width: 49% !important;
        }

        /*#container .RadInput_Bootstrap .riLabel {            
            width: 47% !important;
        }

        #container .riSingle .riTextBox {
            width: 205px !important;
        }*/
    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body_contenido" runat="server">
    <telerik:OpenAccessLinqDataSource ID="OADistribuidor"
        runat="server"
        ContextTypeName="EntitiesModel.EntitiesModel"
        EntityTypeName=""
        ResourceSetName="distribuidors" />
    <telerik:OpenAccessLinqDataSource ID="OAArea"
        runat="server"
        ContextTypeName="EntitiesModel.EntitiesModel"
        EntityTypeName=""
        ResourceSetName="areas" />
    <telerik:OpenAccessLinqDataSource ID="OAProductos"
        runat="server"
        ContextTypeName="EntitiesModel.EntitiesModel"
        EntityTypeName=""
        ResourceSetName="productos" />
    <asp:SqlDataSource runat="server" ID="dsTipoTransaccion" SelectCommand="select * from tipo_transaccion where clave in ('C', 'V')"
        ConnectionString="<%$ ConnectionStrings:GaleniaTest%>"></asp:SqlDataSource>

    <div style="display: block; width: 100%;" id="container">
        <ul id="ulForm">
            <li>
                <telerik:RadTextBox runat="server" ID="numTarjeta" Label="Número de Tarjeta" LabelWidth="180" Width="50%"></telerik:RadTextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Style="margin-left: -83px"
                    ControlToValidate="numTarjeta" ErrorMessage="campo requerido!"
                    Display="Dynamic" Font-Size="Small" Font-Bold="true" Font-Italic="true" ForeColor="Maroon">
                </asp:RequiredFieldValidator>
            </li>
            <li>
                <telerik:RadComboBox runat="server" ID="sucursal" Label="Sucursal" DataSourceID="OADistribuidor"
                    DataTextField="clave" DataValueField="id" LabelWidth="180" Width="50%">
                    <DefaultItem Text="Seleccione Sucursal" />
                </telerik:RadComboBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Style="margin-left: -83px"
                    ControlToValidate="sucursal" ErrorMessage="campo requerido!"
                    Display="Dynamic" Font-Size="Small" Font-Bold="true" Font-Italic="true" ForeColor="Maroon">
                </asp:RequiredFieldValidator>
            </li>
            <li>
                <telerik:RadComboBox runat="server" ID="tipoTransaccion" Label="Tipo de Transacción" DataSourceID="dsTipoTransaccion"
                    DataTextField="descripcion" DataValueField="id" LabelWidth="180" Width="50%">
                </telerik:RadComboBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Style="margin-left: -83px"
                    ControlToValidate="tipoTransaccion" ErrorMessage="campo requerido!"
                    Display="Dynamic" Font-Size="Small" Font-Bold="true" Font-Italic="true" ForeColor="Maroon">
                </asp:RequiredFieldValidator>
            </li>
            <li>
                <telerik:RadComboBox runat="server" ID="area" Label="Area o Departamento" DataSourceID="OAArea"
                    DataTextField="descripcion_larga" DataValueField="id" LabelWidth="180" Width="50%">
                    <DefaultItem Text="Selecciona Area" />
                </telerik:RadComboBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Style="margin-left: -83px"
                    ControlToValidate="area" ErrorMessage="campo requerido!"
                    Display="Dynamic" Font-Size="Small" Font-Bold="true" Font-Italic="true" ForeColor="Maroon">
                </asp:RequiredFieldValidator>
            </li>
            <li>
                <telerik:RadTextBox runat="server" ID="factRem" Label="Factura o remisión" LabelWidth="180" Width="50%"></telerik:RadTextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Style="margin-left: -83px"
                    ControlToValidate="factRem" ErrorMessage="campo requerido!"
                    Display="Dynamic" Font-Size="Small" Font-Bold="true" Font-Italic="true" ForeColor="Maroon">
                </asp:RequiredFieldValidator>
            </li>
            <li>
                <telerik:RadDatePicker runat="server" ID="fechaFactura" DateInput-Label="Fecha Factura" DateInput-LabelWidth="38%" Width="43%"></telerik:RadDatePicker>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Style="margin-left: -83px"
                    ControlToValidate="fechaFactura" ErrorMessage="campo requerido!"
                    Display="Dynamic" Font-Size="Small" Font-Bold="true" Font-Italic="true" ForeColor="Maroon">
                </asp:RequiredFieldValidator>
            </li>
            <li>
                <%--<telerik:RadTextBox runat="server" ID="claveProducto" Label="Clave de producto" LabelWidth="180" Width="50%"></telerik:RadTextBox>--%>
                <telerik:RadComboBox runat="server" ID="claveProducto" Label="Clave del producto" DataSourceID="OAProductos"
                    Filter="Contains" DataTextField="clave" DataValueField="id" LabelWidth="180" Width="50%"
                    OnSelectedIndexChanged="claveProducto_SelectedIndexChanged" AutoPostBack="true" CausesValidation="false">
                    <DefaultItem Text="Seleccionar producto" />
                </telerik:RadComboBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" Style="margin-left: -83px"
                    ControlToValidate="claveProducto" ErrorMessage="campo requerido!"
                    Display="Dynamic" Font-Size="Small" Font-Bold="true" Font-Italic="true" ForeColor="Maroon">
                </asp:RequiredFieldValidator>
            </li>
            <li>
                <telerik:RadTextBox runat="server" ID="descProducto" Label="Descripción del producto" Width="50%" LabelWidth="180" ReadOnly="true"
                    Resize="Both" ReadOnlyStyle-Resize="Both" TextMode="MultiLine">
                </telerik:RadTextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" Style="margin-left: -83px"
                    ControlToValidate="descProducto" ErrorMessage="campo requerido!"
                    Display="Dynamic" Font-Size="Small" Font-Bold="true" Font-Italic="true" ForeColor="Maroon">
                </asp:RequiredFieldValidator>
                <telerik:RadButton runat="server" ID="btnInsertar" Text="Insertar Transaccion" CausesValidation="true" OnClick="btnInsertar_Click"></telerik:RadButton>
            </li>
            <li>
                <telerik:RadNumericTextBox runat="server" ID="cantidad" Label="Cantidad" LabelWidth="180" Width="50%"
                    OnTextChanged="cantidad_TextChanged" AutoPostBack="true">
                </telerik:RadNumericTextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" Style="margin-left: -83px"
                    ControlToValidate="cantidad" ErrorMessage="campo requerido!"
                    Display="Dynamic" Font-Size="Small" Font-Bold="true" Font-Italic="true" ForeColor="Maroon">
                </asp:RequiredFieldValidator>
            </li>
            <li>
                <telerik:RadNumericTextBox runat="server" ID="precioUnitario" Label="Precio Unitario" LabelWidth="180" Width="50%"
                    AutoPostBack="true" OnTextChanged="precioUnitario_TextChanged">
                </telerik:RadNumericTextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" Style="margin-left: -83px"
                    ControlToValidate="precioUnitario" ErrorMessage="campo requerido!"
                    Display="Dynamic" Font-Size="Small" Font-Bold="true" Font-Italic="true" ForeColor="Maroon">
                </asp:RequiredFieldValidator>
            </li>
            <li>
                <telerik:RadNumericTextBox runat="server" ID="importe" Label="Importe" LabelWidth="180" Width="50%"
                    AutoPostBack="true" OnTextChanged="importe_TextChanged" ReadOnly="true">
                </telerik:RadNumericTextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" Style="margin-left: -83px"
                    ControlToValidate="importe" ErrorMessage="campo requerido!"
                    Display="Dynamic" Font-Size="Small" Font-Bold="true" Font-Italic="true" ForeColor="Maroon">
                </asp:RequiredFieldValidator>
            </li>
            <li>
                <telerik:RadNumericTextBox runat="server" ID="impuesto" Label="Impuesto" LabelWidth="180" Width="50%" Value="0"
                    AutoPostBack="true" OnTextChanged="impuesto_TextChanged">
                </telerik:RadNumericTextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" Style="margin-left: -83px"
                    ControlToValidate="impuesto" ErrorMessage="campo requerido!"
                    Display="Dynamic" Font-Size="Small" Font-Bold="true" Font-Italic="true" ForeColor="Maroon">
                </asp:RequiredFieldValidator>
            </li>
            <li>
                <telerik:RadNumericTextBox runat="server" ID="total" Label="Total" LabelWidth="180" Width="50%" ReadOnly="true"></telerik:RadNumericTextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" Style="margin-left: -83px"
                    ControlToValidate="total" ErrorMessage="campo requerido!"
                    Display="Dynamic" Font-Size="Small" Font-Bold="true" Font-Italic="true" ForeColor="Maroon">
                </asp:RequiredFieldValidator>
            </li>
            <li>
                <telerik:RadComboBox runat="server" ID="tipoPago" Label="Tipo de Pago" LabelWidth="200" Width="50%">
                    <DefaultItem Text="Seleccione Tipo de Pago" />
                    <Items>
                        <telerik:RadComboBoxItem Value="Efectivo" Text="Efectivo" />
                        <telerik:RadComboBoxItem Value="Tarjeta" Text="Tarjeta" />
                        <telerik:RadComboBoxItem Value="Puntos" Text="Puntos" />
                        <telerik:RadComboBoxItem Value="Otro" Text="Otro" />
                    </Items>
                </telerik:RadComboBox>
            </li>
            <li>
                <telerik:RadDatePicker runat="server" ID="fechaPago" DateInput-Label="Fecha de Pago"
                    DateInput-LabelWidth="38%" Width="43%" DateInput-CausesValidation="true">
                </telerik:RadDatePicker>

                <asp:CompareValidator ID="CompareValidator1" Operator="GreaterThan"
                    ControlToValidate="fechaPago"
                    ControlToCompare="fechaFactura"
                    ErrorMessage="Fecha de Pago debe ser mayor a Fecha de Factura"
                    runat="server" ForeColor="Maroon">
                </asp:CompareValidator>
                <br />
                <asp:CompareValidator ID="CompareValidator2" Operator="LessThanEqual"
                    ControlToValidate="fechaPago"
                    Type="Date"
                    ErrorMessage="Fecha de Pago y Fecha de Factura debe ser menores al dia de hoy"
                    runat="server" ForeColor="Maroon">
                </asp:CompareValidator>
            </li>
            <li>
                <telerik:RadTextBox runat="server" ID="claveCliente" Label="Clave Cliente" LabelWidth="180" Width="50%"></telerik:RadTextBox>
            </li>
            <li>
                <telerik:RadTextBox runat="server" ID="nombreCliente" Label="Nombre Cliente" LabelWidth="180" Width="50%">
                </telerik:RadTextBox>
            </li>
        </ul>
    </div>
</asp:Content>
