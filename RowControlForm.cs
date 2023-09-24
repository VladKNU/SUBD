using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace SUBD
{
    public partial class RowControlForm : Form
    {
        private List<Column> dataList = new List<Column>();
        private List<Table> tablesList = new List<Table>();

        public string tableName = "";
        public List<string> data = new List<string>();

        public RowControlForm()
        {
            InitializeComponent();
        }

        private void RowControlForm_Load(object sender, EventArgs e)
        {
            tablesList = Form1.tables;
            TablesComboBox.Items.Clear();
            TablesComboBox.Items.AddRange(tablesList.Select(t => t.Name).ToArray());
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {            
            for(int i = 0; i < panel1.Controls.Count; i++)
            {
                if (panel1.Controls[i] is TextBox)
                    data.Add(((TextBox)panel1.Controls[i]).Text);
            }

            this.Close();
        }

        private void GenerateTextBoxes()
        {
            // Clear existing controls in the Panel
            panel1.Controls.Clear();

            // Create TextBoxes and labels dynamically based on the List size
            for (int i = 0; i < dataList.Count; i++)
            {
                // Create a Label
                Label label = new Label();
                label.Size = new Size(panel1.Width - 20, 16);
                label.Text = $"{dataList[i].Name} ({dataList[i].Type})";
                label.Location = new Point(0, 16 + i * 60); // Adjust the label position as needed

                // Create a TextBox
                TextBox textBox = new TextBox();
                textBox.Size = new Size(panel1.Width - 20, 16);
                textBox.Name = dataList[i].Name; // Set a unique name for each TextBox
                textBox.Text = "";                
                textBox.Location = new Point(0, 32 + i * 60); // Adjust the TextBox position as needed               

                if (dataList[i].Type == "TEXT FILE")
                {
                    textBox.ReadOnly = true;

                    Button openFileButton = new Button();
                    openFileButton.Size = new Size(panel1.Width - 20, 23); // Adjust the button size as needed
                    openFileButton.Text = "Open File";
                    openFileButton.Location = new Point(0, 52 + i * 60); // Adjust the button position as needed
                    openFileButton.Click += (sender, e) =>
                    {
                        OpenFileDialog openFileDialog = new OpenFileDialog();
                        openFileDialog.Filter = "Text Files (*.txt)|*.txt";
                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            textBox.Text = openFileDialog.FileName;
                        }
                    };

                    panel1.Controls.Add(openFileButton); // Add the button to the Panel
                }

                textBox.TextChanged += (sender, e) =>
                {
                    if (!dataList.Where(c => c.Name == textBox.Name).First().Validate(textBox.Text))
                    {
                        if (!String.IsNullOrEmpty(textBox.Text))
                            MessageBox.Show("Invalid input. Please enter a valid value.");
                        textBox.Text = null;
                    }
                };               

                // Add the Label and TextBox to the Panel
                panel1.Controls.Add(label);
                panel1.Controls.Add(textBox);
            }
        }

        private void TablesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            dataList.Clear();

            var cols = from c in Form1.columns
                        where c.Key.Name == TablesComboBox.Text
                        select c.Value;            

            if (cols.Count() > 0)
            {
                tableName = TablesComboBox.Text;
                dataList.AddRange(cols.First().ToArray());
                GenerateTextBoxes();
                if (Form1.rowOption == "Delete")
                {
                    foreach (var control in panel1.Controls.Cast<Control>())
                    {
                        control.Enabled = false;
                    }
                }
            }            
        }        
    }
}
