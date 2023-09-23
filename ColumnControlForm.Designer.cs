namespace SUBD
{
    partial class ColumnControlForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.CreateButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.ColumnNameTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TablesComboBox = new System.Windows.Forms.ComboBox();
            this.TypesComboBox = new System.Windows.Forms.ComboBox();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.ColumnsComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Table";
            // 
            // CreateButton
            // 
            this.CreateButton.Location = new System.Drawing.Point(12, 160);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(243, 59);
            this.CreateButton.TabIndex = 3;
            this.CreateButton.Text = "Create";
            this.CreateButton.UseVisualStyleBackColor = true;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Column name";
            // 
            // ColumnNameTextBox
            // 
            this.ColumnNameTextBox.Location = new System.Drawing.Point(12, 74);
            this.ColumnNameTextBox.Name = "ColumnNameTextBox";
            this.ColumnNameTextBox.Size = new System.Drawing.Size(243, 22);
            this.ColumnNameTextBox.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Column type";
            // 
            // TablesComboBox
            // 
            this.TablesComboBox.FormattingEnabled = true;
            this.TablesComboBox.Location = new System.Drawing.Point(12, 27);
            this.TablesComboBox.Name = "TablesComboBox";
            this.TablesComboBox.Size = new System.Drawing.Size(243, 24);
            this.TablesComboBox.TabIndex = 10;
            this.TablesComboBox.SelectedIndexChanged += new System.EventHandler(this.TablesComboBox_SelectedIndexChanged);
            // 
            // TypesComboBox
            // 
            this.TypesComboBox.FormattingEnabled = true;
            this.TypesComboBox.Location = new System.Drawing.Point(12, 123);
            this.TypesComboBox.Name = "TypesComboBox";
            this.TypesComboBox.Size = new System.Drawing.Size(243, 24);
            this.TypesComboBox.TabIndex = 11;
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(12, 160);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(243, 59);
            this.DeleteButton.TabIndex = 12;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // ColumnsComboBox
            // 
            this.ColumnsComboBox.FormattingEnabled = true;
            this.ColumnsComboBox.Location = new System.Drawing.Point(12, 74);
            this.ColumnsComboBox.Name = "ColumnsComboBox";
            this.ColumnsComboBox.Size = new System.Drawing.Size(243, 24);
            this.ColumnsComboBox.TabIndex = 13;
            // 
            // ColumnControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 232);
            this.Controls.Add(this.ColumnsComboBox);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.TypesComboBox);
            this.Controls.Add(this.TablesComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ColumnNameTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CreateButton);
            this.Name = "ColumnControlForm";
            this.Text = "ColumnControlForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ColumnControlForm_FormClosing);
            this.Load += new System.EventHandler(this.ColumnControlForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ColumnNameTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox TablesComboBox;
        private System.Windows.Forms.ComboBox TypesComboBox;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.ComboBox ColumnsComboBox;
    }
}