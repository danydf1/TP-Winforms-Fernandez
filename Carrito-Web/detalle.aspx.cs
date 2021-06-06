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
    public partial class detalle : System.Web.UI.Page
    {
        public Producto seleccionado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if(Request.QueryString["id"] != null)
                {
                    int id = int.Parse(Request.QueryString["id"]);
                    List<Producto> lista = (List<Producto>)Session["listaProductos"];

                    seleccionado = lista.Find(x => x.Id == id);

                }
                else
                {
                    Response.Redirect("productos.aspx");
                }
            }
            catch ( Exception ex)
            {
                Session.Add("error", ex.ToString());
            }
                     

        }
    }
}