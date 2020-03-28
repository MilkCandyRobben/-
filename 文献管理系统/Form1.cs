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
    public partial class 文献管理系统 : Form
    {
        public 文献管理系统()
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
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void 工具按钮_Click(object sender, EventArgs e)
        {
            showSubMenu(子菜单panel);
        }

        private void button1_Click(object sender, EventArgs e)
        {
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
