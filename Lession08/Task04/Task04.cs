using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lession08.Task04
{
    public partial class Task04 : Form
    {

        DataBase database;
        BindingSource bindingSource;

        public Task04()
        {
            InitializeComponent();

            database = new DataBase();
            bindingSource = new BindingSource();

            UpdateVisible();
        }

        public void UpdateVisible()
        {
            bool db = database.Enabled;
            panel_Database.Visible = db;
            ToolStripMenuItem_Create.Enabled = true;
            ToolStripMenuItem_Open.Enabled = true;
            ToolStripMenuItem_Save.Enabled = db;
            ToolStripMenuItem_SaveAs.Enabled = db;
            button_Add.Enabled = db;
            button_Delete.Enabled = bindingSource.Position != -1 && bindingSource.Position < bindingSource.Count;
        }

        void UpdateColumnHeaders()
        {
            dataGridView.Columns[0].HeaderText = "Имя";
            dataGridView.Columns[1].HeaderText = "Фамилия";
            dataGridView.Columns[2].HeaderText = "Отчество";
            dataGridView.Columns[3].HeaderText = "Дата рождения";
        }

        private void ToolStripMenuItem_Create_Click(object sender, EventArgs e)
        {
            database.Create();
            
            bindingSource.DataSource = database.list;
            dataGridView.DataSource = bindingSource;
            UpdateColumnHeaders();
            UpdateVisible();
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            bindingSource.Add(new Person());
            bindingSource.Position = bindingSource.Count - 1;
            database.Saved = false;
            UpdateVisible();
        }

        private void dataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            Program.MessageToolError("В поле введены не корректные данные");
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            if (bindingSource.Position != -1 && bindingSource.Position < bindingSource.Count)
            {
                bindingSource.RemoveCurrent();
                database.Saved = false;
                UpdateVisible();
            }
            
        }

        private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            database.Saved = false;
        }

        private void ToolStripMenuItem_Save_Click(object sender, EventArgs e)
        {
            if (database.Enabled)
            {
                database.Save();
            }
        }

        private void ToolStripMenuItem_Open_Click(object sender, EventArgs e)
        {
            if (database.Enabled && !database.Saved)
            {
                DialogResult result = MessageBox.Show("База данных не сохранена. Продолжить?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result != DialogResult.Yes) return;
            }

            //database.Create();
            if (database.Load())
            {
                bindingSource.DataSource = database.list;
                dataGridView.DataSource = bindingSource;
                UpdateColumnHeaders();
                UpdateVisible();
            }

        }

        private void ToolStripMenuItem_SaveAs_Click(object sender, EventArgs e)
        {
            database.SaveAs();
        }

        private void Task04_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (database.Enabled && !database.Saved)
            {
                DialogResult result = MessageBox.Show("База данных не сохранена. Продолжить?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result != DialogResult.Yes) e.Cancel = true;
            }

        }
    }
}
