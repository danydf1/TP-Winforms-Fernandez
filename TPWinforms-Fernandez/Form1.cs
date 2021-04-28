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
using Negocio;

namespace TPWinforms_Fernandez
{
    public partial class Form1 : Form
    {
        private List<Producto> listaProducto;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        /// se encarga de cargar la grilla del data grid view se intantancia un objeto negocio
        /// lista producto es una variable del tipo lista global que recibe la lista leida en la clase negocioProductos
        /// dgv datasource dibuja las columnas con los datos de lista obtenida
        /// 
        /// no devuelve nada
        private void Cargar()
        {
            ProductoNegocio negocio = new ProductoNegocio();

            try
            {
                listaProducto = negocio.Listar();
                dgvProductos.DataSource = listaProducto;

                dgvProductos.Columns["Id"].Visible = false;
                dgvProductos.Columns["UrlImagen"].Visible = false;

            }
            catch (Exception)
            {

                throw;
            }
        }

        /// Recargar el link que esta recibiendo desde el dgv y lo muestra en este caso una imagen en el pictureBox
        /// si no puede mostrar la imagen da el error
        private void RecargarImg(string img)
        {
            try
            {
                pictureBox.Load(img);
            }
            catch (Exception)
            {

                MessageBox.Show("No se encontro Imagen");
            }
            
        }

        /// Se selecciona de una fila y se cargan los datos en la variable producto
        /// donde ya se puede obtener el contenido de cualquier propiedad publica con el dataBoundItem
        private void dgvProductos_MouseClick(object sender, MouseEventArgs e)
        {

                Producto producto = (Producto)dgvProductos.CurrentRow.DataBoundItem;
                RecargarImg(producto.UrlImagen);
        }

        /// se despliega el formulario para agregar un nuevo producto

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Agregar agregar = new Agregar();

            agregar.ShowDialog();
            
            Cargar();
        }

        /// Del elemto seleccionado desde el dgv lanza un messageBox de seguridad si se confirma borra el registro
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            
            ProductoNegocio negocio = new ProductoNegocio();
            Producto producto = (Producto)dgvProductos.CurrentRow.DataBoundItem;
            
          

            if (MessageBox.Show("Esta Seguro?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                negocio.Eliminar(producto.Id);

                MessageBox.Show("elmininado correctamente");
                Cargar();
            }
            else
            {
                Cargar();
            }

        }
    }
}
