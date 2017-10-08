using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppKaraoke.Dominios
{
    public class productos
    {
        public int productoGeneral { get; set; }
        public string descproductoGeneral { get; set; }
        public int tipoProducto { get; set; }
        public string desctipoProducto { get; set; }
        public int producto { get; set; }
        public string descProducto { get; set; }
        public int mesa { get; set; }
        public int cantidad  { get; set; }
        public Decimal precioUnit { get; set; }
    }
}