namespace Car_Park_Registration_Tracker
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
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.textBoxSubtitle = new System.Windows.Forms.TextBox();
            this.labelLicencePlates = new System.Windows.Forms.Label();
            this.listBoxMain = new System.Windows.Forms.ListBox();
            this.labelTagged = new System.Windows.Forms.Label();
            this.listBoxTagged = new System.Windows.Forms.ListBox();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.buttonEnter = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.buttonBinary = new System.Windows.Forms.Button();
            this.buttonLinear = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonTag = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.AccessibleDescription = "Active Systems PTY Logo";
            this.pictureBoxLogo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.pictureBoxLogo.Image = global::Car_Park_Registration_Tracker.Properties.Resources.logo;
            this.pictureBoxLogo.Location = new System.Drawing.Point(448, 12);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(130, 130);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.TabIndex = 0;
            this.pictureBoxLogo.TabStop = false;
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.textBoxTitle.Location = new System.Drawing.Point(12, 36);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.ReadOnly = true;
            this.textBoxTitle.Size = new System.Drawing.Size(430, 31);
            this.textBoxTitle.TabIndex = 1;
            this.textBoxTitle.Text = "Active Systems Pty";
            this.textBoxTitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxSubtitle
            // 
            this.textBoxSubtitle.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxSubtitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxSubtitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxSubtitle.Location = new System.Drawing.Point(12, 88);
            this.textBoxSubtitle.Name = "textBoxSubtitle";
            this.textBoxSubtitle.ReadOnly = true;
            this.textBoxSubtitle.Size = new System.Drawing.Size(430, 19);
            this.textBoxSubtitle.TabIndex = 2;
            this.textBoxSubtitle.Text = "Licence Plate Management";
            this.textBoxSubtitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelLicencePlates
            // 
            this.labelLicencePlates.AutoSize = true;
            this.labelLicencePlates.Location = new System.Drawing.Point(12, 143);
            this.labelLicencePlates.Name = "labelLicencePlates";
            this.labelLicencePlates.Size = new System.Drawing.Size(104, 17);
            this.labelLicencePlates.TabIndex = 3;
            this.labelLicencePlates.Text = "Licence Plates:";
            // 
            // listBoxMain
            // 
            this.listBoxMain.FormattingEnabled = true;
            this.listBoxMain.ItemHeight = 16;
            this.listBoxMain.Location = new System.Drawing.Point(12, 171);
            this.listBoxMain.Name = "listBoxMain";
            this.listBoxMain.Size = new System.Drawing.Size(167, 372);
            this.listBoxMain.TabIndex = 4;
            this.listBoxMain.SelectedIndexChanged += new System.EventHandler(this.listBoxMain_SelectedIndexChanged);
            this.listBoxMain.DoubleClick += new System.EventHandler(this.listBoxMain_DoubleClick);
            // 
            // labelTagged
            // 
            this.labelTagged.AutoSize = true;
            this.labelTagged.Location = new System.Drawing.Point(185, 143);
            this.labelTagged.Name = "labelTagged";
            this.labelTagged.Size = new System.Drawing.Size(61, 17);
            this.labelTagged.TabIndex = 5;
            this.labelTagged.Text = "Tagged:";
            // 
            // listBoxTagged
            // 
            this.listBoxTagged.FormattingEnabled = true;
            this.listBoxTagged.ItemHeight = 16;
            this.listBoxTagged.Location = new System.Drawing.Point(190, 171);
            this.listBoxTagged.Name = "listBoxTagged";
            this.listBoxTagged.Size = new System.Drawing.Size(167, 372);
            this.listBoxTagged.TabIndex = 6;
            this.listBoxTagged.SelectedIndexChanged += new System.EventHandler(this.listBoxTagged_SelectedIndexChanged);
            this.listBoxTagged.DoubleClick += new System.EventHandler(this.listBoxTagged_DoubleClick);
            // 
            // buttonOpen
            // 
            this.buttonOpen.Location = new System.Drawing.Point(363, 171);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(106, 49);
            this.buttonOpen.TabIndex = 7;
            this.buttonOpen.Text = "Open";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // textBoxInput
            // 
            this.textBoxInput.Location = new System.Drawing.Point(363, 226);
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.Size = new System.Drawing.Size(218, 23);
            this.textBoxInput.TabIndex = 8;
            // 
            // buttonEnter
            // 
            this.buttonEnter.Location = new System.Drawing.Point(363, 262);
            this.buttonEnter.Name = "buttonEnter";
            this.buttonEnter.Size = new System.Drawing.Size(106, 49);
            this.buttonEnter.TabIndex = 9;
            this.buttonEnter.Text = "Enter";
            this.buttonEnter.UseVisualStyleBackColor = true;
            this.buttonEnter.Click += new System.EventHandler(this.buttonEnter_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(475, 262);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(106, 49);
            this.buttonExit.TabIndex = 10;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(363, 317);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(106, 49);
            this.buttonEdit.TabIndex = 11;
            this.buttonEdit.Text = "Edit";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(363, 482);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(106, 49);
            this.buttonReset.TabIndex = 12;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // buttonBinary
            // 
            this.buttonBinary.Location = new System.Drawing.Point(363, 372);
            this.buttonBinary.Name = "buttonBinary";
            this.buttonBinary.Size = new System.Drawing.Size(215, 49);
            this.buttonBinary.TabIndex = 13;
            this.buttonBinary.Text = "Binary Search";
            this.buttonBinary.UseVisualStyleBackColor = true;
            this.buttonBinary.Click += new System.EventHandler(this.buttonBinary_Click);
            // 
            // buttonLinear
            // 
            this.buttonLinear.Location = new System.Drawing.Point(363, 427);
            this.buttonLinear.Name = "buttonLinear";
            this.buttonLinear.Size = new System.Drawing.Size(215, 49);
            this.buttonLinear.TabIndex = 14;
            this.buttonLinear.Text = "Linear Search";
            this.buttonLinear.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(475, 171);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(106, 49);
            this.buttonSave.TabIndex = 15;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonTag
            // 
            this.buttonTag.Location = new System.Drawing.Point(475, 317);
            this.buttonTag.Name = "buttonTag";
            this.buttonTag.Size = new System.Drawing.Size(106, 49);
            this.buttonTag.TabIndex = 16;
            this.buttonTag.Text = "Tag";
            this.buttonTag.UseVisualStyleBackColor = true;
            // 
            // statusStrip
            // 
            this.statusStrip.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip.Location = new System.Drawing.Point(0, 553);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(600, 24);
            this.statusStrip.TabIndex = 17;
            this.statusStrip.Text = "statusStrip";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(83, 19);
            this.toolStripStatusLabel1.Text = "Processing...";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 577);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.buttonTag);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonLinear);
            this.Controls.Add(this.buttonBinary);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonEnter);
            this.Controls.Add(this.textBoxInput);
            this.Controls.Add(this.buttonOpen);
            this.Controls.Add(this.listBoxTagged);
            this.Controls.Add(this.labelTagged);
            this.Controls.Add(this.listBoxMain);
            this.Controls.Add(this.labelLicencePlates);
            this.Controls.Add(this.textBoxSubtitle);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.pictureBoxLogo);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Active Systems PTY";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.TextBox textBoxSubtitle;
        private System.Windows.Forms.Label labelLicencePlates;
        private System.Windows.Forms.ListBox listBoxMain;
        private System.Windows.Forms.Label labelTagged;
        private System.Windows.Forms.ListBox listBoxTagged;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.TextBox textBoxInput;
        private System.Windows.Forms.Button buttonEnter;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Button buttonBinary;
        private System.Windows.Forms.Button buttonLinear;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonTag;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}

