namespace 文献管理系统
{
    partial class 文献管理系统
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(文献管理系统));
            this.侧边菜单栏panel = new System.Windows.Forms.Panel();
            this.子菜单panel = new System.Windows.Forms.Panel();
            this.作者统计按钮 = new System.Windows.Forms.Button();
            this.相关搜索按钮 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.工具按钮 = new System.Windows.Forms.Button();
            this.图标panel = new System.Windows.Forms.Panel();
            this.侧边菜单栏panel.SuspendLayout();
            this.子菜单panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // 侧边菜单栏panel
            // 
            this.侧边菜单栏panel.AutoScroll = true;
            this.侧边菜单栏panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            this.侧边菜单栏panel.Controls.Add(this.子菜单panel);
            this.侧边菜单栏panel.Controls.Add(this.工具按钮);
            this.侧边菜单栏panel.Controls.Add(this.图标panel);
            this.侧边菜单栏panel.Dock = System.Windows.Forms.DockStyle.Left;
            this.侧边菜单栏panel.Location = new System.Drawing.Point(0, 0);
            this.侧边菜单栏panel.Name = "侧边菜单栏panel";
            this.侧边菜单栏panel.Size = new System.Drawing.Size(250, 553);
            this.侧边菜单栏panel.TabIndex = 0;
            // 
            // 子菜单panel
            // 
            this.子菜单panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.子菜单panel.Controls.Add(this.作者统计按钮);
            this.子菜单panel.Controls.Add(this.相关搜索按钮);
            this.子菜单panel.Controls.Add(this.button1);
            this.子菜单panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.子菜单panel.Location = new System.Drawing.Point(0, 145);
            this.子菜单panel.Name = "子菜单panel";
            this.子菜单panel.Size = new System.Drawing.Size(250, 121);
            this.子菜单panel.TabIndex = 2;
            // 
            // 作者统计按钮
            // 
            this.作者统计按钮.Dock = System.Windows.Forms.DockStyle.Top;
            this.作者统计按钮.FlatAppearance.BorderSize = 0;
            this.作者统计按钮.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.作者统计按钮.ForeColor = System.Drawing.Color.LightGray;
            this.作者统计按钮.Image = ((System.Drawing.Image)(resources.GetObject("作者统计按钮.Image")));
            this.作者统计按钮.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.作者统计按钮.Location = new System.Drawing.Point(0, 80);
            this.作者统计按钮.Name = "作者统计按钮";
            this.作者统计按钮.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.作者统计按钮.Size = new System.Drawing.Size(250, 40);
            this.作者统计按钮.TabIndex = 2;
            this.作者统计按钮.Text = "作者统计";
            this.作者统计按钮.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.作者统计按钮.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.作者统计按钮.UseVisualStyleBackColor = true;
            this.作者统计按钮.Click += new System.EventHandler(this.button3_Click);
            // 
            // 相关搜索按钮
            // 
            this.相关搜索按钮.Dock = System.Windows.Forms.DockStyle.Top;
            this.相关搜索按钮.FlatAppearance.BorderSize = 0;
            this.相关搜索按钮.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.相关搜索按钮.ForeColor = System.Drawing.Color.LightGray;
            this.相关搜索按钮.Image = ((System.Drawing.Image)(resources.GetObject("相关搜索按钮.Image")));
            this.相关搜索按钮.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.相关搜索按钮.Location = new System.Drawing.Point(0, 40);
            this.相关搜索按钮.Name = "相关搜索按钮";
            this.相关搜索按钮.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.相关搜索按钮.Size = new System.Drawing.Size(250, 40);
            this.相关搜索按钮.TabIndex = 1;
            this.相关搜索按钮.Text = "相关搜索";
            this.相关搜索按钮.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.相关搜索按钮.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.相关搜索按钮.UseVisualStyleBackColor = true;
            this.相关搜索按钮.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.LightGray;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.button1.Size = new System.Drawing.Size(250, 40);
            this.button1.TabIndex = 0;
            this.button1.Text = "搜索";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // 工具按钮
            // 
            this.工具按钮.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.工具按钮.Dock = System.Windows.Forms.DockStyle.Top;
            this.工具按钮.FlatAppearance.BorderSize = 0;
            this.工具按钮.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.工具按钮.ForeColor = System.Drawing.Color.Gainsboro;
            this.工具按钮.Image = ((System.Drawing.Image)(resources.GetObject("工具按钮.Image")));
            this.工具按钮.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.工具按钮.Location = new System.Drawing.Point(0, 100);
            this.工具按钮.Name = "工具按钮";
            this.工具按钮.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.工具按钮.Size = new System.Drawing.Size(250, 45);
            this.工具按钮.TabIndex = 1;
            this.工具按钮.Text = "工具";
            this.工具按钮.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.工具按钮.UseVisualStyleBackColor = true;
            this.工具按钮.Click += new System.EventHandler(this.工具按钮_Click);
            // 
            // 图标panel
            // 
            this.图标panel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("图标panel.BackgroundImage")));
            this.图标panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.图标panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.图标panel.Location = new System.Drawing.Point(0, 0);
            this.图标panel.Name = "图标panel";
            this.图标panel.Size = new System.Drawing.Size(250, 100);
            this.图标panel.TabIndex = 0;
            // 
            // 文献管理系统
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(932, 553);
            this.Controls.Add(this.侧边菜单栏panel);
            this.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(950, 600);
            this.Name = "文献管理系统";
            this.Text = "文献管理系统";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.侧边菜单栏panel.ResumeLayout(false);
            this.子菜单panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel 侧边菜单栏panel;
        private System.Windows.Forms.Panel 子菜单panel;
        private System.Windows.Forms.Button 作者统计按钮;
        private System.Windows.Forms.Button 相关搜索按钮;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button 工具按钮;
        private System.Windows.Forms.Panel 图标panel;
    }
}

