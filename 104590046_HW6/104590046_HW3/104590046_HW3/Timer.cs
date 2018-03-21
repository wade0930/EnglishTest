using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeWork
{
    public partial class EnglishTestForm : Form
    {
        private const string SCORE = "Score:";
        private const string STRING = "{0:D2}:{1:D2}:{2:D2}";

        //timer設定
        public void TickEventHandler(object sender, EventArgs e)
        {
            _time++;
            _timeSpan = TimeSpan.FromSeconds(_time);//使用TimeSpan來進行時間顯示的設定
            _timerText = string.Format(STRING, _timeSpan.Hours, _timeSpan.Minutes, _timeSpan.Seconds);//因為希望顯示格式為00:00:00 所以用這樣的方式。以{0:D2}為例：0是表示顯示順序在最左邊(依序向右用1,2..來決定顯示順序)。D2表示要顯示的位數為2位，也就是00。中間用 : 來分隔
            _timeCount.Text = _timerText;
        }

        //timer設定
        private void SetQuestionTimeTick(object sender, EventArgs e)
        {
            _progressBar.Minimum = 0;
            _progressBar.Maximum = TEN_SECOND;
            _progressBar.Value = _presentationModel.SetProgress(_progressBar.Value, _progressBar.Maximum);
            _score.Text = SCORE + _presentationModel.GetScore(_progressBar.Value).ToString();
        }
    }
}