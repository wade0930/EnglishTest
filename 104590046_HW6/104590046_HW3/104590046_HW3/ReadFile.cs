using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    public class ReadFile
    {
        private List<Word> _elements = new List<Word>();

        //讀檔
        public ReadFile()
        {
            const string EMPTY_LINE = "";
            const string FILE_NAME = "../../EnglishTest.txt";
            StreamReader file = new StreamReader(FILE_NAME, Encoding.Default);
            while (!file.EndOfStream)
            {
                // Read a new line
                string line = file.ReadLine();
                // Ignore the line, if it is empty
                if (line.Equals(EMPTY_LINE))
                    continue;
                Cut(line);
                //Cut(line);
            }
            file.Close();
        }

        //切割字串
        public void Cut(string line)
        {
            const string WORD = ">>>";
            Word tempSpecies;
            string[] dictionary = line.Split(new string[] { WORD },
            StringSplitOptions.RemoveEmptyEntries);
            tempSpecies = new Word
            {
                _english = dictionary[0].Trim(),
                _chinese = dictionary[1].Trim()
            };
            _elements.Add(tempSpecies);
        }

        //隨機抓題目
        public List<Word> GetRandomData(int length)
        {
            Random random = new Random();
            int index = 0;
            List<Word> tempList = new List<Word>();
            for (int i = 0; i < length; i++)
            {
                index = random.Next(0, this._elements.Count());
                tempList.Add(this._elements[index]);
            }
            return tempList;
        }

        //回傳字典長度
        public int GetDictionaryLength()
        {
            return _elements.Count;
        }

        //回傳elements做測試
        public List<Word> GetElements()
        {
            return _elements;
        }
    }
}