using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
// private string connectionString = "Data Source=AR-ITS-MF\SQLSERVER2012;Initial Catalog=GD1C22016;User ID=sa;Password=gestiondedatos";

namespace Mercado_Envio.Accesos
{
    public class Access
    {
        private SqlConnection cnn;
        private SqlTransaction tx;
        private string connectionString = "Data Source=AR-ITS-MF\\SQLSERVER2012;Initial Catalog=GD1C22016;User ID=sa;Password=gestiondedatos";
        // private string connectionString = "Data Source=AR-ISS-RM\\SQLEXPRESS;Initial Catalog=reservas;Persist Security Info=True;User ID=sa;Password=ro0312r+o";
        //private string connectionString = "Data Source=santii-pc\\sqlexpress;Initial Catalog=reservas;Integrated Security=True";

        private static Access instance;

        private Access()
        {
        }

        public static Access Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Access();
                }
                return instance;
            }
        }

        #region Method Connection

        private void Open()
        {
            try
            {
                cnn = new SqlConnection(connectionString);
                cnn.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Close()
        {
            try
            {
                cnn.Close();
                cnn = null;
                GC.Collect();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Method Access

        public DataTable Read(string store, SqlParameter[] param = null)
        {
            DataTable tabla = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            Open();
            adapter.SelectCommand = new SqlCommand();
            adapter.SelectCommand.CommandText = store;
            adapter.SelectCommand.CommandType = CommandType.Text;
            if (param != null)
            {
                adapter.SelectCommand.Parameters.AddRange(param);
            }
            adapter.SelectCommand.Connection = cnn;
            adapter.Fill(tabla);
            Close();
            return tabla;
        }

        public int Write(string store, SqlParameter[] param)
        {
            int retorno;
            SqlCommand command = new SqlCommand();
            Open();
            command.CommandText = store;
            command.CommandType = CommandType.Text;
            command.Connection = cnn;
            command.Parameters.AddRange(param);
            tx = cnn.BeginTransaction();
            command.Transaction = tx;
            try
            {
                retorno = command.ExecuteNonQuery();
                tx.Commit();
                return retorno;
            }
            catch (Exception ex)
            {
                retorno = -1;
                tx.Rollback();
                return retorno;
            }
            finally
            {
                Close();
            }

        }

        #endregion

        #region Create Parameter
        public SqlParameter CreateParameter(string name, string value)
        {
            SqlParameter param = new SqlParameter(name, value);
            param.SqlDbType = SqlDbType.NVarChar;
            return param;
        }

        public SqlParameter CreateParameter(string name, int value)
        {
            SqlParameter param = new SqlParameter(name, value);
            param.SqlDbType = SqlDbType.Int;
            return param;
        }

        public SqlParameter CreateParameter(string name, bool value)
        {
            SqlParameter param = new SqlParameter(name, value);
            param.SqlDbType = SqlDbType.Bit;
            return param;
        }

        public SqlParameter CreateParameter(string name, DateTime value)
        {
            SqlParameter param = new SqlParameter(name, value);
            param.SqlDbType = SqlDbType.Date;
            return param;
        }

        public SqlParameter CreateParameter(string name, Double value)
        {
            SqlParameter param = new SqlParameter(name, value);
            param.SqlDbType = SqlDbType.Date;
            return param;
        }
        #endregion

    }
}
