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
    public class PatrocinioImplementation
    {
        public List<PatrocinioProp> GetPat()
        {
            List<PatrocinioProp> ListaPatrocinio = new List<PatrocinioProp>();
            string mainconn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mysqlconn = new MySqlConnection(mainconn);
            string sqlquery = "select * from parceiro";
            MySqlCommand sqlcomm = new MySqlCommand(sqlquery, mysqlconn);
            mysqlconn.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(sqlcomm);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mysqlconn.Close();
            foreach (DataRow dr in dt.Rows)
            {
                ListaPatrocinio.Add(new PatrocinioProp
                {
                    id_parceiro   = Convert.ToInt32(dr["id_parceiro"]),
                    nome = Convert.ToString(dr["nome"]),
                    descricao = Convert.ToString(dr["descricao"]),
                   
                }
                );
            }

            return ListaPatrocinio;
        }
    }
}