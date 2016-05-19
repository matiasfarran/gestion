using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mercado_Envio.Rol;

namespace Mercado_Envio
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Roles_Click(object sender, EventArgs e)
        {
            rolForm rolform = new rolForm();
            rolform.Show();
        }
    }
}
