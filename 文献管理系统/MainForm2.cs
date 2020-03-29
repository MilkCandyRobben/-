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
    public partial class MainForm2 : Form
    {
        private bool isPanelToolClosed;
        private string buttonSearchLiteratureText = "搜索文献";
        private string buttonSearchCollaboratorsText = "搜索合作者";
        private string buttonStatisticsPanelText = "统计面板";
        public MainForm2()
        {
            InitializeComponent();
        }

        private void MainForm2_Load(object sender, EventArgs e)
        {
            buttonSearchLiterature.Select();
        }

        private void pictureBoxMenu_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isPanelToolClosed)
            {
                panelTool.Width += 20;
                if (panelTool.Width >= 160)
                {
                    isPanelToolClosed = !isPanelToolClosed;
                    buttonSearchLiterature.Text = buttonSearchLiteratureText ;
                    buttonSearchCollaborators.Text = buttonSearchCollaboratorsText;
                    buttonStatisticsPanel.Text = buttonStatisticsPanelText;
                    pictureBoxMenu.BackColor = Color.PaleTurquoise;
                    timer1.Enabled = false;
                }
            }
            else
            {
                panelTool.Width -= 20;
                buttonSearchLiterature.Text = "";
                buttonSearchCollaborators.Text = "";
                buttonStatisticsPanel.Text = "";
                pictureBoxMenu.BackColor = Color.LightCyan;
                if (panelTool.Width <= 40)
                {
                    isPanelToolClosed = !isPanelToolClosed;
                    timer1.Enabled = false;
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
