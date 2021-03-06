using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lession08
{
    public partial class MainWindow : Form
    {

        public void MessageTool(string text)
        {
            richTextBox_tooltext.AppendText(DateTime.Now + ": " + text + Environment.NewLine);
            richTextBox_tooltext.ScrollToCaret();
            ToolBoxVisible(true);
        }
        public void MessageToolError(string text)
        {
            Color c = richTextBox_tooltext.SelectionColor;
            richTextBox_tooltext.SelectionColor = Color.Red;
            richTextBox_tooltext.AppendText(DateTime.Now + ": " + text + Environment.NewLine);
            richTextBox_tooltext.SelectionColor = c;
            richTextBox_tooltext.ScrollToCaret();
            ToolBoxVisible(true);
            //MessageBox вызывается из класса програм, т.к. если не будет (каки-то образом) главного окна, то выведется только MessageBox
            //MessageBox.Show(text, "ОШИБКА", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public MainWindow()
        {
            InitializeComponent();
            ToolBoxVisible(false);
        }

        public void ToolBoxVisible(bool visible)
        {
            //чтобы избежать мерцании формы при появлении, сместим координаты
            splitter_toolbox.Location = new Point(splitter_toolbox.Location.X, this.Size.Height - splitter_toolbox.Size.Height - panel_toolbox.Size.Height - 61);
            panel_toolbox.Location = new Point(panel_toolbox.Location.X, this.Size.Height - panel_toolbox.Size.Height - 61);
            splitter_toolbox.Visible = visible;
            panel_toolbox.Visible = visible;
        }

        private void OpenChildForm(Form f)
        {
            f.MdiParent = this;
            f.Show();
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

        private void ToolStripMenuItemTrueFalseEditor_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Main());
        }

        private void ToolStripMenuItem_Task01_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Task01());
        }

        private void ToolStripMenuItem_Task02_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Task02());
        }

        private void ToolStripMenuItem_About_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form_About());
        }

        private void ToolStripMenuItem_Task04_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Task04.Task04());
        }

        private void ToolStripMenuItem_Converter_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Task05.Task05());
        }

        private void ToolStripMenuItem_TrueFalseGame_Click(object sender, EventArgs e)
        {
            OpenChildForm(new TrueFalseGame.TrueFalseGameForm());
        }
    }
}
