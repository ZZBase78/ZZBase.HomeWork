using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_DataGrid
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Person.list = new List<Person>();
            Person.list.Add(new Person("Первый", "Первый фио", 10));
            Person.list.Add(new Person("Второй", "Второй фио", 20));
            Person.list.Add(new Person("Nhtnbq", "nhtnbq фио", 30));

            bindingSource1.DataSource = Person.list;

            dataGridView1.DataSource = bindingSource1;
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Insert)
            {
                //bindingSource1.Add(new Person("qaqqa", "qaqaqaq", 40));
                bindingSource1.Add(new Person());
                bindingSource1.Position = bindingSource1.Count;
                //Person.list.Add();
                //dataGridView1.DataSource = Person.list;
                //dataGridView1.Refresh();
                //dataGridView1.RefreshEdit();
                //dataGridView1.Update();
                //dataGridView1.Rows.Add(new Person("qaqqa", "qaqaqaq", 40));
            }
            if (e.KeyData == Keys.Delete)
            {
                bindingSource1.RemoveCurrent();
                //Person.list.Add();
                //dataGridView1.DataSource = Person.list;
                //dataGridView1.Refresh();
                //dataGridView1.RefreshEdit();
                //dataGridView1.Update();
                //dataGridView1.Rows.Add(new Person("qaqqa", "qaqaqaq", 40));
            }
            if (e.KeyData == Keys.F1)
            {
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
    }
}
