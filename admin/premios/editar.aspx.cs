using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RodaARodaIvanaids.admin.premios
{
    public partial class editar : System.Web.UI.Page
    {
        private Model.Premio _u;
        public Model.Premio u
        {
            get { return _u; }
            set { _u = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                u = DAL.DALPremio.Select(Convert.ToInt32(Request.QueryString["uid"]));
                Session["u"] = u;
                try
                {
                    if (u.nome != "")
                    {
                        txtNome.Value = u.nome;
                        txtDescricao.Value = u.descricao;
                    }
                    else
                    {
                        formEdicao.InnerHtml = "<p class='text-alert'>Não foi possível carregar o prêmio</p>";
                    }
                }
                catch (Exception)
                {
                    Response.Write("Ocorreu um erro ao carregar o prêmio");
                }
            }
            else
            {
                u = (Model.Premio)Session["u"];
            }
        }

        protected void btnAtualizar_Click(object sender, EventArgs e)
        {
            u.nome = txtNome.Value;
            u.descricao = txtDescricao.Value;
            DAL.DALPremio.Update(u);
            Response.Redirect("~/admin/premios/ver.aspx");
        }
    }
}