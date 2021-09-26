using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Lession08.Task05
{
    public class Converter
    {
        public string source_filename;
        public string destination_filename;

        public Converter()
        {
            source_filename = "";
            destination_filename = "";
        }

        public void Choose_Source()
        {
            string result = ChooseFileNameToLoad();
            if (result != "") source_filename = result;
        }

        public void Choose_Desination()
        {
            string result = ChooseFileNameToSave();
            if (result != "") destination_filename = result;
        }

        string ChooseFileNameToLoad()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "csv-files (*.csv)|*.csv";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                return openFileDialog.FileName;
            }
            else
            {
                return "";
            }
        }

        string ChooseFileNameToSave()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "xml - files (*.xml) | *.xml";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                return saveFileDialog.FileName;
            }
            else
            {
                return "";
            }

        }

        /// <summary>
        /// Открывает полученный файл в блокноте
        /// </summary>
        void StartNotepad()
        {
            Process iStartProcess = new Process();
            iStartProcess.StartInfo.FileName = @"notepad.exe";
            iStartProcess.StartInfo.Arguments = $" \"{destination_filename}\"";
            iStartProcess.Start();
        }

        /// <summary>
        /// Метод конвертации
        /// </summary>
        /// <returns></returns>
        public bool Convert()
        {
            if (source_filename == "")
            {
                Program.MessageToolError("Не выбран файл источник");
                return false;
            }
            if (destination_filename == "")
            {
                Program.MessageToolError("Не выбран файл приемник");
                return false;
            }

            if (!File.Exists(source_filename))
            {
                Program.MessageToolError($"Файл источника \"{source_filename}\" не существует");
                return false;
            }

            try
            {
                // Чтение файла создание списка

                List<Student> list = new List<Student>();
                using (StreamReader sr = new StreamReader(source_filename))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] s = sr.ReadLine().Split(';');
                        Student st = new Student(s[0], s[1], s[2], s[3], s[4], int.Parse(s[6]), int.Parse(s[5]), int.Parse(s[7]), s[8]);
                        list.Add(st);
                    }
                }
                Program.MessageTool($"Файл источника успешно прочитан");

                //Сохранение в файл XML

                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Student>));
                using (Stream stream = new FileStream(destination_filename, FileMode.Create, FileAccess.Write))
                {
                    xmlSerializer.Serialize(stream, list);
                }
                Program.MessageTool($"Файл успешно сконвертирован");

                DialogResult result = MessageBox.Show("Открыть полученный файл в блокноте?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes) StartNotepad();

                return true;

            }
            catch (Exception e)
            {
                Program.MessageToolError("Ошибка выполнения преобразования" + Environment.NewLine + $"ОШИБКА: {e.Message}");
                return false;

            }

        }
    }
}
