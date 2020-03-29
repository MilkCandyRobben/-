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
    public partial class OpeningForm : Form
    {
        public OpeningForm()
        {
            InitializeComponent();
        }

        private void timerProgressbar_Tick(object sender, EventArgs e)
        {
            panelProgressbar.Width += (new Random()).Next(50, 100);
            if (panelProgressbar.Width >= 700)
            {
                timerProgressbar.Stop();
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
