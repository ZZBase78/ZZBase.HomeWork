using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lession08.TrueFalseGame
{
    class Engine
    {
        List<Question> questions;

        public Question current_question;

        int current_count;
        int current_true;
        int current_percent;

        int best_count;
        int best_true;
        int best_percent;

        string default_filname;

        Random rnd;

        public Engine()
        {
            questions = new List<Question>();
            current_question = null;

            current_count = 0;
            current_true = 0;
            current_percent = 0;

            best_count = 0;
            best_true = 0;
            best_percent = 0;

            default_filname = "TrueFalseGame\\newtf.xml";

            rnd = new Random();
        }

        void Load()
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Question>));
                using (Stream stream = new FileStream(default_filname, FileMode.Open, FileAccess.Read))
                {
                    questions = (List<Question>)xmlSerializer.Deserialize(stream);
                }
            }
            catch (Exception e)
            {
                Program.MessageToolError($"Ошибка чтения файла {default_filname}" + Environment.NewLine + $"Ошибка: {e.Message}");
                questions = new List<Question>();
            }
        }
        public void NewGame()
        {
            Load();
            GetNextQuestion();
        }
        public bool GetNextQuestion()
        {

            if (questions.Count == 0)
            {
                current_question = null;
                return false;
            }

            int next_index = rnd.Next(0, questions.Count);
            current_question = questions[next_index];
            questions.RemoveAt(next_index);
            return true;
        }
        public void Increment_Current_Game(bool correct)
        {
            current_count++;
            current_true += correct ? 1 : 0;
            current_percent = current_true * 100 / current_count;
        }
        public bool IsTrue(bool answer)
        {
            return (current_question.TrueFalse == answer);
        }
        public void playSound(bool corrext)
        {
            if (corrext)
            {
                SoundPlayer simpleSound = new SoundPlayer("TrueFalseGame\\Correct.wav");
                simpleSound.Play();
            }
            else
            {
                SoundPlayer simpleSound = new SoundPlayer("TrueFalseGame\\NotCorrect.wav");
                simpleSound.Play();
            }

        }
        public string GetCurrentQuestionText()
        {
            if (current_question == null) return ""; else return current_question.Text;
        }
        public string CurrentGameString()
        {
            return $"Текущая игра: вопросов: {current_count}; правильных ответов: {current_true}; Успех: {current_percent:F0}%";
        }
        public string BestGameString()
        {
            return $"Текущая игра: вопросов: {best_count}; правильных ответов: {best_true}; Успех: {best_percent:F0}%";
        }
        public bool IsLast()
        {
            return (questions.Count == 0) && (current_question != null);
        }
        public void UpdateBestGame()
        {
            if (IsBestGame())
            {
                best_percent = current_percent;
                best_count = current_count;
                best_true = current_true;

                current_percent = 0;
                current_count = 0;
                current_true = 0;
            }
        }
        public bool IsBestGame()
        {
            return current_percent > best_percent;
        }
        public string EngGameMessage()
        {
            if (IsBestGame())
            {
                return "Новый рекорд" + Environment.NewLine + "Успех: " + $"{current_percent:F0}%";
            }
            else
            {
                return "Вы ответили на все вопросы" + Environment.NewLine + "Успех: " + $"{current_percent:F0}";
            }
            
        }
    }
}
