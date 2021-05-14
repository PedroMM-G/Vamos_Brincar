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
    public class SugestoesImplementation
    {
        public List<SugestoesProp> GetSug()
        {
            List<SugestoesProp> ListaSugestoes = new List<SugestoesProp>();
            string mainconn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mysqlconn = new MySqlConnection(mainconn);
            string sqlquery = "select * from sugestao";
            MySqlCommand sqlcomm = new MySqlCommand(sqlquery, mysqlconn);
            mysqlconn.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(sqlcomm);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mysqlconn.Close();
            foreach (DataRow dr in dt.Rows)
            {
                ListaSugestoes.Add(new SugestoesProp
                {
                    id_sug = Convert.ToInt32(dr["id_sug"]),
                    id_crianca = Convert.ToInt32(dr["id_crianca"]),
                    id_inst = Convert.ToInt32(dr["id_inst"]),
                    sug = Convert.ToString(dr["sug"]),
                }
                );
            }

            return ListaSugestoes;
        }
        public bool insertsug(SugestoesProp suginsert)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mysqlconn = new MySqlConnection(mainconn);
            string sqlquery = "insert into sugestao (id_sug, id_crianca, id_inst, sug) values ('"+suginsert.id_sug+ "', '" + suginsert.id_crianca + "','" + suginsert.id_inst + "', '" + suginsert.sug + "')";
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
        public bool editsug(SugestoesProp sugedit)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mysqlconn = new MySqlConnection(mainconn);
            string sqlquery = "update sugestao set sug='"+sugedit.sug+"' where id_sug='"+sugedit.id_sug+"'";
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
        public bool deletesug (int id)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mysqlconn = new MySqlConnection(mainconn);
            string sqlquery = "Delete from sugestao where id_sug="+id;
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