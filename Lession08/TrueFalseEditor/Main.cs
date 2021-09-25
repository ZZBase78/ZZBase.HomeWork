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
    public partial class Main : Form
    {
        private TrueFalse database;

        public Main()
        {
            InitializeComponent();
        }

        private void menuItemExit_Click(object sender, EventArgs e)
        {
            Close(); // Проверка сохраненности базы, в событии FormClosing
        }

        private void menuItemNew_Click(object sender, EventArgs e)
        {

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                database = new TrueFalse(saveFileDialog.FileName);
                database.Add("Земля круглая?", true);
                database.Save();
                // если возникает ошибка записи в файл, то продолжаем работу, т.к. на текущее состояние базы это не влияет
                nudNumber.Maximum = 1;
                nudNumber.Minimum = 1;
                nudNumber.Value = 1;
            }
        }

        private void menuItemOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                database = new TrueFalse(openFileDialog.FileName);
                if (database.Load())
                {
                    //меняем данные, только если загрузка удалась
                    nudNumber.Maximum = database.Count;
                    nudNumber.Minimum = 1;
                    nudNumber.Value = 1;
                }
            }
        }

        private void nudNumber_ValueChanged(object sender, EventArgs e)
        {
            if (nudNumber.Value == 0) return;

            if (database == null)
            {
                Program.MessageToolError("База данных не создана");
                nudNumber.Value = 0;
                return;
            }

            tbQuestion.Text = database[(int)nudNumber.Value - 1].Text;
            cbTrue.Checked = database[(int)nudNumber.Value - 1].TrueFalse;
        }

        private void menuItemSave_Click(object sender, EventArgs e)
        {
            if (database == null)
            {
                Program.MessageToolError("База данных не создана");
                return;
            }

            database.Save();
            //Если будет ошибка при записи, то метод сообщит об этом
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (database == null)
            {
                Program.MessageToolError("База данных не создана");
                return;
            }

            database.Add($"#{database.Count + 1}", true);
            nudNumber.Maximum = database.Count;
            nudNumber.Value = database.Count;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (database == null)
            {
                Program.MessageToolError("База данных не создана");
                return;
            }

            database[(int)nudNumber.Value - 1].Text = tbQuestion.Text;
            database[(int)nudNumber.Value - 1].TrueFalse = cbTrue.Checked;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (database == null)
            {
                Program.MessageToolError("База данных не создана");
                return;
            }

            if (database.Count > 1)
            {
                database.Remove((int)nudNumber.Value - 1);
                nudNumber.Value = database.Count;
                //в случае удаления предпоследнего элемента, nudNumber.Value не изменится, и событие не будет вызвано
                //поэтому вызов делаем вручную
                nudNumber_ValueChanged(sender, e);
            }
            else
            {
                Program.MessageToolError("В базе данных должен остаться хотя бы один вопрос-ответ");
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (database != null && !database.Saved)
            {
                DialogResult result = MessageBox.Show("База данных не сохранена. Закрыть форму?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void cbTrue_CheckedChanged(object sender, EventArgs e)
        {
            cbTrue.Text = cbTrue.Checked.ToString();
        }
    }
}
