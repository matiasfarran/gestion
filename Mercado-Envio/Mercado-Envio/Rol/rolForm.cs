using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Mercado_Envio.Rol
{
    public partial class rolForm : Form
    {
        bool activo = true;

        public rolForm()
        {
            InitializeComponent();

        }
        
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void cargarForm()
        {
            RolService rolservice = new RolService();
            List<Rol> listRol = rolservice.GetAll(activo);
            listBox1.DataSource = listRol;
            listBox1.DisplayMember = "nombre";

        }

        private void rolForm_Load(object sender, EventArgs e)
        {
            cargarForm();
        }
    }
}
