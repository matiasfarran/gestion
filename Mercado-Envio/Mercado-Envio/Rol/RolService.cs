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
        public void WriteRol(Rol rolToSet)
        {
            if (rolToSet.id != 0)
            {
                #region Query
                string Query = "UPDATE Rol Set rol_nombre=@nombre, rol_habilitado=@habilitado where rol_id=@id";
                #endregion

                SqlParameter[] param = new SqlParameter[3];
                param[0] = access.CreateParameter("@nombre", rolToSet.nombre);
                param[1] = access.CreateParameter("@habilitado", rolToSet.habilitado);
                param[2] = access.CreateParameter("@id", rolToSet.id);
                access.Write(Query, param);
                return;
            }
            else
            {
                #region Query
                string Query = "INSERT INTO Rol VALUES (@nombre,@habilitado)";
                #endregion

                SqlParameter[] param = new SqlParameter[2];
                param[0] = access.CreateParameter("@nombre", rolToSet.nombre);
                param[1] = access.CreateParameter("@habilitado", rolToSet.habilitado);
                access.Write(Query, param);
                return;
            }
        }
    
        public List<Rol> GetAll()
        {
           
            #region Query
            string Query = "SELECT * FROM Rol";
            #endregion

            //SqlParameter[] param = new SqlParameter[1];
            //param[0] = access.CreateParameter("@isActive", isActive);
            DataTable table = access.Read(Query);
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
