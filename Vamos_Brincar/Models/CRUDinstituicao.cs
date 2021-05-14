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
    public class CRUDinstituicao
    {
        public List<instituicaomod> GetInst()
        {
            List<instituicaomod> ListaInstituicao = new List<instituicaomod>();
            string mainconn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mysqlconn = new MySqlConnection(mainconn);
            string sqlquery = "select * from instituicao";
            MySqlCommand sqlcomm = new MySqlCommand(sqlquery, mysqlconn);
            mysqlconn.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(sqlcomm);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mysqlconn.Close();
            foreach (DataRow dr in dt.Rows)
            {
                ListaInstituicao.Add(new instituicaomod
                {
                    id_inst = Convert.ToInt32(dr["id_inst"]),
                    nome = Convert.ToString(dr["nome"]),
                    pass = Convert.ToString(dr["pass"]),
                }
                );
            }

            return ListaInstituicao;
        }
        public bool insertInst(instituicaomod instInsert)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mysqlconn = new MySqlConnection(mainconn);
            string sqlquery = "insert into instituicao (nome, pass) values ('" + instInsert.nome + "','" + instInsert.pass + "') ";
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

        public bool editInst(instituicaomod instEdit)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mysqlconn = new MySqlConnection(mainconn);
            string sqlquery = "update instituicao set nome='" + instEdit.nome + "'where id_inst='" + instEdit.id_inst + "'";
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
        public bool deleteinst(int id)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mysqlconn = new MySqlConnection(mainconn);
            string sqlquery = "Delete From crianca where id_inst =" + id;
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