<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MnuManager.ascx.cs" Inherits="MnuMain.Controles.ControlMnu.MnuManager" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI"  TagPrefix="telerik"%>

<style>
        .RadMenu_Bootstrap .rmRootLink.rmSelected,
        .RadMenu_Bootstrap .rmRootLink.rmSelected:hover,
        .RadMenu_Bootstrap .rmRootLink.rmExpanded,
        .RadMenu_Bootstrap .rmRootLink.rmExpanded:hover {
            /*background-color: rgb(27, 39, 139);*/
            /*background-color: rgb(28, 51, 245);*/
            background-color: #E6E6E6;
        }

        .RadMenu_Bootstrap .rmRootLink.rmExpanded {
            background-color: #E6E6E6;
             
        }

        .RadMenu_Bootstrap .rmHorizontal .rmItem {
            clear: none;
            background: #E6E6E6;
            padding: 0;
            margin: 0;
        }
        .RadMenu_Bootstrap ul.rmActive, .RadMenu_Bootstrap ul.rmRootGroup
         {
           background-image:none!important;
           background-color: #e6e6e6 !important;
           border: none;
         }
        .RadMenu_Bootstrap .rmItem .rmGroup.rmVertical {
            background: #e6e6e6;
        }

        .RadGrid_Bootstrap .rgHeader, .RadGrid_Bootstrap .rgHeader a {
            color: white !important;
            background: #70b8d3 !important;
        }

        .RadGrid_Bootstrap .rgCommandRow {
            background: #70b8d3 !important;
        }

        .RadGrid_Bootstrap .rgCommandCell a {
            color: white !important;
        }

        .RadMenu_Bootstrap {
            margin: 0 auto;
            
        }

            .RadMenu_Bootstrap .rmRootLink {
                color: #2A3479 !important;
            }

                .RadMenu_Bootstrap .rmRootLink .rmExpanded, .RadMenu_Bootstrap .rmExpanded:hover {
                    color: #2A3479 !important;
                    background-color:  #E6E6E6 !important;
                }

            .RadMenu_Bootstrap .rmGroup .rmLink .rmText {
                color: #2A3479;
            }
                .RadMenu_Bootstrap .rmGroup:hover .rmLink:hover .rmText:hover {
                    color: white;
                }

            .RadMenu_Bootstrap .rmGroup .rmLink:hover {
                background-color: #2A3479 !important;
            }
    </style>

              <telerik:RadMenu runat="server" ID="RadMenu1" EnableRoundedCorners="true" DataSourceID="SqlDataSource1"
                DataFieldID="id" DataFieldParentID="menu_id" DataTextField="nombre"
                Skin="Bootstrap"
                BackColor="Transparent"
                EnableShadows="true" EnableTextHTMLEncoding="true"
                Width="100%"
                OnItemClick="RadMenu1_ItemClick"
                OnItemDataBound="RadMenu1_ItemDataBound" Style="z-index: 3000; border: none;">
                <Items>
                    <telerik:RadMenuItem runat="server" Value="templateHolder" Font-Size="280px">
                    </telerik:RadMenuItem>
                </Items>
            </telerik:RadMenu>
            <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString="<%$ ConnectionStrings:GaleniaTest %>"
                ProviderName="System.Data.SqlClient" SelectCommand="sp_menu_usuario" SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:ControlParameter ControlID="hidUserId" Name="usuario_id" />
                </SelectParameters>
            </asp:SqlDataSource>

            <asp:HiddenField ID="hidUserId" runat="server" />
