using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;

namespace Editora.DataAccess
{
    //OPERAÇÕES CRUD
    public class Repository
    {
        public SqlDataReader SelectDataReader()
        {
            var constr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EDITORA;Integrated Security=True";
            var con = new SqlConnection(constr);
            con.Open();
            var SQL = "SELECT [NUM_EDICAO], [CAPA], [NIVEL] FROM [REVISTAS] ORDER BY [NUM_EDICAO]";
            var cmd = new SqlCommand(SQL, con);
            var dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return dr;
        }

        public DataSet SelectDataSet()
        {
            var constr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EDITORA;Integrated Security=True";
            var con = new SqlConnection(constr);
            var SQL = "SELECT [NUM_EDICAO], [CAPA], [NIVEL] FROM [REVISTAS] ORDER BY [NUM_EDICAO]";
            var cmd = new SqlCommand(SQL, con);
            var da = new SqlDataAdapter(cmd);
            var ds = new DataSet("Dados");
            da.Fill(ds);
            return ds;

        }
    }
}