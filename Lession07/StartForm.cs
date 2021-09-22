using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lession07
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            CenterToScreen();

            InitializeComponent();
        }

        private void button_Task01_Click(object sender, EventArgs e)
        {
            // Выбираем следующую форму для открытия, и закрываем текущую

            Program.nextform = new Task01();
            Close();
        }

        private void button_Task02_Click(object sender, EventArgs e)
        {
            // Выбираем следующую форму для открытия, и закрываем текущую

            Program.nextform = new Task02();
            Close();
        }
    }
}
