using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfServiceRest.Errores
{
    [DataContract]
    public class RepetidoException
    {
        [DataMember]
        public string codigo { get; set; }

        [DataMember]
        public string mensaje { get; set; }
    }
}