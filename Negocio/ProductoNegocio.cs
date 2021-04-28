using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;


namespace Negocio
{
    public class ProductoNegocio
    {
        /// Listar
        /// 
        /// Carga la lista atravez de la clase acceso a datos, con el nombre de las columnas del DB
        /// en las propiades a otras clases se selecciona la propiedad y se le instancia la clase correspondiente al asignar
        /// 
        /// retorna una lista 
        public List<Producto> Listar()
        {
            List<Producto> lista = new List<Producto>();
            AccesoDatos Datos = new AccesoDatos();

            Datos.setearConsulta("select A.Id Id,Codigo,Nombre,A.Descripcion Descripcion,ImagenUrl,M.Descripcion Marca,C.Descripcion Categoria,Precio from ARTICULOS A, CATEGORIAS C, Marcas M Where A.IdCategoria = C.Id and A.IdMarca = M.Id");
            Datos.ejecutarLectura();

            try
            {
                while (Datos.Lector.Read())
                {
                    Producto aux = new Producto();

                    aux.Id = (int)Datos.Lector["Id"];
                    aux.Codigo = (string)Datos.Lector["Codigo"];
                    aux.Nombre = (string)Datos.Lector["Nombre"];
                    aux.Descripcion = (string)Datos.Lector["Descripcion"];
                    aux.UrlImagen = (string)Datos.Lector["ImagenUrl"];
                    aux.Precio = (decimal)Datos.Lector["Precio"];

                    aux.Marca = new Marca((string) Datos.Lector["Marca"]);
                    aux.Categoria = new Categoria((string)Datos.Lector["Categoria"]);

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                Datos.cerrarConexion();
            }
            
        }

        public void agregar(Producto nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
               string valores = "values('" + nuevo.Codigo + "', '" + nuevo.Nombre + "', '" + nuevo.Descripcion + "', " +
                                        " '" + nuevo.UrlImagen + "', " + nuevo.Marca.Id + ", "+ nuevo.Categoria.Id+" , "+nuevo.Precio+")";
                datos.setearConsulta("insert into Articulos (Codigo, Nombre, Descripcion, ImagenUrl,  IdMarca, IdCategoria, Precio) " + valores);

                datos.ejectutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        /// Recibe un id que se obtiene desde el form se concatena con la consulta se ejecuta y regresa al form
        public void Eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("delete from ARTICULOS where id = '"+ id +"' ") ;
                datos.ejectutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }

}
