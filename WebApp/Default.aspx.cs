using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Editora.DataAccess;
using System.Data;

namespace WebApp
{
    public partial class Default : System.Web.UI.Page
    {
        private DataSet getDataSet()
        {
            if (Cache["ds"] == null)
            {
                var ctx = new Repository();
                Cache["ds"] = ctx.Select();
            }
            return Cache["ds"] as DataSet;
        }
        private DataView getDataView()
        {
            var ds = getDataSet();
            var dt = ds.Tables[0];
            var dv = new DataView(dt);
            dv.Sort = "CAPA";
            dv.RowFilter = "NUM_EDICAO > 103";
            return dv;


        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //var ctx = new Repository();
                //var ds = ctx.Select();
                GridView1.DataSource = getDataView();
                GridView1.DataBind();
                //dr.Close();
            }
        }
    }
}