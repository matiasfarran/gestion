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
                return instance ?? new Access();
            }
        }

        #region Method Connection

        private void Open()
        {
            cnn = new SqlConnection(connectionString);
            cnn.Open();
        }

        private void Close()
        {   
            cnn.Close();
            cnn.Dispose(); //Usar dispose, no llamar al GarbageCollector
            cnn = null;
        }

        #endregion

        #region Method Access

        public DataTable Read(string store, params SqlParameter[] parameters)
        {
            DataTable tabla = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            Open();
            adapter.SelectCommand = new SqlCommand(store,cnn);
            adapter.SelectCommand.CommandType = CommandType.Text;
            adapter.SelectCommand.Parameters.AddRange(parameters);
            adapter.Fill(tabla);
            Close();
            return tabla;
        }

        public void Write(string store, params SqlParameter[] param)
        {
            Open();
            SqlCommand command = new SqlCommand(store, cnn, tx = cnn.BeginTransaction());
            command.CommandType = CommandType.Text;
            command.Parameters.AddRange(param);
            try
            {
                command.ExecuteNonQuery();
                tx.Commit();
            }
            catch (Exception ex)
            {
                tx.Rollback();
                throw ex;
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
            param.SqlDbType = SqlDbType.Float;
            return param;
        }

        public SqlParameter CreateParameter(String name, Decimal value) {
            SqlParameter param = new SqlParameter(name, value);
            param.SqlDbType = SqlDbType.Decimal;
            return param;
        }
        #endregion

    }
}
