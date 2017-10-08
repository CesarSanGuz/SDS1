using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfServiceRest.Dominio
{
    [DataContract]
    public class productos
    {
        [DataMember]
        public int productoGeneral { get; set; }
        [DataMember]
        public string descproductoGeneral { get; set; }
        [DataMember]
        public int tipoProducto { get; set; }
        [DataMember]
        public string desctipoProducto { get; set; }
        [DataMember]
        public int producto { get; set; }
        [DataMember]
        public string descProducto { get; set; }
        [DataMember]
        public int mesa { get; set; }
        [DataMember]
        public Decimal cantidad { get; set; }
        [DataMember]
        public Decimal precioUnit { get; set; }
    }
}