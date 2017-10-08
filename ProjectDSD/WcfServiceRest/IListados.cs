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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IListados" in both code and config file together.
    [ServiceContract]
    public interface IListados
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "TiposProducto", ResponseFormat = WebMessageFormat.Json)]
        List<productos> GetTiposProductos(productos pr);

    }
}
