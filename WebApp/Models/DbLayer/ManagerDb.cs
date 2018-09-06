using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;

namespace WebApp.Models.DbLayer
{
    public static class ManagerDb
    {
        static OracleConnect _con;
        static ManagerDb()
        {
            //string connectionString = ConfigurationManager.ConnectionStrings["connectionStringName"].ConnectionString;
            string connectionString = "Data Source=CD_WORK;User ID=IMPORT_USER;Password=sT7hk9Lm";
            _con = new OracleConnect(connectionString);
            //_con.OpenConnect();
        }        

        public static string GetData()
        {
            string res = "";
            string query = "select distinct(cr.name) from SUVD.PROJECTS t, suvd.creditors cr where t.creditor_id = cr.id and t.creditor_id = 2060";
            _con.OpenConnect();
            OracleDataReader reader = _con.GetReader(query);
            while (reader.Read())
            {
                res = reader[0].ToString();
            }
            return res;
        }


    }
}