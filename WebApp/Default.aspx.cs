using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Editora.DataAccess;
using System.Data;
using System.IO;

namespace WebApp
{
    public partial class Default : System.Web.UI.Page
    {
        private DataSet getDataSet()
        {
            if (Cache["ds"] == null)
            {
                var ctx = new Repository();
                Cache["ds"] = ctx.SelectDataSet();
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

        private DataSet getXMLDataset()
        {
            var fn = Server.MapPath(@"~/dados.xml");
            var ds = new DataSet();
            if (File.Exists(fn))
            {
                ds.ReadXml(fn);
            }
            else
            {
                var ctx = new Repository();
                ds = ctx.SelectDataSet();
                ds.WriteXml(fn);
            }
            return ds;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var ctx = new Repository();
                var dados = ctx.SelectFike();
                GridView1.DataSource = dados;
                GridView1.DataBind();
               
            }
        }
    }
}