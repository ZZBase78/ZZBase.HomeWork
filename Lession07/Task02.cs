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
    /// <summary>
    /// 2. Используя Windows Forms, разработать игру «Угадай число». 
    /// Компьютер загадывает число от 1 до 100, а человек пытается его угадать за минимальное число попыток.
    /// Компьютер говорит, больше или меньше загаданное число введенного.
    /// a) Для ввода данных от человека используется элемент TextBox;
    /// б) ** Реализовать отдельную форму c TextBox для ввода числа.
    /// </summary>
    public partial class Task02 : Form
    {

        /// <summary>
        /// Счетчик попыток
        /// </summary>
        int _try_count;

        /// <summary>
        /// Загаданное число
        /// </summary>
        int number;
        
        /// <summary>
        /// Свойство счетчика попыток, меняет текст на форме при изменении
        /// </summary>
        int try_count
        {
            get
            {
                return _try_count;
            }
            set
            {
                _try_count = value;
                label_try_count.Text = $"Попытка: {_try_count}";
            }
        }

        public Task02()
        {
            InitializeComponent();
            number = 0;
            try_count = 0;
            CenterToScreen();
        }

        /// <summary>
        /// Метод загадывает число и начинает игру
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_start_Click(object sender, EventArgs e)
        {
            number = new Random().Next(1, 1001);
            try_count = 0;
            Game();
        }

        /// <summary>
        /// Метод непосредственной реализации игры
        /// </summary>
        void Game()
        {
            while (true)
            {
                Task02_EnterNumber enter_number = new Task02_EnterNumber();
                try_count++;
                if (enter_number.ShowDialog() == DialogResult.OK)
                {
                    int current_number = enter_number.result_number;
                    if (number < current_number)
                    {
                        MessageBox.Show("Загаданное число МЕНЬШЕ", "МЕНЬШЕ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (number > current_number)
                    {
                        MessageBox.Show("Загаданное число БОЛЬШЕ", "БОЛЬШЕ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Вы угадали задуманное число", "ПОБЕДА", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        label_try_count.Text = $"Использовано попыток: {try_count}";
                        break;
                    }
                }
                else
                {
                    MessageBox.Show("Игра остановлена", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    try_count = 0;
                    break;
                }
                
            }
        }
    }
}
