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
        public 作者姓名窗口()
        {
            InitializeComponent();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            加载窗口 form = new 加载窗口();
            form.Show();
            string AuthorName = this.textBox1.Text;
            Search search = new Search();
            search.InitialAuthorBTreeLines("D:\\dataxml\\AuthorBTree.txt");
            string[] result = search.SearchAuthor(AuthorName, 0);
            SearchByIndex_xml content = new SearchByIndex_xml();
            content.getInfomation(result, "D:\\dataxml\\dblp_index.xml", "D:\\dataxml\\result\\result_"+AuthorName+".txt");
            System.Diagnostics.Process.Start("D:\\dataxml\\result\\result_" + AuthorName + ".txt");

            search.DeleteAuthorBTreeLines();
            result = null;
            form.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            加载窗口 form1 = new 加载窗口();
            form1.Show();
            string AuthorName = this.textBox1.Text;
            Search search = new Search();
            search.InitialAuthorBTreeLines("D:\\dataxml\\AuthorBTree.txt");
            string[] result = search.SearchAuthor(AuthorName, 0);
            SearchByIndex_xml content = new SearchByIndex_xml();
            content.Author_Partnership(result, "D:\\dataxml\\dblp_index.xml", "D:\\dataxml\\result\\ "+ AuthorName + "'s partnership.txt");
            System.Diagnostics.Process.Start("D:\\dataxml\\result\\ " + AuthorName + "'s partnership.txt");

            search.DeleteAuthorBTreeLines();
            result = null;
            form1.Close();
        }
    }
}
