namespace SUBD
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.databaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateDB = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteDB = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenDB = new System.Windows.Forms.ToolStripMenuItem();
            this.tableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateTABLE = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteTABLE = new System.Windows.Forms.ToolStripMenuItem();
            this.columnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateCOL = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteCOL = new System.Windows.Forms.ToolStripMenuItem();
            this.rowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateROW = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteROW = new System.Windows.Forms.ToolStripMenuItem();
            this.TableTabControl = new System.Windows.Forms.TabControl();
            this.OpenDatabaseDialog = new System.Windows.Forms.OpenFileDialog();
            this.SaveDatabaseDialog = new System.Windows.Forms.SaveFileDialog();
            this.DatabaseNameLabel = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(816, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.databaseToolStripMenuItem,
            this.tableToolStripMenuItem,
            this.columnToolStripMenuItem,
            this.rowToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // databaseToolStripMenuItem
            // 
            this.databaseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreateDB,
            this.DeleteDB,
            this.OpenDB});
            this.databaseToolStripMenuItem.Name = "databaseToolStripMenuItem";
            this.databaseToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.databaseToolStripMenuItem.Text = "Database";
            // 
            // CreateDB
            // 
            this.CreateDB.Name = "CreateDB";
            this.CreateDB.Size = new System.Drawing.Size(136, 26);
            this.CreateDB.Text = "Create";
            this.CreateDB.Click += new System.EventHandler(this.CreateDB_Click);
            // 
            // DeleteDB
            // 
            this.DeleteDB.Name = "DeleteDB";
            this.DeleteDB.Size = new System.Drawing.Size(136, 26);
            this.DeleteDB.Text = "Delete";
            this.DeleteDB.Click += new System.EventHandler(this.DeleteDB_Click);
            // 
            // OpenDB
            // 
            this.OpenDB.Name = "OpenDB";
            this.OpenDB.Size = new System.Drawing.Size(136, 26);
            this.OpenDB.Text = "Open";
            this.OpenDB.Click += new System.EventHandler(this.OpenDB_Click);
            // 
            // tableToolStripMenuItem
            // 
            this.tableToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreateTABLE,
            this.DeleteTABLE});
            this.tableToolStripMenuItem.Name = "tableToolStripMenuItem";
            this.tableToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.tableToolStripMenuItem.Text = "Table";
            // 
            // CreateTABLE
            // 
            this.CreateTABLE.Name = "CreateTABLE";
            this.CreateTABLE.Size = new System.Drawing.Size(136, 26);
            this.CreateTABLE.Text = "Create";
            this.CreateTABLE.Click += new System.EventHandler(this.CreateTABLE_Click);
            // 
            // DeleteTABLE
            // 
            this.DeleteTABLE.Name = "DeleteTABLE";
            this.DeleteTABLE.Size = new System.Drawing.Size(136, 26);
            this.DeleteTABLE.Text = "Delete";
            this.DeleteTABLE.Click += new System.EventHandler(this.DeleteTABLE_Click);
            // 
            // columnToolStripMenuItem
            // 
            this.columnToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreateCOL,
            this.DeleteCOL});
            this.columnToolStripMenuItem.Name = "columnToolStripMenuItem";
            this.columnToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.columnToolStripMenuItem.Text = "Column";
            // 
            // CreateCOL
            // 
            this.CreateCOL.Name = "CreateCOL";
            this.CreateCOL.Size = new System.Drawing.Size(136, 26);
            this.CreateCOL.Text = "Create";
            this.CreateCOL.Click += new System.EventHandler(this.CreateCOL_Click);
            // 
            // DeleteCOL
            // 
            this.DeleteCOL.Name = "DeleteCOL";
            this.DeleteCOL.Size = new System.Drawing.Size(136, 26);
            this.DeleteCOL.Text = "Delete";
            this.DeleteCOL.Click += new System.EventHandler(this.DeleteCOL_Click);
            // 
            // rowToolStripMenuItem
            // 
            this.rowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreateROW,
            this.DeleteROW});
            this.rowToolStripMenuItem.Name = "rowToolStripMenuItem";
            this.rowToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.rowToolStripMenuItem.Text = "Row";
            // 
            // CreateROW
            // 
            this.CreateROW.Name = "CreateROW";
            this.CreateROW.Size = new System.Drawing.Size(224, 26);
            this.CreateROW.Text = "Create";
            this.CreateROW.Click += new System.EventHandler(this.CreateROW_Click);
            // 
            // DeleteROW
            // 
            this.DeleteROW.Name = "DeleteROW";
            this.DeleteROW.Size = new System.Drawing.Size(224, 26);
            this.DeleteROW.Text = "Delete";
            this.DeleteROW.Click += new System.EventHandler(this.DeleteROW_Click);
            // 
            // TableTabControl
            // 
            this.TableTabControl.Location = new System.Drawing.Point(12, 51);
            this.TableTabControl.Name = "TableTabControl";
            this.TableTabControl.SelectedIndex = 0;
            this.TableTabControl.Size = new System.Drawing.Size(793, 375);
            this.TableTabControl.TabIndex = 0;
            // 
            // OpenDatabaseDialog
            // 
            this.OpenDatabaseDialog.InitialDirectory = "./Databases";
            // 
            // DatabaseNameLabel
            // 
            this.DatabaseNameLabel.AutoSize = true;
            this.DatabaseNameLabel.Location = new System.Drawing.Point(374, 32);
            this.DatabaseNameLabel.Name = "DatabaseNameLabel";
            this.DatabaseNameLabel.Size = new System.Drawing.Size(0, 16);
            this.DatabaseNameLabel.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 438);
            this.Controls.Add(this.DatabaseNameLabel);
            this.Controls.Add(this.TableTabControl);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem databaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CreateDB;
        private System.Windows.Forms.ToolStripMenuItem DeleteDB;
        private System.Windows.Forms.ToolStripMenuItem OpenDB;
        private System.Windows.Forms.ToolStripMenuItem tableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CreateTABLE;
        private System.Windows.Forms.ToolStripMenuItem DeleteTABLE;
        private System.Windows.Forms.ToolStripMenuItem columnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CreateCOL;
        private System.Windows.Forms.ToolStripMenuItem DeleteCOL;
        private System.Windows.Forms.ToolStripMenuItem rowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CreateROW;
        private System.Windows.Forms.ToolStripMenuItem DeleteROW;
        private System.Windows.Forms.TabControl TableTabControl;
        private System.Windows.Forms.OpenFileDialog OpenDatabaseDialog;
        private System.Windows.Forms.SaveFileDialog SaveDatabaseDialog;
        private System.Windows.Forms.Label DatabaseNameLabel;
    }
}

