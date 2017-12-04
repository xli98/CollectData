namespace CollectTabletData
{
    partial class RunTrials
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
            this.btnStartTrial = new System.Windows.Forms.Button();
            this.btnEndTrial = new System.Windows.Forms.Button();
            this.btnReturnToMain = new System.Windows.Forms.Button();
            this.scribblePanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // btnStartTrial
            // 
            this.btnStartTrial.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnStartTrial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartTrial.Location = new System.Drawing.Point(140, 591);
            this.btnStartTrial.Margin = new System.Windows.Forms.Padding(4);
            this.btnStartTrial.Name = "btnStartTrial";
            this.btnStartTrial.Size = new System.Drawing.Size(184, 52);
            this.btnStartTrial.TabIndex = 1;
            this.btnStartTrial.Text = "Start Trial";
            this.btnStartTrial.UseVisualStyleBackColor = true;
            this.btnStartTrial.Click += new System.EventHandler(this.btnStartTrial_Click);
            // 
            // btnEndTrial
            // 
            this.btnEndTrial.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnEndTrial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEndTrial.Location = new System.Drawing.Point(459, 591);
            this.btnEndTrial.Margin = new System.Windows.Forms.Padding(4);
            this.btnEndTrial.Name = "btnEndTrial";
            this.btnEndTrial.Size = new System.Drawing.Size(184, 52);
            this.btnEndTrial.TabIndex = 1;
            this.btnEndTrial.Text = "End Trial";
            this.btnEndTrial.UseVisualStyleBackColor = true;
            this.btnEndTrial.Click += new System.EventHandler(this.btnEndTrial_Click);
            // 
            // btnReturnToMain
            // 
            this.btnReturnToMain.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnReturnToMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturnToMain.Location = new System.Drawing.Point(771, 591);
            this.btnReturnToMain.Margin = new System.Windows.Forms.Padding(4);
            this.btnReturnToMain.Name = "btnReturnToMain";
            this.btnReturnToMain.Size = new System.Drawing.Size(184, 52);
            this.btnReturnToMain.TabIndex = 2;
            this.btnReturnToMain.Text = "Return to Main";
            this.btnReturnToMain.UseVisualStyleBackColor = true;
            this.btnReturnToMain.Click += new System.EventHandler(this.btnReturnToMain_Click);
            // 
            // scribblePanel
            // 
            // the panel that displays what the user have written
            // that is overlaid on the top of the form
            this.scribblePanel.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
            this.scribblePanel.Location = new System.Drawing.Point(0, 0);
            this.scribblePanel.Name = "scribblePanel";
            //this.scribblePanel.Size = new System.Drawing.Size(System.Windows.Forms.AnchorStyles.Top -System.Windows.Forms.AnchorStyles.Bottom, System.Windows.Forms.AnchorStyles.Right - System.Windows.Forms.AnchorStyles.Left);
            this.scribblePanel.Size = new System.Drawing.Size(1127, 670);
            this.scribblePanel.TabIndex = 3;
            // 
            // RunTrials
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1127, 670);
            this.Controls.Add(this.btnReturnToMain);
            this.Controls.Add(this.btnEndTrial);
            this.Controls.Add(this.btnStartTrial);
            this.Controls.Add(this.scribblePanel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RunTrials";
            this.Text = "RunTrials";
            this.Load += new System.EventHandler(this.RunTrials_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnStartTrial;
        private System.Windows.Forms.Button btnEndTrial;
        private System.Windows.Forms.Button btnReturnToMain;
        private System.Windows.Forms.Panel scribblePanel;
    }
}