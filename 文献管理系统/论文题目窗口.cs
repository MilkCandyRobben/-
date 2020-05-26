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
    public partial class 论文题目窗口 : Form
    {
        public 论文题目窗口()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            加载窗口 form = new 加载窗口();
            form.Show();
            string TitleName = this.TitleBox.Text;

            Search search_title = new Search();
            search_title.InitialKeywordBTreeLines("D:\\dataxml\\KeywordBTree.txt");
            string[] result = search_title.SearchTitle(TitleName);
            if (result != null)
            {
                SearchByIndex_xml content_title = new SearchByIndex_xml();
                content_title.getInfomation(result, "D:\\dataxml\\dblp_index.xml", "D:\\dataxml\\result\\result_title.txt");
                System.Diagnostics.Process.Start("D:\\dataxml\\result\\result_title.txt");
                search_title.DeleteKeywordBTreeLines();
                result = null;

            }
            else
            {
                Console.WriteLine();
                错误窗口 form1 = new 错误窗口();
                form1.Show();
            }
            
            
            form.Close();
        }
    }
}
