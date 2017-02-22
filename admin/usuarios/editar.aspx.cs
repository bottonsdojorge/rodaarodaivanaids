using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RodaARodaIvanaids.admin.usuarios
{
    public partial class editar : System.Web.UI.Page
    {
        private Model.Usuario _u;
        public Model.Usuario u
        {
            get { return _u; }
            set { _u = value; }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                u = DAL.DALUsuario.Select(Convert.ToInt32(Request.QueryString["uid"]));
                Session["u"] = u;
                try
                {
                    if (u.matricula != "")
                    {
                        txtCpf.Value = u.cpf;
                        txtMatricula.Value = u.matricula;
                        txtNome.Value = u.nome;
                        checkAdmin.Checked = u.admin;
                    }
                    else
                    {
                        formEdicao.InnerHtml = "<p class='text-alert'>Não foi possível carregar usuário</p>";
                    }
                }
                catch (Exception)
                {
                    Response.Write("Ocorreu um erro ao carregar o usuário");
                }
            }
            else
            {
                u = (Model.Usuario)Session["u"];
            }
        }

        protected void btnAtualizar_Click(object sender, EventArgs e)
        {
            u.admin = checkAdmin.Checked;
            u.nome = txtNome.Value;
            u.matricula = txtMatricula.Value;
            u.cpf = txtCpf.Value;
            DAL.DALUsuario.Update(u);
            Response.Redirect("~/admin/usuarios/ver.aspx");
        }
    }
}