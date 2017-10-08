using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using WebAppKaraoke.Dominios;

namespace WebAppKaraoke.View
{
    public partial class Stock : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //dpFecIni.SelectedDate = DateTime.Today;
            //dpFecFin.SelectedDate = DateTime.Today.AddDays(-7);

        }

        protected void RadGrid1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            RadGrid1.DataSource = GetGridSource();
        }
        protected void RadGrid1_ItemCreated(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
        }
        protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem dataItem = (GridDataItem)e.Item;
                if (Convert.ToDouble(dataItem["CA"].Text) <= 5)
                {
                    dataItem["CA"].BackColor = Color.Red;
                    dataItem["CA"].ForeColor = Color.Black;
                }
                else if (Convert.ToDouble(dataItem["CA"].Text) <= 50)
                {
                    dataItem["CA"].BackColor = Color.Yellow;
                    dataItem["CA"].ForeColor = Color.Black;
                }
                else
                {
                    dataItem["CA"].BackColor = Color.LightGreen;
                    dataItem["CA"].ForeColor = Color.Black;
                }
            }
        }
        private DataTable GetGridSource()
        {
            DataTable dataTable = new DataTable();

            DataColumn column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "TP";
            dataTable.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "PR";
            dataTable.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "CA";
            dataTable.Columns.Add(column);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:50548/Producto.svc/Producto");
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string tramajson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<productos> indicadorrespuesta = js.Deserialize<List<productos>>(tramajson);

            foreach (productos ra in indicadorrespuesta)
            {
                DataRow row = dataTable.NewRow();
                row["TP"] = ra.desctipoProducto;
                row["PR"] = ra.descProducto;
                row["CA"] = ra.cantidad;
                dataTable.Rows.Add(row);
            }
            return dataTable;
        }
        protected void Filtrar_Click(object sender, EventArgs e)
        {
        }
    }
}