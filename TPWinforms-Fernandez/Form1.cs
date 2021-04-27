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



        private void dgvProductos_MouseClick(object sender, MouseEventArgs e)
        {

                Producto producto = (Producto)dgvProductos.CurrentRow.DataBoundItem;
                RecargarImg(producto.UrlImagen);
        }
    }
}
