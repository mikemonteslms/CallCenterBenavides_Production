﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DashBenavides1.aspx.cs" Inherits="CallcenterNUevo.DashBoard.DashBenavides1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <br /><br />
    <div class='tableauPlaceholder' id='viz1527032815489'  style='position: relative;'>
    <noscript>
        <a href='#'>
            <img alt='dbPromociones ' src='https:&#47;&#47;public.tableau.com&#47;static&#47;images&#47;DB&#47;DB_PromocionesXCategorias&#47;dbPromociones&#47;1_rss.png' style='border: none' />
        </a>
    </noscript>
    <object class='tableauViz' style='display:none;'>
        <param name='host_url' value='https%3A%2F%2Fpublic.tableau.com%2F' /> 
        <param name='embed_code_version' value='3' /> <param name='site_root' value='' />
        <param name='name' value='DB_PromocionesXCategorias&#47;dbPromociones' />
        <param name='tabs' value='no' /><param name='toolbar' value='yes' />
        <param name='static_image' value='https:&#47;&#47;public.tableau.com&#47;static&#47;images&#47;DB&#47;DB_PromocionesXCategorias&#47;dbPromociones&#47;1.png' /> 
        <param name='animate_transition' value='yes' />
        <param name='display_static_image' value='yes' />
        <param name='display_spinner' value='yes' />
        <param name='display_overlay' value='yes' />
        <param name='display_count' value='yes' />
        <param name='filter' value='publish=yes' />
    </object>
</div>
        

       <script type='text/javascript'>
           var divElement = document.getElementById('viz1527032815489');
           var vizElement = divElement.getElementsByTagName('object')[0];
           //vizElement.style.minWidth = '420px';
           vizElement.style.maxWidth = '950px';
           vizElement.style.width = '100%';
           vizElement.style.minHeight = '587px';
           //vizElement.style.maxHeight = '887px';
           vizElement.style.height = (divElement.offsetWidth * 0.75) + 'px';
           var scriptElement = document.createElement('script');
           scriptElement.src = 'https://public.tableau.com/javascripts/api/viz_v1.js';
           vizElement.parentNode.insertBefore(scriptElement, vizElement);
</script>
</asp:Content>
