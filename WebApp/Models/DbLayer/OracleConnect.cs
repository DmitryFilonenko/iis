using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.DbLayer
{
    public class OracleConnect
    {
        OracleConnection _con;
        OracleCommand _cmd;

        public OracleConnect(string connectionString)
        {
            _con = new OracleConnection();
            _con.ConnectionString = connectionString;            
        }

        public void OpenConnect()
        {
            try
            {
                _con.Open();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void CloseConnect()
        {
            _con.Close();
            _con.Dispose();
        }

        public void ExecCommand(string query)
        {
            _cmd = new OracleCommand(query, _con);
            _cmd.ExecuteNonQuery();
            _cmd.Dispose();
        }

        public OracleDataReader GetReader(string query)
        {
            _cmd = new OracleCommand(query, _con);
            OracleDataReader reader = _cmd.ExecuteReader();
            _cmd.Dispose();
            return reader;
        }
    }
}