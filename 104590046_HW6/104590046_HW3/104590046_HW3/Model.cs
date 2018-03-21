using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    public class Model
    {
        private List<Word> _dataList;
        private List<Word> _choice;
        private const int TWO = 2;
        private const int ONE = 1;
        private const int THREE = 3;
        private const string LEFT = "(";
        private const string RIGHT = ")";
        private const string BOTTOM_LINE = "_";
        private const string SPACE = " ";
        private int _selectCounter = 0;
        private Random _random = new Random(0);
        private int _judge;
        private const int BUTTON_COUNT = 4;
        private ReadFile _dictionary = new ReadFile();
        private int _count = 0;
        private int _score = 0;
        private const int MILLISECONDS_PER_SECOND = 1000;
        private const int TEN_SECOND = 10000;
        private const int HUNDRED = 100;
        private int _correctCounter = 0;

        //載入資料
        public void LoadDataList(int count)
        {
            _dataList = _dictionary.GetRandomData(count);
            _count = count;
        }

        //回傳資料給unittest測試
        public List<Word> GetList()
        {
            return _dataList;
        }

        //回傳count 給unittest測試
        public int GetCount()
        {
            return _count;
        }

        //決定哪種型態
        public bool IsRandomData(int type)
        {
            if (type == 0)
            {
                _judge = 0;
                return false;
            }
            else if (type == 1)
            {
                _judge = 1;
                return true;
            }
            else
            {
                _judge = _random.Next(0, TWO);
                if (_judge == 0)
                    return false;
                return true;
            }
        }

        //取得字典長度
        public int GetDictionaryLength()
        {
            return _dictionary.GetDictionaryLength();
        }

        //typesetting
        public string GenerateString(string text, int number)
        {
            string tempString = "";
            for (int i = 0; i < number; i++)
            {
                tempString += text;
            }

            return tempString;
        }

        //typesetting
        public string AddLine(string title)
        {
            if (title.Length > TWO)
                return title[0].ToString() + GenerateString(BOTTOM_LINE, title.Length - TWO) +
                title[title.Length - ONE].ToString();
            else
                return GenerateString(BOTTOM_LINE, TWO);
        }

        //check
        public bool CheckLastDataList(int index)
        {
            return _dataList.Count() > index;
        }

        //checkanswer
        public bool CheckIsSpeciesAnswer(int index, string answer)
        {
            if (GetAnswer(index).Equals(answer))
                return true;
            else
                return false;
        }

        //getanswer
        public string GetAnswer(int index)
        {
            return CheckLastDataList(index) ? _dataList[index]._english : "";
        }

        //為了unitTest
        public void SetJudge(int index)
        {
            _judge = index;
        }

        //gettitle
        public string GetSpeciesTitle(int index)
        {
            if (_judge == 0)
            {
                return _dataList[index]._chinese + SPACE + AddLine(_dataList[index]._english) + LEFT + _dataList[index]._english.Count() + RIGHT;
            }
            else
                return _dataList[index]._english;
        }

        //隨機排序選擇題選項
        public void InsertRandomChoice(int index)
        {
            int count = 0;
            _selectCounter = 0;
            _choice = _dictionary.GetRandomData(THREE);
            while (_choice[count] == _dataList[index])
            {
                _choice = _dictionary.GetRandomData(THREE);
            }
            _choice.Insert(_random.Next(_choice.Count + 1), _dataList[index]);
            ReturnChoice();
        }

        //unitTest
        public List<Word> ReturnChoice()
        {
            return _choice;
        }

        //檢查選擇題的答案是否正確
        public bool CheckSelectAnswer(string selectionAnswer, int index)
        {
            if (selectionAnswer == _dataList[index]._chinese)
                return true;
            return false;
        }

        //unitTest
        public List<Word> SetChoice(int count)
        {
            _choice = _dictionary.GetRandomData(count);
            return _choice;
        }

        //unitTest
        public void SetSelectCounter(int index)
        {
            _selectCounter = index;
        }

        //得到選擇題選項的題目
        public string GetSelectionText()
        {
            string select;
            select = LEFT + (_selectCounter + 1).ToString() + RIGHT + _choice[_selectCounter]._chinese;
            _selectCounter++;
            return select;
        }

        //計算分數
        public void CalculateScore(int correctCounter, int time)
        {
            if (correctCounter > _correctCounter)
            {
                _score += (HUNDRED / _count) - time / TEN_SECOND;
                _correctCounter = correctCounter;
            }
        }

        //回傳分數
        public int GetScore()
        {
            return _score;
        }

        //計算每題剩下多少時間
        public int CalculateProgress(int value, int max)
        {
            if (value < max)
                value += MILLISECONDS_PER_SECOND;
            if (value == TEN_SECOND || value > max)
            {
                _score--;
                value = 0;
            }
            return value;
        }

        //UntiTest
        public void Set(int count)
        {
            _count = count;
        }
    }
}