using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Lession08.Task04
{
    public class DataBase
    {
        public List<Person> list;

        string filename;

        bool _saved; // признак что база сохранена после изменений

        /// <summary>
        /// Свойство показывает доступна ли база данных
        /// </summary>
        public bool Enabled
        {
            get
            {
                return (list != null);
            }
        }
        public bool Saved
        {
            get
            {
                return _saved;
            }
            set
            {
                _saved = value;
            }
        }

        /// <summary>
        /// Создание пустой базы данных
        /// </summary>
        public void Create()
        {
            list = new List<Person>();
            _saved = true;
            filename = "";
        }

        /// <summary>
        /// Выбор файла для записи
        /// </summary>
        /// <returns></returns>
        public string ChooseFileNameToSave()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
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
        /// Выбор файла для загрузки
        /// </summary>
        /// <returns></returns>
        public string ChooseFileNameToLoad()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                return openFileDialog.FileName;
            }
            else
            {
                return "";
            }

        }

        /// <summary>
        /// Сохранение базы под новым именем
        /// </summary>
        /// <returns></returns>
        public bool SaveAs()
        {
            string newfilename = ChooseFileNameToSave();
            if (newfilename == "") return false;
            if (Save())
            {
                filename = newfilename;
                return true;
            }
            else
            {
                return false;
            }
                
        }

        /// <summary>
        /// Сохранение базы под текущим именем,
        /// и если нет имени то запрос имени файла
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            string newfilename;
            if (filename == "")
            {
                newfilename = ChooseFileNameToSave();
            }
            else
            {
                newfilename = filename;
            }
            

            if (newfilename == "") return false;

            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Person>));
                using (Stream stream = new FileStream(newfilename, FileMode.Create, FileAccess.Write))
                {
                    xmlSerializer.Serialize(stream, list);
                }
                Saved = true; // успешное сохранение
                filename = newfilename;
                Program.MessageTool($"База данных успешно сохранена в файл {filename}");
                return true;
            }
            catch (Exception e)
            {
                Program.MessageToolError($"Ошибка записи в файл {newfilename}" + Environment.NewLine + $"Ошибка: {e.Message}");
                return false;
            }
        }

        /// <summary>
        /// Загрузка базы данных из файла
        /// </summary>
        /// <returns></returns>
        public bool Load()
        {
            string newfilename = ChooseFileNameToLoad();

            if (newfilename == "") return false;

            if (!File.Exists(newfilename))
            {
                Program.MessageToolError($"Файл {newfilename} отсутствует");
                return false;
            }

            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Person>));
                using (Stream stream = new FileStream(newfilename, FileMode.Open, FileAccess.Read))
                {
                    list = (List<Person>)xmlSerializer.Deserialize(stream);
                }
                Saved = true; // успешная загрузка, считаем что база сохранена
                filename = newfilename;
                return true;
            }
            catch (Exception e)
            {
                Program.MessageToolError($"Ошибка записи в файл {newfilename}" + Environment.NewLine + $"Ошибка: {e.Message}");
                return false;
            }
        }

    }
}
