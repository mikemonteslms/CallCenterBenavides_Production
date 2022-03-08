<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editarMecanicas.aspx.cs" Inherits="ORMOperacion.editarMecanicas" MasterPageFile="~/contenido.Master" %>

<%@ Register Assembly="Telerik.OpenAccess.Web.40, Version=2014.3.1027.1, Culture=neutral, PublicKeyToken=7ce17eeaf1d59342" Namespace="Telerik.OpenAccess.Web" TagPrefix="telerik" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head_contenido" runat="server">
    <link id="styCalendario" runat="server" rel="stylesheet" type="text/css" />
    <style>
        .columnaurl {
            word-break: break-all;
        }

        .img_logo img {
            width: 125px !important;
        }

        .labelPrograma {
            width: 77px;
        }

        .labelProgramaLarge {
            width: 100px;
        }

        .labelProgramaLarger {
            width: 132px;
        }

        .RadListBox_Bootstrap .rlbHeader h5 {
            margin-bottom: 0px;
        }
    </style>
    <script>
        function ShowDatePopupIni() {
            $find("<%= fechaInicial.ClientID %>").showPopup();
        }
        function ShowDatePopupFin() {
            $find("<%= fechaFinal.ClientID %>").showPopup();
        }
    </script>
    <script>
        var listbox;
        var filterTextBox;
        var listboxProducto;
        var filterTextBoxProducto;

        function pageLoad() {
            listbox = $find("<%= lstMarcasSource.ClientID %>");
            filterTextBox = document.getElementById("<%= txtFiltrarMarca.ClientID %>");
            // set on anything but text box
            listbox._getGroupElement().focus();

            listboxProducto = $find("<%= lstProductosSource.ClientID %>");
            filterTextBoxProducto = document.getElementById("<%= txtFiltrarProducto.ClientID %>");
            // set on anything but text box
            listboxProducto._getGroupElement().focus();
        }

        function OnClientDroppedHandler(sender, eventArgs) {
            // clear emphasis from matching characters
            eventArgs.get_sourceItem().set_text(clearTextEmphasis(eventArgs.get_sourceItem().get_text()));
        }

        //para filtrar marca empieza
        function filterList() {
            clearListEmphasis();
            createMatchingList();
        }

        // clear emphasis from matching characters for entire list
        function clearListEmphasis() {
            var re = new RegExp("</{0,1}em>", "gi");
            var items = listbox.get_items();
            var itemText;

            items.forEach
            (
                function (item) {
                    itemText = item.get_text();
                    item.set_text(clearTextEmphasis(itemText));
                }
            )
        }

        // clear emphasis from matching characters for given text
        function clearTextEmphasis(text) {
            var re = new RegExp("</{0,1}em>", "gi");
            return text.replace(re, "");
        }

        // hide listboxitems without matching characters
        function createMatchingList() {
            var items = listbox.get_items();
            var filterText = filterTextBox.value;
            var re = new RegExp(filterText, "i");

            items.forEach
            (
                function (item) {
                    var itemText = item.get_text();

                    if (itemText.toLowerCase().indexOf(filterText.toLowerCase()) != -1) {
                        item.set_text(itemText.replace(re, "<em>" + itemText.match(re) + "</em>"));
                        item.set_visible(true);
                    }
                    else {
                        item.set_visible(false);
                    }
                }
            )
        }
        //para filtrar marca termina


        //para filtrar producto empieza
        function filterListProducto() {
            clearListEmphasisProducto();
            createMatchingListProducto();
        }

        function clearListEmphasisProducto() {
            var re = new RegExp("</{0,1}em>", "gi");
            var items = listboxProducto.get_items();
            var itemText;

            items.forEach
            (
                function (item) {
                    itemText = item.get_text();
                    item.set_text(clearTextEmphasisProducto(itemText));
                }
            )
        }

        function clearTextEmphasisProducto(text) {
            var re = new RegExp("</{0,1}em>", "gi");
            return text.replace(re, "");
        }

        // hide listboxitems without matching characters
        function createMatchingListProducto() {
            var items = listboxProducto.get_items();
            var filterText = filterTextBoxProducto.value;
            var re = new RegExp(filterText, "i");

            items.forEach
            (
                function (item) {
                    var itemText = item.get_text();

                    if (itemText.toLowerCase().indexOf(filterText.toLowerCase()) != -1) {
                        item.set_text(itemText.replace(re, "<em>" + itemText.match(re) + "</em>"));
                        item.set_visible(true);
                    }
                    else {
                        item.set_visible(false);
                    }
                }
            )
        }
        //para filtrar producto termina
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body_contenido" runat="server">
    <telerik:OpenAccessLinqDataSource ID="OABeneficio"
        runat="server"
        ContextTypeName="EntitiesModel.EntitiesModel"
        EntityTypeName=""
        ResourceSetName="beneficios">
    </telerik:OpenAccessLinqDataSource>

    <telerik:OpenAccessLinqDataSource ID="OAPrograma"
        runat="server"
        ContextTypeName="EntitiesModel.EntitiesModel"
        EntityTypeName=""
        ResourceSetName="programas">
    </telerik:OpenAccessLinqDataSource>
    <asp:SqlDataSource runat="server" ID="dsMarcas" SelectCommand="select id, descripcion_larga from marca order by descripcion_larga"
        ConnectionString="<%$ ConnectionStrings:GaleniaTest%>"></asp:SqlDataSource>
    <telerik:OpenAccessLinqDataSource ID="OATipoMecanica"
        runat="server"
        ContextTypeName="EntitiesModel.EntitiesModel"
        EntityTypeName=""
        ResourceSetName="tipo_mecanicas">
    </telerik:OpenAccessLinqDataSource>
    <telerik:OpenAccessLinqDataSource ID="OATipoParticipante"
        runat="server"
        ContextTypeName="EntitiesModel.EntitiesModel"
        EntityTypeName=""
        ResourceSetName="tipo_participantes">
    </telerik:OpenAccessLinqDataSource>
    <telerik:OpenAccessLinqDataSource ID="OAMecanicas"
        runat="server"
        ContextTypeName="EntitiesModel.EntitiesModel"
        EntityTypeName=""
        ResourceSetName="mecanicas">
    </telerik:OpenAccessLinqDataSource>

    <div>
        <telerik:RadTabStrip runat="server" ID="RadTabStrip1" MultiPageID="RadMultiPage1" SelectedIndex="1"
            CausesValidation="false" OnTabClick="RadTabStrip1_TabClick">
            <Tabs>
                <telerik:RadTab Text="Agregar" Width="200px"></telerik:RadTab>
                <telerik:RadTab Text="Editar" Width="200px"></telerik:RadTab>
                <telerik:RadTab Text="Editar Existente" Width="200px" Visible="false"></telerik:RadTab>
            </Tabs>
        </telerik:RadTabStrip>
        <telerik:RadMultiPage runat="server" ID="RadMultiPage1" SelectedIndex="0" CssClass="outerMultiPage">
            <telerik:RadPageView runat="server" ID="RadPageView1">
                <telerik:RadWindowManager ID="RadWindowManager1" runat="server" EnableShadow="true"></telerik:RadWindowManager>

                <label>Manteminiento de tipo de mecanicas es mediante el mantenimiento de un catalogo general</label>
                <br />
                <label>Mantenimiento de Mecanica</label>

                <table>
                    <tr>
                        <td>
                            <telerik:RadComboBox runat="server" ID="rcbPrograma" Label="Programa" Width="215" LabelCssClass="labelPrograma"
                                DataSourceID="OAPrograma" DataValueField="id" DataTextField="descripcion_larga">
                                <DefaultItem Text="Seleccionar programa" />
                            </telerik:RadComboBox>
                            <asp:RequiredFieldValidator ID="valPrograma" runat="server"
                                ControlToValidate="rcbPrograma" ErrorMessage="Seleccionar programa!"
                                Display="Dynamic" Font-Size="Small" Font-Bold="true" Font-Italic="true" ForeColor="Maroon">
                            </asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <telerik:RadComboBox runat="server" ID="rcbTipoPar" Label="Tipo Participante" Width="200" LabelCssClass="labelProgramaLarger"
                                DataSourceID="OATipoParticipante" DataValueField="id" DataTextField="descripcion_larga">
                                <DefaultItem Text="Seleccionar tipo de participante" />
                            </telerik:RadComboBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                ControlToValidate="rcbTipoPar" ErrorMessage="Seleccionar tipo de participante!"
                                Display="Dynamic" Font-Size="Small" Font-Bold="true" Font-Italic="true" ForeColor="Maroon">
                            </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <telerik:RadTextBox runat="server" ID="txtClave" Label="Clave" Width="300" LabelWidth="80"></telerik:RadTextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                ControlToValidate="txtClave" ErrorMessage="campo requerido!"
                                Display="Dynamic" Font-Size="Small" Font-Bold="true" Font-Italic="true" ForeColor="Maroon">
                            </asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <label class="RadComboBox_Bootstrap rcbLabel" style="width: 170px;">Fecha Inicial Vigencia</label>
                            <telerik:RadDatePicker runat="server" ID="fechaInicial" Label="Fecha Inicial Vigencia" Width="200" onclick="ShowDatePopupIni()">
                            </telerik:RadDatePicker>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                                ControlToValidate="fechaInicial" ErrorMessage="campo requerido!"
                                Display="Dynamic" Font-Size="Small" Font-Bold="true" Font-Italic="true" ForeColor="Maroon">
                            </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <telerik:RadTextBox runat="server" ID="txtNombre" Label="Nombre" Width="300" LabelWidth="80"></telerik:RadTextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                ControlToValidate="txtNombre" ErrorMessage="campo requerido!"
                                Display="Dynamic" Font-Size="Small" Font-Bold="true" Font-Italic="true" ForeColor="Maroon">
                            </asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <label class="RadComboBox_Bootstrap rcbLabel">Fecha Final Vigencia&nbsp;</label>
                            <telerik:RadDatePicker runat="server" ID="fechaFinal" Label="Fecha Inicial Vigencia" Width="200" onclick="ShowDatePopupFin()"></telerik:RadDatePicker>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                                ControlToValidate="fechaFinal" ErrorMessage="campo requerido!"
                                Display="Dynamic" Font-Size="Small" Font-Bold="true" Font-Italic="true" ForeColor="Maroon">
                            </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <telerik:RadTextBox runat="server" ID="txtDescripcion" Label="Descripcion" Width="300" LabelWidth="80"></telerik:RadTextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                ControlToValidate="txtDescripcion" ErrorMessage="campo requerido!"
                                Display="Dynamic" Font-Size="Small" Font-Bold="true" Font-Italic="true" ForeColor="Maroon">
                            </asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <telerik:RadComboBox runat="server" ID="rcbTipoMec" Label="Tipo Mecanica" Width="200" LabelCssClass="labelProgramaLarger"
                                DataSourceID="OATipoMecanica" DataValueField="id" DataTextField="descripcion_larga" OnSelectedIndexChanged="rcbTipoMec_SelectedIndexChanged"
                                AutoPostBack="true" CausesValidation="false">
                                <DefaultItem Text="Seleccionar tipo de mecanica" />
                            </telerik:RadComboBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                ControlToValidate="rcbTipoMec" ErrorMessage="Seleccionar tipo de mecanica!"
                                Display="Dynamic" Font-Size="Small" Font-Bold="true" Font-Italic="true" ForeColor="Maroon">
                            </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <telerik:RadNumericTextBox runat="server" ID="factAcum" Label="Factor Acumulación" Width="340" LabelWidth="135" NumberFormat-DecimalDigits="2"></telerik:RadNumericTextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"
                                ControlToValidate="factAcum" ErrorMessage="campo requerido!"
                                Display="Dynamic" Font-Size="Small" Font-Bold="true" Font-Italic="true" ForeColor="Maroon">
                            </asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <telerik:RadComboBox runat="server" ID="beneficio" Label="Beneficio" Width="200" LabelCssClass="labelProgramaLarger" Visible="false"
                                DataSourceID="OABeneficio" DataValueField="id" DataTextField="descripcion_larga">
                                <DefaultItem Text="Seleccionar tipo de mecanica" />
                            </telerik:RadComboBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server"
                                ControlToValidate="beneficio" ErrorMessage="Seleccionar un beneficio!"
                                Display="Dynamic" Font-Size="Small" Font-Bold="true" Font-Italic="true" ForeColor="Maroon">
                            </asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <telerik:RadTextBox runat="server" ID="diasAcum" Label="Dias para acumular" Visible="false" Width="140">
                            </telerik:RadTextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server"
                                ControlToValidate="diasAcum" ErrorMessage="Campo requerido!"
                                Display="Dynamic" Font-Size="Small" Font-Bold="true" Font-Italic="true" ForeColor="Maroon">
                            </asp:RequiredFieldValidator>

                        </td>
                    </tr>
                </table>

                <telerik:RadAjaxLoadingPanel runat="server" ID="loadingPanel1"></telerik:RadAjaxLoadingPanel>
                <telerik:RadAjaxPanel runat="server" LoadingPanelID="loadingPanel1">
                    <div class="demo-container">
                        <asp:TextBox ID="txtFiltrarMarca"
                            runat="server"
                            Width="165px"
                            onkeyup="filterList();" />
                        <br />
                        <telerik:RadListBox ID="lstMarcasSource" CssClass="RadListBox1" runat="server" Width="50%" Height="200px"
                            SelectionMode="Multiple" AllowTransfer="true" TransferToID="lstMarcasInsert" AutoPostBackOnTransfer="true"
                            AllowReorder="true" EnableDragAndDrop="true"
                            DataSourceID="dsMarcas" DataTextField="descripcion_larga" DataValueField="id" DataSortField="id"
                            ButtonSettings-Position="Right"
                            ButtonSettings-AreaWidth="50px"
                            OnTransferred="lstMarcasSource_Transferred" OnTransferring="lstMarcasSource_Transferring"
                            Sort="Ascending">
                            <HeaderTemplate>
                                <h5>Marcas</h5>
                            </HeaderTemplate>
                        </telerik:RadListBox>
                        <telerik:RadListBox ID="lstMarcasInsert" CssClass="RadListBox2" runat="server" Width="30%" Height="200px"
                            SelectionMode="Multiple" AutoPostBackOnReorder="true" EnableDragAndDrop="true" AutoPostBackOnTransfer="true"
                            AutoPostBack="true" ShowCheckAll="true" Localization-CheckAll="Seleccionar todos"
                            DataTextField="descripcion_larga" DataValueField="id" CheckBoxes="true" OnItemCheck="lstProductosInsert_ItemCheck"
                            OnCheckAllCheck="lstMarcasInsert_CheckAllCheck">
                            <HeaderTemplate>
                                <h5>*Seleccione el checkbox de la Marca para aplicar a todos los productos de la misma</h5>
                            </HeaderTemplate>
                        </telerik:RadListBox>
                    </div>
                    <br />
                    <asp:TextBox ID="txtFiltrarProducto"
                        runat="server"
                        Width="165px"
                        onkeyup="filterListProducto();" />
                    <br />
                    <div class="demo-container">
                        <telerik:RadListBox ID="lstProductosSource" CssClass="RadListBox1" runat="server" Width="50%" Height="200px"
                            SelectionMode="Multiple" AllowTransfer="true" TransferToID="lstProductosInsert" AutoPostBackOnTransfer="true"
                            AutoPostBackOnReorder="true" EnableDragAndDrop="true"
                            DataTextField="descripcion_larga" DataValueField="id" DataKeyField="marca_id"
                            ButtonSettings-AreaWidth="50px" OnTransferred="lstProductosSource_Transferred">
                            <HeaderTemplate>
                                <h5>Productos</h5>
                            </HeaderTemplate>

                        </telerik:RadListBox>
                        <telerik:RadListBox ID="lstProductosInsert" CssClass="RadListBox2" runat="server" Width="30%" Height="200px"
                            SelectionMode="Multiple" AutoPostBackOnReorder="true" EnableDragAndDrop="true"
                            DataTextField="descripcion_larga" DataValueField="id" DataKeyField="marca_id">
                        </telerik:RadListBox>
                        <telerik:RadButton runat="server" ID="btnGuardar" Text="Guardar" OnClick="btnGuardar_Click" CausesValidation="true"></telerik:RadButton>
                    </div>
                    <telerik:RadInputManager ID="RadInputManagerMarcas" runat="server">
                        <telerik:TextBoxSetting InitializeOnClient="true"
                            BehaviorID="TextBoxBehavior1"
                            EmptyMessage="filtrar marcas...">
                            <TargetControls>
                                <telerik:TargetInput ControlID="txtFiltrarMarca" />
                            </TargetControls>
                        </telerik:TextBoxSetting>
                    </telerik:RadInputManager>
                    <telerik:RadInputManager ID="RadInputManagerProductos" runat="server">
                        <telerik:TextBoxSetting
                            BehaviorID="TextBoxBehavior1"
                            EmptyMessage="filtrar productos...">
                            <TargetControls>
                                <telerik:TargetInput ControlID="txtFiltrarProducto" />
                            </TargetControls>
                        </telerik:TextBoxSetting>
                    </telerik:RadInputManager>
                </telerik:RadAjaxPanel>
            </telerik:RadPageView>
            <telerik:RadPageView runat="server" ID="RadPageView2" Selected="true">
                <telerik:RadGrid runat="server" ID="rgdMecanicas" DataSourceID="OAMecanicas" AutoGenerateColumns="false">
                    <MasterTableView>
                        <Columns>
                            <telerik:GridBoundColumn HeaderText="ID" DataField="id"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Clave" DataField="clave"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Descripcion" DataField="descripcion"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Descripcion Larga" DataField="descripcion_larga"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Tipo Mecanica" DataField="tipo_mecanica.clave"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Programa" DataField="programa.clave"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Tipo Participante" DataField="tipo_participante.clave"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Beneficio" DataField="beneficio.clave"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Dias para cupon" DataField="dias_para_cupon"></telerik:GridBoundColumn>
                            <telerik:GridDateTimeColumn HeaderText="Fecha Inicial Vigencia" DataField="fecha_inicial_vigencia" DataType="System.DateTime"
                                DataFormatString="{0:dd/MM/yyyy}">
                            </telerik:GridDateTimeColumn>
                            <telerik:GridDateTimeColumn HeaderText="Fecha Final Vigencia" DataField="fecha_final_vigencia" DataType="System.DateTime"
                                DataFormatString="{0:dd/MM/yyyy}">
                            </telerik:GridDateTimeColumn>
                            <telerik:GridDateTimeColumn HeaderText="Fecha Alta" DataField="fecha_alta" DataType="System.DateTime"
                                DataFormatString="{0:dd/MM/yyyy}">
                            </telerik:GridDateTimeColumn>
                            <telerik:GridTemplateColumn>
                                <ItemTemplate>
                                    <telerik:RadButton runat="server" ID="rdbEditar" Text="Editar"
                                        CommandArgument='<%#DataBinder.Eval(Container.DataItem, "id") %>'
                                        OnClick="rdbEditar_Click" AutoPostBack="true" CausesValidation="false">
                                    </telerik:RadButton>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
            </telerik:RadPageView>
            <telerik:RadPageView runat="server" ID="RadPageView3" ContentUrl="mantenimientoMecanicas.aspx"></telerik:RadPageView>
        </telerik:RadMultiPage>
    </div>
</asp:Content>
