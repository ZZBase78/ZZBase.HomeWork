using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lession08.TrueFalseGame
{
    public partial class TrueFalseGameForm : Form
    {
        Engine engine;

        public TrueFalseGameForm()
        {
            InitializeComponent();

            engine = new Engine();

            UpdateVisible();
        }
        
        /// <summary>
        /// Обновление элементов формы
        /// </summary>
        void UpdateVisible()
        {
            label_Question.Text = engine.GetCurrentQuestionText();
            button_Start.Visible = engine.current_question == null;
            button_True.Visible = engine.current_question != null;
            button_False.Visible = engine.current_question != null;
            label_CurrentGame.Text = engine.CurrentGameString();
            label_BestGame.Text = engine.BestGameString();
        }

        private void button_Start_Click(object sender, EventArgs e)
        {
            engine.NewGame();
            UpdateVisible();
        }

        /// <summary>
        /// Конец Игры
        /// </summary>
        void EndGame()
        {
            bool best = engine.IsBestGame();
            EndGameForm F = new EndGameForm();
            F.text = engine.EngGameMessage();
            F.victory = best;
            F.UpdateVisible();
            engine.UpdateBestGame();
            UpdateVisible();
            F.ShowDialog();
        }

        /// <summary>
        /// Проверка ответа на вопрос
        /// </summary>
        /// <param name="answer"></param>
        public void Move(bool answer)
        {
            bool correct = engine.IsTrue(answer);

            engine.playSound(correct);
            engine.Increment_Current_Game(correct);

            bool last = engine.IsLast();
            engine.GetNextQuestion();
            UpdateVisible();

            if (last) EndGame();
        }

        private void button_True_Click(object sender, EventArgs e)
        {
            Move(true);
        }

        private void button_False_Click(object sender, EventArgs e)
        {
            Move(false);
        }
    }
}
