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
            this.safebytesVerificationCheckbox = new System.Windows.Forms.CheckBox();
            this.initiateButton = new System.Windows.Forms.Button();
            this.verboseLogCheckBox = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // sourceDirectoryTextBox
            // 
            this.sourceDirectoryTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sourceDirectoryTextBox.Location = new System.Drawing.Point(4, 36);
            this.sourceDirectoryTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.sourceDirectoryTextBox.Name = "sourceDirectoryTextBox";
            this.sourceDirectoryTextBox.Size = new System.Drawing.Size(805, 29);
            this.sourceDirectoryTextBox.TabIndex = 0;
            // 
            // sourceDirectoryLabel
            // 
            this.sourceDirectoryLabel.AutoSize = true;
            this.sourceDirectoryLabel.Location = new System.Drawing.Point(4, 0);
            this.sourceDirectoryLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.sourceDirectoryLabel.Name = "sourceDirectoryLabel";
            this.sourceDirectoryLabel.Size = new System.Drawing.Size(158, 25);
            this.sourceDirectoryLabel.TabIndex = 1;
            this.sourceDirectoryLabel.Text = "Zdrojový adresár";
            // 
            // XMLDirectoryLabel
            // 
            this.XMLDirectoryLabel.AutoSize = true;
            this.XMLDirectoryLabel.Location = new System.Drawing.Point(4, 0);
            this.XMLDirectoryLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.XMLDirectoryLabel.Name = "XMLDirectoryLabel";
            this.XMLDirectoryLabel.Size = new System.Drawing.Size(203, 25);
            this.XMLDirectoryLabel.TabIndex = 3;
            this.XMLDirectoryLabel.Text = "Agregátny XML súbor";
            // 
            // filePathXMLTextBox
            // 
            this.filePathXMLTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filePathXMLTextBox.Location = new System.Drawing.Point(4, 36);
            this.filePathXMLTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.filePathXMLTextBox.Name = "filePathXMLTextBox";
            this.filePathXMLTextBox.Size = new System.Drawing.Size(805, 29);
            this.filePathXMLTextBox.TabIndex = 2;
            // 
            // sourceDirectoryButton
            // 
            this.sourceDirectoryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sourceDirectoryButton.Location = new System.Drawing.Point(21, 36);
            this.sourceDirectoryButton.Margin = new System.Windows.Forms.Padding(4);
            this.sourceDirectoryButton.Name = "sourceDirectoryButton";
            this.sourceDirectoryButton.Size = new System.Drawing.Size(99, 37);
            this.sourceDirectoryButton.TabIndex = 4;
            this.sourceDirectoryButton.Text = "Vybrať";
            this.sourceDirectoryButton.UseVisualStyleBackColor = true;
            this.sourceDirectoryButton.Click += new System.EventHandler(this.sourceDirectoryButton_Click);
            // 
            // filePathXMLButton
            // 
            this.filePathXMLButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.filePathXMLButton.Location = new System.Drawing.Point(21, 36);
            this.filePathXMLButton.Margin = new System.Windows.Forms.Padding(4);
            this.filePathXMLButton.Name = "filePathXMLButton";
            this.filePathXMLButton.Size = new System.Drawing.Size(99, 37);
            this.filePathXMLButton.TabIndex = 5;
            this.filePathXMLButton.Text = "Vybrať";
            this.filePathXMLButton.UseVisualStyleBackColor = true;
            this.filePathXMLButton.Click += new System.EventHandler(this.XMLDirectoryButton_Click);
            // 
            // importSettings
            // 
            this.importSettings.AutoSize = true;
            this.importSettings.Location = new System.Drawing.Point(4, 0);
            this.importSettings.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.importSettings.Name = "importSettings";
            this.importSettings.Size = new System.Drawing.Size(166, 25);
            this.importSettings.TabIndex = 6;
            this.importSettings.Text = "Import nastavenia";
            // 
            // statusBox
            // 
            this.statusBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.statusBox, 2);
            this.statusBox.Location = new System.Drawing.Point(44, 374);
            this.statusBox.Margin = new System.Windows.Forms.Padding(4);
            this.statusBox.Name = "statusBox";
            this.statusBox.Size = new System.Drawing.Size(941, 369);
            this.statusBox.TabIndex = 7;
            this.statusBox.Text = "";
            // 
            // safebytesVerificationCheckbox
            // 
            this.safebytesVerificationCheckbox.AutoSize = true;
            this.safebytesVerificationCheckbox.Location = new System.Drawing.Point(4, 41);
            this.safebytesVerificationCheckbox.Margin = new System.Windows.Forms.Padding(4);
            this.safebytesVerificationCheckbox.Name = "safebytesVerificationCheckbox";
            this.safebytesVerificationCheckbox.Size = new System.Drawing.Size(217, 29);
            this.safebytesVerificationCheckbox.TabIndex = 8;
            this.safebytesVerificationCheckbox.Text = "Verifikácia safebytes";
            this.safebytesVerificationCheckbox.UseVisualStyleBackColor = true;
            // 
            // initiateButton
            // 
            this.initiateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.initiateButton, 2);
            this.initiateButton.Location = new System.Drawing.Point(44, 324);
            this.initiateButton.Margin = new System.Windows.Forms.Padding(4);
            this.initiateButton.Name = "initiateButton";
            this.initiateButton.Size = new System.Drawing.Size(941, 42);
            this.initiateButton.TabIndex = 9;
            this.initiateButton.Text = "Spracovať";
            this.initiateButton.UseVisualStyleBackColor = true;
            this.initiateButton.Click += new System.EventHandler(this.initiateButton_Click);
            // 
            // verboseLogCheckBox
            // 
            this.verboseLogCheckBox.AutoSize = true;
            this.verboseLogCheckBox.Location = new System.Drawing.Point(304, 41);
            this.verboseLogCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.verboseLogCheckBox.Name = "verboseLogCheckBox";
            this.verboseLogCheckBox.Size = new System.Drawing.Size(112, 29);
            this.verboseLogCheckBox.TabIndex = 10;
            this.verboseLogCheckBox.Text = "Verbose";
            this.verboseLogCheckBox.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel6, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.statusBox, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.initiateButton, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(40);
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1029, 787);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 468F));
            this.tableLayoutPanel6.Controls.Add(this.importSettings, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.verboseLogCheckBox, 1, 1);
            this.tableLayoutPanel6.Controls.Add(this.safebytesVerificationCheckbox, 0, 1);
            this.tableLayoutPanel6.Location = new System.Drawing.Point(43, 243);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(813, 74);
            this.tableLayoutPanel6.TabIndex = 13;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.filePathXMLButton, 0, 1);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(862, 143);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(124, 94);
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
            this.tableLayoutPanel3.Location = new System.Drawing.Point(43, 143);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(813, 94);
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
            this.tableLayoutPanel2.Location = new System.Drawing.Point(43, 43);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(813, 94);
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
            this.tableLayoutPanel4.Location = new System.Drawing.Point(862, 43);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(124, 94);
            this.tableLayoutPanel4.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 787);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1027, 820);
            this.Name = "Form1";
            this.Text = "Form1";
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
        private System.Windows.Forms.CheckBox safebytesVerificationCheckbox;
        private System.Windows.Forms.Button initiateButton;
        private System.Windows.Forms.CheckBox verboseLogCheckBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
    }
}

