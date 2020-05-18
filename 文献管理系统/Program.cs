using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 文献管理系统
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new MainForm());
            OpeningForm frm = new OpeningForm();
            
            if (frm.ShowDialog() == DialogResult.OK)
            {
                
                FileStream fs_out_demo = new FileStream("d:\\dataxml\\start.txt", FileMode.Append, FileAccess.Write);
                fs_out_demo.Close();
                FileStream fr_out = new FileStream("d:\\dataxml\\start.txt", FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fr_out);

                if (sr.ReadLine() == null)
                {
                    fr_out.Close();
                    FileStream fs_out = new FileStream("d:\\dataxml\\start.txt", FileMode.Append, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fs_out);
                    sw.Write("1");

                    sr.Close();
                    sw.Close();
                    fs_out.Close();
                    PreprocessingUtils utils = new PreprocessingUtils();
                    utils.fileFormatting("d:\\dataxml\\dblp.xml", "d:\\dataxml\\dblp_index.xml");
                    utils.getAuthorAndKeyword("d:\\dataxml\\dblp_index.xml");
                    utils.findTop100("d:\\dataxml\\top100.txt");
                    utils.createAuthorBTree("d:\\dataxml\\AuthorBTree.txt");
                    utils.createKeywordBTree("d:\\dataxml\\KeywordBTree.txt");
                    MessageBox.Show("加载完成");
                    
                }
                
                Application.Run(new MainForm());
            }








           // Console.WriteLine("输出排序后键值");
            //FileStream fs_out = new FileStream("d:\\dataxml\\start.txt", FileMode.Append, FileAccess.Write|FileAccess.Read);
            //StreamReader sr = new StreamReader(fs_out);
            //if (sr.ReadLine()!="")
            //{
            //    StreamWriter sw = new StreamWriter(fs_out);
            //    sw.Write("1");

            //    sr.Close();
            //    sw.Close();
            //    PreprocessingUtils utils = new PreprocessingUtils();
            //    utils.fileFormatting("d:\\dataxml\\dblp.xml", "d:\\dataxml\\dblp_index.xml");
            //    utils.getAuthorAndKeyword("d:\\dataxml\\dblp_index.xml");
            //    utils.findTop100("d:\\dataxml\\top100.txt");
            //    utils.createAuthorBTree("d:\\dataxml\\AuthorBTree.txt");
            //    utils.createKeywordBTree("d:\\dataxml\\KeywordBTree.txt");
            //    MessageBox.Show("加载完成");
            //}

            


            

            

            //Search search = new Search();
            //search.InitialAuthorBTreeLines("D:\\dataxml\\authorBtreeIndex.txt");

            //DateTime beforDT = System.DateTime.Now;
            //string[] result = search.SearchAuthor("H. Vincent Poor", 0);
            //DateTime afterDT = System.DateTime.Now;
            //TimeSpan ts = afterDT.Subtract(beforDT);
            //Console.WriteLine("DateTime总共花费{0}ms.", ts.TotalMilliseconds);
            //Console.WriteLine("Paul Kocher");
            //for (int i = 0; i < result.Length; i++)
            //{
            //    Console.WriteLine("\"" + result[i] + "\"");
            //    sw.Write("\"" + result[i] + "\",\n");

            //}
            //sw.Close();
            //search.InitialKeywordBTreeLines("D:\\dataxml\\keywordBtreeIndex.txt");
            //DateTime beforDT = System.DateTime.Now;
            //string[] result = search.SearchTitle("feature graphs");
            //DateTime afterDT = System.DateTime.Now;
            //TimeSpan ts = afterDT.Subtract(beforDT);
            //Console.WriteLine("DateTime总共花费{0}ms.", ts.TotalMilliseconds);
            //Console.WriteLine("feature graph");
            //for (int i = 0; i < result.Length; i++)
            //{
            //    Console.WriteLine(result[i]);
            //}
        }
    }
}
