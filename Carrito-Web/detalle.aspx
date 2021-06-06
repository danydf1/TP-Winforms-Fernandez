<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="detalle.aspx.cs" Inherits="TP_Carrito_Fernandez.detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="card mb-3" style="width: 40rem; margin:auto;">
          <img src=<% =seleccionado.UrlImagen %> class="card-img-top" alt=<%=seleccionado.Nombre %> />
          <div class="card-body">
            <h5 class="card-title-detalle"><% =seleccionado.Nombre %></h5>
            <p class="card-text"><% =seleccionado.Marca.Descripcion %></p>
            <p class="card-text"><% =seleccionado.Categoria.Descripcion%></p>
            <p class="card-text"> <% =seleccionado.Descripcion %>></p>
            <p class="card-text">$<% =seleccionado.Precio %></p>
            <a href="carrito.aspx?id=<%= seleccionado.Id %>" class="btn btn-primary">Agregar a carrito</a>
            <a href="productos.aspx" class="btn btn-primary">Volver</a>
          </div>
        </div>
</asp:Content>
