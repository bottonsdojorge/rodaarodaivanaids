using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RodaARodaIvanaids.admin.usuarios
{
    public partial class criar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCadastras_Click(object sender, EventArgs e)
        {
            Model.Usuario u = new Model.Usuario(0, txtNome.Value, txtMatricula.Value, txtCpf.Value, checkAdmin.Checked);
            DAL.DALUsuario.Insert(u);
            Response.Redirect("~/admin/usuarios/ver.aspx");
        }
    }
}