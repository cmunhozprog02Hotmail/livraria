using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Editora.DataAccess;
using System.Data;
using System.IO;
using Editora.Domain;

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
                var dados = ctx.Select();
                GridView1.DataSource = dados;
                GridView1.DataBind();
               
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var ctx = new Repository();
            ctx.Update(new Revista() {NUM_EDICAO = 105, CAPA = "JAVA", NIVEL = 2.75});
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            var ctx = new Repository();
            ctx.Delete(new Revista() { NUM_EDICAO = 105, CAPA = "", NIVEL = 0});
            
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            var ctx = new Repository();
            ctx.Insert(new Revista() { NUM_EDICAO = 105, CAPA = "cordel", NIVEL = 3});
            
        }
    }
}