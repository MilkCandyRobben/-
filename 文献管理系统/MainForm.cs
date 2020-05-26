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
            子菜单panel2.Visible = false;

        }
        private void hideSubMenu()
        {
            if(子菜单panel.Visible ==true)
            {
                子菜单panel.Visible = false;
            }
            if (子菜单panel2.Visible == true)
            {
                子菜单panel2.Visible = false;
            }
        }
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
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
        bool b = true;
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
            作者姓名窗口 form = new 作者姓名窗口();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Show();
            hideSubMenu();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            加载窗口 form4 = new 加载窗口();
            form4.Show();
            System.Diagnostics.Process.Start("D:\\dataxml\\top100.txt");
            System.Diagnostics.Process.Start("D:\\dataxml\\render.html");
            hideSubMenu();
            form4.Close();
        }

        private void 拓展功能button_Click(object sender, EventArgs e)
        {
            showSubMenu(子菜单panel2);

            if (b == true)
            {
                拓展功能button.Image = global::文献管理系统.Properties.Resources.三角下标down;
                b = false;
            }
            else
            {
                拓展功能button.Image = global::文献管理系统.Properties.Resources.三角下标left;
                b = true;
            }

        }

        private void 热点搜索button_Click(object sender, EventArgs e)
        {
            加载窗口 form3 = new 加载窗口();
            form3.Show();
            System.Diagnostics.Process.Start("D:\\dataxml\\Hotspot.txt");
            hideSubMenu();
            form3.Close();
        }
    }
}
