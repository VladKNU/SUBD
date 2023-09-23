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
    public partial class DatabaseControlForm : Form
    {
        public string dbname = "";

        public DatabaseControlForm()
        {            
            InitializeComponent();
        }

        private void DatabaseNameTextBox_TextChanged(object sender, EventArgs e)
        {
            dbname = DatabaseNameTextBox.Text;
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            dbname = DatabaseNameTextBox.Text;

            if (!String.IsNullOrEmpty(DatabaseNameTextBox.Text))
                this.Close();
            else
            {
                DialogResult dialogResult = MessageBox.Show("The name of the database is not specified. The database will not be created.", "Exit?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }
    }
}
