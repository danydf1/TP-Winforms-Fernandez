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
        public List<Producto> listaCarrito;
        public int Cantidad { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            listaCarrito = (List<Producto>)Session["listaCarrito"];

            if (listaCarrito == null)
                listaCarrito = new List<Producto>();

            if(!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    if(listaCarrito.Find(x => x.Id.ToString() == Request.QueryString["id"]) == null)
                    {
                        List<Producto> listaProductos = (List<Producto>)Session["listaProductos"];
                        listaCarrito.Add(listaProductos.Find(x => x.Id.ToString() == Request.QueryString["id"]));
                    }
                }
                
                repetidor.DataSource = listaCarrito;
                repetidor.DataBind();
                
            }
           
            
            Session.Add("listaCarrito", listaCarrito);
            
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            var argument = ((Button)sender).CommandArgument;
            List<Producto> listaCarrito = (List<Producto>)Session["listaCarrito"];
            Producto elim = listaCarrito.Find(x => x.Id.ToString() == argument);
            listaCarrito.Remove(elim);
            Session.Add("listaCarrito", listaCarrito);
            repetidor.DataSource = null;
            repetidor.DataSource = listaCarrito;
            repetidor.DataBind();
        }

        protected void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            Cantidad = int.Parse( ((TextBox)sender).Text);
            
        }
    }
}