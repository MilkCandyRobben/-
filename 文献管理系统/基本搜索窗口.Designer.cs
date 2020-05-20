namespace 文献管理系统
{
    partial class 基本搜索窗口
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radioButton2论文题目 = new System.Windows.Forms.RadioButton();
            this.radioButton1作者姓名 = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.确定按钮 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(382, 51);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(134, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "请选择搜索方式";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.radioButton2论文题目);
            this.panel2.Controls.Add(this.radioButton1作者姓名);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 51);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(382, 46);
            this.panel2.TabIndex = 1;
            // 
            // radioButton2论文题目
            // 
            this.radioButton2论文题目.AutoSize = true;
            this.radioButton2论文题目.Location = new System.Drawing.Point(239, 21);
            this.radioButton2论文题目.Name = "radioButton2论文题目";
            this.radioButton2论文题目.Size = new System.Drawing.Size(88, 19);
            this.radioButton2论文题目.TabIndex = 1;
            this.radioButton2论文题目.TabStop = true;
            this.radioButton2论文题目.Text = "论文题目";
            this.radioButton2论文题目.UseVisualStyleBackColor = true;
            this.radioButton2论文题目.CheckedChanged += new System.EventHandler(this.radioButton2论文题目_CheckedChanged);
            // 
            // radioButton1作者姓名
            // 
            this.radioButton1作者姓名.AutoSize = true;
            this.radioButton1作者姓名.Location = new System.Drawing.Point(50, 21);
            this.radioButton1作者姓名.Name = "radioButton1作者姓名";
            this.radioButton1作者姓名.Size = new System.Drawing.Size(88, 19);
            this.radioButton1作者姓名.TabIndex = 0;
            this.radioButton1作者姓名.TabStop = true;
            this.radioButton1作者姓名.Text = "作者姓名";
            this.radioButton1作者姓名.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.确定按钮);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 97);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(382, 56);
            this.panel3.TabIndex = 2;
            // 
            // 确定按钮
            // 
            this.确定按钮.Location = new System.Drawing.Point(151, 18);
            this.确定按钮.Name = "确定按钮";
            this.确定按钮.Size = new System.Drawing.Size(75, 30);
            this.确定按钮.TabIndex = 0;
            this.确定按钮.Text = "确定";
            this.确定按钮.UseVisualStyleBackColor = true;
            this.确定按钮.Click += new System.EventHandler(this.确定按钮_Click);
            // 
            // 基本搜索窗口
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 153);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.IsMdiContainer = true;
            this.MaximumSize = new System.Drawing.Size(400, 200);
            this.MinimumSize = new System.Drawing.Size(400, 200);
            this.Name = "基本搜索窗口";
            this.Text = "基本搜索窗口";
            this.Load += new System.EventHandler(this.基本搜索窗口_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton radioButton1作者姓名;
        private System.Windows.Forms.RadioButton radioButton2论文题目;
        private System.Windows.Forms.Button 确定按钮;
    }
}