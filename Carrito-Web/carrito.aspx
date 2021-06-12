<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="carrito.aspx.cs" Inherits="TP_Carrito_Fernandez.carrito" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table class="table">
        <thead>
            <tr>
                <th scope="col">Nombre</th>
                <th scope="col">Marca</th>
                <th scope="col">Precio</th>
                <th scope="col">Cantidad</th>
                <th scope="col">Eliminar</th>
                <th scope="col">Total</th>
            </tr>
        </thead>
        <tbody>
            <%foreach ( Dominio.items item in listaCarrito.items)
                {%>

            <tr>
                <td><%= item.item.Nombre %></td>
                <td><%= item.item.Marca  %></td>
                <td><%= item.item.Precio %></td>
                <td>
                    <asp:TextBox TextMode="Number" AutoPostBack="true" ID="txtCantidad" runat="server" OnTextChanged="txtCantidad_TextChanged" ReadOnly="False" Text="1"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnEliminar" CssClass="btn btn-dark" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />

                </td>
                <td><%= item.subTotal %></td>
                <%} %>
            </tr>
        </tbody>

    </table>
</asp:Content>
