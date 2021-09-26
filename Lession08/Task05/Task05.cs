using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lession08.Task05
{
    public partial class Task05 : Form
    {

        Converter converter;

        void UpdateVisible()
        {
            label_Source_filename.Text = converter.source_filename;
            label_Destination_filename.Text = converter.destination_filename;
        }

        public Task05()
        {
            InitializeComponent();
            converter = new Converter();
        }

        private void button_Source_Click(object sender, EventArgs e)
        {
            converter.Choose_Source();
            UpdateVisible();
        }

        private void button_Destination_Click(object sender, EventArgs e)
        {
            converter.Choose_Desination();
            UpdateVisible();
        }

        private void button_Convert_Click(object sender, EventArgs e)
        {
            converter.Convert();
            UpdateVisible();
        }
    }
}
