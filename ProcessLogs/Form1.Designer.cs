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
            this.SuspendLayout();
            // 
            // sourceDirectoryTextBox
            // 
            this.sourceDirectoryTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sourceDirectoryTextBox.Location = new System.Drawing.Point(29, 78);
            this.sourceDirectoryTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.sourceDirectoryTextBox.Name = "sourceDirectoryTextBox";
            this.sourceDirectoryTextBox.Size = new System.Drawing.Size(811, 29);
            this.sourceDirectoryTextBox.TabIndex = 0;
            // 
            // sourceDirectoryLabel
            // 
            this.sourceDirectoryLabel.AutoSize = true;
            this.sourceDirectoryLabel.Location = new System.Drawing.Point(28, 33);
            this.sourceDirectoryLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.sourceDirectoryLabel.Name = "sourceDirectoryLabel";
            this.sourceDirectoryLabel.Size = new System.Drawing.Size(158, 25);
            this.sourceDirectoryLabel.TabIndex = 1;
            this.sourceDirectoryLabel.Text = "Zdrojový adresár";
            // 
            // XMLDirectoryLabel
            // 
            this.XMLDirectoryLabel.AutoSize = true;
            this.XMLDirectoryLabel.Location = new System.Drawing.Point(29, 140);
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
            this.filePathXMLTextBox.Location = new System.Drawing.Point(31, 185);
            this.filePathXMLTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.filePathXMLTextBox.Name = "filePathXMLTextBox";
            this.filePathXMLTextBox.Size = new System.Drawing.Size(811, 29);
            this.filePathXMLTextBox.TabIndex = 2;
            // 
            // sourceDirectoryButton
            // 
            this.sourceDirectoryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sourceDirectoryButton.Location = new System.Drawing.Point(880, 72);
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
            this.filePathXMLButton.Location = new System.Drawing.Point(880, 176);
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
            this.importSettings.Location = new System.Drawing.Point(31, 247);
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
            this.statusBox.Location = new System.Drawing.Point(40, 424);
            this.statusBox.Margin = new System.Windows.Forms.Padding(4);
            this.statusBox.Name = "statusBox";
            this.statusBox.Size = new System.Drawing.Size(928, 296);
            this.statusBox.TabIndex = 7;
            this.statusBox.Text = "";
            // 
            // safebytesVerificationCheckbox
            // 
            this.safebytesVerificationCheckbox.AutoSize = true;
            this.safebytesVerificationCheckbox.Location = new System.Drawing.Point(31, 295);
            this.safebytesVerificationCheckbox.Margin = new System.Windows.Forms.Padding(4);
            this.safebytesVerificationCheckbox.Name = "safebytesVerificationCheckbox";
            this.safebytesVerificationCheckbox.Size = new System.Drawing.Size(217, 29);
            this.safebytesVerificationCheckbox.TabIndex = 8;
            this.safebytesVerificationCheckbox.Text = "Verifikácia safebytes";
            this.safebytesVerificationCheckbox.UseVisualStyleBackColor = true;
            // 
            // initiateButton
            // 
            this.initiateButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.initiateButton.Location = new System.Drawing.Point(31, 360);
            this.initiateButton.Margin = new System.Windows.Forms.Padding(4);
            this.initiateButton.Name = "initiateButton";
            this.initiateButton.Size = new System.Drawing.Size(937, 41);
            this.initiateButton.TabIndex = 9;
            this.initiateButton.Text = "Spracovať";
            this.initiateButton.UseVisualStyleBackColor = true;
            this.initiateButton.Click += new System.EventHandler(this.initiateButton_Click);
            // 
            // verboseLogCheckBox
            // 
            this.verboseLogCheckBox.AutoSize = true;
            this.verboseLogCheckBox.Location = new System.Drawing.Point(280, 295);
            this.verboseLogCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.verboseLogCheckBox.Name = "verboseLogCheckBox";
            this.verboseLogCheckBox.Size = new System.Drawing.Size(112, 29);
            this.verboseLogCheckBox.TabIndex = 10;
            this.verboseLogCheckBox.Text = "Verbose";
            this.verboseLogCheckBox.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 756);
            this.Controls.Add(this.filePathXMLButton);
            this.Controls.Add(this.verboseLogCheckBox);
            this.Controls.Add(this.initiateButton);
            this.Controls.Add(this.safebytesVerificationCheckbox);
            this.Controls.Add(this.statusBox);
            this.Controls.Add(this.importSettings);
            this.Controls.Add(this.sourceDirectoryButton);
            this.Controls.Add(this.XMLDirectoryLabel);
            this.Controls.Add(this.filePathXMLTextBox);
            this.Controls.Add(this.sourceDirectoryLabel);
            this.Controls.Add(this.sourceDirectoryTextBox);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1027, 820);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}

