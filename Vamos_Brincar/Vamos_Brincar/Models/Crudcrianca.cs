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
    public class CrudCrianca
    {
        public List<Criancamod> GetCri()
        {
            List<Criancamod> ListaCrianca = new List<Criancamod>();
            string mainconn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mysqlconn = new MySqlConnection(mainconn);
            string sqlquery = "select * from crianca";
            MySqlCommand sqlcomm = new MySqlCommand(sqlquery, mysqlconn);
            mysqlconn.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(sqlcomm);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mysqlconn.Close();
            foreach (DataRow dr in dt.Rows)
            {
                ListaCrianca.Add(new Criancamod
                {
                    id_crianca = Convert.ToInt32(dr["id_crianca"]),
                    nome = Convert.ToString(dr["nome"]),
                    idade = Convert.ToInt32(dr["idade"]),
                    pass = Convert.ToString(dr["pass"]),
                }
                );     
            }

            return ListaCrianca;
        }
        public bool insertCri(Criancamod criInsert)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mysqlconn = new MySqlConnection(mainconn);
            string sqlquery = "insert into crianca (nome, idade, pass) values ('" + criInsert.nome + "','" + criInsert.idade + "','" + criInsert.pass +  "') ";
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

        public bool editCri(Criancamod criEdit)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mysqlconn = new MySqlConnection(mainconn);
            string sqlquery = "update crianca set nome='" + criEdit.nome + "'where id_crianca='"+criEdit.id_crianca+"'";
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
        public bool deletecri(int id)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mysqlconn = new MySqlConnection(mainconn);
            string sqlquery = "Delete From crianca where id_crianca =" + id;
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

