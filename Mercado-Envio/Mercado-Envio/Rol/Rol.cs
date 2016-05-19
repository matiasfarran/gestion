using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mercado_Envio.Rol
{
    public class Rol
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public bool habilitado { get; set; }
        public Rol() { }
        public Rol(int id, string nombre, bool habilitado) {

            this.id = id;
            this.nombre = nombre;
            this.habilitado = habilitado;
        } 
        public string todo
        {
            get
            {
                string resu = "";
                resu = "Nom:" + this.nombre + "_ID:" + this.id + "_Activo:" + this.habilitado;
                return resu;
            }
        }
    }
}
