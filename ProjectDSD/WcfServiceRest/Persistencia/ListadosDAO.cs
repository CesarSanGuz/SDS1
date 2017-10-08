using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Messaging;
using System.Web;
using WcfServiceRest.Dominio;

namespace WcfServiceRest.Persistencia
{
    public class ListadosDAO
    {
        #region no se usa
        //public List<productos> productosGenerales()
        //{
        //    List<productos> listado = new List<productos>();
        //    try
        //    {
        //        #region Consulta a BD
        //        string cadenaConexion = "Data Source=localhost;Integrated Security=SSPI;Initial Catalog=pcDos;";

        //        string sql = "select DISTINCT pr_tipoProductoGeneral,pr_descTipProductoGeneral from producto";
        //        productos encontrado = null;
        //        using (SqlConnection conexion = new SqlConnection(cadenaConexion))
        //        {
        //            conexion.Open();
        //            using (SqlCommand comando = new SqlCommand(sql, conexion))
        //            {
        //                using (SqlDataReader resultad = comando.ExecuteReader())
        //                {
        //                    while (resultad.Read())
        //                    {
        //                        encontrado = new productos()
        //                        {
        //                            descGeneral = (string)resultad["pr_descTipProductoGeneral"],
        //                            productoGeneral = (int)resultad["pr_tipoProductoGeneral"],
        //                        };
        //                        listado.Add(encontrado);
        //                    }
        //                }
        //            }
        //        }
        //        #endregion
        //        return listado;
        //    }
        //    catch (Exception ex)
        //    {
        //        productos encontrado = new productos();
        //        encontrado.descGeneral = "Error: " + ex;
        //        listado.Add(encontrado);
        //        return listado;
        //    }
        //}
        #endregion
        public List<productos> productosporTipo(productos pr)
        {
            List<productos> listado = new List<productos>();
            try
            {
                #region Consulta a BD
                string cadenaConexion = "Data Source=localhost;Integrated Security=SSPI;Initial Catalog=projectSDS;";

                string sql = "select DISTINCT pr_tipoProducto,pr_descTipProducto from producto where pr_tipoProductoGeneral = @productoGeneral";
                productos encontrado = null;
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(sql, conexion))
                    {
                        comando.Parameters.Add(new SqlParameter("@productoGeneral", Convert.ToInt16(pr.productoGeneral)));
                        using (SqlDataReader resultad = comando.ExecuteReader())
                        {
                            while (resultad.Read())
                            {
                                encontrado = new productos()
                                {
                                    descProducto = "",
                                    producto = 0,
                                    desctipoProducto = (string)resultad["pr_descTipProducto"],
                                    tipoProducto = (int)resultad["pr_tipoProducto"],
                                };
                                listado.Add(encontrado);
                            }
                        }
                    }
                }
                #endregion
                return listado;
            }
            catch (Exception ex)
            {
                productos encontrado = new productos();
                encontrado.desctipoProducto = "Error: " + ex;
                listado.Add(encontrado);
                return listado;
            }
        }
        public List<productos> productos(productos pr)
        {
            List<productos> listado = new List<productos>();
            try
            {
                #region Consulta a BD
                string cadenaConexion = "Data Source=localhost;Integrated Security=SSPI;Initial Catalog=projectSDS;";

                string sql = "select DISTINCT pr_producto,pr_descProducto from producto where pr_tipoProductoGeneral = @productoGeneral and pr_tipoProducto = @tipoProducto";
                productos encontrado = null;
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(sql, conexion))
                    {
                        comando.Parameters.Add(new SqlParameter("@productoGeneral", Convert.ToInt16(pr.productoGeneral)));
                        comando.Parameters.Add(new SqlParameter("@tipoProducto", Convert.ToInt16(pr.tipoProducto)));
                        using (SqlDataReader resultad = comando.ExecuteReader())
                        {
                            while (resultad.Read())
                            {
                                encontrado = new productos()
                                {
                                    descProducto = (string)resultad["pr_descProducto"],
                                    producto = (int)resultad["pr_producto"],
                                    tipoProducto = 0,
                                    desctipoProducto = "",
                                };
                                listado.Add(encontrado);
                            }
                        }
                    }
                }
                #endregion
                return listado;
            }
            catch (Exception ex)
            {
                productos encontrado = new productos();
                encontrado.desctipoProducto = "Error: " + ex;
                listado.Add(encontrado);
                return listado;
            }
        }

        public string regIndicador(productos regInd)
        {
            try
            {
                string cadenaConexion = "Data Source=localhost;Integrated Security=SSPI;Initial Catalog=projectSDS;";

                #region Registro a BD
                string sql = "INSERT INTO [dbo].[venta] VALUES (@mesa, @total)";

                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    Decimal suma = regInd.precioUnit * regInd.cantidad;

                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(sql, conexion))
                    {
                        comando.Parameters.Add(new SqlParameter("@mesa", regInd.mesa));
                        comando.Parameters.Add(new SqlParameter("@total", suma));
                        comando.ExecuteNonQuery();
                    }
                }
                #endregion

                #region Update a BD
                string sql3 = "update producto set pr_cantStock = pr_cantStock-@pr_cantStock where pr_tipoProductoGeneral = @idGen and pr_tipoProducto = @idTipProd and pr_producto = @idproducto";

                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(sql3, conexion))
                    {
                        comando.Parameters.Add(new SqlParameter("@pr_cantStock", regInd.cantidad));
                        comando.Parameters.Add(new SqlParameter("@idGen", regInd.productoGeneral));
                        comando.Parameters.Add(new SqlParameter("@idTipProd", regInd.tipoProducto));
                        comando.Parameters.Add(new SqlParameter("@idproducto", regInd.producto));
                        comando.ExecuteNonQuery();
                    }
                }
                #endregion

                #region Registro a MQ

                string rutaCOla = @".\private$\CSanchez";
                if (!MessageQueue.Exists(rutaCOla))
                    MessageQueue.Create(rutaCOla);
                MessageQueue cola = new MessageQueue(rutaCOla);
                Message mensaje = new Message();

                List<productos> listado = new List<productos>();

                string sql2 = "select pr_descTipProducto, pr_descProducto, pr_cantStock from producto";
                productos encontrado = null;
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(sql2, conexion))
                    {
                        using (SqlDataReader resultad = comando.ExecuteReader())
                        {
                            while (resultad.Read())
                            {
                                encontrado = new productos()
                                {
                                    desctipoProducto = (string)resultad["pr_descTipProducto"],
                                    descProducto = (string)resultad["pr_descProducto"],
                                    //descProducto = "dasd",
                                    cantidad = (Decimal)resultad["pr_cantStock"],
                                    //cantidad = 0,
                                };
                                listado.Add(encontrado);
                            }
                        }
                    }
                }
                mensaje.Label = ""+DateTime.Today;
                mensaje.Body = listado;
                cola.Send(mensaje);
                #endregion

                return "Registro exitoso";
            }
            catch (Exception ex)
            {
                return "Error> " + ex;
            }
        }

        public List<productos> listadoStock()
        {
            List<productos> encontrados = new List<productos>();
            try
            {

                string rutaCOla = @".\private$\CSanchez";
                if (!MessageQueue.Exists(rutaCOla))
                    MessageQueue.Create(rutaCOla);
                MessageQueue cola = new MessageQueue(rutaCOla);
                cola.Formatter = new XmlMessageFormatter(new Type[] { typeof(List<productos>) });
                Message[] mensaje = cola.GetAllMessages();

                foreach (Message msg in mensaje)
                {
                    try
                    {
                        if (msg.Label == ""+DateTime.Today)
                        {
                            encontrados.Clear();
                            List<productos> prds = (List<productos>)msg.Body;
                            foreach (productos dd in prds)
                            {
                                encontrados.Add(dd);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }
                if (encontrados == null)
                {
                    foreach (Message msg in mensaje)
                    {
                        try
                        {
                            if (msg.Label == ""+DateTime.Today.AddDays(-1))
                            {
                                List<productos> prds = (List<productos>)msg.Body;
                                foreach (productos dd in prds)
                                {
                                    encontrados.Add(dd);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                if (encontrados == null)
                {
                    productos das = new productos();
                    das.descProducto = "No se encontraron Datos.";
                    encontrados.Add(das);
                    return encontrados;
                }
                return encontrados;
            }
            catch (Exception ex)
            {
                productos das = new productos();
                das.descProducto = "Error> " + ex;
                encontrados.Add(das);
                return encontrados;
            }
        }
    }
}