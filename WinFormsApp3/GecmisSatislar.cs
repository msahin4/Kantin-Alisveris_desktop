using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace WinFormsApp3
{
    public partial class Form2 : Form
    {
        public Form2(DataTable dataTable)
        {
            InitializeComponent();

            dataGridView1.Dock = DockStyle.Fill; // Formu kaplar
            dataGridView1.DataSource = dataTable; // DataTable'ı DataGridView'e ata

            Controls.Add(dataGridView1);
        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
