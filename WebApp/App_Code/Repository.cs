using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Editora.Domain;


namespace Editora.DataAccess
{
    //OPERAÇÕES CRUD
    public class Repository
    {

        public List<Revista> Select()
        {
            var constr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EDITORA;Integrated Security=True";
            var con = new SqlConnection(constr);
            var SQL = "select [NUM_EDICAO], [CAPA], [NIVEL] from REVISTAS";
            var cmd = new SqlCommand(SQL, con);
            var lista = new List<Revista>();
            con.Open();
            try
            {
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    var obj = new Revista();
                    obj.NUM_EDICAO = Convert.ToInt32(dr[0]);
                    obj.CAPA = dr[1].ToString();
                    obj.NIVEL = Convert.ToDouble(dr[2]);
                    lista.Add(obj);
                }
                
                con.Close();
            }
            finally
            {
                con.Close();
            }
            return lista;
        }

        public void Update(int NUM_EDICAO, string CAPA, double NIVEL)
        {
            var constr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EDITORA;Integrated Security=True";
            var con = new SqlConnection(constr);
            var SQL = "update REVISTAS set CAPA=@CAPA,NIVEL=@NIVEL where NUM_EDICAO=@NUM_EDICAO";
            var cmd = new SqlCommand(SQL, con);
            cmd.Parameters.AddWithValue("@NUM_EDICAO", NUM_EDICAO);
            cmd.Parameters.AddWithValue("@CAPA", CAPA);
            cmd.Parameters.AddWithValue("@NIVEL", NIVEL);
            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
            

        }

        public void Delete(int NUM_EDICAO, string CAPA, double NIVEL)
        {
            var constr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EDITORA;Integrated Security=True";
            var con = new SqlConnection(constr);
            var SQL = "delete REVISTAS where NUM_EDICAO=@NUM_EDICAO";
            var cmd = new SqlCommand(SQL, con);
            cmd.Parameters.AddWithValue("@NUM_EDICAO", NUM_EDICAO);
            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }

        public void Insert(int NUM_EDICAO, string CAPA, double NIVEL)
        {
            var constr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EDITORA;Integrated Security=True";
            var con = new SqlConnection(constr);
            var SQL = "insert into REVISTAS(NUM_EDICAO, CAPA, NIVEL) values (@NUM_EDICAO, @CAPA, @NIVEL);";
            var cmd = new SqlCommand(SQL, con);
            cmd.Parameters.AddWithValue("@NUM_EDICAO", NUM_EDICAO);
            cmd.Parameters.AddWithValue("@CAPA", CAPA);
            cmd.Parameters.AddWithValue("@NIVEL", NIVEL);
            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }

        public List<Revista> SelectFike()
        {
            var lista = new List<Revista>();
            lista.Add(new Revista(){NUM_EDICAO = 100, CAPA = "Teste1", NIVEL = 1 });
            lista.Add(new Revista(){NUM_EDICAO = 102, CAPA = "Teste2", NIVEL= 2.5});
            return lista;
        }
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