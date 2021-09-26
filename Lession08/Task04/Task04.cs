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

        /// <summary>
        /// Метод управляем видимостью и доступностью элементов
        /// </summary>
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

        /// <summary>
        /// Инициализирует название колонок
        /// </summary>
        void UpdateColumnHeaders()
        {
            dataGridView.Columns[0].HeaderText = "Имя";
            dataGridView.Columns[1].HeaderText = "Фамилия";
            dataGridView.Columns[2].HeaderText = "Отчество";
            dataGridView.Columns[3].HeaderText = "Дата рождения";
        }

        /// <summary>
        /// Создание новой базы данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_Create_Click(object sender, EventArgs e)
        {
            database.Create();
            
            bindingSource.DataSource = database.list;
            dataGridView.DataSource = bindingSource;
            UpdateColumnHeaders();
            UpdateVisible();
        }

        /// <summary>
        /// Добавление новой записи в базу данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Add_Click(object sender, EventArgs e)
        {
            bindingSource.Add(new Person());
            bindingSource.Position = bindingSource.Count - 1;
            database.Saved = false;
            UpdateVisible();
        }

        /// <summary>
        /// Сообщение при не корректном ввода данных в ячейку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            Program.MessageToolError("В поле введены не корректные данные");
        }

        /// <summary>
        /// Удаление записи из базы данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Delete_Click(object sender, EventArgs e)
        {
            // проверка корректности текущей позиции
            if (bindingSource.Position != -1 && bindingSource.Position < bindingSource.Count)
            {
                bindingSource.RemoveCurrent();
                database.Saved = false;
                UpdateVisible();
            }
            
        }

        /// <summary>
        /// Регистрации изменений в базе данных, установка флага база данных изменена
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            database.Saved = false;
        }

        /// <summary>
        /// Запись базы данных под тем же именем
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_Save_Click(object sender, EventArgs e)
        {
            if (database.Enabled)
            {
                database.Save();
            }
        }

        /// <summary>
        /// Открытие существующей базы данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                // если пользователь не отказался от выбора имени файла
                bindingSource.DataSource = database.list;
                dataGridView.DataSource = bindingSource;
                UpdateColumnHeaders();
                UpdateVisible();
            }

        }

        /// <summary>
        /// Сохранение базы под новым именем
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_SaveAs_Click(object sender, EventArgs e)
        {
            database.SaveAs();
        }

        /// <summary>
        /// Проверка сохранения базы данных перед закрытиыем формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
