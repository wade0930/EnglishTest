using Microsoft.VisualStudio.TestTools.UnitTesting;
using HomeWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.Tests
{
    [TestClass()]
    public class ModelTests
    {
        //測試

        private const int TEN = 10;
        private const int FIFTY = 50;
        private int ZERO = 0;
        private const int ONE = 1;
        private const int THREE = 3;
        private const int FOUR = 4;
        private const int FIVE = 5;
        private const int TWENTY = 20;
        private const int THIRTY = 30;
        private const int NUMBER = 1081;
        private const string LEFT = "(";
        private const string RIGHT = ")";
        private const string SPACE = " ";
        private const int MILLISECONDS_PER_SECOND = 1000;
        private const int TEN_SECOND = 10000;
        private const int TWENTY_THOUSAND = 2000;
        //測試

        [TestMethod()]
        public void LoadDataListTest()
        {
            Model model;
            model = new Model();
            model.LoadDataList(FIFTY);
            Assert.AreEqual(model.GetCount(), FIFTY);
            model.LoadDataList(TEN);
            Assert.AreEqual(model.GetCount(), TEN);
        }

        //測試

        [TestMethod()]
        public void IsRandomDataTest()
        {
            Model model;
            model = new Model();
            bool actual;
            actual = model.IsRandomData(ZERO);
            Assert.AreEqual(actual, false);
            actual = model.IsRandomData(ONE);
            Assert.AreEqual(actual, true);
            actual = model.IsRandomData(THREE);
            Assert.AreEqual(actual, true);
        }

        //測試

        [TestMethod()]
        public void GetDictionaryLengthTest()
        {
            Model model;
            model = new Model();
            Assert.AreEqual(model.GetDictionaryLength(), NUMBER);
        }

        //測試

        [TestMethod()]
        public void CheckLastDataListTest()
        {
            Model model;
            model = new Model();
            model.LoadDataList(THIRTY);
            Assert.IsTrue(model.CheckLastDataList(TEN));
            model.LoadDataList(TEN);
            Assert.IsFalse(model.CheckLastDataList(FIFTY));
        }

        //測試

        [TestMethod()]
        public void CheckIsSpeciesAnswerTest()
        {
            Model model;
            model = new Model();
            const string STR = "abcndjnck";
            model.LoadDataList(TEN);
            Assert.IsFalse(model.CheckIsSpeciesAnswer(TEN, STR));
            Assert.IsTrue(model.CheckIsSpeciesAnswer(FIVE, model.GetList()[FIVE]._english));
        }

        //測試

        [TestMethod()]
        public void GetAnswerTest()
        {
            Model model;
            model = new Model();
            model.LoadDataList(TEN);
            Assert.AreEqual(model.GetAnswer(THIRTY), "");
            model.LoadDataList(FIFTY);
            Assert.AreNotEqual(model.GetAnswer(THIRTY), "");
        }

        //測試

        [TestMethod()]
        public void GetSpeciesTitleTest()
        {
            Model model;
            model = new Model();
            model.LoadDataList(TEN);
            List<Word> tempList = new List<Word>();
            tempList = model.GetList();
            model.SetJudge(1);
            Assert.AreEqual(model.GetSpeciesTitle(THREE), tempList[THREE]._english);
            model.SetJudge(0);
            Assert.AreEqual(model.GetSpeciesTitle(FIVE), tempList[FIVE]._chinese + SPACE + model.AddLine(tempList[FIVE]._english) + LEFT + tempList[FIVE]._english.Count() + RIGHT);
        }

        //測試

        [TestMethod()]
        public void InsertRandomChoiceTest()
        {
            Model model = new Model();
            List<Word> tempList = new List<Word>();
            model.LoadDataList(TEN);
            model.InsertRandomChoice(THREE);
            tempList = model.ReturnChoice();
            Assert.IsNotNull(tempList);
        }

        //測試

        [TestMethod()]
        public void CheckSelectAnswerTest()
        {
            Model model = new Model();
            model.LoadDataList(TWENTY);
            List<Word> tempList = new List<Word>();
            tempList = model.GetList();
            Assert.IsFalse(model.CheckSelectAnswer(tempList[THREE]._chinese, FIVE));
            Assert.IsTrue(model.CheckSelectAnswer(tempList[FOUR]._chinese, FOUR));
        }

        //測試

        [TestMethod()]
        public void GetSelectionTextTest()
        {
            int count;
            count = ZERO;
            Model model = new Model();
            List<Word> tempList = new List<Word>();
            tempList = model.SetChoice(TEN);
            model.SetSelectCounter(ZERO);
            Assert.AreEqual(model.GetSelectionText(), LEFT + (count + 1).ToString() + RIGHT + tempList[count]._chinese);
        }

        //測試

        [TestMethod()]
        public void GenerateStringTest()
        {
            Model model = new Model();
            const string STR = "X";
            const string STR1 = "XXXX";
            const int FOUR = 4;
            Assert.AreEqual(model.GenerateString(STR, FOUR), STR1);
        }

        //測試

        [TestMethod()]
        public void AddLineTest()
        {
            Model model = new Model();
            const string STR = "HELLO";
            const string STR1 = "hi";
            const string STR2 = "H___O";
            const string STR3 = "__";
            Assert.AreEqual(model.AddLine(STR), STR2);
            Assert.AreEqual(model.AddLine(STR1), STR3);
        }

        //測試
        [TestMethod()]
        public void CalculateScoreTest()
        {
            Model model = new Model();
            model.Set(TEN);
            model.CalculateScore(ZERO, ONE);
            Assert.AreEqual(ZERO, model.GetScore());
            model.CalculateScore(TEN, TEN);
            Assert.AreEqual(TEN, model.GetScore());
            model.CalculateScore(TWENTY, FIFTY);
            Assert.AreEqual(TWENTY, model.GetScore());
            model.CalculateScore(TEN, FIFTY);
            Assert.AreEqual(TWENTY, model.GetScore());
        }

        //測試
        [TestMethod()]
        public void GetScoreTest()
        {
            Model model = new Model();
            Assert.AreEqual(ZERO, model.GetScore());
        }

        //測試
        [TestMethod()]
        public void CalculateProgressTest()
        {
            Model model = new Model();
            Assert.AreEqual(TWENTY_THOUSAND, model.CalculateProgress(MILLISECONDS_PER_SECOND, TEN_SECOND));
            Assert.AreEqual(ZERO, model.CalculateProgress(TEN_SECOND, MILLISECONDS_PER_SECOND));
        }
    }
}