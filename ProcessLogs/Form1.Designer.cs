using ProcessLogs.utilities;
using System;

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


        private void MinimumSizeCheckboxChecked(object sender, EventArgs e)
        {
            if (minimumRecordSizeCheckBox.Checked)
            {
                minimumRecordSizeNumeric.Enabled = true;
            }
            else
            {
                minimumRecordSizeNumeric.Enabled = false;
            }
        }

        private void MaximumSizeCheckboxChecked(object sender, EventArgs e)
        {
            if (maximumRecordSizeCheckBox.Checked)
            {
                maximumRecordSizeNumeric.Enabled = true;
            }
            else
            {
                maximumRecordSizeNumeric.Enabled = false;
            }
        }


        private void verifyDuplicityCheckBoxPermission(object sender, EventArgs e)
        {
            if (verifyAggregateXMLStructureOnLoadCheck.Checked && VerifyLogHashCheck.Checked)
            {
                preventDuplicatesCheckBox.Enabled = true;
            }
            else
            {
                preventDuplicatesCheckBox.Checked = false;
                preventDuplicatesCheckBox.Enabled = false;
            }
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
            this.verifyAggregateXMLStructureOnLoadCheck = new System.Windows.Forms.CheckBox();
            this.initiateButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.verifyAggregateXMLStructureOnCloseCheck = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.VerifyLogHashCheck = new System.Windows.Forms.CheckBox();
            this.verifyLogXMLStructureCheck = new System.Windows.Forms.CheckBox();
            this.verboseLogCheckBox = new System.Windows.Forms.CheckBox();
            this.preventDuplicatesCheckBox = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.maximumRecordSizeNumeric = new System.Windows.Forms.NumericUpDown();
            this.minimumRecordSizeNumeric = new System.Windows.Forms.NumericUpDown();
            this.minimumRecordSizeCheckBox = new System.Windows.Forms.CheckBox();
            this.maximumRecordSizeCheckBox = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maximumRecordSizeNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimumRecordSizeNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // sourceDirectoryTextBox
            // 
            this.sourceDirectoryTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sourceDirectoryTextBox.Location = new System.Drawing.Point(4, 36);
            this.sourceDirectoryTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.sourceDirectoryTextBox.Name = "sourceDirectoryTextBox";
            this.sourceDirectoryTextBox.Size = new System.Drawing.Size(801, 29);
            this.sourceDirectoryTextBox.TabIndex = 0;
            // 
            // sourceDirectoryLabel
            // 
            this.sourceDirectoryLabel.AutoSize = true;
            this.sourceDirectoryLabel.Location = new System.Drawing.Point(4, 0);
            this.sourceDirectoryLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.sourceDirectoryLabel.Name = "sourceDirectoryLabel";
            this.sourceDirectoryLabel.Size = new System.Drawing.Size(158, 25);
            this.sourceDirectoryLabel.TabIndex = 0;
            this.sourceDirectoryLabel.Text = "Zdrojový adresár";
            // 
            // XMLDirectoryLabel
            // 
            this.XMLDirectoryLabel.AutoSize = true;
            this.XMLDirectoryLabel.Location = new System.Drawing.Point(4, 0);
            this.XMLDirectoryLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.XMLDirectoryLabel.Name = "XMLDirectoryLabel";
            this.XMLDirectoryLabel.Size = new System.Drawing.Size(203, 25);
            this.XMLDirectoryLabel.TabIndex = 1;
            this.XMLDirectoryLabel.Text = "Agregátny XML súbor";
            // 
            // filePathXMLTextBox
            // 
            this.filePathXMLTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filePathXMLTextBox.Location = new System.Drawing.Point(4, 36);
            this.filePathXMLTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.filePathXMLTextBox.Name = "filePathXMLTextBox";
            this.filePathXMLTextBox.Size = new System.Drawing.Size(801, 29);
            this.filePathXMLTextBox.TabIndex = 0;
            // 
            // sourceDirectoryButton
            // 
            this.sourceDirectoryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sourceDirectoryButton.Location = new System.Drawing.Point(20, 36);
            this.sourceDirectoryButton.Margin = new System.Windows.Forms.Padding(4);
            this.sourceDirectoryButton.Name = "sourceDirectoryButton";
            this.sourceDirectoryButton.Size = new System.Drawing.Size(99, 37);
            this.sourceDirectoryButton.TabIndex = 0;
            this.sourceDirectoryButton.Text = "Vybrať";
            this.sourceDirectoryButton.UseVisualStyleBackColor = true;
            this.sourceDirectoryButton.Click += new System.EventHandler(this.sourceDirectoryButton_Click);
            // 
            // filePathXMLButton
            // 
            this.filePathXMLButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.filePathXMLButton.Location = new System.Drawing.Point(20, 36);
            this.filePathXMLButton.Margin = new System.Windows.Forms.Padding(4);
            this.filePathXMLButton.Name = "filePathXMLButton";
            this.filePathXMLButton.Size = new System.Drawing.Size(99, 37);
            this.filePathXMLButton.TabIndex = 0;
            this.filePathXMLButton.Text = "Vybrať";
            this.filePathXMLButton.UseVisualStyleBackColor = true;
            this.filePathXMLButton.Click += new System.EventHandler(this.XMLDirectoryButton_Click);
            // 
            // importSettings
            // 
            this.importSettings.AutoSize = true;
            this.tableLayoutPanel6.SetColumnSpan(this.importSettings, 2);
            this.importSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.importSettings.Location = new System.Drawing.Point(4, 0);
            this.importSettings.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.importSettings.Name = "importSettings";
            this.importSettings.Size = new System.Drawing.Size(497, 25);
            this.importSettings.TabIndex = 0;
            this.importSettings.Text = "Nastavenia verifikácie štruktúry agregátneho XML:";
            // 
            // statusBox
            // 
            this.statusBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.statusBox, 2);
            this.statusBox.HideSelection = false;
            this.statusBox.Location = new System.Drawing.Point(44, 571);
            this.statusBox.Margin = new System.Windows.Forms.Padding(4);
            this.statusBox.Name = "statusBox";
            this.statusBox.ReadOnly = true;
            this.statusBox.Size = new System.Drawing.Size(940, 460);
            this.statusBox.TabIndex = 0;
            this.statusBox.TabStop = false;
            this.statusBox.Text = "";
            // 
            // verifyAggregateXMLStructureOnLoadCheck
            // 
            this.verifyAggregateXMLStructureOnLoadCheck.AutoSize = true;
            this.verifyAggregateXMLStructureOnLoadCheck.Checked = true;
            this.verifyAggregateXMLStructureOnLoadCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.verifyAggregateXMLStructureOnLoadCheck.Location = new System.Drawing.Point(18, 50);
            this.verifyAggregateXMLStructureOnLoadCheck.Margin = new System.Windows.Forms.Padding(18, 4, 4, 4);
            this.verifyAggregateXMLStructureOnLoadCheck.Name = "verifyAggregateXMLStructureOnLoadCheck";
            this.verifyAggregateXMLStructureOnLoadCheck.Size = new System.Drawing.Size(135, 29);
            this.verifyAggregateXMLStructureOnLoadCheck.TabIndex = 0;
            this.verifyAggregateXMLStructureOnLoadCheck.Text = "Pri otvorení";
            this.verifyAggregateXMLStructureOnLoadCheck.UseVisualStyleBackColor = true;
            this.verifyAggregateXMLStructureOnLoadCheck.CheckedChanged += new System.EventHandler(this.verifyDuplicityCheckBoxPermission);
            // 
            // initiateButton
            // 
            this.initiateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.initiateButton, 2);
            this.initiateButton.Location = new System.Drawing.Point(44, 521);
            this.initiateButton.Margin = new System.Windows.Forms.Padding(4);
            this.initiateButton.Name = "initiateButton";
            this.initiateButton.Size = new System.Drawing.Size(940, 42);
            this.initiateButton.TabIndex = 7;
            this.initiateButton.Text = "Spracovať";
            this.initiateButton.UseVisualStyleBackColor = true;
            this.initiateButton.Click += new System.EventHandler(this.initiateButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 131F));
            this.tableLayoutPanel1.Controls.Add(this.statusBox, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.initiateButton, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel6, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel7, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel8, 0, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(40, 41, 40, 41);
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1028, 1062);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.filePathXMLButton, 0, 1);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(861, 145);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(123, 92);
            this.tableLayoutPanel5.TabIndex = 3;
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
            this.tableLayoutPanel3.Location = new System.Drawing.Point(44, 145);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(809, 92);
            this.tableLayoutPanel3.TabIndex = 2;
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
            this.tableLayoutPanel2.Location = new System.Drawing.Point(44, 45);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(809, 92);
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
            this.tableLayoutPanel4.Location = new System.Drawing.Point(861, 45);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(123, 92);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 3;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel6.Controls.Add(this.importSettings, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.verifyAggregateXMLStructureOnLoadCheck, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.verifyAggregateXMLStructureOnCloseCheck, 1, 1);
            this.tableLayoutPanel6.Location = new System.Drawing.Point(44, 245);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(809, 84);
            this.tableLayoutPanel6.TabIndex = 4;
            // 
            // verifyAggregateXMLStructureOnCloseCheck
            // 
            this.verifyAggregateXMLStructureOnCloseCheck.AutoSize = true;
            this.verifyAggregateXMLStructureOnCloseCheck.Checked = true;
            this.verifyAggregateXMLStructureOnCloseCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.verifyAggregateXMLStructureOnCloseCheck.Location = new System.Drawing.Point(246, 50);
            this.verifyAggregateXMLStructureOnCloseCheck.Margin = new System.Windows.Forms.Padding(4);
            this.verifyAggregateXMLStructureOnCloseCheck.Name = "verifyAggregateXMLStructureOnCloseCheck";
            this.verifyAggregateXMLStructureOnCloseCheck.Size = new System.Drawing.Size(123, 29);
            this.verifyAggregateXMLStructureOnCloseCheck.TabIndex = 1;
            this.verifyAggregateXMLStructureOnCloseCheck.Text = "Pri zápise";
            this.verifyAggregateXMLStructureOnCloseCheck.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 4;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel7, 2);
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel7.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.VerifyLogHashCheck, 0, 1);
            this.tableLayoutPanel7.Controls.Add(this.verifyLogXMLStructureCheck, 1, 1);
            this.tableLayoutPanel7.Controls.Add(this.verboseLogCheckBox, 3, 1);
            this.tableLayoutPanel7.Controls.Add(this.preventDuplicatesCheckBox, 2, 1);
            this.tableLayoutPanel7.Location = new System.Drawing.Point(44, 337);
            this.tableLayoutPanel7.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 2;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(940, 84);
            this.tableLayoutPanel7.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.tableLayoutPanel7.SetColumnSpan(this.label1, 5);
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(4, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(580, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nastavenie spracovania záznamov (diskvalifikuje záznam):";
            // 
            // VerifyLogHashCheck
            // 
            this.VerifyLogHashCheck.AutoSize = true;
            this.VerifyLogHashCheck.Checked = true;
            this.VerifyLogHashCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.VerifyLogHashCheck.Location = new System.Drawing.Point(18, 50);
            this.VerifyLogHashCheck.Margin = new System.Windows.Forms.Padding(18, 4, 4, 4);
            this.VerifyLogHashCheck.Name = "VerifyLogHashCheck";
            this.VerifyLogHashCheck.Size = new System.Drawing.Size(176, 29);
            this.VerifyLogHashCheck.TabIndex = 0;
            this.VerifyLogHashCheck.Text = "Verifikácia hash";
            this.VerifyLogHashCheck.UseVisualStyleBackColor = true;
            this.VerifyLogHashCheck.CheckedChanged += new System.EventHandler(this.verifyDuplicityCheckBoxPermission);
            // 
            // verifyLogXMLStructureCheck
            // 
            this.verifyLogXMLStructureCheck.AutoSize = true;
            this.verifyLogXMLStructureCheck.Checked = true;
            this.verifyLogXMLStructureCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.verifyLogXMLStructureCheck.Location = new System.Drawing.Point(239, 50);
            this.verifyLogXMLStructureCheck.Margin = new System.Windows.Forms.Padding(4);
            this.verifyLogXMLStructureCheck.Name = "verifyLogXMLStructureCheck";
            this.verifyLogXMLStructureCheck.Size = new System.Drawing.Size(254, 29);
            this.verifyLogXMLStructureCheck.TabIndex = 1;
            this.verifyLogXMLStructureCheck.Text = "Verifikácia XML štruktúry";
            this.verifyLogXMLStructureCheck.UseVisualStyleBackColor = true;
            // 
            // verboseLogCheckBox
            // 
            this.verboseLogCheckBox.AutoSize = true;
            this.verboseLogCheckBox.Checked = true;
            this.verboseLogCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.verboseLogCheckBox.Location = new System.Drawing.Point(756, 50);
            this.verboseLogCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.verboseLogCheckBox.Name = "verboseLogCheckBox";
            this.verboseLogCheckBox.Size = new System.Drawing.Size(112, 29);
            this.verboseLogCheckBox.TabIndex = 3;
            this.verboseLogCheckBox.Text = "Verbose";
            this.verboseLogCheckBox.UseVisualStyleBackColor = true;
            // 
            // preventDuplicatesCheckBox
            // 
            this.preventDuplicatesCheckBox.AutoSize = true;
            this.preventDuplicatesCheckBox.Checked = true;
            this.preventDuplicatesCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.preventDuplicatesCheckBox.Location = new System.Drawing.Point(521, 50);
            this.preventDuplicatesCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.preventDuplicatesCheckBox.Name = "preventDuplicatesCheckBox";
            this.preventDuplicatesCheckBox.Size = new System.Drawing.Size(200, 29);
            this.preventDuplicatesCheckBox.TabIndex = 2;
            this.preventDuplicatesCheckBox.Text = "Prevencia duplicity";
            this.preventDuplicatesCheckBox.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 4;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23F));
            this.tableLayoutPanel8.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.maximumRecordSizeNumeric, 3, 1);
            this.tableLayoutPanel8.Controls.Add(this.minimumRecordSizeNumeric, 1, 1);
            this.tableLayoutPanel8.Controls.Add(this.minimumRecordSizeCheckBox, 0, 1);
            this.tableLayoutPanel8.Controls.Add(this.maximumRecordSizeCheckBox, 2, 1);
            this.tableLayoutPanel8.Location = new System.Drawing.Point(46, 431);
            this.tableLayoutPanel8.Margin = new System.Windows.Forms.Padding(6);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 2;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(805, 79);
            this.tableLayoutPanel8.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.tableLayoutPanel8.SetColumnSpan(this.label2, 4);
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(4, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(559, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nastavenie spracovania záznamov (diskvalifikuje súbor):";
            // 
            // maximumRecordSizeNumeric
            // 
            this.maximumRecordSizeNumeric.Location = new System.Drawing.Point(625, 45);
            this.maximumRecordSizeNumeric.Margin = new System.Windows.Forms.Padding(6);
            this.maximumRecordSizeNumeric.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.maximumRecordSizeNumeric.Name = "maximumRecordSizeNumeric";
            this.maximumRecordSizeNumeric.Size = new System.Drawing.Size(110, 29);
            this.maximumRecordSizeNumeric.TabIndex = 3;
            this.maximumRecordSizeNumeric.Value = new decimal(new int[] {
            1800,
            0,
            0,
            0});
            // 
            // minimumRecordSizeNumeric
            // 
            this.minimumRecordSizeNumeric.Location = new System.Drawing.Point(223, 45);
            this.minimumRecordSizeNumeric.Margin = new System.Windows.Forms.Padding(6);
            this.minimumRecordSizeNumeric.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.minimumRecordSizeNumeric.Name = "minimumRecordSizeNumeric";
            this.minimumRecordSizeNumeric.Size = new System.Drawing.Size(110, 29);
            this.minimumRecordSizeNumeric.TabIndex = 1;
            this.minimumRecordSizeNumeric.Value = new decimal(new int[] {
            850,
            0,
            0,
            0});
            // 
            // minimumRecordSizeCheckBox
            // 
            this.minimumRecordSizeCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.minimumRecordSizeCheckBox.AutoSize = true;
            this.minimumRecordSizeCheckBox.Checked = true;
            this.minimumRecordSizeCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.minimumRecordSizeCheckBox.Location = new System.Drawing.Point(18, 43);
            this.minimumRecordSizeCheckBox.Margin = new System.Windows.Forms.Padding(18, 4, 4, 4);
            this.minimumRecordSizeCheckBox.Name = "minimumRecordSizeCheckBox";
            this.minimumRecordSizeCheckBox.Size = new System.Drawing.Size(195, 32);
            this.minimumRecordSizeCheckBox.TabIndex = 0;
            this.minimumRecordSizeCheckBox.Text = "Minimálna dĺžka";
            this.minimumRecordSizeCheckBox.UseVisualStyleBackColor = true;
            this.minimumRecordSizeCheckBox.CheckedChanged += new System.EventHandler(this.MinimumSizeCheckboxChecked);
            // 
            // maximumRecordSizeCheckBox
            // 
            this.maximumRecordSizeCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.maximumRecordSizeCheckBox.AutoSize = true;
            this.maximumRecordSizeCheckBox.Checked = true;
            this.maximumRecordSizeCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.maximumRecordSizeCheckBox.Location = new System.Drawing.Point(408, 45);
            this.maximumRecordSizeCheckBox.Margin = new System.Windows.Forms.Padding(6);
            this.maximumRecordSizeCheckBox.Name = "maximumRecordSizeCheckBox";
            this.maximumRecordSizeCheckBox.Size = new System.Drawing.Size(205, 28);
            this.maximumRecordSizeCheckBox.TabIndex = 2;
            this.maximumRecordSizeCheckBox.Text = "Maximálna dĺžka";
            this.maximumRecordSizeCheckBox.UseVisualStyleBackColor = true;
            this.maximumRecordSizeCheckBox.CheckedChanged += new System.EventHandler(this.MaximumSizeCheckboxChecked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 1062);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1030, 1009);
            this.Name = "Form1";
            this.Text = "Log parser";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maximumRecordSizeNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimumRecordSizeNumeric)).EndInit();
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
        private System.Windows.Forms.CheckBox verifyAggregateXMLStructureOnLoadCheck;
        private System.Windows.Forms.Button initiateButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.CheckBox verifyAggregateXMLStructureOnCloseCheck;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox VerifyLogHashCheck;
        private System.Windows.Forms.CheckBox verboseLogCheckBox;
        private System.Windows.Forms.CheckBox verifyLogXMLStructureCheck;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown maximumRecordSizeNumeric;
        private System.Windows.Forms.NumericUpDown minimumRecordSizeNumeric;
        private System.Windows.Forms.CheckBox minimumRecordSizeCheckBox;
        private System.Windows.Forms.CheckBox maximumRecordSizeCheckBox;
        private System.Windows.Forms.CheckBox preventDuplicatesCheckBox;
    }
}

