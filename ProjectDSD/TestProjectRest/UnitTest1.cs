using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Script.Serialization;
using System.Text;
using System.Net;
using System.IO;
using System.Collections.Generic;
namespace TestProjectRest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestPostTiposProductos()
        {
            string respEsperada = "Corto";
            JavaScriptSerializer js = new JavaScriptSerializer();
            campos indec = new campos()
            {
                productoGeneral = 1,
            };
            string postdata = js.Serialize(indec);
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:50548/Listados.svc/TiposProducto");
            request.Method = "POST";
            request.ContentLength = data.Length;
            request.ContentType = "application/json";
            var requestStream = request.GetRequestStream();
            requestStream.Write(data, 0, data.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string tramajson = reader.ReadToEnd();
            List<campos> indicadorrespuesta = js.Deserialize<List<campos>>(tramajson);
            string desctipoProducto = "";
            foreach (campos ca in indicadorrespuesta)
            {
                desctipoProducto = ca.desctipoProducto;
            }
            Assert.AreEqual(desctipoProducto, respEsperada);
        }

        [TestMethod]
        public void TestPostProductos()
        {
                string respEsperada = "Ron";
                JavaScriptSerializer js = new JavaScriptSerializer();
                campos indec = new campos()
                {
                    productoGeneral = 1,
                    tipoProducto = 2,
                };
                string postdata = js.Serialize(indec);
                byte[] data = Encoding.UTF8.GetBytes(postdata);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:50548/Producto.svc/Producto");
                request.Method = "POST";
                request.ContentLength = data.Length;
                request.ContentType = "application/json";
                var requestStream = request.GetRequestStream();
                requestStream.Write(data, 0, data.Length);

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string tramajson = reader.ReadToEnd();
                List<campos> indicadorrespuesta = js.Deserialize<List<campos>>(tramajson);
                string desctipoProducto = "";
                foreach (campos ca in indicadorrespuesta)
                {
                    desctipoProducto = ca.descProducto;
                }
                Assert.AreEqual(desctipoProducto, respEsperada);
        }

        [TestMethod]
        public void TestPostRegistro()
        {
            string respEsperada = "Registro exitoso";
            JavaScriptSerializer js = new JavaScriptSerializer();
            campos indece = new campos()
            {
                productoGeneral = 1,
                tipoProducto = 2,
                cantidad = 2,
                mesa = 3,
                producto = 1,
                precioUnit = Convert.ToDecimal("12.5"),
            };
            string postdata = js.Serialize(indece);
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:50548/Ventas.svc/Venta");
            request.Method = "POST";
            request.ContentLength = data.Length;
            request.ContentType = "application/json";
            var requestStream = request.GetRequestStream();
            requestStream.Write(data, 0, data.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string tramajson = reader.ReadToEnd();
            //List<productos> indicadorrespuesta = js.Deserialize<List<productos>>(tramajson);
            string repsuestaServicio = js.Deserialize<string>(tramajson);
            Assert.AreEqual(repsuestaServicio, respEsperada);
        }

        [TestMethod]
        public void TestGetStock()
        {
            string respEsperada = "No se encontraron Datos.";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:50548/Producto.svc/Producto");
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string tramajson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<campos> indicadorrespuesta = js.Deserialize<List<campos>>(tramajson);
            foreach (campos cc in indicadorrespuesta)
            {
                string repsuestaObtenida = cc.descProducto;
                Assert.AreEqual(repsuestaObtenida, respEsperada);
            }
        }

    }
}
