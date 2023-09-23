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
    public partial class ColumnControlForm : Form
    {
        public string columnName = "";
        public string tableName = "";
        public string columnType = "";

        private bool customButtonClicked = true;

        public ColumnControlForm()
        {
            InitializeComponent();
        }

        private void ColumnControlForm_Load(object sender, EventArgs e)
        {
            List<string> types = new List<string>()
            {
                "INT",
                "REAL",
                "CHAR",
                "STRING",
                "TEXT FILE",
                "INT INTERVAL"
            };

            TypesComboBox.Items.AddRange(types.ToArray());

            TablesComboBox.Items.AddRange(Form1.tables.Select(t => t.Name).ToArray());

            if (Form1.columnOption == "Create")
            {
                DeleteButton.Visible = false;
                ColumnsComboBox.Visible = false;
            }
            else
            {
                CreateButton.Visible = false;
                TypesComboBox.Visible = false;
                ColumnNameTextBox.Visible = false;
                label3.Visible = false;                
            }
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            customButtonClicked = true;

            columnName = ColumnNameTextBox.Text;
            tableName = TablesComboBox.Text;
            columnType = TypesComboBox.Text;

            var col = from c in Form1.columns
                    where c.Key.Name == tableName && c.Value.Where(co => co.Name == columnName).Count() > 0
                    select c;

            if (col.Count() <= 0)
            {
                if (!String.IsNullOrEmpty(ColumnNameTextBox.Text) && !String.IsNullOrEmpty(TablesComboBox.Text) && !String.IsNullOrEmpty(TypesComboBox.Text))
                    this.Close();
                else
                {
                    DialogResult dialogResult = MessageBox.Show("One or any of the parameters are not specified. The column will not be created.", "Exit?", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        this.Close();
                    }
                }
            }
            else
            {
                customButtonClicked = false;
                MessageBox.Show($"A column with that name already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            customButtonClicked = true;

            columnName = ColumnsComboBox.Text;
            tableName = TablesComboBox.Text;

            if (!String.IsNullOrEmpty(ColumnsComboBox.Text) && !String.IsNullOrEmpty(TablesComboBox.Text))
                this.Close();
            else
            {
                DialogResult dialogResult = MessageBox.Show("One or any of the parameters are not specified. The column will not be deleted.", "Exit?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }

        private void TablesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Form1.columnOption == "Delete")
                ColumnsComboBox.Items.AddRange(Form1.columns[Form1.tables.First(t => t.Name == TablesComboBox.Text)].Select(c => c.Name).ToArray());
        }

        private void ColumnControlForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!customButtonClicked)
            {
                columnName = "";
                tableName = "";
                columnType = "";
            }            
        }
    }
}
