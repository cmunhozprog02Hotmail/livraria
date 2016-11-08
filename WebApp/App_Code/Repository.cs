using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Editora.Domain;
using System.Configuration;


namespace Editora.DataAccess
{
    //OPERAÇÕES CRUD
    public class Repository
    {
        private SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["EDITORA"].ConnectionString);
        
        public List<Revista> Select()
        {
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

        public void Update(Revista Obj)
        {
            var SQL = "update REVISTAS set CAPA=@CAPA,NIVEL=@NIVEL where NUM_EDICAO=@NUM_EDICAO";
            var cmd = new SqlCommand(SQL, con);
            cmd.Parameters.AddWithValue("@NUM_EDICAO", Obj.NUM_EDICAO);
            cmd.Parameters.AddWithValue("@CAPA", Obj.CAPA);
            cmd.Parameters.AddWithValue("@NIVEL", Obj.NIVEL);
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

        public void Delete(Revista Obj)
        {
            var SQL = "delete REVISTAS where NUM_EDICAO=@NUM_EDICAO";
            var cmd = new SqlCommand(SQL, con);
            cmd.Parameters.AddWithValue("@NUM_EDICAO", Obj.NUM_EDICAO);
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

        public void Insert(Revista Obj)
        {
            var SQL = "insert into REVISTAS(NUM_EDICAO, CAPA, NIVEL) values (@NUM_EDICAO, @CAPA, @NIVEL);";
            var cmd = new SqlCommand(SQL, con);
            cmd.Parameters.AddWithValue("@NUM_EDICAO", Obj.NUM_EDICAO);
            cmd.Parameters.AddWithValue("@CAPA", Obj.CAPA);
            cmd.Parameters.AddWithValue("@NIVEL", Obj.NIVEL);
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

        
    }
}