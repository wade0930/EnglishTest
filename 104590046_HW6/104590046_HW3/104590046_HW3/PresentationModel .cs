using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeWork
{
    public partial class PresentationModel
    {
        private Model _model;
        private int _indexCounter = 0;
        private int _correctTopicCounter = 0;
        private string _message = "";
        private const int THREE = 3;
        private const int BUTTON_COUNT = 4;
        private const string CORRECT = "Correct";
        private const string ERROR = "It should become!!";
        private const string PASS = "you pass ";
        private const string QUESTION_TITLE = "Q";
        private const string QUESTION = " questions!!";
        private const string OF = " of ";
        private int _score = 0;
        private Timer _time = new Timer();
        private string _modifyAnswer;
        private const string DOT = ".";
        private const string CHANGE_ROW = "\n";

        public PresentationModel(Model model)
        {
            this._model = model;
        }

        //傳回現在題數
        public int GetIndexCounter()
        {
            return _indexCounter;
        }

        //開始的初始
        public void Start(string questionCount, int type)
        {
            _last = false;
            _time.Enabled = true;
            _model.LoadDataList(Convert.ToInt32(questionCount));
            _judge = _model.IsRandomData(type);
            if (_judge)
                _model.InsertRandomChoice(_indexCounter);
            SetView(_judge);
        }

        //下次填充題
        public void ClickNextFill(string answer, int type)
        {
            if (_model.CheckIsSpeciesAnswer(_indexCounter, answer))
            {
                AddCorrectTopicCounter();
                _message = CORRECT;
            }
            else
            {
                RecordError();
                _message = ERROR;
            }
            SetUp(type);
        }

        //下次選擇題
        public void ClickNextMultiple(RadioButton[] select, int type)
        {
            for (int i = 0; i < BUTTON_COUNT; i++)
            {
                if (select[i].Checked)
                {
                    if (_model.CheckSelectAnswer(select[i].Text.Substring(THREE), _indexCounter))
                    {
                        AddCorrectTopicCounter();
                        _message = CORRECT;
                    }
                    else
                    {
                        RecordError();
                        _message = ERROR;
                    }
                }
            }
            SetUp(type);
        }

        //記錄錯的答案並把正確答案記下來
        public void RecordError()
        {
            _modifyAnswer += ((_indexCounter + 1).ToString() + DOT + _model.GetAnswer(_indexCounter) + CHANGE_ROW);
        }

        //設定和下一題的版面設定
        public void SetUp(int type)
        {
            CheckLastData();
            _judge = _model.IsRandomData(type);
            if (_judge)
                _model.InsertRandomChoice(_indexCounter);
            if (_last == false)
                SetView(_judge);
        }

        //設定是選擇題的介面還是填充題的介面
        public void SetView(bool judge)
        {
            if (judge == false && _last == false)
            {
                _fill = true;
                _multiple = false;
            }
            else if (judge == true && _last == false)
            {
                _fill = false;
                _multiple = true;
            }
        }

        //得到題目
        public string GetUpdateTitle()
        {
            return _model.GetSpeciesTitle(_indexCounter);
        }

        //得到狀態
        public string GetStatusText()
        {
            return _message;
        }

        //顯示最後的對話框
        public void SetEnd()
        {
            _time.Enabled = false;
            MessageBox.Show(PASS + _correctTopicCounter.ToString() + OF + (_indexCounter + 1).ToString() + QUESTION + CHANGE_ROW + _modifyAnswer);
            _indexCounter = 0;
            _correctTopicCounter = 0;
            _modifyAnswer = "";
            _last = true;
            _fill = false;
            _multiple = false;
            _message = "";
        }

        //得到選擇題題目的選項
        public string GetSelectionText()
        {
            if (_judge)
                return _model.GetSelectionText();
            return "";
        }

        //對的題目數量
        public int AddCorrectTopicCounter()
        {
            _correctTopicCounter++;
            return _correctTopicCounter;
        }

        //檢查是否為最後一題
        public void CheckLastData()
        {
            if (_model.CheckLastDataList(_indexCounter + 1) == false)
            {
                SetEnd();
            }
            else
            {
                _indexCounter++;
            }
        }

        //判斷是選擇還是填充
        public void CheckView(string answer, RadioButton[] select, int type)
        {
            if (_judge)
            {
                ClickNextMultiple(select, type);
            }
            else
            {
                ClickNextFill(answer, type);
            }
        }

        //取得字典長度
        public int GetDictionaryLength()
        {
            return _model.GetDictionaryLength();
        }

        //回傳分數
        public int GetScore(int time)
        {
            _model.CalculateScore(_correctTopicCounter, time);
            _score = _model.GetScore();
            return _score;
        }

        //設定進度條
        public int SetProgress(int value, int max)
        {
            return _model.CalculateProgress(value, max);
        }

        //確認時間始否啟動
        public int CheckTime(int time)
        {
            if (_time.Enabled == false)
                return 0;
            return time;
        }

        //unitTest
        public void SetCorrect(int correct)
        {
            _correctTopicCounter = correct;
        }
    }
}