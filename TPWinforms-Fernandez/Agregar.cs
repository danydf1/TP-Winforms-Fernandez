using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
using Dominio;

namespace TPWinforms_Fernandez
{
    public partial class FrmAgregar : Form
    {
        private Producto producto = null;
        public FrmAgregar()
        {
            InitializeComponent();
        }

        /// Constructor se encarga se mandar el producto ya cargado para su modificacion
        public FrmAgregar (Producto articulo)
        {
            InitializeComponent();
            producto = articulo; 
        }
        /// Se cargan los comboBox con la funcion listar de cada clase
        /// si un producto se crea ya con campos completos los carga en una ventana para modificar
        private void Agregar_Load(object sender, EventArgs e)
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

            cmbMarca.DataSource = marcaNegocio.listar();
            cmbMarca.ValueMember = "id";
            cmbMarca.DisplayMember = "descripcion";

            cmbCategoria.DataSource = categoriaNegocio.listar();
            cmbCategoria.ValueMember = "id";
            cmbCategoria.DisplayMember = "descripcion";

            if (producto != null)
            {
                txtCodigo.Text = producto.Codigo;
                txtNombre.Text = producto.Nombre;
                txtDescripcion.Text = producto.Descripcion;
                txtPrecio.Text = producto.Precio.ToString();
                txtUrl.Text = producto.UrlImagen;

                cmbCategoria.SelectedValue = producto.Categoria.Id;
                cmbMarca.SelectedValue = producto.Marca.Id;

                Text = "Modificar";
            }
        }
        /// cierra la ventana con la funcion close
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// se crea un objeto producto donde se van a cargar todos los campos necesarios y se manda el objeto como parametro 
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Producto nuevo = new Producto();
            ProductoNegocio negocio = new ProductoNegocio();
            try
            {
                nuevo.Codigo = txtCodigo.Text;
                nuevo.Nombre = txtNombre.Text;
                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.UrlImagen = txtUrl.Text;
                nuevo.Precio = decimal.Parse(txtPrecio.Text);
                //se selecciona el item, hay casteado en la clase correspondiente porque sino solo lo toma como la clase objeto
                nuevo.Marca = (Marca) cmbMarca.SelectedItem;
                nuevo.Categoria = (Categoria)cmbCategoria.SelectedItem;

                negocio.agregar(nuevo);

                MessageBox.Show("Agregado");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 59) && e.KeyChar != 8)
                e.Handled = true;
        }
    }
}
