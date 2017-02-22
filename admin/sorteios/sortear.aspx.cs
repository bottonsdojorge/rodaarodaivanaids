using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RodaARodaIvanaids.admin.sorteios
{
    public partial class sortear : System.Web.UI.Page
    {
        private Model.Sorteio _s;
        public Model.Sorteio s
        {
            get { return _s; }
            set { _s = value; }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                s = DAL.DALSorteio.Select(Convert.ToInt32(Request.QueryString["uid"]));
                Session["s"] = s;
            }
            else
            {
                s = (Model.Sorteio)Session["s"];
            }
            if (!s.sorteado)
            {
                s.Sortear();
                s = DAL.DALSorteio.Select(s.id);
            }
        }
    }
}