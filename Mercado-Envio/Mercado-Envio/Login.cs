using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mercado_Envio.Accesos;


namespace Mercado_Envio
{
    public partial class Login : Form
    {
        private String password { get { return txtPassword.Text; } }
        private String username { get { return txtUsername.Text; } }
        private Usuario usuario { get; set; }

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e) {
            try {
                usuario = new Usuario(username, password);
            }
            catch {
                MessageBox.Show("El usuario o la contraseña no son válidos");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e) {
            if(MessageBox.Show("¿Esta seguro de que desea salir?", "Si/No", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                Application.Exit();
        }

    }
}
