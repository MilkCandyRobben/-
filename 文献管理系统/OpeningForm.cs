using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PreprocessingUtils;

namespace 文献管理系统
{
    public partial class OpeningForm : Form
    {
        public OpeningForm()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            //创建无参的线程
            Thread thread1 = new Thread(new ThreadStart(initXML_INDEX));
            //调用Start方法执行线程
            thread1.Start();

        }

        //private void timerProgressbar_Tick(object sender, EventArgs e)
        //{
        //    panelProgressbar.Width += (new Random()).Next(5, 10);
        //    if (panelProgressbar.Width >= 700)
        //    {
        //        timerProgressbar.Stop();
        //        this.DialogResult = DialogResult.OK;
        //    }
        //}
        public void initXML_INDEX()
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
                utils.Listener += new ListenerHandler(updateProgress);
                utils.fileFormatting("d:\\dataxml\\dblp.xml", "d:\\dataxml\\dblp_index.xml");
                utils.getAuthorAndKeyword("d:\\dataxml\\dblp_index.xml");

                utils.findHotspotTop10("d:\\dataxml\\Hotspot.txt");

                utils.findTop100("d:\\dataxml\\top100.txt");
                utils.createAuthorBTree("d:\\dataxml\\AuthorBTree.txt");
                utils.createKeywordBTree("d:\\dataxml\\KeywordBTree.txt");
                MessageBox.Show("加载完成");

            }
        }
        private void updateProgress()
        {
            panelProgressbar.Width += (new Random()).Next(2, 5);
            if (panelProgressbar.Width >= 700)
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void pictureBox_Opening_Click(object sender, EventArgs e)
        {

        }
    }
}
