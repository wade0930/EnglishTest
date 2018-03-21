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
        private ReadFile _dictionary = new ReadFile();
        private Model _model = new Model();
        private RadioButton[] _selection = new RadioButton[BUTTON_COUNT];
        private const string QUESTION_TITLE = "Q";
        private PresentationModel _presentationModel;
        private const int BUTTON_COUNT = 4;
        private const int TWO = 2;
        private const int THREE = 3;
        private const int TEN = 10;
        private const int TWENTY = 20;
        private const int FIFTY = 50;
        private bool _judge;
        private string _timerText;
        private int _time = 0;
        private const int MILLISECONDS_PER_SECOND = 1000;
        private const int TEN_SECOND = 10000;
        private Timer _timer = new Timer();
        private TimeSpan _timeSpan;

        public EnglishTestForm()
        {
            InitializeComponent();
        }

        public EnglishTestForm(PresentationModel presentationModel)
        {
            InitializeComponent();
            this._presentationModel = presentationModel;
            _typeSelection.Items.Add("all fill-inblanksquestions");
            _typeSelection.Items.Add("all multiple-choices questions");
            _typeSelection.Items.Add("pick up questionsrandomly");
            _pickUpToolStripMenuItem.Checked = true;
            _typeSelection.SelectedIndex = 0;
            _questionCount.Minimum = 1;
            _timer.Interval = MILLISECONDS_PER_SECOND;
            _questionTime.Interval = MILLISECONDS_PER_SECOND;
            _timer.Tick += TickEventHandler;
        }

        //建立選項按鈕
        public void SetSelection()
        {
            _selection[0] = _select1;
            _selection[1] = _select2;
            _selection[TWO] = _select3;
            _selection[THREE] = _select4;
        }

        //updata question
        private void UpdateTitle()
        {
            SetSelectionText();
            SetQuestionText();
            SetQuestionNumber();
        }

        //設定題目
        public void SetQuestionText()
        {
            _multipleTitle.Text = _presentationModel.GetUpdateTitle();
            _fillTitle.Text = _presentationModel.GetUpdateTitle();
        }

        //設定選項文字
        public void SetSelectionText()
        {
            SetSelection();
            for (int i = 0; i < BUTTON_COUNT; i++)
            {
                _selection[i].Text = _presentationModel.GetSelectionText();
            }
        }

        //設定題號
        public void SetQuestionNumber()
        {
            _multipleChoiceQuestions.Text = QUESTION_TITLE + (_presentationModel.GetIndexCounter() + 1).ToString();
            _fillTest.Text = QUESTION_TITLE + (_presentationModel.GetIndexCounter() + 1).ToString();
        }

        //刷新的動作
        private void RefreshControl()
        {
            _judge = _presentationModel.IsLast();
            _questionTime.Enabled = _presentationModel.IsTime();
            _timer.Enabled = _presentationModel.IsTime();
            _presentationModel.SetEnd(_judge);
            _begin.Visible = _presentationModel.IsBegin();
            _fillTest.Visible = _presentationModel.IsGetFill();
            _multipleChoiceQuestions.Visible = _presentationModel.IsGetMultiple();
            _start.Enabled = _presentationModel.IsStartEnable();
            _next.Enabled = _presentationModel.IsNextEnable();
            _stop.Enabled = _presentationModel.IsStopEnable();
        }

        //開始按鈕的動作
        private void ClickStart(object sender, EventArgs e)
        {
            SetSelection();
            _timer.Start();
            _questionTime.Start();
            _presentationModel.SetStart();
            _presentationModel.Start(_questionCount.Value.ToString(), _typeSelection.SelectedIndex);
            RefreshControl();
            UpdateTitle();
        }

        //下次按鈕的動作
        private void ClickNext(object sender, EventArgs e)
        {
            SetSelection();
            _presentationModel.CheckView(_answer.Text, _selection, _typeSelection.SelectedIndex);
            _time = _presentationModel.CheckTime(_time);
            _statusText.Text = _presentationModel.GetStatusText();
            _progressBar.Value = 0;
            _answer.Text = "";
            RefreshControl();
            UpdateTitle();
        }

        //停止按鈕的動作
        private void ClickStop(object sender, EventArgs e)
        {
            _presentationModel.SetEnd();
            _time = _presentationModel.CheckTime(_time);
            _progressBar.Value = 0;
            RefreshControl();
        }

        //Exit結束選單
        private void ClickExitToolStripMenuItem(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //開始選單
        private void ClickStartToolStripMenuItem(object sender, EventArgs e)
        {
            ClickStart(sender, e);
        }

        //Next選單
        private void ClickNextToolStripMenuItem(object sender, EventArgs e)
        {
            ClickNext(sender, e);
        }

        //Stop選單
        private void ClickStopToolStripMenuItem(object sender, EventArgs e)
        {
            ClickStop(sender, e);
        }

        //10題
        private void ClickTenQuestionToolStripMenuItem(object sender, EventArgs e)
        {
            _questionCount.Value = TEN;
        }

        //20題
        private void ClickTwentyQuestionsToolStripMenuItem(object sender, EventArgs e)
        {
            _questionCount.Value = TWENTY;
        }

        //50題
        private void ClickFiftyQuestionsToolStripMenuItem1(object sender, EventArgs e)
        {
            _questionCount.Value = FIFTY;
        }

        //有關字典選單
        private void ClickAboutToolStripMenuItem(object sender, EventArgs e)
        {
            const string TOTAL = "Total ";
            const string STRING = "words in the dictionary.";
            MessageBox.Show(TOTAL + _presentationModel.GetDictionaryLength().ToString() + STRING);
        }

        //全部填充選單
        private void ClickAllFillInTheToolStripMenuItem(object sender, EventArgs e)
        {
            _typeSelection.SelectedIndex = 0;
            _allFillInTheToolStripMenuItem.Checked = true;
            _allMultipleToolStripMenuItem.Checked = false;
            _pickUpToolStripMenuItem.Checked = false;
        }

        //全部選擇選單
        private void ClickAllMultipleToolStripMenuItem(object sender, EventArgs e)
        {
            _typeSelection.SelectedIndex = 1;
            _allFillInTheToolStripMenuItem.Checked = false;
            _allMultipleToolStripMenuItem.Checked = true;
            _pickUpToolStripMenuItem.Checked = false;
        }

        //隨機選單
        private void ClickPickUpToolStripMenuItem(object sender, EventArgs e)
        {
            _typeSelection.SelectedIndex = TWO;
            _allFillInTheToolStripMenuItem.Checked = false;
            _allMultipleToolStripMenuItem.Checked = false;
            _pickUpToolStripMenuItem.Checked = true;
        }

        //help選單跳出另外一個視窗
        private void ClickAboutSpellerToolStripMenuItem(object sender, EventArgs e)
        {
            AboutSpellingCheckerForm form = new AboutSpellingCheckerForm();
            form.ShowDialog();
        }
    }
}