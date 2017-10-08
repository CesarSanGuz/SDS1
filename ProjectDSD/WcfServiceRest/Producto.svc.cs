using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfServiceRest.Dominio;
using WcfServiceRest.Errores;
using WcfServiceRest.Persistencia;

namespace WcfServiceRest
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Producto" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Producto.svc or Producto.svc.cs at the Solution Explorer and start debugging.
    public class Producto : IProducto
    {
        private ListadosDAO listadoDAO = new ListadosDAO();


        public List<productos> GetProductos(productos pr)
        {
            try
            {
                return listadoDAO.productos(pr);
            }
            catch (Exception ex)
            {
                throw new FaultException<RepetidoException>(
                    new RepetidoException { codigo = "FatalError", mensaje = "Error: " + ex },
                    new FaultReason("Error en la conversión"));
            }
        }
        public List<productos> ListadoStock()
        {
            try
            {
                return listadoDAO.listadoStock();
            }
            catch (Exception ex)
            {
                throw new FaultException<RepetidoException>(
                    new RepetidoException { codigo = "FatalError", mensaje = "Error: " + ex },
                    new FaultReason("Error en la conversión"));
            }
        }

    }
}
