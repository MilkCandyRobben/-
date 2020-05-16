using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 文献管理系统
{
    public partial class 基本搜索窗口 : Form
    {
        public 基本搜索窗口()
        {
            InitializeComponent();
        }

        private void 基本搜索窗口_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        

        private void radioButton2论文题目_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void 确定按钮_Click(object sender, EventArgs e)
        {
            if (radioButton1作者姓名.Checked == true)
            {
                作者姓名窗口 form = new 作者姓名窗口();
                form.StartPosition = FormStartPosition.CenterScreen;
                form.Show();
                this.Close();
            }
            else
            {
                论文题目窗口 form1 = new 论文题目窗口();
                form1.StartPosition = FormStartPosition.CenterScreen;
                form1.Show();
                this.Close();
            }
        }
    }
}
