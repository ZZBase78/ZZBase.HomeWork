using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lession08
{
    public class TrueFalse
    {

        #region Fields

        private string fileName;
        private List<Question> list;
        private bool saved; // флаг, что база данных сохранена, после изменений

        public string FileName
        {
            set { fileName = value; }
        }

        public bool Saved
        {
            get
            {
                return saved;
            }
        }

        #endregion

        #region Constructors

        public TrueFalse(string fileName)
        {
            this.fileName = fileName;
            list = new List<Question>();
            saved = false; // база создана, но не сохранялась после изменений данных
        }

        #endregion

        #region Public Properties

        public Question this[int index]
        {
            get { return list[index]; }
        }

        public int Count
        {
            get { return list.Count; }
        }

        #endregion

        #region Public Methods

        public void Add(string text, bool trueFalse)
        {
            list.Add(new Question(text, trueFalse));
            saved = false;
        }

        public void Remove(int index)
        {
            if (list != null && index < list.Count && index >= 0)
            {
                list.RemoveAt(index);
                saved = false;
            }
                
        }

        public bool Load()
        {
            if (File.Exists(fileName))
            {
                FileInfo fileInfo = new FileInfo(fileName);
                if (fileInfo.Length > 1000000)
                {
                    Program.MessageToolError($"Файл {fileName} слишком большого размера");
                    return false;
                }
            }
            else
            {
                Program.MessageToolError($"Файл {fileName} отсутствует");
                return false;
            }

            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Question>));
                using (Stream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    list = (List<Question>)xmlSerializer.Deserialize(stream);
                }
                saved = true; // успешная загрузка, считаем что база сохранена
                return true;
            }
            catch (Exception e)
            {
                Program.MessageToolError($"Ошибка чтения файла {fileName}" + Environment.NewLine + $"Ошибка: {e.Message}");
                return false;
            }
        }

        public bool Save()
        {

            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Question>));
                using (Stream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                {
                    xmlSerializer.Serialize(stream, list);
                }
                saved = true; // успешное сохранение
                return true;
            }
            catch (Exception e)
            {
                Program.MessageToolError($"Ошибка записи в файл {fileName}" + Environment.NewLine + $"Ошибка: {e.Message}");
                return false;
            }

        }

        public bool SaveAs(string newfilename)
        {

            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Question>));
                using (Stream stream = new FileStream(newfilename, FileMode.Create, FileAccess.Write))
                {
                    xmlSerializer.Serialize(stream, list);
                }
                //В случае успешного сохранения, меняем имя связанного файла
                FileName = newfilename;
                saved = true; // успешное сохранение
                return true;
            }
            catch (Exception e)
            {
                //В случае ошибки ничего не меняем
                Program.MessageToolError($"Ошибка записи в файл {fileName}" + Environment.NewLine + $"Ошибка: {e.Message}");
                return false;
            }

        }

        #endregion

    }
}
