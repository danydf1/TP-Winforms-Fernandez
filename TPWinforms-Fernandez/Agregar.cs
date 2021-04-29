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
            try
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
                    nmrPrecio.Text = producto.Precio.ToString();
                    txtUrl.Text = producto.UrlImagen;

                    cmbCategoria.SelectedValue = producto.Categoria.Id;
                    cmbMarca.SelectedValue = producto.Marca.Id;

                    Text = "Modificar";
                }
            }
            catch (Exception ex)
            {

                throw ex;
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
           
            ProductoNegocio negocio = new ProductoNegocio();
            
            try
            {
                if (producto == null)
                    producto = new Producto();

                producto.Codigo = txtCodigo.Text;
                producto.Nombre = txtNombre.Text;
                producto.Descripcion = txtDescripcion.Text;
                producto.UrlImagen = txtUrl.Text;
                producto.Precio = decimal.Parse(nmrPrecio.Value.ToString());
                //se selecciona el item, hay casteado en la clase correspondiente porque sino solo lo toma como la clase objeto
                producto.Marca = (Marca) cmbMarca.SelectedItem;
                producto.Categoria = (Categoria)cmbCategoria.SelectedItem;

                if (producto.Id == 0)
                {
                    if (Verificar(producto))
                    {
                        negocio.agregar(producto);

                        MessageBox.Show("Agregado");
                        Close();
                    }
                }
                else
                {
                    negocio.Modificar(producto);
                    Close();
                }
                    
                
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        private bool Verificar(Producto producto)
        {
            if (producto.Codigo == "")
            {
                txtCodigo.BackColor = Color.Red;
                MessageBox.Show("Ingresar Codigo");
                return false;
            }
            else
            {
                txtCodigo.BackColor = System.Drawing.SystemColors.Control;
            } 
            if (producto.Nombre == "")
            {
                txtNombre.BackColor = Color.Red;
                MessageBox.Show("Ingresar Nombre");
                return false;
            }
            else
            {
                txtNombre.BackColor = System.Drawing.SystemColors.Control;
                
            }
            if (producto.Descripcion == "")
            {
                txtDescripcion.BackColor = Color.Red;
                MessageBox.Show("Ingresar Descripcion");
                return false;
            }     
            else
                txtDescripcion.BackColor = System.Drawing.SystemColors.Control;
            if(producto.Precio == 0)
            {
                nmrPrecio.BackColor = Color.Red;
                MessageBox.Show("El precio debe ser mayor a cero");
                return false;
            }
            else
                nmrPrecio.BackColor = System.Drawing.SystemColors.Control;
            return true;
            
        }

    }
}
