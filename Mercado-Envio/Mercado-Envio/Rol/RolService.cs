using Mercado_Envio.Accesos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Mercado_Envio.Rol
{
    public class RolService
    {
        Acceso access = new Acceso();

        public Rol getRol()
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = access.CreateParameter("@id", 1);
            DataTable table = access.Read("SELECT * FROM Rol Where rol_id = @id", parameters);
                
        }
    }
}
