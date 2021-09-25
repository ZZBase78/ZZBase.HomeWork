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
    public partial class Task02 : Form
    {
        
        void UpdateForm()
        {
            textBox1.Text = numericUpDown1.Value.ToString();
        }

        public Task02()
        {
            InitializeComponent();
            UpdateForm();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            UpdateForm();
        }
    }
}
