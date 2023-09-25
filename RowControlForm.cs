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
        private bool isButtonClicled = false;

        public string tableName = "";
        public List<string> data = new List<string>();

        public int index = -1;

        ComboBox comboBox = new ComboBox();

        public RowControlForm()
        {
            InitializeComponent();
        }

        private void RowControlForm_Load(object sender, EventArgs e)
        {
            this.Size = new Size(304, 452);
            tablesList = Form1.tables;
            TablesComboBox.Items.Clear();
            TablesComboBox.Items.AddRange(tablesList.Select(t => t.Name).ToArray());

            if (Form1.rowOption == "Delete")
            {
                this.Size = new Size(304, 511);

                Label label = new Label();
                label.Size = new Size(panel1.Width - 20, 16);
                label.Text = $"Row";
                label.Location = new Point(TablesComboBox.Location.X, TablesComboBox.Location.X + 35);

                comboBox.Name = "RowsComboBox";
                comboBox.Size = new Size(panel1.Width, 16);
                comboBox.Location = new Point(TablesComboBox.Location.X, TablesComboBox.Location.X + 55);

                comboBox.SelectedIndexChanged += (s, ee) =>
                {
                    if (!String.IsNullOrEmpty(comboBox.Text))
                    {
                        foreach (var control in panel1.Controls.Cast<Control>())
                        {
                            if (control is TextBox)
                                control.Text = null;
                        }

                        List<string> values = comboBox.Text.Substring(comboBox.Text.IndexOf('|') + 2).Split('#').ToList();

                        index = Convert.ToInt32(comboBox.Text.Substring(0, 1));

                        for (int i = 0, j = 0; i < panel1.Controls.Count && j < values.Count; i++)
                        {
                            if (panel1.Controls[i] is TextBox)
                            {
                                if (values[j] != "null")
                                {
                                    panel1.Controls[i].Text = values[j];                                    
                                }
                                j++;
                            }
                        }
                    }
                };

                this.Controls.Add(label);
                this.Controls.Add(comboBox);

                panel1.Location = new Point(panel1.Location.X, panel1.Location.Y + 60);
                CreateButton.Visible = false;
                DeleteButton.Location = new Point(CreateButton.Location.X, CreateButton.Location.Y + 60);
            }

            else
            {                
                DeleteButton.Visible = false;
            }
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

                if (dataList[i].Type == "TIME")
                {
                    textBox.ReadOnly = true;

                    DateTimePicker timePicker = new DateTimePicker();
                    timePicker.Format = DateTimePickerFormat.Time;
                    timePicker.ShowUpDown = true;
                    timePicker.Location = new Point(0, 52 + i * 60);
                    timePicker.Size = new Size(panel1.Width - 20, 23);
                    timePicker.ValueChanged += (sender, e) =>
                    {
                        textBox.Text = timePicker.Value.ToLongTimeString();
                    };

                    panel1.Controls.Add(timePicker);
                }

                if (dataList[i].Type == "STRING INTERVAL")
                {
                    textBox.Leave += (sender, e) =>
                    {
                        if (!dataList.Where(c => c.Name == textBox.Name).First().Validate(textBox.Text))
                        {
                            if (!String.IsNullOrEmpty(textBox.Text))
                                MessageBox.Show("Invalid input. Please enter a valid value.");
                            textBox.Text = null;
                        }
                    };
                }
                else
                {
                    textBox.TextChanged += (sender, e) =>
                    {
                        if (!dataList.Where(c => c.Name == textBox.Name).First().Validate(textBox.Text))
                        {
                            if (!String.IsNullOrEmpty(textBox.Text))
                                MessageBox.Show("Invalid input. Please enter a valid value.");
                            textBox.Text = null;
                        }
                    };
                }                               

                // Add the Label and TextBox to the Panel
                panel1.Controls.Add(label);
                panel1.Controls.Add(textBox);
            }
        }

        private void TablesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            dataList.Clear();
            comboBox.Items.Clear();

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

                    var rows = from r in Form1.rows
                               where r.Key.Name == TablesComboBox.Text
                               select r.Value;

                    if (rows.Count() > 0)
                    {
                        var values = rows.First().Select(r => r.Values).ToArray();

                        if(values.Count() > 0)
                        {
                            data = values.First();

                            for (int i = 0; i < values.Length; i++)
                            {
                                string output = $"{i} | {string.Join("#", values[i])}";
                                comboBox.Items.Add(output);
                            }
                        }                        
                    }
                }
            }            
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            isButtonClicled = true;
            this.Close();
        }

        private void RowControlForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isButtonClicled == false) {
                index = -1;
            }
        }
    }
}
