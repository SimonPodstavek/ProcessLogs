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
            this.sourceDirectoryTextBox.Location = new System.Drawing.Point(16, 42);
            this.sourceDirectoryTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.sourceDirectoryTextBox.Name = "sourceDirectoryTextBox";
            this.sourceDirectoryTextBox.Size = new System.Drawing.Size(444, 20);
            this.sourceDirectoryTextBox.TabIndex = 0;
            // 
            // sourceDirectoryLabel
            // 
            this.sourceDirectoryLabel.AutoSize = true;
            this.sourceDirectoryLabel.Location = new System.Drawing.Point(15, 18);
            this.sourceDirectoryLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.sourceDirectoryLabel.Name = "sourceDirectoryLabel";
            this.sourceDirectoryLabel.Size = new System.Drawing.Size(86, 13);
            this.sourceDirectoryLabel.TabIndex = 1;
            this.sourceDirectoryLabel.Text = "Zdrojový adresár";
            // 
            // XMLDirectoryLabel
            // 
            this.XMLDirectoryLabel.AutoSize = true;
            this.XMLDirectoryLabel.Location = new System.Drawing.Point(16, 76);
            this.XMLDirectoryLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.XMLDirectoryLabel.Name = "XMLDirectoryLabel";
            this.XMLDirectoryLabel.Size = new System.Drawing.Size(109, 13);
            this.XMLDirectoryLabel.TabIndex = 3;
            this.XMLDirectoryLabel.Text = "Agregátny XML súbor";
            // 
            // filePathXMLTextBox
            // 
            this.filePathXMLTextBox.Location = new System.Drawing.Point(17, 100);
            this.filePathXMLTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.filePathXMLTextBox.Name = "filePathXMLTextBox";
            this.filePathXMLTextBox.Size = new System.Drawing.Size(444, 20);
            this.filePathXMLTextBox.TabIndex = 2;
            // 
            // sourceDirectoryButton
            // 
            this.sourceDirectoryButton.Location = new System.Drawing.Point(480, 39);
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
            this.filePathXMLButton.Location = new System.Drawing.Point(480, 100);
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
            this.importSettings.Location = new System.Drawing.Point(17, 134);
            this.importSettings.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.importSettings.Name = "importSettings";
            this.importSettings.Size = new System.Drawing.Size(91, 13);
            this.importSettings.TabIndex = 6;
            this.importSettings.Text = "Import nastavenia";
            // 
            // statusBox
            // 
            this.statusBox.Location = new System.Drawing.Point(13, 238);
            this.statusBox.Margin = new System.Windows.Forms.Padding(2);
            this.statusBox.Name = "statusBox";
            this.statusBox.Size = new System.Drawing.Size(517, 162);
            this.statusBox.TabIndex = 7;
            this.statusBox.Text = "";
            // 
            // safebytesVerificationCheckbox
            // 
            this.safebytesVerificationCheckbox.AutoSize = true;
            this.safebytesVerificationCheckbox.Location = new System.Drawing.Point(17, 160);
            this.safebytesVerificationCheckbox.Margin = new System.Windows.Forms.Padding(2);
            this.safebytesVerificationCheckbox.Name = "safebytesVerificationCheckbox";
            this.safebytesVerificationCheckbox.Size = new System.Drawing.Size(130, 21);
            this.safebytesVerificationCheckbox.TabIndex = 8;
            this.safebytesVerificationCheckbox.Text = "Verifikácia safebytes";
            this.safebytesVerificationCheckbox.UseVisualStyleBackColor = true;
            // 
            // initiateButton
            // 
            this.initiateButton.Location = new System.Drawing.Point(17, 195);
            this.initiateButton.Margin = new System.Windows.Forms.Padding(2);
            this.initiateButton.Name = "initiateButton";
            this.initiateButton.Size = new System.Drawing.Size(511, 22);
            this.initiateButton.TabIndex = 9;
            this.initiateButton.Text = "Spracovať";
            this.initiateButton.UseVisualStyleBackColor = true;
            this.initiateButton.Click += new System.EventHandler(this.initiateButton_Click);
            // 
            // verboseLogCheckBox
            // 
            this.verboseLogCheckBox.AutoSize = true;
            this.verboseLogCheckBox.Location = new System.Drawing.Point(153, 160);
            this.verboseLogCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.verboseLogCheckBox.Name = "verboseLogCheckBox";
            this.verboseLogCheckBox.Size = new System.Drawing.Size(72, 21);
            this.verboseLogCheckBox.TabIndex = 10;
            this.verboseLogCheckBox.Text = "Verbose";
            this.verboseLogCheckBox.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 425);
            this.Controls.Add(this.verboseLogCheckBox);
            this.Controls.Add(this.initiateButton);
            this.Controls.Add(this.safebytesVerificationCheckbox);
            this.Controls.Add(this.statusBox);
            this.Controls.Add(this.importSettings);
            this.Controls.Add(this.filePathXMLButton);
            this.Controls.Add(this.sourceDirectoryButton);
            this.Controls.Add(this.XMLDirectoryLabel);
            this.Controls.Add(this.filePathXMLTextBox);
            this.Controls.Add(this.sourceDirectoryLabel);
            this.Controls.Add(this.sourceDirectoryTextBox);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox sourceDirectoryTextBox;
        private System.Windows.Forms.Label sourceDirectoryLabel;
        private System.Windows.Forms.Label XMLDirectoryLabel;
        private System.Windows.Forms.TextBox filePathXMLTextBox;
        private System.Windows.Forms.Button sourceDirectoryButton;
        private System.Windows.Forms.Button filePathXMLButton;
        private System.Windows.Forms.Label importSettings;
        private System.Windows.Forms.RichTextBox statusBox;
        private System.Windows.Forms.CheckBox safebytesVerificationCheckbox;
        private System.Windows.Forms.Button initiateButton;
        private System.Windows.Forms.CheckBox verboseLogCheckBox;
    }
}

