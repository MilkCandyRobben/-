namespace 文献管理系统
{
    partial class MainForm2
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelTool = new System.Windows.Forms.Panel();
            this.buttonTesting = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.buttonStatisticsPanel = new System.Windows.Forms.Button();
            this.buttonSearchCollaborators = new System.Windows.Forms.Button();
            this.buttonSearchLiterature = new System.Windows.Forms.Button();
            this.pictureBoxMenu = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            this.panelTool.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.panel1.Controls.Add(this.pictureBoxMenu);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(950, 40);
            this.panel1.TabIndex = 0;
            // 
            // panelTool
            // 
            this.panelTool.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panelTool.Controls.Add(this.buttonTesting);
            this.panelTool.Controls.Add(this.buttonStatisticsPanel);
            this.panelTool.Controls.Add(this.buttonSearchCollaborators);
            this.panelTool.Controls.Add(this.buttonSearchLiterature);
            this.panelTool.Controls.Add(this.panel3);
            this.panelTool.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelTool.Location = new System.Drawing.Point(0, 40);
            this.panelTool.Name = "panelTool";
            this.panelTool.Size = new System.Drawing.Size(160, 560);
            this.panelTool.TabIndex = 1;
            // 
            // buttonTesting
            // 
            this.buttonTesting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonTesting.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonTesting.FlatAppearance.BorderSize = 0;
            this.buttonTesting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTesting.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.buttonTesting.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonTesting.Location = new System.Drawing.Point(0, 141);
            this.buttonTesting.Name = "buttonTesting";
            this.buttonTesting.Size = new System.Drawing.Size(160, 40);
            this.buttonTesting.TabIndex = 0;
            this.buttonTesting.Text = "测试按钮";
            this.buttonTesting.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonTesting.UseVisualStyleBackColor = false;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(160, 21);
            this.panel3.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(160, 40);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(790, 560);
            this.panel4.TabIndex = 2;
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // buttonStatisticsPanel
            // 
            this.buttonStatisticsPanel.AccessibleDescription = "";
            this.buttonStatisticsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonStatisticsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonStatisticsPanel.FlatAppearance.BorderSize = 0;
            this.buttonStatisticsPanel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStatisticsPanel.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.buttonStatisticsPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonStatisticsPanel.Image = global::文献管理系统.Properties.Resources.pie_chart_24px;
            this.buttonStatisticsPanel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonStatisticsPanel.Location = new System.Drawing.Point(0, 101);
            this.buttonStatisticsPanel.Name = "buttonStatisticsPanel";
            this.buttonStatisticsPanel.Size = new System.Drawing.Size(160, 40);
            this.buttonStatisticsPanel.TabIndex = 0;
            this.buttonStatisticsPanel.Text = "统计面板";
            this.buttonStatisticsPanel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonStatisticsPanel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonStatisticsPanel.UseVisualStyleBackColor = false;
            // 
            // buttonSearchCollaborators
            // 
            this.buttonSearchCollaborators.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonSearchCollaborators.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonSearchCollaborators.FlatAppearance.BorderSize = 0;
            this.buttonSearchCollaborators.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearchCollaborators.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.buttonSearchCollaborators.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonSearchCollaborators.Image = global::文献管理系统.Properties.Resources.people_26px;
            this.buttonSearchCollaborators.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSearchCollaborators.Location = new System.Drawing.Point(0, 61);
            this.buttonSearchCollaborators.Name = "buttonSearchCollaborators";
            this.buttonSearchCollaborators.Size = new System.Drawing.Size(160, 40);
            this.buttonSearchCollaborators.TabIndex = 0;
            this.buttonSearchCollaborators.Text = "搜索合作者";
            this.buttonSearchCollaborators.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSearchCollaborators.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonSearchCollaborators.UseVisualStyleBackColor = false;
            // 
            // buttonSearchLiterature
            // 
            this.buttonSearchLiterature.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonSearchLiterature.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonSearchLiterature.FlatAppearance.BorderSize = 0;
            this.buttonSearchLiterature.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearchLiterature.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.buttonSearchLiterature.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonSearchLiterature.Image = global::文献管理系统.Properties.Resources.search_property_24px;
            this.buttonSearchLiterature.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSearchLiterature.Location = new System.Drawing.Point(0, 21);
            this.buttonSearchLiterature.Name = "buttonSearchLiterature";
            this.buttonSearchLiterature.Size = new System.Drawing.Size(160, 40);
            this.buttonSearchLiterature.TabIndex = 0;
            this.buttonSearchLiterature.Text = "搜索文献";
            this.buttonSearchLiterature.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSearchLiterature.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonSearchLiterature.UseVisualStyleBackColor = false;
            // 
            // pictureBoxMenu
            // 
            this.pictureBoxMenu.Image = global::文献管理系统.Properties.Resources.menu_24px;
            this.pictureBoxMenu.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxMenu.Name = "pictureBoxMenu";
            this.pictureBoxMenu.Size = new System.Drawing.Size(40, 40);
            this.pictureBoxMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxMenu.TabIndex = 0;
            this.pictureBoxMenu.TabStop = false;
            this.pictureBoxMenu.Click += new System.EventHandler(this.pictureBoxMenu_Click);
            // 
            // MainForm2
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(950, 600);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panelTool);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MainForm2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm2";
            this.Load += new System.EventHandler(this.MainForm2_Load);
            this.panel1.ResumeLayout(false);
            this.panelTool.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMenu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBoxMenu;
        private System.Windows.Forms.Panel panelTool;
        private System.Windows.Forms.Button buttonTesting;
        private System.Windows.Forms.Button buttonStatisticsPanel;
        private System.Windows.Forms.Button buttonSearchCollaborators;
        private System.Windows.Forms.Button buttonSearchLiterature;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Timer timer1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}