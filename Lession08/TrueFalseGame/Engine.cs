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

        /// <summary>
        /// Загрузка файла
        /// </summary>
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
        
        /// <summary>
        /// Начало новой игры
        /// </summary>
        public void NewGame()
        {
            Load();
            GetNextQuestion();
        }
        
        /// <summary>
        /// Полчение следующего вопроса
        /// </summary>
        /// <returns></returns>
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
        
        /// <summary>
        /// Увеличение счетчиков текущей игры
        /// </summary>
        /// <param name="correct"></param>
        public void Increment_Current_Game(bool correct)
        {
            current_count++;
            current_true += correct ? 1 : 0;
            current_percent = current_true * 100 / current_count;
        }
        
        /// <summary>
        /// Проверка корректности ответа
        /// </summary>
        /// <param name="answer"></param>
        /// <returns></returns>
        public bool IsTrue(bool answer)
        {
            return (current_question.TrueFalse == answer);
        }
        
        /// <summary>
        /// Проигрывание музыки в зависимости от правильности ответа
        /// </summary>
        /// <param name="correct"></param>
        public void playSound(bool correct)
        {
            if (correct)
            {
                if (File.Exists("TrueFalseGame\\Correct.wav"))
                {
                    SoundPlayer simpleSound = new SoundPlayer("TrueFalseGame\\Correct.wav");
                    simpleSound.Play();
                }
            }
            else
            {
                if (File.Exists("TrueFalseGame\\NotCorrect.wav"))
                {
                    SoundPlayer simpleSound = new SoundPlayer("TrueFalseGame\\NotCorrect.wav");
                    simpleSound.Play();
                }
            }

        }
        
        /// <summary>
        /// Получение текста текущего вопроса
        /// </summary>
        /// <returns></returns>
        public string GetCurrentQuestionText()
        {
            if (current_question == null) return ""; else return current_question.Text;
        }
        
        /// <summary>
        /// Получение представления текущего состояния игры
        /// </summary>
        /// <returns></returns>
        public string CurrentGameString()
        {
            return $"Текущая игра: вопросов: {current_count}; правильных ответов: {current_true}; Успех: {current_percent:F0}%";
        }
        
        /// <summary>
        /// Получение представления лучшей игры
        /// </summary>
        /// <returns></returns>
        public string BestGameString()
        {
            return $"Текущая игра: вопросов: {best_count}; правильных ответов: {best_true}; Успех: {best_percent:F0}%";
        }
        
        /// <summary>
        /// Проверка последний ли вопрос
        /// </summary>
        /// <returns></returns>
        public bool IsLast()
        {
            return (questions.Count == 0) && (current_question != null);
        }
        
        /// <summary>
        /// Обновление данных лучшей игры
        /// </summary>
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

        /// <summary>
        /// Является ли текущая игра лучшей
        /// </summary>
        /// <returns></returns>
        public bool IsBestGame()
        {
            return current_percent > best_percent;
        }

        /// <summary>
        /// Формирование строки по окончании игры
        /// </summary>
        /// <returns></returns>
        public string EngGameMessage()
        {
            if (IsBestGame())
            {
                return "Новый рекорд" + Environment.NewLine + "Успех: " + $"{current_percent:F0}%";
            }
            else
            {
                return "Вы ответили на все вопросы" + Environment.NewLine + "Успех: " + $"{current_percent:F0}%";
            }
            
        }
    }
}
