using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RodaARodaIvanaids.publico
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.DALUsuario.AcessoPublico();
        }

        protected void btnLogar_Click(object sender, EventArgs e)
        {
            DAL.DALUsuario.Login(txtCpf.Value, txtMatricula.Value);
        }
    }
}