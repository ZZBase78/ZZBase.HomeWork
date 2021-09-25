using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_Main_Window_2
{
    public partial class MainWindow : Form
    {

        public void MessageTool(string text)
        {
            richTextBox_tooltext.AppendText(text + "\n");
            ToolBoxVisible(true);
        }

        public MainWindow()
        {
            InitializeComponent();
            ToolBoxVisible(false);
        }

        public void ToolBoxVisible(bool visible)
        {
            splitter_toolbox.Visible = visible;
            panel_toolbox.Visible = visible;
        }

        private void toolBoxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolBoxVisible(true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox_tooltext.Clear();
        }

        private void button_tool_close_Click(object sender, EventArgs e)
        {
            ToolBoxVisible(false);
        }
    }
}
