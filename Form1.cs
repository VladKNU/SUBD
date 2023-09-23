using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace SUBD
{
    public partial class Form1 : Form
    {
        public static Database database = null;
        public static List<Table> tables = new List<Table>();
        public static Dictionary<Table, List<Column>> columns = new Dictionary<Table, List<Column>>();
        public static Dictionary<Table, List<Row>> rows = new Dictionary<Table, List<Row>>();
        public static Dictionary<string, TabPage> tabs = new Dictionary<string, TabPage>();

        public static string tableOption = "";
        public static string columnOption = "";

        public Form1()
        {
            InitializeComponent();            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //LOAD
        }

        #region DATABASE

        private void CreateDB_Click(object sender, EventArgs e)
        {
            DatabaseControlForm dbForm = new DatabaseControlForm();
            dbForm.ShowDialog();            
            
            if (!String.IsNullOrEmpty(dbForm.dbname))
            {
                if (File.Exists($"./Databases/{dbForm.dbname}.xml"))
                {
                    MessageBox.Show($"A database with that name already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (dbForm.dbname != null)
                    {
                        DatabaseNameLabel.Text = dbForm.dbname;
                        database = new Database(dbForm.dbname);
                        CreateDatabase();
                    }                        
                }                
            }            
        }

        private void CreateDatabase()
        {
            using (XmlTextWriter writer = new XmlTextWriter($"./Databases/{database.Name}.xml", null))
            {
                writer.WriteStartElement("DATABASE");
                writer.WriteAttributeString("Name", database.Name);

                writer.WriteStartElement("TABLES");

                writer.WriteEndElement();

                writer.WriteEndElement();

                writer.Close();
            }                       
        }

        private void DeleteDB_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(DatabaseNameLabel.Text) && File.Exists($"./Databases/{database.Name}.xml"))
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure want to delete this database?", "Delete?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    File.Delete($"./Databases/{database.Name}.xml");
                    DatabaseNameLabel.Text = "";
                    TableTabControl.TabPages.Clear();
                    database = null;
                    tables.Clear();
                    columns.Clear();
                    rows.Clear();
                    tabs.Clear();

                    tableOption = "";
                    columnOption = "";
                }
            }                
        }

        private void OpenDB_Click(object sender, EventArgs e)
        {
            OpenDatabaseDialog.Filter = "XML Files (*.xml)|*.xml";
            OpenDatabaseDialog.FilterIndex = 0;
            OpenDatabaseDialog.DefaultExt = "xml";
            if (OpenDatabaseDialog.ShowDialog() == DialogResult.OK)
            {
                if (!String.Equals(Path.GetExtension(OpenDatabaseDialog.FileName),
                                   ".xml",
                                   StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("The type of the selected file is not supported by this application. You must select an XML file.",
                                    "Invalid File Type",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
                else
                {
                    string path = OpenDatabaseDialog.FileName.Replace(".xml", "");
                    database = new Database(path.Substring(path.LastIndexOf('\\') + 1));
                    DatabaseNameLabel.Text = database.Name;
                    OpenDatabase(database.Name);
                }
            }
        }

        private void OpenDatabase(string name)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load($"./Databases/{name}.xml");

            XmlElement TABLESElement = xmlDoc.SelectSingleNode("/DATABASE/TABLES") as XmlElement;

            XmlNodeList tablesElements = TABLESElement.ChildNodes;

            foreach (XmlNode element in tablesElements)
            {
                string tableName = element.Attributes.GetNamedItem("Name").Value;
                tables.Add(new Table(tableName));

                var columnsElement = xmlDoc.SelectSingleNode($"/DATABASE/TABLES/Table[@Name='{element.Attributes.GetNamedItem("Name").Value}']/COLUMNS").ChildNodes;

                Dictionary<string, string> cols = new Dictionary<string, string>();
                foreach (XmlNode column in columnsElement)
                {
                    cols.Add(column.Attributes["Name"].Value, column.Attributes["Type"].Value);
                }

                CreateTableTab(element.Attributes.GetNamedItem("Name").Value, cols);
            }

            xmlDoc.Save($"./Databases/{name}.xml");
        }

        #endregion

        #region TABLE

        private void CreateTABLE_Click(object sender, EventArgs e)
        {
            tableOption = "Create";
            TableControlForm tableForm = new TableControlForm();
            tableForm.ShowDialog();

            if (!String.IsNullOrEmpty(tableForm.tableName))
            {
                if (tables.Where(t => t.Name == tableForm.tableName).Count() > 0)
                {
                    MessageBox.Show($"A table with that name already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    tables.Add(new Table(tableForm.tableName));
                    CreateTableTab(tableForm.tableName, null);
                    CreateTable(tableForm.tableName);
                }                
            }
        }

        private void CreateTable(string name)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load($"./Databases/{database.Name}.xml");

            XmlElement newTable = xmlDoc.CreateElement("Table");
            newTable.SetAttribute("Name", name);

            XmlElement tablesElement = xmlDoc.SelectSingleNode("/DATABASE/TABLES") as XmlElement;

            tablesElement.AppendChild(newTable);

            newTable.AppendChild(xmlDoc.CreateElement("COLUMNS"));
            newTable.AppendChild(xmlDoc.CreateElement("ROWS"));

            xmlDoc.Save($"./Databases/{database.Name}.xml");
        }

        private void CreateTableTab(string name, Dictionary<string, string> _columns)
        {
            Table table = tables.First(t => t.Name == name);
            TabPage tabPage = new TabPage(name);

            DataGridView dataGridView = new DataGridView();

            dataGridView.Dock = DockStyle.Fill;
            dataGridView.AllowUserToAddRows = true;
            dataGridView.AllowUserToDeleteRows = true;

            if(_columns != null)
            {
                foreach (var item in _columns)
                {
                    AddColumn(table, item.Key, item.Value);
                    if(!dataGridView.Columns.Contains(item.Key))
                        dataGridView.Columns.Add(item.Key.Replace(' ', '_'), $"{item.Key} ({item.Value})");
                }
            }
            tabPage.Controls.Add(dataGridView);
            
            TableTabControl.TabPages.Add(tabPage);
            tabs.Add(name, tabPage);
        }

        private void DeleteTABLE_Click(object sender, EventArgs e)
        {
            tableOption = "Delete";
            TableControlForm tableForm = new TableControlForm();
            tableForm.ShowDialog();

            if (!String.IsNullOrEmpty(tableForm.tableName))
            {
                tables.Remove(tables.Where(t => t.Name == tableForm.tableName).First());

                tabs.Remove(tableForm.tableName);
                foreach (TabPage tab in TableTabControl.TabPages)
                {
                    if (tab.Text == tableForm.tableName) 
                        TableTabControl.TabPages.Remove(tab);
                }

                DeleteTable(tableForm.tableName);
            }
        }

        private void DeleteTable(string name)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load($"./Databases/{database.Name}.xml");

            XmlElement tablesElement = xmlDoc.SelectSingleNode("/DATABASE/TABLES") as XmlElement;

            XmlNodeList elementsToRemove = tablesElement.ChildNodes;

            foreach (XmlNode element in elementsToRemove)
            {
                if (element.Attributes["Name"].Value == name)                
                    element.ParentNode.RemoveChild(element);
            }

            xmlDoc.Save($"./Databases/{database.Name}.xml");
        }


        #endregion

        #region COLUMNS

        private void CreateCOL_Click(object sender, EventArgs e)
        {
            columnOption = "Create";
            ColumnControlForm columnForm = new ColumnControlForm();
            columnForm.ShowDialog();
            if (!String.IsNullOrEmpty(columnForm.tableName) && !String.IsNullOrEmpty(columnForm.columnName) && !String.IsNullOrEmpty(columnForm.columnType))
                CreateColumn(columnForm.tableName, columnForm.columnName, columnForm.columnType);
        }

        private void CreateColumn(string tableName, string name, string type)
        {            
            Table table = tables.Where(t => t.Name == tableName).First();

            columns[table] = AddColumn(table, name, type);
            AddColumnToDB(table, name, type);

            foreach (var control in tabs[tableName].Controls)
            {
                if (control is DataGridView)                
                    ((DataGridView)control).Columns.Add(name.Replace(' ', '_'), $"{name} ({type})");                
            }
        }

        private List<Column> AddColumn(Table table, string name, string type)
        {
            if (!columns.ContainsKey(table))
                columns.Add(table, new List<Column>());

            var ColumnsList = columns[table];

            switch (type)
            {
                case "INT":
                    ColumnsList.Add(new IntColumn(name));
                    break;
                case "REAL":
                    ColumnsList.Add(new RealColumn(name));
                    break;
                case "CHAR":
                    ColumnsList.Add(new CharColumn(name));
                    break;
                case "STRING":
                    ColumnsList.Add(new StringColumn(name));
                    break;
                case "TEXT FILE":
                    ColumnsList.Add(new TextFileColumn(name));
                    break;
                case "INT INTERVAL":
                    ColumnsList.Add(new IntIntervalColumn(name));
                    break;
            }

            return ColumnsList;
        }

        private void AddColumnToDB(Table table, string name, string type)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load($"./Databases/{database.Name}.xml");

            XmlElement newColumn = xmlDoc.CreateElement("Column");
            newColumn.SetAttribute("Name", name);
            newColumn.SetAttribute("Type", type);

            XmlNode columnsElement = xmlDoc.SelectSingleNode($"/DATABASE/TABLES/Table[@Name='{table.Name}']");

            XmlNode columnsNode = columnsElement.SelectSingleNode("COLUMNS");
            columnsNode.AppendChild(newColumn);

            xmlDoc.Save($"./Databases/{database.Name}.xml");
        }

        private void DeleteCOL_Click(object sender, EventArgs e)
        {
            columnOption = "Delete";
            ColumnControlForm columnForm = new ColumnControlForm();
            columnForm.ShowDialog();

            if (!String.IsNullOrEmpty(columnForm.columnName) && !String.IsNullOrEmpty(columnForm.tableName))
            {
                var col = from c in columns
                        where c.Key.Name == columnForm.tableName && c.Value.Where(co => co.Name == columnForm.columnName).Count() > 0
                        select c.Value.First();

                columns[tables.First(t => t.Name == columnForm.tableName)].Remove(col.First());

                foreach (TabPage tab in TableTabControl.TabPages)
                {
                    if (tab.Text == columnForm.tableName)
                    {
                        foreach (var item in tab.Controls)
                        {
                            if(item is DataGridView)
                            {
                                ((DataGridView)item).Columns.Remove(((DataGridView)item).Columns[columnForm.columnName.Replace(' ', '_')]);
                            }
                        }
                    }
                }

                DeleteColumn(columnForm.columnName, columnForm.tableName);
            }
        }

        private void DeleteColumn(string columnName, string tableName)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load($"./Databases/{database.Name}.xml");

            XmlNode columnToRemove = xmlDoc.SelectSingleNode($"/DATABASE/TABLES/Table[@Name='{tableName}']/COLUMNS/Column[@Name='{columnName}']");

            columnToRemove.ParentNode.RemoveChild(columnToRemove);

            xmlDoc.Save($"./Databases/{database.Name}.xml");
        }

        #endregion

        #region ROWS

        private void CreateROW_Click(object sender, EventArgs e)
        {

        }

        private void DeleteROW_Click(object sender, EventArgs e)
        {
            //test
        }

        #endregion
    }
}
