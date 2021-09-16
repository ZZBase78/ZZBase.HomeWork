using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lession05
{

    /// <summary>
    /// Статический класс для обработки текста
    /// </summary>
    static class Message
    {

        /// <summary>
        /// Возможные разделители слов, в порядке их правильного замещения
        /// </summary>
        static string[] separators = { "\r\n", "\n\r", "\n", "\r", "\t", " — ", " - ", ".", ",", "?", "!", ":", ";", "(", ")", "<", ">", "«", "»", "[", "]"};
        public readonly static char[] single_separators = { '\n', '\r', '\t', '—', '-', '.', ',', '?', '!', ':', ';', '(', ')', '<', '>', '«', '»', '[', ']', ' ', '_', '+', '-', '=' };

        /// <summary>
        /// Паттерн слова для регулярного выражения
        /// </summary>
        public readonly static string word_pattern = "\\b[a-zA-Zа-яА-Я]+\\b";

        /// <summary>
        /// Проверяет является ли данная строка словом
        /// </summary>
        /// <param name="word">проверяемая строка</param>
        /// <returns>true - это слово</returns>
        static bool IsWord(string word)
        {
            Regex r = new Regex("^" + word_pattern + "$");
            return r.IsMatch(word);
        }

        /// <summary>
        /// Выводит текст на экран с автоматическим переносом строк
        /// строки не более переданной заданной ширины
        /// </summary>
        /// <param name="text">текст для вывода</param>
        /// <param name="max_width">максимальная ширина выводимой строки</param>
        public static void PrintText(string text, int max_width)
        {

            My.Message("***");

            StringBuilder current_string = new StringBuilder();
            StringBuilder current_word = new StringBuilder();

            foreach (char ch in text)
            {
                if ((ch == '\n') || (ch == '\r'))
                {
                    if (current_string.Length + current_word.Length > max_width)
                    {
                        if (current_string.Length > 0) My.Message(current_string.ToString());
                        current_string = new StringBuilder(current_word.ToString());
                        current_word.Clear();
                    }
                    else
                    {
                        if ((current_string.Length + current_word.Length) > 0) My.Message(current_string.ToString() + current_word.ToString());
                        current_string.Clear();
                        current_word.Clear();
                    }
                }
                else if (ch == ' ')
                {
                    current_word.Append(ch);
                    if (current_string.Length + current_word.Length > max_width)
                    {
                        My.Message(current_string.ToString());
                        current_string = new StringBuilder(current_word.ToString());
                        current_word.Clear();
                    }
                    else 
                    {
                        current_string.Append(current_word.ToString());
                        current_word.Clear();
                    }
                }
                else
                {
                    current_word.Append(ch);
                }
            }

            if ((current_string.Length + current_word.Length) > 0) My.Message(current_string.ToString() + current_word.ToString());

            My.Message("***");
        }

        /// <summary>
        /// Удаление из строки двойных пробелов
        /// </summary>
        /// <param name="text">исходная строка</param>
        /// <returns>строка-результат</returns>
        public static string RemoveDoubleSpaces(string text)
        {
            //двойные пробелы заменим на одинарные, несколько раз, т.к. тройные и более пробелы необходимо убирать несколько раз

            StringBuilder result = new StringBuilder(text);

            bool repeat = true;
            do
            {
                StringBuilder new_result = new StringBuilder(result.ToString());
                new_result.Replace("  ", " ");
                repeat = new_result.ToString() != result.ToString(); //повторяем цикл, до тех пор пока replace не перестанет приносить новый результат
                result = new StringBuilder(new_result.ToString());
            } while (repeat);

            return result.ToString();
        }

        /// <summary>
        /// Метод читающий текстовый файл и помещающий содержимое файла в строку
        /// </summary>
        /// <param name="filename">полное имя файла</param>
        /// <returns>строка содержимое файла</returns>
        public static string Load(string filename)
        {

            string result = "";

            if (!File.Exists(filename))
            {
                My.ErrorSignal($"Файл {filename} не найден");
                return result;
            }

            try
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    if (!reader.EndOfStream) result = reader.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                My.ErrorSignal($"Ошибка чтения файла: {e.Message}");
                result = "";
            }
            return result;
        }

        /// <summary>
        /// Метод выводит содержимое словаря на экран
        /// </summary>
        /// <param name="dictionary">словарь для вывода на жкран</param>
        public static void PrintDictionary(Dictionary<string, int> dictionary)
        {
            foreach (KeyValuePair<string, int> key_value in dictionary)
            {
                My.Message($"{key_value.Key} - {key_value.Value}");
            }
        }

        /// <summary>
        /// Выводит на экран массив строк разделенных пробелом
        /// </summary>
        /// <param name="words"></param>
        public static void PrintStringArray(string[] words)
        {
            string text = string.Join(" ", words);
            PrintText(text, Console.WindowWidth - 1);
        }

        /// <summary>
        /// Метод возвращает слова из строки, длина которых не превышает переданный параметр
        /// </summary>
        /// <param name="text">текст для анализа</param>
        /// <param name="maxlength">максимальная длина слова</param>
        /// <returns>Массив строк</returns>
        public static string[] GetWordsNotLonger(string text, int maxlength)
        {

            string[] words = text.Split(single_separators, StringSplitOptions.RemoveEmptyEntries);

            List<string> list = new List<string>();
            foreach (string word in words)
            {
                if (word.Length <= maxlength) list.Add(word);
            }

            string[] result = new string[list.Count];
            list.CopyTo(result);

            return result;
        }

        /// <summary>
        /// Возвращает строку, в которой удалены все слова заканчивающиеся на определенный символ
        /// регистр символа не имет значения
        /// </summary>
        /// <param name="text">тест для обработки</param>
        /// <param name="ch">символ для проверки</param>
        /// <returns></returns>
        public static string RemoveWordsEndedByChar(string text, char ch)
        {

            // Проблема реаизации этого задания в том, что при выборе например символа 'И' и если в текст есть предлог "И"
            // То замена данного предлога на <пусто>, вызовет удаление всех символов 'и' из всех слов по всей строке
            // для правильной реализации нужно использовать регулярные выражения

            StringBuilder s = new StringBuilder(text);

            Regex r = new Regex(Message.word_pattern);
            MatchCollection matchCollection = r.Matches(s.ToString());

            // переберем все паттерны с конца,
            // т.к. при удалении в обычном порядке индексы строки будут сдвигаться влево и следующее совпадение будет указывать некорректно

            for (int i = matchCollection.Count - 1; i >= 0; i--)
            {
                Match match = matchCollection[i];

                if ((match.Value[match.Value.Length - 1] == Char.ToUpper(ch)) || (match.Value[match.Value.Length - 1] == Char.ToLower(ch)))
                {
                    s.Remove(match.Index, match.Length);
                }
                
            }

            return RemoveDoubleSpaces(s.ToString());
        }

        /// <summary>
        /// Возвращает первое самое длинное слово из переданной строки
        /// </summary>
        /// <param name="text">строка для анализа</param>
        /// <returns>первое самое длинное слово</returns>
        public static string FindLongestWord(string text)
        {
            string[] words = text.Split(single_separators, StringSplitOptions.RemoveEmptyEntries);

            int maxlength = 0;
            string maxword = "";
            foreach (string word in words)
            {
                if ((word.Length > maxlength) && IsWord(word))
                {
                    maxlength = word.Length;
                    maxword = word;
                }
            }

            return maxword;
        }

        /// <summary>
        /// Метод возвращает строку состоящую из самых длинных слов текста
        /// с использованием StringBuilder
        /// </summary>
        /// <param name="text">текст для анализа</param>
        /// <returns>строка с самыми длинными словами через пробел</returns>
        public static string LongestWords(string text)
        {
            string maxword = FindLongestWord(text);

            StringBuilder result = new StringBuilder();
            string[] words = text.Split(single_separators, StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in words)
            {
                if ((word.Length == maxword.Length) && IsWord(word)) result.Append(word + " ");
            }

            return result.ToString();
        }

        /// <summary>
        /// Метод производящий частотный анализ переданного текста, на наличия слов из массива
        /// регистр слов не имеет значения
        /// </summary>
        /// <param name="text">текст для анализа</param>
        /// <param name="words">массив слов</param>
        /// <returns>Словарь из слов и числом вхождения его в текст</returns>
        public static Dictionary<string, int> WordsFrequence(string text, string[] patternwords)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();

            foreach(string patternword in patternwords)
            {
                if (!dict.ContainsKey(patternword.ToLower())) dict.Add(patternword.ToLower(), 0);
            }

            string[] words = text.Split(single_separators, StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in words)
            {
                if (dict.ContainsKey(word.ToLower()))
                {
                    dict[word.ToLower()]++;
                }
            }

            return dict;
        }

        /// <summary>
        /// Метод возвращает массив слов из пользовательской строки
        /// </summary>
        /// <param name="input_text">входной текст</param>
        /// <returns>массив слов</returns>
        public static string[] GetWordsFromInput(string input_text)
        {
            string[] result = input_text.Split(single_separators, StringSplitOptions.RemoveEmptyEntries);
            return result;
        }

    }
}
