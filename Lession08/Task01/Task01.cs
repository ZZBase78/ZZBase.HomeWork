using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lession08
{
    public partial class Task01 : Form
    {
        public Task01()
        {
            InitializeComponent();
        }

        private void button_ShowResult_Click(object sender, EventArgs e)
        {
            Type T = typeof(DateTime);
            foreach (PropertyInfo pi in T.GetProperties())
            {
                textBox_ResultData.AppendText($"{pi.PropertyType}: {pi.Name}" + " {" + (pi.CanRead ? " get;" : "") + (pi.CanWrite ? " set;" : "") + " }" + Environment.NewLine);
            }
        }
    }
}
