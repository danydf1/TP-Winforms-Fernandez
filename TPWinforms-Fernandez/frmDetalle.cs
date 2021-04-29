using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;

namespace TPWinforms_Fernandez
{
    public partial class frmDetalle : Form
    {
        Producto producto = null;
        public frmDetalle()
        {
            InitializeComponent();
        }
        public frmDetalle(Producto Articulo)
        {
            InitializeComponent();
            producto = Articulo;
        }

        private void frmDetalle_Load(object sender, EventArgs e)
        {
            if (producto != null)
            {
                lblCodigo.Text = producto.Codigo;
                lblNombre.Text = producto.Nombre;
                lblDescripcion.Text = producto.Descripcion;
                lblPrecio.Text = producto.Precio.ToString();
                lblMarca.Text = producto.Marca.Descripcion;
                lblCategoria.Text = producto.Categoria.Descripcion;

                RecargarImg(producto.UrlImagen);

            }
            else
                MessageBox.Show("no se selecciono ningun articulo, volver y seleccionar uno");

        }
        private void RecargarImg(string img)
        {
            try
            {
                pbProducto.Load(img);
            }
            catch (Exception)
            {

                MessageBox.Show("No se encontro Imagen");
            }

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
