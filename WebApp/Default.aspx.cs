using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Editora.DataAccess;

namespace WebApp
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var ctx = new Repository();
                var ds = ctx.Select();
                GridView1.DataSource = ds;
                GridView1.DataBind();
                //dr.Close();
            }
        }
    }
}