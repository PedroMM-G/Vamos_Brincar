using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;
using Vamos_Brincar.Models;
namespace Vamos_Brincar.Models
{
    public class CrudImplementation
    {
        public List<CrudProp> GetAti()
        {
            List < CrudProp > ListaAtividade = new List<CrudProp>();
            string mainconn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mysqlconn = new MySqlConnection(mainconn);
            string sqlquery = "select * from atividade";
            MySqlCommand sqlcomm = new MySqlCommand(sqlquery, mysqlconn);
            mysqlconn.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(sqlcomm);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mysqlconn.Close();
            foreach(DataRow dr in dt.Rows)
            {
                ListaAtividade.Add(new CrudProp {
                    id_atividade = Convert.ToInt32(dr["id_atividade"]),
                    nome = Convert.ToString(dr["nome"]),
                    //data_at = Convert.ToDateTime(dr["data_at"]),
                    descricao = Convert.ToString(dr["descricao"]),
                    avaliacao = Convert.ToInt32(dr["avaliacao"]),
                }
                );
            }
 
            return ListaAtividade;
        }
        public bool insertAti (CrudProp atiInsert)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mysqlconn = new MySqlConnection(mainconn);
            string sqlquery = "insert into atividade (nome, descricao ,avaliacao) values ('"+ atiInsert.nome+ "','" + atiInsert.descricao + "','" + atiInsert.avaliacao + "') ";
            MySqlCommand sqlcomm = new MySqlCommand(sqlquery, mysqlconn);
            mysqlconn.Open();
            int i = sqlcomm.ExecuteNonQuery();
            mysqlconn.Close();
            if (i>= 1)
            {
                return true;

            }
            else
            {
                return false;
            }   
        }
        public bool editAti(CrudProp atiEdit)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mysqlconn = new MySqlConnection(mainconn);
            string sqlquery = "update crianca set nome='" + atiEdit.nome + "'where id_crianca='" + atiEdit.id_atividade + "'";
            MySqlCommand sqlcomm = new MySqlCommand(sqlquery, mysqlconn);
            mysqlconn.Open();
            int i = sqlcomm.ExecuteNonQuery();
            mysqlconn.Close();
            if (i >= 1)
            {
                return true;

            }
            else
            {
                return false;
            }
        }
    }
}