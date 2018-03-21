using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;

namespace HomeWork.Tests
{
    /// <summary>
    /// CodedUITest1 的摘要描述
    /// </summary>
    [CodedUITest]
    public class CodedUITest1
    {
        private const string FILE_PATH = @"../../../104590046_HW3/bin/Debug/104590046_HW3.exe";
        private const string WINDOWS_TITLE = "EnglishTestForm";
        private const string CALCULATOR_TITLE = "TestForm";
        private readonly string[] _types = { "all fill-inblanksquestions", "all multiple-choices questions", "pick up questionsrandomly" };

        /// <summary>
        /// Launches the Calculator
        /// </summary>
        [TestInitialize()]
        public void Initialize()
        {
            Robot.Initialize(FILE_PATH, WINDOWS_TITLE);
            Keyboard.SendKeys("{Shift}");
        }

        /// <summary>
        /// Launches the Calculator
        /// </summary>

        [TestCleanup()]
        public void GoCleanup()
        {
            Robot.CleanUp();
        }

        //test

        [TestMethod()]
        public void TestStart()
        {
            Robot.ClickButton("Start");
            Robot.AssertButtonEnable("Start", false);
        }

        //test

        [TestMethod()]
        public void TestNext()
        {
            Robot.EnterTheKey("%s");
            Robot.EnterTheKey("%n");
            Robot.SendKeyEnterToMessageBox("");
        }

        //test

        [TestMethod()]
        public void TestStop()
        {
            Robot.EnterTheKey("%s");
            Robot.EnterTheKey("%t");
            Robot.SendKeyEnterToMessageBox("");
        }

        //test

        [TestMethod()]
        public void GoAboutDictionary()
        {
            Robot.EnterTheKey("%alt");
            Robot.EnterTheKey("%hd");
            Robot.SendKeyEnterToMessageBox("");
        }

        //test

        [TestMethod()]
        public void GoAboutSpellingChecker()
        {
            const string ABOUT_SPELLING_WINDOW = "About Spelling Checker";
            Keyboard.SendKeys("{Alt}");
            Keyboard.SendKeys("%h");
            Keyboard.SendKeys("c");
            Robot.AssertWindow(ABOUT_SPELLING_WINDOW);
            Robot.ClickOtherFormButton(ABOUT_SPELLING_WINDOW, "ok");
        }

        //test

        [TestMethod()]
        public void FileTest()
        {
            Robot.EnterTheKey("%alt");
            Robot.EnterTheKey("%fe");
        }

        //test

        [TestMethod()]
        public void GoExaminationStartTest()
        {
            Keyboard.SendKeys("{Alt}");
            Robot.EnterTheKey("%es");
        }

        //test

        [TestMethod()]
        public void GoExaminationNextTest()
        {
            Keyboard.SendKeys("{Alt}");
            Robot.EnterTheKey("%eo1");
            Keyboard.SendKeys("{Alt}");
            Robot.EnterTheKey("%es");
            Robot.EnterTheKey("%s");
            Keyboard.SendKeys("{Alt}");
            Robot.EnterTheKey("%en");
            Keyboard.SendKeys("{Alt}");
            Robot.EnterTheKey("%et");
        }

        //test

        [TestMethod()]
        public void GoExaminationStopTest()
        {
            Keyboard.SendKeys("{Alt}");
            Robot.EnterTheKey("%eo1");
            Keyboard.SendKeys("{Alt}");
            Robot.EnterTheKey("%es");
            Keyboard.SendKeys("{Alt}");
            Robot.EnterTheKey("%et");
            Robot.SendKeyEnterToMessageBox("");
        }

        //test

        [TestMethod()]
        public void GoExaminationTest()
        {
            Keyboard.SendKeys("{Alt}");
            Robot.EnterTheKey("%eo1");
            Robot.EnterTheKey("%eo2");
            Robot.EnterTheKey("%eo5");
            Robot.EnterTheKey("%eqf");
            Robot.EnterTheKey("%eqm");
            Robot.EnterTheKey("%equ");
        }

        //set question number test

        [TestMethod()]
        public void SetQuestionNumberTest()
        {
            Robot.SetNumericUpDown("NumberOfQuestion", "5");
            Robot.SetNumericUpDown("NumberOfQuestion", "87");
        }

        //test

        [TestMethod()]
        public void FillTopicTest()
        {
            Robot.SetNumericUpDown("NumberOfQuestion", "10");
            SelectQuestionType(0);
            Robot.ClickButton("Start");
            FillInputAndNext();
            EndTopicTest();
        }

        //test

        [TestMethod()]
        public void SelectTopicTest()
        {
            Robot.SetNumericUpDown("NumberOfQuestion", "5");
            SelectQuestionType(1);
            Robot.ClickButton("Start");
            SelectTopic();
            EndTopicTest();
        }

        //test
        private void FillInputAndNext()
        {
            Robot.SetEdit("FillInput", "test");
            Robot.ClickButton("Next");
        }

        // select question type test
        private void SelectQuestionType(int type)
        {
            Robot.SetComboBox("QuestionType", _types[type]);
        }

        // end topic test
        private void EndTopicTest()
        {
            Robot.ClickButton("Stop");
            Robot.SendKeyEnterToMessageBox("");
        }

        // select Radio
        private void SelectTopic()
        {
            Robot.ClickRadioButton("Radio1");
            Robot.ClickRadioButton("Radio2");
            Robot.ClickRadioButton("Radio3");
            Robot.ClickRadioButton("Radio4");
            Robot.ClickButton("Next");
        }
    }
}