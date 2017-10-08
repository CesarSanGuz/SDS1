using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using WebAppKaraoke.Dominios;

namespace WebAppKaraoke.View
{
    public partial class Vista_Venta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RadComboBoxItem itemCB = new RadComboBoxItem();
                itemCB.Text = "-Seleccione Opción Producto";
                itemCB.Value = "Seleccione Opción Producto";
                cbxTipoProducto.Items.Add(itemCB);

                RadComboBoxItem itemCP = new RadComboBoxItem();
                itemCP.Text = "-Seleccione Opción Producto-";
                itemCP.Value = "Seleccione Opción Producto";
                cbxProducto.Items.Add(itemCP);
            }
        }
        protected void RadImageCocteles_Click(object sender, EventArgs e)
        {
            Session["tiposeleccionad"] = "1";
            lblTipProdcuto.Text = "Tipo Bebida";
            lblProducto.Text = "Bebida";
            JavaScriptSerializer js = new JavaScriptSerializer();
            productos indec = new productos()
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
            List<productos> indicadorrespuesta = js.Deserialize<List<productos>>(tramajson);

            cbxProducto.Items.Clear();
            cbxTipoProducto.Items.Clear();
            foreach (productos ca in indicadorrespuesta)
            {
                RadComboBoxItem itemCB = new RadComboBoxItem();
                itemCB.Text = ca.desctipoProducto;
                itemCB.Value = ca.tipoProducto + "";
                cbxTipoProducto.Items.Add(itemCB);
            }

            productos indece = new productos()
            {
                productoGeneral = Convert.ToInt16((string)Session["tiposeleccionad"]),
                tipoProducto = Convert.ToInt16(cbxTipoProducto.SelectedValue),
                //tipoProducto = Convert.ToInt16("2"),
            };
            postdata = js.Serialize(indece);
            data = Encoding.UTF8.GetBytes(postdata);
            request = (HttpWebRequest)WebRequest.Create("http://localhost:50548/Producto.svc/Producto");
            request.Method = "POST";
            request.ContentLength = data.Length;
            request.ContentType = "application/json";
            requestStream = request.GetRequestStream();
            requestStream.Write(data, 0, data.Length);
            response = (HttpWebResponse)request.GetResponse();
            reader = new StreamReader(response.GetResponseStream());
            tramajson = reader.ReadToEnd();
            indicadorrespuesta = js.Deserialize<List<productos>>(tramajson);

            cbxProducto.Items.Clear();
            foreach (productos ca in indicadorrespuesta)
            {
                RadComboBoxItem itemCB = new RadComboBoxItem();
                itemCB.Text = ca.descProducto;
                itemCB.Value = ca.producto + "";
                cbxProducto.Items.Add(itemCB);
            }
        }
        protected void RadComboBox1_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            productos indec = new productos()
            {
                productoGeneral = Convert.ToInt16((string)Session["tiposeleccionad"]),
                tipoProducto = Convert.ToInt16(cbxTipoProducto.SelectedValue),
                //tipoProducto = Convert.ToInt16("2"),
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
            List<productos> indicadorrespuesta = js.Deserialize<List<productos>>(tramajson);
            
            cbxProducto.Items.Clear();
            foreach (productos ca in indicadorrespuesta)
            {
                RadComboBoxItem itemCB = new RadComboBoxItem();
                itemCB.Text = ca.descProducto;
                itemCB.Value = ca.producto + "";
                cbxProducto.Items.Add(itemCB);
            }
        }
        protected void RadImageEntradas_Click(object sender, EventArgs e)
        {
            Session["tiposeleccionad"] = "2";
            lblTipProdcuto.Text = "Tipo Plato";
            lblProducto.Text = "Plato";
            JavaScriptSerializer js = new JavaScriptSerializer();
            productos indec = new productos()
            {
                productoGeneral = 2,
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
            List<productos> indicadorrespuesta = js.Deserialize<List<productos>>(tramajson);

            cbxProducto.Items.Clear();
            cbxTipoProducto.Items.Clear();
            foreach (productos ca in indicadorrespuesta)
            {
                RadComboBoxItem itemCB = new RadComboBoxItem();
                itemCB.Text = ca.desctipoProducto;
                itemCB.Value = ca.tipoProducto + "";
                cbxTipoProducto.Items.Add(itemCB);
            }


            productos indece = new productos()
            {
                productoGeneral = Convert.ToInt16((string)Session["tiposeleccionad"]),
                tipoProducto = Convert.ToInt16(cbxTipoProducto.SelectedValue),
                //tipoProducto = Convert.ToInt16("2"),
            };
            postdata = js.Serialize(indece);
            data = Encoding.UTF8.GetBytes(postdata);
            request = (HttpWebRequest)WebRequest.Create("http://localhost:50548/Producto.svc/Producto");
            request.Method = "POST";
            request.ContentLength = data.Length;
            request.ContentType = "application/json";
            requestStream = request.GetRequestStream();
            requestStream.Write(data, 0, data.Length);
            response = (HttpWebResponse)request.GetResponse();
            reader = new StreamReader(response.GetResponseStream());
            tramajson = reader.ReadToEnd();
            indicadorrespuesta = js.Deserialize<List<productos>>(tramajson);

            cbxProducto.Items.Clear();
            foreach (productos ca in indicadorrespuesta)
            {
                RadComboBoxItem itemCB = new RadComboBoxItem();
                itemCB.Text = ca.descProducto;
                itemCB.Value = ca.producto + "";
                cbxProducto.Items.Add(itemCB);
            }
        }
        protected void Comprar_Click(object sender, EventArgs e)
        {
            if ((string)Session["tiposeleccionad"] == "" || cbxTipoProducto.SelectedValue == "Seleccione Opción Producto"
                || txtCantidad.Text == "" || cbxProducto.SelectedValue == "Seleccione Opción Producto" || txtPreUnit.Text=="")
            {
                lblError.Text = "Ingrese todos los campos requeridos";
                lblExito.Text = "";
            }
            else
            {
                try
                {
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    productos indece = new productos()
                    {
                        productoGeneral = Convert.ToInt16((string)Session["tiposeleccionad"]),
                        tipoProducto = Convert.ToInt16(cbxTipoProducto.SelectedValue),
                        cantidad = Convert.ToInt16(txtCantidad.Text),
                        mesa = Convert.ToInt16(txtMesa.Text),
                        producto = Convert.ToInt16(cbxProducto.SelectedValue),
                        precioUnit = Convert.ToDecimal(txtPreUnit.Text),
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
                    string repsuesta = js.Deserialize<string>(tramajson);
                    if(repsuesta == "Registro exitoso")
                    {
                        lblExito.Text = repsuesta;
                        lblError.Text = "";
                        cbxTipoProducto.SelectedIndex = 0;
                        cbxProducto.SelectedIndex = 0;
                        txtCantidad.Text = "0";
                        txtMesa.Text = "0";
                        txtPreUnit.Text = "0.00";
                    }
                    else
                    {
                        lblExito.Text = "";
                        lblError.Text = repsuesta;
                    }
                }
                catch (Exception ex)
                {
                    lblExito.Text = "";
                    lblError.Text = "Error: "+ex;
                }
            }
            
        }
        protected void Cancelar_Click(object sender, EventArgs e)
        {
            cbxTipoProducto.SelectedIndex = 0;
            cbxProducto.SelectedIndex = 0;
            txtCantidad.Text = "0";
            txtMesa.Text = "0";
            txtPreUnit.Text = "0.00";
        }
    }
}