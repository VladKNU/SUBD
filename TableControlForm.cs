using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SUBD
{
    public partial class TableControlForm : Form
    {
        public string tableName = "";

        public TableControlForm()
        {
            InitializeComponent();
        }

        private void TableNameTextBox_TextChanged(object sender, EventArgs e)
        {
            tableName = TableNameTextBox.Text;
        }

        private void TableControlForm_Load(object sender, EventArgs e)
        {
            if (Form1.tableOption == "Create")
            {
                TablesComboBox.Visible = false;
                DeleteButton.Visible = false;
            }
            else
            {
                TableNameTextBox.Visible = false;
                CreateButton.Visible = false;
                TablesComboBox.Items.AddRange(Form1.tables.Select(t => t.Name).ToArray());
            }
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {            
            tableName = TableNameTextBox.Text;

            if (!String.IsNullOrEmpty(TableNameTextBox.Text))
                this.Close();
            else
            {
                DialogResult dialogResult = MessageBox.Show("The name of the table is not specified. The table will not be created.", "Exit?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {            
            tableName = TablesComboBox.Text;

            if (!String.IsNullOrEmpty(tableName))
                this.Close();
            else
            {
                DialogResult dialogResult = MessageBox.Show("The name of the table is not specified. The table will not be created.", "Exit?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }        
    }
}
