using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WcfServiceRest.Dominio;

namespace WcfServiceRest
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IProducto" in both code and config file together.
    [ServiceContract]
    public interface IProducto
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Producto", ResponseFormat = WebMessageFormat.Json)]
        List<productos> GetProductos(productos pr);


        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Producto", ResponseFormat = WebMessageFormat.Json)]
        List<productos> ListadoStock();
    }
}
