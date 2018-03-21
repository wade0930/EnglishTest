using Microsoft.VisualStudio.TestTools.UnitTesting;
using HomeWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeWork.Tests
{
    [TestClass()]
    public class PresentationModelTests
    {
        //測試

        [TestMethod()]
        public void PresentationModelTest()
        {
            PresentationModel presentationModel = new PresentationModel(new Model());
            Model model = new Model();
            Assert.AreEqual(model.GetCount(), 0);
        }

        //測試

        [TestMethod()]
        public void IsBeginTest()
        {
            PresentationModel presentationModel = new PresentationModel(new Model());
            Assert.IsTrue(presentationModel.IsBegin());
        }

        //測試

        [TestMethod()]
        public void GetIndexCounterTest()
        {
            PresentationModel presentationModel = new PresentationModel(new Model());
            Assert.AreEqual(0, presentationModel.GetIndexCounter());
        }

        //測試

        [TestMethod()]
        public void StartTest()
        {
            PresentationModel presentationModel = new PresentationModel(new Model());
            const string TEN = "10";
            const int ONE = 1;
            presentationModel.Start(TEN, ONE);
            Assert.IsFalse(presentationModel.IsGetFill());
            Assert.IsTrue(presentationModel.IsGetMultiple());
        }

        //測試

        [TestMethod()]
        public void ClickNextFillTest()
        {
            const string STRING = "WADE";
            const string STR = "10";
            const string STR1 = "It should become!!";
            PresentationModel presentationModel = new PresentationModel(new Model());
            presentationModel.Start(STR, 0);
            presentationModel.ClickNextFill(STRING, 0);
            Assert.AreEqual(STR1, presentationModel.GetStatusText());
        }

        //測試

        [TestMethod()]
        public void ClickNextMultipleTest()
        {
            PresentationModel presentationModel = new PresentationModel(new Model());
            const string STR = "10";
            presentationModel.Start(STR, 0);
        }

        //測試

        [TestMethod()]
        public void SetUpTest()
        {
            PresentationModel presentationModel = new PresentationModel(new Model());
            const string STR = "10";
            presentationModel.Start(STR, 0);
            presentationModel.SetUp(0);
            Assert.IsTrue(presentationModel.IsGetFill());
            Assert.IsFalse(presentationModel.IsGetMultiple());
        }

        //測試

        [TestMethod()]
        public void SetViewTest()
        {
            PresentationModel presentationModel = new PresentationModel(new Model());
            presentationModel.SetView(false);
            Assert.IsTrue(presentationModel.IsGetFill());
            Assert.IsFalse(presentationModel.IsGetMultiple());
            presentationModel.SetView(true);
            Assert.IsTrue(presentationModel.IsGetMultiple());
            Assert.IsFalse(presentationModel.IsGetFill());
        }

        //測試

        [TestMethod()]
        public void IsGetFillTest()
        {
            PresentationModel presentationModel = new PresentationModel(new Model());
            Assert.IsTrue(presentationModel.IsGetFill());
        }

        //測試

        [TestMethod()]
        public void IsGetMultipleTest()
        {
            PresentationModel presentationModel = new PresentationModel(new Model());
            Assert.IsFalse(presentationModel.IsGetMultiple());
        }

        //測試

        [TestMethod()]
        public void GetUpdateTitleTest()
        {
            PresentationModel presentationModel = new PresentationModel(new Model());
            Model model = new Model();
            const string TEN = "10";
            const string STRING = "WADE";
            presentationModel.Start(TEN, 1);
            Assert.AreNotEqual(presentationModel.GetUpdateTitle(), STRING);
        }

        //測試

        [TestMethod()]
        public void GetStatusTextTest()
        {
            PresentationModel presentationModel = new PresentationModel(new Model());
            Assert.AreEqual("", presentationModel.GetStatusText());
        }

        //測試

        [TestMethod()]
        public void GetSelectionTextTest()
        {
            PresentationModel presentationModel = new PresentationModel(new Model());
            Assert.AreEqual("", presentationModel.GetSelectionText());
        }

        //測試

        [TestMethod()]
        public void AddCorrectTopicCounterTest()
        {
            PresentationModel presentationModel = new PresentationModel(new Model());
            Assert.AreEqual(1, presentationModel.AddCorrectTopicCounter());
        }

        //測試

        [TestMethod()]
        public void CheckLastDataTest()
        {
            PresentationModel presentationModel = new PresentationModel(new Model());
            Model model = new Model();
            const string TEN = "10";
            presentationModel.Start(TEN, 0);
            presentationModel.CheckLastData();
            Assert.AreEqual(1, presentationModel.GetIndexCounter());
        }

        //測試

        [TestMethod()]
        public void CheckViewTest()
        {
            PresentationModel presentationModel = new PresentationModel(new Model());
            RadioButton[] select = new RadioButton[4];
            const string STRING = "WADE";
            const string ERROR = "It should become!!";
            const string TEN = "10";
            presentationModel.Start(TEN, 0);
            presentationModel.CheckView(STRING, select, 0);
            Assert.AreEqual(ERROR, presentationModel.GetStatusText());
        }

        //測試

        [TestMethod()]
        public void GetDictionaryLengthTest()
        {
            const int NUMBER = 1081;
            PresentationModel presentationModel = new PresentationModel(new Model());
            Assert.AreEqual(NUMBER, presentationModel.GetDictionaryLength());
        }

        //測試
        [TestMethod()]
        public void IsStopEnableTest()
        {
            PresentationModel presentationModel = new PresentationModel(new Model());
            Assert.IsFalse(presentationModel.IsStopEnable());
        }

        //測試
        [TestMethod()]
        public void IsNextEnableTest()
        {
            PresentationModel presentationModel = new PresentationModel(new Model());
            Assert.IsFalse(presentationModel.IsNextEnable());
        }

        //測試
        [TestMethod()]
        public void IsStartEnableTest()
        {
            PresentationModel presentationModel = new PresentationModel(new Model());
            Assert.IsTrue(presentationModel.IsStartEnable());
        }

        //測試
        [TestMethod()]
        public void IsLastTest()
        {
            PresentationModel presentationModel = new PresentationModel(new Model());
            Assert.IsFalse(presentationModel.IsLast());
        }

        //測試
        [TestMethod()]
        public void IsGetFillTest1()
        {
            PresentationModel presentationModel = new PresentationModel(new Model());
            Assert.IsTrue(presentationModel.IsGetFill());
        }

        //測試
        [TestMethod()]
        public void IsGetMultipleTest1()
        {
            PresentationModel presentationModel = new PresentationModel(new Model());
            Assert.IsFalse(presentationModel.IsGetMultiple());
        }

        //測試
        [TestMethod()]
        public void SetStartTest()
        {
            PresentationModel presentationModel = new PresentationModel(new Model());
            Assert.IsTrue(presentationModel.IsStartEnable());
            Assert.IsFalse(presentationModel.IsNextEnable());
            Assert.IsTrue(presentationModel.IsBegin());
            Assert.IsFalse(presentationModel.IsStopEnable());
        }

        //測試
        [TestMethod()]
        public void SetEndTest1()
        {
            PresentationModel presentationModel = new PresentationModel(new Model());
            bool judge = true;
            presentationModel.SetEnd(judge);
            Assert.IsFalse(presentationModel.IsNextEnable());
            Assert.IsTrue(presentationModel.IsStartEnable());
            Assert.IsTrue(presentationModel.IsBegin());
            Assert.IsFalse(presentationModel.IsStopEnable());
        }

        //測試
        [TestMethod()]
        public void IsTimeTest()
        {
            PresentationModel presentationModel = new PresentationModel(new Model());
            presentationModel.Set(false);
            Assert.IsFalse(presentationModel.IsTime());
        }

        //測試
        [TestMethod()]
        public void GetScoreTest()
        {
            const int TEN = 10;
            PresentationModel presentationModel = new PresentationModel(new Model());
            presentationModel.GetScore(TEN);
        }

        //測試
        [TestMethod()]
        public void SetProgressTest()
        {
            const int TWO_THUSAND = 2000;
            const int THUSAND = 1000;
            PresentationModel presentationModel = new PresentationModel(new Model());
            Assert.AreEqual(TWO_THUSAND, presentationModel.SetProgress(THUSAND, TWO_THUSAND));
        }

        //測試
        [TestMethod()]
        public void CheckTimeTest()
        {
            PresentationModel presentationModel = new PresentationModel(new Model());
            const int TEN = 10;
            presentationModel.Set(true);
            Assert.AreEqual(TEN, presentationModel.CheckTime(TEN));
            presentationModel.Set(false);
            Assert.AreEqual(0, presentationModel.CheckTime(TEN));
        }
    }
}