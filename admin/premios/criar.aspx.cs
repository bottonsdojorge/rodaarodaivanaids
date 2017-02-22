using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RodaARodaIvanaids.admin.premios
{
    public partial class criar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCadastras_Click(object sender, EventArgs e)
        {
            Model.Premio u = new Model.Premio(0, txtNome.Value, txtDescricao.Value);
            DAL.DALPremio.Insert(u);
            Response.Redirect("~/admin/premios/ver.aspx");
        }
    }
}