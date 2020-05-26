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
    public partial class 作者姓名窗口 : Form
    {
        Search search;
        public 作者姓名窗口()
        {
            InitializeComponent();
            search = new Search();
            search.InitialAuthorBTreeLines("D:\\dataxml\\AuthorBTree.txt");
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            string AuthorName = this.textBox1.Text;
            string[] result = search.SearchAuthor(AuthorName, 0);
            if (result != null)
            {
            SearchByIndex_xml content = new SearchByIndex_xml();
            content.getInfomation(result, "D:\\dataxml\\dblp_index.xml", "D:\\dataxml\\result\\result_"+AuthorName+".txt");
            System.Diagnostics.Process.Start("D:\\dataxml\\result\\result_" + AuthorName + ".txt");
            //search.DeleteAuthorBTreeLines();
            result = null;

            }
            else
            {
                错误窗口 form2 = new 错误窗口();
                form2.Show();

            }
                
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string AuthorName = this.textBox1.Text;
            string[] result = search.SearchAuthor(AuthorName, 0);
            if (result != null)
            {
            SearchByIndex_xml content = new SearchByIndex_xml();
            content.Author_Partnership(result, "D:\\dataxml\\dblp_index.xml", "D:\\dataxml\\result\\ "+ AuthorName + "'s partnership.txt");
            System.Diagnostics.Process.Start("D:\\dataxml\\result\\ " + AuthorName + "'s partnership.txt");            
            result = null;

            }
            else
            {
                错误窗口 form2 = new 错误窗口();
                form2.Show();
            }
            
        
        }

        private void 作者姓名窗口_FormClosing(object sender, FormClosingEventArgs e)
        {
            search.DeleteAuthorBTreeLines();

        }
    }
}
