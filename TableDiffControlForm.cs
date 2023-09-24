using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SUBD
{
    public partial class TableDiffControlForm : Form
    {
        public string tableName1 = "";
        public string tableName2 = "";

        public TableDiffControlForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != comboBox2.Text)
            {
                if (String.IsNullOrEmpty(comboBox1.Text))
                {
                    MessageBox.Show($"First table is null.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (String.IsNullOrEmpty(comboBox2.Text))
                {
                    MessageBox.Show($"Second table is null.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    tableName1 = comboBox1.Text;
                    tableName2 = comboBox2.Text;
                    this.Close();
                }
            }
            else
                this.Close();
        }

        private void TableDiffControlForm_Load(object sender, EventArgs e)
        {
            comboBox1.Items.AddRange(Form1.tables.Select(t => t.Name).ToArray());
            comboBox2.Items.AddRange(Form1.tables.Select(t => t.Name).ToArray());
        }
    }
}
