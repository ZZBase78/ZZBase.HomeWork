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
    public partial class Task02_EnterNumber : Form
    {
        /// <summary>
        /// переменная для хранения возвращаемого числа из формы
        /// </summary>
        public int result_number;

        public Task02_EnterNumber()
        {
            InitializeComponent();
            result_number = -1;
            CenterToScreen();
        }

        /// <summary>
        /// Метод для проверки возможнсти выхода
        /// </summary>
        void Try_Exit()
        {
            if (int.TryParse(textBox_number.Text, out int result))
            {
                result_number = result;
                this.DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void button_continue_Click(object sender, EventArgs e)
        {
            Try_Exit();
        }

        private void textBox_number_TextChanged(object sender, EventArgs e)
        {
            // изменяем достпуность кнопки продолжить в зависимости от значения поля ввода
            button_continue.Enabled = int.TryParse(textBox_number.Text, out int result);
        }

        /// <summary>
        /// Метод проверки нажатия клавиши enter, чтобы не нажимать мышкой на кнопку ПродолжитьУ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_number_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Try_Exit();
            }
        }
    }
}
