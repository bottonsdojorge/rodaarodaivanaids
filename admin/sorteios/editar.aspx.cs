using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RodaARodaIvanaids.admin.sorteios
{
    public partial class editar : System.Web.UI.Page
    {
        private Model.Sorteio _u;
        public Model.Sorteio u
        {
            get { return _u; }
            set { _u = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                u = DAL.DALSorteio.Select(Convert.ToInt32(Request.QueryString["uid"]));
                Session["u"] = u;
                try
                {
                    if (u.descricao != "")
                    {
                        txtDescricao.Value = u.descricao;
                        txtData.Value = u.data.ToString();
                        txtNome.Value = u.nome;
                    }
                    else
                    {
                        formEdicao.InnerHtml = "<p class='text-alert'>Não foi possível carregar sorteio</p>";
                    }
                }
                catch (Exception)
                {
                    Response.Write("Ocorreu um erro ao carregar o usuário");
                }
            }
            else
            {
                u = (Model.Sorteio)Session["u"];
            }
        }

        protected void btnAtualizar_Click(object sender, EventArgs e)
        {
            u.nome = txtNome.Value;
            u.data = Convert.ToDateTime(txtData.Value);
            u.descricao = txtDescricao.Value;
            u.premios = new List<Model.PremioSorteio>();
            foreach (ListItem premio in selectPremios.Items)
            {
                if (premio.Selected)
                {
                    u.AdicionarPremio(DAL.DALPremio.Select(Convert.ToInt32(premio.Value)));
                }
            }
            DAL.DALSorteio.Update(u);
            Response.Redirect("~/admin/sorteios/ver.aspx");
        }
    }
}