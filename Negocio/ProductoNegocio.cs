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

            Datos.setearConsulta("select A.Id Id,Codigo,Nombre,A.Descripcion Descripcion,ImagenUrl,M.Descripcion Marca,M.ID IDMarca ,C.Descripcion Categoria,C.ID IDCategoria ,Precio from ARTICULOS A, CATEGORIAS C, Marcas M Where A.IdCategoria = C.Id and A.IdMarca = M.Id");
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

                    aux.Marca = new Marca((int)Datos.Lector["IDMarca"],(string) Datos.Lector["Marca"]);
                    
                    aux.Categoria = new Categoria((int)Datos.Lector["IDCategoria"],(string)Datos.Lector["Categoria"]);

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

        ///recibe de parametro un obeto de producto ya cargado con los campos completos desde el formulario agregar
        ///se pasan los valores y se setea la query
        public void agregar(Producto nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT Into Articulos (Codigo,Nombre,Descripcion,Precio,ImagenUrl,IdMarca,IdCategoria) " +
                                   "values (@Codigo,@Nombre,@Descripcion,@Precio,@ImagenUrl,@IdMarca,@IdCategoria)");

                datos.agregarParametro("@Codigo", nuevo.Codigo);
                datos.agregarParametro("@Nombre", nuevo.Nombre);
                datos.agregarParametro("@Descripcion", nuevo.Descripcion);
                datos.agregarParametro("@IdMarca", nuevo.Marca.Id);
                datos.agregarParametro("@IdCategoria", nuevo.Categoria.Id);
                datos.agregarParametro("@ImagenUrl", nuevo.UrlImagen);
                datos.agregarParametro("@Precio", nuevo.Precio);
                

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


        public void Modificar(Producto modificar)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Articulos Set Codigo=@Codigo,Nombre=@Nombre,Descripcion=@Descripcion," +
                                   "IdMarca=@IdMarca,IdCategoria=@IdCategoria,ImagenUrl=@ImagenUrl,Precio=@Precio Where Id=@Id");


                datos.agregarParametro("@Codigo", modificar.Codigo);
                datos.agregarParametro("@Nombre", modificar.Nombre);
                datos.agregarParametro("@Descripcion", modificar.Descripcion);
                datos.agregarParametro("@IdMarca", modificar.Marca.Id);
                datos.agregarParametro("@IdCategoria", modificar.Categoria.Id);
                datos.agregarParametro("@ImagenUrl", modificar.UrlImagen);
                datos.agregarParametro("@Precio", modificar.Precio);
                datos.agregarParametro("@Id", modificar.Id);
                datos.ejectutarAccion();

            }
            catch (Exception)
            {

                throw;
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
