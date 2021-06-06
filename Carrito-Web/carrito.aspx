<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="carrito.aspx.cs" Inherits="TP_Carrito_Fernandez.carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
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
        <asp:Repeater runat="server" ID="repetidor">
            <ItemTemplate>
                <tbody>
                    <tr>
                        <td><%#Eval("Nombre")%></td>
                        <td><%#Eval("Marca") %></td>
                        <td><%#Eval("Precio") %></td>
                        <td>
                            <asp:TextBox TextMode="Number" AutoPostBack="true" ID="txtCantidad" runat="server" OnTextChanged="txtCantidad_TextChanged"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="btnEliminar" CssClass="btn btn-dark" runat="server" Text="Eliminar" CommandArgument='<%#Eval("Id")%>' OnClick="btnEliminar_Click" />

                        </td>
                        <td>
                           
                        </td>
                    </tr>
                </tbody>
            </ItemTemplate>
        </asp:Repeater>
    </table>

</asp:Content>
