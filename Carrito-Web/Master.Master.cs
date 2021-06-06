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
    public partial class Master : System.Web.UI.MasterPage
    {
        public List<Producto> lista;
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarLista();
        }
        public void cargarLista()
        {
            ProductoNegocio negocio = new ProductoNegocio();

            lista = negocio.Listar();
        }
    }
}