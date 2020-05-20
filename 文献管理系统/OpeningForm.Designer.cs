namespace 文献管理系统
{
    partial class OpeningForm
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
            this.components = new System.ComponentModel.Container();
            this.pictureBox_Opening = new System.Windows.Forms.PictureBox();
            this.panelProgressbarContainer = new System.Windows.Forms.Panel();
            this.panelProgressbar = new System.Windows.Forms.Panel();
            this.timerProgressbar = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Opening)).BeginInit();
            this.panelProgressbarContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox_Opening
            // 
            this.pictureBox_Opening.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox_Opening.Image = global::文献管理系统.Properties.Resources.opening;
            this.pictureBox_Opening.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_Opening.Name = "pictureBox_Opening";
            this.pictureBox_Opening.Size = new System.Drawing.Size(700, 400);
            this.pictureBox_Opening.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Opening.TabIndex = 0;
            this.pictureBox_Opening.TabStop = false;
            // 
            // panelProgressbarContainer
            // 
            this.panelProgressbarContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(233)))), ((int)(((byte)(230)))));
            this.panelProgressbarContainer.Controls.Add(this.panelProgressbar);
            this.panelProgressbarContainer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelProgressbarContainer.Location = new System.Drawing.Point(0, 380);
            this.panelProgressbarContainer.Name = "panelProgressbarContainer";
            this.panelProgressbarContainer.Size = new System.Drawing.Size(700, 20);
            this.panelProgressbarContainer.TabIndex = 1;
            // 
            // panelProgressbar
            // 
            this.panelProgressbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(118)))), ((int)(((byte)(186)))));
            this.panelProgressbar.Location = new System.Drawing.Point(0, 0);
            this.panelProgressbar.Name = "panelProgressbar";
            this.panelProgressbar.Size = new System.Drawing.Size(10, 20);
            this.panelProgressbar.TabIndex = 2;
            // 
            // timerProgressbar
            // 
            this.timerProgressbar.Enabled = true;
            this.timerProgressbar.Interval = 1000;
            // 
            // OpeningForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 400);
            this.Controls.Add(this.panelProgressbarContainer);
            this.Controls.Add(this.pictureBox_Opening);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OpeningForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OpeningForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Opening)).EndInit();
            this.panelProgressbarContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_Opening;
        private System.Windows.Forms.Panel panelProgressbarContainer;
        private System.Windows.Forms.Panel panelProgressbar;
        private System.Windows.Forms.Timer timerProgressbar;
    }
}