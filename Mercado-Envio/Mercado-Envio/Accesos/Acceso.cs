using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Mercado_Envio.Accesos
{
    class Acceso
    {
        private string connectionString = "Data Source=AR-ITS-MF\SQLSERVER2012;Initial Catalog=GD1C22016;User ID=sa;Password=gestiondedatos";
        private SqlConnection cn;
        private void openConection()
        {
            cn.ConnectionString = connectionString;
            cn.Open();

        }
        private void closeConection()
        {
            cn.Close();
        }
        public DataTable Read(string consulta, SqlParameter[] parameters)
        {
            SqlDataAdapter data = new SqlDataAdapter();
            data.SelectCommand = new SqlCommand();
            data.SelectCommand.CommandType = System.Data.CommandType.Text;
            data.SelectCommand.CommandText = consulta;
            openConection();
            data.SelectCommand.Connection = cn;
            if (parameters != null) 
                data.SelectCommand.Parameters.AddRange(parameters);
            
            DataTable table = new DataTable();
            data.Fill(table);

            return table

        }
        private void Write()
        {

        }

        public SqlParameter CreateParameter(string name, int value)
        {
            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = name;
            parameter.Value = value;
            parameter.DbType = DbType.Int32;
            return parameter;
        }

    }
}
