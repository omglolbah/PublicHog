namespace XaeroToJourneyMap
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.fbdInstance = new System.Windows.Forms.FolderBrowserDialog();
            this.btnSelectInstance = new System.Windows.Forms.Button();
            this.cbSaves = new System.Windows.Forms.ComboBox();
            this.btnLoadWaypoints = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.txtWaypoints = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnSelectInstance
            // 
            this.btnSelectInstance.Location = new System.Drawing.Point(12, 12);
            this.btnSelectInstance.Name = "btnSelectInstance";
            this.btnSelectInstance.Size = new System.Drawing.Size(329, 23);
            this.btnSelectInstance.TabIndex = 0;
            this.btnSelectInstance.Text = "Browse for instance";
            this.btnSelectInstance.UseVisualStyleBackColor = true;
            this.btnSelectInstance.Click += new System.EventHandler(this.btnSelectInstance_Click);
            // 
            // cbSaves
            // 
            this.cbSaves.FormattingEnabled = true;
            this.cbSaves.Location = new System.Drawing.Point(12, 41);
            this.cbSaves.Name = "cbSaves";
            this.cbSaves.Size = new System.Drawing.Size(329, 23);
            this.cbSaves.TabIndex = 1;
            this.cbSaves.SelectedIndexChanged += new System.EventHandler(this.cbSaves_SelectedIndexChanged);
            // 
            // btnLoadWaypoints
            // 
            this.btnLoadWaypoints.Location = new System.Drawing.Point(12, 70);
            this.btnLoadWaypoints.Name = "btnLoadWaypoints";
            this.btnLoadWaypoints.Size = new System.Drawing.Size(329, 23);
            this.btnLoadWaypoints.TabIndex = 2;
            this.btnLoadWaypoints.Text = "Load Xaero waypoints";
            this.btnLoadWaypoints.UseVisualStyleBackColor = true;
            this.btnLoadWaypoints.Click += new System.EventHandler(this.btnLoadWaypoints_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(12, 343);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(329, 23);
            this.btnExport.TabIndex = 4;
            this.btnExport.Text = "Export to Journeymap";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // txtWaypoints
            // 
            this.txtWaypoints.Location = new System.Drawing.Point(12, 99);
            this.txtWaypoints.Multiline = true;
            this.txtWaypoints.Name = "txtWaypoints";
            this.txtWaypoints.Size = new System.Drawing.Size(329, 238);
            this.txtWaypoints.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 379);
            this.Controls.Add(this.txtWaypoints);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnLoadWaypoints);
            this.Controls.Add(this.cbSaves);
            this.Controls.Add(this.btnSelectInstance);
            this.Name = "Form1";
            this.Text = "XaeroToJourneyMap";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FolderBrowserDialog fbdInstance;
        private Button btnSelectInstance;
        private ComboBox cbSaves;
        private Button btnLoadWaypoints;
        private Button btnExport;
        private TextBox txtWaypoints;
    }
}