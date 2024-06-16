namespace ProcessLogs
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
            this.sourceDirectoryTextBox = new System.Windows.Forms.TextBox();
            this.sourceDirectoryLabel = new System.Windows.Forms.Label();
            this.XMLDirectoryLabel = new System.Windows.Forms.Label();
            this.filePathXMLTextBox = new System.Windows.Forms.TextBox();
            this.sourceDirectoryButton = new System.Windows.Forms.Button();
            this.filePathXMLButton = new System.Windows.Forms.Button();
            this.importSettings = new System.Windows.Forms.Label();
            this.statusBox = new System.Windows.Forms.RichTextBox();
            this.XMLStrucutreAggregateImportCheck = new System.Windows.Forms.CheckBox();
            this.initiateButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.XMLStructureVerification = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // sourceDirectoryTextBox
            // 
            this.sourceDirectoryTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sourceDirectoryTextBox.Location = new System.Drawing.Point(2, 19);
            this.sourceDirectoryTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.sourceDirectoryTextBox.Name = "sourceDirectoryTextBox";
            this.sourceDirectoryTextBox.Size = new System.Drawing.Size(438, 20);
            this.sourceDirectoryTextBox.TabIndex = 0;
            // 
            // sourceDirectoryLabel
            // 
            this.sourceDirectoryLabel.AutoSize = true;
            this.sourceDirectoryLabel.Location = new System.Drawing.Point(2, 0);
            this.sourceDirectoryLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.sourceDirectoryLabel.Name = "sourceDirectoryLabel";
            this.sourceDirectoryLabel.Size = new System.Drawing.Size(86, 13);
            this.sourceDirectoryLabel.TabIndex = 1;
            this.sourceDirectoryLabel.Text = "Zdrojový adresár";
            // 
            // XMLDirectoryLabel
            // 
            this.XMLDirectoryLabel.AutoSize = true;
            this.XMLDirectoryLabel.Location = new System.Drawing.Point(2, 0);
            this.XMLDirectoryLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.XMLDirectoryLabel.Name = "XMLDirectoryLabel";
            this.XMLDirectoryLabel.Size = new System.Drawing.Size(109, 13);
            this.XMLDirectoryLabel.TabIndex = 3;
            this.XMLDirectoryLabel.Text = "Agregátny XML súbor";
            // 
            // filePathXMLTextBox
            // 
            this.filePathXMLTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filePathXMLTextBox.Location = new System.Drawing.Point(2, 19);
            this.filePathXMLTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.filePathXMLTextBox.Name = "filePathXMLTextBox";
            this.filePathXMLTextBox.Size = new System.Drawing.Size(438, 20);
            this.filePathXMLTextBox.TabIndex = 2;
            // 
            // sourceDirectoryButton
            // 
            this.sourceDirectoryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sourceDirectoryButton.Location = new System.Drawing.Point(11, 19);
            this.sourceDirectoryButton.Margin = new System.Windows.Forms.Padding(2);
            this.sourceDirectoryButton.Name = "sourceDirectoryButton";
            this.sourceDirectoryButton.Size = new System.Drawing.Size(54, 20);
            this.sourceDirectoryButton.TabIndex = 4;
            this.sourceDirectoryButton.Text = "Vybrať";
            this.sourceDirectoryButton.UseVisualStyleBackColor = true;
            this.sourceDirectoryButton.Click += new System.EventHandler(this.sourceDirectoryButton_Click);
            // 
            // filePathXMLButton
            // 
            this.filePathXMLButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.filePathXMLButton.Location = new System.Drawing.Point(11, 19);
            this.filePathXMLButton.Margin = new System.Windows.Forms.Padding(2);
            this.filePathXMLButton.Name = "filePathXMLButton";
            this.filePathXMLButton.Size = new System.Drawing.Size(54, 20);
            this.filePathXMLButton.TabIndex = 5;
            this.filePathXMLButton.Text = "Vybrať";
            this.filePathXMLButton.UseVisualStyleBackColor = true;
            this.filePathXMLButton.Click += new System.EventHandler(this.XMLDirectoryButton_Click);
            // 
            // importSettings
            // 
            this.importSettings.AutoSize = true;
            this.tableLayoutPanel6.SetColumnSpan(this.importSettings, 2);
            this.importSettings.Location = new System.Drawing.Point(2, 0);
            this.importSettings.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.importSettings.Name = "importSettings";
            this.importSettings.Size = new System.Drawing.Size(243, 13);
            this.importSettings.TabIndex = 6;
            this.importSettings.Text = "Nastavenia verifikácie štruktúry agregátneho XML";
            // 
            // statusBox
            // 
            this.statusBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.statusBox, 2);
            this.statusBox.Location = new System.Drawing.Point(24, 245);
            this.statusBox.Margin = new System.Windows.Forms.Padding(2);
            this.statusBox.Name = "statusBox";
            this.statusBox.ReadOnly = true;
            this.statusBox.Size = new System.Drawing.Size(513, 283);
            this.statusBox.TabIndex = 7;
            this.statusBox.Text = "";
            // 
            // XMLStrucutreAggregateImportCheck
            // 
            this.XMLStrucutreAggregateImportCheck.AutoSize = true;
            this.XMLStrucutreAggregateImportCheck.Location = new System.Drawing.Point(2, 21);
            this.XMLStrucutreAggregateImportCheck.Margin = new System.Windows.Forms.Padding(2);
            this.XMLStrucutreAggregateImportCheck.Name = "XMLStrucutreAggregateImportCheck";
            this.XMLStrucutreAggregateImportCheck.Size = new System.Drawing.Size(81, 16);
            this.XMLStrucutreAggregateImportCheck.TabIndex = 8;
            this.XMLStrucutreAggregateImportCheck.Text = "Pri otvorení";
            this.XMLStrucutreAggregateImportCheck.UseVisualStyleBackColor = true;
            // 
            // initiateButton
            // 
            this.initiateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.initiateButton, 2);
            this.initiateButton.Location = new System.Drawing.Point(24, 218);
            this.initiateButton.Margin = new System.Windows.Forms.Padding(2);
            this.initiateButton.Name = "initiateButton";
            this.initiateButton.Size = new System.Drawing.Size(513, 23);
            this.initiateButton.TabIndex = 9;
            this.initiateButton.Text = "Spracovať";
            this.initiateButton.UseVisualStyleBackColor = true;
            this.initiateButton.Click += new System.EventHandler(this.initiateButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 71F));
            this.tableLayoutPanel1.Controls.Add(this.statusBox, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.initiateButton, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel6, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel7, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(22);
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(561, 552);
            this.tableLayoutPanel1.TabIndex = 11;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 3;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel6.Controls.Add(this.importSettings, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.XMLStrucutreAggregateImportCheck, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.XMLStructureVerification, 1, 1);
            this.tableLayoutPanel6.Location = new System.Drawing.Point(24, 132);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(442, 39);
            this.tableLayoutPanel6.TabIndex = 13;
            // 
            // XMLStructureVerification
            // 
            this.XMLStructureVerification.AutoSize = true;
            this.XMLStructureVerification.Checked = true;
            this.XMLStructureVerification.CheckState = System.Windows.Forms.CheckState.Checked;
            this.XMLStructureVerification.Location = new System.Drawing.Point(134, 21);
            this.XMLStructureVerification.Margin = new System.Windows.Forms.Padding(2);
            this.XMLStructureVerification.Name = "XMLStructureVerification";
            this.XMLStructureVerification.Size = new System.Drawing.Size(71, 16);
            this.XMLStructureVerification.TabIndex = 11;
            this.XMLStructureVerification.Text = "Pri zápise";
            this.XMLStructureVerification.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.filePathXMLButton, 0, 1);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(470, 78);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(67, 50);
            this.tableLayoutPanel5.TabIndex = 14;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.XMLDirectoryLabel, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.filePathXMLTextBox, 0, 1);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(24, 78);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(442, 50);
            this.tableLayoutPanel3.TabIndex = 12;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.sourceDirectoryTextBox, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.sourceDirectoryLabel, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(24, 24);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(442, 50);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.sourceDirectoryButton, 0, 1);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(470, 24);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(67, 50);
            this.tableLayoutPanel4.TabIndex = 13;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 3;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel7.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.checkBox1, 0, 1);
            this.tableLayoutPanel7.Controls.Add(this.checkBox2, 2, 1);
            this.tableLayoutPanel7.Controls.Add(this.checkBox3, 1, 1);
            this.tableLayoutPanel7.Location = new System.Drawing.Point(24, 175);
            this.tableLayoutPanel7.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 2;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(442, 39);
            this.tableLayoutPanel7.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.tableLayoutPanel7.SetColumnSpan(this.label1, 2);
            this.label1.Location = new System.Drawing.Point(2, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Nastavenia spracovávaných logov";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(2, 21);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(101, 16);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "Verifikácia hash";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(310, 21);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(65, 16);
            this.checkBox2.TabIndex = 10;
            this.checkBox2.Text = "Verbose";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Checked = true;
            this.checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox3.Location = new System.Drawing.Point(134, 21);
            this.checkBox3.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(143, 16);
            this.checkBox3.TabIndex = 11;
            this.checkBox3.Text = "Verifikácia XML štruktúry";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 552);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(567, 462);
            this.Name = "Form1";
            this.Text = "Log parser";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.RichTextBox statusBox;
        private System.Windows.Forms.TextBox sourceDirectoryTextBox;
        private System.Windows.Forms.Label sourceDirectoryLabel;
        private System.Windows.Forms.Label XMLDirectoryLabel;
        private System.Windows.Forms.TextBox filePathXMLTextBox;
        private System.Windows.Forms.Button sourceDirectoryButton;
        private System.Windows.Forms.Button filePathXMLButton;
        private System.Windows.Forms.Label importSettings;
        private System.Windows.Forms.CheckBox XMLStrucutreAggregateImportCheck;
        private System.Windows.Forms.Button initiateButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.CheckBox XMLStructureVerification;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
    }
}

