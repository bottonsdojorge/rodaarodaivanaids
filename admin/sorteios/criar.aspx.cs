using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RodaARodaIvanaids.admin.sorteios
{
    public partial class criar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnCadastras_Click(object sender, EventArgs e)
        {
            Model.Sorteio u = new Model.Sorteio();
            u.nome = txtNome.Value;
            u.data = Convert.ToDateTime(txtData.Value);
            u.descricao = txtDescricao.Value;
            u.id = DAL.DALSorteio.Insert(u);
            foreach (ListItem premio in selectPremios.Items)
            {
                if (premio.Selected)
                {
                    u.AdicionarPremio(DAL.DALPremio.Select(Convert.ToInt32(premio.Value)));
                }
            }
            Response.Redirect("~/admin/premios/ver.aspx");
        }
    }
}