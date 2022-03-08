<%@ Page Title="" Language="C#" MasterPageFile="~/contenido.Master" AutoEventWireup="true" CodeBehind="registrarParticipantes.aspx.cs" Inherits="ORMOperacion.registrar.registrarParticipantes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head_contenido" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body_contenido" runat="server">
    <center>    
        <div>
            Generar Participantes en Membership<br />
            <br />
            <br />
            <asp:DropDownList ID="ddlMarca" runat="server">
                <asp:ListItem Selected="True" Value="0">Seleccione Marca</asp:ListItem>
                <asp:ListItem Value="1">VW</asp:ListItem>
                <asp:ListItem Value="2">AUDI</asp:ListItem>
                <asp:ListItem Value="3">SEAT</asp:ListItem>
                <asp:ListItem Value="4">PORSCHE</asp:ListItem>
                <asp:ListItem Value="5">CONSULTOR</asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvMarca" runat="server"
                ControlToValidate="ddlMarca" ErrorMessage="* Seleccione marca"
                ForeColor="#FF3300" InitialValue="0"></asp:RequiredFieldValidator>
            <br />
            <br />
            <asp:Button ID="btnConsultar" runat="server" Text="Consultar Pendientes"
                OnClick="btnConsultar_Click" />
            &nbsp;
        <asp:Button ID="btnGenerar" runat="server" Text="Generar Participantes"
            OnClick="btnGenerar_Click" ValidationGroup="aasasa" />
            <br />
            <br />
            <br />
            <asp:Button ID="btnConsultarUsuarios" runat="server" OnClick="btnConsultarUsuarios_Click" Text="consultar Usuarios Pendientes" ValidationGroup="asasa" Visible="false" />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="Button" ValidationGroup="asasa" Visible="false" />
            <br />
            <br />
            Total de Resultados:&nbsp;
        <asp:Label ID="lblNoRegistros" runat="server" Text="0"></asp:Label>
            <br />
            <asp:Panel ID="pnlDatos" runat="server" Height="400px" Width="900px" ScrollBars="Vertical">
                <asp:GridView ID="gvDatos" runat="server" AutoGenerateColumns="true" DataKeyNames="clave,id,nombre,correo_electronico,contraseña"
                    BackColor="#CCCCCC">
                    <HeaderStyle BackColor="#0066FF" ForeColor="White" />
                </asp:GridView>
            </asp:Panel>
        </div>
    </center>
</asp:Content>
