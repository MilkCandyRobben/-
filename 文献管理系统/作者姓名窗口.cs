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

        private void 作者姓名窗口_Load(object sender, EventArgs e)
        {




        }

        private void button1_Click(object sender, EventArgs e)
        {
            string AuthorName = this.textBox1.Text;
            Search search = new Search();
            search.InitialAuthorBTreeLines("D:\\dataxml\\AuthorBTree.txt");
            string[] result = search.SearchAuthor(AuthorName, 0);
            SearchByIndex_xml content = new SearchByIndex_xml();
            content.getInfomation(result, "D:\\dataxml\\dblp_index.xml", "D:\\dataxml\\result\\result_"+AuthorName+".txt");
            System.Diagnostics.Process.Start("D:\\dataxml\\result\\result_" + AuthorName + ".txt");

            search.DeleteAuthorBTreeLines();
            result = null;
        }
    }
}
