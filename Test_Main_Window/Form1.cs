using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_Main_Window
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void newFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Form F = new Form2();
            //F.MdiParent = this;
            //F.Dock = DockStyle.Bottom;
            ////F.BringToFront();
            //F.Show();

            Form F = new Form3();
            F.MdiParent = this;
            F.Show();
        }

        private void showMessagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Visible = true;
            splitter1.Visible = true;
        }

        private void hideMessageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Visible = false;
            splitter1.Visible = false;

        }
    }
}
