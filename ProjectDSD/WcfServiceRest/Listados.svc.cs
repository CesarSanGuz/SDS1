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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Listados" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Listados.svc or Listados.svc.cs at the Solution Explorer and start debugging.
    public class Listados : IListados
    {
        private ListadosDAO listadoDAO = new ListadosDAO();

        public List<productos> GetTiposProductos(productos pr)
        {
            try
            {
                return listadoDAO.productosporTipo(pr);
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
