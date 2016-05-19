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
        //bool activo = true;

        public rolForm()
        {
            InitializeComponent();

        }

        private void cargarForm()
        {
            RolService rolservice = new RolService();
            List<Rol> listRol = rolservice.GetAll();
            
            listBox1.DataSource = listRol;
            listBox1.DisplayMember = "todo";

            Rol primero = listRol.First();
            textBox1.Text = primero.nombre;
            checkBox1.Checked = primero.habilitado;
            textBox2.Text = primero.id.ToString();

        }

        private void rolForm_Load(object sender, EventArgs e)
        {
            cargarForm();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RolService rolservice = new RolService();
            Rol CurrentRol = new Rol(Int32.Parse(textBox2.Text), textBox1.Text,checkBox1.Checked);
            rolservice.WriteRol(CurrentRol);
            cargarForm();
        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            Rol currentRol = (Rol)listBox1.SelectedItem;
            textBox1.Text = currentRol.nombre;
            checkBox1.Checked = currentRol.habilitado;
            textBox2.Text = currentRol.id.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            checkBox1.Checked = true;
            textBox2.Text = "";
                
        }
    }
}
