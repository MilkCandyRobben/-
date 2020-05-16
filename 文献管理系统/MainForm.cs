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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            customizeDesign();
        }
        private void customizeDesign()
        {
            子菜单panel.Visible = false;

        }
        private void hideSubMenu()
        {
            if(子菜单panel.Visible ==true)
            {
                子菜单panel.Visible = false;
            }
        }
        private void showSubMenu(Panel subMenu)
        {
            if (子菜单panel.Visible == false)
            {
               // hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
         bool a = true;
        private void 工具按钮_Click(object sender, EventArgs e)
        {
            showSubMenu(子菜单panel);
            
            if (a==true)
            { 
                工具按钮.Image = global::文献管理系统.Properties.Resources.三角下标down;
                a = false;
            }
            else 
            {
                工具按钮.Image = global::文献管理系统.Properties.Resources.三角下标left;
                a = true;
            }

            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            基本搜索窗口 form = new 基本搜索窗口();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Show();
            hideSubMenu();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            hideSubMenu();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }
    }
}
