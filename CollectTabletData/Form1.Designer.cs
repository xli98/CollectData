namespace CollectTabletData
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
            this.btnSelectDataFolder = new System.Windows.Forms.Button();
            this.lblDataFolder = new System.Windows.Forms.Label();
            this.btnDataFileBaseDone = new System.Windows.Forms.Button();
            this.txtDataSetName = new System.Windows.Forms.TextBox();
            this.btnRunTrials = new System.Windows.Forms.Button();
            this.lblProgramName = new System.Windows.Forms.Label();
            this.lblDataFileBase = new System.Windows.Forms.Label();
            this.lblDataFilesFolder = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSelectDataFolder
            // 
            this.btnSelectDataFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectDataFolder.Location = new System.Drawing.Point(81, 101);
            this.btnSelectDataFolder.Name = "btnSelectDataFolder";
            this.btnSelectDataFolder.Size = new System.Drawing.Size(101, 31);
            this.btnSelectDataFolder.TabIndex = 0;
            this.btnSelectDataFolder.Text = "Select Folder";
            this.btnSelectDataFolder.UseVisualStyleBackColor = true;
            this.btnSelectDataFolder.Click += new System.EventHandler(this.btnSelectDataFolder_Click);
            // 
            // lblDataFolder
            // 
            this.lblDataFolder.AutoSize = true;
            this.lblDataFolder.BackColor = System.Drawing.SystemColors.Window;
            this.lblDataFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDataFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataFolder.Location = new System.Drawing.Point(256, 81);
            this.lblDataFolder.Name = "lblDataFolder";
            this.lblDataFolder.Size = new System.Drawing.Size(2, 19);
            this.lblDataFolder.TabIndex = 1;
            this.lblDataFolder.Visible = false;
            // 
            // btnDataFileBaseDone
            // 
            this.btnDataFileBaseDone.Enabled = false;
            this.btnDataFileBaseDone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDataFileBaseDone.Location = new System.Drawing.Point(116, 183);
            this.btnDataFileBaseDone.Name = "btnDataFileBaseDone";
            this.btnDataFileBaseDone.Size = new System.Drawing.Size(104, 28);
            this.btnDataFileBaseDone.TabIndex = 2;
            this.btnDataFileBaseDone.Text = "Done";
            this.btnDataFileBaseDone.UseVisualStyleBackColor = true;
            this.btnDataFileBaseDone.Visible = false;
            this.btnDataFileBaseDone.Click += new System.EventHandler(this.btnDataFileBaseDone_Click);
            // 
            // txtDataSetName
            // 
            this.txtDataSetName.Enabled = false;
            this.txtDataSetName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDataSetName.Location = new System.Drawing.Point(256, 149);
            this.txtDataSetName.Name = "txtDataSetName";
            this.txtDataSetName.Size = new System.Drawing.Size(284, 23);
            this.txtDataSetName.TabIndex = 3;
            this.txtDataSetName.Visible = false;
            this.txtDataSetName.TextChanged += new System.EventHandler(this.txtDataSetName_TextChanged);
            // 
            // btnRunTrials
            // 
            this.btnRunTrials.Enabled = false;
            this.btnRunTrials.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRunTrials.Location = new System.Drawing.Point(45, 350);
            this.btnRunTrials.Name = "btnRunTrials";
            this.btnRunTrials.Size = new System.Drawing.Size(137, 31);
            this.btnRunTrials.TabIndex = 4;
            this.btnRunTrials.Text = "Run Trials";
            this.btnRunTrials.UseVisualStyleBackColor = true;
            this.btnRunTrials.Visible = false;
            this.btnRunTrials.Click += new System.EventHandler(this.btnRunTrials_Click);
            // 
            // lblProgramName
            // 
            this.lblProgramName.AutoSize = true;
            this.lblProgramName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgramName.Location = new System.Drawing.Point(269, 20);
            this.lblProgramName.Name = "lblProgramName";
            this.lblProgramName.Size = new System.Drawing.Size(300, 26);
            this.lblProgramName.TabIndex = 5;
            this.lblProgramName.Text = "CollectTabletData 1.0 1-30-17";
            this.lblProgramName.UseWaitCursor = true;
            // 
            // lblDataFileBase
            // 
            this.lblDataFileBase.AutoSize = true;
            this.lblDataFileBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataFileBase.Location = new System.Drawing.Point(25, 150);
            this.lblDataFileBase.Name = "lblDataFileBase";
            this.lblDataFileBase.Size = new System.Drawing.Size(195, 20);
            this.lblDataFileBase.TabIndex = 6;
            this.lblDataFileBase.Text = "Base Name for Data Files:";
            this.lblDataFileBase.Visible = false;
            // 
            // lblDataFilesFolder
            // 
            this.lblDataFilesFolder.AutoSize = true;
            this.lblDataFilesFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataFilesFolder.Location = new System.Drawing.Point(25, 78);
            this.lblDataFilesFolder.Name = "lblDataFilesFolder";
            this.lblDataFilesFolder.Size = new System.Drawing.Size(157, 20);
            this.lblDataFilesFolder.TabIndex = 7;
            this.lblDataFilesFolder.Text = "Folder for Data Files:";
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(274, 350);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(137, 31);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 482);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblDataFilesFolder);
            this.Controls.Add(this.lblDataFileBase);
            this.Controls.Add(this.lblProgramName);
            this.Controls.Add(this.btnRunTrials);
            this.Controls.Add(this.txtDataSetName);
            this.Controls.Add(this.btnDataFileBaseDone);
            this.Controls.Add(this.lblDataFolder);
            this.Controls.Add(this.btnSelectDataFolder);
            this.Name = "Form1";
            this.Text = "CollectTabletData Startup";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelectDataFolder;
        private System.Windows.Forms.Label lblDataFolder;
        private System.Windows.Forms.Button btnDataFileBaseDone;
        private System.Windows.Forms.TextBox txtDataSetName;
        private System.Windows.Forms.Button btnRunTrials;
        private System.Windows.Forms.Label lblProgramName;
        private System.Windows.Forms.Label lblDataFileBase;
        private System.Windows.Forms.Label lblDataFilesFolder;
        private System.Windows.Forms.Button btnExit;
    }
}

