using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mercado_Envio.Accesos;
using System.Security.Cryptography;

namespace Mercado_Envio.Accesos {
    class Usuario {
        public String username { get; private set; }
        
        public Usuario(String username, String password) {
            loguear(username, password);
            this.username = username;
        }

        private void loguear(String username, String password) {
            Access accesos = Access.Instance;

            byte[] pass = accesos.Read(@"SELECT password 
                           FROM usuarios 
                           WHERE username=@username",
                            accesos.CreateParameter("username", username)).Rows[0][0] as byte[];
            if(pass != SHA256Cng.Create().ComputeHash(Encoding.Unicode.GetBytes(password))) {
                throw new Exception();
            }
        }
        
    }
}
