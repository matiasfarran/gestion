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
        Access access = null;

        public RolService()
        {
            access = Access.Instance;
        }
        /*
        public Rol getRol(int id)
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = access.CreateParameter("@id", id);
            DataTable table = access.Read("SELECT TOP 1 * FROM Rol Where rol_id = @id", parameters);
            foreach(DataRow rol in )
                
        }*/
        public List<Rol> GetAll(bool isActive)
        {
           
            #region Query
            string Query = "SELECT * FROM Rol WHERE rol_habilitado = @isActive";
            #endregion

            SqlParameter[] param = new SqlParameter[1];
            param[0] = access.CreateParameter("@isActive", isActive);
            DataTable table = access.Read(Query, param);
            List<Rol> lstRol = new List<Rol>();
            foreach (DataRow rol in table.Rows)
            {
                lstRol.Add(Convert(rol));
            }
            return lstRol;
        }
        private Rol Convert(DataRow obj)
        {
            Rol rol = new Rol();
            rol.id = Int32.Parse(obj["rol_id"].ToString());
            rol.habilitado =  Boolean.Parse(obj["rol_habilitado"].ToString());
            rol.nombre = obj["rol_nombre"].ToString();
            return rol;
        }

    }
}
