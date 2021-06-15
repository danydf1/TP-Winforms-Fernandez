using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TP_Carrito_Fernandez
{

    public partial class carrito : System.Web.UI.Page
    {
        public Carrito listaCarrito = new Carrito();
        public items item = new items();    
       
        protected void Page_Load(object sender, EventArgs e)
        {
          listaCarrito.items = (List<items>)Session["listaCarrito"];
            

            if (listaCarrito.items == null)
                listaCarrito.items = new List<items>();

            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    if(listaCarrito.items.Find(x => x.item.Id.ToString() == Request.QueryString["id"]) == null)
                    {
                        List<Producto> listaProductos = (List<Producto>)Session["listaProductos"];
                        
                        item.item = listaProductos.Find(x => x.Id.ToString() == Request.QueryString["id"]);
                        item.cantidad = (int)Session["cantidad"];
                        item.subTotal = total( item.cantidad , item.item.Precio);
                        listaCarrito.items.Add(item); 
                    }
                }                
            }
            Session.Add("listaCarrito", listaCarrito.items);
            
        }

        
        private decimal total(int cantidad, decimal precio)
        {
            decimal Total = precio * cantidad;
            
            return Total;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            var argument = ((Button)sender).CommandArgument;
            List<items> listaCarrito = (List<items>)Session["listaCarrito"];
            items elim = listaCarrito.Find(x => x.item.Id.ToString() == argument);
            listaCarrito.Remove(elim);
            Session.Add("listaCarrito", listaCarrito);
        }

        protected void restar_Click(object sender, EventArgs e)
        {
            int cantidad = int.Parse( lblCantidad.Text);
            cantidad--;
             lblCantidad.Text = cantidad.ToString() ;
        }

        protected void aumentar_Click(object sender, EventArgs e)
        {
            int cantidad = int.Parse(lblCantidad.Text);
            cantidad++;
            lblCantidad.Text = cantidad.ToString();
        }
    }
}