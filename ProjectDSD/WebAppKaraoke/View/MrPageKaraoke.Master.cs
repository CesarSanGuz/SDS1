using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppKaraoke.View
{
    public partial class MrPageKaraoke : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Salir_Click(object sender, EventArgs e)
        {
            Response.Redirect("../View/Vista_Venta.aspx");
        }
    }
}