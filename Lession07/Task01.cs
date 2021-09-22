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
    /// 1.
    /// а) Добавить в программу «Удвоитель» подсчёт количества отданных команд удвоителю.
    /// б) Добавить меню и команду «Играть». При нажатии появляется сообщение,
    /// какое число должен получить игрок.Игрок должен получить это число за минимальное количество ходов.
    /// в) * Добавить кнопку «Отменить», которая отменяет последние ходы.
    /// Используйте библиотечный обобщенный класс System.Collections.Generic.Stack<int> Stack.
    /// Вся логика игры должна быть реализована в классе с удвоителем.
    /// </summary>
    public partial class Task01 : Form
    {
        int Move_count { get; set; }
        bool Game_mode { get; set; }
        int Target_Number { get; set; }
        int Target_MinMove { get; set; }

        Stack<int> stack; //Стек последних значений

        /// <summary>
        /// Инициализация переменных, и обновление элементов формы
        /// </summary>
        public Task01()
        {
            CenterToScreen();

            InitializeComponent();

            Move_count = 0;
            Game_mode = false;
            Target_Number = 0;
            Target_MinMove = 0;
            stack = new Stack<int>();

            Update_form();
        }

        /// <summary>
        /// Метод возвращает минимальное необходимое количество ходов для достижения цели игры
        /// </summary>
        /// <param name="target">цель игры</param>
        /// <returns>количество ходов</returns>
        int CalculateMinMove(int target)
        {
            if (target <= 2) return 1;

            if (target % 2 == 0)
            {
                return 1 + CalculateMinMove(target / 2);
            }
            else
            {
                return 1 + CalculateMinMove(target - 1);
            }
        }

        /// <summary>
        /// Запуск режима игры
        /// </summary>
        void GameStart()
        {
            Game_mode = true;
            Target_Number = new Random().Next(1, 101);
            Target_MinMove = CalculateMinMove(Target_Number);
            Move_count = 0;
            stack.Clear();
            Update_form();
        }

        /// <summary>
        /// Проверка выигрыша или проигрыша
        /// </summary>
        /// <returns>истина - был или выигрыш или проигрыш</returns>
        bool CheckVictory()
        {
            if (Game_mode)
            {
                int current = int.Parse(lblNumber.Text);
                if (current == Target_Number)
                {
                    MessageBox.Show("ВЫ ВЫИГРАЛИ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else if (current > Target_Number)
                {
                    MessageBox.Show("ВЫ ПРОИГРАЛИ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true;
                }
            }

            return false;

        }

        /// <summary>
        /// Обновление элементов формы
        /// </summary>
        void Update_form()
        {
            label_info.Text = $"Сделано ходов: {Move_count}";

            if (Game_mode)
            {
                label_game_info.Text = $"Цель: {Target_Number}\nМин.ходов: {Target_MinMove}";
            }
            else
            {
                label_game_info.Text = "";
            }

            //если стек имеет значения, то активируем кнопку "Отменить"
            button_Undo.Enabled = stack.Count > 0;

            if (CheckVictory())
            {
                // если был выигрыш или проигрыш, то обнуляем начальные значения и выходим из режима игры
                Move_count = 0;
                Game_mode = false;
                Target_Number = 0;
                Target_MinMove = 0;
                lblNumber.Text = "1";
                stack.Clear();
                Update_form();
            }
        }

        private void btnCommand1_Click(object sender, EventArgs e)
        {
            int current = int.Parse(lblNumber.Text);
            stack.Push(current);
            lblNumber.Text = (current + 1).ToString();
            Move_count++;
            Update_form();
        }

        private void btnCommand2_Click(object sender, EventArgs e)
        {
            int current = int.Parse(lblNumber.Text);
            stack.Push(current);
            lblNumber.Text = (current * 2).ToString();
            Move_count++;
            Update_form();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            lblNumber.Text = "1";
            Move_count = 0;
            stack.Clear();
            Update_form();
        }

        private void button_game_Click(object sender, EventArgs e)
        {
            GameStart(); // начинаем игру
        }

        /// <summary>
        /// метод "отката" на предыдущее значение
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Undo_Click(object sender, EventArgs e)
        {
            if (stack.Count > 0)
            {
                int last = stack.Pop();
                lblNumber.Text = last.ToString();
                Move_count--;
                Update_form();
            }
        }
    }
}
