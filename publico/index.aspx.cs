using RodaARodaIvanaids.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RodaARodaIvanaids.publico
{
	public partial class index : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            if (Request.QueryString["uid"] != null)
            {
                Usuario u = DAL.DALUsuario.Select(Convert.ToInt32(Session["idautenticado"]));
                Sorteio s = DAL.DALSorteio.Select(Convert.ToInt32(Request.QueryString["uid"]));
                s.InscreverUsuario(u);
                DAL.DALSorteio.InsertUsuario(u, s.id);
            }
		}
	}
}