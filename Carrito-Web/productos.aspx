<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="productos.aspx.cs" Inherits="TP_Carrito_Fernandez.productos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <div class="cards">
        <div class="row row-cols-1 row-cols-md-4 ">
         <%foreach (Dominio.Producto item in lista)
            {%>
            
                <div class="col">
                    <div class="card border-secondary mb-3" style="max-width: 20rem;">
                        <img src="<%=item.UrlImagen%>" class="card-img-top" alt="<%=item.Nombre%>">
                        <div class="card-body">
                            <h5 class="card-title"><%=item.Nombre %></h5>
                            <p class="card-text"><%=item.Marca %></p>
                            <p class="card-text"><%=item.Precio %></p>
                            <a href="detalle.aspx?id=<%=item.Id%>" class="btn btn-primary">Detalles</a>
                        </div>
                    </div>
                </div>
            
        <%  } %>
            </div>
    </div>
</asp:Content>
