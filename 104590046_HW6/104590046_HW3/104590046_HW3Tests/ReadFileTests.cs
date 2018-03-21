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
    public class ReadFileTests
    {
        //測試

        [TestMethod()]
        public void ReadFileTest()
        {
            ReadFile dictionary;
            dictionary = new ReadFile();
            Assert.AreEqual(dictionary.GetDictionaryLength(), 1081);
        }

        //測試

        [TestMethod()]
        public void CutTest()
        {
            ReadFile dictionary;
            dictionary = new ReadFile();
            const string STRING = "ABCD>>>哈哈哈";
            const string STR = "ABCD";
            const string STR1 = "哈哈哈";
            dictionary.Cut(STRING);
            Assert.AreEqual(dictionary.GetElements().Last<Word>()._english, STR);
            Assert.AreEqual(dictionary.GetElements().Last<Word>()._chinese, STR1);
        }

        //測試

        [TestMethod()]
        public void GetRandomDataTest()
        {
            ReadFile dictionary;
            dictionary = new ReadFile();
            const int TEN = 10;
            List<Word> tempList = new List<Word>();
            tempList = dictionary.GetRandomData(TEN);
            for (int i = 0; i < TEN; i++)
            {
                for (int j = i + 1; j < TEN; j++)
                {
                    Assert.AreNotEqual(tempList[i], tempList[j]);
                }
            }
        }

        //測試

        [TestMethod()]
        public void GetDictionaryLengthTest()
        {
            ReadFile dictionary = new ReadFile();
            const int NUMBER = 1081;
            Assert.AreEqual(dictionary.GetDictionaryLength(), NUMBER);
        }
    }
}