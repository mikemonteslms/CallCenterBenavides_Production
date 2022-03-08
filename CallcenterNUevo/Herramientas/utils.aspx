<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="utils.aspx.cs" Inherits="CallcenterNUevo.Herramientas.utils" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <script src="../../Scripts/jquery-1.7.1.min.js"></script>
    <script src="../../Scripts/jquery-ui-1.8.20.min.js"></script>
    <link href="cssAdminProm/cssAdminPromocion.css" rel="stylesheet" />
    

    <script type="text/javascript">
        function isokmaxlength(e, val, maxlengt) {
            var charCode = (typeof e.which == "number") ? e.which : e.keyCode

            if (!(charCode == 44 || charCode == 46 || charCode == 0 || charCode == 8 || (val.value.length < maxlengt))) {
                return false;
            }
        }
    </script>

    <asp:UpdatePanel runat="server" >
        <ContentTemplate>
            <asp:Table ID="tbl" runat="server">
                <asp:TableRow >
                    <asp:TableCell>
                        <asp:RadioButton ID="rdbexe" runat="server" GroupName="gral" Text="cadena: " />
                    </asp:TableCell>
                    <asp:TableCell>
                         <asp:RadioButton ID="rdbcons" runat="server" GroupName="gral" Text="consulta: " />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lbl" runat="server" Text="Cadena: "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                          <asp:TextBox ID="txtcadena" runat="server" MaxLength ="5000" TextMode ="MultiLine" Height="130px" onkeypress="return isokmaxlength(event,this,5000);" Width="700px"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow >
                    <asp:TableCell>
                        <asp:Button ID="btnEjecutar" runat="server" Text="Iniciar" OnClick="btnEjecutar_Click" />
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <br />
            <asp:Table ID="tbl2" runat="server">
                <asp:TableRow >
                    <asp:TableCell>
                        <telerik:RadGrid ID="grvDatosTest"  runat="server"  AutoGenerateColumns="true"  CellSpacing="2" GridLines="Both"    lowPaging="True" Culture="es-MX"  Width="850px">
                            <GroupingSettings CollapseAllTooltip="Collapse all groups" />
                            <MasterTableView NoMasterRecordsText="No se encontro información" AllowMultiColumnSorting="true">
                               <RowIndicatorColumn Visible="False">
                                        </RowIndicatorColumn>
                                  <PagerStyle PageSizeControlType="None"/>
                            </MasterTableView>
                                <SortingSettings SortedBackColor="#FFF6D6" EnableSkinSortStyles="false"></SortingSettings>
                        <HeaderStyle Width="100px"></HeaderStyle>
                            <PagerStyle FirstPageToolTip="Primera Página" GoToPageButtonToolTip="Ir a página" LastPageToolTip="Última página" NextPagesToolTip="Siguientes páginas" NextPageToolTip="Siguiente página" PagerTextFormat="Cambiar página: {4} &amp;nbsp;página &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;, registro &lt;strong&gt;{2}&lt;/strong&gt; a &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeControlType="None" PrevPagesToolTip="Páginas anteriores" PrevPageToolTip="Página anterior" />
                        </telerik:RadGrid>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow >
                    <asp:TableCell>
                        <telerik:RadGrid ID="grvDatosProd"  runat="server"  AutoGenerateColumns="true"  CellSpacing="2" GridLines="Both"    lowPaging="True" Culture="es-MX"  Width="850px">
                            <GroupingSettings CollapseAllTooltip="Collapse all groups" />
                            <MasterTableView NoMasterRecordsText="No se encontro información" AllowMultiColumnSorting="true">
                               <RowIndicatorColumn Visible="False">
                                        </RowIndicatorColumn>
                                  <PagerStyle PageSizeControlType="None"/>
                            </MasterTableView>
                                <SortingSettings SortedBackColor="#FFF6D6" EnableSkinSortStyles="false"></SortingSettings>
                        <HeaderStyle Width="100px"></HeaderStyle>
                            <PagerStyle FirstPageToolTip="Primera Página" GoToPageButtonToolTip="Ir a página" LastPageToolTip="Última página" NextPagesToolTip="Siguientes páginas" NextPageToolTip="Siguiente página" PagerTextFormat="Cambiar página: {4} &amp;nbsp;página &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;, registro &lt;strong&gt;{2}&lt;/strong&gt; a &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeControlType="None" PrevPagesToolTip="Páginas anteriores" PrevPageToolTip="Página anterior" />
                        </telerik:RadGrid>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
